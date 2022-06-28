using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Net;
using System.Data;
using System.Security.Cryptography;

namespace Miracle.Util
{
    public class Utilities
    {
        public static void LogException(Exception ex)
        {
            /* using ( StreamWriter sw = new StreamWriter( HttpContext.Current.Server.MapPath( "~/ExceptionLog/LogFile.txt" ) , true ) )
             {
             sw.WriteLine( DateTime.Now.ToShortDateString() +
             Environment.NewLine +
             ex.InnerException.ToString() +
             Environment.NewLine +
             Environment.NewLine );
             }*/
        }

        public static bool IsHaveData(DataSet ds)
        {
            if (ds == null) return false;
            if (ds.Tables.Count == 0) return false;
            bool flag = false;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable dtt = ds.Tables[i];
                if (IsHaveData(dtt))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static bool IsHaveData(DataTable dtt)
        {
            if (dtt == null) return false;
            if (dtt.Rows.Count == 0) return false;
            return true;
        }
        public static bool IsHaveData(DataRow[] dr)
        {
            if (dr == null) return false;
            if (dr.Length == 0) return false;
            return true;
        }
        public string GUID()
        {
            System.Guid desiredGuid = System.Guid.NewGuid();
            return "" + desiredGuid;
        }

        public string IPAddress()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[0].ToString();
        }
        public string MachineName()
        {
            string strHostName = Dns.GetHostName();
            return strHostName;
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
    }
}