using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
namespace Envision.NET.Forms.Dialog
{
    public partial class MyMessageBox : Form
    {

        static MyMessageBox newMessageBox;
        public Timer msgTimer;
        static string Button_id;
        static bool checkBox;

        int disposeFormTimer; 

        public MyMessageBox()
        {
            InitializeComponent();
        }

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        public static string ShowBox(string txtMessage, int delaytime)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.disposeFormTimer = delaytime;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        public string ShowAlert(string UID, int LANGID)
        {
            
            string btn = "";
            string txtMessage="", txtTitle="", noOfButton="", defaultbtn="", timesec="", cap1="", cap2="", cap3="", alttype="";
            ProcessGetGlobalAlert gblprocess = new ProcessGetGlobalAlert();
            GBL_ALERT galert = new GBL_ALERT();
            galert.ALT_UID = UID;
            galert.LangID = LANGID;
            gblprocess.GBL_ALERT = galert;

            try
            {
                gblprocess.Invoke();
                DataTable dt = gblprocess.ResultSet.Tables[0];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    txtMessage = dt.Rows[i]["ALT_TEXT"].ToString();
                    txtTitle = dt.Rows[i]["ALT_TITLE"].ToString();
                    noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
                    defaultbtn = dt.Rows[i]["DEFAULT_BTN"].ToString();
                    timesec = dt.Rows[i]["TIME_SEC"].ToString();
                    cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
                    cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
                    cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
                    alttype = dt.Rows[i]["ALT_TYPE"].ToString();

                    i++;
                }
                if (dt.Rows.Count > 0)
                {
                    btn = ShowBox(txtMessage, txtTitle, noOfButton, defaultbtn, timesec, cap1, cap2, cap3, alttype);
                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            return btn;

        }
        public string ShowAlert(string UID, int LANGID,int minichar)
        {
            string btn = "";
            string txtMessage = "", txtTitle = "", noOfButton = "", defaultbtn = "", timesec = "", cap1 = "", cap2 = "", cap3 = "", alttype = "";
            ProcessGetGlobalAlert gblprocess = new ProcessGetGlobalAlert();
            GBL_ALERT galert = new GBL_ALERT();
            galert.ALT_UID = UID;
            galert.LangID = LANGID;
            gblprocess.GBL_ALERT = galert;

            try
            {
                gblprocess.Invoke();
                DataTable dt = gblprocess.ResultSet.Tables[0];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    txtMessage = dt.Rows[i]["ALT_TEXT"].ToString().Replace("8",minichar.ToString());
                    txtTitle = dt.Rows[i]["ALT_TITLE"].ToString();
                    noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
                    defaultbtn = dt.Rows[i]["DEFAULT_BTN"].ToString();
                    timesec = dt.Rows[i]["TIME_SEC"].ToString();
                    cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
                    cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
                    cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
                    alttype = dt.Rows[i]["ALT_TYPE"].ToString();

                    i++;
                }
                if (dt.Rows.Count > 0)
                {
                    btn = ShowBox(txtMessage, txtTitle, noOfButton, defaultbtn, timesec, cap1, cap2, cap3, alttype);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return btn;

        }
        public string ShowAlert(string UID, int LANGID,string caption)
        {
            bool visibleCheckBox = false;
            string textCheckBox= "";
            string btn = "";
            string txtMessage = "", txtTitle = "", noOfButton = "", defaultbtn = "", timesec = "", cap1 = "", cap2 = "", cap3 = "", alttype = "";
            ProcessGetGlobalAlert gblprocess = new ProcessGetGlobalAlert();
            GBL_ALERT galert = new GBL_ALERT();
            galert.ALT_UID = UID;
            galert.LangID = LANGID;
            gblprocess.GBL_ALERT = galert;
            if (string.IsNullOrEmpty(caption))
                visibleCheckBox = false;
            else
                visibleCheckBox = true;
            textCheckBox = caption;
            try
            {
                gblprocess.Invoke();
                DataTable dt = gblprocess.ResultSet.Tables[0];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    txtMessage = dt.Rows[i]["ALT_TEXT"].ToString();
                    txtTitle = dt.Rows[i]["ALT_TITLE"].ToString();
                    noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
                    defaultbtn = dt.Rows[i]["DEFAULT_BTN"].ToString();
                    timesec = dt.Rows[i]["TIME_SEC"].ToString();
                    cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
                    cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
                    cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
                    alttype = dt.Rows[i]["ALT_TYPE"].ToString();

                    i++;
                }
                if (dt.Rows.Count > 0)
                {
                    btn = ShowBox(txtMessage, txtTitle, noOfButton, defaultbtn, timesec, cap1, cap2, cap3, alttype,textCheckBox,visibleCheckBox);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return btn;

        }

        public string ShowAlertAndAddMessage(string UID, int LANGID, string addMessage)
        {
            string btn = "";
            string txtMessage = "", txtTitle = "", noOfButton = "", defaultbtn = "", timesec = "", cap1 = "", cap2 = "", cap3 = "", alttype = "";
            ProcessGetGlobalAlert gblprocess = new ProcessGetGlobalAlert();
            GBL_ALERT galert = new GBL_ALERT();
            galert.ALT_UID = UID;
            galert.LangID = LANGID;
            gblprocess.GBL_ALERT = galert;

            try
            {
                gblprocess.Invoke();
                DataTable dt = gblprocess.ResultSet.Tables[0];
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    txtMessage = dt.Rows[i]["ALT_TEXT"].ToString();
                    txtTitle = dt.Rows[i]["ALT_TITLE"].ToString();
                    noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
                    defaultbtn = dt.Rows[i]["DEFAULT_BTN"].ToString();
                    timesec = dt.Rows[i]["TIME_SEC"].ToString();
                    cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
                    cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
                    cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
                    alttype = dt.Rows[i]["ALT_TYPE"].ToString();

                    i++;
                }
                if (!string.IsNullOrEmpty(addMessage))
                    txtMessage += addMessage;

                if (dt.Rows.Count > 0)
                {
                    btn = ShowBox(txtMessage, txtTitle, noOfButton, defaultbtn, timesec, cap1, cap2, cap3, alttype);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return btn;
        }
        public static string ShowBox(string txtMessage, string txtTitle,string noOfButton,string defaultbtn, string timesec, string cap1, string cap2, string cap3, string alttype)
        {
            
            
           
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            
            if (noOfButton == "1")
            {
                //for image RIS.Properties.Resources.title_bar
                newMessageBox.btnOK.Text = cap1;
                newMessageBox.btnCancel.Visible = false;
                newMessageBox.btnYes.Visible = false;
            }
            else if (noOfButton == "2")
            {
                newMessageBox.btnOK.Text = cap1;
                newMessageBox.btnCancel.Text = cap2;
                newMessageBox.btnYes.Visible = false;
            }
            else
            {
              
                newMessageBox.btnCancel.Text = cap3;
                newMessageBox.btnOK.Text = cap2;
                newMessageBox.btnYes.Text = cap1;
            }

            if (alttype == "I")
            {
                newMessageBox.label1.Image =  Envision.NET.Properties.Resources.information;
            }
            else if (alttype == "W")
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.warning;
            }
            else if (alttype == "C")
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.caution;
            }
            else
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.confirmation;
            }
            
            newMessageBox.disposeFormTimer = Convert.ToInt32(timesec.ToString().Trim());
            if (defaultbtn == "1")
            {

                newMessageBox.AcceptButton = newMessageBox.btnCancel;
                newMessageBox.btnCancel.Focus();
            }
            else if (defaultbtn == "2")
            {

                newMessageBox.AcceptButton = newMessageBox.btnOK;
                newMessageBox.btnOK.Focus();

            }
            else
            {

                newMessageBox.AcceptButton = newMessageBox.btnYes;
                newMessageBox.btnYes.Focus();
            }
            
            newMessageBox.ShowDialog();
            return Button_id;
        }
        public static string ShowBox(string txtMessage, string txtTitle, string noOfButton, string defaultbtn, string timesec, string cap1, string cap2, string cap3, string alttype,string capCheckBox,bool visCheckbox)
        {



            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.chkBox.Text = capCheckBox;
            newMessageBox.chkBox.Visible = visCheckbox;
            if (noOfButton == "1")
            {
                //for image RIS.Properties.Resources.title_bar
                newMessageBox.btnOK.Text = cap1;
                newMessageBox.btnCancel.Visible = false;
                newMessageBox.btnYes.Visible = false;
            }
            else if (noOfButton == "2")
            {
                newMessageBox.btnOK.Text = cap1;
                newMessageBox.btnCancel.Text = cap2;
                newMessageBox.btnYes.Visible = false;
            }
            else
            {

                newMessageBox.btnCancel.Text = cap3;
                newMessageBox.btnOK.Text = cap2;
                newMessageBox.btnYes.Text = cap1;
            }

            if (alttype == "I")
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.information;
            }
            else if (alttype == "W")
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.warning;
            }
            else if (alttype == "C")
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.caution;
            }
            else
            {
                newMessageBox.label1.Image = Envision.NET.Properties.Resources.confirmation;
            }

