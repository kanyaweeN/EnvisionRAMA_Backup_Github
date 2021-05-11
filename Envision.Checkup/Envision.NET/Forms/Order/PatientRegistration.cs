using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Forms.GBLMessage;
using RIS.BusinessLogic;
using RIS.Common;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Imaging;

using Itworks.NationalIdCardSdk;
using System.Threading;
using System.Data.SqlClient;
using Miracle.NationalIDCard;
using Miracle.WebCam;
using RIS.Operational.Translator;

namespace RIS.Forms.Order
{
    public partial class PatientRegistration : Form
    {
        MyMessageBox mmb = new MyMessageBox();
        DataTable table_select = new DataTable();
        UUL.ControlFrame.Controls.TabControl CloseControl;
        string lastisAdded = "";

        NationalIDCard nationalID;
        Capture cam;
        IntPtr m_ip = IntPtr.Zero;
        uint _context;

        bool saving = false;

        public PatientRegistration(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
            CloseControl = tabcontrol;

            stripBtnYellow.Visible = true;
            stripBtnRed.Visible = false;
            stripBtnGreen.Visible = false;

            bgWorker1.RunWorkerAsync();
        }

        public PatientRegistration(UUL.ControlFrame.Controls.TabControl tabcontrol, NidNationalIdMagneticCardDataType data)
        {
            InitializeComponent();
            CloseControl = tabcontrol;

            stripBtnYellow.Visible = true;
            stripBtnRed.Visible = false;
            stripBtnGreen.Visible = false;

            GetDataFromOrder(data);

            bgWorker1.RunWorkerAsync();
        }

        private void GBL_SF14_Load(object sender, EventArgs e)
        {
            //txtSearchRegID.Focus();
            txtSearchHN.Focus();
            dedDOB.Tag = false;

            AddItemIntoComboBox();
        }

        private void txtRegID_TextChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit sd = sender as DevExpress.XtraEditors.TextEdit;

            HISRegistration hisreg = new HISRegistration();
            ProcessGetPatientRegistration selectpt = new ProcessGetPatientRegistration();
            hisreg.HN = "";
            try { hisreg.REG_ID = Int32.Parse(sd.Text); }
            catch (Exception) { hisreg.REG_ID = 0; }
            selectpt.HISRegistration = hisreg;
            selectpt.Invoke();
            table_select = selectpt.DataResult.Tables[0];

            if (table_select.Rows.Count > 0 && txtSearchRegID.Text.Trim().Length > 0)
            {
                textbox_setting();
            }
            else if(btnUpdate.Text == "Save")
            {
                textbox_setting();
            }
            else
            {
                textbox_clearing();
                table_select.Rows.Clear();
                pictureBox1.Image = null;
            }
        }

        private void txtHN_TextChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

            HISRegistration hisreg = new HISRegistration();
            ProcessGetPatientRegistration selectpt = new ProcessGetPatientRegistration();
            hisreg.HN = sd.Text;
            hisreg.REG_ID = 0;
            selectpt.HISRegistration = hisreg;
            selectpt.Invoke();
            table_select = selectpt.DataResult.Tables[0];

            if (table_select.Rows.Count > 0 && txtSearchHN.Text.Trim().Length > 0)
            {
                textbox_setting();
            }
            else
            {
                textbox_clearing();
                table_select.Clear();
                pictureBox1.Image = null;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(simpleButton1_Click1);

            string qry = @"
                        select
                            INSURANCE_TYPE_ID,
                            INSURANCE_TYPE_UID,
	                        INSURANCE_TYPE_DESC
                        from
	                        RIS_INSURANCETYPE
                        where INSURANCE_TYPE_ID like '%%' OR INSURANCE_TYPE_UID like '%%' OR INSURANCE_TYPE_DESC like '%%'
                        order by INSURANCE_TYPE_ID asc 
                            ";

            string fields = "Insurance ID, Insurance Alias, Insurance Description";
            string con = "";
            lv.getData(qry, fields, con, "Insurance List");
            lv.Show();
        }
        private void simpleButton1_Click1(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtInsuranceType.Text = retValue[1];
            txtInsuranceType.Tag = retValue[0];
            txtInsuranceDescription.Text = retValue[2];
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(simpleButton2_Click1);

            string qry = @"
                        select
                            REG_ID,
                            HN,
	                        (ISNULL(TITLE,'')+' '+ISNULL(FNAME,'')+' '+ISNULL(MNAME,'')+' '+ISNULL(LNAME,'')) AS NAME
                        from
	                        HIS_REGISTRATION
                        where HN like '%%' OR REG_ID like '%%' OR
                              TITLE like '%%' OR FNAME like '%%' OR MNAME like '%%' OR LNAME like '%%'
                        order by REG_ID asc
                            ";

            string fields = "Patient ID, Patient HN, Patient NAME";
            string con = "";
            lv.getData(qry, fields, con, "Patient List");
            lv.Show();
        }
        private void simpleButton2_Click1(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtSearchRegID.Text = retValue[0];
            txtSearchHN.Text = retValue[1];
        }

        private void textbox_clearing()
        {
            //Start Patient Demographic
            txtRegID.Text = "";
            txtHN.Text = "";
            dedRegDate.Text = "";
            checkEdit1.Checked = false;

            txtTitle.Text = "";
            txtFname.Text = "";
            txtMname.Text = "";
            txtLname.Text = "";

            txtTitleEng.Text = "";
            txtFnameEng.Text = "";
            txtMnameEng.Text = "";
            txtLnameEng.Text = "";

            txtSSN.Text = "";

            cbbMarritalStatus.SelectedIndex = -1;

            cbbGender.SelectedIndex = -1;

            dedDOB.Text = "";
            spinAge.Text = "";

            cbbBloodGroup.SelectedIndex = -1;

            txtNationality.Text = "";
            txtPassportNo.Text = "";
            //End Patient Demographic

            //Start Contact Information
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtEmail.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtAddress4.Text = "";
            txtAddress5.Text = "";
            //End Contact Information

            //Start Emergency Contact Information
            txtEmContactPerson.Text = "";
            txtEmAddress.Text = "";
            txtEmPhone.Text = "";
            txtEmRelation.Text = "";
            //End Emergency Contact Information

            //Start Miscellaneous
            txtAllergies.Text = "";
            txtInsuranceType.Text = "";
            txtInsuranceDescription.Text = "";
            //End Miscellaneous
        }

