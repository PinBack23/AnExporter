using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnExporter
{
    public partial class FrmExporter : Form
    {
        #region Attributes

        private const string ExportConfig = @"ExportConfig.data";

        private Exporter moExporter;

        #endregion

        #region Constructor / Destructor

        public FrmExporter()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            try
            {
                this.LoadExportConfig();
            }
            catch { }

            if (this.moExporter == null)
                this.moExporter = new Exporter();
            this.txtUser.Text = this.moExporter.UserName;
            this.txtPassword.Text = this.moExporter.Password;
            this.txtDB.Text = this.moExporter.DB;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                this.SaveExportConfig();
            }
            catch { }
            base.OnClosing(e);
        }

        #endregion

        #region Private Methods / Properties

        private void LoadExportConfig()
        {
            if (File.Exists(ExportConfig))
                this.moExporter = Newtonsoft.Json.JsonConvert.DeserializeObject<Exporter>(File.ReadAllText(ExportConfig));
        }

        private void SaveExportConfig()
        {
            File.WriteAllText(ExportConfig, Newtonsoft.Json.JsonConvert.SerializeObject(this.moExporter));
        }

        public void ErrorCatcher(object sender, Exception exp)
        {
            try
            {
                this.lsbLog.Items.Add(exp.Message);
            }
            catch
            {
            }
        }

        private void ReportProgress(string psProgress)
        {
            this.lblExportInProgress.Text = psProgress;
        }

        #endregion

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsbLog.Items.Clear();
                this.moExporter.UserName = this.txtUser.Text;
                this.moExporter.Password = this.txtPassword.Text;
                this.moExporter.DB = this.txtDB.Text;
                this.moExporter.CheckLogin();
            }
            catch (Exception exp)
            {
                this.ErrorCatcher(this, exp);
            }
            finally
            {
                this.cmdExport.Enabled = this.moExporter.LoginReady;
                this.cmdImport.Enabled = this.moExporter.LoginReady;
                if (this.moExporter.LoginReady)
                    this.lblLogin.ImageIndex = 0;

                else
                    this.lblLogin.ImageIndex = 1;
            }
        }

        private async void cmdExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtExportName.Text.IsNotEmpty() && this.txtSelect.Text.IsNotEmpty())
                {
                    this.lsbLog.Items.Add("Start Export {0:T}".FormatWith(DateTime.Now));

                    await this.moExporter.Export(this.txtExportName.Text, this.txtSelect.Text, new Progress<string>(this.ReportProgress));

                    this.lsbLog.Items.Add("End Export {0:T}".FormatWith(DateTime.Now));
                }

            }
            catch (Exception exp)
            {
                this.ErrorCatcher(this, exp);
            }
        }

        private async void cmdImport_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.openFileDialog.FileName.IsNotEmpty())
                    {
                        this.lsbLog.Items.Add("Start Import {0:T}".FormatWith(DateTime.Now));

                        await this.moExporter.Import(this.openFileDialog.FileName, new Progress<string>(this.ReportProgress));
                        this.lsbLog.Items.Add("End Import {0:T}".FormatWith(DateTime.Now));
                    }
                }
            }
            catch (Exception exp)
            {
                this.ErrorCatcher(this, exp);
            }
        }

    }
}
