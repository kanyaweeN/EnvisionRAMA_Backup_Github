using System;
using System.Data;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.Operational.PACS;
using Envision.Operational.Translator;
using Miracle.Util;

namespace Envision.NET.Forms.Orders
{
	public partial class frmViewReconciliation : Envision.NET.Forms.Main.MasterForm
	{
		private int PresentRegID, action, CurrectRegID;
		private bool hasHN, linkdown, checkHN;
		private MyMessageBox msg;
		private GBLEnvVariable env = new GBLEnvVariable();
		private string NewHN, OldHN;
		public frmViewReconciliation()
		{
			InitializeComponent();
		}
		public frmViewReconciliation(string hn)
		{
			InitializeComponent();
            txtHNps.Text = hn;
			action = 0;
		}
		private void frmViewReconciliation_Load(object sender, EventArgs e)
		{
			msg = new MyMessageBox();
			txtHNcr.Focus();
			lbCorrectAlert.Text = "";
			lbPresentAlert.Text = "";
			btnSave.Enabled = false;
			if (action == 0)
			{
				SetControl();
			}
            if (!string.IsNullOrEmpty(txtHNps.Text))
                BindPresentData(txtHNps.Text);
            base.CloseWaitDialog();
		}
		private void BindPresentData(string _HN)
		{
			Order ord = new Order(_HN, true);
			if (ord.Demographic.HasHN)
			{
				PresentRegID = ord.Demographic.Reg_ID;
				if (string.IsNullOrEmpty(ord.Demographic.Title))
				{

					cmbTitleThaips.SelectedItem = "นาย";
				}
				else
				{
					cmbTitleThaips.SelectedItem = ord.Demographic.Title;
				}
				txtFnameThaips.Text = ord.Demographic.FirstName;//dtSelect.Rows[0]["FNAME"].ToString();
				txtFnameEngps.Text = ord.Demographic.FirstName_ENG;
				txtLnameThaips.Text = ord.Demographic.LastName;
				txtLnameEngps.Text = ord.Demographic.LastName_ENG;
				if (string.IsNullOrEmpty(ord.Demographic.DateOfBirth.ToString()))
					dteDobps.DateTime = DateTime.Now;
				else
					dteDobps.DateTime = ord.Demographic.DateOfBirth;

				switch (ord.Demographic.Gender)
				{
					case "M": cmbGenderps.SelectedIndex = 0; break;
					case "F": cmbGenderps.SelectedIndex = 1; break;
					default: cmbGenderps.SelectedIndex = 0; break;
				}
				cmbGenderps.SelectedItem = ord.Demographic.Gender;
				txtSSNps.Text = ord.Demographic.SocialNumber;
				txtAddressps.Text = ord.Demographic.Address1;
				txtDistrictps.Text = ord.Demographic.Address2;
				txtProvinceps.Text = ord.Demographic.Address3;
				txtZIPps.Text = ord.Demographic.Address4;
				txtPhoneps.Text = ord.Demographic.Phone1;
				txtMobileps.Text = ord.Demographic.Phone2;

				OldHN = txtHNps.Text;
				lbPresentAlert.Text = "";

				grdCorrectPatient.Enabled = true;
				txtHNcr.Focus();
			}
			else
			{
				lbPresentAlert.Text = "HN Patient Miss Match";
				SetPresentPatientNull();

				grdCorrectPatient.Enabled = false;
				txtHNps.Focus();
			}
		}
		private void BindCurrectData(string _HN)
		{
			Order ord = new Order(_HN, true);
			if (ord.Demographic.HasHN)
			{
				if (string.IsNullOrEmpty(ord.Demographic.Title))
				{

					cmbTitleThaicr.SelectedItem = "นาย";
				}
				else
				{
					cmbTitleThaicr.SelectedItem = ord.Demographic.Title;
				}
				txtFnameThaicr.Text = ord.Demographic.FirstName;//dtSelect.Rows[0]["FNAME"].ToString();
				txtFnameEngcr.Text = ord.Demographic.FirstName_ENG;
				txtLnameThaicr.Text = ord.Demographic.LastName;
				txtLnameEngcr.Text = ord.Demographic.LastName_ENG;
				if (string.IsNullOrEmpty(ord.Demographic.DateOfBirth.ToString()))
					dteDOBcr.DateTime = DateTime.Now;
				else
					dteDOBcr.DateTime = ord.Demographic.DateOfBirth;

				switch (ord.Demographic.Gender)
				{
					case "M": cmbGendercr.SelectedIndex = 0; break;
					case "F": cmbGendercr.SelectedIndex = 1; break;
					default: cmbGendercr.SelectedIndex = 0; break;
				}
				cmbGendercr.SelectedItem = ord.Demographic.Gender;
				txtSSNcr.Text = ord.Demographic.SocialNumber;
				txtAddresscr.Text = ord.Demographic.Address1;
				txtDistrictcr.Text = ord.Demographic.Address2;
				txtProvincecr.Text = ord.Demographic.Address3;
				txtZIPcr.Text = ord.Demographic.Address4;
				txtPhonecr.Text = ord.Demographic.Phone1;
				txtMobilecr.Text = ord.Demographic.Phone2;
				NewHN = txtHNcr.Text;

				lbCorrectAlert.Text = "HN Patient from Envision";
				btnSave.Enabled = true;
			}
			else
			{
				if (msg.ShowAlert("UID5010", env.CurrentLanguageID) == "2")
				{
					cmbTitleThaicr.SelectedItem = cmbTitleThaips.SelectedItem;

					txtFnameThaicr.Text = txtFnameThaips.Text;
					txtFnameEngcr.Text = txtFnameEngps.Text;
					txtLnameThaicr.Text = txtLnameThaips.Text;
					txtLnameEngcr.Text = txtLnameEngps.Text;
					dteDOBcr.DateTime = dteDobps.DateTime;
					cmbGendercr.SelectedIndex = cmbGenderps.SelectedIndex;

					cmbGendercr.SelectedItem = cmbGenderps.SelectedItem;
					txtSSNcr.Text = txtSSNps.Text;
					txtAddresscr.Text = txtAddressps.Text;
					txtDistrictcr.Text = txtDistrictps.Text;
					txtProvincecr.Text = txtProvinceps.Text;
					txtZIPcr.Text = txtZIPps.Text;
					txtPhonecr.Text = txtPhoneps.Text;
					txtMobilecr.Text = txtMobileps.Text;
					NewHN = txtHNcr.Text;

					lbCorrectAlert.Text = "Data from Present Patient";
					btnSave.Enabled = true;
				}
				else
				{
					lbCorrectAlert.Text = "HN Patient Miss Match";
					btnSave.Enabled = false;
				}
			}
		}
		private void SetControl()
		{
			cmbTitleThaips.Properties.Items.Clear();
			cmbTitleThaicr.Properties.Items.Clear();
			cmbTitleEngps.Properties.Items.Clear();
			cmbTitleEngcr.Properties.Items.Clear();

			cmbGenderps.Properties.Items.Clear();
			cmbGendercr.Properties.Items.Clear();

			for (int i = 0; i < TitleThaiName.Length; i++)
			{
				cmbTitleThaips.Properties.Items.Add(TitleThaiName[i]);
				cmbTitleEngps.Properties.Items.Add(TitleEngName[i]);
				cmbTitleThaicr.Properties.Items.Add(TitleThaiName[i]);
				cmbTitleEngcr.Properties.Items.Add(TitleEngName[i]);
			}
			for (int i = 0; i < Gender.Length; i++)
			{
				cmbGenderps.Properties.Items.Add(Gender[i]);
				cmbGendercr.Properties.Items.Add(Gender[i]);
			}


			grdPresentPatient.Enabled = true;
			grdCorrectPatient.Enabled = false;
		}
		private void cmbTitleThai_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbTitleEngps.SelectedIndex = cmbTitleThaips.SelectedIndex;
		}

