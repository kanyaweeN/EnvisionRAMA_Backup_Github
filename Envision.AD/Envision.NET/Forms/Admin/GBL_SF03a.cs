using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;

using Miracle.Util;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Admin
{

    public partial class GBL_SF03a : Envision.NET.Forms.Main.MasterForm
    {
        MyMessageBox msg = new MyMessageBox();

        public GBL_SF03a()
        {
            InitializeComponent();
            this.ORG_UID.Focus();
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
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.RemoveAt(index);
            this.Close();
        }

        private void Dataload()
        {
            ProcessGetGBLEnv ge = new ProcessGetGBLEnv();
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
                GBL_ENV env = new GBL_ENV();
                ProcessUpdateGBLEnv penv = new ProcessUpdateGBLEnv();

                env.ORG_UID = this.ORG_UID.Text;
                env.ORG_NAME = this.ORG_NAME.Text;
                env.ORG_ALIAS = this.ORG_ALIAS.Text;
                env.ORG_SLOGAN1 = this.ORG_SLOGAN1.Text;
                env.ORG_SLOGAN2 = this.ORG_SLOGAN2.Text;

                env.ORG_ADDR1 = this.ORG_ADD1.Text;
                env.ORG_ADDR2 = this.ORG_ADD2.Text;
                env.ORG_ADDR3 = this.ORG_ADD3.Text;
                env.ORG_ADDR4 = this.ORG_ADD4.Text;

                env.ORG_TEL1 = this.ORG_PHONE1.Text;
                env.ORG_TEL2 = this.ORG_PHONE2.Text;
                env.ORG_TEL3 = this.ORG_PHONE3.Text;
                env.ORG_FAX = this.ORG_FAX.Text;

                env.ORG_EMAIL1 = this.ORG_EMAIL1.Text;
                env.ORG_WEBSITE = this.ORG_WEBSITE.Text;
                env.WELCOME_DIALOG1 = this.WELCOME_DIALOG1.Text;
                env.WELCOME_DIALOG2 = this.WELCOME_DIALOG2.Text;

                env.REP_FOOTER1 = this.REP_FOOTER1.Text;
                env.REP_FOOTER2 = this.REP_FOOTER2.Text;

                env.DT_FMT = this.DT_FMT.Text;
                env.TIME_FMT = this.TIME_FMT.Text;

                env.USER_DISPLAY_FMT = this.USER_DISPLAY_FMT.Text;
                env.CURRENCY_FMT = this.CURRENCY_FMT.Text;
                env.LOCAL_CURRENCY_NAME = this.LOCAL_CURRENCY_NAME.Text;
                env.LOCAL_CURRENCY_SYMBOL = this.LOCAL_CURRENCY_SYMBOL.Text;

                env.EMP_IMG_TYPE = this.EMP_IMG_TYPE.Text;
                env.EMP_IMG_MAX_SIZE = this.EMP_IMG_MAX_SIZE.Text;

                env.SCANNED_IMAGE_PATH = this.SCANNED_IMAGE_PATH.Text;
                env.BACKUP_PATH = this.BACKUP_PATH.Text;

                env.VENDOR_H1 = this.VENDOR_H1.Text;
                env.VENDOR_H2 = this.VENDOR_H2.Text;
                env.VENDOR_LOGO_PATH = this.VENDOR_LOGO_PATH.Text;

                env.RIS_IP = this.RIS_IP.Text;
                env.RIS_PORT = this.RIS_PORT.Text;
                env.RIS_USER = this.RIS_USER.Text;
                env.RIS_PASS = this.RIS_PASS.Text;
                env.RIS_URL = this.RIS_URL.Text;

                env.PACS_IP = this.PACS_IP.Text;
                env.PACS_PORT = this.PACS_PORT.Text;
                env.PACS_URL1 = this.PACS_URL1.Text;
                env.PACS_URL2 = this.PACS_URL2.Text;

                env.HIS_IP = this.HIS_IP.Text;
                env.HIS_PORT = this.HIS_PORT.Text;
                env.HIS_DB_NAME = this.HIS_DB_NAME.Text;

                if (this.HIS_FIN_FLAG.Checked == true)
                    env.HIS_FIN_FLAG = "TRUE";
                else
                    env.HIS_FIN_FLAG = "FALSE";

                env.HIS_USER_NAME = this.HIS_USER_NAME.Text;
                env.HIS_USER_PASS = this.HIS_USER_PASS.Text;

                env.WS_IP = this.WS_IP.Text;
                env.WS_VERSION = this.WS_VERSION.Text;

                ImageConverter imcon = new ImageConverter();
                //env.ORG_IMG = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                env.PICTURE_FORSAVE = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));

                env.CREATED_BY = new GBLEnvVariable().UserID;

                penv.GBL_ENV = env;
                penv.Invoke();

                UpdateGBLEnvVariable();

                //MyMessageBox.ShowBox("Form was Updated!!!!",4);
                //msg.ShowAlert("UID2050", new GBLEnvVariable().CurrentLanguageID);

                Dataload();
                refreshENV();
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
        }

        private void GBL_SF03a_Load(object sender, EventArgs e)
        {
            layoutControlGroup3.Expanded = false;
            layoutControlGroup7.Expanded = false;
            layoutControlGroup5.Expanded = false;
            layoutControlGroup8.Expanded = false;
            base.CloseWaitDialog();
        }

        private void refreshENV() {
            GBLEnvVariable env = new GBLEnvVariable();
            EnvisionDataContext db = new EnvisionDataContext();
            IQueryable<GBL_ENV> envQuery = from g in db.GBL_ENVs select g;
            GBL_ENV gEnv = (from g in envQuery where g.ORG_ID == env.OrgID select g).Single();
            
            env.ActiveDate = DateTime.Today;
            env.OrgID = gEnv.ORG_ID;
            env.ScannedImagePath = gEnv.SCANNED_IMAGE_PATH;
            env.TemplateID = 0;
            env.TimeFormat = gEnv.TIME_FMT;
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
            //Main.frmMain.ChangeHospitalName();
            Main.frmMain main = (Main.frmMain)this.MdiParent;
            main.UpdateHospitalName();
        }
    }
}