        private void textbox_Enable(bool enable)
        {
            //Start Patient Search
            txtSearchRegID.Enabled = !enable;
            txtSearchHN.Enabled = !enable;
            simpleButton2.Enabled = !enable;
            //End Patient Search

            //Start Patient Demographic
            txtRegID.Enabled = enable;
            txtHN.Enabled = enable;
            dedRegDate.Enabled = enable;

            txtTitle.Enabled = enable;
            txtFname.Enabled = enable;
            txtMname.Enabled = enable;
            txtLname.Enabled = enable;

            txtTitleEng.Enabled = enable;
            txtFnameEng.Enabled = enable;
            txtMnameEng.Enabled = enable;
            txtLnameEng.Enabled = enable;

            txtSSN.Enabled = enable;

            cbbMarritalStatus.Enabled = enable;

            cbbGender.Enabled = enable;

            dedDOB.Enabled = enable;
            spinAge.Enabled = enable;

            cbbBloodGroup.Enabled = enable;

            txtNationality.Enabled = enable;
            txtPassportNo.Enabled = enable;
            //End Patient Demographic

            //Start Contact Information
            txtPhone1.Enabled = enable;
            txtPhone2.Enabled = enable;
            txtEmail.Enabled = enable;
            txtAddress1.Enabled = enable;
            txtAddress2.Enabled = enable;
            txtAddress3.Enabled = enable;
            txtAddress4.Enabled = enable;
            txtAddress5.Enabled = enable;
            //End Contact Information

            //Start Emergency Contact Information
            txtEmContactPerson.Enabled = enable;
            txtEmAddress.Enabled = enable;
            txtEmPhone.Enabled = enable;
            txtEmRelation.Enabled = enable;
            //End Emergency Contact Information

            //Start Miscellaneous
            txtAllergies.Enabled = enable;
            txtInsuranceType.Enabled = enable;
            txtInsuranceDescription.Enabled = enable;
            simpleButton1.Enabled = enable;
            //End Miscellaneous
        }

