using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Net;

namespace openPACSWithApplication
{
    public partial class openPACS : Form
    {
        public openPACS()
        {
            InitializeComponent();
        }

        private void openPACS_Load(object sender, EventArgs e)
        {

            //string accessionURL = ConfigurationSettings.AppSettings["synapseAccessionURL"];
            //string hnURL = ConfigurationSettings.AppSettings["synapsePatientUidURL"];

            //string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            //col = HttpUtility.ParseQueryString(queryString);
            //if (!string.IsNullOrEmpty(col["accession_no"]))
            //{
                //keepLog("- Acc : " + col["accession_no"]);
                //showPACS(accessionURL + acc);
            //}
            //else if (!string.IsNullOrEmpty(col["patientuid"]))
            //{
            //    keepLog("- HN : " + col["patientuid"]);
            //    showPACS(hnURL + col["patientuid"]);
            //}
            Application.Exit();
        }
        private void keepLog(string log)
        {
            try
            {
                #region Check OS Version
                string _servicePack = "";
                if (OSVersionInfo.ServicePack != string.Empty)
                    _servicePack = String.Format("Service Pack = {0}", OSVersionInfo.ServicePack);
                else
                    _servicePack = "Service Pack = None";
                string os_name = OSVersionInfo.Name + " " + OSVersionInfo.Edition + " " + _servicePack + " " + OSVersionInfo.OSBits + " ";
                os_name += String.Format("Version = {0}", OSVersionInfo.VersionString);
                #endregion
                #region Get Host Name
                string strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
                IPAddress[] addr = ipEntry.AddressList;
                #endregion
                DataTable dt = new DataTable();
                string strConn = ConfigurationSettings.AppSettings["connStr"];
                string strQuery = @"insert into RIS_LOG(IP_ADDRESS,OS,ERROR_LOG,CREATED_ON)
                                VALUES(@IP_ADDRESS,@OS,@ERROR_LOG,GETDATE())";
                SqlParameter[] param = {
                                   new SqlParameter("@IP_ADDRESS", addr[0].ToString()),
                                   new SqlParameter("@OS", os_name),
                                   new SqlParameter("@ERROR_LOG", log),
                                   };

                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Parameters.AddRange(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

        public void showPACS(string url)
        {
            bool IsReplaceURL = Convert.ToBoolean(ConfigurationSettings.AppSettings["replaceTAB"]);
            string synapseServerName = ConfigurationSettings.AppSettings["synapseServerName"];
            bool foundIE = false;

            //if (IsReplaceURL)
            //{
                //Find IE is still open in PACS.
                foreach (SHDocVw.InternetExplorer ie in new SHDocVw.ShellWindows())
                {
                    if (ie.LocationURL.ToString().ToLower().Contains(string.Format("http://{0}", synapseServerName.ToLower())))
                    {

                        object Empty = 0;
                        ie.Navigate(url.ToString(), ref Empty, ref Empty, ref Empty, ref Empty);
                        int val = ie.HWND;
                        IntPtr hwnd = new IntPtr(val);
                        SetForegroundWindow(hwnd);
                        foundIE = true;
                        break;
                    }
                }

                if (!foundIE)
                {
                    //Use full path for open IE x64
                    string file_name = Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Internet Explorer\\iexplore.exe";
                    Process.Start(File.Exists(file_name) ? file_name : "iexplore", url.ToString());
                }
            //}
            //else
            //{
            //    //Use full path for open IE x64
            //    string file_name = Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Internet Explorer\\iexplore.exe";
            //    Process.Start(File.Exists(file_name) ? file_name : "iexplore", url.ToString());
            //}
        }
        private static string ErrorDetails(Exception exception)
        {
            string exceptionString = "";
            try
            {
                int i = 0;
                while (exception != null)
                {
                    exceptionString += "*** Exception Level " + i + "***\n";
                    exceptionString += "Message: " + exception.Message + "\n";
                    exceptionString += "Source: " + exception.Source + "\n";
                    exceptionString += "Target Site: " + exception.TargetSite + "\n";
                    exceptionString += "Stack Trace: " + exception.StackTrace + "\n";
                    exceptionString += "Data: ";
                    foreach (System.Collections.DictionaryEntry keyValuePair in
                    exception.Data)
                        exceptionString += keyValuePair.Key.ToString()
                        + ":" + keyValuePair.Value.ToString();
                    exceptionString += "\n***\n\n";

                    exception = exception.InnerException;

                    i++;
                }
            }
            catch { }

            return exceptionString;
        }
    }
}
