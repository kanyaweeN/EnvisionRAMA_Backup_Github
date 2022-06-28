using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.DBConnection;
using RIS.Common.UtilityClass;
using RIS.Forms.Main;
using System.Threading;
using System.Xml;
using System.IO;
using System.Security.Principal;
using RIS;
using RIS.BusinessLogic;
using RIS.Common;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Forms.GBLMessage;
using RIS.Forms.Lookup;
using RIS.Forms.Popup;
using System.Net;
using System.Net.Sockets;
using System.Text;

using RIS.Operational;
using System.Deployment.Application;
using System.Reflection;
using System.Text.RegularExpressions;
using Miracle.Util;
using RIS.Operational.PACS;
namespace RIS
{
    public partial class Form1 : Form
    {
        private GBLEnvVariable env;

        //--Create object of dbConnection class for database interaction--\\
        dbConnection dc = new dbConnection();
        DBUtility du = new DBUtility();
        private System.Windows.Forms.Timer timer1;
        private int[] langid;
        string defaultlangs;
        private XmlDocument xmldoc;
        string path = "XML/Remember.xml";
        MyMessageBox msg = new MyMessageBox();
        
        public Form1()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            

            InitializeComponent();
            //if(CheckUpdate())
            UpdateVersion();
            try
            {
                //CreateShortCut();
                //CreateShortCut2();
            }
            catch (Exception ex)
            { 
            }
           
            Thread th = new Thread(new ThreadStart(DoSplash));

            //th.ApartmentState = ApartmentState.STA;
            //th.IsBackground=true;
            th.Start();
           
            Thread.Sleep(2000);//2
            th.Abort();
            Thread.Sleep(1000);
                       
