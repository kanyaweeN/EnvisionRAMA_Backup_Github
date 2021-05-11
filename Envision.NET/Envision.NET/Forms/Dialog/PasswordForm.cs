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
            this.labelTop.Text = "��ҹ��ͧ��á������¹ password �ͧ user :\n"
                + "��سҡ�͡ password ���㹪�ͧ�á ��� password ����ͧ��è�����¹㹪�ͧ���2���3���ǡ������׹�ѹ";
            this.labelUser.Text = user;

            this.label1.Text = "�׹�ѹ password ���";
            this.label2.Text = "��͡ password ����";
            this.label3.Text = "�׹�ѹ password ����";
        }

        private void LoadForm2()
        {
            this.labelTop.Text = "��ҹ��ͧ��÷ӡ����૷ password �ͧ user :\n"
                + "��سҡ�͡ �ӵͺŧ㹪�ͧ���2��С������׹�ѹ ����ͤӵͺ�١��ͧ��سҡ�͡ password ������С������׹�ѹ";
            this.labelUser.Text = user;

            this.textBox1.ReadOnly = true;
            this.textBox1.Text = sequestion;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox2.UseSystemPasswordChar = false;
            this.textBox3.Visible = false;
            textBox1.Enabled = false;

            this.label1.Text = "��ͤ��� �Ӷ��";
            this.label2.Text = "��ͧ����Ѻ�ͺ�Ӷ��";
            this.label3.Text = "";
        }

        private void LoadForm3()
        {
            this.labelTop.Text = "��س��͡ password ���� ��觨���㹡��\n login 㹤��駵���(��سҨ��������¹Ф��)";
            this.labelUser.Text = user;

            this.label1.Text = "��͡ password ����";
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;
            textBox1.UseSystemPasswordChar = true;

            this.label2.Text = "�׹�ѹ password ����";
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
                //string id = MyMessageBox.ShowBox("��س��׹�ѹ password ��� 㹪�ͧ�á����", 10);
                string id = msg.ShowAlert("UID2040", new GBLEnvVariable().CurrentLanguageID);
            }
            else if (textBox2.Text == "" || textBox3.Text == "")
            {
                //string id = MyMessageBox.ShowBox("��سҡ�͡ password ���� 㹪�ͧ���2���3����", 10);
                string id = msg.ShowAlert("UID2041", new GBLEnvVariable().CurrentLanguageID);
            }
            else if (this.textBox1.Text != this.pass)
            {
                //string id = MyMessageBox.ShowBox("password ��� �ͧ�س���١��ͧ \n��سҡ�͡ password ��� �ա����", 10);
                string id = msg.ShowAlert("UID2042", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox1.Text = string.Empty;
                }
            }
            else if (this.textBox2.Text != this.textBox3.Text)
            {
                //string id = MyMessageBox.ShowBox("password 㹪�ͧ 2 ��������͹�Ѻ ��ͧ password 3 \n��سҡ�͡ password ����ͧ��ͧ����", 10);
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

                    //MyMessageBox.ShowBox("�к���ӡ������¹ password ���º��������. \n   password ����ͧ��ҹ���  \""+textBox3.Text+"\" ", 10);
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
                //string id = MyMessageBox.ShowBox("��سҡ�͡ �ӵͺ ����", 10);
                string id = msg.ShowAlert("UID2045", new GBLEnvVariable().CurrentLanguageID);
            }
            else if(textBox2.Text != seanswer)
            {
                //string id = MyMessageBox.ShowBox("�ӵͺ�Դ \n��سҡ�͡ �ӵͺ ����", 10);
                string id = msg.ShowAlert("UID2047", new GBLEnvVariable().CurrentLanguageID);
                if (id == "1")
                {
                    textBox2.Text = string.Empty;
                }
            }
            else if (textBox2.Text == seanswer)
            {
                //MyMessageBox.ShowBox("�ӵͺ�١��ͧ!! \n�����к�������� password ����",10);
                string id = msg.ShowAlert("UID2046", new GBLEnvVariable().CurrentLanguageID);

                this.label1.Text = "��͡ password ����";
                textBox1.Text = string.Empty;
                textBox1.Enabled = true;
                textBox1.ReadOnly = false;
                textBox1.UseSystemPasswordChar = true;

                this.label2.Text = "�׹�ѹ password ����";
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
                //MyMessageBox.ShowBox("��سҡ�͡ password ����", 10);
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

                    //MyMessageBox.ShowBox("�к���ӡ�� reset password ���º��������. \npassowrd ����ͧ��ҹ ���\"" + textBox2.Text + "\" ", 10);
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
                //MyMessageBox.ShowBox("��سҡ�͡ password ����", 10);
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
                    this.labelTop.Text = "��س��͡ �Ӷ��-�ӵͺ ���� ��觨���㹡��\n Reset Password 㹤��駵���(��سҨ��������¹Ф��)";
                    this.labelUser.Text = user;

                    this.label1.Text = "��سҡ�͡ �Ӷ��";
                    textBox1.Text = string.Empty;
                    textBox1.Enabled = true;
                    textBox1.ReadOnly = false;
                    textBox1.UseSystemPasswordChar = false;

                    this.label2.Text = "��سҡ�͡ �ӵͺ";
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
                //MyMessageBox.ShowBox("��سҡ�͡ password ����", 10);
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

                    //MyMessageBox.ShowBox("�к���ӡ�� reset password ���º��������. \npassowrd ����ͧ��ҹ ���\"" + textBox2.Text + "\" ", 10);
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