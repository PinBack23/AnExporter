using Devart.Data.Oracle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExporter
{
    public class Exporter
    {
        #region Attributes

        private const string CreateTabelFileName = "create.sql";
        private const string ExportFileName = "export.sql";
        private static Encoding TextEncoding = Encoding.GetEncoding("iso-8859-1");

        private string msCurrentExportZip;
        private FileStream moExportStream;
        private ZipArchive moExportZipArchive;
        private ZipArchiveEntry moExportZipArchiveEntry;
        private StreamWriter moExportWriter;
        private Dictionary<int, string> moColumnTypes;

        #endregion

        #region Public Methods / Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public string DB { get; set; }

        [JsonIgnoreAttribute]
        public bool LoginReady { get; private set; }

        public void CheckLogin()
        {
            this.ReadSysdate();
            this.LoginReady = true;
        }

        public async Task Export(string psExportTableName, string psSelect, IProgress<string> poProgress)
        {
            const string lsFormat = "Records: {0}/{1}";
            await Task.Run(() =>
            {
                int lnAllRecordCounter = 0;
                int lnRecordCounter = 0;
                DataTable loDT = null;

                this.PrepareExportData(psExportTableName);

                try
                {
                    using (OracleConnection loConnection = this.CreateConnection())
                    {
                        using (OracleCommand loCmd = loConnection.CreateCommand())
                        {
                            loCmd.CommandType = CommandType.Text;
                            loCmd.CommandText = "select count(*) from ({0})".FormatWith(psSelect);
                            lnAllRecordCounter = Convert.ToInt32(loCmd.ExecuteScalar());
                            poProgress.Report(lsFormat.FormatWith(0, lnAllRecordCounter));
                        }

                        using (OracleCommand loCmd = loConnection.CreateCommand())
                        {
                            loCmd.CommandType = CommandType.Text;
                            loCmd.CommandText = psSelect;

                            using (var loDR = loCmd.ExecuteReader())
                            {

                                loDT = loDR.GetSchemaTable();

                                this.CreateColumnTypes(loDT);
                                this.OpenExportFile();

                                this.WriteCreateTable(psExportTableName, loDT);

                                this.OpenExportWriter();
                                string lsFormatString = this.CreateTableExportFormatString(psExportTableName, loDT);

                                this.WriteLine("set feedback off");
                                this.WriteLine("set define off");

                                object[] loValues = null;
                                while (loDR.Read())
                                {
                                    loValues = new object[loDR.FieldCount];
                                    loDR.GetValues(loValues);

                                    this.WriteLine(this.CreateInsertLine(lsFormatString, loValues));
                                    poProgress.Report(lsFormat.FormatWith(++lnRecordCounter, lnAllRecordCounter));

                                    if (lnRecordCounter % 10000 == 0)
                                        this.WriteLine("commit;");
                                }
                                loDR.Close();
                                this.WriteLine("commit;");
                            }

                        }
                    }
                }
                finally
                {
                    this.CloseExportFile();
                }
            });
        }

        public async Task Import(string psFileName, IProgress<string> poProgress)
        {
            await Task.Run(() =>
            {
                int lnCounter = 0;
                string lsLine;
                using (var loReader = new StreamReader(psFileName, TextEncoding))
                {
                    loReader.ReadLine();
                    loReader.ReadLine();
                    using (OracleConnection loConnection = this.CreateConnection())
                    {
                        using (OracleCommand loCmd = loConnection.CreateCommand())
                        {
                            loCmd.CommandType = CommandType.Text;
                            while ((lsLine = loReader.ReadLine()) != null)
                            {
                                loCmd.CommandText = lsLine;
                                if (lsLine.StartsWith("insert"))
                                    loCmd.CommandText += loReader.ReadLine();
                                loCmd.CommandText = loCmd.CommandText.TrimEnd(';');

                                try
                                {
                                    loCmd.ExecuteNonQuery();

                                    if (loCmd.CommandText.StartsWith("insert"))
                                        poProgress.Report("Import record: {0}".FormatWith(++lnCounter));

                                }
                                catch
                                {
                                    //Nix machen
                                }
                            }
                        }
                    }
                }
            });
        }

        #endregion

        #region Private Methods / Properties

        private DateTime ReadSysdate()
        {
            using (OracleConnection loConnection = this.CreateConnection())
            {
                using (OracleCommand loCmd = loConnection.CreateCommand())
                {
                    loCmd.CommandType = CommandType.Text;
                    loCmd.CommandText = "select sysdate from dual";
                    return Convert.ToDateTime(loCmd.ExecuteScalar());
                }
            }
        }

        private OracleConnection CreateConnection()
        {
            OracleConnection loConnection;
            OracleConnectionStringBuilder loBuilder = new OracleConnectionStringBuilder();
            loBuilder.UserId = this.UserName;
            loBuilder.Password = this.Password;
            loBuilder.Server = this.DB;

            loConnection = new OracleConnection(loBuilder.ConnectionString);

            loConnection.Open();
            return loConnection;
        }

        private void PrepareExportData(string psExportTableName)
        {
            this.msCurrentExportZip = Path.Combine(System.Environment.CurrentDirectory, "{0}.zip".FormatWith(psExportTableName));
            if (File.Exists(this.msCurrentExportZip))
                File.Delete(this.msCurrentExportZip);
        }

        private void OpenExportFile()
        {
            this.moExportStream = new FileStream(this.msCurrentExportZip, FileMode.Create);
            this.moExportZipArchive = new ZipArchive(this.moExportStream, ZipArchiveMode.Create);
        }

        private void OpenExportWriter()
        {
            this.moExportZipArchiveEntry = this.moExportZipArchive.CreateEntry(ExportFileName);
            this.moExportWriter = new StreamWriter(this.moExportZipArchiveEntry.Open(), TextEncoding);
        }

        private void CloseExportFile()
        {
            if (this.moExportWriter != null)
            {
                this.moExportWriter.Dispose();
                this.moExportWriter = null;
            }
            if (this.moExportZipArchive != null)
            {
                this.moExportZipArchive.Dispose();
                this.moExportZipArchive = null;
            }
            if (this.moExportStream != null)
            {
                this.moExportStream.Dispose();
                this.moExportStream = null;
            }
        }

        private void WriteLine(string psLine)
        {
            this.moExportWriter.WriteLine(psLine);
        }

        private void CreateColumnTypes(DataTable poSchemaTable)
        {
            this.moColumnTypes = new Dictionary<int, string>();
            foreach (DataRow loRow in poSchemaTable.AsEnumerable().OrderBy(r => r.Field<int>("ColumnOrdinal")))
            {
                this.moColumnTypes.Add(loRow.Field<int>("ColumnOrdinal"), loRow.Field<string>("TypeName"));
            }
        }

        private void WriteCreateTable(string psExportTableName, DataTable poSchemaTable)
        {
            StringBuilder loBuilder = new StringBuilder();
            string lsType, lsNotNull;

            loBuilder.AppendFormat("create table {0}", psExportTableName);
            loBuilder.AppendLine();
            loBuilder.Append("(");

            foreach (DataRow loRow in poSchemaTable.AsEnumerable().OrderBy(r => r.Field<int>("ColumnOrdinal")))
            {
                loBuilder.AppendLine();
                lsType = loRow.Field<string>("TypeName");
                if (lsType == "VARCHAR2" || lsType == "CHAR")
                    lsType += "({0})".FormatWith(loRow.Field<int>("ColumnSize"));
                else if (lsType == "NUMBER")
                {
                    short lnNumericPrecision = loRow.Field<short>("NumericPrecision");
                    short lnNumericScale = loRow.Field<short>("NumericScale");

                    if (lnNumericPrecision > 0 && lnNumericScale > 0)
                        lsType += "({0},{1})".FormatWith(lnNumericPrecision, lnNumericScale);
                    else if (lnNumericPrecision > 0)
                        lsType += "({0})".FormatWith(lnNumericPrecision);
                }

                lsNotNull = string.Empty;
                if (!loRow.Field<bool>("AllowDBNull"))
                    lsNotNull = "not null";
                loBuilder.AppendFormat("{0} {1} {2},", loRow.Field<string>("ColumnName"), lsType, lsNotNull);
            }

            loBuilder.Remove(loBuilder.Length - 1, 1);
            loBuilder.AppendLine();
            loBuilder.AppendLine(")");
            loBuilder.AppendLine("/");

            var loCreatTableEntry = this.moExportZipArchive.CreateEntry(CreateTabelFileName);
            using (var loCreateTableWriter = new StreamWriter(loCreatTableEntry.Open(), TextEncoding))
            {
                loCreateTableWriter.Write(loBuilder.ToString());
            }
        }

        private string CreateTableExportFormatString(string psExportTableName, DataTable poSchemaTable)
        {
            StringBuilder loBuilder = new StringBuilder();

            loBuilder.AppendFormat("insert into {0} (", psExportTableName);
            foreach (DataRow loRow in poSchemaTable.AsEnumerable().OrderBy(r => r.Field<int>("ColumnOrdinal")))
            {
                loBuilder.AppendFormat("{0},", loRow.Field<string>("ColumnName"));
            }

            loBuilder.Remove(loBuilder.Length - 1, 1);
            loBuilder.AppendLine(") values (");

            foreach (DataRow loRow in poSchemaTable.AsEnumerable().OrderBy(r => r.Field<int>("ColumnOrdinal")))
            {
                loBuilder.Append("{" + loRow.Field<int>("ColumnOrdinal").ToString() + "},");
            }

            loBuilder.Remove(loBuilder.Length - 1, 1);
            loBuilder.Append(");");
            return loBuilder.ToString();
        }

        private string CreateInsertLine(string psExportFormatString, object[] poValues)
        {
            string[] loStringValues = new string[poValues.Length];
            for (int i = 0; i < poValues.Length; i++)
            {
                if (poValues[i].IsNull())
                    loStringValues[i] = "null";
                else if (this.moColumnTypes[i] == "VARCHAR2" || this.moColumnTypes[i] == "CHAR")
                    loStringValues[i] = "'{0}'".FormatWith(poValues[i].OracleStringValue());
                else if (this.moColumnTypes[i] == "NUMBER")
                    loStringValues[i] = "{0}".FormatWith(poValues[i]);
                else if (this.moColumnTypes[i] == "DATE")
                    loStringValues[i] = "to_date('{0:ddMMyyyy HHmmss}','ddmmyyyy HH24:MI:SS')".FormatWith(poValues[i]);
            }
            return psExportFormatString.FormatWith(loStringValues);
        }

        #endregion
    }
}
