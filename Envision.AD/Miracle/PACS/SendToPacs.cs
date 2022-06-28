using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Miracle.PACS
{
    public  class SendToPacs
    {
        private string ip;
        private string port;

        public SendToPacs(string IP, string Port) {
            ip = IP;
            port = Port;
        }
        public virtual bool SendMSGToPacs(DataTable dt, string tbl)
        {
            Socket m_clientSocket = null;
            try
            {
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(this.ip.Trim());// IPAddress.Parse("192.168.1.209");
                int iPortNo = Convert.ToInt32(this.port.Trim());// 8001;
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
                        Console.WriteLine("Error..... ");
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
                //tcpclnt.Close();
                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
