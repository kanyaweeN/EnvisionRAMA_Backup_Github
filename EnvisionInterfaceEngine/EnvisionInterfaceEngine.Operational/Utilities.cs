using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using EnvisionInterfaceEngine.Common.Global;

namespace EnvisionInterfaceEngine.Operational
{
    public class Utilities
    {
        public static bool HasData(DataSet data)
        {
            if (data != null)
            {
                foreach (DataTable item in data.Tables)
                {
                    if (HasData(item))
                        return true;
                }
            }

            return false;
        }
        public static bool HasData(DataTable data) { return (data != null && data.Rows.Count > 0); }
        public static bool HasData(DataView data) { return (data != null && data.Count > 0); }
        public static bool HasData(DataRow[] data) { return (data != null && data.Length > 0); }
        public static bool HasData(object[] data) { return (data != null && data.Length > 0); }
        public static bool HasData(string[] data)
        {
            if (data != null)
            {
                foreach (string item in data)
                {
                    if (!string.IsNullOrEmpty(item))
                        return true;
                }
            }

            return false;
        }

        public static bool SaveLog(string function, string caption, string message, bool mistake)
        {
            try
            {
                SaveTextFile(
                    string.Format("{0}{1}_{2:yyyyMMdd}{3}.txt", Config.LogPath, function, DateTime.Today, (mistake ? "_Error" : string.Empty)),
                    Encoding.Default,
                    string.Format("{0:HH:mm:ss} || [{1}] {2}", DateTime.Now, caption, message),
                    true);

            }
            catch { return false; }

            return true;
        }
        public static void SaveTextFile(string fullName, Encoding encoding, string message, bool append)
        {
            FileInfo file = new FileInfo(fullName);

            if (!file.Exists)
                file.Directory.Create();

            using (StreamWriter writing = new StreamWriter(file.FullName, append, encoding))
            {
                writing.WriteLine(message);
                writing.Flush();
                writing.Close();
            }
        }

        public static string OpenTextFile(string fullName, Encoding encoding)
        {
            string result = string.Empty;

            if (File.Exists(fullName))
            {
                using (StreamReader reading = new StreamReader(fullName, encoding))
                {
                    result = reading.ReadToEnd();
                    reading.Close();
                }
            }

            return result;
        }

        public static string ToCleanString(object value)
        {
            string[] temp = value.ToString()
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace("\t", " ")
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            foreach (string item in temp)
            {
                result += item + " ";
            }

            return result.Trim();
        }
        public static string ClearSyntaxHL7(string hl7_text)
        {
            string _hl7_text = hl7_text;
            _hl7_text = _hl7_text.Replace(@"\T\", "&");
            _hl7_text = _hl7_text.Replace(@"\E\", " ");
            return _hl7_text;
        }
        public static int ToInt(string value)
        {
            int result = 0;

            int.TryParse(value, out result);

            return result;
        }
        public static char ToChar(string value) { return ToChar(value, char.MinValue); }
        public static char ToChar(string value, char defaultValue)
        {
            char result;

            if (!char.TryParse(value, out result) || result == char.MinValue)
                result = defaultValue;

            return result;
        }
        public static decimal ToDecimal(string value)
        {
            decimal result = 0;

            decimal.TryParse(value, out result);

            return result;
        }
        public static DateTime ToDateTime(object value)
        {
            string temp = value.ToString();

            DateTime result;

            if (!DateTime.TryParse(temp, out result))
                result = DateTime.MinValue;
            else if (result.Year > 2400)
                result = result.AddYears(-543);

            return result;
        }
        /// <param name="format">
        /// <para>y yy yyy yyyy   : 8 08 008 2008     year</para>
        /// <para>M MM MMM MMMM   : 3 03 Mar March    month</para>
        /// <para>d dd ddd dddd   : 9 09 Sun Sunday   day</para>
        /// <para>h hh H HH       : 4 04 16 16        hour 12/24</para>
        /// <para>m mm            : 5 05              minute</para>
        /// <para>s ss            : 7 07              second</para>
        /// <para>f ff fff ffff   : 1 12 123 1230     sec.fraction</para>
        /// <para>F FF FFF FFFF   : 1 12 123 123      without zeroes</para>
        /// <para>t tt            : P PM              A.M. or P.M.</para>
        /// <para>z zz zzz        : -6 -06 -06:00     time zone</para>
        /// </param>
        public static DateTime ToDateTime(string value, string format)
        {
            DateTime result;

            if (!DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out result))
                result = DateTime.MinValue;
            else if (result.Year > 2400)
                result = result.AddYears(-543);

            return result;
        }

        public static bool CheckMinDateTime(ref DateTime date)
        {
            bool flag = false;
            DateTime result = new DateTime(1900, 1, 1);

            if (date <= result)
            {
                date = result;

                flag = true;
            }

            return flag;
        }

        public static DataTable ConvertObjectToTable(object value)
        {
            Type obj_type = value.GetType();
            PropertyInfo[] properties = obj_type.GetProperties();

            DataTable data = new DataTable();
            data.TableName = obj_type.Name;

            foreach (PropertyInfo property in properties)
                data.Columns.Add(property.Name, property.PropertyType);

            object[] obj_value = new object[properties.Length];

            for (int i = 0; i < obj_value.Length; i++)
            {
                obj_value[i] = obj_type.InvokeMember(
                    properties[i].Name,
                    BindingFlags.GetProperty,
                    null,
                    value,
                    new object[0]);
            }

            data.LoadDataRow(obj_value, true);
            data.AcceptChanges();

            return data.Copy();
        }
        public static DataTable ConvertObjectToTablePattern(object value)
        {
            Type obj_type = value.GetType();
            PropertyInfo[] properties = obj_type.GetProperties();

            DataTable data = new DataTable();
            data.TableName = obj_type.Name;

            foreach (PropertyInfo property in properties)
                data.Columns.Add(property.Name, property.PropertyType);

            data.AcceptChanges();

            return data.Copy();
        }
        public static void ConvertObjectFromRow(DataRow data, object result)
        {
            Type obj_type = result.GetType();

            foreach (DataColumn column in data.Table.Columns)
            {
                try
                {
                    obj_type.InvokeMember(
                        column.ColumnName,
                        BindingFlags.SetProperty,
                        null,
                        result,
                        new object[] { data[column.ColumnName] });
                }
                catch { }
            }
        }
    }
}