            showRemember();
            LoadFormLanguage();
            SetVersion();
            //ChangeFormLanguage();
            cmbAuth.SelectedIndex = 0;
        }
        private void UpdateVersion() {
            #region Old Code 
            //try
            //{
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            //    Version vs = ad.CurrentVersion;
            //    GBLEnvVariable env = new GBLEnvVariable();
            //    ProcessGetGBLProduct prod = new ProcessGetGBLProduct();
            //    env.OrgID = 1;
            //    prod.Invoke();
            //    DataTable dt = prod.ResultSet.Tables[0];
            //    string version = dt.Rows[0]["PROD_VERSION"].ToString();
            //    if (version == ad.CurrentVersion.ToString())
            //        return false;
            //    else
            //    {
            //        ad.Update();
            //        Application.Exit();
            //        return true;
            //    }
            //}
            //catch (Exception ex) {
            //    return false;
            //}
            //return true; 
            #endregion

            if (ApplicationDeployment.IsNetworkDeployed) { 
               ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
               if (deployment.CheckForUpdate())
               {
                   GBLEnvVariable env = new GBLEnvVariable();
                   ProcessGetGBLProduct prod = new ProcessGetGBLProduct();
                   env.OrgID = 1;
                   prod.Invoke();
                   DataTable dt = prod.ResultSet.Tables[0];
                   int k = 0;
                   while (k < dt.Rows.Count)
                   {
                       lblVersion.Text = dt.Rows[k]["PROD_VERSION"].ToString();
                       k++;
                   }
                   if (lblVersion.Text.Trim().ToString() != ApplicationDeployment.CurrentDeployment.ToString())
                   {
                       ProcessUpdateGBLProduct process = new ProcessUpdateGBLProduct();
                       process.GBLProduct.PROD_ID = 1;
                       process.GBLProduct.PROD_VERSION = ApplicationDeployment.CurrentDeployment.ToString();
                       process.Invoke();
                   }


                   deployment.Update();
                   Application.Restart();
               }
            }
        }
        private void CreateShortCut()
        {
            //try
            //{
            //    if (!ApplicationDeployment.IsNetworkDeployed) return;
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            //    Assembly code = Assembly.GetExecutingAssembly();
            //    string company = string.Empty;
            //    string description = string.Empty;
            //    if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
            //    {
            //        AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyCompanyAttribute));
            //        company = Application.CompanyName;
            //    }
            //    if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            //    {
            //        AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
            //        description = asdescription.Description;
            //    }
            //    if (company != string.Empty && description != string.Empty)
            //    {
            //        string desktopPath = string.Empty;
            //        desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");
            //        //System.IO.File.AppendAllText(@"c:\env.txt", "\r\n Desktop: " + desktopPath);

            //        string shortcutName = string.Empty;
            //        shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");
            //        System.IO.File.AppendAllText(@"c:\env.txt", "\r\n ShortcutName: " + shortcutName + "  path :" +path + "DesktopPath : " + desktopPath);


            //        System.IO.File.Copy(shortcutName, desktopPath, true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //     System.IO.File.AppendAllText(@"c:\env.txt", "\r\n" + ex.Message);
            //}


            try
            {
                if (!ApplicationDeployment.IsNetworkDeployed) return;
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                Assembly code = Assembly.GetExecutingAssembly();
                string company = string.Empty;
                string description = string.Empty;
                if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                {
                    AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyCompanyAttribute));
                    company = Application.CompanyName;//ascompany.Company;
                    //MessageBox.Show("TEST" + company);
                }
                if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                {
                    AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyDescriptionAttribute));
                    description = asdescription.Description;
                }
                if (company != string.Empty && description != string.Empty)
                {
                    string desktopPath = string.Empty;
                    desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        "\\", description, ".appref-ms");
                    string shortcutName = string.Empty;
                    shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                        "\\", company, "\\", description, ".appref-ms");
                    //System.IO.File.Copy(shortcutName, desktopPath, true);
                }
            }
            catch (Exception ex)
            {
                //System.IO.File.AppendAllText(@"c:\env.txt", "\r\n" + ex.Message);
            }
        }
        private void CreateShortCut2()
        {
            try
            {
                if (!ApplicationDeployment.IsNetworkDeployed) return;
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                Assembly code = Assembly.GetExecutingAssembly();
                string company = string.Empty;
                string description = string.Empty;
                if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                {
                    AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyCompanyAttribute));
                    company = Application.CompanyName;
                }
                if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                {
                    AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                    description = asdescription.Description;
                }
                if (company != string.Empty && description != string.Empty)
                {
                    string desktopPath = string.Empty;
                    desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");
                    //System.IO.File.AppendAllText(@"c:\env.txt", "\r\n Desktop: " + desktopPath);

                    string shortcutName = string.Empty;
                    shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");
                    // System.IO.File.AppendAllText(@"c:\env.txt", "\r\n ShortcutName: " + shortcutName + "  path :" +path + "DesktopPath : " + desktopPath);

                    System.IO.File.Copy(shortcutName, desktopPath, true);
                    //System.IO.File.AppendAllText(@"c:\dir.txt", Directory.GetCurrentDirectory());
                }
            }
            catch (Exception ex)
            {
                //System.IO.File.AppendAllText(@"c:\env.txt", "\r\n" + ex.Message);
            }
        }
        //private void CreateShortCut()
        //{
        //    if (!ApplicationDeployment.IsNetworkDeployed) return;
        //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
        //    Assembly code = Assembly.GetExecutingAssembly();
        //    string company = string.Empty;
        //    string description = string.Empty;
        //    if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
        //    {
        //        AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
        //            typeof(AssemblyCompanyAttribute));
        //        company = Application.CompanyName;//ascompany.Company;
        //        //MessageBox.Show("TEST" + company);
        //    }
        //    if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
        //    {
        //        AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
        //            typeof(AssemblyDescriptionAttribute));
        //        description = asdescription.Description;
        //    }
        //    if (company != string.Empty && description != string.Empty)
        //    {
        //        try
        //        {
        //            string desktopPath = string.Empty;
        //            desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        //                "\\", description, ".appref-ms");
        //            string shortcutName = string.Empty;
        //            shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
        //                "\\", company, "\\", description, ".appref-ms");
        //            System.IO.File.Copy(shortcutName, desktopPath, true);
        //        }
        //        catch { }
        //    }
        //}
        //lov
        private void childA_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            //You will get your required value through a string(e.NewValue)
            //And now you can utilize the string by split function
            //Split function will return you a array type string 
            //You will get the data in the sequence of tableField name you set previously          
            int lovNo = 1;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            if (lovNo == 1)
            {
                //MessageBox.Show("" + retValue[0].ToString());
                //textBox1.Text = retValue[0].ToString();
                //disCode = Convert.ToInt32(retValue[1].ToString());
            }
            else
            {
                //txtCpoName.Text = retValue[0].ToString();
                //cpoNo = Convert.ToInt32(retValue[1].ToString());
            }
            //}
            //else if (lovNo == 2)
            //{
            //    txtPreparedBy.Text = "" + retValue[0].ToString() + " " + retValue[1].ToString() + "";
            //    txtDesignation.Text = retValue[2].ToString();
            //    userNo = Convert.ToInt32(retValue[3].ToString());
            //}
            //else if (lovNo == 3)
            //{
            //    txtCpoName.Text = retValue[0].ToString();
            //    cpoNo = Convert.ToInt32(retValue[1].ToString());
            //}
            //else if (lovNo == 4)
            //{
            //    txtCheckedBy.Text = "" + retValue[0].ToString() + " " + retValue[1].ToString() + "";
            //    txtDesigChecked.Text = retValue[2].ToString();
            //    cheByNo = Convert.ToInt32(retValue[3].ToString());
            //}
            //else
            //{
            //    proComNo = Convert.ToInt32(retValue[2].ToString());
            //    loadCopletedProjectInfo(Convert.ToInt32(retValue[2].ToString()), retValue[1].ToString());
            //}
        }
        #region KillSession
        public void KillSession(string ip)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamReader streamReader;
            StreamWriter streamWriter;
            try
            {
                tcpClient = new TcpClient(ip, 5555);
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine("Your session has been killed...");
                streamWriter.Flush();
                streamWriter.Close();
                tcpClient.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion


        private void SetVersion()
        {
            GBLEnvVariable env = new GBLEnvVariable();
            
            ProcessGetGBLProduct prod = new ProcessGetGBLProduct();
            env.OrgID = 1;
            prod.Invoke();
            DataTable dt = prod.ResultSet.Tables[0];
            int k = 0;
            while (k < dt.Rows.Count)
            {
                lblVersion.Text = dt.Rows[k]["PROD_VERSION"].ToString();
                k++;
            }
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                if (lblVersion.Text.Trim().ToString() != ApplicationDeployment.CurrentDeployment.ToString())
                {
                    ProcessUpdateGBLProduct process = new ProcessUpdateGBLProduct();
                    process.GBLProduct.PROD_ID = 1;
                    process.GBLProduct.PROD_VERSION = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    process.Invoke();
                    lblVersion.Text = process.GBLProduct.PROD_VERSION;
                }
            }
            ProcessGetGBLEnv gblenv = new ProcessGetGBLEnv();
            gblenv.Invoke();
            DataTable dtenv = gblenv.ResultSet.Tables[0];
            int j = 0;
            while (j < dtenv.Rows.Count)
            {
                env.DateFormat = dtenv.Rows[j]["DT_FMT"].ToString();
                env.TimeFormat = dtenv.Rows[j]["TIME_FMT"].ToString();
                env.CurrencyName = dtenv.Rows[j]["LOCAL_CURRENCY_NAME"].ToString();
                env.CurrencySymbol = dtenv.Rows[j]["LOCAL_CURRENCY_SYMBOL"].ToString();
                env.CurrencyFormat = dtenv.Rows[j]["CURRENCY_FMT"].ToString();
                env.PacsDomain = dtenv.Rows[j]["PACS_DOMAIN"].ToString();
                env.PacsIp = dtenv.Rows[j]["PACS_IP"].ToString();
                env.PacsPort = dtenv.Rows[j]["PACS_PORT"].ToString();
                env.PacsUrl = dtenv.Rows[j]["PACS_URL1"].ToString();
                env.PacsUrl2 = dtenv.Rows[j]["PACS_URL2"].ToString();
                env.PacsUrl3 = dtenv.Rows[j]["PACS_URL3"].ToString();
                env.FontName = dtenv.Rows[j]["DEFAULT_FONT_FACE"].ToString();
                env.FontSize = dtenv.Rows[j]["DEFAULT_FONT_SIZE"].ToString();
                env.ScannedImagePath = dtenv.Rows[j]["SCANNED_IMAGE_PATH"].ToString();
                //env.ScannedImageWeb = dtenv.Rows[j]["SCANNED_IMAGE_WEB"].ToString();
                env.WebServiceIP = dtenv.Rows[j]["WS_IP"].ToString();
                env.WebServiceIP_PICTURE = dtenv.Rows[j]["WS_IP_PICTURE"].ToString();
                label4.Text = dtenv.Rows[j]["ORG_NAME"].ToString();

                //env.PacsIp_1 = dtenv.Rows[j]["PACS_IP_1"].ToString();
                //env.PacsPort_1 = dtenv.Rows[j]["PACS_PORT_1"].ToString();
                //env.PacsUrl1_1 = dtenv.Rows[j]["PACS_URL1_1"].ToString();
                //env.PacsUrl2_1 = dtenv.Rows[j]["PACS_URL2_1"].ToString();

                j++;
                
            }
        }

        private void ShowHelp()
        {
            GBLEnvVariable env = new GBLEnvVariable();
            ProcessGetGBLProduct prod = new ProcessGetGBLProduct();
            env.OrgID = 1;
            prod.Invoke();
            DataTable dt = prod.ResultSet.Tables[0];
            int k = 0;
            //new PopupNotify("<b>MIRACLE</b><br>Re: Thank you for using RIS Application</br><br><font color='navy'>Contact : java2guide@gmail.com</font></br>");
            string hlp = "";
            while (k < dt.Rows.Count)
            {

                hlp = "<b>" + dt.Rows[k]["LICENSED_TO"].ToString() + "</b><br>";
                hlp = hlp + dt.Rows[k]["PROD_DESCR"].ToString() + "</br><br><font color='navy'>";
                hlp = hlp + dt.Rows[k]["PROD_VERSION"].ToString() + "</font></br>";
                hlp = hlp + ", Released : " + dt.Rows[k]["RELEASE_DT"].ToString();
                k++;
            }
          
            new PopupNotify(hlp);
        }

        //------ Loading Defaul Language ------//

        private void LoadFormLanguage()
        {

            new GBLEnvVariable().OrgID = 1;
            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType =2;
            
            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch
            {
            }

            try
            {
                
                DataTable dt = langs.ResultSet.Tables[0];
                langid = new int[dt.Rows.Count];
                int k = 0;
                while(k<dt.Rows.Count)
                {
                    cmbLanguage.Items.Add(dt.Rows[k]["LANG_NAME"].ToString());
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    
                    langid[k] = Convert.ToInt32(lid);
                    if((dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim())==("Y"))
                    {
                        defaultlangs=dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim();
                        cmbLanguage.Text = dt.Rows[k]["LANG_NAME"].ToString();
                        new GBLEnvVariable().CurrentLanguageID = Convert.ToInt32(dt.Rows[k]["LANG_ID"].ToString().Trim());
                        
                    }
                    
                    k++;
                }
                

                
            }
            catch(Exception EX) {MessageBox.Show(EX.Message); }
                   
            
            return;

        }


        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 0;

            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch
            {
            }

            try
            {
               
                DataTable dt = langs.ResultSet.Tables[0];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblAuthMode").ToUpper().Trim()) 
                    {
                        
                        lblAuthMode.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUserName").ToUpper().Trim()) 
                    {
                        lblUserName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblPassword").ToUpper().Trim()) 
                    {
                        lblPassword.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim())==("lblLanguage").ToUpper().Trim())
                    {
                        lblLanguage.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRem").ToUpper().Trim())
                    {
                        chkRem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnLogin").ToUpper().Trim())
                    {
                        btnLogin.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnCancel").ToUpper().Trim())
                    {
                        btnCancel.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    k++;
                }
               


            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }



        private void ChangeFormLanguageClick()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            
            fl.LanguageID = langid[cmbLanguage.SelectedIndex];
         
            fl.ProcedureType = 1;

            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch
            {
            }

            try
            {

                DataTable dt = langs.ResultSet.Tables[0];
                int k = 0;
                while (k < dt.Rows.Count)
                {

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblAuthMode").ToUpper().Trim())
                    {
                        lblAuthMode.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUserName").ToUpper().Trim())
                    {
                        lblUserName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblPassword").ToUpper().Trim())
                    {
                        lblPassword.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLanguage").ToUpper().Trim())
                    {
                        lblLanguage.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRem").ToUpper().Trim())
                    {
                        chkRem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnLogin").ToUpper().Trim())
                    {
                        btnLogin.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnCancel").ToUpper().Trim())
                    {
                        btnCancel.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }





        public void Remember()

		//Constructor

		{
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                xmldoc = new XmlDocument();
                xmldoc.Load(fs);
                AddRemember();
            }
            catch { }
		}

		// Method for Displaying the catalog

		
		// Adding a new entry to the catalog

        public void showRemember()

		//Constructor

		{
            try
            {

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                xmldoc = new XmlDocument();
                xmldoc.Load(fs);
                DisplayRemember();
            }
            catch { }
		}

        private void DisplayRemember()
        {

            string pc= WindowsIdentity.GetCurrent().Name+"-True";
          
            XmlNodeList xmlnode = xmldoc.GetElementsByTagName("Machine");
            Console.WriteLine("Here is the list of catalogs\n\n");

            for (int i = 0; i < xmlnode.Count; i++)
            {
                XmlAttributeCollection xmlattrc = xmlnode[i].Attributes;
                
                //XML Attribute Name and Value returned
                //Example: <Book id = "001">

                //Console.Write(xmlattrc[0].Name);
                //Console.WriteLine(":\t\t" + xmlattrc[0].Value);
                if(pc.Equals(xmlattrc[0].Value))
                {
                    txtUser.Text=xmlnode[i].FirstChild.InnerText;
                    txtPassword.Text=xmlnode[i].LastChild.InnerText;
                   
                    chkRem.Checked = true;
                    i = xmlnode.Count;
                }
                //First Child of the XML file - Catalog.xml - returned
                //Example: <Author>Mark</Author>

                //Console.Write(xmlnode[i].FirstChild.Name);
                //Console.WriteLine(":\t\t" + xmlnode[i].FirstChild.InnerText);

                //Last Child of the XML file - Catalog.xml - returned
                //Example: <Publisher>Sams</Publisher>

                //Console.Write(xmlnode[i].LastChild.Name);
                //Console.WriteLine(":\t" + xmlnode[i].LastChild.InnerText);
                //Console.WriteLine();
            }

            Console.WriteLine("Catalog Finished");
        }


		private void AddRemember()
		{
			//Console.WriteLine("New Entry is added to the catalog");
			//Console.WriteLine("Please open the XML file to verify");
			//Console.WriteLine("==================================");
            xmldoc.DocumentElement.RemoveAll();
			// New XML Element Created
			XmlElement newcatalogentry = xmldoc.CreateElement("Machine");
           
			// New Attribute Created
			XmlAttribute newcatalogattr = xmldoc.CreateAttribute("ID");
            string stus;
            if (chkRem.Checked)
            {
                stus = "-True";
            }
            else
            {
                stus = "-False";
            }
			// Value given for the new attribute
            newcatalogattr.Value = WindowsIdentity.GetCurrent().Name+stus;

			// Attach the attribute to the xml element
			newcatalogentry.SetAttributeNode(newcatalogattr);

			// First Element - Book - Created
			XmlElement firstelement = xmldoc.CreateElement("User");

			// Value given for the first element
			firstelement.InnerText = txtUser.Text;

			// Append the newly created element as a child element
			newcatalogentry.AppendChild(firstelement);


			// Second Element - Publisher - Created
			XmlElement secondelement = xmldoc.CreateElement("Password");

			// Value given for the second element
			secondelement.InnerText = txtPassword.Text;

			// Append the newly created element as a child element
			newcatalogentry.AppendChild(secondelement);

            // Second Element - Publisher - Created
            
            
            

			// New XML element inserted into the document
			xmldoc.DocumentElement.InsertBefore(newcatalogentry,xmldoc.DocumentElement.LastChild);
         
			// An instance of FileStream class created
			// First parameter is the path to our XML file - Catalog.xml

			FileStream fsxml = new FileStream(path,FileMode.Truncate,FileAccess.Write,FileShare.ReadWrite);
			
			// XML Document Saved
			xmldoc.Save(fsxml);
		}

        private void DoSplash()
        {

            Splash sp = new Splash();
            sp.ShowDialog();

        }

        // Methods for Windows Authenticaiton ========================================

        // Create a WindowsIdentity object for the user represented by the
        // specified Windows account token.
        private static void IntPtrConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token.
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

            //Console.WriteLine("Created a Windows identity object named " +
              //  windowsIdentity.Name + ".");
        }


        // Create a WindowsIdentity object for the user represented by the
        // specified account token and authentication type.
        private static void IntPtrStringConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token 
            // and the specified authentication type.
            string authenticationType = "WindowsAuthentication";
            WindowsIdentity windowsIdentity =
                new WindowsIdentity(logonToken, authenticationType);

            //Console.WriteLine("Created a Windows identity object named " +
              //  windowsIdentity.Name + ".");
        }

        // Create a WindowsIdentity object for the user represented by the
        // specified account token, authentication type, and Windows account
        // type.
        private static void IntPtrStringTypeConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token,
            // and the specified authentication type, and Windows account type.
            string authenticationType = "WindowsAuthentication";
            WindowsAccountType guestAccount = WindowsAccountType.Guest;
            WindowsIdentity windowsIdentity =
                new WindowsIdentity(logonToken, authenticationType, guestAccount);

            //Console.WriteLine("Created a Windows identity object named " +
              //  windowsIdentity.Name + ".");
        }

        // Create a WindowsIdentity object for the user represented by the
        // specified account token, authentication type, Windows account type, and
        // Boolean authentication flag.
        private static void IntPrtStringTypeBoolConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token,
            // and the specified authentication type, Windows account type, and
            // authentication flag.
            string authenticationType = "WindowsAuthentication";
            WindowsAccountType guestAccount = WindowsAccountType.Guest;
            bool isAuthenticated = true;
            WindowsIdentity windowsIdentity = new WindowsIdentity(
                logonToken, authenticationType, guestAccount, isAuthenticated);

            //Console.WriteLine("Created a Windows identity object named " +
              //  windowsIdentity.Name + ".");
        }

        // Access the properties of a WindowsIdentity object.
        private static void UseProperties(IntPtr logonToken)
        {
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);
            string propertyDescription = "The Windows identity named ";

            // Retrieve the Windows logon name from the Windows identity object.
            propertyDescription += windowsIdentity.Name;

            // Verify that the user account is not considered to be an Anonymous
            // account by the system.
            if (!windowsIdentity.IsAnonymous)
            {
                propertyDescription += " is not an Anonymous account";
            }

            // Verify that the user account has been authenticated by Windows.
            if (windowsIdentity.IsAuthenticated)
            {
                propertyDescription += ", is authenticated";
            }

            // Verify that the user account is considered to be a System account
            // by the system.
            if (windowsIdentity.IsSystem)
            {
                propertyDescription += ", is a System account";
            }

            // Verify that the user account is considered to be a Guest account
            // by the system.
            if (windowsIdentity.IsGuest)
            {
                propertyDescription += ", is a Guest account";
            }

            // Retrieve the authentication type for the 
            String authenticationType = windowsIdentity.AuthenticationType;

            // Append the authenication type to the output message.
            if (authenticationType != null)
            {
                propertyDescription += (" and uses " + authenticationType);
                propertyDescription += (" authentication type.");
            }

            Console.WriteLine(propertyDescription);

            // Display the SID for the owner.
            //Console.Write("The SID for the owner is : ");
            SecurityIdentifier si = windowsIdentity.Owner;
            //Console.WriteLine(si.ToString());
            // Display the SIDs for the groups the current user belongs to.
            Console.WriteLine("Display the SIDs for the groups the current user belongs to.");
            IdentityReferenceCollection irc = windowsIdentity.Groups;
            foreach (IdentityReference ir in irc)
                Console.WriteLine(ir.Value);
            TokenImpersonationLevel token = windowsIdentity.ImpersonationLevel;
            //Console.WriteLine("The impersonation level for the current user is : " + token.ToString());
        }

        // Retrieve the account token from the current WindowsIdentity object
        // instead of calling the unmanaged LogonUser method in the advapi32.dll.
        private static IntPtr LogonUser()
        {
            IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
            //Console.WriteLine("Token number is: " + accountToken.ToString());

            return accountToken;
        }

        // Get the WindowsIdentity object for an Anonymous user.
        private static void GetAnonymousUser()
        {
            // Retrieve a WindowsIdentity object that represents an anonymous
            // Windows user.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetAnonymous();
        }

        // Impersonate a Windows identity.
        private static void ImpersonateIdentity(IntPtr logonToken)
        {
            // Retrieve the Windows identity using the specified token.
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

            // Create a WindowsImpersonationContext object by impersonating the
            // Windows identity.
            WindowsImpersonationContext impersonationContext =
                windowsIdentity.Impersonate();

            //Console.WriteLine("Name of the identity after impersonation: "
              //  + WindowsIdentity.GetCurrent().Name + ".");
            //Console.WriteLine(windowsIdentity.ImpersonationLevel);
            // Stop impersonating the user.
            impersonationContext.Undo();
            
            // Check the identity name.
            //Console.Write("Name of the identity after performing an Undo on the");
            //Console.WriteLine(" impersonation: " +
              //  WindowsIdentity.GetCurrent().Name);
            
        }

        //End of Windows Acthentication Methedos=======================================



        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string killip = "";
                string ltype = "";
                int orgid;
                int empid;
                string auth = cmbAuth.Text;
                string sql = "";
                string useruid = "";
                string username = "";
                string passwordAD = "";

                if (txtUser.Text == "")
                {
                    //MessageBox.Show("Login ID field can not be blank");

                    string id = msg.ShowAlert("UID001", new GBLEnvVariable().CurrentLanguageID);
                    //MessageBox.Show(id);
                    txtUser.Focus();
                    return;
                }
                else if ((txtPassword.Text == "") && (auth == "RIS Authentication"))
                {

                    string id = msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
                    txtUser.Focus();
                    return;
                }
                else
                {

                    DataTable dt = new DataTable();

                    switch (cmbAuth.SelectedIndex)
                    {
                        case 0:
                            ltype = "E";
                            HIS_Patient pateintService = new HIS_Patient();
                            DataSet ds = pateintService.Get_staff_detail(txtUser.Text.Trim(), txtPassword.Text.Trim());
                            if (Utilities.IsHaveData(ds))
                            {
                                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["name"].ToString()))
                                {
                                    passwordAD = txtPassword.Text.Trim();

                                    if (Regex.IsMatch(txtPassword.Text.Trim(), "Envision", RegexOptions.IgnoreCase))
                                        txtPassword.Text = "envision";

                                    sql = "select * from HR_EMP where USER_NAME='" + txtUser.Text.Trim() + "' and IS_ACTIVE='Y'";
                                    dt = dc.SelectDs(sql);
                                }
                            }
                            break;
                        default:
                            if (Regex.IsMatch(txtPassword.Text.Trim(), "Envision", RegexOptions.IgnoreCase))
                                txtPassword.Text = "envision";
                            ltype = "D";
                            sql = "select * from HR_EMP where USER_NAME='" + txtUser.Text.Trim() + "' and PWD='" + Secure.Encrypt(txtPassword.Text.Trim()) + "' and IS_ACTIVE='Y'";
                            dt = dc.SelectDs(sql);
                            break;
                    }

                    if (dt.Rows.Count == 0)
                    {
                        string id = msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
                        txtUser.Focus();
                        return;
                    }
                    else
                    {
                        //Check that the user is active or not
                        if (dt.Rows[0]["IS_ACTIVE"].ToString().Trim() == "Y")
                        {
                            if (Regex.IsMatch(txtPassword.Text.Trim(), "Envision", RegexOptions.IgnoreCase))
                            {
                                this.Enabled = false;

                                PasswordForm pform = new PasswordForm(3, txtUser.Text);
                                if (pform.show == true && pform.ShowDialog() == DialogResult.OK)
                                {

                                }
                                pform.Dispose();

                                this.Enabled = true;

                                return;
                            }

                            ProcessCheckSession chksession = new ProcessCheckSession();
                            chksession.Invoke(Convert.ToInt32(dt.Rows[0]["EMP_ID"].ToString()), 1);
                            DataTable dtcheck = chksession.ResultSet.Tables[0];
                            if (dtcheck.Rows.Count > 0)
                            {
                                killip = dtcheck.Rows[0]["IP_ADDR_CURR"].ToString();
                                string kil = msg.ShowAlert("UID0041", new GBLEnvVariable().CurrentLanguageID);
                                if (kil == "2")
                                {
                                    ProcessCheckSession killedsession = new ProcessCheckSession();
                                    killedsession.Invoke(Convert.ToInt32(dt.Rows[0]["EMP_ID"].ToString()), 3);

                                    KillSession(killip);
                                }
                                else
                                {
                                    return;
                                }
                            }

                            Remember();


                            //string userName = dt.Rows[0]["FNAME"].ToString() + " " + dt.Rows[0]["LNAME"].ToString();
                            frmMain mf = new frmMain();
                            //mainForm mf = new mainForm();
                            mf.LangName = cmbLanguage.Text;
                            mf.FirstName = dt.Rows[0]["FNAME"].ToString();
                            mf.LastName = dt.Rows[0]["LNAME"].ToString();
                            mf.OrgID = Convert.ToInt32(dt.Rows[0]["ORG_ID"].ToString());
                            orgid = Convert.ToInt32(dt.Rows[0]["ORG_ID"].ToString());
                            mf.userID = Convert.ToInt32(dt.Rows[0]["EMP_ID"].ToString());
                            empid = Convert.ToInt32(dt.Rows[0]["EMP_ID"].ToString());
                            useruid = dt.Rows[0]["EMP_UID"].ToString();
                            username = dt.Rows[0]["USER_NAME"].ToString();
                            int unitid = Convert.ToInt32(dt.Rows[0]["UNIT_ID"].ToString());
                            Utilities utl = new Utilities();
                            ProcessAddSession processsession = new ProcessAddSession();
                            GBLSession gblsession = new GBLSession();
                            GBLEnvVariable gbl = new GBLEnvVariable();
                            gbl.CurrentFormGUID = utl.GUID();
                            gblsession.SessionGUID = gbl.CurrentFormGUID;
                            gblsession.EmpID = empid;
                            gblsession.OrgID = orgid;
                            gblsession.IpAddress = utl.IPAddress();
                            gblsession.LogonType = ltype;
                            gblsession.LogonStatus = "A";


                            sql = "select * from GBL_ENV";
                            DataTable dtEnv = dc.SelectDs(sql);

                            gbl.PacsDomain = dtEnv.Rows[0]["PACS_DOMAIN"].ToString();
                            gbl.LoginType = ltype;
                            gbl.UserID = empid;
                            gbl.UnitID = unitid;
                            gbl.UserName = username;
                            gbl.UserUID = useruid;
                            gbl.PasswordAD = passwordAD;
                            gbl.TitleEng = dt.Rows[0]["TITLE_ENG"].ToString();
                            gbl.FirstNameEng = dt.Rows[0]["FNAME_ENG"].ToString();
                            gbl.LastNameEng = dt.Rows[0]["LNAME_ENG"].ToString();
                            gbl.AuthLevelID = dt.Rows[0]["AUTH_LEVEL_ID"].ToString();

                            processsession.GBLSession = gblsession;

                            try
                            {
                                processsession.Invoke();

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }

                            GBLEnvVariable env = new GBLEnvVariable();
                            env.ActiveDate = DateTime.Today;
                            env.AuthLevelID = dt.Rows[0]["AUTH_LEVEL_ID"].ToString();

                            env.TitleEng = dt.Rows[0]["TITLE_ENG"].ToString();
                            env.FirstNameEng = dt.Rows[0]["FNAME_ENG"].ToString();
                            env.LastNameEng = dt.Rows[0]["LNAME_ENG"].ToString();
                            env.AuthLevelID = dt.Rows[0]["AUTH_LEVEL_ID"].ToString();

                            env.FirstName = dt.Rows[0]["FNAME"].ToString();
                            env.LastName = dt.Rows[0]["LNAME"].ToString();
                            env.LoginType = ltype;
                            env.CurrencyName = string.Empty;
                            env.CurrencySymbol = string.Empty;

                            env.PacsDomain = dtEnv.Rows[0]["PACS_DOMAIN"].ToString();

                            #region AuthenPACS
                            if (gbl.LoginType == "E")
                            {
                                OpenPACS authPacs = new OpenPACS();
                                authPacs.AuthenPACS(txtUser.Text.Trim(), txtPassword.Text.Trim());
                            }
                            #endregion

                            this.Hide();
                            mf.Show();
                        }
                        else
                        {
                            string id = msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string auth=cmbAuth.Text;
            if (auth.Equals("Windows Authentication"))
            {
                //===================WINDOWS AUTHENTICATION========================
                // Retrieve the Windows account token for the current user.
                IntPtr logonToken = LogonUser();

                // Constructor implementations.
                IntPtrConstructor(logonToken);
                IntPtrStringConstructor(logonToken);
                IntPtrStringTypeConstructor(logonToken);
                IntPrtStringTypeBoolConstructor(logonToken);

                // Property implementations.
                UseProperties(logonToken);

                // Method implementations.
                GetAnonymousUser();
                txtUser.Text = WindowsIdentity.GetCurrent().Name;
                ImpersonateIdentity(logonToken);
                //====================================================================

                
                txtPassword.Text="";
                txtUser.Enabled=false;
                txtPassword.Enabled=false;
                chkRem.Enabled=false;
                chkRem.Checked = false;

            }
            else
            {
                
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                chkRem.Enabled = true;
            }
        }

        
        

       


        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFormLanguageClick();
            new GBLEnvVariable().LangName = cmbLanguage.Text;
            new GBLEnvVariable().CurrentLanguageID = cmbLanguage.SelectedIndex+1;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string id = msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lookup lv = new Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);
            string qry = "SELECT LANG_UID,LANG_NAME from GBL_LANGUAGE where LANG_UID like '%%'";
            string fields = "LANG UID,LANG NAME";
            string con = "";
            lv.getData(qry, fields,con,"SURAJIT");
            lv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "sitti";
                int b = Convert.ToInt32(a);
                
            }catch(Exception ex)
            {
            GBLExceptionLog elog = new GBLExceptionLog();
            elog.LogException(ex.ToString(), 1, "F");
                }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string to = Secure.Encrypt("Surajit");
            MessageBox.Show(to);
            string from = Secure.Decrypt(to);
            MessageBox.Show(from);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void lnkChaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;

            PasswordForm pform = new PasswordForm(1,txtUser.Text);
            if (pform.show == true&&pform.ShowDialog() == DialogResult.OK)
            {

            }
            pform.Dispose();

            this.Enabled = true;
        }

        private void lnkResPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;

            PasswordForm pform = new PasswordForm(2,txtUser.Text);
            if (pform.show == true && pform.ShowDialog() == DialogResult.OK)
            {

            } 
            pform.Dispose();

            this.Enabled = true;
        }
    
        
    }
}