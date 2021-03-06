using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Itworks.NationalIdCardSdk;
using Miracle.NationalIDCard;
using Miracle.Util;
using Miracle.WebCam;
using Envision.Operational.Translator;

namespace Envision.NET.Forms.Orders
{
	public partial class PatientRegistration : Envision.NET.Forms.Main.MasterForm  //Form
	{
		private GuiMode _mode;

		MyMessageBox mmb = new MyMessageBox();
		DataTable table_select = new DataTable();
		string lastisAdded = "";
		NationalIDCard nationalID;
		Capture cam;
		IntPtr m_ip = IntPtr.Zero;
		uint _context;

		bool saving = false;

		////////MODIFIED BY CAHI
		public PatientRegistration()
		{
			InitializeComponent();
		}

		////////MODIFIED BY CAHI
		public PatientRegistration(NidNationalIdMagneticCardDataType data)
		{
			InitializeComponent();

			GetDataFromOrder(data);
		}

		////////MODIFIED BY CAHI
		private void GBL_SF14_Load(object sender, EventArgs e)
		{
			stripBtnYellow.Visible = true;
			stripBtnRed.Visible = false;
			stripBtnGreen.Visible = false;

			txtSearchHN.Focus();
			dedDOB.Tag = false;

			Load_Title();

			setForm(GuiMode.Normal);

			base.CloseWaitDialog();
		}

		////////CREATED BY CAHI
		private void Select_HISRegistration(string hn, int reg_id)
		{
            if (txtSearchHN.Text.Length == 0) return;

			HIS_REGISTRATION hisreg = new HIS_REGISTRATION();
			hisreg.HN = hn;
			hisreg.REG_ID = reg_id;

			ProcessGetPatientRegistration select = new ProcessGetPatientRegistration();
			select.HIS_REGISTRATION = hisreg;
			select.Invoke();

			table_select = select.DataResult.Tables[0];

			if (btnUpdate.Text == "Edit")
			{
				textbox_setting();
			}
			else
			{
				pictureBox1.Image = null;

				textbox_clearing();
				table_select.Clear();
			}
		}
		////////CREATED BY CAHI
		private void Load_Title()
		{
			txtTitle.Properties.Items.Clear();
			txtTitleEng.Properties.Items.Clear();

			txtTitle.Properties.Items.AddRange(TitleThaiName);
			txtTitleEng.Properties.Items.AddRange(TitleEngName);
		}

		////////MODIFIED BY CAHI
		private void txtRegID_TextChanged(object sender, EventArgs e)
		{
			int reg_id;

			if (!int.TryParse(((DevExpress.XtraEditors.TextEdit)sender).Text, out reg_id))
			{
				reg_id = 0;
			}

			Select_HISRegistration("", reg_id);
		}
		////////MODIFIED BY CAHI
		private void txtHN_TextChanged(object sender, EventArgs e)
		{
			Select_HISRegistration(((DevExpress.XtraEditors.TextEdit)sender).Text, 0);
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			//Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
			//            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(simpleButton1_Click1);

			//            string qry = @"
			//                        select
			//                            INSURANCE_TYPE_ID,
			//                            INSURANCE_TYPE_UID,
			//	                        INSURANCE_TYPE_DESC
			//                        from
			//	                        RIS_INSURANCETYPE
			//                        where INSURANCE_TYPE_ID like '%%' OR INSURANCE_TYPE_UID like '%%' OR INSURANCE_TYPE_DESC like '%%'
			//                        order by INSURANCE_TYPE_ID asc 
			//                            ";

			//            string fields = "Insurance ID, Insurance Alias, Insurance Description";
			//            string con = "";
			//            lv.getData(qry, fields, con, "Insurance List");
			//            lv.Show();

			LookUpSelect lvS = new LookUpSelect();
			LookupData lv = new LookupData();
			lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_InsuranceType);
			lv.AddColumn("INSURANCE_TYPE_ID", "Exam ID", false, true);
			lv.AddColumn("INSURANCE_TYPE_UID", "Exam Code", true, true);
			lv.AddColumn("INSURANCE_TYPE_DESC", "Name", true, true);
			//lv.AddColumn("TYPE_NAME_ALIAS", "Exam Type", true, true);
			lv.Text = "Insurance List";

