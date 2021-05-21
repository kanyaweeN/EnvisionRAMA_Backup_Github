using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace SynapseSearchByHN
{
    public partial class frmAppConfig : Form
    {
        XMLClass xml;
        DataTable dtSymbol;

        public frmAppConfig()
        {
            InitializeComponent();
        }
        private void frmAppConfig_Load(object sender, EventArgs e)
        {
            xml = new XMLClass();
            cmbLogin.SelectedIndex = 0;
            cmbIsReplaceURL.SelectedIndex = 0;
            cmbFreeText.SelectedIndex = 0;
            cmbHNUpper.SelectedIndex = 0;
            setSymbolData();
        }
        private void setSymbolData()
        {
            dtSymbol = new DataTable();
            DataSet dsSymbol = new DataSet();

            if (File.Exists(xml.XmlSymbolPath))
            {
                dsSymbol.ReadXml(xml.XmlSymbolPath);
                dtSymbol = dsSymbol.Tables[0];
            }
            else
            {
                dtSymbol = xml.LoadSchemaSymbol().Tables[0];
            }

            grdSymbol.DataSource = dtSymbol;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openDlg.Filter = 
                @"Image File|*.png;*.jpg;*.bmp" ;
            openDlg.FilterIndex = 1;
            openDlg.RestoreDirectory = true;

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openDlg.FileName);
                imgLogo.Image = ResizeImage(img, 60, 60);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(xml.XmlPath))
                addData();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void txtContentAlignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;

            foreach (object strItem in cbb.Items)
            { 
                char startWith = strItem.ToString().ToLower()[0];
                char keyChar = e.KeyChar.ToString().ToLower()[0];
                if (keyChar == startWith)
                {
                    cbb.SelectedItem = strItem;
                    break;
                }
            }

            e.Handled = true;
        }

        private Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }
        private void btnBrown_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog flg = new FolderBrowserDialog();
            flg.ShowNewFolderButton = true;
            if (flg.ShowDialog() == DialogResult.OK)
                txtManualPath.Text = flg.SelectedPath;
            flg.Dispose();
        }
        private void cmbLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (cmbLogin.SelectedItem.ToString())
            {
                case "Not Login":
                    txtDomain.Enabled = false;
                    txtIPDm.Enabled = false;
                    chkLinkAuthen.Checked = false;
                    chkLinkAuthen.Enabled = false;
                    break;
                case "Windows Authen":
                    txtDomain.Enabled = false;
                    txtIPDm.Enabled = false;
                    chkLinkAuthen.Enabled = true;
                    break;
                case "Domain Authen":
                    txtDomain.Enabled = true;
                    txtIPDm.Enabled = true;
                    chkLinkAuthen.Enabled = true;
                    break;
                case "HIS Authen":
                    txtWebservice.Text = "http://miracle99/PatientService/Service.asmx";
                    break;
            }
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            addData();
        }
        private void addData()
        {
            xml.SynapseDomain = txtDomain.Text.Trim();
            xml.IPDomain = txtIPDm.Text.Trim();
            xml.LinkSynapse = txtLinkSynapse.Text.Trim();
            xml.SynapseServer = txtServer.Text.Trim();
            xml.SynapseManualPath = txtManualPath.Text.Trim();
            xml.EnvisionWebservice = txtWebservice.Text.Trim();
            xml.LoginMode = cmbLogin.SelectedItem.ToString();
            xml.IsLinkAuthen = chkLinkAuthen.Checked;
            xml.UrlText = txtUrl.Text;
            xml.UrlLink = txtUrlLink.Text;
            xml.IsReplaceURL = cmbIsReplaceURL.SelectedIndex == 0 ? true : false;

            xml.HospitalLogo = imgLogo.Image;
            xml.HospitalName = txtHospitalName.Text;
            xml.HospitalAlign = txtHospitalAlign.Text == "Center" ? ContentAlignment.MiddleCenter
                : txtHospitalAlign.Text == "Left" ? ContentAlignment.MiddleLeft
                : txtHospitalAlign.Text == "Right" ? ContentAlignment.MiddleRight : ContentAlignment.MiddleCenter;
            xml.HospitalFontSize = Convert.ToSingle(txtHospitalFontSize.Value);

            xml.HNAlign = txtHNAlign.Text == "Center" ? HorizontalAlignment.Center
                : txtHNAlign.Text == "Left" ? HorizontalAlignment.Left
                : txtHNAlign.Text == "Right" ? HorizontalAlignment.Right : HorizontalAlignment.Center;
            xml.HNFontSize = Convert.ToSingle(txtHNFontSize.Value);
            xml.HNValue = Convert.ToInt32(txtHNValue.Value);
            xml.HNType = txtHNType.Text.ToString();
            xml.HNSymbolText = txtHNSymbolText.Text.ToString();
            xml.HNSymbolPosition = Convert.ToInt32(txtHNSymbolPosition.Value);
            xml.HNSymbolStartFrom = txtHNSymbolStartFrom.Text[0].ToString();
            xml.HNAllUpper = cmbHNUpper.SelectedItem.ToString();
            xml.HNFreeText = cmbFreeText.SelectedItem.ToString();

            xml.SuggestionText = txtSuggestionText.Text;
            xml.SuggestionAlign = txtSuggestionAlign.Text == "Center" ? ContentAlignment.MiddleCenter
                : txtSuggestionAlign.Text == "Left" ? ContentAlignment.MiddleLeft
                : txtSuggestionAlign.Text == "Right" ? ContentAlignment.MiddleRight : ContentAlignment.MiddleCenter;
            xml.SuggestionFontSize = Convert.ToSingle(txtSuggestionFontSize.Value);

            xml.FooterText = txtFooterText.Text;
            xml.FooterAlign = txtFooterAlign.Text == "Center" ? ContentAlignment.MiddleCenter
                : txtFooterAlign.Text == "Left" ? ContentAlignment.MiddleLeft
                : txtFooterAlign.Text == "Right" ? ContentAlignment.MiddleRight : ContentAlignment.MiddleCenter;
            xml.FooterFontSize = Convert.ToSingle(txtFooterFontSize.Value);
            xml.AlwaysOnTop = txtAlwaysOnTop.Text;

            string _disableStatus = "";
            if (chkCancel.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=5" : "%26studyStatusCode!=5";
            if (chkSchedule.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=10" : "%26studyStatusCode!=10";
            if (chkArrived.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=20" : "%26studyStatusCode!=20";
            if (chkStarted.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=30" : "%26studyStatusCode!=30";
            if (chkSent.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=35" : "%26studyStatusCode!=35";
            if (chkComplete.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=40" : "%26studyStatusCode!=40";
            if (chkDictated.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=50" : "%26studyStatusCode!=50";
            if (chkFinalized.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=60" : "%26studyStatusCode!=60";
            if (chkReference.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=70" : "%26studyStatusCode!=70";
            if (chkNonReportable.Checked)
                _disableStatus += string.IsNullOrEmpty(_disableStatus) ? "studyStatusCode!=80" : "%26studyStatusCode!=80";

            xml.DisableStatus = string.IsNullOrEmpty(_disableStatus) ? "" : "&filter=" + _disableStatus;

            xml.SymbolData = grdSymbol.DataSource as DataTable;

            xml.SaveData();
        }
    }
}
