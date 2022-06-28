using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Data;
namespace Miracle.Util
{
    public static class Utilities
    {
        public static string GetIPAddress()
        {
            string _IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    _IPAddress = Convert.ToString(IP);
                }
            }
            return _IPAddress;

        }
        public static void LogException(Exception ex)
        {
            DirectoryInfo DirInfo = new DirectoryInfo("C:\\Envision_Log");
            //*** Create Folder ***// 
            if (!DirInfo.Exists)
                DirInfo.Create();
            if (System.IO.File.Exists("C:\\Envision_Log\\ErrorEnvision.txt") == false)
            {
                TextWriter tsw = new StreamWriter("C:\\Envision_Log\\ErrorEnvision.txt");
                tsw.WriteLine(DateTime.Now.ToShortDateString() + "\r\n" +
                   ex.Message.ToString() + "\r\n" +
                   ex.Source + "\r\n");

                tsw.Close();
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("C:\\Envision_Log\\ErrorEnvision.txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortDateString() + "\r\n" +
                   ex.Message.ToString() + "\r\n" +
                   ex.Source + "\r\n");
                }
            }
        }

        public static string GUID()
        {
            System.Guid desiredGuid = System.Guid.NewGuid();
            return "" + desiredGuid;
        }

        public static string IPAddress()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[0].ToString();
        }
        public static string MachineName()
        {
            string strHostName = Dns.GetHostName();
            return strHostName;
        }

        public static string FormatText(string text, bool allow)
        {
            string formatted = "";
            StringBuilder sb = new StringBuilder(text);
            sb.Replace(" ", " &nbsp;");
            if (!allow)
            {
                sb.Replace("<br>", Environment.NewLine);
                sb.Replace("&nbsp;", " ");
                formatted = sb.ToString();
            }
            else
            {
                StringReader sr = new StringReader(sb.ToString());
                StringWriter sw = new StringWriter();
                while (sr.Peek() > -1)
                {
                    string temp = sr.ReadLine();
                    sw.Write(temp + "<br>");
                }
                formatted = sw.GetStringBuilder().ToString();
            }
            return formatted;
        }

        public static string Encrypt(string txt)
        {
            string plainText = txt;
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

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }
        public static string Decrypt(string txt)
        {
            string cipherText = txt;
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

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }

        public static string EncryptText(string input, string key)
        {
            String encData = null;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            AesManaged tdes = new AesManaged();
            byte[] keys = UTF8.GetBytes(key);
            Array.Resize(ref keys, 16);
            tdes.Key = keys;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateEncryptor();

            byte[] plain = Encoding.UTF8.GetBytes(input);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            encData = Convert.ToBase64String(cipher);

            return encData;
        }

        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) { SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1); }
        }

        public static bool IsHaveData(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable dtt in ds.Tables)
                {
                    if (IsHaveData(dtt))
                        return true;
                }
            }

            return false;
        }
        public static bool IsHaveData(DataTable dtt) { return (dtt != null && dtt.Rows.Count > 0); }
        public static bool IsHaveData(DataRow data) { return (data != null); }
        public static bool IsHaveData(DataRow[] data) { return (data != null && data.Length > 0); }
        public static bool IsHaveData(DataView data) { return (data != null && data.Count > 0); }
        public static bool IsHaveData(object[] data) { return (data != null && data.Length > 0); }
        public static bool IsHaveData(string[] data)
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

        public static string TextBaht(double money)
        {
            return textBaht.ToBahtText(money);
        }
        public static void keepReportingLog(DevExpress.XtraRichEdit.RichEditControl rtPad, string accessionNo)
        {
            string _date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string _folder = ConfigurationSettings.AppSettings["errorResultPath"];
            _folder += _date.Substring(0, 8) + "//";
            DirectoryInfo DirInfo = new DirectoryInfo(_folder);
            if (!DirInfo.Exists)
            {
                DirInfo.Create();
            }
            string _fileName = accessionNo + "_" + _date;
            string _pathBackup = _folder + _fileName+".rtf";
            rtPad.SaveDocument(_pathBackup, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
        }
        public static void keepLog(string errorText, string accessionNo)
        {
            string _date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string _folder = ConfigurationSettings.AppSettings["errorPath"];
            _folder += _date.Substring(0, 8) + "//";
            DirectoryInfo DirInfo = new DirectoryInfo(_folder);
            if (!DirInfo.Exists)
            {
                DirInfo.Create();
            }
            string _fileName = string.IsNullOrEmpty(accessionNo) ? "NoAccession" : accessionNo;
            _fileName += "_" + _date;
            string _pathBackup = _folder + _fileName + ".txt";
            if (System.IO.File.Exists(_pathBackup) == false)
            {
                TextWriter tsw = new StreamWriter(_pathBackup);
                tsw.WriteLine(errorText);

                tsw.Close();
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(_pathBackup, true))
                {
                    writer.WriteLine(errorText);
                }
            }
        }
    }
    public struct EmailContents
    {
        public string To;
        public string FromName;
        public string FromEmailAddress;
        public string Subject;
        public string Body;
    }
    public class EmailManager
    {
        private bool _issent;
        public EmailManager()
        {
        }

        public void Send(EmailContents emailcontents)
        {
            SmtpClient client = new SmtpClient(SMTPServerName);
            client.UseDefaultCredentials = true;
            MailAddress from = new MailAddress(emailcontents.FromEmailAddress, emailcontents.FromName);
            MailAddress to = new MailAddress(ToAddress);
            MailMessage message = new MailMessage(from, to);
            message.Subject = emailcontents.Subject;
            message.Body = Utilities.FormatText(emailcontents.Body, true);
            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
                IsSent = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsSent
        {
            get { return _issent; }
            set { _issent = value; }
        }
        private string SMTPServerName
        {
            get { return ConfigurationSettings.AppSettings["SMTPServer"]; }
        }
        private string ToAddress
        {
            get { return ConfigurationSettings.AppSettings["ToAddress"]; }

        }
    }
    internal class textBaht
    {
        private static string s1 = "";
        private static string s2 = "";
        private static string s3 = "";
        private static string[] suffix = { "", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
        private static string[] numSpeak = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };

        public static string ToBahtText(double m)
        {
            string result;
            string beforeresult = "";

            if (m == 0) return ("");
            //-------------------
            if (m < 0)
            {
                string tmp = m.ToString();
                if ((tmp.Substring(0, 1) == "-"))
                {
                    tmp = tmp.Remove(0, 1);
                    beforeresult = "ติดลบ";
                    m = Convert.ToDouble(tmp);
                }
            }
            //-------------------
            splitCurr(m);
            result = "";
            if (s1.Length > 0)
            {
                result = result + Speak(s1) + "ล้าน";
            }
            if (s2.Length > 0)
            {
                result = result + Speak(s2) + "บาท";
            }
            if (s3.Length > 0)
            {
                result = result + speakStang(s3) + "สตางค์";
            }
            else
            {
                result = result + "ถ้วน";
            }
            return (beforeresult + result);
        }

        private static string Speak(string s)
        {
            int L, c;
            string result;

            if (s == "") return ("");

            result = "";
            L = s.Length;
            for (int i = 0; i < L; i++)
            {
                if ((s.Substring(i, 1) == "-"))
                {
                    result = result + "ติดลบ";
                }
                else
                {
                    c = System.Convert.ToInt32(s.Substring(i, 1));
                    if ((i == L - 1) && (c == 1))
                    {
                        if (L == 1)
                        {
                            return ("หนึ่ง");
                        }
                        if ((L > 1) && (s.Substring(L - 1, 1) == "0"))
                        {
                            result = result + "หนึ่ง";
                        }
                        else
                        {
                            result = result + "เอ็ด";
                        }
                    }
                    else if ((i == L - 2) && (c == 2))
                    {
                        result = result + "ยี่สิบ";
                    }
                    else if ((i == L - 2) && (c == 1))
                    {
                        result = result + "สิบ";
                    }
                    else
                    {
                        if (c != 0)
                        {
                            result = result + numSpeak[c] + suffix[L - i];
                        }
                    }
                }
            }
            return (result);
        }

        private static string speakStang(string s)
        {
            int L, c;
            string result;

            L = s.Length;

            if (L == 0) return ("");

            if (L == 1)
            {
                s = s + "0";
                L = 2;
            }
            if (L > 2)
            {
                s = s.Substring(0, 2);
                L = 2;
            }
            result = "";
            for (int i = 0; i < 2; i++)
            {
                c = Convert.ToInt32(s.Substring(i, 1));
                if ((i == L - 1) && (c == 1))
                {
                    if (Convert.ToInt32(s.Substring(0, 1)) == 0)
                        result = result + "หนึ่ง";
                    else
                        result = result + "เอ็ด";
                }
                else if ((i == L - 2) && (c == 2))
                {
                    result = result + "ยี่สิบ";
                }
                else if ((i == L - 2) && (c == 1))
                {
                    result = result + "สิบ";
                }
                else
                {
                    if (c != 0)
                    {
                        result = result + numSpeak[c] + suffix[L - i];
                    }
                }
            }

            return (result);
        }

        private static void splitCurr(double m)
        {
            string s;
            int L;
            int position;

            s = System.Convert.ToString(m);
            position = s.IndexOf(".");
            if ((position >= 0))
            {
                s1 = s.Substring(0, position);
                s3 = s.Substring(position + 1);
                if (s3 == "00")
                {
                    s3 = "";
                }
            }
            else
            {
                s1 = s;
                s3 = "";
            }
            L = s1.Length;
            if ((L > 6))
            {
                s2 = s1.Substring(L - 6);
                s1 = s1.Substring(0, L - 6);
            }
            else
            {
                s2 = s1;
                s1 = "";
            }

            if ((s1 != "") && (Convert.ToInt32(s1) == 0)) s1 = "";
            if ((s2 != "") && (Convert.ToInt32(s2) == 0)) s2 = "";
        }
    }
}
