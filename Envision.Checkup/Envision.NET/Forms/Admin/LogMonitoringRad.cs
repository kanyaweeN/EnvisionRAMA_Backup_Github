using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Admin
{
    public partial class LogMonitoringRad : Form
    {
        DataTable dtRad = new DataTable();
        DevExpress.XtraEditors.ButtonEdit ct;

        public LogMonitoringRad(DevExpress.XtraEditors.ButtonEdit control)
        {
            InitializeComponent();
            ct = control;
            LoadTableRad();
            LoadGridRad();
        }

        private void LoadTableRad()
        {
            RIS.BusinessLogic.ResultEntry br = new RIS.BusinessLogic.ResultEntry();
            DataTable dt = br.GetRadiologist().Copy();
            dt.Columns.Add("CHECK");
            foreach (DataRow dr in dt.Rows)
                dr["CHECK"] = "N";

            if (ct.Tag != null)
            {
                string[] empid = ct.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (string id in empid)
                    {
                        if (dr["EMP_ID"].ToString() == id)
                            dr["CHECK"] = "Y";
                    }
                }
            }

            dt.AcceptChanges();
            dtRad = dt.Copy();
        }

        private void LoadGridRad()
        {
            gridControl1.DataSource = dtRad.Copy();
            gridView1.RefreshData();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView1.Columns["EMP_UID"].VisibleIndex = 1;
            gridView1.Columns["EMP_UID"].Caption = "Radiologist Code";
            gridView1.Columns["EMP_UID"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["EMP_UID"].Width = 75;

            gridView1.Columns["RadioName"].VisibleIndex = 2;
            gridView1.Columns["RadioName"].Caption = "Radiologist Name";
            gridView1.Columns["RadioName"].Width = 200;

            gridView1.Columns["CHECK"].VisibleIndex = 3;
            gridView1.Columns["CHECK"].Caption = "";
            gridView1.Columns["CHECK"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["CHECK"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["CHECK"].Width = 50;

            #endregion

            #region setRepoItem

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            gridView1.Columns["CHECK"].ColumnEdit = chk;

            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
            DataRow[] drs = ((DataTable)gridControl1.DataSource).Select("CHECK='Y'");
            if (drs.Length > 0)
            {
                ct.Text = "";
                ct.Tag = null;
                for (int i = 0; i < drs.Length; i++)
                {
                    ct.Text += drs[i]["RadioName"].ToString();
                    ct.Tag += drs[i]["EMP_ID"].ToString();

                    if (i + 1 < drs.Length)
                    {
                        ct.Text += ",";
                        ct.Tag += "#";
                    }
                }
            }
            else
            {
                ct.Tag = null;
                ct.Text = "";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "CHECK", "Y");
            }
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "CHECK", "N");
            }
        }

        private void gridRadView_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr["CHECK"].ToString() == "Y")
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CHECK", "N");
                else
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CHECK", "Y");
            }
        }

    }
}