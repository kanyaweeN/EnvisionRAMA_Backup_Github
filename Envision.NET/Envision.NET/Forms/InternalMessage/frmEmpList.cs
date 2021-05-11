using System;
using System.Data;
using System.Windows.Forms;

namespace Envision.NET.Forms.InternalMessage
{
    public partial class frmEmpList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataView dvEmpList { get; set; }
        public bool IsOneClick { get; set; }

        public frmEmpList()
        {
            InitializeComponent();
            IsOneClick = false;
        }

        private void frmEmpList_Load(object sender, EventArgs e)
        {

            viewEmp.DataSource = dvEmpList;
        }

       


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (row["IS_SELECTED"].ToString().Trim() == "True")
                    row["IS_SELECTED"] = "False";
                else
                {
                    row["IS_SELECTED"] = "True";
                    if (IsOneClick)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (DataRowView _item in dvEmpList)
            {
                _item["IS_SELECTED"] = "False";
            }
            DialogResult = DialogResult.Cancel;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
