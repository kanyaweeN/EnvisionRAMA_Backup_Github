using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;

namespace Envision.NET.Forms.Admin
{
    public partial class frmSetupSessionMaxApp : MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        public frmSetupSessionMaxApp()
        {
            InitializeComponent();
        }

        private void frmSetupSessionMaxApp_Load(object sender, EventArgs e)
        {
            ProcessGetRISSessionMaxapp prc = new ProcessGetRISSessionMaxapp();
            prc.InvokeGetSetupData();
            DataTable dtt = prc.Result.Tables[0];
            dtt.Columns.Add("btnUpdate");
            grdData.DataSource = dtt;
            setColumns();
            base.CloseWaitDialog();
        }
        private void setColumns()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
                viewData.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewData.Columns["MODALITY_NAME"].GroupIndex = 1;
            viewData.Columns["SESSION_NAME"].GroupIndex = 2;

            viewData.Columns["DAY_NAME"].Caption = "Days of week";
            viewData.Columns["DAY_NAME"].OptionsColumn.AllowFocus = false;
            viewData.Columns["DAY_NAME"].Width = 200;
            viewData.Columns["DAY_NAME"].SortIndex = 0;
            viewData.Columns["DAY_NAME"].VisibleIndex = 1;

            RepositoryItemSpinEdit speMaxApp = new RepositoryItemSpinEdit();
            speMaxApp.ValueChanged += new EventHandler(speMaxApp_ValueChanged);
            viewData.Columns["MAX_APP"].Caption = "Max of Session";
            viewData.Columns["MAX_APP"].OptionsColumn.AllowEdit = true;
            viewData.Columns["MAX_APP"].OptionsColumn.ReadOnly = false;
            viewData.Columns["MAX_APP"].ColumnEdit = speMaxApp;
            viewData.Columns["MAX_APP"].Width = 150;
            viewData.Columns["MAX_APP"].VisibleIndex = 2;

            RepositoryItemSpinEdit speMaxOnlApp = new RepositoryItemSpinEdit();
            speMaxOnlApp.ValueChanged += new EventHandler(speMaxOnlApp_ValueChanged);
            viewData.Columns["MAX_ONLINE_APP"].Caption = "Online Max of Session";
            viewData.Columns["MAX_ONLINE_APP"].OptionsColumn.AllowEdit = true;
            viewData.Columns["MAX_ONLINE_APP"].ColumnEdit = speMaxOnlApp;
            viewData.Columns["MAX_ONLINE_APP"].Width = 150;
            viewData.Columns["MAX_ONLINE_APP"].VisibleIndex = 3;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btn.Buttons[0].Caption = "Update";
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Click += new EventHandler(btn_Click);
            viewData.Columns["btnUpdate"].OptionsColumn.AllowEdit = true;
            viewData.Columns["btnUpdate"].Caption = " ";
            viewData.Columns["btnUpdate"].ColumnEdit = btn;
            viewData.Columns["btnUpdate"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            viewData.Columns["btnUpdate"].Width = 100;
            viewData.Columns["btnUpdate"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewData.Columns["btnUpdate"].VisibleIndex = 4;
        }

        private void speMaxOnlApp_ValueChanged(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {

                DevExpress.XtraEditors.SpinEdit spe = new DevExpress.XtraEditors.SpinEdit();
                spe = (DevExpress.XtraEditors.SpinEdit)sender;
                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                int sp = Convert.ToInt32(spe.Value.ToString());
                if (sp > 0)
                {
                    row["MAX_ONLINE_APP"] = sp;
                    row.AcceptChanges();
                }
            }
        }

        private void speMaxApp_ValueChanged(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {

                DevExpress.XtraEditors.SpinEdit spe = new DevExpress.XtraEditors.SpinEdit();
                spe = (DevExpress.XtraEditors.SpinEdit)sender;
                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                int sp = Convert.ToInt32(spe.Value.ToString());
                if (sp > 0)
                {
                    row["MAX_APP"] = sp;
                    row.AcceptChanges();
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Loading Worklist Data", s);

                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);

                ProcessUpdateRISSessionmaxapp upData = new ProcessUpdateRISSessionmaxapp();
                upData.RIS_SESSIONMAXAPP.LAST_MODIFIED_BY = env.UserID;
                upData.RIS_SESSIONMAXAPP.MAX_APP = string.IsNullOrEmpty(row["MAX_APP"].ToString()) ? Convert.ToByte(0) : Convert.ToByte(row["MAX_APP"]);
                upData.RIS_SESSIONMAXAPP.MAX_IPD_APP = string.IsNullOrEmpty(row["MAX_IPD_APP"].ToString()) ? 0 : Convert.ToInt32(row["MAX_IPD_APP"]);
                upData.RIS_SESSIONMAXAPP.MAX_ONLINE_APP = string.IsNullOrEmpty(row["MAX_ONLINE_APP"].ToString()) ? 0 : Convert.ToInt32(row["MAX_ONLINE_APP"]);
                upData.RIS_SESSIONMAXAPP.MODALITY_ID = string.IsNullOrEmpty(row["MODALITY_ID"].ToString()) ? 0 : Convert.ToInt32(row["MODALITY_ID"]);
                upData.RIS_SESSIONMAXAPP.SESSION_ID = Convert.ToInt32(row["SESSION_ID"]);
                upData.RIS_SESSIONMAXAPP.WEEKDAY = Convert.ToByte(row["WEEKDAY"]);
                upData.Invoke();

                //ProcessGetRISSessionMaxapp prc = new ProcessGetRISSessionMaxapp();
                //prc.InvokeGetSetupData();
                //DataTable dtt = prc.Result.Tables[0];
                //dtt.Columns.Add("btnUpdate");
                //grdData.DataSource = dtt;
                //setColumns();

                dlg.Close();
            }
        }
    }
}
