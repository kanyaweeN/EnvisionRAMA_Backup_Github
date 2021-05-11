using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmAddOnlineBlock : DevExpress.XtraEditors.XtraForm
    {
        static public string date = "";
        static public string modality = "";
        static public string session = "";

        public frmAddOnlineBlock()
        {
            InitializeComponent();
            loadcontrol();
        }
        public frmAddOnlineBlock(DataRow dr)
        {
            InitializeComponent();
            loadcontrol();

            btnOk.Text = "อัพเดค";

            dateTimePicker1.Value = Convert.ToDateTime(dr.ItemArray[0].ToString());
            string[] moda = dr.ItemArray[2].ToString().Split(',');
            for (int i = 0; i < cbModality.Properties.Items.Count; i++)
            {
                for (int j = 0; j < moda.Length; j++)
                {
                    if (cbModality.Properties.Items[i].Value.ToString().ToLower().Trim() == moda[j].ToString().ToLower().Trim())
                    {
                        cbModality.Properties.Items[i].CheckState = CheckState.Checked;
                        break;
                    }
                }
            }

            dateTimePicker1.Value = Convert.ToDateTime(dr.ItemArray[0].ToString());
            string[] ses = dr.ItemArray[3].ToString().Split(',');
            for (int i = 0; i < cbModality.Properties.Items.Count; i++)
            {
                for (int j = 0; j < ses.Length; j++)
                {
                    if (cbSession.Properties.Items[i].Value.ToString().ToLower().Trim() == ses[j].ToString().ToLower().Trim())
                    {
                        cbSession.Properties.Items[i].CheckState = CheckState.Checked;
                        break;
                    }
                }
            }
        }

        private void loadcontrol()
        {
            cbModality.Properties.Items.Clear();
            ProcessGetRISModality procModality = new ProcessGetRISModality();
            procModality.Invoke();
            DataTable dttModality = procModality.Result.Tables[0];
            foreach (DataRow row in dttModality.Rows)
                cbModality.Properties.Items.Add(row["MODALITY_ID"], row["MODALITY_NAME"].ToString(), CheckState.Checked, true);

            cbSession.Properties.Items.Clear();
            ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
            DataTable dttSession = proc.GetClinicSession().Copy();
            foreach (DataRow row in dttSession.Rows)
                cbSession.Properties.Items.Add(row["SESSION_ID"], row["SESSION_NAME"].ToString(), CheckState.Checked, true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnOk.Text == "ตกลง")
            {
                date = dateTimePicker1.Text;
                //modality = cbModality.Text;
                //session = cbSession.Text;

                if (cbModality.Text == "" || cbSession.Text == "")
                {
                    lbAlert.Text = "กรุณาเลือก Modality และ Session";
                    return;
                }
                else
                {
                    string[] modality = cbModality.EditValue.ToString().Split(',');
                    string[] session = cbSession.EditValue.ToString().Split(',');
                    //DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                    //if (row["IS_BLOCKED"].ToString() == "Y")
                    //    row["IS_BLOCKED"] = "N";
                    //else
                    //    row["IS_BLOCKED"] = "Y";

                    //ProcessUpdateRISSessionAppCount update = new ProcessUpdateRISSessionAppCount();
                    //update.RIS_SESSIONAPPCOUNT.APP_DATE = Convert.ToDateTime(row["APP_DATE"]);
                    //update.RIS_SESSIONAPPCOUNT.MODALITY_ID = Convert.ToInt32(row["MODALITY_ID"]);
                    //update.RIS_SESSIONAPPCOUNT.SESSION_ID = Convert.ToInt32(row["SESSION_ID"]);
                    //update.RIS_SESSIONAPPCOUNT.IS_BLOCKED = row["IS_BLOCKED"].ToString();
                    //update.Invoke();
                }
            }
            else
            {
                date = dateTimePicker1.Text;
                modality = cbModality.Text;
                session = cbSession.Text;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}