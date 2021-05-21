using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SynapseSearchByHN.Common;
using System.IO;
using System.Runtime.InteropServices;

namespace SynapseSearchByHN
{
    public partial class frmLogin : Form
    {
        private XMLClass xml;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            xml = new XMLClass();

            try
            {
                string DirectoryName = Path.GetDirectoryName(xml.XmlPath);
                if (!Directory.Exists(DirectoryName))
                    Directory.CreateDirectory(DirectoryName);

                if (!File.Exists(xml.XmlPath))
                    OpenSettingForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            AppDomain.CurrentDomain.AssemblyResolve
                += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            WindowStartPosition();
        }
        private void OpenSettingForm()
        {
            frmAppConfig frmSet = new frmAppConfig();
            frmSet.ShowDialog();
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                checkUser();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                checkUser();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            checkUser();
        }
        private void checkUser()
        {

            lblAlert.Visible = false;
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                lblAlert.Visible = true;
                lblAlert.Text = "Please input Username!!";
                txtUsername.Select();
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                lblAlert.Visible = true;
                lblAlert.Text = "Please input Password!!";
                txtPassword.Select();
                return;
            }
            else
            {
                xml = new XMLClass();
                xml.LoadData();
                bool flag = false;
                switch (xml.LoginMode)
                {
                    case "Not Login": break;
                    case "Windows Authen": 
                        flag = CommonDetails.IsWindowsAuthen(xml.EnvisionWebservice,txtUsername.Text.ToLower().Trim());
                        break;
                    case "Domain Authen": 
                        flag = CommonDetails.IsAuthenticated(xml.IPDomain, xml.SynapseDomain, txtUsername.Text.ToLower().Trim(), txtPassword.Text.Trim());
                        break;
                    case "HIS Authen":
                        flag = CommonDetails.IsHISAuthen(xml.EnvisionWebservice, txtUsername.Text.ToLower().Trim(),txtPassword.Text.Trim());
                        break;
                }

                if (!flag)
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = "Username or Password not match!!!";
                    return;
                }
                else
                {
                    Common.CommonDetails.pacsUser = txtUsername.Text.Trim();
                    Common.CommonDetails.pacsPassword = txtPassword.Text.Trim();
                    frmMain frm = new frmMain();
                    frm.Show();

                    this.Hide();
                }
            }
        }

        private void WindowStartPosition()
        {
            Size prmSize = SystemInformation.PrimaryMonitorSize;

            int ScrW = prmSize.Width;
            int ScrH = prmSize.Height;

            //205, 147

            int LoW = (ScrW - 10) - this.Size.Width;
            int LoH = (ScrH - 50) - this.Size.Height;

            this.Location = new Point(LoW, LoH);
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

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            xml = new XMLClass();
            xml.LoadData();
            CommonDetails.openManual(xml.SynapseManualPath);
        }

    }
}
