using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Admin
{
    public partial class ExamresultLog_Radiologist : Form
    {
        DataTable dtRad = new DataTable();
        DevExpress.XtraEditors.ButtonEdit ct;

        public ExamresultLog_Radiologist(DevExpress.XtraEditors.ButtonEdit control)
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
            gridRad.DataSource = dtRad.Copy();
            gridRadView.RefreshData();

            for (int i = 0; i < gridRadView.Columns.Count; i++)
            {
                gridRadView.Columns[i].Visible = false;
                gridRadView.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridRadView.Columns["EMP_UID"].VisibleIndex = 1;
            gridRadView.Columns["EMP_UID"].Caption = "Radiologist Code";
            gridRadView.Columns["EMP_UID"].OptionsColumn.FixedWidth = true;
            gridRadView.Columns["EMP_UID"].Width = 75;

            gridRadView.Columns["RadioName"].VisibleIndex = 2;
            gridRadView.Columns["RadioName"].Caption = "Radiologist Name";
            gridRadView.Columns["RadioName"].Width = 200;

            gridRadView.Columns["CHECK"].VisibleIndex = 3;
            gridRadView.Columns["CHECK"].Caption = "";
            gridRadView.Columns["CHECK"].OptionsColumn.FixedWidth = true;
            gridRadView.Columns["CHECK"].OptionsColumn.AllowEdit = true;
            gridRadView.Columns["CHECK"].Width = 50;

            #endregion

            #region setRepoItem

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            gridRadView.Columns["CHECK"].ColumnEdit = chk;

            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gridRadView.RefreshData();
            DataRow[] drs = ((DataTable)gridRad.DataSource).Select("CHECK='Y'");
            if (drs.Length > 0)
            {
                ct.Text = "";
                ct.Tag = null;
                for(int i = 0;i<drs.Length;i++)
                { 
                    ct.Text += drs[i]["RadioName"].ToString();
                    ct.Tag += drs[i]["EMP_ID"].ToString();

                    if (i+1 < drs.Length)
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

        private void gridRadView_Click(object sender, EventArgs e)
        {
            //if (gridRadView.FocusedRowHandle > -1)
            //{
            //    DataRow dr = gridRadView.GetDataRow(gridRadView.FocusedRowHandle);
            //    if (dr["CHECK"].ToString() == "Y")
            //        ((DataTable)gridRad.DataSource).Rows[gridRadView.FocusedRowHandle]["CHECK"] = "N";
            //    else if (dr["CHECK"].ToString() == "N")
            //        ((DataTable)gridRad.DataSource).Rows[gridRadView.FocusedRowHandle]["CHECK"] = "Y";
                
            //    gridRadView.RefreshData();
            //}
        }

    }
}