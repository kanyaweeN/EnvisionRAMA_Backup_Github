using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.Orders
{
    public partial class frmOrdersCancelForm : Form
    {
        private DataTable tbCancel;
        private DataRow drCancel;

        public frmOrdersCancelForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmOrderCancelForm_Load(object sender, EventArgs e)
        {
            ReloadCancelTemplate();
        }

        private void LoadCancelTemplateData()
        {
            ProcessGetRISOrder getData = new ProcessGetRISOrder();
            tbCancel = getData.GetCancelTemplate();
        }
        private void LoadCancelTemplateFilter()
        {

        }
        private void LoadCancelTemplateGrid()
        {
            gridControl1.DataSource = tbCancel.Copy();

            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;

                k++;
            }

            gridView1.Columns["CAN_UID"].VisibleIndex = 0;
            gridView1.Columns["CAN_UID"].Caption = "Cancel Code";

            gridView1.Columns["CAN_NAME"].VisibleIndex = 1;
            gridView1.Columns["CAN_NAME"].Caption = "Cancel Name";

            gridView1.BestFitColumns();
        }
        private void ReloadCancelTemplate()
        {
            LoadCancelTemplateData();
            LoadCancelTemplateFilter();
            LoadCancelTemplateGrid();
        }

        public DataRow SELECTED
        {
            get { return drCancel; }
            set { drCancel = value; }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = gridView1.FocusedRowHandle;
            if (rowIndex > -1)
            {
                DataRow row = gridView1.GetDataRow(rowIndex);
                string can_uid = row["CAN_NAME"].ToString().Trim(); ;
                if (can_uid == "อื่นๆ")
                {
                    frmOrdersCancelFillReason frmReason
                        = new frmOrdersCancelFillReason();
                    frmReason.ShowDialog();
                    row["CAN_NAME"] = frmReason.REASON;
                }

                SELECTED = row;
                this.DialogResult = DialogResult.OK;
                this.Close();     
            }
        }
    }
}