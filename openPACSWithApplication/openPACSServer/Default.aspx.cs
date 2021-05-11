using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Net;

namespace openPACSServer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string valuefromParameter = string.Empty;
            if (null != Request.QueryString["accession_no"])
            {
                valuefromParameter = Request.QueryString["accession_no"].ToString();
            }
            string myStringVariable = GetUserIP();

            try
            {
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(myStringVariable);
                System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 7071);
                soc.Connect(remoteEP);
                byte[] byData = new byte[100];
                //byData = System.Text.Encoding.ASCII.GetBytes(msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg + msg2 + msg + msg + msg + msg);            
                //byData = System.Text.Encoding.ASCII.GetBytes(hl7msg);
                //soc.Send(byData);
                //byData = System.Text.Encoding.ASCII.GetBytes("openpacsdirectly:" + valuefromParameter.Trim());
                string fullUrl = "http://synapse/explore.asp?path=/All%20Studies./AccessionNumber=" + valuefromParameter.Trim();
                byData = System.Text.Encoding.ASCII.GetBytes(fullUrl);
                soc.Send(byData);

                soc.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.open('close.html', '_self', null);", true);
        }
        private string GetUserIP()
        {
            //Gets a comma-delimited list of IP Addresses
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //If any are available - use the first one
            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            //Otherwise return the Remote Address
            return Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}