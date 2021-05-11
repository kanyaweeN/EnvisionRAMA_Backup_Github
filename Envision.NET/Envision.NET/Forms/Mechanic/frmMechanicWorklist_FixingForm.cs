using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessUpdate;


namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMechanicWorklist_FixingForm : Form
    {
        DataRow drMTNData;
        List<string> listStatus = new List<string>();

        public frmMechanicWorklist_FixingForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmMechanicWorklist_FixingForm(DataRow dataRow)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.drMTNData = dataRow;

            if (dataRow["MTN_SCH_STATUS"].ToString() == "N")
                LoadDatatxtStatus_ForNew();
            else if (dataRow["MTN_SCH_STATUS"].ToString() == "W")
                LoadDatatxtStatus_ForWorkInProgress();
            else if (dataRow["MTN_SCH_STATUS"].ToString() == "C"
                        || dataRow["MTN_SCH_STATUS"].ToString() == "P"
                        || dataRow["MTN_SCH_STATUS"].ToString() == "X")
                LoadDatatxtStatus_ForComp_ForPostp_ForCanc();
            else
                return;

            LoadTextFilling();
        }

        private void LoadDatatxtStatus_ForNew()
        {
            txtStatus.Properties.Items.Clear();
            txtStatus.Properties.Items.Add("Work in Progress");
            txtStatus.Properties.Items.Add("Completed");
            txtStatus.Properties.Items.Add("Postponed");
            txtStatus.Properties.Items.Add("Canceled");

            txtStatus.SelectedItem = 0;
        }

        private void LoadDatatxtStatus_ForWorkInProgress()
        {
            txtStatus.Properties.Items.Clear();
            txtStatus.Properties.Items.Add("Work in Progress");
            txtStatus.Properties.Items.Add("Completed");
            txtStatus.Properties.Items.Add("Postponed");
            txtStatus.Properties.Items.Add("Canceled");

            txtStatus.SelectedItem = 0;
        }

        private void LoadDatatxtStatus_ForComp_ForPostp_ForCanc()
        {
            txtStatus.Properties.Items.Clear();
            txtStatus.Properties.Items.Add("Work in Progress");

            txtStatus.SelectedItem = 0;
        }

        private void LoadTextFilling()
        {
            txtComment.Text = drMTNData["COMMENTS"].ToString();
            txtStatus.SelectedIndex = 0;

            DateTime date = Convert.ToDateTime(drMTNData["MTN_DT"]);

            txtMTNDate.EditValue = date.ToString("dd-MM-yyyy HH:mm:ss");
            txtMTNType.EditValue = drMTNData["MTN_TYPE_UID"].ToString();
            txtMTNCost.EditValue = drMTNData["MTN_COST"].ToString();
            txtModName.EditValue = drMTNData["MODALITY_NAME"].ToString();

            date = Convert.ToDateTime(drMTNData["START_TIME"]);
            txtModStart.EditValue = date.ToString("dd-MM-yyyy HH:mm:ss");
            date = Convert.ToDateTime(drMTNData["END_TIME"]);
            txtModEnd.EditValue = date.ToString("dd-MM-yyyy HH:mm:ss");

            string status = drMTNData["MTN_SCH_STATUS"].ToString();
            switch (status)
            {
                case "N":
                    txtStatus.SelectedText = "New";
                    break;
                case "W":
                    txtStatus.SelectedText = "Work in Progress";
                    break;
                case "C":
                    txtStatus.SelectedText = "Completed";
                    break;
                case "P":
                    txtStatus.SelectedText = "Postponed";
                    break;
                case "X":
                    txtStatus.SelectedText = "CanceledS";
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessUpdateRISModalitymaintenancescheduleChangeStatus updateChangeStatus 
                = new ProcessUpdateRISModalitymaintenancescheduleChangeStatus();
            
            string status = "";
            switch(txtStatus.SelectedItem.ToString())
            {
                case "New" :
                    status = "N";
                    break;
                case "Work in Progress" :
                    status = "W";
                    break;
                case "Completed" :
                    status = "C";
                    break;
                case "Postponed":
                    status = "P";
                    break;
                case "Canceled" :
                    status = "X";
                    break;
            }

            int mtnSchId = Convert.ToInt32(drMTNData["MTN_SCH_ID"]);
            updateChangeStatus.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtnSchId;
            updateChangeStatus.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_STATUS = status;
            updateChangeStatus.RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS = txtComment.Text;
            updateChangeStatus.Invoke();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
