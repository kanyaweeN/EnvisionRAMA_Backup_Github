using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;


using Miracle.Util;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
namespace Envision.NET.Forms.Dialog
{
    public partial class PasswordForm : Form
    {
        double form;
        string user;
        string pass;
        string sequestion;
        string seanswer;
        string passen;

        DataTable dt;
        public bool show = true;
        
        MyMessageBox msg = new MyMessageBox();
        HR_EMP hraccount = new HR_EMP();
        ProcessGetHRAccount pchracc = new ProcessGetHRAccount();

        public PasswordForm(int fo, string us)
        {
            
            InitializeComponent();

            form = Convert.ToDouble(fo);

            hraccount.Username = us.Trim();
            pchracc.HR_EMP = hraccount;

            try
            {
                pchracc.Invoke();
                dt = pchracc.ResultSet.Tables[0].Copy();

                user = dt.Rows[0]["USER_NAME"].ToString();
                pass = Utilities.Decrypt(dt.Rows[0]["PWD"].ToString());
                sequestion = dt.Rows[0]["SECURITY_QUESTION"].ToString();
                seanswer = dt.Rows[0]["SECURITY_ANSWER"].ToString();
                //try
                //{
                //    passen = dt.Rows[0]["PWD_ENCRYPT"].ToString();
                //}
                //catch (Exception ex) { passen = string.Empty; }

                //if (passen != "")
                //    pass = Secure.Decrypt(passen);
            }
            catch(Exception ex)
            {
                //MyMessageBox.ShowBox("Incorrect Username Account in Database \n    Please try again.", 10);
                string id = msg.ShowAlert("UID2039", 2);
                this.show = false;
              
            }

            if(form == 1)
            {
                LoadForm1();
            }
            else if (form == 2)
            {
                LoadForm2();
            }
            else if (form == 3)
            {
                LoadForm3();
            }
        }

        private void LoadForm1()
        {
            this.labelTop.Text = "ท่านต้องการการเปลี่ยน password ของ user :\n"
                + "กรุณากรอก password เดิมในช่องแรก และ password ที่ต้องการจะเปลี่ยนในช่องที่2และ3แล้วกดปุ่มยืนยัน";
            this.labelUser.Text = user;

            this.label1.Text = "ยืนยัน password เก่า";
            this.label2.Text = "กรอก password ใหม่";
            this.label3.Text = "ยืนยัน password ใหม่";
        }

        private void LoadForm2()
        {
            this.labelTop.Text = "ท่านต้องการทำการรีเซท password ของ user :\n"
                + "กรุณากรอก คำตอบลงในช่องที่2และกดปุ่มยืนยัน เมื่อคำตอบถูกต้องกรุณากรอก password ใหม่และกดปุ่มยืนยัน";
            this.labelUser.Text = user;

            this.textBox1.ReadOnly = true;
            this.textBox1.Text = sequestion;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox2.UseSystemPasswordChar = false;
            this.textBox3.Visible = false;
            textBox1.Enabled = false;

            this.label1.Text = "ข้อความ คำถาม";
            this.label2.Text = "ช่องสำหรับตอบคำถาม";
            this.label3.Text = "";
        }

        private void LoadForm3()
        {
            this.labelTop.Text = "กรุณกรอก password ใหม่ ซึ่งจะใช้ในการ\n login ในครั้งต่อไป(กรุณาจดจำไว้ด้วยนะค่ะ)";
            this.labelUser.Text = user;

            this.label1.Text = "กรอก password ใหม่";
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;
            textBox1.UseSystemPasswordChar = true;

            this.label2.Text = "ยืนยัน password ใหม่";
            textBox2.Text = string.Empty;
            textBox2.Enabled = true;
            textBox2.ReadOnly = false;
            textBox2.UseSystemPasswordChar = true;

            this.label3.Text = "";
            textBox3.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (form == 1)
            {
                ProcessForm1();
            }
            else if (form == 2)
            {
                ProcessForm2();
            }
            else if (form == 2.1)
            {
                ProcessForm2_1();
            }
            else if (form == 3)
            {
                ProcessForm3();
            }
            else if (form == 3.1)
            {
                ProcessForm3_1();
            }
        }

