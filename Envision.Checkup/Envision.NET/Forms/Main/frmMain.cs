/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MT.WindowsUI;
using MT.WindowsUI.NavigationPane;
using RIS.Common.UtilityClass;
using RIS.Forms.Main.Trees;
using RIS.Forms;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Forms.Popup;
using RIS.Forms.Admin;
using UUL.ControlFrame.Controls;
using RIS.Forms.GBLMessage;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace RIS.Forms.Main
{
   
    public partial class frmMain : Form
    {
        int count = 0;
        private int[] langid;
        string defaultlangs;
        GBLEnvVariable env = new GBLEnvVariable();
        int userNo;

        int _langid;
        int _orgid;
        string _firstname;
        string _lastname;
        string _langname;
 
        
        public int userID
        {
            get
            {
                return userNo;
            }
            set
            {
                userNo = value;
            }
        }

        
        public int CurrentLanguageID
        {
            get { return _langid; }
            set { _langid = value; }
        }
                
        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string LangName
        {
            get { return _langname; }
            set { _langname = value; }
        }
        

        #region Var
        // NavigateBar

        ContainerControl containerControlProp = null;
        
        NavigateBar outlookNavigatePane;
        NavigateBarButton nvbCustom;

        // Form
        MTSplitter splitterNavigateMenu = null;

        // ToolStrip

        ToolStrip toolStrip = null;
        ToolStripButton tbtnMDIChildForm;
        ToolStripButton tbtnAbout;
        ToolStripButton tbtnExit;

        // StatusStrip
        StatusStrip statusStrip = null;

        // MenuStrip
        MenuStrip menuStrip = null;

        ToolStripMenuItem mnExit;
        ToolStripMenuItem mnProgram;

        UUL.ControlFrame.Controls.TabControl formContainer;

        #endregion

        public frmMain()
        {
            InitializeComponent();
            ////
            //InitDBConnection();
            ////
            //InitNavigateBar();
            ////
            //InitPullMenu();
            LoadFormLanguage();
            SetCopyRight();
            InitializeBackgroudWorker();
            backgroundWorker1.RunWorkerAsync("RIS");

            InitializeBackgroudWorkerTran();
            backgroundWorker2.RunWorkerAsync("ThaiRomanization");
            MemoryFlush();
        }

        public void MemoryFlush()
        {
            Timer _time = new Timer();
            _time.Interval = 300000;
            _time.Tick += new EventHandler(OnTimeEvent);
            _time.Enabled = true;
        }
        private void OnTimeEvent(object sender, EventArgs e)
        {
            RIS.Operational.HostedApp.FlushMemory();
        }

        private void InitializeBackgroudWorker()
        {
            backgroundWorker1.DoWork +=
                new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
            StreamWriter streamWriter;
            StreamReader streamReader;
            NetworkStream networkStream;
            TcpListener tcpListener = new TcpListener(5559);
            tcpListener.Start();
            Console.WriteLine("The Server has started on port 5555");
            Socket serverSocket = tcpListener.AcceptSocket();
           
                if (serverSocket.Connected)
                {
                    while (true)
                    {
                        try
                        {
                            networkStream = new NetworkStream(serverSocket);
                            streamWriter = new StreamWriter(networkStream);
                            streamReader = new StreamReader(networkStream);

                            string a = (streamReader.ReadLine());
                            MyMessageBox _mymsg = new MyMessageBox();
                            string myid = _mymsg.ShowAlert("UID0051", new GBLEnvVariable().CurrentLanguageID);
                            serverSocket.Close();
                            Application.Exit();
                        }
                        catch (Exception err) { }
                    }
                }

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
             
            }


        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {

            }
            else if (e.ProgressPercentage == 100)
            {

            }
            else
            {
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Background_RunWorkerCompleted");
        }

        private void InitializeBackgroudWorkerTran()
        {
            backgroundWorker2.DoWork +=
                new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            backgroundWorker2.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker2_ProgressChanged);
            backgroundWorker2.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            RIS.Operational.Translator.TransToEnglish.Trans("บริษัท มิราเคิล แอดวานซ์ เทคโนโลยี จำกัด");

        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {

            }
            else if (e.ProgressPercentage == 100)
            {

            }
            else
            {
            }
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Background_RunWorkerCompleted");
        }


        private void SetCopyRight()
        {
            GBLEnvVariable env = new GBLEnvVariable();
            ProcessGetGBLProduct prod = new ProcessGetGBLProduct();
            env.OrgID = 1;
            prod.Invoke();
            DataTable dt = prod.ResultSet.Tables[0];
            int k = 0;
            //new PopupNotify("<b>MIRACLE</b><br>Re: Thank you for using RIS Application</br><br><font color='navy'>Contact : java2guide@gmail.com</font></br>");
            string cp = "";
            string cp2 = "";
            while (k < dt.Rows.Count)
            {
                
                cp = dt.Rows[k]["PROD_NAME"].ToString();
                cp2 =  dt.Rows[k]["COPY_RIGHT"].ToString();
                k++;
                
            }
            this.ultraToolbarsManager1.Tools["LabelTool1"].SharedProps.Caption = cp;
            this.ultraToolbarsManager1.Tools["LabelTool2"].SharedProps.Caption = cp2;
            //this.Text = "surajit";
            this.ultraToolbarsManager1.Ribbon.Caption = cp;
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
            System.Diagnostics.Process.Start("http://localhost/EnvisionHelper/EnvisionWebHelp.html");
        }
       
#region Language
        private void LoadFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;

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
                while (k < dt.Rows.Count)
                {
                    toolStripComboBox1.Items.Add(dt.Rows[k]["LANG_NAME"].ToString());
                    string lid = dt.Rows[k]["LANG_ID"].ToString();

                    langid[k] = Convert.ToInt32(lid);
                    if ((dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim()) == ("Y"))
                    {
                        defaultlangs = dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim();
                        


                    }

                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }

#endregion


        private void InitDBConnection()
        {
            
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connStr"]); ;
            DatabaseUtility.Connection = connection;
        }

        public void InitNavigateBar()
        {
            // Form Container

            formContainer = new UUL.ControlFrame.Controls.TabControl();
            formContainer.Dock = DockStyle.Fill;
            formContainer.AutoScroll = true;
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0x98, /* G */ 0xB8, /* B */ 0xE2);
            formContainer.BackColor = c;
            formContainer.HideTabsMode = UUL.ControlFrame.Controls.TabControl.HideTabsModes.ShowAlways;
            formContainer.Name = "formContainer";
            formContainer.PositionTop = true;
            formContainer.ShowArrows = true;
            formContainer.ShowClose = true;
            formContainer.TabIndex = 16;
            
            //formContainer.BackgroundImage = global::Synesis.CloveLakes.Properties.Resources.mainBackground;
            //formContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            formContainer.SelectionChanged += new System.EventHandler(this.formContainer_SelectionChanged);
            formContainer.ClosePressed += new System.EventHandler(this.formContainer_ClosePressed);
            
            frmMainTab frmMainTab = new frmMainTab(formContainer);
            UUL.ControlFrame.Controls.TabPage page;
            page = new UUL.ControlFrame.Controls.TabPage(frmMainTab.Text, frmMainTab);
            page.Selected = true;
            formContainer.TabPages.Add(page);
            formContainer.SelectedTab.Tag = "RIS.Forms.Main.frmMainTab";

            formContainer.Style = UUL.ControlFrame.Common.VisualStyle.IDE;

            outlookNavigatePane = new NavigateBar();
            outlookNavigatePane.Dock = DockStyle.Left;
            outlookNavigatePane.IsShowCollapsibleScreen = true;
            outlookNavigatePane.CollapsedScreenWidth = 150; // For all buttons // Optional
            outlookNavigatePane.CollapsibleWidth = 32;
            outlookNavigatePane.NavigateBarColorTable = NavigateBarColorTable.Office2007Blue;
            outlookNavigatePane.Width = 180;
            outlookNavigatePane.NavigateBarDisplayedButtonCount = 10;
            outlookNavigatePane.DisplayedButtonCount = 10;
            //outlookNavigatePane.NavigateBarButtonHeight = 20;
                               
            
            #region NavigateBar Buttons            
            DataTable menuTab;

           
            lblUser.Text = "        "+FirstName + " " + LastName+"        ";
            env.FirstName = FirstName;
            env.LastName = LastName;
            env.UserID = userID;
            env.OrgID = OrgID;
            env.LangName = this.LangName;
            toolStripComboBox1.Text = env.LangName;
            try
            {
                //--Collect the menu name from the database--\\
                DataTable company = DatabaseUtility.ExecuteDataTable("SELECT ORG_NAME FROM GBL_ENV WHERE ORG_ID=" + OrgID + "");
                int ij = 0;
                while (ij < company.Rows.Count)
                {
                    string orgname = "" + company.Rows[ij]["ORG_NAME"].ToString() + "";
                    lblCompany.Text = "   "+orgname+"    ";
                    lblDate.Text = "    "+ System.DateTime.Now.ToShortDateString()+"   ";
                    ij++;
                }

            }
            catch
            {
            }


            try
            {
                //--Collect the menu name from the database--\\
                menuTab = DatabaseUtility.ExecuteDataTable("SELECT DISTINCT MENU_ID,MENU_NAME,MENU_SL_NO FROM GBLV_SETMENU WHERE EMP_ID="+userID+ 
                "AND MENU_IS_ACTIVE='Y' ORDER BY MENU_SL_NO");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            int i = 0;
            while (i < menuTab.Rows.Count)
            {
                string name = "" + menuTab.Rows[i]["MENU_NAME"].ToString() + "";
                string desc = "" + menuTab.Rows[i]["MENU_NAME"].ToString() + "";
                string menuNo = "" + menuTab.Rows[i]["MENU_ID"].ToString() + ""; 

                nvbCustom = new NavigateBarButton();
                nvbCustom.RelatedControl = new SubMenuTree(name, menuNo, formContainer,userNo);
                nvbCustom.Caption = name;
                nvbCustom.CaptionDescription = desc;
                nvbCustom.OnNavigateBarButtonSelected += new NavigateBarButton.OnNavigateBarButtonSelectedEventHandler(nvbMail_OnNavigateBarButtonSelected);
                if (i == 0)
                {
                    SubMenuTree sTree = (SubMenuTree)nvbCustom.RelatedControl;
                    sTree.load_tree();
                }

                switch (menuNo)
                {
                    case "1001":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.FaceSheet24;
                        break;
                    case "1002":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Rehabilitation24;
                        break;
                    case "1003":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Inventory24;
                        break;
                    case "1004":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Botique24;
                        break;
                    case "1005":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.QI24;
                        break;
                    case "1006":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.GeneralOffice24;
                        break;
                    case "1007":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.CYC24;
                        break;
                    case "1008":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Recreation24;
                        break;
                    case "1009":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.PlantOperation24;
                        break;
                    case "1010":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Nursing24;
                        break;
                    case "1011":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Perssonel24;
                        break;
                    case "1012":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.SocialService24;
                        break;
                    case "1013":
                        //nvbCustom.Image = global::Envision.NET.Properties.Resources.Photo24;
                        break;
                    case "1":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.icon_adminstrator32;
                        break;
                    case "2":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.icon_order32;
                        break;
                    case "3":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.icon_schedule32;
                        break;
                    case "16":
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.icon_home32;
                        break;
                    case "5": // report manager
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.reporting_management2_32;
                        break;
                    case "19": //schedule
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.personal_schedule32;
                        break;
                    case "17": //bi
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.business_intelligence32;
                        break;
                    case "18": //technologist
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.technologist32;
                        break;
                    case "20": //technologist
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.browse_24;
                        break;
                    case "21": //technologist
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.calculator_orange24;
                        break;
                    default:
                        nvbCustom.Image = global::Envision.NET.Properties.Resources.icon_report32;
                        break;
                }                
                nvbCustom.Enabled = true;
                nvbCustom.Key = menuNo;
                nvbCustom.IsShowCaptionImage = false;
                outlookNavigatePane.NavigateBarButtons.Add(nvbCustom);
                i++;
            }

            outlookNavigatePane.NavigateBarDisplayedButtonCount = 10;
            outlookNavigatePane.DisplayedButtonCount = 10;
            
            #endregion

            #region Strips

            c = System.Drawing.Color.FromArgb( /* R */ 0xE3, /* G */ 0xEF, /* B */ 0xFF);

            // ToolStrip
            toolStrip = new ToolStrip();
            toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            toolStrip.BackColor = c;

            tbtnMDIChildForm = new ToolStripButton();
            tbtnMDIChildForm.Text = "Test";
            tbtnMDIChildForm.Click += new EventHandler(tbtnMDIChildForm_Click);

            tbtnAbout = new ToolStripButton();
            tbtnAbout.Text = "About";
            tbtnAbout.Click += delegate(object sender, EventArgs e)
                {

                    Type typ = typeof(frmMain);

                    object[] r = typ.Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                    AssemblyCopyrightAttribute ct = (AssemblyCopyrightAttribute)r[0];

                    object[] d = typ.Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                    AssemblyDescriptionAttribute dt = (AssemblyDescriptionAttribute)d[0];

                    object[] v = typ.Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                    AssemblyFileVersionAttribute vt = (AssemblyFileVersionAttribute)v[0];

                    MessageBox.Show(ct.Copyright + "\n\n" + dt.Description + "\n\n" + "Version : " + vt.Version);

                };


            tbtnExit = new ToolStripButton();
            tbtnExit.Text = "Exit";
            tbtnExit.Click += delegate(object sender, EventArgs e)
            {
                this.Close();
            };

            toolStrip.Items.Add(tbtnMDIChildForm);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(tbtnAbout);
            toolStrip.Items.Add(tbtnExit);


            // MenuStrip

            menuStrip = new MenuStrip();
            menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            menuStrip.Dock = DockStyle.Top;
            c = System.Drawing.Color.FromArgb( /* R */ 0xBF, /* G */ 0xDB, /* B */ 0xFF);

            menuStrip.BackColor = c;
            MainMenuStrip = menuStrip;

            // StatusStrip

            statusStrip = new StatusStrip();
            statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            c = System.Drawing.Color.FromArgb( /* R */ 0xB5, /* G */ 0xD5, /* B */ 0xFF);
            statusStrip.BackColor = c;

            #endregion

            // Splitter

            splitterNavigateMenu = new MTSplitter();
            splitterNavigateMenu.Size = new Size(7, 100);
            splitterNavigateMenu.SplitterPointCount = 10;
            splitterNavigateMenu.SplitterPaintAngle = 360F;
            splitterNavigateMenu.Dock = DockStyle.Left;

            Controls.AddRange(new Control[] { formContainer, splitterNavigateMenu, outlookNavigatePane, null, statusStrip, null });

        }

        /// <summary>
        /// Navbar button selected
        /// </summary>
        /// <param name="e"></param>
        void nvbMail_OnNavigateBarButtonSelected(NavigateBarButtonEventArgs e)
        {
            SubMenuTree sTree = (SubMenuTree)e.NavigateBarButton.RelatedControl;
            sTree.load_tree();
        }

        private void formContainer_ClosePressed(object sender, EventArgs e)
        {
            try
            {
                if (formContainer.TabPages.Count > 0)
                {
                   
                    GBLSessionLog slog = new GBLSessionLog();
                    slog.SPType = 2;
                    slog.SessionGUID = new GBLEnvVariable().CurrentFormGUID;
                    slog.SubmenuID = new GBLEnvVariable().CurrentFormID;
                    slog.OrgID = new GBLEnvVariable().OrgID;
                    slog.CreatedBy = new GBLEnvVariable().UserID;

                    ProcessAddSessionLog pslog = new ProcessAddSessionLog();
                    pslog.GBLSessionLog = slog;
                    pslog.Invoke();
                    formContainer.TabPages.Remove(formContainer.SelectedTab);

                    
                                                        
                }
            }

            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void formContainer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (formContainer.TabPages.Count > 0)
                {
                    DataTable dtabl = DatabaseUtility.ExecuteDataTable("select * FROM GBL_SUBMENU WHERE SUBMENU_NAME_USER='" + formContainer.SelectedTab.Title + "'");
                    //MessageBox.Show(formContainer.SelectedTab.Title);
                    int x = 0;
                    if (x < dtabl.Rows.Count)
                    {
                        new GBLEnvVariable().CurrentFormID = Convert.ToInt32(dtabl.Rows[x]["SUBMENU_ID"].ToString());
                        new GBLEnvVariable().FormTitle = formContainer.SelectedTab.Title;
                    }
                    
                    //MessageBox.Show(""+new GBLEnvVariable().CurrentFormID);
                }
                else
                {
                    //label1.Text = "RIS";
                }
            }

            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Changed rtl state, redock controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void outlookNavigatePane_RightToLeftChanged(object sender, EventArgs e)
        {
            if (outlookNavigatePane.RightToLeft == RightToLeft.Yes)
            {
                containerControlProp.Dock = DockStyle.Left;
                outlookNavigatePane.Dock = DockStyle.Right;
                splitterNavigateMenu.Dock = DockStyle.Right;
            }
            else
            {
                containerControlProp.Dock = DockStyle.Right;
                outlookNavigatePane.Dock = DockStyle.Left;
                splitterNavigateMenu.Dock = DockStyle.Left;
            }
        }

        /// <summary>
        /// Pane colortable changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void outlookNavigatePane_OnNavigateBarColorChanged(object sender, EventArgs e)
        {
            splitterNavigateMenu.SplitterLightColor = outlookNavigatePane.NavigateBarColorTable.ButtonNormalBegin;
            splitterNavigateMenu.SplitterDarkColor = outlookNavigatePane.NavigateBarColorTable.ButtonNormalEnd;
            splitterNavigateMenu.SplitterBorderColor = Color.Transparent;
        }

        #region Strips Events & Methods
        void tbtnMDIChildForm_Click(object sender, EventArgs e)
        {
            
        }

        void InitPullMenu()
        {

            mnProgram = new ToolStripMenuItem("Program");

            mnExit = new ToolStripMenuItem("Exit");
            mnExit.Click += new EventHandler(mnExit_Click);

            mnProgram.DropDownItems.Add(mnExit);

            menuStrip.Items.Add(mnProgram);

        }

        void mnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //
            InitDBConnection();
            //
            InitNavigateBar();
            //
            InitPullMenu();
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GBLEnvVariable gbl = new GBLEnvVariable();
            ProcessCloseSession processsession = new ProcessCloseSession();
            GBLSession gblsession = new GBLSession();
            gblsession.SessionGUID = gbl.CurrentFormGUID;
            gblsession.LogonStatus = "I";

            processsession.GBLSession = gblsession;

            try
            {
                processsession.Invoke();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            Application.Exit();
        }

        private void toolStripLogOff_Click(object sender, EventArgs e)
        {
            
            

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "calc";
            proc.Start(); 

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            GBLEnvVariable gbl = new GBLEnvVariable();
            ProcessCloseSession processsession = new ProcessCloseSession();
            GBLSession gblsession = new GBLSession();
            gblsession.SessionGUID = gbl.CurrentFormGUID;
            gblsession.LogonStatus = "I";
            
            processsession.GBLSession = gblsession;

            try
            {
                processsession.Invoke();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            Hide();
            Form1 frm = new Form1();
            frm.Visible = true;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
           // new GBLEnvVariable().LangName = toolStripComboBox1.Text;
           // new GBLEnvVariable().CurrentLanguageID = toolStripComboBox1.SelectedIndex + 1;
            //MessageBox.Show(""+toolStripComboBox1.SelectedIndex + 1;
           // string tag = formContainer.SelectedTab.Tag.ToString();
           // string txt = formContainer.SelectedTab.Title.ToString();
          // formContainer.TabPages.RemoveAt(formContainer.SelectedIndex);
           
          // SubMenuTree stree = new SubMenuTree(formContainer);
          // stree.form(tag, txt);
          // formContainer.SelectedTab.Tag = tag;
            
                      
            
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (count > 1)
            {
                
                new GBLEnvVariable().LangName = toolStripComboBox1.Text;
                new GBLEnvVariable().CurrentLanguageID = toolStripComboBox1.SelectedIndex + 1;
                //MessageBox.Show(""+toolStripComboBox1.SelectedIndex + 1;
                string tag = formContainer.SelectedTab.Tag.ToString();
                string txt = formContainer.SelectedTab.Title.ToString();
                formContainer.TabPages.RemoveAt(formContainer.SelectedIndex);

                SubMenuTree stree = new SubMenuTree(formContainer);
                stree.form(tag, txt);
                formContainer.SelectedTab.Tag = tag;
            }
        }
       
       
        

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Language":    // StateButtonTool
                    // Place code here
                    break;

                case "LogOff":    // ButtonTool
                    GBLEnvVariable gbl = new GBLEnvVariable();
                    ProcessCloseSession processsession = new ProcessCloseSession();
                    GBLSession gblsession = new GBLSession();
                    gblsession.SessionGUID = gbl.CurrentFormGUID;
                    gblsession.LogonStatus = "I";

                    processsession.GBLSession = gblsession;

                    try
                    {
                        processsession.Invoke();

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    Hide();
                    Form1 frm = new Form1();
                    frm.Visible = true;

                    break;

                case "MaskedEditTool1":    // MaskedEditTool
                    // Place code here
                    break;

                case "Radiology Information System.":    // LabelTool
                    // Place code here
                    break;

                case "Copyright (C) 2008 MIRACLE. All rights reserved.":    // LabelTool
                    // Place code here
                    break;

                case "ButtonTool1":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool2":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool3":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool4":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool5":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool6":    // ButtonTool
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "calc";
                    proc.Start(); 
                    break;

                case "ButtonTool7":    // ButtonTool
                    ShowHelp();
                    break;

                case "ButtonTool8":    // ButtonTool
                    // Place code here
                    break;

                case "ButtonTool9":    // ButtonTool
                    string formid=""+new GBLEnvVariable().CurrentFormID;
                    string stat = "A";
                    ProcessGetGBLFavourite fav5 = new ProcessGetGBLFavourite("3");
                    fav5.Invoke();
                    DataTable dt5 = fav5.ResultSet.Tables[0];
                    int i = 0;
                    MyMessageBox msg = new MyMessageBox();
                    
                    while (i < dt5.Rows.Count)
                    {
                        if ((dt5.Rows[i]["SUBMENU_ID"].ToString() == formid) && (dt5.Rows[i]["IS_ACTIVE"].ToString() == "A"))
                        {
                            msg.ShowAlert("UID007", new GBLEnvVariable().CurrentLanguageID);
                            //MessageBox.Show("Already added to your home page");
                        }
                        else if ((dt5.Rows[i]["SUBMENU_ID"].ToString() == formid) && (dt5.Rows[i]["IS_ACTIVE"].ToString() == "I"))
                        {
                            ProcessUpdateMyMenu upmy = new ProcessUpdateMyMenu(Convert.ToInt32(formid.ToString()), stat);
                            upmy.Invoke();
                            msg.ShowAlert("UID008", new GBLEnvVariable().CurrentLanguageID);
                            //MessageBox.Show("Successfully added to your home page");
                        }
                        else
                        {
                        }
                        i++;
                    }
                    break;


                case "Exit":    // ButtonTool
                    this.Close();
                    break;

            }

        }

        


    }
}