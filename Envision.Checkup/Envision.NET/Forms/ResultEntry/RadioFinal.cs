using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
namespace RIS.Forms.ResultEntry
{
    public partial class RadioFinal : Form
    {
        private RIS.BusinessLogic.ResultEntry result;
        private int id;

        public RadioFinal()
        {
            InitializeComponent();
            result = new RIS.BusinessLogic.ResultEntry();
            initDataLookup();
            id = 0;
        }

        private void initDataLookup() {
            DataTable dtt = result.GetRadioFinalize();
            lookData.Properties.DisplayMember = "RadioName";
            lookData.Properties.ValueMember = "EMP_ID";
            lookData.Properties.DataSource = dtt;
            
            if (dtt.Rows.Count > 0)
                lookData.EditValue = dtt.Rows[0]["EMP_ID"].ToString();

            gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
          
            gridLookUpEdit1View.Columns["EMP_ID"].Caption = "ID";
            gridLookUpEdit1View.Columns["EMP_ID"].Visible = false;

            gridLookUpEdit1View.Columns["EMP_UID"].Caption = "Code";
            gridLookUpEdit1View.Columns["EMP_UID"].Visible = true;

            gridLookUpEdit1View.Columns["RadioName"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridLookUpEdit1View.Columns["RadioName"].Visible = true;

            gridLookUpEdit1View.Columns["ALLOW_OTHERS_TO_FINALIZE"].Visible = false;
            gridLookUpEdit1View.Columns["AUTH_LEVEL_ID"].Visible = false;

            gridLookUpEdit1View.BestFitColumns();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            id = 0;
            if (gridLookUpEdit1View.FocusedRowHandle > -1)
                id = Convert.ToInt32(gridLookUpEdit1View.GetDataRow(gridLookUpEdit1View.FocusedRowHandle)["EMP_ID"].ToString());
             
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public int FinalizeID {
            get { return id; }
        }
        public string FinalizedName {
            get {
                string str = string.Empty;
                if (gridLookUpEdit1View.FocusedRowHandle > -1)
                    str = gridLookUpEdit1View.GetDataRow(gridLookUpEdit1View.FocusedRowHandle)["RadioName"].ToString();
                return str;
            }
        }
        public string Finalized_UID
        {
            get
            {
                string str = string.Empty;
                if (gridLookUpEdit1View.FocusedRowHandle > -1)
                    str = gridLookUpEdit1View.GetDataRow(gridLookUpEdit1View.FocusedRowHandle)["EMP_UID"].ToString();
                return str;
            }
        }
    }
}