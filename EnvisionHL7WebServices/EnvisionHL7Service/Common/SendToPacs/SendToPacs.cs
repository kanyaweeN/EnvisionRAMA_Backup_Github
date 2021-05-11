using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
/// <summary>
/// Summary description for SendToPacs
/// </summary>
public class SendToPacs
{
    public bool SendMSGToPacs(DataTable dt, string tbl)
    {
        Socket m_clientSocket = null;
        try
        {
            
            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(PACSInfo.IP);
            int iPortNo = Convert.ToInt32(PACSInfo.PORTS);
            IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
            m_clientSocket.Connect(ipEnd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string acc_no = dt.Rows[i]["ACCESSION_NO"].ToString().Trim();
                string a = dt.Rows[i]["HL7_TXT"].ToString();
                a = Convert.ToChar(0x0b).ToString() + a + Convert.ToChar(0x1c).ToString() + Convert.ToChar(0x0d).ToString();
                NetworkStream networkStream = new NetworkStream(m_clientSocket);
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                byte[] byteMessage = Encoding.GetEncoding(874).GetBytes(a);

                int msgLength = byteMessage.Length;
                if (msgLength > 0)
                {
                    m_clientSocket.Send(byteMessage, 0, msgLength, SocketFlags.None);
                    /*CHANGED CODE*/
                    streamWriter.Close();
                    streamWriter = null;
                    networkStream.Close();
                    networkStream = null;
                    /*END CHANGED CODE*/
                }
                else
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                        streamWriter = null;
                    }
                    return false;
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception err) { }
            }
            //Modified to test PACS connection mechanism
            m_clientSocket.Close();
            m_clientSocket = null;
        }

        catch (Exception e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
            return false;
        }
        return true;
    }
}