        private void ProcessForm1()
        {
            if (textBox1.Text == "")
            {
                //string id = MyMessageBox.ShowBox("กรุณายืนยัน password เดิม ในช่องแรกด้วย", 10);
                string id = msg.ShowAlert("UID2040", new GBLEnvVariable().CurrentLanguageID);
            }
            else if (textBox2.Text == "" || textBox3.Text == "")
            {
                //string id = MyMessageBox.ShowBox("กรุณากรอก password ใหม่ ในช่องที่2และ3ด้วย", 10);
                string id = msg.ShowAlert("UID2041", new GBLEnvVariable().CurrentLanguageID);
            }
            else if (this.textBox1.Text != this.pass)
            {
                //string id = MyMessageBox.ShowBox("password เดิม ของคุณไม่ถูกต้อง \nกรุณากรอก password เดิม อีกครั้ง", 10);
                string id = msg.ShowAlert("UID2042", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox1.Text = string.Empty;
                }
            }
            else if (this.textBox2.Text != this.textBox3.Text)
            {
                //string id = MyMessageBox.ShowBox("password ในช่อง 2 ไม่เหมื่อนกับ ช่อง password 3 \nกรุณากรอก password ทั้งสองช่องใหม่", 10);
                string id = msg.ShowAlert("UID2043", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
            else
            {

                hraccount.Password = Utilities.Encrypt(textBox3.Text);
                hraccount.Username = user;
                hraccount.SecurityQuestion = "";
                hraccount.SecurityAnswer = "";


                hraccount.USER_NAME = user;
                hraccount.PWD = hraccount.Password;


                try
                {
                    ProcessUpdateHRAccount uphracc = new ProcessUpdateHRAccount();
                    uphracc.HR_EMP = hraccount;
                    uphracc.Invoke();

                    //MyMessageBox.ShowBox("ระบบได้ทำการเปลี่ยน password เรียบร้อยแล้ว. \n   password ใหม่ของท่านคือ  \""+textBox3.Text+"\" ", 10);
                    string id = msg.ShowAlert("UID2044", new GBLEnvVariable().CurrentLanguageID);

                    object e = null;
                    EventArgs ee = null;
                    this.btnCancel_Click(e,ee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ProcessForm2()
        {
            textBox1.Text = sequestion;
            textBox1.Enabled = false;

            if (textBox2.Text == "")
            {
                //string id = MyMessageBox.ShowBox("กรุณากรอก คำตอบ ด้วย", 10);
                string id = msg.ShowAlert("UID2045", new GBLEnvVariable().CurrentLanguageID);
            }
            else if(textBox2.Text != seanswer)
            {
                //string id = MyMessageBox.ShowBox("คำตอบผิด \nกรุณากรอก คำตอบ ใหม่", 10);
                string id = msg.ShowAlert("UID2047", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox2.Text = string.Empty;
                }
            }
            else if (textBox2.Text == seanswer)
            {
                //MyMessageBox.ShowBox("คำตอบถูกต้อง!! \nต่อไประบบจะให้ตั้ง password ใหม่",10);
                string id = msg.ShowAlert("UID2046", new GBLEnvVariable().CurrentLanguageID);

                this.label1.Text = "กรอก password ใหม่";
                textBox1.Text = string.Empty;
                textBox1.Enabled = true;
                textBox1.ReadOnly = false;
                textBox1.UseSystemPasswordChar = true;

                this.label2.Text = "ยืนยัน password ใหม่";
                textBox2.Text = string.Empty;
                textBox2.Enabled = true;
                textBox2.ReadOnly = false;
                textBox2.UseSystemPasswordChar = true;

                form = 2.1;

                textBox1.Focus();
            }
        }

        private void ProcessForm2_1()
        {
            if (textBox1.Text != textBox2.Text)
            {
                //MyMessageBox.ShowBox("กรุณากรอก password ใหม่", 10);
                string id = msg.ShowAlert("UID2048", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                }
            }
            else
            {
                hraccount.Password = Utilities.Encrypt(textBox2.Text);
                hraccount.Username = user;
                hraccount.SecurityQuestion = "";
                hraccount.SecurityAnswer = "";
                hraccount.USER_NAME = user;
                hraccount.PWD = hraccount.Password;


                try
                {
                    ProcessUpdateHRAccount uphracc = new ProcessUpdateHRAccount();
                    uphracc.HR_EMP = hraccount;
                    uphracc.Invoke();

                    //MyMessageBox.ShowBox("ระบบได้ทำการ reset password เรียบร้อยแล้ว. \npassowrd ใหม่ของท่าน คือ\"" + textBox2.Text + "\" ", 10);
                    string id = msg.ShowAlert("UID2049", new GBLEnvVariable().CurrentLanguageID);

                    object e = null;
                    EventArgs ee = null;
                    this.btnCancel_Click(e, ee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ProcessForm3()
        {
            if (textBox1.Text != textBox2.Text)
            {
                //MyMessageBox.ShowBox("กรุณากรอก password ใหม่", 10);
                string id = msg.ShowAlert("UID2048", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                }
            }
            else
            {
                hraccount.Password = Utilities.Encrypt(textBox2.Text);
                hraccount.Username = user;
                hraccount.USER_NAME = user;
                hraccount.PWD = hraccount.Password;

                try
                {
                    this.labelTop.Text = "กรุณกรอก คำถาม-ตำตอบ ใหม่ ซึ่งจะใช้ในการ\n Reset Password ในครั้งต่อไป(กรุณาจดจำไว้ด้วยนะค่ะ)";
                    this.labelUser.Text = user;

                    this.label1.Text = "กรุณากรอก คำถาม";
                    textBox1.Text = string.Empty;
                    textBox1.Enabled = true;
                    textBox1.ReadOnly = false;
                    textBox1.UseSystemPasswordChar = false;

                    this.label2.Text = "กรุณากรอก คำตอบ";
                    textBox2.Text = string.Empty;
                    textBox2.Enabled = true;
                    textBox2.ReadOnly = false;
                    textBox2.UseSystemPasswordChar = false;

                    this.label3.Text = "";
                    textBox3.Visible = false;

                    form = 3.1;

                    textBox1.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ProcessForm3_1()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                //MyMessageBox.ShowBox("กรุณากรอก password ใหม่", 10);
                string id = msg.ShowAlert("UID2048", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                }
            }
            else
            {
                hraccount.SecurityQuestion = textBox1.Text;
                hraccount.SecurityAnswer = textBox2.Text;

                try
                {
                    ProcessUpdateHRAccount uphracc = new ProcessUpdateHRAccount();
                    uphracc.HR_EMP = hraccount;
                    uphracc.Invoke();

                    //MyMessageBox.ShowBox("ระบบได้ทำการ reset password เรียบร้อยแล้ว. \npassowrd ใหม่ของท่าน คือ\"" + textBox2.Text + "\" ", 10);
                    string id = msg.ShowAlert("UID2049", new GBLEnvVariable().CurrentLanguageID);

                    object e = null;
                    EventArgs ee = null;
                    this.btnCancel_Click(e, ee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}