		private void cmbTitleThaiO_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbTitleEngcr.SelectedIndex = cmbTitleThaicr.SelectedIndex;
		}

		private void cmbTitleEng_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbTitleThaips.SelectedIndex = cmbTitleEngps.SelectedIndex;
		}

		private void cmbTitleEngO_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbTitleThaicr.SelectedIndex = cmbTitleEngcr.SelectedIndex;
		}
		#region Gender
		public string[] Gender = new string[]
            {
                "Male",
                "Female",
                "Other"
            };
		#endregion
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cmbTitleThaicr.Text))
			{
				cmbTitleThaicr.SelectedIndex = cmbTitleThaips.SelectedIndex;
			}
			if (string.IsNullOrEmpty(txtFnameThaicr.Text))
			{
				txtFnameThaicr.Text = txtFnameThaips.Text;
				txtFnameEngcr.Text = TransToEnglish.Trans(txtFnameThaicr.Text);
			}
			if (string.IsNullOrEmpty(txtLnameThaicr.Text))
			{
				txtLnameThaicr.Text = txtLnameThaips.Text;
				txtLnameEngcr.Text = TransToEnglish.Trans(txtLnameThaicr.Text);
			}
			if (string.IsNullOrEmpty(dteDOBcr.Text))
			{
				dteDOBcr.DateTime = dteDobps.DateTime;
			}
			else if (dteDOBcr.DateTime == DateTime.Now)
			{
				dteDOBcr.DateTime = dteDobps.DateTime;
			}
			if (string.IsNullOrEmpty(cmbGendercr.Text))
			{
				cmbGendercr.SelectedIndex = cmbGenderps.SelectedIndex;
			}
			if (string.IsNullOrEmpty(txtSSNcr.Text))
			{
				txtSSNcr.Text = txtSSNps.Text;
			}
			if (string.IsNullOrEmpty(txtAddresscr.Text))
			{
				txtAddresscr.Text = txtAddressps.Text;
			}
			if (string.IsNullOrEmpty(txtDistrictcr.Text))
			{
				txtDistrictcr.Text = txtDistrictps.Text;
			}
			if (string.IsNullOrEmpty(txtProvincecr.Text))
			{
				txtProvincecr.Text = txtProvinceps.Text;
			}
			if (string.IsNullOrEmpty(txtZIPcr.Text))
			{
				txtZIPcr.Text = txtZIPps.Text;
			}
			if (string.IsNullOrEmpty(txtPhonecr.Text))
			{
				txtPhonecr.Text = txtPhoneps.Text;
			}
			if (string.IsNullOrEmpty(txtMobilecr.Text))
			{
				txtMobilecr.Text = txtMobileps.Text;
			}
		}

		private void txtHNO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (OldHN == txtHNcr.Text)
					lbCorrectAlert.Text = "HN Patient Same Present Patient";
				else
					BindCurrectData(txtHNcr.Text);
			}
			else if (e.KeyCode == Keys.Tab)
			{
				cmbTitleThaicr.Focus();
			}
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtHNps.Text != string.Empty && txtHNcr.Text != string.Empty)
			{
				UpdateDate();
				sendToPacs();
				SetCurrectPatientNull();
				SetPresentPatientNull();
				grdCorrectPatient.Enabled = false;
				btnSave.Enabled = false;
			}
			else
			{
				MessageBox.Show("HN is not match!!!");
			}

		}
		private void UpdateDate()
		{
			try
			{
				ProcessAddHISRegistration prcadd = new ProcessAddHISRegistration(false);
				prcadd.HIS_REGISTRATION.HN = txtHNcr.Text;
				prcadd.HIS_REGISTRATION.FNAME = txtFnameThaicr.Text;
				prcadd.HIS_REGISTRATION.LNAME = txtLnameThaicr.Text;
				prcadd.HIS_REGISTRATION.FNAME_ENG = txtFnameEngcr.Text;
				prcadd.HIS_REGISTRATION.LNAME_ENG = txtLnameEngcr.Text;
				prcadd.HIS_REGISTRATION.TITLE = cmbTitleThaicr.Text;
				prcadd.HIS_REGISTRATION.TITLE_ENG = cmbTitleEngcr.Text;
				prcadd.HIS_REGISTRATION.DOB = dteDOBcr.DateTime;
				switch (cmbGendercr.SelectedIndex)
				{
					case 0: prcadd.HIS_REGISTRATION.GENDER = 'M'; break;
					case 1: prcadd.HIS_REGISTRATION.GENDER = 'F'; break;
				}
				prcadd.HIS_REGISTRATION.SSN = txtSSNcr.Text;
				prcadd.HIS_REGISTRATION.ADDR1 = txtAddresscr.Text;
				prcadd.HIS_REGISTRATION.ADDR2 = txtDistrictcr.Text;
				prcadd.HIS_REGISTRATION.ADDR3 = txtProvincecr.Text;
				prcadd.HIS_REGISTRATION.ADDR4 = txtZIPcr.Text;
				prcadd.HIS_REGISTRATION.PHONE1 = txtPhonecr.Text;
				prcadd.HIS_REGISTRATION.PHONE2 = txtMobilecr.Text;
				prcadd.HIS_REGISTRATION.PHONE3 = "";
				prcadd.HIS_REGISTRATION.EMAIL = "";
				prcadd.HIS_REGISTRATION.NATIONALITY = "";
				prcadd.HIS_REGISTRATION.EM_CONTACT_PERSON = "";
				prcadd.HIS_REGISTRATION.INSURANCE_TYPE = "";
				prcadd.HIS_REGISTRATION.ORG_ID = 1;
				prcadd.HIS_REGISTRATION.CREATED_BY = new GBLEnvVariable().UserID;
				prcadd.InvokeFromADTChange(PresentRegID);
				//prcadd.Invoke();


			}
			catch (Exception ex)
			{

			}
			finally
			{

			}

		}
		private void sendToPacs()
		{
			new SendToPacs().Set_ADTReconcileQueue(OldHN, NewHN);
		}

		private void SetCurrectPatientNull()
		{
			txtHNcr.Text = string.Empty;
			txtFnameEngcr.Text = string.Empty;
			txtFnameThaicr.Text = string.Empty;
			txtLnameEngcr.Text = string.Empty;
			txtLnameThaicr.Text = string.Empty;
			txtMobilecr.Text = string.Empty;
			txtPhonecr.Text = string.Empty;
			txtProvincecr.Text = string.Empty;
			txtSSNcr.Text = string.Empty;
			txtZIPcr.Text = string.Empty;
			txtDistrictcr.Text = string.Empty;
			txtAddresscr.Text = string.Empty;
			cmbGendercr.SelectedIndex = 0;
			dteDOBcr.Text = string.Empty;
			NewHN = "";
		}
		private void SetPresentPatientNull()
		{
			txtHNps.Text = string.Empty;
			txtFnameEngps.Text = string.Empty;
			txtFnameThaips.Text = string.Empty;
			txtLnameEngps.Text = string.Empty;
			txtLnameThaips.Text = string.Empty;
			txtMobileps.Text = string.Empty;
			txtPhoneps.Text = string.Empty;
			txtProvinceps.Text = string.Empty;
			txtSSNps.Text = string.Empty;
			txtZIPps.Text = string.Empty;
			txtDistrictps.Text = string.Empty;
			txtAddressps.Text = string.Empty;
			cmbGenderps.SelectedIndex = 0;
			dteDobps.Text = string.Empty;
			OldHN = "";
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#region Key Down
		private void cmbTitleThaiO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtFnameThaicr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtFnameThaicr.Focus();
			}
		}

		private void txtFnameThaiO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtLnameThaicr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtLnameThaicr.Focus();
			}
		}

		private void txtLnameThaiO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				cmbTitleEngcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				cmbTitleEngcr.Focus();
			}
		}

		private void cmbTitleEngO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtFnameEngcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtFnameEngcr.Focus();
			}
		}

		private void txtFnameEngO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtLnameEngcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtLnameEngcr.Focus();
			}
		}

		private void txtLnameEngO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				dteDOBcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				dteDOBcr.Focus();
			}
		}

		private void dteDOBO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				cmbGendercr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				cmbGendercr.Focus();
			}
		}

		private void cmbGenderO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtSSNcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtSSNcr.Focus();
			}
		}

		private void txtSSNO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtAddresscr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtAddresscr.Focus();
			}
		}

		private void txtAddressO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtDistrictcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtDistrictcr.Focus();
			}
		}

		private void txtDistrictO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtProvincecr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtProvincecr.Focus();
			}
		}

		private void txtProvinceO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtZIPcr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtZIPcr.Focus();
			}
		}

		private void txtZIPO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtPhonecr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtPhonecr.Focus();
			}
		}

		private void txtPhoneO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtMobilecr.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				txtMobilecr.Focus();
			}
		}

		private void txtMobileO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				btnSave.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				btnSave.Focus();
			}
		}

		private void btnSave_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{

			}
		}

		private void btnCancel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				txtHNcr.Focus();
			}
		}
		#endregion

        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (txtHNps.Text.Trim().Length > 0)
                {
                    BindPresentData(txtHNps.Text);
                }
            }
        }

		private void btnCancel_Click_1(object sender, EventArgs e)
		{
			lbCorrectAlert.Text = "";
			btnSave.Enabled = false;
			SetCurrectPatientNull();
		}

		private void txtHNps_Leave(object sender, EventArgs e)
		{
			txtHNps.Text = OldHN;
			if (lbPresentAlert.Text == "HN Patient Same Currect Patient")
				lbPresentAlert.Text = "";
		}

		private void txtHNcr_Leave(object sender, EventArgs e)
		{
			txtHNcr.Text = NewHN;
			if (lbCorrectAlert.Text == "HN Patient Same Present Patient")
				lbCorrectAlert.Text = "";
		}

	}
}