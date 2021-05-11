using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;
using RIS.BusinessLogic;
using RIS.Common;
using UUL.ControlFrame.Controls;
using System.Globalization;
using System.Threading;
using RIS.Common.Common;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;

using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{

    public partial class GBL_SF03a : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private RIS.Common.UtilityClass.DBUtility dbu = new RIS.Common.UtilityClass.DBUtility();

        MyMessageBox msg = new MyMessageBox();

        public GBL_SF03a(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            this.ORG_UID.Focus();

            //Panel_Resize();
            Dataload();
        }

        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JPEG (*.jpg)|*.jpg|Png (*.png)|*.png|Gif (*.gif)|*.gif";
                ofd.InitialDirectory = "root";
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
                {
                    try
                    {
                        using (Image im = Image.FromFile(ofd.FileName.Trim()))
                        {
                            this.pictureBox1.Image = (Image)im.Clone();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void textBox22_KeyUp(object sender, KeyEventArgs e)
        {
                try
                {Int32.Parse(EMP_IMG_MAX_SIZE.Text.Trim());}
                catch (Exception)
                {EMP_IMG_MAX_SIZE.Text = string.Empty;}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void Dataload()
        {
            RIS.BusinessLogic.ProcessGetGBLEnv ge = new RIS.BusinessLogic.ProcessGetGBLEnv();
            ge.Invoke();

            DataTable dt = ge.ResultSet.Tables[0];

            DataShow(dt);
        }

        private void DataShow(DataTable dt)
        {
            try
            {
                this.ORG_UID.Text = dt.Rows[0]["ORG_UID"].ToString();
                this.ORG_NAME.Text = dt.Rows[0]["ORG_NAME"].ToString();
                this.ORG_ALIAS.Text = dt.Rows[0]["ORG_ALIAS"].ToString();
                this.ORG_SLOGAN1.Text = dt.Rows[0]["ORG_SLOGAN1"].ToString();
                this.ORG_SLOGAN2.Text = dt.Rows[0]["ORG_SLOGAN2"].ToString();

                this.ORG_ADD1.Text = dt.Rows[0]["ORG_ADDR1"].ToString();
                this.ORG_ADD2.Text = dt.Rows[0]["ORG_ADDR2"].ToString();
                this.ORG_ADD3.Text = dt.Rows[0]["ORG_ADDR3"].ToString();
                this.ORG_ADD4.Text = dt.Rows[0]["ORG_ADDR4"].ToString();

                this.ORG_PHONE1.Text = dt.Rows[0]["ORG_TEL1"].ToString();
                this.ORG_PHONE2.Text = dt.Rows[0]["ORG_TEL2"].ToString();
                this.ORG_PHONE3.Text = dt.Rows[0]["ORG_TEL3"].ToString();
                this.ORG_FAX.Text = dt.Rows[0]["ORG_FAX"].ToString();

                this.ORG_EMAIL1.Text = dt.Rows[0]["ORG_EMAIL1"].ToString();
                this.ORG_WEBSITE.Text = dt.Rows[0]["ORG_WEBSITE"].ToString();
                this.WELCOME_DIALOG1.Text = dt.Rows[0]["WELCOME_DIALOG1"].ToString();
                this.WELCOME_DIALOG2.Text = dt.Rows[0]["WELCOME_DIALOG2"].ToString();

                this.REP_FOOTER1.Text = dt.Rows[0]["REP_FOOTER1"].ToString();
                this.REP_FOOTER2.Text = dt.Rows[0]["REP_FOOTER2"].ToString();

                this.DT_FMT.Text = dt.Rows[0]["DT_FMT"].ToString();
                this.TIME_FMT.Text = dt.Rows[0]["TIME_FMT"].ToString();

                this.USER_DISPLAY_FMT.Text = dt.Rows[0]["USER_DISPLAY_FMT"].ToString();
                this.CURRENCY_FMT.Text = dt.Rows[0]["CURRENCY_FMT"].ToString();
                this.LOCAL_CURRENCY_NAME.Text = dt.Rows[0]["LOCAL_CURRENCY_NAME"].ToString();
                this.LOCAL_CURRENCY_SYMBOL.Text = dt.Rows[0]["LOCAL_CURRENCY_SYMBOL"].ToString();

                this.EMP_IMG_TYPE.Text = dt.Rows[0]["EMP_IMG_TYPE"].ToString();
                this.EMP_IMG_MAX_SIZE.Text = dt.Rows[0]["EMP_IMG_MAX_SIZE"].ToString();

                this.SCANNED_IMAGE_PATH.Text = dt.Rows[0]["SCANNED_IMAGE_PATH"].ToString();
                this.BACKUP_PATH.Text = dt.Rows[0]["BACKUP_PATH"].ToString();

                this.VENDOR_H1.Text = dt.Rows[0]["VENDOR_H1"].ToString();
                this.VENDOR_H2.Text = dt.Rows[0]["VENDOR_H2"].ToString();
                this.VENDOR_LOGO_PATH.Text = dt.Rows[0]["VENDOR_LOGO_PATH"].ToString();

                this.RIS_IP.Text = dt.Rows[0]["RIS_IP"].ToString();
                this.RIS_PORT.Text = dt.Rows[0]["RIS_PORT"].ToString();
                this.RIS_USER.Text = dt.Rows[0]["RIS_USER"].ToString();
                this.RIS_PASS.Text = dt.Rows[0]["RIS_PASS"].ToString();
                this.RIS_URL.Text = dt.Rows[0]["RIS_URL"].ToString();

                this.PACS_IP.Text = dt.Rows[0]["PACS_IP"].ToString();
                this.PACS_PORT.Text = dt.Rows[0]["PACS_PORT"].ToString();
                this.PACS_URL1.Text = dt.Rows[0]["PACS_URL1"].ToString();
                this.PACS_URL2.Text = dt.Rows[0]["PACS_URL2"].ToString();

                //this.PACS_IP_1.Text = dt.Rows[0]["PACS_IP_1"].ToString();
                //this.PACS_PORT_1.Text = dt.Rows[0]["PACS_PORT_1"].ToString();
                //this.PACS_URL1_1.Text = dt.Rows[0]["PACS_URL1_1"].ToString();
                //this.PACS_URL2_1.Text = dt.Rows[0]["PACS_URL2_1"].ToString();

                this.HIS_IP.Text = dt.Rows[0]["HIS_IP"].ToString();
                this.HIS_PORT.Text = dt.Rows[0]["HIS_PORT"].ToString();
                this.HIS_DB_NAME.Text = dt.Rows[0]["HIS_DB_NAME"].ToString();
                this.HIS_USER_NAME.Text = dt.Rows[0]["HIS_USER_NAME"].ToString();
                this.HIS_USER_PASS.Text = dt.Rows[0]["HIS_USER_PASS"].ToString();

                if (dt.Rows[0]["HIS_FIN_FLAG"].ToString() == "TRUE")
                    this.HIS_FIN_FLAG.Checked = true;
                else
                    this.HIS_FIN_FLAG.Checked = false;

                this.WS_IP.Text = dt.Rows[0]["WS_IP"].ToString();
                this.WS_VERSION.Text = dt.Rows[0]["WS_VERSION"].ToString();

                
                    try
                    {
                        ImageConverter imcon = new ImageConverter();
                        pictureBox1.Image = (Image)imcon.ConvertFrom(dt.Rows[0]["ORG_IMG"]); 
                    }
                    catch(Exception)
                    {
                        pictureBox1.Image = null;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string str = msg.ShowAlert("UID2008", 1);
            if (str == "1")
            { return; }

            try
            {
                GBLEnv env = new GBLEnv();
                ProcessUpdateGBLEnv penv = new ProcessUpdateGBLEnv();

                env.OrgUID = this.ORG_UID.Text;
                env.OrgName = this.ORG_NAME.Text;
                env.OrgAlias = this.ORG_ALIAS.Text;
                env.OrgSlogan1 = this.ORG_SLOGAN1.Text;
                env.OrgSlogan2 = this.ORG_SLOGAN2.Text;

                env.OrgAddr1 = this.ORG_ADD1.Text;
                env.OrgAddr2 = this.ORG_ADD2.Text;
                env.OrgAddr3 = this.ORG_ADD3.Text;
                env.OrgAddr4 = this.ORG_ADD4.Text;

                env.OrgTel1 = this.ORG_PHONE1.Text;
                env.OrgTel2 = this.ORG_PHONE2.Text;
                env.OrgTel3 = this.ORG_PHONE3.Text;
                env.OrgFax = this.ORG_FAX.Text;

                env.OrgEmail1 = this.ORG_EMAIL1.Text;
                env.OrgWebsite = this.ORG_WEBSITE.Text;
                env.WelcomeDialog1 = this.WELCOME_DIALOG1.Text;
                env.WelcomeDialog2 = this.WELCOME_DIALOG2.Text;

                env.RepFooter1 = this.REP_FOOTER1.Text;
                env.RepFooter2 = this.REP_FOOTER2.Text;

                env.DateFormat = this.DT_FMT.Text;
                env.TimeFormat = this.TIME_FMT.Text;

                env.UserDisplayFormat = this.USER_DISPLAY_FMT.Text;
                env.CurrencyFormat = this.CURRENCY_FMT.Text;
                env.LocalCurrencyName = this.LOCAL_CURRENCY_NAME.Text;
                env.LocalCurrencySymbol = this.LOCAL_CURRENCY_SYMBOL.Text;

                env.EmpImageType = this.EMP_IMG_TYPE.Text;
                env.EmpImageMaxSize = this.EMP_IMG_MAX_SIZE.Text;

                env.ScannedImagePath = this.SCANNED_IMAGE_PATH.Text;
                env.BackupPath = this.BACKUP_PATH.Text;

                env.VendorH1 = this.VENDOR_H1.Text;
                env.VendorH2 = this.VENDOR_H2.Text;
                env.VendorLogoPath = this.VENDOR_LOGO_PATH.Text;

                env.RisIP = this.RIS_IP.Text;
                env.RisPort = this.RIS_PORT.Text;
                env.RisUser = this.RIS_USER.Text;
                env.RisPass = this.RIS_PASS.Text;
                env.RisURL = this.RIS_URL.Text;

                env.PacsIP = this.PACS_IP.Text;
                env.PacsPort = this.PACS_PORT.Text;
                env.PacsURL1 = this.PACS_URL1.Text;
                env.PacsURL2 = this.PACS_URL2.Text;

                env.PacsIP_1 = this.PACS_IP_1.Text;
                env.PacsPort_1 = this.PACS_PORT_1.Text;
                env.PacsURL1_1 = this.PACS_URL1_1.Text;
                env.PacsURL2_1 = this.PACS_URL2_1.Text;

                env.HisIP = this.HIS_IP.Text;
                env.HisPort = this.HIS_PORT.Text;
                env.HisDBName = this.HIS_DB_NAME.Text;

                if (this.HIS_FIN_FLAG.Checked == true)
                    env.HisFinFlag = "TRUE";
                else
                    env.HisFinFlag = "FALSE";

                env.HisUserName = this.HIS_USER_NAME.Text;
                env.HisUserPass = this.HIS_USER_PASS.Text;

                env.WsIP = this.WS_IP.Text;
                env.WsVersion = this.WS_VERSION.Text;

                ImageConverter imcon = new ImageConverter();
                env.Image = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));

                env.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                penv.GBLEnv = env;
                penv.Invoke();

                UpdateGBLEnvVariable();

                //MyMessageBox.ShowBox("Form was Updated!!!!",4);
                msg.ShowAlert("UID2050", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

                Dataload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateGBLEnvVariable()
        {
            GBLEnvVariable env = new GBLEnvVariable();

            ProcessGetGBLEnv gblenv = new ProcessGetGBLEnv();
            gblenv.Invoke();
            DataTable dtenv = gblenv.ResultSet.Tables[0];

            env.DateFormat = dtenv.Rows[0]["DT_FMT"].ToString();
            env.TimeFormat = dtenv.Rows[0]["TIME_FMT"].ToString();
            env.CurrencyName = dtenv.Rows[0]["LOCAL_CURRENCY_NAME"].ToString();
            env.CurrencySymbol = dtenv.Rows[0]["LOCAL_CURRENCY_SYMBOL"].ToString();
            env.CurrencyFormat = dtenv.Rows[0]["CURRENCY_FMT"].ToString();
            env.PacsIp = dtenv.Rows[0]["PACS_IP"].ToString();
            env.PacsPort = dtenv.Rows[0]["PACS_PORT"].ToString();
            env.PacsUrl = dtenv.Rows[0]["PACS_URL1"].ToString();
            env.PacsUrl2 = dtenv.Rows[0]["PACS_URL2"].ToString();
            env.FontName = dtenv.Rows[0]["DEFAULT_FONT_FACE"].ToString();
            env.FontSize = dtenv.Rows[0]["DEFAULT_FONT_SIZE"].ToString();
            env.ScannedImagePath = dtenv.Rows[0]["SCANNED_IMAGE_PATH"].ToString();
            env.WebServiceIP = dtenv.Rows[0]["WS_IP"].ToString();
            env.WebServiceIP_PICTURE = dtenv.Rows[0]["WS_IP_PICTURE"].ToString();

            //env.PacsIp_1 = dtenv.Rows[0]["PACS_IP_1"].ToString();
            //env.PacsPort_1 = dtenv.Rows[0]["PACS_PORT_1"].ToString();
            //env.PacsUrl1_1 = dtenv.Rows[0]["PACS_URL1_1"].ToString();
            //env.PacsUrl2_1 = dtenv.Rows[0]["PACS_URL2_1"].ToString();
        }

        private void GBL_SF03a_Load(object sender, EventArgs e)
        {
            layoutControlGroup3.Expanded = false;
            layoutControlGroup7.Expanded = false;
            layoutControlGroup5.Expanded = false;
            layoutControlGroup8.Expanded = false;
        }

    }
}