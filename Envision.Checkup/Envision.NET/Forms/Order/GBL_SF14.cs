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

namespace RIS.Forms.Order
{
    public partial class GBL_SF14 : Form
    {
        MyMessageBox mmb = new MyMessageBox();
        DataTable table_select = new DataTable();
        UUL.ControlFrame.Controls.TabControl CloseControl;
        string lastisAdded = "";


        public GBL_SF14(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
            CloseControl = tabcontrol;
        }
        public GBL_SF14()
        {
            InitializeComponent();
        }

        private void GBL_SF14_Load(object sender, EventArgs e)
        {
            txtSearchRegID.Focus();
            dedDOB.Tag = false;
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

                this.nEntryContainer29.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(250)))));
                this.nEntryContainer28.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            }
            else if(btnUpdate.Text == "Save")
            {
                textbox_setting();
            }
            else
            {
                textbox_clearing();
                table_select.Clear();
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

                this.nEntryContainer28.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(250)))));
                this.nEntryContainer29.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            }
            else
            {
                textbox_clearing();
                table_select.Clear();
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
            txtAge.Text = "";

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
            txtAge.Enabled = enable;

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
                int dob = DateTime.Now.Year - dedDOB.DateTime.Year;
                txtAge.Text = dob.ToString();
            }
            catch (Exception)
            {
                txtAge.Text = "";
            }

            if(row["BLOOD_GROUP"].ToString()=="A+")
                cbbBloodGroup.SelectedIndex = 0;
            else if(row["BLOOD_GROUP"].ToString()=="A-")
                cbbBloodGroup.SelectedIndex = 1;
            else if(row["BLOOD_GROUP"].ToString()=="B+")
                cbbBloodGroup.SelectedIndex = 2;
            else if(row["BLOOD_GROUP"].ToString()=="B-")
                cbbBloodGroup.SelectedIndex = 3;
            else if(row["BLOOD_GROUP"].ToString()=="AB+")
                cbbBloodGroup.SelectedIndex = 4;
            else if(row["BLOOD_GROUP"].ToString()=="AB-")
                cbbBloodGroup.SelectedIndex = 5;
            else if(row["BLOOD_GROUP"].ToString()=="O+")
                cbbBloodGroup.SelectedIndex = 6;
            else if(row["BLOOD_GROUP"].ToString()=="O-")
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
            //End Miscellaneous
            
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

                txtHN.Focus();
                lastisAdded = "";
            }
            else
            {
                HISRegistration hisreg = new HISRegistration();

                if (txtHN.Text == "")
                { mmb.ShowAlert("UID2001", 1); txtHN.Focus(); return; }

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
                try { hisreg.AGE = int.Parse(txtAge.Text); }
                catch(Exception) {}
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

                ProcessAddPatientRegistration add = new ProcessAddPatientRegistration();
                add.HISRegistration = hisreg;
                add.Invoke();

                if (add.ResultSet.Tables[0].Rows.Count > 0)
                {
                    mmb.ShowAlert("UID2009", 1);
                    txtHN.Focus();
                    return;
                }

                mmb.ShowAlert("UID2044", 2);

                textbox_clearing();
                txtHN.Focus();
                dedRegDate.DateTime = DateTime.Now;

                lastisAdded = hisreg.HN;
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

                txtHN.Focus();
            }
            else
            {
                HISRegistration hisreg = new HISRegistration();

                if (txtHN.Text == "")
                { mmb.ShowAlert("UID2001", 1); txtHN.Focus(); return; }

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
                try { hisreg.AGE = int.Parse(txtAge.Text); }
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
                txtAge.Focus();
            }
            else
            {
                sd.DateTime = (DateTime)e.Value;
                int dob = DateTime.Now.Year - sd.DateTime.Year;
                txtAge.Text = dob.ToString();
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
            txtAge.Text = numdob.ToString();
        }

        private void ThaiText_Validated(object sender, EventArgs e)
        {        
            DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

            if (sd.Text.Trim().Length < 1) return;

            if (sd.Name == "txtTitle")
                txtTitleEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
            else if (sd.Name == "txtFname")
                txtFnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
            else if (sd.Name == "txtMname")
                txtMnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
            else if (sd.Name == "txtLname")
                txtLnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
            else
            {
                System.Windows.Forms.MessageBox.Show("Can not translate to eng language", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
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

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNationality.Focus();
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
    }
}