            newMessageBox.disposeFormTimer = Convert.ToInt32(timesec.ToString().Trim());
            if (defaultbtn == "1")
            {

                newMessageBox.AcceptButton = newMessageBox.btnCancel;
                newMessageBox.btnCancel.Focus();
            }
            else if (defaultbtn == "2")
            {

                newMessageBox.AcceptButton = newMessageBox.btnOK;
                newMessageBox.btnOK.Focus();

            }
            else
            {

                newMessageBox.AcceptButton = newMessageBox.btnYes;
                newMessageBox.btnYes.Focus();
            }

            newMessageBox.ShowDialog();
            return Button_id;
        } 

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            //disposeFormTimer = 0;
            msgTimer = new Timer();
            if (disposeFormTimer > 0) // disposeFormTimer > 0 will enable timer. Otherwise, timer is disabled.
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
                msgTimer.Interval = 1000;
                msgTimer.Enabled = true;
                msgTimer.Start();
                msgTimer.Tick += new System.EventHandler(this.timer_tick);
            }
        }

        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);
            
            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "2";
            checkBox = chkBox.Checked;
            newMessageBox.Dispose(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "1";
            checkBox = false;
            newMessageBox.Dispose();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                newMessageBox.msgTimer.Stop();
                newMessageBox.msgTimer.Dispose();
                newMessageBox.Dispose();
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "3";
            checkBox = chkBox.Checked;
            newMessageBox.Dispose();
        }

        public bool isCheckBox
        {
            get { return checkBox; }
            set { checkBox = value; }
        }
        ~MyMessageBox()
        {
            this.Dispose();

        }
    }
}