using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.Forms.Technologist
{
    public partial class frmPopupReleaseMedia : Form
    {
        private DataRow dr;
        private GBLEnvVariable env = new GBLEnvVariable();
        private int RequestByID;
        private string RequestBy;
        private int RequestDept;
        public frmPopupReleaseMedia()
        {
            InitializeComponent();
        }
        public frmPopupReleaseMedia(DataRow drData)
        {
            InitializeComponent();
            dr = drData;
        }

        private void frmPopupReleaseMedia_Load(object sender, EventArgs e)
        {
            setComboboxMediatype();
            setComboboxReason();
            BindData();
        }
        private void BindData()
        {
            lblHn.Text = dr["HN"].ToString();
            lblAccession.Text = dr["ACCESSION_NO"].ToString();
            lblPatientName.Text = dr["PATIENTNAME"].ToString();
            lblAge.Text = dr["AGE"].ToString();

            if (radioGroup1.SelectedIndex == 0)
            {
                txtRequestBy.Text = dr["PATIENTNAME"].ToString();
                RequestByID = Convert.ToInt32(dr["REG_ID"]);
                RequestBy = "P";
            }
            txtRequestDept.Enabled = false;
        }
        private void setComboboxMediatype()
        {
            LookUpSelect lvS = new LookUpSelect();
            DataTable dt = lvS.SelectReleaseCombobox("MEDIATYPE").Tables[0];

            luMediatype.Properties.DataSource = dt;
            luMediatype.Properties.DisplayMember = "TEXT";
            luMediatype.Properties.ValueMember = "ID";
            luMediatype.EditValue = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
        private void setComboboxReason()
        {
            LookUpSelect lvS = new LookUpSelect();
            DataTable dt = lvS.SelectReleaseCombobox("REASON").Tables[0];

            luReason.Properties.DataSource = dt;
            luReason.Properties.DisplayMember = "TEXT";
            luReason.Properties.ValueMember = "ID";
            luReason.EditValue = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                txtRequestBy.Enabled = false;
                txtRequestBy.ReadOnly = true;
                btnRequestBy.Enabled = false;
                txtRequestBy.Text = dr["PATIENTNAME"].ToString();
                RequestByID = Convert.ToInt32(dr["REG_ID"]);
                RequestBy = "P";
            }
            else if(radioGroup1.SelectedIndex == 1)
            {
                txtRequestBy.Enabled = false;
                txtRequestBy.ReadOnly = false;
                btnRequestBy.Enabled = true;
                txtRequestBy.Text = "";
                RequestByID = 0;
                RequestBy = "C";
            }
            else
            {
                txtRequestBy.Enabled = false;
                txtRequestBy.ReadOnly = true;
                btnRequestBy.Enabled = false;
                txtRequestBy.Text = "Nurse";
                RequestByID = 0;
                RequestBy = "N";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequestDept.Text))
            {
                txtRequestDept.Enabled = true;
                txtRequestDept.Focus();
                return;
            }

            if (radioGroup1.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(txtRequestBy.Text))
                {
                    txtRequestBy.Enabled = true;
                    txtRequestBy.ReadOnly = true;
                    txtRequestBy.Focus();
                    return;
                } 
            }

            ProcessAddRISReleasemedia add = new ProcessAddRISReleasemedia();
            add.RISReleasemedia.COMMENT = memComment.Text;
            add.RISReleasemedia.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
            add.RISReleasemedia.HN = dr["HN"].ToString();

            add.RISReleasemedia.MEDIA_TYPE = luMediatype.EditValue.ToString();
            add.RISReleasemedia.REASON = luReason.EditValue.ToString();
            add.RISReleasemedia.RECEIVED_BY = txtRecieve.Text.Trim();
            add.RISReleasemedia.RELEASE_DATE = DateTime.Now;
            add.RISReleasemedia.REQUEST_BY = RequestBy;
            add.RISReleasemedia.REQUEST_BY_ID = RequestByID;
            add.RISReleasemedia.UNIT_ID = RequestDept;
            add.RISReleasemedia.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
            add.RISReleasemedia.LAST_MODIFIED_BY = env.UserID;
            add.RISReleasemedia.CREATED_BY = env.UserID;
            add.RISReleasemedia.QTY = Convert.ToByte(speQTY.Value);
            add.Invoke();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRequestBy_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            RequestByID = Convert.ToInt32(retValue[0]);
            txtRequestBy.Text = retValue[2];

        }

        private void btnRequestDept_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_UnitCode(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            RequestDept = Convert.ToInt32(retValue[0]);
            txtRequestDept.Text = retValue[1] + ":" + retValue[2];
        }
    }
}