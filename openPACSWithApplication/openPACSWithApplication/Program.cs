using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Configuration;
using System.Net.Sockets;
using System.Net;


namespace openPACSWithApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetInitValues();
            using (NotifyIcon icon = new NotifyIcon())
            {
                icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                icon.ContextMenu = new ContextMenu(new MenuItem[] {                
                new MenuItem("Exit", (s, e) => { Application.Exit(); }),
                 });
                icon.Visible = true;
                icon.Text = "Envision Open PACS URL";
                icon.BalloonTipTitle = "Envision Open PACS URL";
                icon.BalloonTipText = "Your application is running at taskbar.";
                icon.ShowBalloonTip(3000);

                int _port = Convert.ToInt32(ConfigurationSettings.AppSettings["recievePORT"]);
                TcpListener server = new TcpListener(IPAddress.Any, 7071);
                // we set our IP address as server's address, and we also set the port: 9999

                server.Start();  // this will start the server

                while (true)   //we wait for a connection
                {
                    TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

                    NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

                    //sending the message

                    try
                    {
                        while (client.Connected)  //while the client is connected, we look for incoming messages
                        {
                            byte[] msg = new byte[1024];     //the messages arrive as byte array
                            ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                            //string accession = Encoding.ASCII.GetString(msg); //now , we write the message as string
                            //string accessionURL = ConfigurationSettings.AppSettings["synapseAccessionURL"];
                            //new openPACS().showPACS(accessionURL + accession);
                            string fullurl = Encoding.ASCII.GetString(msg);
                            new openPACS().showPACS(fullurl);
                            client.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                icon.Visible = false;
            }
        }
        private static void SetInitValues()
        {
            string localPath = "";
            RegHelper reg = new RegHelper();
            //appIcon = new Icon(GetType(), "D:\\EnvisionTaskScheduler\\EnvisionTaskScheduler\\TaskScheduler\\App.ico");
            localPath = System.Environment.CurrentDirectory;
            localPath += "\\" + Assembly.GetExecutingAssembly().GetName().Name +
                    ".exe";

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
                if (key.GetValue("EnvisionOpenPacsUrl") == null)
                    RegHelper.SetRunOnStartup(localPath, false);
            }
            catch (NullReferenceException)
            {
            }


        }
    }
}
