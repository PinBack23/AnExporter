using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExporter
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }

        public static string EmptyOrValue(this string value)
        {
            return value.IfEmpty(string.Empty);
        }

        public static string IfEmpty(this string value, string defaultValue)
        {
            return (!value.IsEmpty() ? value : defaultValue);
        }

        public static string FormatWith(this string value, params object[] parameters)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, value, parameters);
        }

        public static string UpperTrim(this string value)
        {
            return (value.IsEmpty() ? string.Empty : value.Trim().ToUpper());
        }

    }

    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == null|| value == System.DBNull.Value;
        }

        public static string OracleStringValue(this object value)
        {
            return value.ToString().Replace("'", "''").Replace("\r", "' || chr(13) || '").Replace("\n", "' || chr(10) || '");
        }
    }
}
