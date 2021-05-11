using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Principal;
using System.Threading;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

using Miracle.Util;
using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Miracle.OSDetail;

namespace Envision.NET
{
    public partial class Login : Form
    {

        private List<GBL_LANGUAGE> langList;
        private GBL_LANGUAGE currentLang;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private Splash sp;
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
#if DEBUG
            this.TopMost = false;
#endif


            myLookAndFeel.LookAndFeel.SetSkinStyle("Office 2007 Blue"); //Set Office Skin

            #region Deploy session.
            updateVersion();
            //createShortCut(); 
            #endregion

            #region Splash Screen 2 Second.
            Thread th = new Thread(new ThreadStart(doSplash));
            th.Start();
            initializeControl();
            Thread.Sleep(4000);

            th.Abort();
            Thread.Sleep(2000);
            #endregion
        }


        private void loadLanguage()
        {
            EnvisionDataContext db = new EnvisionDataContext();
            IQueryable<GBL_LANGUAGE> langs = from g in db.GBL_LANGUAGEs select g;
            IList<GBL_LANGUAGE> gl = (from l in langs where l.IS_ACTIVE == 'Y' select l).ToList();
            langList = gl.ToList();
        }
        private void setLanguage()
        {
            cmbLanguage.Items.Clear();
            env = new GBLEnvVariable();
            env.OrgID = 1;
            GBL_LANGUAGE lang = new GBL_LANGUAGE();
            if (langList != null)
            {
                foreach (GBL_LANGUAGE l in langList)
                {
                    cmbLanguage.Items.Add(l.LANG_NAME);
                    if (l.IS_DEFAULT == 'Y')
                    {
                        lang = l;
                        env.LangName = l.LANG_NAME;
                        env.LangName = env.LangName;
                        env.CurrentLanguageID = l.LANG_ID;
                        currentLang = new GBL_LANGUAGE();
                        currentLang = l;
                    }
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
        private void refreshControlByLanguage()
        {
            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;// 124; 
            fl.LanguageID = currentLang.LANG_ID;
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
                        //   lblLanguage.Text = dt.Rows[k]["LABEL"].ToString().Trim();
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
            catch (Exception EX)
            {
                throw EX;
            }
        }
        private void changeLanguage()
        {
            string langName = cmbLanguage.Text;
            foreach (GBL_LANGUAGE lng in langList)
                if (lng.LANG_NAME == langName)
                {
                    currentLang = lng;
                    break;
                }
            refreshControlByLanguage();
        }

        private void doSplash()
        {

            sp = new Splash();
            Application.Run(sp);
        }
        private void initializeControl()
        {
            msg = new MyMessageBox();
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbAuth.SelectedIndex = 0;
            txtUser.Focus();
        }
        private void setVersion()
        {
            env = new GBLEnvVariable();

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
                    process.GBL_PRODUCT.PROD_ID = 1;
                    process.GBL_PRODUCT.PROD_VERSION = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    process.Invoke();
                    lblVersion.Text = process.GBL_PRODUCT.PROD_VERSION;
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

                env.EDIT_ORDER_UNTIL = dtenv.Rows[j]["EDIT_ORDER_UNTIL"].ToString().Trim();
                j++;
            }
        }

        #region Domain Authentication.
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

        public static DirectoryEntry GetDirectoryEntry(string username, string password)
        {
            string strServerName = "192.1.10.230";
            string strBaseDN = "DC=RADIOLOGY,DC=COM";
            string strUserDN = "OU=Service PACS";
            DirectoryEntry deSystem = new DirectoryEntry("LDAP://" + strServerName + "/" + strUserDN + "," + strBaseDN);
            deSystem.AuthenticationType = AuthenticationTypes.Secure;
            //deSystem.Username = "administrator";
            //deSystem.Password = "pacsKCMH@1";
            deSystem.Username = username;
            deSystem.Password = password;
            return deSystem;
        }
        public bool UserExists(string username, string password)
        {
            try
            {
                DirectoryEntry de = GetDirectoryEntry(username, password);
                DirectorySearcher deSearch = new DirectorySearcher();
                deSearch.SearchRoot = de;
                deSearch.Filter = "(&(objectClass=user) (cn=" + username + "))";
                SearchResultCollection results = deSearch.FindAll();
                de.Dispose();
                return results.Count > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Deploy Session.
        private void updateVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
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
                        process.GBL_PRODUCT.PROD_ID = 1;
                        process.GBL_PRODUCT.PROD_VERSION = ApplicationDeployment.CurrentDeployment.ToString();
                        process.Invoke();
                    }
                    deployment.Update();
                    Application.Restart();
                }
            }
        }
        private void createShortCut()
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
                //MessageBox.Show("TEST:" + company);
            }
            if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            {
                AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                description = asdescription.Description;
                //MessageBox.Show("TEST:" + description);
            }
            if (company != string.Empty && description != string.Empty)
            {
                string desktopPath = string.Empty;
                desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");
                string shortcutName = string.Empty;
                shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");
                System.IO.File.Copy(shortcutName, desktopPath, true);
            }
        }
        #endregion

        #region Remember Session.
        private string pwd = string.Empty;

        private void getRemember()
        {
            try
            {
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                try
                {

                    IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("Envision.NET\\config.env", FileMode.Open, iso);
                    StreamReader streamReader = new StreamReader(isolatedStorageFileStream);
                    string contents = streamReader.ReadToEnd();
                    pwd = contents;
                    streamReader.Dispose();
                    isolatedStorageFileStream.Dispose();
                    chkRem.Checked = true;
                }
                catch (Exception ex)
                {
                    pwd = string.Empty;
                }
                finally
                {
                    iso.Dispose();
                }
            }
            catch { }
        }
        private void addRemember()
        {
            try
            {
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                try
                {
                    string[] str = iso.GetFileNames("Envision.NET\\config.env");
                    if (str.Length > 0)
                        iso.DeleteFile("Envision.NET\\config.env");
                    str = iso.GetDirectoryNames("Envision.NET");
                    if (str.Length == 0) iso.CreateDirectory("Envision.NET");
                }
                catch (Exception eex)
                {
                    iso.CreateDirectory("Envision.NET");
                }


                IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("Envision.NET\\config.env", FileMode.Create, iso);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(txtPassword.Text.Trim());
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void deleteRemember()
        {
            try
            {
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                string[] str = iso.GetFileNames("Envision.NET\\config.env");
                if (str.Length > 0)
                    iso.DeleteFile("Envision.NET\\config.env");
                iso.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Killer Session.
        public void killSession(string ip)
        {
            Envision.WebService.EnvisionWebService kill = new Envision.WebService.EnvisionWebService(env.WebServiceIP, true);
            kill.SentClientSession(ip, "KillSession");
            //TcpClient tcpClient;
            //NetworkStream networkStream;
            //StreamReader streamReader;
            //StreamWriter streamWriter;
            //try
            //{
            //    tcpClient = new TcpClient(ip, 5555);
            //    networkStream = tcpClient.GetStream();
            //    streamReader = new StreamReader(networkStream);
            //    streamWriter = new StreamWriter(networkStream);
            //    streamWriter.WriteLine("Your session has been killed...");
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //    tcpClient.Close();
            //}
            //catch (SocketException ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            this.Activate();

            getRemember();
            loadLanguage();
            setLanguage();
            setVersion();
            cmbAuth.SelectedIndex = 0;
#if DEBUG
            //txtUser.Text = "dell";
            //txtPassword.Text = "dell";
#endif
            txtUser.Focus();


            #region Save App.Config
            //System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            //config.AppSettings.Settings["fadell"].Value = "cheteng";
            //config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            //System.Configuration.ConfigurationManager.RefreshSection("appSettings");   
            #endregion

        }

        private void cmbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string auth = cmbAuth.Text;
            if (auth.Equals("Windows Authentication"))
            {
                try
                {
                    ////===================WINDOWS AUTHENTICATION========================
                    //// Retrieve the Windows account token for the current user.
                    //IntPtr logonToken = LogonUser();
                    //// Constructor implementations.
                    //IntPtrConstructor(logonToken);
                    //IntPtrStringConstructor(logonToken);
                    //IntPtrStringTypeConstructor(logonToken);
                    //IntPrtStringTypeBoolConstructor(logonToken);
                    //// Property implementations.
                    //UseProperties(logonToken);
                    //// Method implementations.
                    //GetAnonymousUser();
                    //txtUser.Text = WindowsIdentity.GetCurrent().Name;
                    //ImpersonateIdentity(logonToken);
                    ////====================================================================
                    //txtPassword.Text = "";
                    //txtUser.Enabled = false;
                    //txtPassword.Enabled = false;
                    //chkRem.Enabled = false;
                    //chkRem.Checked = false;

                    txtUser.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    chkRem.Enabled = false;
                    chkRem.Checked = false;
                }
                catch (Exception ex)
                {

                }

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
            changeLanguage();
        }

        private void lnkChaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;

            PasswordForm pform = new PasswordForm(1, txtUser.Text);
            if (pform.show == true && pform.ShowDialog() == DialogResult.OK)
            {

            }
            pform.Dispose();

            this.Enabled = true;
        }
        private void lnkResPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;

            PasswordForm pform = new PasswordForm(2, txtUser.Text);
            if (pform.show == true && pform.ShowDialog() == DialogResult.OK)
            {

            }
            pform.Dispose();

            this.Enabled = true;

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string title = "Contact US";
            string text = "\r\nEmail    support@jf.co.th";
            text += "\r\nPhone  081-123-1236";
            DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo(title, text);
            info.Image = Envision.NET.Properties.Resources.logojf; //icon_help;
            showHelp.Show(this, info);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                #region Require Check.
                if (string.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    string id = msg.ShowAlert("UID001", new GBLEnvVariable().CurrentLanguageID);
                    txtUser.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtPassword.Text.Trim()) && (cmbAuth.Text == "RIS Authentication"))
                {

                    string id = msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
                    txtUser.Focus();
                    return;
                }
                #endregion

                EnvisionDataContext db = new EnvisionDataContext();

                IQueryable<HR_EMP> empListData = from emp in db.HR_EMPs select emp;
                IEnumerable<HR_EMP> hrData = null;
                HR_EMP userInfo = new HR_EMP();
                string ltype = string.Empty;

                #region Check UserName, Password, Authentication.
                if (cmbAuth.Text == "Windows Authentication")
                {
                    if (UserExists(txtUser.Text.Trim(), txtPassword.Text.Trim()))
                    {
                        ltype = "W";
                        IEnumerable<HR_EMP> empSelect = from emp in empListData where (emp.USER_NAME == txtUser.Text) && (emp.IS_ACTIVE == 'Y') select emp;
                        hrData = empSelect.ToList();
                        env.PasswordAD = txtPassword.Text.Trim();
                    }
                    else
                    {

                        string id = msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
                        txtUser.Focus();
                        return;
                    }
                }
                else
                {
                    if (Regex.IsMatch(txtPassword.Text.Trim(), "Envision", RegexOptions.IgnoreCase)) txtPassword.Text = "envision";
                    ltype = "D";
                    string pwd = Utilities.Encrypt(txtPassword.Text.Trim());
                    IEnumerable<HR_EMP> empSelect = from emp in empListData where (emp.USER_NAME == txtUser.Text) && (emp.PWD == pwd) && (emp.IS_ACTIVE == 'Y') select emp;
                    hrData = empSelect.ToList();
                }
                if (hrData == null || hrData.Count() == 0)
                {
                    string id = msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
                    txtUser.Focus();
                    return;
                }
                userInfo = hrData.Single();
                #endregion

                if (userInfo.IS_ACTIVE == 'Y')
                {

                    #region Check Reset Password Policy.
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
                    #endregion

                    ProcessCheckSession chksession = new ProcessCheckSession();
                    chksession.Invoke(userInfo.EMP_ID, 1);
                    DataTable dtcheck = chksession.ResultSet.Tables[0];
                    if (dtcheck.Rows.Count > 0)
                    {
                        #region Kill Session
                        string kil = msg.ShowAlert("UID0041", new GBLEnvVariable().CurrentLanguageID);
                        if (kil == "2")
                        {
                            string killip = dtcheck.Rows[0]["IP_ADDR_CURR"].ToString();
                            ProcessCheckSession killedsession = new ProcessCheckSession();
                            killedsession.Invoke(userInfo.EMP_ID, 3);
                            killSession(killip);
                        }
                        else
                            return;
                        #endregion
                    }

                    #region Create Session To Database.
                    #region Check OS Version
                    string _servicePack = "";
                    if (OSVersionInfo.ServicePack != string.Empty)
                        _servicePack = String.Format("Service Pack = {0}", OSVersionInfo.ServicePack);
                    else
                        _servicePack = "Service Pack = None";
                    string os_name = OSVersionInfo.Name + " " + OSVersionInfo.Edition + " " + _servicePack + " " + OSVersionInfo.OSBits + " ";
                    os_name += String.Format("Version = {0}", OSVersionInfo.VersionString);
                    #endregion

                    ProcessAddSession processsession = new ProcessAddSession();
                    GBL_SESSION gblsession = new GBL_SESSION();
                    GBLEnvVariable gbl = new GBLEnvVariable();
                    gbl.CurrentFormGUID = Utilities.GUID();
                    gblsession.SESSION_GUID = gbl.CurrentFormGUID;
                    gblsession.EMP_ID = userInfo.EMP_ID;
                    gblsession.ORG_ID = userInfo.ORG_ID;
                    gblsession.IP_ADDR_CURR = Utilities.IPAddress();
                    gblsession.LOGON_TYPE = Convert.ToChar(ltype);
                    gblsession.SESSION_STAT = 'A';
                    gblsession.PROD_VERSION = lblVersion.Text;
                    gblsession.OS_NAME = os_name;

                    gbl.UserID = userInfo.EMP_ID; ;
                    int uid = userInfo.UNIT_ID == null ? 1 : (int)userInfo.UNIT_ID;
                    gbl.UnitID = uid;
                    gbl.UserUID = userInfo.EMP_UID;
                    gbl.UserName = userInfo.USER_NAME;
                    gbl.TitleEng = userInfo.TITLE_ENG;
                    gbl.FirstNameEng = userInfo.FNAME_ENG;
                    gbl.LastNameEng = userInfo.LNAME_ENG;
                    gbl.AuthLevelID = userInfo.AUTH_LEVEL_ID.ToString();
                    processsession.GBL_SESSION = gblsession;
                    try
                    {
                        processsession.Invoke();
                    }
                    catch (Exception err)
                    {

                    }
                    #endregion

                    #region Store GBLEnv Info
                    IQueryable<GBL_ENV> envQuery = from g in db.GBL_ENVs select g;
                    GBL_ENV gEnv = (from g in envQuery where g.ORG_ID == userInfo.ORG_ID select g).Single();
                    GBLEnvVariable env = new GBLEnvVariable();
                    env.ActiveDate = DateTime.Today;
                    env.AuthLevelID = userInfo.AUTH_LEVEL_ID.ToString();

                    env.JobtitleID = userInfo.JOBTITLE_ID.HasValue ? Convert.ToInt32(userInfo.JOBTITLE_ID) : 0;

                    //env.BmpPic = IntPtr.Zero;
                    //env.BmpPic2 = IntPtr.Zero;
                    //env.BmpPic3 = IntPtr.Zero;
                    //env.PixPic = IntPtr.Zero;
                    //env.PixPic2 = IntPtr.Zero;
                    //env.PixPic3 = IntPtr.Zero;
                    //env.CountImg = string.Empty;
                    env.PixPicture = Miracle.Scanner.PointerStruct.GetPointerStruct();

                    env.CurrentLanguageID = currentLang.LANG_ID;
                    env.LangName = currentLang.LANG_NAME;

                    env.FirstName = userInfo.FNAME;
                    env.FirstNameEng = userInfo.FNAME_ENG;
                    env.LastName = userInfo.LNAME;
                    env.LastNameEng = userInfo.LNAME_ENG;
                    env.LoginType = ltype;
                    env.OrgID = userInfo.ORG_ID.GetValueOrDefault();
                    env.ScannedImagePath = gEnv.SCANNED_IMAGE_PATH;
                    env.TemplateID = 0;
                    env.TimeFormat = gEnv.TIME_FMT;
                    env.TitleEng = userInfo.TITLE_ENG;
                    env.UnitID = userInfo.UNIT_ID.GetValueOrDefault();
                    env.UserID = userInfo.EMP_ID;
                    env.UserName = userInfo.USER_NAME;
                    env.UserUID = userInfo.EMP_UID;
                    env.WebServiceIP = gEnv.WS_IP;
                    env.WebServiceIP_PICTURE = gEnv.WS_IP_PICTURE;
                    env.OrgaizationName = gEnv.ORG_NAME;
                    env.CurrencyFormat = gEnv.CURRENCY_FMT;
                    env.DateFormat = gEnv.DT_FMT;
                    env.FontName = gEnv.DEFAULT_FONT_FACE;
                    env.FontSize = gEnv.DEFAULT_FONT_SIZE.ToString();
                    env.PacsIp = gEnv.PACS_IP;
                    env.PacsPort = gEnv.PACS_PORT;
                    env.PacsUrl = gEnv.PACS_URL1;
                    env.PacsUrl2 = gEnv.PACS_URL2;
                    env.PacsUrl3 = gEnv.PACS_URL3;
                    env.CurrencyName = string.Empty;
                    env.CurrencySymbol = string.Empty;
                    env.CurrentFormGUID = gblsession.SESSION_GUID;
                    env.SUPPORT_USER = userInfo.SUPPORT_USER == null ? "N" : userInfo.SUPPORT_USER.ToString();
                    env.USED_120DPI = "N";
                    env.USED_MENUBAR = "N";
                    Miracle.Scanner.PointerStruct.ImageUrl = env.PacsUrl2;
                    if (userInfo.JOB_TYPE == 'D')
                    {
                        try
                        {
                            IQueryable<GBL_RADEXPERIENCE> radListData = from emp in db.GBL_RADEXPERIENCEs select emp;
                            GBL_RADEXPERIENCE radSelect = (from emp in radListData where emp.RADIOLOGIST_ID == env.UserID select emp).Single();
                            if (radSelect != null)
                            {
                                env.USED_MENUBAR = radSelect.USED_MENUBAR.ToString();
                                env.USED_120DPI = radSelect.USED_120DPI.ToString();
                                env.ReconfirmPassword = radSelect.RECONFIRM_PASS_ON_SAVE.ToString();
                            }
                        }
                        catch { }

                    }
                    env.PasswordAD = txtPassword.Text;
                    env.IsDent = false;
                    env.IsFellow = false;
                    ProcessGetHREmp procEmp = new ProcessGetHREmp();
                    procEmp.HR_EMP.EMP_ID = env.UserID;
                    procEmp.HR_EMP.ORG_ID = env.OrgID;
                    DataTable dtt = procEmp.GetEmployee();
                    if (Miracle.Util.Utilities.IsHaveData(dtt))
                    {
                        if (dtt.Rows[0]["IS_RESIDENT"].ToString() == "Y") env.IsDent = true;
                        if (dtt.Rows[0]["IS_FELLOW"].ToString() == "Y") env.IsFellow = true;
                    }
                    #endregion

                    #region SetMaster Form.
                    Envision.NET.Forms.Main.MasterForm.CurrencyFormat = env.CurrencyFormat;
                    Envision.NET.Forms.Main.MasterForm.CurrencyName = env.CurrencyName;
                    Envision.NET.Forms.Main.MasterForm.CurrencySymbol = env.CurrencySymbol;
                    Envision.NET.Forms.Main.MasterForm.DateTimeFormat = env.DateFormat;
                    Envision.NET.Forms.Main.MasterForm.DefaultFontName = env.FontName;
                    Envision.NET.Forms.Main.MasterForm.DefaultFontSize = env.FontSize;
                    Envision.NET.Forms.Main.MasterForm.DefaultSkinName = "Office 2007 Blue";
                    Envision.NET.Forms.Main.MasterForm.TimeFormat = env.TimeFormat;
                    #endregion

                    if (chkRem.Checked)
                        addRemember();
                    else
                        deleteRemember();

                    this.Hide();
                    Envision.NET.Forms.Main.frmMain main = new Envision.NET.Forms.Main.frmMain();
                    main.Show();
                }
                else
                {
                    msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
                    return;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                MessageBox.Show("Form not created, please contact support.", "Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) == false)
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                    txtPassword.Text = pwd;
            }
        }
    }
}
