using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Deployment.Application;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using SynapseSearchByHN.Common;

namespace SynapseSearchByHN
{
    public partial class frmMain : Form
    {
        private XMLClass xml;
        public frmMain()
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

            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve
                += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        private void frmSynapseSearchByHN_Load(object sender, EventArgs e)
        {
            xml.LoadData();
            RegistryKeySetting();
            ReloadSettingFile();

            //WindowSizeChange();
            //WindowStartPosition();
            setControls();
            ControlStartPosition();

            txtHN.Focus();
        }
        private void setControls()
        {
            DataSet ds = xml.ConfigData;
            cmbHos.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cmbHos.Items.Add(ds.Tables[0].Rows[i]["HospitalName"].ToString());

            cmbHos.SelectedIndex = 0;

            if (ds.Tables[0].Rows.Count <= 1)
                cmbHos.Enabled = false;
        }
        private void frmSynapseSearchByHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                OpenSynapseLink();
        }
        private void frmSynapseSearchByHN_Activated(object sender, EventArgs e)
        {
            txtHN.Focus();
        }
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
                if (xml.HNValue != 0 && txtHN.Text.Trim().Length >= xml.HNValue)
                    e.Handled = true;
        }

        private void LoadSettingFileData()
        {
            xml.LoadData();

        }
        private void LoadSettingFileFilter()
        {

        }
        private void LoadSettingFileControl()
        {
            imgLogo.Image = xml.HospitalLogo;

            this.Text = xml.HospitalName;
            //txtHospitalName.TextAlign = xml.HospitalAlign;

            txtHN.TextAlign = xml.HNAlign;

            txtSuggestion.Text = xml.SuggestionText;
            txtSuggestion.TextAlign = xml.SuggestionAlign;

            txtFooter.Text = xml.FooterText;
            txtFooter.TextAlign = xml.FooterAlign;

            linkURL.Text = xml.UrlText;

            //Font Setting
            Font fnHos = this.Font;
            this.Font = new Font(fnHos.FontFamily, xml.HospitalFontSize, fnHos.Style, fnHos.Unit, fnHos.GdiCharSet);

            Font fnHN = txtHN.Font;
            txtHN.Font = new Font(fnHN.FontFamily, xml.HNFontSize, fnHN.Style, fnHN.Unit, fnHN.GdiCharSet);

            Font fnSuggest = txtSuggestion.Font;
            txtSuggestion.Font = new Font(fnSuggest.FontFamily, xml.SuggestionFontSize, fnSuggest.Style, fnSuggest.Unit, fnSuggest.GdiCharSet);

            //Font fnFoot = txtFooter.Font;
            //txtFooter.Font = new Font(fnFoot.FontFamily, xml.FooterFontSize, fnFoot.Style, fnFoot.Unit, fnFoot.GdiCharSet);

            //Miscellaneous Setting
            this.TopMost = xml.AlwaysOnTop == "Yes" ? true : false;
            txtHN.CharacterCasing = xml.HNAllUpper == "Yes" ? CharacterCasing.Upper : CharacterCasing.Normal;

        }
        private void ReloadSettingFile()
        {
            //LoadSettingFileData();
            if (xml.IsComplete)
            {
                LoadSettingFileFilter();
                LoadSettingFileControl();
            }
        }

        private void OpenSynapseLink()
        {
            if (txtHN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Invalid config file path, please contact support.");
                return;
            }
            try
            {
                if (!CommonDetails.checkImagesFromPACS(xml.EnvisionWebservice, txtHN.Text.Trim()))
                {
                    MessageBox.Show("ไม่มีภาพในระบบ PACS กรุณาตรวจสอบ HN หรือประวัติการตรวจของผู้ป่วย");
                    txtHN.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {

            }

            BeforeOpenSynapseLink();

            string link = xml.SynapseURL + "[HN]"+xml.DisableStatus;

            bool foundIE = false;

            xml.setSynapseURL(false);
            object url = link.Replace("[HN]", txtHN.Text.Trim());

            if (xml.IsReplaceURL)
            {
                //Find IE is still open in PACS.
                foreach (SHDocVw.InternetExplorer ie in new SHDocVw.ShellWindows())
                {
                    if (ie.LocationURL.ToString().ToLower().Contains(string.Format("http://{0}", xml.SynapseServer)))
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
            }
            else
            {
                //Use full path for open IE x64
                string file_name = Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Internet Explorer\\iexplore.exe";
                Process.Start(File.Exists(file_name) ? file_name : "iexplore", url.ToString());
            }
            txtHN.Text = "";
        }
        private static readonly List<string> Symbol = new List<string> { 
            "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", 
            "{", "}", "[", "]", @"\", "|",
            ";", ":", "'", "\"",
            "<", ">", ",", ".", "/", "?" };

        private void BeforeOpenSynapseLink()
        {
            #region filter special symbol without hn
            if (xml.HNFreeText.ToString() == "No")
                foreach (string strsym in Symbol.ToArray())
                    txtHN.Text = txtHN.Text.Replace(strsym, "");
            #endregion

            if (xml.HNValue > txtHN.Text.Trim().Length)
                if (xml.HNType.Trim().Length != 0)
                    while (xml.HNValue > txtHN.Text.Trim().Length)
                        txtHN.Text = xml.HNType.Trim() + txtHN.Text;

            if (xml.HNSymbolStartFrom == "R")
            {
                if (xml.HNSymbolText.Trim().Length > 0)
                {
                    int HNSymPos = txtHN.Text.Trim().Length - xml.HNSymbolPosition;

                    //int idxSym = txtHN.Text.IndexOf(xml.HNSymbolText.Trim());
                    //if (idxSym == HNSymPos)
                    //    txtHN.Text = txtHN.Text.Remove(idxSym, 1);

                    if (xml.HNSymbolPosition <= txtHN.Text.Trim().Length)
                    {
                        txtHN.Text = txtHN.Text.Insert(HNSymPos, xml.HNSymbolText.Trim());
                    }
                    else
                        txtHN.Text = xml.HNSymbolText + txtHN.Text;
                }
            }
            else
            {
                if (xml.HNSymbolText.Trim().Length > 0)
                {
                    int idxSym = txtHN.Text.IndexOf(xml.HNSymbolText.Trim());
                    if (idxSym == xml.HNSymbolPosition)
                        txtHN.Text = txtHN.Text.Remove(idxSym, 1);

                    if (xml.HNSymbolPosition <= txtHN.Text.Trim().Length)
                        txtHN.Text = txtHN.Text.Insert(xml.HNSymbolPosition, xml.HNSymbolText.Trim());
                    else
                        txtHN.Text += xml.HNSymbolText;
                }
            }

            if(xml.SymbolData != null)
                foreach (DataRow rowSymbol in xml.SymbolData.Rows)
                    txtHN.Text = txtHN.Text.Replace(rowSymbol["Symbol"].ToString(), rowSymbol["Unicode"].ToString());
            
        }

        private void OpenSettingForm()
        {
            frmAppConfig frmSet = new frmAppConfig();
            frmSet.ShowDialog();
        }
        private void RegistryKeySetting()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser;
                reg = reg.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
                reg.SetValue("AllowWindowReuse ", 1, RegistryValueKind.DWord);
                reg.Flush();
            }
            catch { }
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
        private void WindowSizeChange()
        {
            int DifLength = this.Size.Width - 260;

            int widthHN = txtHN.Size.Width + DifLength;
            SizeF sizeHN = new SizeF((float)widthHN, txtHN.Size.Height);
            txtHN.Size = sizeHN.ToSize();

            int widthSugg = txtSuggestion.Size.Width + DifLength;
            SizeF sizeSugg = new SizeF((float)widthSugg, txtHN.Size.Height);
            txtSuggestion.Size = sizeSugg.ToSize();

            //int widthFoot = txtFooter.Size.Width + DifLength;
            //SizeF sizeFoot = new SizeF((float)widthFoot, txtHN.Size.Height);
            //txtFooter.Size = sizeFoot.ToSize();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            int oldThm = 50;
            int newThm = 90;
            int currThm = 0;

            System.OperatingSystem osInfo = System.Environment.OSVersion;
            currThm = osInfo.Version.Major > 5 ? newThm : oldThm;

            //string thm = GetThemeName();
            //if (thm.ToLower() == "aero.theme"
            //    || thm.ToLower() == "architecture.theme"
            //    || thm.ToLower() == "characters.theme"
            //    || thm.ToLower() == "landscapes.theme"
            //    || thm.ToLower() == "nature.theme"
            //    || thm.ToLower() == "scenes.theme"
            //    )
            //{
            //    currThm = newThm;
            //}
            //else
            //    currThm = oldThm;

            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(Text, Font);

                int newWidthSize = (int)Math.Ceiling(size.Width) + currThm;
                if (newWidthSize > this.Size.Width)
                    Width = newWidthSize;
            }
            base.OnTextChanged(e);

            WindowStartPosition();
            WindowSizeChange();
        }
        private void ControlStartPosition()
        {
            int heightHN = txtHN.Size.Height;
            int startHN = txtHN.Location.Y;

            int newLoSug = heightHN + startHN;
            txtSuggestion.Location = new Point(txtSuggestion.Location.X, newLoSug);
        }
        public string GetThemeName()
        {
            string RegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes";
            string theme;
            theme = (string)Registry.GetValue(RegistryKey, "CurrentTheme", string.Empty);
            theme = Path.GetFileName(theme);
            return theme;
        }
        private void txtHN_TextChanged(object sender, EventArgs e)
        {
            if (xml.HNCharacterBoundary == null || xml.HNCharacterBoundary.Length == 0) return;

            List<char> charRemove = new List<char>();
            foreach (char ch in txtHN.Text.ToLower().ToCharArray())
            {
                int idx = 0;
                idx = xml.HNCharacterBoundary.IndexOf(ch);
                if (idx < 0)
                    charRemove.Add(ch);
            }

            int lastIndex = txtHN.SelectionStart;
            foreach (char chRm in charRemove)
                txtHN.Text = txtHN.Text.Replace(chRm.ToString(), "");

            if (charRemove.Count > 0)
                txtHN.SelectionStart = lastIndex < 1 ? 0 : lastIndex - 1;
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void imgLogo_DoubleClick(object sender, EventArgs e)
        {
            CommonDetails.openManual(xml.SynapseManualPath);
        }

        private void linkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Use full path for open IE x64
            string file_name = Path.GetPathRoot(Environment.SystemDirectory) + "Program Files\\Internet Explorer\\iexplore.exe";
            Process.Start(File.Exists(file_name) ? file_name : "iexplore", xml.UrlLink);
        }

        private void cmbHos_SelectedIndexChanged(object sender, EventArgs e)
        {
            xml.BindingData(cmbHos.SelectedIndex);
            ReloadSettingFile();
        }

    }
}