			ProcessGetRISInsurancetype getData = new ProcessGetRISInsurancetype();
			getData.Invoke();
			lv.Data = getData.Result.Tables[0];
			lv.Size = new Size(600, 400);
			lv.ShowBox();
		}
		private void find_InsuranceType(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
		{
			string[] retValue = e.NewValue.Split(new Char[] { '^' });

			txtInsuranceType.Tag = retValue[0];
			txtInsuranceType.Text = retValue[1];
			txtInsuranceDescription.Text = retValue[2];
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			//Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
			//            lv.ValueUpdated += new RIS.Forms.Dialog.ValueUpdatedEventHandler(simpleButton2_Click1);

			//            string qry = @"
			//                        select
			//                            REG_ID,
			//                            HN,
			//	                        (ISNULL(TITLE,'')+' '+ISNULL(FNAME,'')+' '+ISNULL(MNAME,'')+' '+ISNULL(LNAME,'')) AS NAME
			//                        from
			//	                        HIS_REGISTRATION
			//                        where HN like '%%' OR REG_ID like '%%' OR
			//                              TITLE like '%%' OR FNAME like '%%' OR MNAME like '%%' OR LNAME like '%%'
			//                        order by REG_ID asc
			//                            ";

			//            string fields = "Patient ID, Patient HN, Patient NAME";
			//            string con = "";
			//            lv.getData(qry, fields, con, "Patient List");
			//            lv.Show();

			//DELL////START//?????????????????????????? ???????????????????????????
			LookUpSelect lvS = new LookUpSelect();

			LookupData lv = new LookupData();
			lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Patient);
			lv.AddColumn("REG_ID", "REG_ID", false, true);
			lv.AddColumn("HN", "HN", true, true);
			lv.AddColumn("FNAME", "First Name", true, true);
			lv.AddColumn("LNAME", "Last Name", true, true);
			//lv.AddColumn("TYPE_NAME_ALIAS", "Exam Type", true, true);
			lv.Text = "Patient List";

			ProcessGetHISRegistration getData = new ProcessGetHISRegistration(-1);
			getData.Invoke_GetDataAll();
			lv.Data = getData.Result.Tables[0];
			lv.Size = new Size(600, 400);
			lv.ShowBox();
			//DELL////END//
		}
		private void find_Patient(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
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

		#region old textbox_setting()
		//private void textbox_setting()
		//{
		//    try
		//    {
		//        textbox_clearing();

		//        if (!Utilities.IsHaveData(table_select)) { return; }

		//        DataRow row = table_select.Rows[0];

		//        txtRegID.Text = row["REG_ID"].ToString();
		//        txtHN.Text = row["HN"].ToString();
		//        if (row["IS_DELETED"].ToString() == "Y" || row["IS_UPDATED"].ToString() == "Y")
		//        {
		//            checkEdit1.Checked = false;
		//        }
		//        else
		//        {
		//            checkEdit1.Checked = true;
		//        }

		//        try { dedRegDate.DateTime = (DateTime)row["REG_DT"]; }
		//        catch (Exception) { dedRegDate.Text = ""; }

		//        txtTitle.Text = row["TITLE"].ToString();
		//        txtFname.Text = row["FNAME"].ToString();
		//        txtMname.Text = row["MNAME"].ToString();
		//        txtLname.Text = row["LNAME"].ToString();

		//        txtTitleEng.Text = row["TITLE_ENG"].ToString();
		//        txtFnameEng.Text = row["FNAME_ENG"].ToString();
		//        txtMnameEng.Text = row["MNAME_ENG"].ToString();
		//        txtLnameEng.Text = row["LNAME_ENG"].ToString();

		//        txtSSN.Text = row["SSN"].ToString();

		//        if (row["MARITAL_STATUS"].ToString() == "M")
		//            cbbMarritalStatus.SelectedIndex = 0;
		//        else if (row["MARITAL_STATUS"].ToString() == "S")
		//            cbbMarritalStatus.SelectedIndex = 1;
		//        else if (row["MARITAL_STATUS"].ToString() == "")
		//            cbbMarritalStatus.SelectedIndex = -1;

		//        if (row["GENDER"].ToString() == "M")
		//            cbbGender.SelectedIndex = 0;
		//        else if (row["GENDER"].ToString() == "F")
		//            cbbGender.SelectedIndex = 1;
		//        else
		//            cbbGender.SelectedIndex = -1;

		//        try
		//        {
		//            dedDOB.DateTime = (DateTime)row["DOB"];
		//        }
		//        catch
		//        {

		//        }

		//        try
		//        {
		//            //dedDOB.DateTime = (DateTime)row["DOB"];
		//            //int dob = DateTime.Now.Year - dedDOB.DateTime.Year;
		//            //spinAge.Text = dob.ToString();
		//            spinAge.Text = row["AGE"].ToString();
		//        }
		//        catch (Exception)
		//        {
		//            spinAge.Text = "";
		//        }



		//        if (row["BLOOD_GROUP"].ToString() == "A+")
		//            cbbBloodGroup.SelectedIndex = 0;
		//        else if (row["BLOOD_GROUP"].ToString() == "A-")
		//            cbbBloodGroup.SelectedIndex = 1;
		//        else if (row["BLOOD_GROUP"].ToString() == "B+")
		//            cbbBloodGroup.SelectedIndex = 2;
		//        else if (row["BLOOD_GROUP"].ToString() == "B-")
		//            cbbBloodGroup.SelectedIndex = 3;
		//        else if (row["BLOOD_GROUP"].ToString() == "AB+")
		//            cbbBloodGroup.SelectedIndex = 4;
		//        else if (row["BLOOD_GROUP"].ToString() == "AB-")
		//            cbbBloodGroup.SelectedIndex = 5;
		//        else if (row["BLOOD_GROUP"].ToString() == "O+")
		//            cbbBloodGroup.SelectedIndex = 6;
		//        else if (row["BLOOD_GROUP"].ToString() == "O-")
		//            cbbBloodGroup.SelectedIndex = 7;
		//        else
		//            cbbBloodGroup.SelectedIndex = -1;

		//        txtNationality.Text = row["NATIONALITY"].ToString();
		//        txtPassportNo.Text = row["PASSPORT_NO"].ToString();
		//        //End Patient Demographic

		//        //Start Contact Information
		//        txtPhone1.Text = row["PHONE1"].ToString();
		//        txtPhone2.Text = row["PHONE2"].ToString();
		//        txtEmail.Text = row["EMAIL"].ToString();
		//        txtAddress1.Text = row["ADDR1"].ToString();
		//        txtAddress2.Text = row["ADDR2"].ToString();
		//        txtAddress3.Text = row["ADDR3"].ToString();
		//        txtAddress4.Text = row["ADDR4"].ToString();
		//        txtAddress5.Text = row["ADDR5"].ToString();
		//        //End Contact Information

		//        //Start Emergency Contact Information
		//        txtEmContactPerson.Text = row["EM_CONTACT_PERSON"].ToString();
		//        txtEmAddress.Text = row["EM_ADDR"].ToString();
		//        txtEmPhone.Text = row["EM_PHONE"].ToString();
		//        txtEmRelation.Text = row["EM_RELATION"].ToString();
		//        //End Emergency Contact Information

		//        //Start Miscellaneous
		//        txtAllergies.Text = row["ALLERGIES"].ToString();
		//        txtInsuranceType.Text = row["INSURANCE_TYPE"].ToString();
		//        txtInsuranceDescription.Text = row["INSURANCE_TYPE_DESC"].ToString();
		//        //Image im;
		//        try
		//        {
		//            ImageConverter imcon = new ImageConverter();
		//            pictureBox1.Image = (Image)imcon.ConvertFrom(row["Picture"]);
		//        }
		//        catch (Exception)
		//        {
		//            pictureBox1.Image = null;
		//        }
		//        //pictureBox1.Image = (Image)row["INSURANCE_TYPE"];
		//        //End Miscellaneous

		//        //STOP();
		//        //Activate();
		//    }
		//    catch (Exception ex)
		//    {
		//        //MessageBox.Show(ex.Message);
		//    }
		//}
		#endregion
		////////MODIFIED BY CAHI
		private void textbox_setting()
		{
			try
			{
				textbox_clearing();

				if (!Utilities.IsHaveData(table_select)) { return; }

				DataRow row = table_select.Rows[0];

				//Start Patient Demographic
				txtRegID.Text = row["REG_ID"].ToString();
				txtHN.Text = row["HN"].ToString();

				checkEdit1.Checked = !(row["IS_DELETED"].ToString() == "Y" || row["IS_UPDATED"].ToString() == "Y");

				try { dedRegDate.DateTime = (DateTime)row["REG_DT"]; }
				catch { dedRegDate.Text = ""; }

				txtTitle.Text = row["TITLE"].ToString();
				txtFname.Text = row["FNAME"].ToString();
				txtMname.Text = row["MNAME"].ToString();
				txtLname.Text = row["LNAME"].ToString();

				txtTitleEng.Text = row["TITLE_ENG"].ToString();
				txtFnameEng.Text = row["FNAME_ENG"].ToString();
				txtMnameEng.Text = row["MNAME_ENG"].ToString();
				txtLnameEng.Text = row["LNAME_ENG"].ToString();

				txtSSN.Text = row["SSN"].ToString();

				switch (row["MARITAL_STATUS"].ToString())
				{
					case "M": cbbMarritalStatus.SelectedIndex = 0; break;
					case "S": cbbMarritalStatus.SelectedIndex = 1; break;
					default: cbbMarritalStatus.SelectedIndex = -1; break;
				}

				switch (row["GENDER"].ToString())
				{
					case "M": cbbGender.SelectedIndex = 0; break;
					case "F": cbbGender.SelectedIndex = 1; break;
					default: cbbGender.SelectedIndex = -1; break;
				}

				try { dedDOB.DateTime = (DateTime)row["DOB"]; }
				catch { }

				try { spinAge.Text = row["AGE"].ToString(); }
				catch { spinAge.Text = ""; }

				switch (row["BLOOD_GROUP"].ToString())
				{
					case "A+": cbbBloodGroup.SelectedIndex = 0; break;
					case "A-": cbbBloodGroup.SelectedIndex = 1; break;
					case "B+": cbbBloodGroup.SelectedIndex = 2; break;
					case "B-": cbbBloodGroup.SelectedIndex = 3; break;
					case "AB+": cbbBloodGroup.SelectedIndex = 4; break;
					case "AB-": cbbBloodGroup.SelectedIndex = 5; break;
					case "O+": cbbBloodGroup.SelectedIndex = 6; break;
					case "O-": cbbBloodGroup.SelectedIndex = 7; break;
					default: cbbBloodGroup.SelectedIndex = -1; break;
				}

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

				try
				{
					pictureBox1.Image = (Image)new ImageConverter().ConvertFrom(row["Picture"]);
				}
				catch { pictureBox1.Image = null; }
				//End Miscellaneous
			}
			catch { }
		}

		////////CREATED BY CAHI
		/// <summary>
		/// Check & Get data HISRegistration
		/// </summary>
		/// <param name="hisreg">Common HIS_REGISTRATION</param>
		/// <returns>Do data correct?</returns>
		private bool HISRegistration(out HIS_REGISTRATION hisreg)
		{
			hisreg = new HIS_REGISTRATION();

			if (mmb.ShowAlert("UID1019", 2) == "1") { }
			else if (txtHN.Text == "" || txtFname.Text.Trim() == "")
			{
				mmb.ShowAlert("UID2001", 1);
				txtFname.Focus();
			}
			else
			{
                hisreg.REG_ID = Convert.ToInt32(txtRegID.Text);

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

				switch (cbbMarritalStatus.Text)
				{
					case "Married": hisreg.MARITAL_STATUS = 'M'; break;
					case "Single": hisreg.MARITAL_STATUS = 'S'; break;
					default: hisreg.MARITAL_STATUS = null; break;
				}

				hisreg.PASSPORT_NO = txtPassportNo.Text;

				switch (cbbGender.Text)
				{
					case "Male": hisreg.GENDER = 'M'; break;
					case "Female": hisreg.GENDER = 'F'; break;
					default: hisreg.GENDER = null; break;
				}

				hisreg.DOB = dedDOB.DateTime;
				int age;
				if (int.TryParse(spinAge.Text, out age))
				{
					hisreg.AGE = age;
				}

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
					hisreg.Picture_Forsave = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
					if (hisreg.Picture_Forsave.Length <= 0)
						hisreg.Picture_Forsave = null;
				}
				catch
				{
					hisreg.Picture_Forsave = null;
				}

				return true;
			}

			return false;
		}
		////////MODIFIED BY CAHI
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