        private void textbox_setting()
        {
            try
            {
                textbox_clearing();

                if (table_select.Rows.Count <= 0)
                    return;
                DataRow row = table_select.Rows[0];

                //Start Patient Demographic
                txtRegID.Text = row["REG_ID"].ToString();
                txtHN.Text = row["HN"].ToString();
                if (row["IS_DELETED"].ToString() == "Y" || row["IS_UPDATED"].ToString() == "Y")
                {
                    checkEdit1.Checked = false;
                }
                else
                {
                    checkEdit1.Checked = true;
                }

                try { dedRegDate.DateTime = (DateTime)row["REG_DT"]; }
                catch (Exception) { dedRegDate.Text = ""; }

                txtTitle.Text = row["TITLE"].ToString();
                txtFname.Text = row["FNAME"].ToString();
                txtMname.Text = row["MNAME"].ToString();
                txtLname.Text = row["LNAME"].ToString();

                txtTitleEng.Text = row["TITLE_ENG"].ToString();
                txtFnameEng.Text = row["FNAME_ENG"].ToString();
                txtMnameEng.Text = row["MNAME_ENG"].ToString();
                txtLnameEng.Text = row["LNAME_ENG"].ToString();

                txtSSN.Text = row["SSN"].ToString();

                if (row["MARITAL_STATUS"].ToString() == "M")
                    cbbMarritalStatus.SelectedIndex = 0;
                else if (row["MARITAL_STATUS"].ToString() == "S")
                    cbbMarritalStatus.SelectedIndex = 1;
                else if (row["MARITAL_STATUS"].ToString() == "")
                    cbbMarritalStatus.SelectedIndex = -1;

                if (row["GENDER"].ToString() == "M")
                    cbbGender.SelectedIndex = 0;
                else if (row["GENDER"].ToString() == "F")
                    cbbGender.SelectedIndex = 1;
                else
                    cbbGender.SelectedIndex = -1;

                try
                {
                    dedDOB.DateTime = (DateTime)row["DOB"];
                }
                catch
                { 
                    
                }

                try
                {
                    //dedDOB.DateTime = (DateTime)row["DOB"];
                    //int dob = DateTime.Now.Year - dedDOB.DateTime.Year;
                    //spinAge.Text = dob.ToString();
                    spinAge.Text = row["AGE"].ToString();
                }
                catch (Exception)
                {
                    spinAge.Text = "";
                }

             

                if (row["BLOOD_GROUP"].ToString() == "A+")
                    cbbBloodGroup.SelectedIndex = 0;
                else if (row["BLOOD_GROUP"].ToString() == "A-")
                    cbbBloodGroup.SelectedIndex = 1;
                else if (row["BLOOD_GROUP"].ToString() == "B+")
                    cbbBloodGroup.SelectedIndex = 2;
                else if (row["BLOOD_GROUP"].ToString() == "B-")
                    cbbBloodGroup.SelectedIndex = 3;
                else if (row["BLOOD_GROUP"].ToString() == "AB+")
                    cbbBloodGroup.SelectedIndex = 4;
                else if (row["BLOOD_GROUP"].ToString() == "AB-")
                    cbbBloodGroup.SelectedIndex = 5;
                else if (row["BLOOD_GROUP"].ToString() == "O+")
                    cbbBloodGroup.SelectedIndex = 6;
                else if (row["BLOOD_GROUP"].ToString() == "O-")
                    cbbBloodGroup.SelectedIndex = 7;
                else
                    cbbBloodGroup.SelectedIndex = -1;

                txtNationality.Text = row["NATIONALITY"].ToString();
                txtPassportNo.Text = row["PASSPORT_NO"].ToString();
                //End Patient Demographic

                //Start Contact Information
                txtPhone1.Text = row["PHONE1"].ToString();
                txtPhone2.Text = row["PHONE2"].ToString();
                txtEmail.Text = row["EMAIL"].ToString();
                txtAddress1.Text = row["ADDR1"].ToString();
                txtAddress2.Text = row["ADDR2"].ToString();
                txtAddress3.Text = row["ADDR3"].ToString();
                txtAddress4.Text = row["ADDR4"].ToString();
                txtAddress5.Text = row["ADDR5"].ToString();
                //End Contact Information

                //Start Emergency Contact Information
                txtEmContactPerson.Text = row["EM_CONTACT_PERSON"].ToString();
                txtEmAddress.Text = row["EM_ADDR"].ToString();
                txtEmPhone.Text = row["EM_PHONE"].ToString();
                txtEmRelation.Text = row["EM_RELATION"].ToString();
                //End Emergency Contact Information

                //Start Miscellaneous
                txtAllergies.Text = row["ALLERGIES"].ToString();
                txtInsuranceType.Text = row["INSURANCE_TYPE"].ToString();
                txtInsuranceDescription.Text = row["INSURANCE_TYPE_DESC"].ToString();
                //Image im;
                try
                {
                    ImageConverter imcon = new ImageConverter();
                    pictureBox1.Image = (Image)imcon.ConvertFrom(row["Picture"]);
                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                }
                //pictureBox1.Image = (Image)row["INSURANCE_TYPE"];
                //End Miscellaneous

                //STOP();
                //Activate();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                textbox_clearing();
                textbox_Enable(true);

                dedRegDate.DateTime = DateTime.Now;
                dedRegDate.Enabled = false;

                btnAdd.Text = "Save";
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                dedRegDate.DateTime = DateTime.Now;

                txtHN.Text = "AUTO";
                txtHN.Enabled = false;

                txtHN.Focus();
                lastisAdded = "";

                saving = true;
            }
            else
            {
                if (mmb.ShowAlert("UID1019", 2) == "2")
                {
                    HISRegistration hisreg = new HISRegistration();

                    if (txtHN.Text == "" || txtFname.Text.Trim() == "")
                    { mmb.ShowAlert("UID2001", 1); txtFname.Focus(); return; }

                    hisreg.HN = txtHN.Text.Trim();
                    hisreg.REG_DT = DateTime.Now;

                    hisreg.TITLE = txtTitle.Text;
                    hisreg.FNAME = txtFname.Text;
                    hisreg.MNAME = txtMname.Text;
                    hisreg.LNAME = txtLname.Text;

                    hisreg.TITLE_ENG = txtTitleEng.Text;
                    hisreg.FNAME_ENG = txtFnameEng.Text;
                    hisreg.MNAME_ENG = txtMnameEng.Text;
                    hisreg.LNAME_ENG = txtLnameEng.Text;

                    hisreg.SSN = txtSSN.Text;
                    hisreg.NATIONALITY = txtNationality.Text;
                    hisreg.MARITAL_STATUS = cbbMarritalStatus.Text;
                    hisreg.PASSPORT_NO = txtPassportNo.Text;

                    hisreg.GENDER = cbbGender.Text;
                    hisreg.DOB = dedDOB.DateTime;
                    try { hisreg.AGE = int.Parse(spinAge.Text); }
                    catch (Exception) { }
                    hisreg.BLOOD_GROUP = cbbBloodGroup.Text;

                    hisreg.PHONE1 = txtPhone1.Text;
                    hisreg.PHONE2 = txtPhone2.Text;
                    hisreg.EMAIL = txtEmail.Text;
                    hisreg.ADDR1 = txtAddress1.Text;
                    hisreg.ADDR2 = txtAddress2.Text;
                    hisreg.ADDR3 = txtAddress3.Text;
                    hisreg.ADDR4 = txtAddress4.Text;
                    hisreg.ADDR5 = txtAddress5.Text;

                    hisreg.EM_CONTACT_PERSON = txtEmContactPerson.Text;
                    hisreg.EM_ADDR = txtEmAddress.Text;
                    hisreg.EM_PHONE = txtEmPhone.Text;
                    hisreg.EM_RELATION = txtEmRelation.Text;

                    hisreg.ALLERGIES = txtAllergies.Text;
                    hisreg.INSURANCE_TYPE = txtInsuranceType.Text;

                    try
                    {
                        ImageConverter imcon = new ImageConverter();
                        hisreg.Picture = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    }
                    catch
                    {
                        //env.Image = null;
                    }

                    ProcessAddPatientRegistration add = new ProcessAddPatientRegistration();
                    add.HISRegistration = hisreg;
                    add.Invoke();

                    if (add.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        mmb.ShowAlert("UID2009", 1);
                        //txtHN.Focus();
                        txtTitle.Focus();
                        return;
                    }

                    mmb.ShowAlert("UID2044", 2);

                    textbox_clearing();
                    //txtHN.Focus();
                    txtTitle.Focus();
                    dedRegDate.DateTime = DateTime.Now;

                    txtHN.Text = "AUTO";

                    lastisAdded = hisreg.HN;

                    saving = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (table_select.Rows.Count < 1) return;

            if (btnUpdate.Text == "Edit")
            {
                if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
                {
                    mmb.ShowAlert("UID2010", 1);
                    string str = mmb.ShowAlert("UID2011", 1);
                    if (str == "1") 
                        return;

                    checkEdit1.Checked = true;
                }

                textbox_Enable(true);
                dedRegDate.Enabled = false;

                btnUpdate.Text = "Save";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                txtHN.Enabled = true;

                txtHN.Focus();
            }
            else
            {
                if (mmb.ShowAlert("UID1019", 2) == "2")
                {
                    HISRegistration hisreg = new HISRegistration();

                    if (txtHN.Text == "" || txtFname.Text.Trim() == "")
                    { mmb.ShowAlert("UID2001", 1); txtFname.Focus(); return; }

                    hisreg.REG_ID = int.Parse(txtRegID.Text);
                    hisreg.HN = txtHN.Text;
                    hisreg.REG_DT = dedRegDate.DateTime;

                    hisreg.TITLE = txtTitle.Text;
                    hisreg.FNAME = txtFname.Text;
                    hisreg.MNAME = txtMname.Text;
                    hisreg.LNAME = txtLname.Text;

                    hisreg.TITLE_ENG = txtTitleEng.Text;
                    hisreg.FNAME_ENG = txtFnameEng.Text;
                    hisreg.MNAME_ENG = txtMnameEng.Text;
                    hisreg.LNAME_ENG = txtLnameEng.Text;

                    hisreg.SSN = txtSSN.Text;
                    hisreg.NATIONALITY = txtNationality.Text;
                    hisreg.MARITAL_STATUS = cbbMarritalStatus.Text;
                    hisreg.PASSPORT_NO = txtPassportNo.Text;

                    hisreg.GENDER = cbbGender.Text;
                    hisreg.DOB = dedDOB.DateTime;
                    try { hisreg.AGE = int.Parse(spinAge.Text); }
                    catch (Exception) { }
                    hisreg.BLOOD_GROUP = cbbBloodGroup.Text;

                    hisreg.PHONE1 = txtPhone1.Text;
                    hisreg.PHONE2 = txtPhone2.Text;
                    hisreg.EMAIL = txtEmail.Text;
                    hisreg.ADDR1 = txtAddress1.Text;
                    hisreg.ADDR2 = txtAddress2.Text;
                    hisreg.ADDR3 = txtAddress3.Text;
                    hisreg.ADDR4 = txtAddress4.Text;
                    hisreg.ADDR5 = txtAddress5.Text;

                    hisreg.EM_CONTACT_PERSON = txtEmContactPerson.Text;
                    hisreg.EM_ADDR = txtEmAddress.Text;
                    hisreg.EM_PHONE = txtEmPhone.Text;
                    hisreg.EM_RELATION = txtEmRelation.Text;

                    hisreg.ALLERGIES = txtAllergies.Text;
                    hisreg.INSURANCE_TYPE = txtInsuranceType.Text;

                    try
                    {
                        ImageConverter imcon = new ImageConverter();
                        hisreg.Picture = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    }
                    catch
                    {
                        //env.Image = null;
                    }

                    ProcessUpdatePatientRegistration update = new ProcessUpdatePatientRegistration();
                    update.HISRegistration = hisreg;
                    update.Invoke();

                    if (update.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        mmb.ShowAlert("UID2009", 1);
                        txtHN.Focus();
                        return;
                    }
                    else
                    {
                        mmb.ShowAlert("UID2044", 2);
                    }


                    //CancelMethod Statement
                    textbox_Enable(false);
                    txtRegID_TextChanged(txtRegID as object, new EventArgs());
                    textbox_setting();


                    btnAdd.Text = "Add";
                    btnUpdate.Text = "Edit";
                    btnDelete.Text = "Delete";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = false;
                    //CancelMethod Statement
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (table_select.Rows.Count < 1) return;

            if (btnDelete.Text == "Delete")
            {
                if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
                {
                    mmb.ShowAlert("UID2012", 1);
                    return;
                }

                string str = mmb.ShowAlert("UID2003", 1);
                if (str == "2")
                {
                    HISRegistration hisreg = new HISRegistration();
                    hisreg.REG_ID = int.Parse(txtRegID.Text);

                    ProcessDeletePatientRegistration delete = new ProcessDeletePatientRegistration();
                    delete.HISRegistration = hisreg;
                    delete.Invoke();

                    //Modified at 2008/8/14
                    txtRegID_TextChanged(txtRegID as object, new EventArgs());
                    textbox_setting();
                }
            }
            else
            { 
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Save" && lastisAdded.Trim().Length>0)
            {
                HISRegistration hisreg = new HISRegistration();
                ProcessGetPatientRegistration selectpt = new ProcessGetPatientRegistration();
                hisreg.HN = lastisAdded;
                hisreg.REG_ID = 0;
                selectpt.HISRegistration = hisreg;
                selectpt.Invoke();
                table_select = selectpt.DataResult.Tables[0];
            }

            textbox_setting();
            textbox_Enable(false);

            btnAdd.Text = "Add";
            btnUpdate.Text = "Edit";
            btnDelete.Text = "Delete";

            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            txtSearchRegID.Focus();

            saving = false;

            //txtRegID_TextChanged(new object(), new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void dedDOB_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DevExpress.XtraEditors.DateEdit sd = sender as DevExpress.XtraEditors.DateEdit;
            //string[] date = sd.Text.Split('/');

            if (e.Value == null || e.Value.ToString() == "")
            {
                sd.Text = string.Empty;
                spinAge.Focus();
            }
            else
            {
                sd.DateTime = (DateTime)e.Value;
                int dob = DateTime.Now.Year - sd.DateTime.Year;
                spinAge.Text = dob.ToString();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)&&e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void dedDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            DevExpress.XtraEditors.DateEdit sd = sender as DevExpress.XtraEditors.DateEdit;

            if (e.KeyChar == 13 && !(bool)sd.Tag)
            {
                sd.ShowPopup();
                sd.Tag = true;
            }
            else if ((bool)sd.Tag)
            {
                sd.CancelPopup();
                sd.Tag = false;
            }

            dedDOB_KeyPress(e);
        }

        private void dedDOB_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.DateEdit sd = (DevExpress.XtraEditors.DateEdit)sender;
            sd.DateTime = DateTime.Parse(sd.Text);
            int numdob = DateTime.Now.Year-sd.DateTime.Year;
            spinAge.Text = numdob.ToString();
        }

        private void ThaiText_Validated(object sender, EventArgs e)
        {        
            DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

            if (sd.Text.Trim().Length > 0)
            {
                try
                {
                    if (sd.Name == "txtTitle")
                    {
                        //txtTitleEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
                    }
                    else if (sd.Name == "txtFname")
                    {
                        txtFnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
                        if (txtFnameEng.Text.Length > 0)
                        {
                            string firstLetter = txtFnameEng.Text.Substring(0, 1);
                            string firstUpper = firstLetter.ToUpper();
                            string firstDelete = txtFnameEng.Text.Remove(0, 1);
                            txtFnameEng.Text = firstUpper + firstDelete;
                        }
                    }
                    else if (sd.Name == "txtMname")
                    {
                        txtMnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
                        if (txtMnameEng.Text.Length > 0)
                        {
                            string firstLetter = txtMnameEng.Text.Substring(0, 1);
                            string firstUpper = firstLetter.ToUpper();
                            string firstDelete = txtMnameEng.Text.Remove(0, 1);
                            txtMnameEng.Text = firstUpper + firstDelete;
                        }
                    }
                    else if (sd.Name == "txtLname")
                    {
                        txtLnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
                        if (txtLnameEng.Text.Length > 0)
                        {
                            string firstLetter = txtLnameEng.Text.Substring(0, 1);
                            string firstUpper = firstLetter.ToUpper();
                            string firstDelete = txtLnameEng.Text.Remove(0, 1);
                            txtLnameEng.Text = firstUpper + firstDelete;
                        }
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Can not translate to eng language", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
                }
            }
        }

        #region ENTER_KeyPress

        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTitle.Focus();
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtFname.Focus();
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMname.Focus();
        }

        private void txtMname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtLname.Focus();
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cbbGender.Focus();
        }

        private void cbbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTitleEng.Focus();
        }

        private void txtTitleEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtFnameEng.Focus();
        }

        private void txtFnameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMnameEng.Focus();
        }

