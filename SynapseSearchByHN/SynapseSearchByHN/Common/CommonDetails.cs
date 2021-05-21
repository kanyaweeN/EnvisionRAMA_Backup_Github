using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Diagnostics;
using System.Collections;
using System.Data;
namespace SynapseSearchByHN.Common
{
    public static class CommonDetails
    {
        public static string pacsUser { get; set; }
        public static string pacsPassword { get; set; }
        public static bool checkImagesFromPACS(string webservice, string hn)
        {
            SynapseSearchByHN.Webservice.QueryImageCount wb = new SynapseSearchByHN.Webservice.QueryImageCount();
            wb.Url = string.Format(@"http://{0}/EnvisionQueryImageCount/QueryImageCount.asmx", webservice);
            bool flag = false;
            if (wb.QueryImage(hn) > 0)
                flag = true;
            return flag;
        }
        public static bool IsWindowsAuthen(string webservice, string username)
        {
            bool authenticated = false;
            SynapseSearchByHN.Webservice.QueryImageCount wb = new SynapseSearchByHN.Webservice.QueryImageCount();
            wb.Url = string.Format(@"http://{0}/EnvisionQueryImageCount/QueryImageCount.asmx", webservice);
            authenticated = wb.checkWindowsAuthen(username);
            return authenticated;
        }
        public static bool IsAuthenticated(string srvr,string domain, string username, string password)
        {
            bool authenticated = false;
            try
            {
               
                    string dcAdDomain = string.Empty;
                    string[] dc = domain.Split('.');
                    foreach (string item in dc)
                    {
                        if (dc[dc.Length - 1].Equals(item))
                            dcAdDomain = dcAdDomain + "DC=" + item;
                        else
                            dcAdDomain = dcAdDomain + "DC=" + item + ",";
                    }
                    string path = string.Format("LDAP://{0}/{1}", srvr , dcAdDomain);

                    DirectoryEntry deSystem = new DirectoryEntry(path);
                    deSystem.AuthenticationType = AuthenticationTypes.Secure;
                    deSystem.Username = username;
                    deSystem.Password = password;

                    DirectorySearcher deSearch = new DirectorySearcher();
                    deSearch.SearchRoot = deSystem;
                    deSearch.Filter = "(&(objectClass=user) (SAMAccountName=" + username + "))";
                    SearchResultCollection results = deSearch.FindAll();
                    deSystem.Dispose();
                    authenticated = true;

            }
            catch (Exception ex)
            {

            }

            return authenticated;
        }
        public static bool IsHISAuthen(string webservice, string username, string password)
        {
            bool authenticated = false;
            SynapseSearchByHN.Webservice.Service wb = new SynapseSearchByHN.Webservice.Service();
            wb.Url = webservice;
            DataSet dsHIS = new DataSet();
            dsHIS = wb.Get_staff_detail(username, password);
            if (dsHIS.Tables.Count > 0)
                if (dsHIS.Tables[0].Rows.Count > 0)
                    if (!string.IsNullOrEmpty(dsHIS.Tables[0].Rows[0][0].ToString()))
                        authenticated = true;
            return authenticated;
        }
        public static void openManual(string manualPath)
        {
            try
            {
                Process.Start(manualPath);
            }
            catch (Exception ex)
            {

            }
        }
    }

}
