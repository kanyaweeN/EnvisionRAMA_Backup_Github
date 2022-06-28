using Envision.Operational.Common;
using Envision.Operational.Configs;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace Envision.Operational
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
                    string.Format("{0}{1}_{2:yyyyMMdd}{3}.txt", EnvisionConfig.KeepLogPath, function, DateTime.Today, (mistake ? "_Error" : string.Empty)),
                    Encoding.Default,
                    string.Format("{0:HH:mm:ss} || [{1}] {2}", DateTime.Now, caption, message),
                    true);
            }
            catch { return false; }

            return true;
        }
        public static void SaveTextFile(string fullName, Encoding encoding, string message, bool append)
        {
            try
            {
                FileInfo file = new FileInfo(fullName);

                if (!file.Directory.Exists)
                    file.Directory.Create();

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        using (StreamWriter writing = new StreamWriter(file.FullName, append, encoding))
                        {
                            writing.WriteLine(message);
                            writing.Flush();
                            writing.Close();
                        }

                        break;
                    }
                    catch (IOException) { Thread.Sleep(100); }
                    catch { break; }
                }
            }
            catch { }
        }
        public static void SaveCheckPoint(string checkPointExtensions) { SaveCheckPoint(string.Empty, checkPointExtensions); }
        public static void SaveCheckPoint(string checkPointText, string checkPointExtensions)
        {
            MIStringArray files_name = null;

            if (Directory.Exists(EnvisionConfig.KeepLogPath))
                files_name = new MIStringArray(Directory.GetFiles(EnvisionConfig.KeepLogPath, string.Format("*.{0}", checkPointExtensions), SearchOption.TopDirectoryOnly));

            string checkpoint_file_path = string.Format("{0}{1}_{2:yyyyMMdd_HHmmss}.{3}", EnvisionConfig.KeepLogPath, checkPointText, DateTime.Now, checkPointExtensions);

            if (files_name == null || files_name.Values.Count == 0)
                SaveTextFile(checkpoint_file_path, Encoding.Default, string.Empty, false);
            else
            {
                foreach (string file_name in files_name.Values)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            File.Move(file_name, checkpoint_file_path);

                            break;
                        }
                        catch (IOException) { Thread.Sleep(100); }
                        catch { break; }
                    }
                }
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
            if (value == null)
                return string.Empty;

            return string.Join(
                " ",
                value.ToString()
                    .Replace(Convert.ToChar(0x00).ToString(), string.Empty)
                    .Replace("\r", " ")
                    .Replace("\n", " ")
                    .Replace("\t", " ")
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }
        public static string ToUseCrLf(string value) { return string.IsNullOrEmpty(value) ? string.Empty : value.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"); }
        public static int ToInt(object value) { return ToInt((value ?? string.Empty).ToString()); }
        public static int ToInt(string value)
        {
            int result = 0;

            int.TryParse(value, out result);

            return result;
        }
        public static bool ToBoolean(object value) { return ToBoolean((value ?? string.Empty).ToString()); }
        public static bool ToBoolean(string value)
        {
            bool result = false;

            if (!bool.TryParse(value, out result))
            {
                switch (value.ToLower())
                {
                    case "true":
                    case "1":
                    case "y":
                    case "t":
                        result = true;
                        break;
                }
            }

            return result;
        }
        public static char ToChar(object value) { return ToChar((value ?? string.Empty).ToString(), char.MinValue); }
        public static char ToChar(string value) { return ToChar(value, char.MinValue); }
        public static char ToChar(object value, char defaultValue) { return ToChar((value ?? string.Empty).ToString(), defaultValue); }
        public static char ToChar(string value, char defaultValue)
        {
            char result;

            if (!char.TryParse(value, out result) || result == char.MinValue)
                result = defaultValue;

            return result;
        }
        public static byte[] toByteArry(string varBinaryString)
        {
            char[] charArray = varBinaryString.ToCharArray();
            byte[] byteArray = new byte[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                byteArray[i] = (byte)charArray[i];
            }
            return byteArray;
        }
        public static decimal ToDecimal(object value) { return ToDecimal((value ?? string.Empty).ToString()); }
        public static decimal ToDecimal(string value)
        {
            decimal result = decimal.Zero;

            decimal.TryParse(value, out result);

            return result;
        }
        public static DateTime ToDateTime(object value)
        {
            string temp = (value ?? string.Empty).ToString();

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

            if (value.Length > format.Length)
                value = value.Substring(0, format.Length);
            else if (value.Length < format.Length)
                value = value.PadRight(format.Length, '0');

            if (!DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out result))
                result = DateTime.MinValue;
            else if (result.Year > 2400)
                result = result.AddYears(-543);

            return result;
        }

        public static Encoding ToEncoding(string name)
        {
            int codepage;

            return int.TryParse(name, out codepage)
                ? Encoding.GetEncoding(codepage)
                : Encoding.GetEncoding(name);
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

        public static string ConvertObjectToXml(object obj)
        {
            string result = string.Empty;

            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    XmlTextWriter tw = new XmlTextWriter(sw);

                    XmlSerializer xml_serializer = new XmlSerializer(obj.GetType());
                    xml_serializer.Serialize(tw, obj);

                    result = sw.ToString();

                    tw.Flush();
                    tw.Close();
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }
        public static object ConvertXmlToObject(string xml, Type objectType)
        {
            object result;

            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlTextReader tr = new XmlTextReader(sr);

                    XmlSerializer xml_serializer = new XmlSerializer(objectType);
                    result = xml_serializer.Deserialize(tr);

                    tr.Close();
                    sr.Close();
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public static bool CheckValidHostName(string value) { return Regex.IsMatch(value, @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$"); }
        public static bool CheckValidIpAddress(string value) { return Regex.IsMatch(value, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"); }
        public static bool CheckValidIpAddressRange(string value) { return Regex.IsMatch(value, @"^((\*|[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(\*|[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"); }

        public static string ConvertAsciiOctetsToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length);

            string[] controlChars =
            {
              "<NUL>" , "<SOH>" , "<STX>" , "<ETX>" ,
              "<EOT>" , "<ENQ>" , "<ACK>" , "<BEL>" ,
              "<BS>"  , "<HT>"  , "<LF>"  , "<VT>"  ,
              "<FF>"  , "<CR>"  , "<SO>"  , "<SI>"  ,
              "<DLE>" , "<DC1>" , "<DC2>" , "<DC3>" ,
              "<DC4>" , "<NAK>" , "<SYN>" , "<ETB>" ,
              "<CAN>" , "<EM>"  , "<SUB>" , "<ESC>" ,
              "<FS>"  , "<GS>"  , "<RS>"  , "<US>"  ,
            };

            foreach (byte b in bytes)
            {
                char c = (char)b;

                if (c < '\u0020') { sb.Append(controlChars[c]); }
                else if (c == '\u007F') { sb.Append("<DEL>"); }
                else if (c > '\u007F') { sb.AppendFormat(@"\u{0:X4}", (ushort)c); }
                else /* 0x20-0x7E */ { sb.Append(c); }
            }

            return sb.ToString();
        }

        public static string Encryp(string text)
        {
            string plainText = text;
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                  // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128


            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }
        public static string Decryp(string text)
        {
            string cipherText = text;
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                  // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }

    }
}
