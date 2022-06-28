using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common.Common;
using RIS.WebService;
using System.Net;
using Miracle.Util;
using System.IO;

namespace RIS.Operational.PACS
{
    public class OpenPACS
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private EnvisionWebService ws;

        private string URL_SYNAPSE;

        public OpenPACS()
        {
            ws = new EnvisionWebService(env.WebServiceIP);

            URL_SYNAPSE = env.PacsUrl;
        }
        public OpenPACS(string urlSynapse)
        {
            ws = new EnvisionWebService(env.WebServiceIP);

            URL_SYNAPSE = string.IsNullOrEmpty(urlSynapse) ? env.PacsUrl : urlSynapse;
        }

        public string OpenIEAccession(string accessionNo)
        {
            try
            {
                //if (env.LoginType == "E")
                //    AuthenPACS(env.UserName, env.PasswordAD);

                string url = env.PacsDomain + "AN&Value=" + accessionNo;

                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse response = request.GetResponse();
                request.Abort();
                response.Close();

                return url.ToString();
            }
            catch (Exception ex)
            {
                ws.SaveClientLog("Envision.Operational.PACS.OpenPACS.createFileChangeStudy(string accessionNo)", "\r\n" + ex.ToString());
            }

            return string.Empty;
        }
        public string OpenIEHn(string hn)
        {
            try
            {
                if ((string.IsNullOrEmpty(URL_SYNAPSE)))
                    return string.Empty;
                string url = env.PacsDomain + "PID&Value=" + hn;

                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse response = request.GetResponse();
                request.Abort();
                response.Close();

                return url.ToString();
            }
            catch (Exception ex)
            {
                ws.SaveClientLog("Envision.Operational.PACS.OpenPACS.createFileChangeStudy(string accessionNo)", "\r\n" + ex.ToString());
            }

            return string.Empty;
        }
        public string OpenIEAccession(string accessionNo, string username, string password, string domain, string loginType) { return OpenIEAccession(accessionNo); }
        public void AuthenPACS(string username, string password)
        {
            try
            {
                string _jsonUser = "{userId : \"" + username.ToLower() + "\",secret : \"" + Utilities.EncryptText(password, "Jf@v455455@PublicP@ssw0rd") + "\"}";
                string _url = string.IsNullOrEmpty(env.PacsDomain) ? "http://localhost:9090?QueryMode=" : env.PacsDomain;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url + "Logon");
                request.Method = "POST";
                request.ContentType = @"application/json";

                using (Stream sw = request.GetRequestStream())
                {

                    byte[] buffer = Encoding.GetEncoding(Convert.ToInt32(65001)).GetBytes(_jsonUser);

                    sw.Write(buffer, 0, buffer.Length);
                }

                using (Stream ms = request.GetResponse().GetResponseStream())
                {
                    new StreamReader(ms, Encoding.GetEncoding(Convert.ToInt32(65001))).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }
        }
        public void LogoutPACS()
        {
            try
            {
                string url = env.PacsDomain + "Logoff";

                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse response = request.GetResponse();
                request.Abort();
                response.Close();
            }
            catch (Exception ex)
            {
            }
        }
        public bool CloseIE() { return true; }
    }
}
