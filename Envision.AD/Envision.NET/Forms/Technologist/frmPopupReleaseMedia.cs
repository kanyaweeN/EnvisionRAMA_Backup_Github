using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmPopupReleaseMedia : Form
    {
        private DataRow[] dr;
        private GBLEnvVariable env = new GBLEnvVariable();
        private int RequestByID;
        private string RequestBy;
        private int RequestDept;
        public frmPopupReleaseMedia()
        {
            InitializeComponent();
        }
        public frmPopupReleaseMedia(DataRow[] drData)
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
            lblHn.Text = dr[0]["HN"].ToString();
            lblAccession.Text = dr[0]["ACCESSION_NO"].ToString();
            lblPatientName.Text = dr[0]["PATIENTNAME"].ToString();
            lblAge.Text = dr[0]["AGE"].ToString();

            if (radioGroup1.SelectedIndex == 0)
            {
                txtRequestBy.Text = dr[0]["PATIENTNAME"].ToString();
                RequestByID = Convert.ToInt32(dr[0]["REG_ID"]);
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
            if(dt.Rows.Count>0)
                luMediatype.EditValue = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            
        }
        private void setComboboxReason() 
        {
            LookUpSelect lvS = new LookUpSelect();
            DataTable dt = lvS.SelectReleaseCombobox("REASON").Tables[0];

            luReason.Properties.DataSource = dt;
            luReason.Properties.DisplayMember = "TEXT";
            luReason.Properties.ValueMember = "ID";
            if (dt.Rows.Count > 0)
                luReason.EditValue = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                txtRequestBy.Enabled = false;
                txtRequestBy.ReadOnly = true;
                btnRequestBy.Enabled = false;
                txtRequestBy.Text = dr[0]["PATIENTNAME"].ToString();
                RequestByID = Convert.ToInt32(dr[0]["REG_ID"]);
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

            foreach (DataRow row in dr)
            {
                ProcessAddRISReleasemedia add = new ProcessAddRISReleasemedia();
                add.RIS_RELEASEMEDIA.COMMENT = memComment.Text;
                add.RIS_RELEASEMEDIA.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
                add.RIS_RELEASEMEDIA.HN = row["HN"].ToString();

                add.RIS_RELEASEMEDIA.MEDIA_TYPE = Convert.ToChar(luMediatype.EditValue.ToString());
                add.RIS_RELEASEMEDIA.REASON = Convert.ToChar(luReason.EditValue.ToString());
                add.RIS_RELEASEMEDIA.RECEIVED_BY = txtRecieve.Text.Trim();
                add.RIS_RELEASEMEDIA.RELEASE_DATE = DateTime.Now;
                add.RIS_RELEASEMEDIA.REQUEST_BY = Convert.ToChar(RequestBy);
                add.RIS_RELEASEMEDIA.REQUEST_BY_ID = RequestByID;
                add.RIS_RELEASEMEDIA.UNIT_ID = RequestDept;
                add.RIS_RELEASEMEDIA.ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);
                add.RIS_RELEASEMEDIA.LAST_MODIFIED_BY = env.UserID;
                add.RIS_RELEASEMEDIA.CREATED_BY = env.UserID;
                add.RIS_RELEASEMEDIA.QTY = Convert.ToByte(speQTY.Value);
                add.Invoke(); 
            }
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

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            RequestByID = Convert.ToInt32(retValue[0]);
            txtRequestBy.Text = retValue[2];

        }

        private void btnRequestDept_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_UnitCode(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            RequestDept = Convert.ToInt32(retValue[0]);
            txtRequestDept.Text = retValue[1] + ":" + retValue[2];
        }
    }
}