				txtHN.Text = "AUTO";
				txtHN.Enabled = false;

				txtHN.Focus();
				lastisAdded = "";

				saving = true;
			}
			else if (mmb.ShowAlert("UID1019", 2) == "2")
			{
				HIS_REGISTRATION Params;

				if (HISRegistration(out Params))
				{
					ProcessAddPatientRegistration add = new ProcessAddPatientRegistration();
					add.HIS_REGISTRATION = Params;
					add.Invoke();

					if (add._ds.Tables[0].Rows.Count > 0)
					{
						mmb.ShowAlert("UID2009", 1);
						return;
					}

					mmb.ShowAlert("UID2044", 2);

					textbox_clearing();
					txtTitle.Focus();

					dedRegDate.DateTime = DateTime.Now;

					txtHN.Text = "AUTO";

					lastisAdded = add.HIS_REGISTRATION.HN;

					saving = false;
				}
			}
		}
		////////MODIFIED BY CAHI
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!Utilities.IsHaveData(table_select)) { return; }

			if (btnUpdate.Text == "Edit")
			{
				if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
				{
					mmb.ShowAlert("UID2010", 1);

					if (mmb.ShowAlert("UID2011", 1) == "1") { return; }

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
			else if (mmb.ShowAlert("UID1019", 2) == "2")
			{
				HIS_REGISTRATION Params;

				if (HISRegistration(out Params))
				{
					Params.REG_ID = int.Parse(txtRegID.Text);

					ProcessUpdatePatientRegistration update = new ProcessUpdatePatientRegistration();
					update.HIS_REGISTRATION = Params;
					update.Invoke();

					if (update.ResultSet.Tables[0].Rows.Count > 0)
					{
						mmb.ShowAlert("UID2009", 1);
						txtHN.Focus();
						return;
					}

					mmb.ShowAlert("UID2044", 2);

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
		////////MODIFIED BY CAHI
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (!Utilities.IsHaveData(table_select)) { return; }

			if ((btnDelete.Text == "Delete") && (table_select.Rows[0]["IS_DELETED"].ToString() == "Y"))
			{
				mmb.ShowAlert("UID2012", 1);
			}
			else if (mmb.ShowAlert("UID2003", 1) == "2")
			{
				ProcessDeletePatientRegistration delete = new ProcessDeletePatientRegistration();
				delete.HIS_REGISTRATION.REG_ID = int.Parse(txtRegID.Text);
				delete.Invoke();

				txtRegID_TextChanged(txtRegID as object, new EventArgs());
				textbox_setting();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (btnAdd.Text == "Save" && lastisAdded.Trim().Length > 0)
			{
				HIS_REGISTRATION hisreg = new HIS_REGISTRATION();
				ProcessGetPatientRegistration selectpt = new ProcessGetPatientRegistration();
				hisreg.HN = lastisAdded;
				hisreg.REG_ID = 0;
				selectpt.HIS_REGISTRATION = hisreg;
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
			this.Close();
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
			if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
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
			int numdob = DateTime.Now.Year - sd.DateTime.Year;
			spinAge.Text = numdob.ToString();
		}

		////////MODIFIED BY CAHI
		private void ThaiText_Validated(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

			string word = sd.Text.Trim();

			if (word != "")
			{
				try
				{
					word = TransToEnglish.Trans(word);

					if (!string.IsNullOrEmpty(word))
					{
						word = word.Substring(0, 1).ToUpper() + word.Remove(0, 1);

						switch (sd.Name)
						{
							case "txtFname": txtFnameEng.Text = word; break;
							case "txtMname": txtMnameEng.Text = word; break;
							case "txtLname": txtLnameEng.Text = word; break;
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
					result = "???????????????????????????????.";
					break;

				case ResultCodeTypes.InvalidContext:
					result = "context ??????????";
					break;

				case ResultCodeTypes.ActivationFail:
					result = "??????????????????????????";
					break;

				case ResultCodeTypes.ModuleNotActivate:
					result = "????????????????????";
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
		//            //"?????????????????????????????";
		//            //throw new Exception("?????????????????????????????");
		//            MessageBox.Show("?????????????????????????????");
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
		//            //"?????????????"
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
		private void nationalID_ValueUpdated(object sender, Miracle.NationalIDCard.ValueUpdatedEventArgs e)
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

			row["GENDER"] = IDCdata.Gender.StartsWith("?") ? "M" : "F";//"M" or "F" or ""
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
					nationalID.ValueUpdated += new Miracle.NationalIDCard.ValueUpdatedEventHandler(nationalID_ValueUpdated);
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
					if (!ex.Message.StartsWith("?????????????????????????????"))
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
								nationalID.ValueUpdated += new Miracle.NationalIDCard.ValueUpdatedEventHandler(nationalID_ValueUpdated);
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

			string gender = IDCdata.Gender.StartsWith("?") ? "M" : "F";
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

		#region Title Thai Name
		public string[] TitleThaiName = new string[]
        { 
            "???",
            "??????",
            "???",

            "???????",
            "?????",
            "???",
            "????????????",
            "?????????",
            "??????????????",
            "??????????????????",

            "??.?.?.",
            "??.?.?.",
            "??.?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "???",

            "??.?.",
            "??.?.",
            "??.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "???",

            "??.?.?.",
            "??.?.?.",
            "??.?.?.",
            "?.?...?.?.",
            "?.?...?.?.",
            "?.?...?.?.",
            "?.?...?.?.",
            "?.?...?.?.",
            "?.?...?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.",
            "?.?.",
            "?.?.",
            "???",

            "??.?.?.",
            "??.?.?.",
            "??.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?",
            "?.?.?",
            "?.?.?",
            "?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "?.?.?.",
            "???????",
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

		private void setForm(GuiMode Mode)
		{
			_mode = Mode;

			switch (Mode)
			{
				case GuiMode.Normal:

					btnribbonSave.Visible = false;
					btnribbonCancel.Visible = false;
					btnribBack.Visible = true;
					btnribbonAdd.Visible = true;
					btnribbonUpdate.Visible = true;
					//btnribDelete.Visible = true;
                    textbox_Enable(false);
                    break;
				case GuiMode.Add:
					textbox_clearing();
					textbox_Enable(true);

					dedRegDate.DateTime = DateTime.Now;
					dedRegDate.Enabled = false;

					dedRegDate.DateTime = DateTime.Now;

					txtHN.Text = "AUTO";
					txtHN.Enabled = false;

					txtHN.Focus();
					lastisAdded = "";

					saving = true;

					btnribbonSave.Visible = true;
					btnribbonCancel.Visible = true;
					btnribbonAdd.Visible = false;
					btnribbonUpdate.Visible = false;
					btnribBack.Visible = false;
					//btnribDelete.Visible = false;
					break;
				case GuiMode.Edit:
					if (table_select.Rows.Count < 1) return;

					//if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
					//{
					//    mmb.ShowAlert("UID2010", 1);
					//    string str = mmb.ShowAlert("UID2011", 1);
					//    if (str == "1")
					//        return;

					//    checkEdit1.Checked = true;
					//}

					textbox_Enable(true);
					dedRegDate.Enabled = false;

					btnUpdate.Text = "Save";
					btnAdd.Visible = false;
					btnUpdate.Visible = true;
					btnDelete.Visible = false;
					btnCancel.Visible = true;

					txtHN.Enabled = true;

					txtHN.Focus();

					btnribbonSave.Visible = true;
					btnribbonCancel.Visible = true;
					btnribbonAdd.Visible = false;
					btnribbonUpdate.Visible = false;
					btnribBack.Visible = false;
					//btnribDelete.Visible = false;
					break;
				case GuiMode.Remove:
					break;
				default:
					break;
			}
		}
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_mode = GuiMode.Add;
			setForm(_mode);
		}

		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_mode = GuiMode.Edit;
			setForm(_mode);
		}

		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (table_select.Rows.Count < 1) return;

			if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
			{
				mmb.ShowAlert("UID2012", 1);
				return;
			}

			string str = mmb.ShowAlert("UID2003", 1);
			if (str == "2")
			{
				HIS_REGISTRATION hisreg = new HIS_REGISTRATION();
				hisreg.REG_ID = int.Parse(txtRegID.Text);

				ProcessDeletePatientRegistration delete = new ProcessDeletePatientRegistration();
				delete.HIS_REGISTRATION = hisreg;
				delete.Invoke();

				//Modified at 2008/8/14
				txtRegID_TextChanged(txtRegID as object, new EventArgs());
				textbox_setting();
			}
		}

		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
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


			_mode = GuiMode.Normal;
			setForm(_mode);
		}

		private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Close();
		}

		////////MODIFIED BY CAHI
		private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			HIS_REGISTRATION hisreg;

			switch (_mode)
			{
				case GuiMode.Normal:
					break;
				case GuiMode.Add:
					#region Insert
					if (HISRegistration(out hisreg))
					{
						ProcessAddPatientRegistration add = new ProcessAddPatientRegistration();
						add.HIS_REGISTRATION = hisreg;
						add.Invoke();

						if (add._ds.Tables[0].Rows.Count > 0)
						{
							mmb.ShowAlert("UID2009", 1);
							return;
						}

						mmb.ShowAlert("UID2044", 2);

						dedRegDate.DateTime = DateTime.Now;
						txtHN.Text = "AUTO";
						lastisAdded = hisreg.HN;

						saving = false;
						textbox_clearing();
						textbox_Enable(false);

						btnAdd.Text = "Add";
						btnUpdate.Text = "Edit";
						btnDelete.Text = "Delete";

						btnAdd.Visible = true;
						btnUpdate.Visible = true;
						btnDelete.Visible = true;
						btnCancel.Visible = false;

						ProcessGetHISRegistration getData = new ProcessGetHISRegistration(-1);
						getData.Invoke_GetLastRecord();

						if (getData.Result.Tables[0].Rows.Count > 0)
						{
							string hn = getData.Result.Tables[0].Rows[0]["HN"].ToString();
							txtHN.Text = hn;
							txtSearchHN.Text = hn;
						}

						txtHN.Focus();
					}
					#endregion
					break;
				case GuiMode.Edit:
					#region Update
					if (HISRegistration(out hisreg))
					{
						ProcessUpdatePatientRegistration update = new ProcessUpdatePatientRegistration();
						update.HIS_REGISTRATION = hisreg;
						update.Invoke();

                        //if (update.ResultSet.Tables[0].Rows.Count > 0)
                        //{
                        //    mmb.ShowAlert("UID2009", 1);
                        //    txtHN.Focus();
                        //    return;
                        //}
                        //else
                        //{
                        //    mmb.ShowAlert("UID2044", 2);
                        //}


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
					_mode = GuiMode.Normal;
					setForm(_mode);
					#endregion
					break;
				case GuiMode.Remove:
					if (table_select.Rows.Count < 1) return;

					if (table_select.Rows[0]["IS_DELETED"].ToString() == "Y")
					{
						mmb.ShowAlert("UID2012", 1);
						return;
					}

					string str = mmb.ShowAlert("UID2003", 1);
					if (str == "2")
					{
						hisreg = new HIS_REGISTRATION();
						hisreg.REG_ID = int.Parse(txtRegID.Text);

						ProcessDeletePatientRegistration delete = new ProcessDeletePatientRegistration();
						delete.HIS_REGISTRATION = hisreg;
						delete.Invoke();

						//Modified at 2008/8/14
						txtRegID_TextChanged(txtRegID as object, new EventArgs());
						textbox_setting();
					}
					break;
			}

			_mode = GuiMode.Normal;
			setForm(_mode);
		}

        private void btnHNSearch_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient his = new HIS_Patient();
                DataSet ds = his.Get_demographic_long(txtSearchHN.Text);
                PatientRegistrationHISViewer HISPage = new PatientRegistrationHISViewer();
                HISPage.HISData = ds;
                HISPage.ShowDialog();
            }
            catch { }
        }
	}
}