        private void txtMnameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtLnameEng.Focus();
        }

        private void txtLnameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dedDOB.Focus();
        }

        private void dedDOB_KeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSSN.Focus();
        }

        private void txtSSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cbbMarritalStatus.Focus();
        }

        private void cbbMarritalStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNationality.Focus();
        }

        private void spinAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNationality.Focus();
            else
            { 

            }

        }

        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPassportNo.Focus();
        }

        private void txtPassportNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cbbBloodGroup.Focus();
        }

        private void cbbBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPhone1.Focus();
        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPhone2.Focus();
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmail.Focus();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAddress1.Focus();
        }

        private void txtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAddress2.Focus();
        }

        private void txtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAddress3.Focus();
        }

        private void txtAddress3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAddress4.Focus();
        }

        private void txtAddress4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAddress5.Focus();
        }

        private void txtAddress5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmContactPerson.Focus();
        }

        private void txtEmContactPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmAddress.Focus();
        }

        private void txtEmAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmPhone.Focus();
        }

        private void txtEmPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtEmRelation.Focus();
        }

        private void txtEmRelation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtAllergies.Focus();
        }

        private void txtAllergies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                simpleButton1.Focus();
        }

        #endregion ENTER_KeyPress

        private string ResultCodeToString(ResultCodeTypes resultCode)
        {
            string result = "";

            switch (resultCode)
            {
                case ResultCodeTypes.GeneralFail:
                    result = "พบข้อผิดพลาดที่ไม่สามารถระบุได้.";
                    break;

                case ResultCodeTypes.InvalidContext:
                    result = "context ไม่ถูกต้อง";
                    break;

                case ResultCodeTypes.ActivationFail:
                    result = "พบข้อผิดพลาดในการลงทะเบียน";
                    break;

                case ResultCodeTypes.ModuleNotActivate:
                    result = "ยังไม่มีการลงทะเบียน";
                    break;
            };

            return result;
        }

        #region oldCode
        //private void InitialDevice()
        //{
        //    NationalIdCardSdkWrapper.InitializeModule();

        //    ResultCodeTypes result = NationalIdCardSdkWrapper.CreateContext(out _context);
        //    if (ResultCodeTypes.OK == result)
        //    {
        //        uint major = 0;
        //        uint minor = 0;
        //        uint release = 0;
        //        uint build = 0;

        //        NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
        //        NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
        //    }
        //    else
        //    {
        //        // If function fail then show error message.
        //        //throw new Exception(this.ResultCodeToString(result));
        //        MessageBox.Show(this.ResultCodeToString(result));
        //    };

        //    result = NationalIdCardSdkWrapper.SetCommPortNumber(_context, 0);
        //    if (ResultCodeTypes.OK == result)
        //    {
        //        Int32 port_number = 0;
        //        NationalIdCardSdkWrapper.GetCommPortNumber(_context, ref port_number);

        //        if (0 == port_number)
        //        {
        //            //"ไม่สามารถกำหนดหมายเลขพอร์ทได้";
        //            //throw new Exception("ไม่สามารถกำหนดหมายเลขพอร์ทได้");
        //            MessageBox.Show("ไม่สามารถกำหนดหมายเลขพอร์ทได้");
        //        }
        //        else
        //        {

        //        }
        //    }
        //    else
        //    {
        //        //throw new Exception(this.ResultCodeToString(result));
        //        MessageBox.Show(this.ResultCodeToString(result));
        //    }

        //    result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1");
        //    if (result == ResultCodeTypes.OK)
        //    {
        //        // Add delegate for handling data comming from card reader.
        //        //NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);
        //        NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(NationalIDCardSDKWrapper_OnReceiveData);

        //        // Start card reader.
        //        result = NationalIdCardSdkWrapper.StartReadCard(_context);
        //        if (result == ResultCodeTypes.OK)
        //        {
        //            //"เริ่มการทำงาน"
        //        }
        //        else
        //        {
        //            //throw new Exception(this.ResultCodeToString(result));
        //            MessageBox.Show(this.ResultCodeToString(result));
        //        };
        //    }
        //    else
        //    {
        //        //throw new Exception(this.ResultCodeToString(result));
        //        MessageBox.Show(this.ResultCodeToString(result));
        //    };
        //}
        
        //private void STOP()
        //{
        //    ResultCodeTypes result = (ResultCodeTypes)NationalIdCardSdkWrapper.StopReadCard(_context);
        //    NationalIdCardSdkWrapper.OnReceiveNationalIdCardData -= new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);        
        //}
        //private void Avtivate()
        //{
        //    ResultCodeTypes result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1");
        //    result = NationalIdCardSdkWrapper.StartReadCard(_context);
        //    NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);        
        //}
        
        
        //private void NationalIDCardSDKWrapper_OnReceiveData(NidNationalIdMagneticCardDataType nationalIdCardData)
        //{
        //    //throw new Exception("The method or operation is not implemented.");

        //    NidNationalIdMagneticCardDataType IDCdata = nationalIdCardData;

        //    string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
        //    DataTable datatable = new DataTable("HIS_REGISTRATION");

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        adapter.SelectCommand = new SqlCommand();
        //        adapter.SelectCommand.Connection = connection;
        //        adapter.SelectCommand.CommandText = @"select * from HIS_REGISTRATION";
        //        adapter.SelectCommand.CommandType = CommandType.Text;
        //        adapter.Fill(datatable);
        //    }
        //    table_select = datatable.Clone();

        //    table_select.Rows.Clear();
        //    DataRow row = table_select.NewRow();

        //    //row["REG_ID"];
        //    //row["HN"];

        //    //row["IS_DELETED"];//"Y" or "N"
        //    //row["IS_UPDATED"];//"Y" or "N"

        //    row["REG_DT"] = new DateTime
        //                            (
        //                                DateTime.Now.ToLocalTime().Year,
        //                                DateTime.Now.ToLocalTime().Month,
        //                                DateTime.Now.ToLocalTime().Day
        //                            );
        //    dedRegDate.DateTime = (DateTime)row["REG_DT"];
        //    //class DateTime type

        //    row["TITLE"] = IDCdata.Prefix;
        //    txtTitle.Text = row["TITLE"].ToString();
        //    row["FNAME"] = IDCdata.FirstName;
        //    txtFname.Text = row["FNAME"].ToString();
        //    //row["MNAME"];
        //    row["LNAME"] = IDCdata.LastName;
        //    txtLname.Text = row["LNAME"].ToString();

        //    //row["TITLE_ENG"];
        //    //row["FNAME_ENG"];
        //    //row["MNAME_ENG"];
        //    //row["LNAME_ENG"];

        //    row["SSN"] = IDCdata.IdCardNumber;
        //    txtSSN.Text = row["SSN"].ToString();

        //    //row["MARITAL_STATUS"];//"M" or "S" or ""

        //    row["GENDER"] = IDCdata.Gender;//"M" or "F" or ""

        //    if (row["GENDER"].ToString() == "M")
        //        cbbGender.SelectedIndex = 0;
        //    else if (row["GENDER"].ToString() == "F")
        //        cbbGender.SelectedIndex = 1;
        //    else
        //        cbbGender.SelectedIndex = -1;

        //    int year = Convert.ToInt32(IDCdata.BirthYear);
        //    int month = Convert.ToInt32(IDCdata.BirthMonth);
        //    int day = Convert.ToInt32(IDCdata.BirthDay);
        //    //row["DOB"] = new DateTime(year, month, day);//class DateTime type;

        //    //row["BLOOD_GROUP"];//"A+","A-","B+","B-","AB+","AB-","O+","O-"

        //    //row["NATIONALITY"];//
        //    //row["PASSPORT_NO"];//

        //    row["PHONE1"] = IDCdata.HomeNumber;

        //    txtPhone1.Text = row["PHONE1"].ToString();
        //    //row["PHONE2"];
        //    //row["EMAIL"];
        //    row["ADDR1"] = IDCdata.FullAddress;
        //    txtAddress1.Text = row["ADDR1"].ToString();
        //    //row["ADDR2"];
        //    //row["ADDR3"];
        //    //row["ADDR4"];
        //    //row["ADDR5"];

        //    //row["EM_CONTACT_PERSON"];
        //    //row["EM_ADDR"];
        //    //row["EM_PHONE"];
        //    //row["EM_RELATION"];

        //    //row["ALLERGIES"];
        //    //row["INSURANCE_TYPE"];
        //    //row["INSURANCE_TYPE_DESC"];


        //    //table_select.Rows.Add(row);

        //    //textbox_setting();
        //}
        #endregion oldCOde

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            btnWebCam.Enabled = false;

            if (btnWebCam.Tag.ToString() == "0")
            {
                
                try
                {
                    const int VIDEODEVICE = 0; // zero based index of video capture device to use
                    const int VIDEOWIDTH = 320;//640; // Depends on video device caps
                    const int VIDEOHEIGHT = 240;//480; // Depends on video device caps
                    const int VIDEOBITSPERPIXEL = 64;//24; // BitsPerPixel values determined by device

                    cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, pictureBox2);

                    btnWebCam.Tag = 1;
                    btnWebCam.Text = "Save Picture";
                    //pictureBox2.Visible = true;
                    //pictureBox1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btnWebCam.Tag.ToString() == "1")
            {
                try
                {
                    
                    Cursor.Current = Cursors.WaitCursor;

                    // Release any previous buffer
                    if (m_ip != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(m_ip);
                        m_ip = IntPtr.Zero;
                    }

                    // capture image
                    m_ip = cam.Click();
                    Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

                    // If the image is upsidedown
                    b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    pictureBox1.Image = b;

                    Cursor.Current = Cursors.Default;

                    cam.Dispose();

                    if (m_ip != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(m_ip);
                        m_ip = IntPtr.Zero;
                    }

                    //pictureBox2.Visible = false;
                    //pictureBox1.Visible = true;
                    btnWebCam.Text = "Capture";
                    btnWebCam.Tag = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            btnWebCam.Enabled = true;

            //if (simpleButton3.Tag == null)
            //{
            //    if (!webCamPanelControl1.START_WEBCAM())
            //        this.Close();

            //    simpleButton3.Tag = true;
            //}
            //else
            //{
            //    if (!webCamPanelControl1.START_CAPTURE())
            //        this.Close();

            //    simpleButton3.Tag = null;
            //}
        }

        private void GBL_SF14_FormClosing(object sender, FormClosingEventArgs e)
        {
           //bool bl =  webCamPanelControl1.STOP_WEBCAM();

           //nationalID.Closing();
        }

        //Modify at 20Jan09
        private void nationalID_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");

            if (!saving) return;

            NidNationalIdMagneticCardDataType IDCdata = e.NewValue;

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable("HIS_REGISTRATION");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @"select * from HIS_REGISTRATION where REG_ID = 0";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
            }

            DataTable table = new DataTable();

            table = datatable.Clone();

            table.Rows.Clear();


            DataRow row = table.NewRow();

            //row["REG_ID"];
            //row["HN"] = IDCdata.IdCardNumber;
            //txtHN.Text = row["HN"].ToString();

            //row["IS_DELETED"];//"Y" or "N"
            //row["IS_UPDATED"];//"Y" or "N"

            row["REG_DT"] = new DateTime
                                    (
                                        DateTime.Now.ToLocalTime().Year,
                                        DateTime.Now.ToLocalTime().Month,
                                        DateTime.Now.ToLocalTime().Day
                                    );
            dedRegDate.DateTime = (DateTime)row["REG_DT"];
            //class DateTime type

            row["TITLE"] = IDCdata.Prefix;
            txtTitle.Text = row["TITLE"].ToString();
            row["FNAME"] = IDCdata.FirstName;
            txtFname.Text = row["FNAME"].ToString();
            //row["MNAME"];
            row["LNAME"] = IDCdata.LastName;
            txtLname.Text = row["LNAME"].ToString();

            try
            {
                txtTitleEng.Text = TransToEnglish.Trans(row["TITLE"].ToString());
                txtFnameEng.Text = TransToEnglish.Trans(row["FNAME"].ToString());
                txtLnameEng.Text = TransToEnglish.Trans(row["LNAME"].ToString());
            }
            catch { }

            //row["TITLE_ENG"];
            //row["FNAME_ENG"];
            //row["MNAME_ENG"];
            //row["LNAME_ENG"];

            row["SSN"] = IDCdata.IdCardNumber;
            txtSSN.Text = row["SSN"].ToString();

            //row["MARITAL_STATUS"];//"M" or "S" or ""

            row["GENDER"] = IDCdata.Gender.StartsWith("ช")?"M":"F";//"M" or "F" or ""
            if (row["GENDER"].ToString() == "M")
                cbbGender.SelectedIndex = 0;
            else if (row["GENDER"].ToString() == "F")
                cbbGender.SelectedIndex = 1;
            else
                cbbGender.SelectedIndex = -1;

            try
            {
                int year = Convert.ToInt32(IDCdata.BirthYear);
                int month = Convert.ToInt32(IDCdata.BirthMonth);
                int day = Convert.ToInt32(IDCdata.BirthDay);

                dedDOB.DateTime = new DateTime(year, month, day).ToLocalTime();
                spinAge.Text = IDCdata.Age.ToString();
            }
            catch { }

            //row["BLOOD_GROUP"];//"A+","A-","B+","B-","AB+","AB-","O+","O-"

            //row["NATIONALITY"];//
            //row["PASSPORT_NO"];//

            //row["PHONE1"] = IDCdata.;
            //txtPhone1.Text = row["PHONE1"].ToString();
            //row["PHONE2"];
            //row["EMAIL"];
            //row["ADDR1"] = ;
            txtAddress1.Text = IDCdata.HomeNumber;

            row["ADDR2"] = IDCdata.Soi;
            txtAddress2.Text = row["ADDR2"].ToString();

            row["ADDR3"] = IDCdata.Tt;
            txtAddress3.Text = row["ADDR3"].ToString();

            row["ADDR4"] = IDCdata.Aa;
            txtAddress4.Text = row["ADDR4"].ToString();

            row["ADDR5"] = IDCdata.Cc;
            txtAddress5.Text = row["ADDR5"].ToString();


            //row["EM_CONTACT_PERSON"];
            //row["EM_ADDR"];
            //row["EM_PHONE"];
            //row["EM_RELATION"];

            //row["ALLERGIES"];
            //row["INSURANCE_TYPE"];
            //row["INSURANCE_TYPE_DESC"];


            //table_select.Rows.Add(row);

            //textbox_setting();
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            //while (true)
            //{
            //    Thread.Sleep(5000);
                
            //    if (!IDCard.DeviceChecking())
            //    {
            //        MessageBox.Show(IDCard.ErrorReport, "Error Reporting");
            //    }
            //    else
            //    {
            //        if (!IDCard.ModuleActivated(IDCard.Activatation_Keys[0]))
            //        {
            //            MessageBox.Show(IDCard.ErrorReport, "Error Reporting");
            //        }
            //        else
            //        {
            //            bgWorker1.ReportProgress(0);
            //            break;
            //        }
            //    }
            //}
            //IDCard.Invoke();
            bgWorker1.ReportProgress(1);
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                //lbSearching.Visible = false;
                //lbConnected.Visible = true;
            }
            else if (e.ProgressPercentage == 1)
            {
                try
                {
                    //btnDeviceStatus.BackColor = Color.Yellow;

                    stripBtnYellow.Visible = true;
                    stripBtnRed.Visible = false;
                    stripBtnGreen.Visible = false;

                    //Thread.Sleep(10000);

                    //PatientRegistration_ActivateDialog pt = new PatientRegistration_ActivateDialog();
                    //if (pt.ShowDialog() == DialogResult.OK)
                    //{
                        nationalID = new NationalIDCard();
                        nationalID.Closing();
                        //nationalID.ValueUpdated -= new ValueUpdatedEventHandler(nationalID_ValueUpdated);
                        nationalID.ValueUpdated += new ValueUpdatedEventHandler(nationalID_ValueUpdated);
                        nationalID.Invoke();

                        //pt.Close();
                    //}

                    //btnDeviceStatus.BackColor = Color.GreenYellow;
                    //btnDeviceStatus.Enabled = true;

                    stripBtnYellow.Visible = false;
                    stripBtnRed.Visible = false;
                    stripBtnGreen.Visible = true;
                }
                catch (Exception ex)
                {
                    if (!ex.Message.StartsWith("ไม่สามารถกำหนดหมายเลขพอร์ทได้"))
                    {
                        //MessageBox.Show(ex.Message);                    
                        PatientRegistration_ActivateDialog pt = new PatientRegistration_ActivateDialog();
                        if (pt.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                string activeCode = pt.ActivateCode;
                                pt.Close();

                                nationalID = new NationalIDCard();
                                nationalID.ValueUpdated += new ValueUpdatedEventHandler(nationalID_ValueUpdated);
                                nationalID.Invoke(activeCode);

                                stripBtnYellow.Visible = false;
                                stripBtnRed.Visible = false;
                                stripBtnGreen.Visible = true;
                            }
                            catch (Exception ex2)
                            {
                                stripBtnYellow.Visible = false;
                                stripBtnRed.Visible = true;
                                stripBtnGreen.Visible = false;
                            }
                        }
                        else
                        {
                            stripBtnYellow.Visible = false;
                            stripBtnRed.Visible = true;
                            stripBtnGreen.Visible = false;
                        }

                        //btnDeviceStatus.BackColor = Color.Red;
                        //btnDeviceStatus.Enabled = true;
                    }
                    else
                    {
                        stripBtnYellow.Visible = false;
                        stripBtnRed.Visible = true;
                        stripBtnGreen.Visible = false;
                    }
                }

                //while (true)
                //{
                //    try
                //    {
                //        //nationalID.Invoke(nationalID.Activatation_Keys[1]);
                //        break;
                //    }
                //    catch
                //    {

                //    }
                //}
                
            }
            else if (e.ProgressPercentage == 2)
            { 
                while (true)
                {
                    //Thread.Sleep(5000);

                    if (!nationalID.DeviceChecking())
                    {
                        MessageBox.Show(nationalID.ErrorReport, "Error Reporting");
                    }
                    else
                    {
                        if (!nationalID.ModuleActivated(nationalID.Activatation_Keys[1]))
                        {
                            MessageBox.Show(nationalID.ErrorReport, "Error Reporting");
                        }
                        else
                        {
                            //bgWorker1.ReportProgress(0);
                            break;
                        }
                    }
                }

                //lbSearching.Visible = false;
                //lbConnected.Visible = true;
            }
        }

        private void lbStatus_Click(object sender, EventArgs e)
        {
            bgWorker1.RunWorkerAsync();
        }

        private void GetDataFromOrder(NidNationalIdMagneticCardDataType IDCdata)
        {
            if (!saving) return;

            txtHN.Text = IDCdata.IdCardNumber;

            dedRegDate.DateTime = new DateTime
                                    (
                                        DateTime.Now.ToLocalTime().Year,
                                        DateTime.Now.ToLocalTime().Month,
                                        DateTime.Now.ToLocalTime().Day
                                    );

            txtTitle.Text = IDCdata.Prefix;
            txtFname.Text = IDCdata.FirstName;
            txtLname.Text = IDCdata.LastName;

            try
            {
                txtTitleEng.Text = TransToEnglish.Trans(txtTitle.Text);
                txtFnameEng.Text = TransToEnglish.Trans(txtFname.Text);
                txtLnameEng.Text = TransToEnglish.Trans(txtLname.Text);
            }
            catch { }

            txtSSN.Text = IDCdata.IdCardNumber;

            string gender = IDCdata.Gender.StartsWith("ช") ? "M" : "F";
            if (gender == "M")
                cbbGender.SelectedIndex = 0;
            else if (gender == "F")
                cbbGender.SelectedIndex = 1;
            else
                cbbGender.SelectedIndex = -1;

            try
            {
                int year = Convert.ToInt32(IDCdata.BirthYear);
                int month = Convert.ToInt32(IDCdata.BirthMonth);
                int day = Convert.ToInt32(IDCdata.BirthDay);

                dedDOB.DateTime = new DateTime(year, month, day).ToLocalTime();
                spinAge.Text = IDCdata.Age.ToString();
            }
            catch { }

            txtAddress1.Text = IDCdata.HomeNumber;
            txtAddress2.Text = IDCdata.Soi;
            txtAddress3.Text = IDCdata.Tt;
            txtAddress4.Text = IDCdata.Aa;
            txtAddress5.Text = IDCdata.Cc;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            string strTitle = txtTitle.Text;

            int k = 0;
            bool wasFound = false;
            foreach (string titlename in TitleThaiName)
            {
                if (titlename == strTitle)
                {
                    wasFound = true;
                    break;
                }
                k++;
            }

            if (wasFound)
            {
                txtTitleEng.Text = TitleEngName[k];
            }
            else
            {
                txtTitleEng.Text = "";
            }
        }

        private void AddItemIntoComboBox()
        {
            txtTitle.Properties.Items.Clear();
            txtTitleEng.Properties.Items.Clear();

            int k = 0;
            while (k < TitleThaiName.Length)
            {
                txtTitle.Properties.Items.Add(TitleThaiName[k]);
                txtTitleEng.Properties.Items.Add(TitleEngName[k]);
                ++k;
            }
        }

        #region Title Thai Name
        public string[] TitleThaiName = new string[]
        { 
            "นาย",
            "นางสาว",
            "นาง",

            "บาทหลวง",
            "แม่ชี",
            "พระ",
            "หม่อมราชวงศ์",
            "หม่อมหลวง",
            "รองศาสตราจารย์",
            "ผู้ช่วยศาสตราจารย์",

            "พล.อ.อ.",
            "พล.อ.ท.",
            "พล.อ.ต.",
            "น.อ.",
            "น.ท.",
            "น.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "พ.อ.อ.",
            "พ.จ.ท.",
            "พ.อ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",

            "พล.อ.",
            "พล.ท.",
            "พล.ต.",
            "พ.อ.",
            "พ.ท.",
            "พ.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "จ.ส.อ.",
            "จ.ส.ท.",
            "จ.ส.ต.",
            "ส.อ.",
            "ส.ท.",
            "ส.ต.",
            "พลฯ",

            "พล.ร.อ.",
            "พล.ร.ท.",
            "พล.ร.ต.",
            "น.อ...ร.น.",
            "น.ท...ร.น.",
            "น.ต...ร.น.",
            "ร.อ...ร.น.",
            "ร.ท...ร.น.",
            "ร.ต...ร.น.",
            "พ.จ.อ.",
            "พ.จ.ท.",
            "พ.จ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",

            "พล.ต.อ.",
            "พล.ต.ท.",
            "พล.ต.ต.",
            "พ.ต.อ.",
            "พ.ต.ท.",
            "พ.ต.ต.",
            "ร.ต.อ",
            "ร.ต.ท",
            "ร.ต.ต",
            "ด.ต.",
            "จ.ส.อ.",
            "ส.ต.อ.",
            "ส.ต.ท.",
            "ส.ต.ต.",
            "พลตำรวจ",
        };
        #endregion Title Thai Name

        #region Title Eng Name
        public string[] TitleEngName = new string[]
        { 
            "Mr.",
            "Ms.",
            "Mrs.",

            "Fr.",
            "Sis.",
            "Monk",
            "M R",
            "M L", 
            "Assoc P.",
            "Assist Pro.",

            "ACM",
            "AM", 
            "AVM", 
            "GP CAPT",
            "WG CDR",
            "SON LDR",
            "FLT LT",
            "FLG OFF",
            "PLT OFF",
            "FS 1",
            "FS 2",
            "FS 3",
            "SGT",
            "CPL", 
            "LAC",
            "AMN",

            "GEN", 
            "LT GEN", 
            "MAJ GEN",
            "COL", 
            "LT COL", 
            "MAJ",
            "CAPT",
            "LT",
            "SUB KT",
            "SM 1",
            "SM 2",
            "SM 3",
            "PFC",
            "CPL",
            "PFC",
            "PVT",

            "ADM", 
            "V ADM",
            "R AVM",
            "CAPT",
            "CDR",
            "L CDR",
            "LT",
            "LT JG", 
            "SUB LT",
            "CPO 1",
            "CPO 2",
            "CPO 3",
            "PO 1",
            "PO 2",
            "PO 3",
            "SEA-MAN",

            "POL GEN",
            "POL LT GEN", 
            "POL MAL GEN",
            "POL COL",
            "POL LT COL", 
            "POL MAL",
            "POL CAPT",
            "POL LT",
            "POL SUB LT",
            "POL SEN SGT MAJ", 
            "POL SM",
            "POL SGT",
            "POL CPL",
            "POL PFC",
            "POL PVT",         
        };
        #endregion Title Eng Name
    }
}