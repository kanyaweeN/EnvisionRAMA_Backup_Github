using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Deployment.Application;
using Miracle.Util;
using Envision.Common;
using Envision.Common.Linq;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.InternalMessage;
using System.Net.NetworkInformation;
using System.Security;
using System.Diagnostics;
using Envision.Operational.Translator;
using DevExpress.XtraBars.Alerter;
using Envision.Operational.PACS;
namespace Envision.NET.Forms.Main
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static GBLEnvVariable env;
        private static List<GBL_LANGUAGE> langList;
        private static GBL_LANGUAGE currentLang;
        private static DataRow rowHome;
        private TcpListener tcpListener;
        private TcpListener tcpPortListner;
        private string resultID;
        private int no_ofMSG = 0;

        private DateTime LastMouseClicked;

        private DataSet dsComments;
        private DataTable dataComments;
        private MyMessageBox msg;

        OpenPACS authPacs = new OpenPACS();

        public frmMain()
        {
            InitializeComponent();
            initBackgroudWorker();
            this.CenterToScreen();
            env = new GBLEnvVariable();
            myDefaultLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue");
            initializeControl();
            initializeHomeForm();
            msg = new MyMessageBox();
        }
        
        public void SetDefaultLookAndFeel() {
            myDefaultLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue");

        }
        public void DisplayHome() {
            for (int i = 0; i < mdiMain.Pages.Count; i++)
            {
              
                if (mdiMain.Pages[i].Text=="Home")
                {
                    mdiMain.SelectedPage = mdiMain.Pages[i];
                    return;
                }
            }
        }
        public bool FormIsAlive(int SubmenuID) {
            bool flag = false;
            for (int i = 0; i < mdiMain.Pages.Count; i++)
            {
                Envision.NET.Forms.Main.MasterForm form = (Envision.NET.Forms.Main.MasterForm)mdiMain.Pages[i].MdiChild;
                if (form.Submenu_ID == SubmenuID) {
                    flag = true;
                    mdiMain.SelectedPage = mdiMain.Pages[i];
                    break;
                }
            
            }
            return flag;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            rbMain.Visible = false;
 	        env = new GBLEnvVariable();
            alertNewComment();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExecuteCommandSync(@"net use r: /d /y");

            GBLEnvVariable gbl = new GBLEnvVariable();
            ProcessCloseSession processsession = new ProcessCloseSession();
            GBL_SESSION gblsession = new GBL_SESSION();
            gblsession.SESSION_GUID = gbl.CurrentFormGUID;
            gblsession.SESSION_STAT = 'I';
            processsession.GBL_SESSION = gblsession;
            try
            {
                processsession.Invoke();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            authPacs.LogoutPACS();
            Application.Exit();
        }

        private void mdiMain_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (env.USED_MENUBAR == "Y")
            {
                bool flag = true;
                for (int i = 0; i < mdiMain.Pages.Count; i++)
                {
                    Envision.NET.Forms.Main.MasterForm mas = (Envision.NET.Forms.Main.MasterForm)mdiMain.Pages[i].MdiChild;
                    if (mas.Submenu_ID.ToString() == resultID)
                    {
                        flag = false;
                        return;
                    }
                }
                if (flag)
                {
                    navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
                    navBarMain.Visible = true;
                    rbMain.Visible = false;
                }
            }
        }
        private void alertMsg_FormClosing(object sender, DevExpress.XtraBars.Alerter.AlertFormClosingEventArgs e)
        {


        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeLanguage();
            for (int i = 0; i < mdiMain.Pages.Count; i++)
            {
                Envision.NET.Forms.Main.MasterForm master = (Envision.NET.Forms.Main.MasterForm)mdiMain.Pages[i].MdiChild;
                if (master != null)
                    master.ChangeLanguage();
            }
        }

        private void btnLogOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            authPacs.LogoutPACS();
            Application.Restart();
        }
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #region Backgroud Worker.

        private void initPortSocket()
        {
            tcpPortListner = new TcpListener(5555);
            tcpPortListner.Start();
        }
        private void bgPort_DoWork(object sender, DoWorkEventArgs e)
        {
            Socket serverSocket = tcpPortListner.AcceptSocket();
            if (serverSocket.Connected)
            {
                StreamReader streamReader;
                NetworkStream networkStream;
                networkStream = new NetworkStream(serverSocket);
                streamReader = new StreamReader(networkStream);
                e.Result = (streamReader.ReadLine());
                serverSocket.Close();
            }
            else
                e.Result = "N";
        }
        private void bgPort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
        private void bgPort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
            if (e.Result.ToString() == "KillSession")
            {
                ProcessGetGBLSessionViewer getAltMsg = new ProcessGetGBLSessionViewer();
                string altMsg = "Your session have been killed";

                try
                {
                    DataSet dsAltMsg = getAltMsg.GetSessionAltMsg(new GBLEnvVariable().UserID);
                    altMsg = dsAltMsg.Tables[0].Rows[0]["SESSION_ALT_MSG"].ToString();
                }
                catch
                {
                }

                MessageBox.Show(altMsg, "session have been killed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                Application.Exit();
            }
            else if (e.Result.ToString() == "CommentAlert")
            {
                alertNewComment();
            }
            else if (e.Result.ToString().ToLower().StartsWith("openpacsdirectly"))
            {
                string[] arryResult = e.Result.ToString().Split(':');
                string str = env.PacsUrl + arryResult[1];
                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenSynapseLink(str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
                initPortSocket();
            }
            else if (e.Result.ToString() == "WarningUpdateEnvision")
            {
                msg.ShowAlert("UID4050", env.CurrentLanguageID);
                bgPort.RunWorkerAsync("RIS");
            }
            else
                bgPort.RunWorkerAsync("RIS");
        }
              
        #endregion

        #region Initialize Control.
        private void createChildForm(string name,DataRow row)
        {
            for (int i = 0; i < mdiMain.Pages.Count; i++)
            {
                Envision.NET.Forms.Main.MasterForm mas = (Envision.NET.Forms.Main.MasterForm) mdiMain.Pages[i].MdiChild;
                if (mas.Submenu_ID.ToString() == row["SUBMENU_ID"].ToString())
                {
                    mdiMain.SelectedPage = mdiMain.Pages[i];
                    return;
                }
            }
            Envision.NET.Forms.Main.MasterForm form = null;
            try
            {
                Assembly asm = Assembly.Load("Envision.NET");
                Type frmType = asm.GetType(name);
                frmType = asm.GetType(name);
                if (frmType == null)
                {
#if DEBUG
                    MessageBox.Show("FORM IS NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
#endif
                    MessageBox.Show("Form not created, please contact support.", "Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                object obj = Activator.CreateInstance(frmType);
                form = (Envision.NET.Forms.Main.MasterForm)obj;
                form.MdiParent = this;
                form.Menu_ID = Convert.ToInt32(row["MENU_ID"].ToString());
                form.Submenu_ID = Convert.ToInt32(row["SUBMENU_ID"].ToString());
                form.Role_ID = Convert.ToInt32(row["ROLE_ID"].ToString());
                form.Menu_Name_Class = row["SUBMENU_CLASS_NAME"].ToString();
                form.Menu_Name_User = row["SUBMENU_NAME_USER"].ToString();
                form.Menu_Namespace = row["MENU_NAMESPACE"].ToString();
                form.ReportingSerivce_URL =  row["SUBMENU_REPORTINGSERVICE_URL"].ToString();
                form.Menu_FullNamespace = form.Menu_Namespace + "." + form.Menu_Name_Class;
                form.Text = form.Menu_Name_User;
                form.ISOpenwebOutside = row["IS_OPENWEBOUTSIDE"].ToString();

                if (form.Submenu_ID.ToString()==resultID) {
                    if (env.USED_MENUBAR == "Y")
                    {
                        navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                        //rbMain.Visible = true;
                    }
                }

                form.ShowWaitDialog();
                Application.DoEvents();
                form.Show();
                form.Activate();
                if (form.ISOpenwebOutside == "Y")
                {
                    //form.Close();
                    //}
                    //else if (form.ISOpenwebOutside == "P")
                    //{
                    form.Close();
                    //frmOpenWebsite frm = new frmOpenWebsite(form.ReportingSerivce_URL);
                    //frm.Show();

                    // open in Google Chrome
                    Process[] remoteByName = Process.GetProcessesByName("openPACSWithApplication");
                    if (remoteByName.Length == 0)
                        System.Diagnostics.Process.Start("http://miracle99/envisionpacsdirectlyapp/openPACSWithApplication.application");
                    //else
                    Process.Start("chrome", form.ReportingSerivce_URL);
                }
            }catch(Exception ex)
            {
                if (form != null)
                {
                    form.CloseWaitDialog();
                    form.Close();
                    form.Dispose();
                }
#if DEBUG
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
#endif
                MessageBox.Show("Form not created, please contact support.", "Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private  void initializeRadiologistBar() {
            ProcessGetGBLMenu process = new ProcessGetGBLMenu();
            DataSet menu = process.GetMenuEMP(env.UserID);
            if (Utilities.IsHaveData(menu) == false) return;
            DataTable dtt = menu.Tables[1];
            DevExpress.XtraBars.BarButtonItem[] listItem = new DevExpress.XtraBars.BarButtonItem[dtt.Rows.Count];
            for (int i = 0; i < dtt.Rows.Count; i++) {
                listItem[i] = new DevExpress.XtraBars.BarButtonItem();
                listItem[i].Name = dtt.Rows[i]["MENU_NAMESPACE"].ToString() + "." + dtt.Rows[i]["SUBMENU_CLASS_NAME"].ToString();
                listItem[i].Caption = dtt.Rows[i]["SUBMENU_NAME_USER"].ToString();
                listItem[i].Tag = dtt.Rows[i]   ;
                listItem[i].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(frmMain_ItemClick);
            }
            dtt = menu.Tables[0];
            foreach (DataRow row in dtt.Rows) {
                DevExpress.XtraBars.Ribbon.RibbonPage page = new DevExpress.XtraBars.Ribbon.RibbonPage(row["MENU_NAME"].ToString());
                rbMain.Pages.Add(page);
                DataRow[] rows = menu.Tables[1].Select("MENU_ID=" + row["MENU_ID"].ToString());
                List<string> chkDup = new List<string>();
                if (rows.Length > 0)
                {
                    DevExpress.XtraBars.Ribbon.RibbonPageGroup pageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup(row["MENU_NAME"].ToString());
                    pageGroup.ShowCaptionButton = false;
                    foreach (DataRow dr in rows)
                    {
                        if (chkDup.IndexOf(dr["SUBMENU_ID"].ToString()) == -1)
                        {
                            string menuName = dr["MENU_NAMESPACE"].ToString() + "." + dr["SUBMENU_CLASS_NAME"].ToString();
                            for (int i = 0; i < listItem.Length; i++)
                                if (listItem[i].Name == menuName)
                                {
                                    pageGroup.ItemLinks.Add(listItem[i]);
                                    chkDup.Add(dr["SUBMENU_ID"].ToString());
                                    break;
                                }
                        }
                    }
                    rbMain.Pages[page.Text].Groups.Add(pageGroup);
                }
            }
        }
        private  void frmMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow row = (DataRow)e.Item.Tag;
            createChildForm(row[2].ToString() + "." + row[0].ToString(), row);
        }

        public   void initializeNavigatorBar() {

            ProcessGetGBLMenu process = new ProcessGetGBLMenu();
            DataSet menu = process.GetMenuEMP(env.UserID);
            if (Utilities.IsHaveData(menu)==false) return;
            DataTable dtt = menu.Tables[0];
            foreach (DataRow row in dtt.Rows) {
                DevExpress.XtraNavBar.NavBarGroup group = new DevExpress.XtraNavBar.NavBarGroup(row["MENU_NAME"].ToString());
              
                #region Add Icon to GroupNavbar.
                switch (row["MENU_ID"].ToString())
                {
                    case "1": //admin
                        group.LargeImageIndex = 9;
                        group.SmallImageIndex = 9;
                        break;
                    case "2"://order
                        group.LargeImageIndex = 2;
                        group.SmallImageIndex = 2;
                        break;
                    case "3"://patient schedule
                        group.LargeImageIndex = 6;
                        group.SmallImageIndex = 6;
                        break;
                    case "16"://home
                        group.LargeImageIndex = 0;
                        group.SmallImageIndex = 0;
                        break;
                    case "5": // report manager
                        group.LargeImageIndex = 4;
                        group.SmallImageIndex = 4;
                        break;
                    case "19": //schedule
                        group.LargeImageIndex = 1;
                        group.SmallImageIndex = 1;
                        break;
                    case "17": //bi
                        group.LargeImageIndex = 5;
                        group.SmallImageIndex = 5;
                        break;
                    case "18": //technologist
                        group.LargeImageIndex = 3;
                        group.SmallImageIndex = 3;
                        break;
                    case "20": //inventory
                        group.LargeImageIndex = 7;
                        group.SmallImageIndex = 7;
                        break;
                    case "21": //technologist
                        group.LargeImageIndex = 8;
                        group.SmallImageIndex = 8;
                        break;
                    case "22": //OLAP
                        group.LargeImageIndex = 19;
                        group.SmallImageIndex = 19;
                        break;
                    case "23": //Acedemic
                        group.LargeImageIndex = 18;
                        group.SmallImageIndex = 18;
                        break;
                    case "24": //Structure Report
                        group.LargeImageIndex = 17;
                        group.SmallImageIndex = 17;
                        break;
                    case "25": //Risk
                        group.LargeImageIndex = 20;
                        group.SmallImageIndex = 20;
                        break;
                    default:
                        group.LargeImageIndex = 6;
                        group.SmallImageIndex = 6;
                        break;

                }
                #endregion

                #region Phase 1.
                //List<string> chkDup = new List<string>();
                //DataRow[] rows = menu.Tables[1].Select("MENU_ID=" + row["MENU_ID"].ToString());
                //if (rows.Length > 0)
                //{
                //    foreach (DataRow dr in rows)
                //    {
                //        if (row["MENU_ID"].ToString() == "16") //Home
                //        {
                //            if (dr["SUBMENU_CLASS_NAME"].ToString() == "frmMainTab")
                //            {
                //                DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(dr["SUBMENU_NAME_USER"].ToString());
                //                item.Tag = dr;
                //                item.Name = "Envision.NET.Forms.Main.Home";
                //                rowHome = dr;
                //                group.ItemLinks.Add(item);
                //                chkDup.Add(dr["SUBMENU_ID"].ToString());
                //            }
                //        }
                //        else if (row["MENU_ID"].ToString() == "5")//resule entry
                //        {
                //            DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(dr["SUBMENU_NAME_USER"].ToString());
                //            item.Tag = dr;
                //            switch (dr["SUBMENU_ID"].ToString())
                //            {
                //                case "14":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.frmResultEntry";
                //                    break;
                //                case "55":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.frmReprint";
                //                    break;
                //                case "89":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.SearchEngine";
                //                    break;
                //                case "92":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.RadExperience";
                //                    break;
                //                case "94":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.frmResultEntry_Lite";
                //                    break;
                //                case "97":
                //                    item.Name = "Envision.NET.Forms.ResultEntry.RadStudyManagement";
                //                    break;
                //            }
                //            item.SmallImage = ImageList.Images[0];
                //            group.ItemLinks.Add(item);
                //            chkDup.Add(dr["SUBMENU_ID"].ToString());
                //        }
                //        else if (row["MENU_ID"].ToString() == "3")//schedule
                //        {
                //            DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(dr["SUBMENU_NAME_USER"].ToString());
                //            item.Tag = dr;
                //            switch (dr["SUBMENU_ID"].ToString())
                //            {
                //                case "3":
                //                    item.Name = "Envision.NET.Forms.Schedule.frmSchedule";
                //                    break;
                //            }
                //            item.SmallImage = ImageList.Images[0];
                //            group.ItemLinks.Add(item);
                //            chkDup.Add(dr["SUBMENU_ID"].ToString());
                //        }
                //        else
                //        {
                //            DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(dr["SUBMENU_NAME_USER"].ToString());
                //            item.Tag = dr;
                //            item.Name = dr["MENU_NAMESPACE"].ToString() + "." + dr["SUBMENU_CLASS_NAME"].ToString();
                //            if (item.Name == "Envision.NET.Forms.Orders.frmOrders") Envision.NET.Forms.Main.MasterForm.OrderSubMenuID = Convert.ToInt32(dr["SUBMENU_ID"].ToString());
                //            if (item.Name == "Envision.NET.Forms.ResultEntry.frmResultEntry") resultID = dr["SUBMENU_ID"].ToString();
                //            item.SmallImage = ImageList.Images[0];
                //            group.ItemLinks.Add(item);
                //            chkDup.Add(dr["SUBMENU_ID"].ToString());
                //        }
                //    }
                //}
                #endregion

                #region Real Logic.
                DataRow[] rows = menu.Tables[1].Select("MENU_ID=" + row["MENU_ID"].ToString());
                List<string> chkDup = new List<string>();
                if (rows.Length > 0)
                {

                    foreach (DataRow dr in rows)
                    {
                        if (chkDup.IndexOf(dr["SUBMENU_ID"].ToString()) == -1)
                        {
                            DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(dr["SUBMENU_NAME_USER"].ToString());
                            item.Tag = dr;
                            item.Name = dr["MENU_NAMESPACE"].ToString() + "." + dr["SUBMENU_CLASS_NAME"].ToString();
                            if (item.Name == "Envision.NET.Forms.Main.Home") rowHome = dr;
                            if (item.Name == "Envision.NET.Forms.Orders.frmOrders") Envision.NET.Forms.Main.MasterForm.OrderSubMenuID = Convert.ToInt32(dr["SUBMENU_ID"].ToString());
                            if (item.Name == "Envision.NET.Forms.ResultEntry.frmResultEntry") resultID = dr["SUBMENU_ID"].ToString();
                            item.SmallImage = ImageList.Images[0];
                            group.ItemLinks.Add(item);
                            chkDup.Add(dr["SUBMENU_ID"].ToString());

                            if (item.Name == "Envision.NET.Forms.ResultEntry.frmResultEntry")
                                createChildForm(item.Name, (DataRow)item.Tag);
                        }
                    }
                } 
                #endregion
                navBarMain.Groups.Add(group);
            }
            //navBarMain.NavigationPaneMaxVisibleGroups = 6; //set show max.
            LastMouseClicked = DateTime.Now;


        }
        private  void navBarMain_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraNavBar.NavBarControl nav = (DevExpress.XtraNavBar.NavBarControl)sender;
            if (nav == null) return;
            if (nav.ActiveGroup == null) return;
            if (nav.PressedLink == null) return;

            createChildForm(nav.PressedLink.ItemName, (DataRow)nav.PressedLink.Item.Tag);
            myDefaultLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue");
        }
        private void navBarMain_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //DateTime dtN = DateTime.Now;
            //double milGap = (dtN - LastMouseClicked).TotalMilliseconds;
            //LastMouseClicked = DateTime.Now;
            //MessageBox.Show(milGap.ToString());
            //if (milGap > 1000) return;

            //DevExpress.XtraNavBar.NavBarControl nav = (DevExpress.XtraNavBar.NavBarControl)sender;
            //if (nav == null) return;
            //if (nav.ActiveGroup == null) return;
            //if (nav.PressedLink == null) return;

            //createChildForm(nav.PressedLink.ItemName, (DataRow)nav.PressedLink.Item.Tag);
            //myDefaultLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue");
        }
        private void navBarMain_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (navBarMain.OptionsNavPane.NavPaneState == DevExpress.XtraNavBar.NavPaneState.Expanded)
                return;

            DateTime dtN = DateTime.Now;
            double milGap = (dtN - LastMouseClicked).TotalMilliseconds;
            LastMouseClicked = DateTime.Now;
            //MessageBox.Show(milGap.ToString());
            if (milGap > 2000) return;

            DevExpress.XtraNavBar.NavBarControl nav = (DevExpress.XtraNavBar.NavBarControl)sender;
            if (nav == null) return;
            if (nav.ActiveGroup == null) return;
            if (nav.PressedLink == null) return;

            createChildForm(nav.PressedLink.ItemName, (DataRow)nav.PressedLink.Item.Tag);
            myDefaultLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue");
        } 

        private  void loadLanguage()
        {
            EnvisionDataContext db = new EnvisionDataContext();
            IQueryable<GBL_LANGUAGE> langs = from g in db.GBL_LANGUAGEs select g;
            IList<GBL_LANGUAGE> gl = (from l in langs where l.IS_ACTIVE == 'Y' select l).ToList();
            langList = gl.ToList();
            currentLang = new GBL_LANGUAGE();
            currentLang.LANG_ID = env.CurrentLanguageID;
        }
        private  void setLanguage()
        {
            cmbLanguage.Items.Clear();
            env.OrgID = 1;
            if (langList != null)
            {
                foreach (GBL_LANGUAGE l in langList)
                {
                    cmbLanguage.Items.Add(l.LANG_NAME);
                    if (l.LANG_ID == currentLang.LANG_ID)
                        currentLang = l;
                }
            }
            for (int i = 0; i < cmbLanguage.Items.Count; i++)
            {
                if (cmbLanguage.Items[i].ToString() == currentLang.LANG_NAME)
                {
                    cmbLanguage.SelectedIndex = i;
                    refreshControlByLanguage();
                    break;
                }
            }
        }
        private  void refreshControlByLanguage()
        {
           
        }
        private  void changeLanguage()
        {
            string langName = cmbLanguage.Text;
            foreach (GBL_LANGUAGE lng in langList)
                if (lng.LANG_NAME == langName)
                {
                    currentLang = lng;
                    env.LangName = currentLang.LANG_NAME;
                    env.CurrentLanguageID = currentLang.LANG_ID;
                    break;
                }
            refreshControlByLanguage();
        }
        private  void setUserInformation() 
        {

            lblHosName.Text = env.OrgaizationName;
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblUserName.Text = env.FirstName + " " + env.LastName;
        }

        private void initializeControl() {
            initializeNavigatorBar();
            loadLanguage();
            setLanguage();
            setUserInformation();
            initializeRadiologistBar();
            lblVersion.Text = string.Empty;
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) 
            {
                System.Deployment.Application.ApplicationDeployment ad =System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                lblVersion.Text = "(version " + ad.CurrentVersion.ToString() + ")";
            }
        }
        private void initBackgroudWorker() {
            initPortSocket();
            bgPort.RunWorkerAsync("RIS");
        }
        #endregion

        #region Initialize Home.
        private void initializeHomeForm() {
            if (rowHome == null) return;
            frmHome form = new frmHome();
            form.MdiParent = this;
            form.Menu_ID = Convert.ToInt32(rowHome["MENU_ID"].ToString());
            form.Submenu_ID = Convert.ToInt32(rowHome["SUBMENU_ID"].ToString());
            form.Role_ID = Convert.ToInt32(rowHome["ROLE_ID"].ToString());
            form.Menu_Name_Class = rowHome["SUBMENU_CLASS_NAME"].ToString();
            form.Menu_Name_User = rowHome["SUBMENU_NAME_USER"].ToString();
            form.Menu_Namespace = rowHome["MENU_NAMESPACE"].ToString();
            form.Menu_FullNamespace = form.Menu_Namespace + "." + form.Menu_Name_Class;
            form.Text = form.Menu_Name_User;
            form.Show();
            mdiMain.Pages[0].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
        }
        #endregion

        public void UpdateHospitalName() {
            lblHosName.Text = new GBLEnvVariable().OrgaizationName;
        }
        public void UpdateUserName() {
            GBLEnvVariable env = new GBLEnvVariable();
            lblUserName.Text = env.FirstName + " " + env.LastName;
            loadLanguage();
            setLanguage();
        }
        public void UpdateMenu() {
            navBarMain.Items.Clear();
            navBarMain.Groups.Clear();
            navBarMain.Update();


            initializeNavigatorBar();
            loadLanguage();
            setLanguage();
            setUserInformation();
            initializeRadiologistBar();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.Show();
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
                this.Show(); 
        }

        private void barNotePad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }
        private void barCalculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void barMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tmMsg.Stop();
            frmMessageManagement frm = new frmMessageManagement();
            frm.ShowDialog();
            frm.Dispose();
            DataTable dtt = getMessage();
            no_ofMSG = 0;
            if (dtt.Rows[0][0].ToString() != "0")
                no_ofMSG = Convert.ToInt32(dtt.Rows[0][0].ToString());
            tmMsg.Start();
        }
        private void toolBarImg_Click(object sender, EventArgs e)
        {
            tmMsg.Stop();
            frmMessageManagement frm = new frmMessageManagement();
            frm.ShowDialog();
            frm.Dispose();
            DataTable dtt = getMessage();
            no_ofMSG = 0;
            if (dtt.Rows[0][0].ToString() != "0")
                no_ofMSG = Convert.ToInt32(dtt.Rows[0][0].ToString());
            tmMsg.Start();
        }

        private void tmMsg_Tick(object sender, EventArgs e)
        {
            tmMsg.Stop();

            try
            {
                DataTable dtt = getMessage();
                if (dtt.Rows[0][0].ToString() != "0")
                {
                    int msg = Convert.ToInt32(dtt.Rows[0][0].ToString());
                    if (msg > no_ofMSG)
                    {
                        string txt = msg == 1 ? "1 Message." : msg.ToString() + " Messages.";
                        DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo(txt, "                                          ");
                        alertMsg.Show(this, info);
                        no_ofMSG = msg;

                    }

                    toolBarImg.Image = Envision.NET.Properties.Resources.gmail_icon128_NewMessage;
                    barMessage.ImageIndex = 15;
                }
                else
                {
                    toolBarImg.Image = Envision.NET.Properties.Resources.gmail_icon128;
                    barMessage.ImageIndex = 14;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tmMsg.Start();
        }
        private DataTable getMessage()
        {
            ProcessGetGBLMessageRecipient proc = new ProcessGetGBLMessageRecipient();
            proc.Columns.SP_TYPE = 2;
            proc.Columns.CC_TO = env.UserID;
            DataTable dtt = proc.GetMessage();
            return dtt;
        }


        private void alertMsg_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            Envision.NET.Forms.InternalMessage.frmMessageManagement frm = new frmMessageManagement();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void barComments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Comment.frmComment frm = null;
            frm = new Envision.NET.Forms.Comment.frmComment();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barMyDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMyDocument();
        }
        private void OpenMyDocument()
        {
            ShowWaitDialog();

            string ip1 = "sfxray"; //"10.6.4.181"; "192.168.5.181";
            string user_name = env.UserName;//@"radiology\jfps028";
            string pass_word = env.PasswordAD;//"20758213";
            string folder_name = env.UserName;//"jfps028";
            string folderPath = @"";
            string drive_letter = "r";

            folderPath = @"\\" + ip1 + @"\" + folder_name;

            string startCommand = @"net use " + drive_letter + ": " + folderPath + " " + pass_word + @" /user:ramapacs.rama.mahidol.ac.th\" + user_name + @" /persistent:no";

            if (!Directory.Exists(drive_letter + @":\"))
            {
                ExecuteCommandSync(@"net use " + drive_letter + ": /d /y");
                ExecuteCommandSync(startCommand);

                int i = 1;
                int ival = 100;
                while (!Directory.Exists(drive_letter + @":\"))
                {
                    Thread.Sleep(ival);
                    if ((i * ival) > 10000)
                        break;
                    i++;
                }

                ExecuteCommandSync(@"explorer " + drive_letter + @":\");
            }
            else
                ExecuteCommandSync(@"explorer " + drive_letter + @":\");

            CloseWaitDialog();
        }
        public void ExecuteCommandSync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, exe.Source);
            }
        }

        #region Waiting Dialog Windows
        private DevExpress.Utils.WaitDialogForm dlg;
        public void ShowWaitDialog()
        {
            Size s = new Size(250, 50);
            dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Open Share Folder", s);
        }
        public void CloseWaitDialog()
        {
            if (dlg != null) dlg.Close();
        }
        #endregion

        private void alertNewComment()
        {
            dataComments = new DataTable();
            dsComments = new DataSet();
            ProcessGetRISCommentAlert procCommentAlert = new ProcessGetRISCommentAlert();
            procCommentAlert.RIS_COMMENTSYSTEMALERT.READER_ID = env.UserID;
            dsComments = procCommentAlert.GetAlertMessage();
            for (int i = 0; i < dsComments.Tables.Count; i++)
                dataComments.Merge(dsComments.Tables[i].Copy());

            if (dataComments.Rows.Count > 0)
            {
                bool alert = true;
                //if (dataComments.Rows.Count == 1)
                //{
                //    frmMessageConversation frm = new frmMessageConversation();
                //    switch (frm.pageMode)
                //    {
                //        case PagesModes.Order:
                //            if (dsComments.Tables[0].Rows[0]["ACCESSION_NO"].ToString() == frm.objectCurrent.ToString())
                //                alert = false;
                //            break;
                //        case PagesModes.Schedule:
                //            if (dsComments.Tables[0].Rows[0]["SCHEDULE_ID"].ToString() == frm.objectCurrent.ToString())
                //                alert = false;
                //            break;
                //        case PagesModes.XrayReq:
                //            if (dsComments.Tables[0].Rows[0]["XRAYREQ_ID"].ToString() == frm.objectCurrent.ToString())
                //                alert = false;
                //            break;
                //    }
                //}
                if (alert)
                {
                    string noOfAlert = string.Empty;
                    noOfAlert = "You have New Message.";
                    DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo(noOfAlert, "");
                    alertComment.Show(this, info); 
                }
            }
        }
        private void alertComment_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            if (dataComments.Rows.Count == 1)
            {
                if (dsComments.Tables[0].Rows.Count > 0) {
                    frmMessageConversation frm = new frmMessageConversation(dsComments.Tables[0].Rows[0]["ACCESSION_NO"].ToString());
                    frm.ShowDialog();
                }
                else if(dsComments.Tables[1].Rows.Count>0)
                {
                    frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(dsComments.Tables[1].Rows[0]["SCHEDULE_ID"].ToString()));
                    frm.ShowDialog();
                }
                else if (dsComments.Tables[2].Rows.Count > 0)
                {
                    frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(dsComments.Tables[2].Rows[0]["XRAYREQ_ID"].ToString()),true);
                    frm.ShowDialog();
                }
            }
            else
            {
                Envision.NET.Forms.Dialog.LookupAlertComment frm = new LookupAlertComment();
                frm.ShowDialog();
                frm.Dispose();
            }
            alertNewComment();
        }
        private void alertComment_FormClosing(object sender, AlertFormClosingEventArgs e)
        {
            if (dataComments.Rows.Count > 0)
            {
                if (e.CloseReason == AlertFormCloseReason.TimeUp)
                {
                    e.Cancel = true;
                    System.Media.SystemSounds.Beep.Play();

                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void barHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessGetGBLSubMenu process = new ProcessGetGBLSubMenu();
            DataTable dtt = process.GetDataAdminRole();

            for (int i = 0; i < mdiMain.Pages.Count; i++)
            {
                Envision.NET.Forms.Main.MasterForm mas = (Envision.NET.Forms.Main.MasterForm)mdiMain.Pages[i].MdiChild;
                if (mdiMain.SelectedPage.Text == mas.Menu_Name_User.ToString())
                {
                    DataRow[] rows = dtt.Select("SUBMENU_ID=" + mas.Submenu_ID.ToString());
                    if (rows.Length > 0)
                    {
                        string url = "http://miracle99/EnvisionInformation/Default.aspx?submenu=" + rows[0]["SUBMENU_ID"].ToString();
                        Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                        Browser.Text = "Help";
                        Browser.StartPosition = FormStartPosition.CenterScreen;
                        Browser.ShowDialog();
                        return;
                    }
                }
            }
        }

        private void barCareLink_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome","https://care.rama.mahidol.ac.th/");
        }
    }
}
