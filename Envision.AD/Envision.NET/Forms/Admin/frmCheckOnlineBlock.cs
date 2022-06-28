using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Repository;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Forms.Admin
{
    public partial class frmCheckOnlineBlock : MasterForm
    {
        public frmCheckOnlineBlock()
        {
            InitializeComponent();
        }

        private void frmCheckOnlineBlock_Load(object sender, EventArgs e)
        {
            dateSearch.EditValue = DateTime.Now;
            getData();
            base.CloseWaitDialog();
        }

        private void btnGo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ProcessGetRISSessionAppCount getData = new ProcessGetRISSessionAppCount();
            getData.RIS_SESSIONAPPCOUNT.APP_DATE = Convert.ToDateTime(dateSearch.EditValue);
            getData.Invoke();
            DataTable dtt = getData.ResultSet.Tables[0];
            grdData.DataSource = dtt;
            setColumns();
        }
        private void setColumns()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
                viewData.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewData.Columns["MODALITY_NAME"].GroupIndex = 1;

            viewData.Columns["SESSION_NAME"].Caption = "Session";
            viewData.Columns["SESSION_NAME"].OptionsColumn.AllowFocus = false;
            viewData.Columns["SESSION_NAME"].Width = 200;
            viewData.Columns["SESSION_NAME"].SortIndex = 0;
            viewData.Columns["SESSION_NAME"].VisibleIndex = 1;

            RepositoryItemCheckEdit chkIsBlock = new RepositoryItemCheckEdit();
            chkIsBlock.ValueChecked = "Y";
            chkIsBlock.ValueUnchecked = "N";
            chkIsBlock.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkIsBlock.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkIsBlock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkIsBlock.CheckStateChanged += new EventHandler(chkIsBlock_CheckStateChanged);
            viewData.Columns["IS_BLOCKED"].ColumnEdit = chkIsBlock;
            viewData.Columns["IS_BLOCKED"].OptionsColumn.AllowEdit = true;
            viewData.Columns["IS_BLOCKED"].VisibleIndex = 2;
        }

        private void chkIsBlock_CheckStateChanged(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle > -1)
            {
                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                if (row["IS_BLOCKED"].ToString() == "Y")
                    row["IS_BLOCKED"] = "N";
                else
                    row["IS_BLOCKED"] = "Y";

                ProcessUpdateRISSessionAppCount update = new ProcessUpdateRISSessionAppCount();
                update.RIS_SESSIONAPPCOUNT.APP_DATE = Convert.ToDateTime(row["APP_DATE"]);
                update.RIS_SESSIONAPPCOUNT.MODALITY_ID = Convert.ToInt32(row["MODALITY_ID"]);
                update.RIS_SESSIONAPPCOUNT.SESSION_ID = Convert.ToInt32(row["SESSION_ID"]);
                update.RIS_SESSIONAPPCOUNT.IS_BLOCKED = row["IS_BLOCKED"].ToString();
                update.Invoke();
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddOnlineBlock add = new frmAddOnlineBlock();
            add.StartPosition = FormStartPosition.CenterParent;
            add.Text = "Add";
            if (DialogResult.OK == add.ShowDialog())
            {
                //dt.Rows.Add(frmadd.date, frmadd.txtdate, frmadd.modality, frmadd.session);
                //dt.DefaultView.Sort = "date";
            }
        }

    }
}
