using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.Common;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Envision.NET.Forms.Admin
{
    public partial class frmSetupHome : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env;
        private DataTable dtEmp;
        public frmSetupHome()
        {
            InitializeComponent();
        }

        private void frmSetupHome_Load(object sender, EventArgs e)
        {
            env = new GBLEnvVariable();
            dtEmp = new DataTable();
            ProcessGetHREmp emp = new ProcessGetHREmp();
            emp.HR_EMP.MODE = "All";
            emp.Invoke();
            dtEmp = emp.Result.Tables[0];

            cmbEmployer.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbEmployer.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in dtEmp.Rows)
                    colls.Add(new EmployeeControl(Convert.ToInt32(dr["EMP_ID"])
                        , dr["FullName"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbEmployer.SelectedIndex = 0;

            base.CloseWaitDialog();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                getEventData();
                setGridEvent();
            }
        }
        private void getEventData()
        {
            ProcessGetGBLNotification nofSelect = new ProcessGetGBLNotification();
            nofSelect.GBL_NOTIFICATION.MODE = 2;
            nofSelect.Invoke();
            grdEvent.DataSource = nofSelect.ResultSet.Tables[0];
        }
        private void setGridEvent()
        {
            for (int i = 0; i < viewEvent.Columns.Count; i++)
            {
                viewEvent.Columns[i].Visible = false;
                viewEvent.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                viewEvent.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewEvent.Columns["SUBJECT"].Visible = true;
            viewEvent.Columns["SUBJECT"].Caption = "Subject";

            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdCmd = new RepositoryItemGridLookUpEdit();
            grdCmd.DataSource = dtEmp;
            
            #region SetGrdLookup
            grdCmd.View.OptionsView.ShowAutoFilterRow = true;
            grdCmd.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            grdCmd.View.OptionsFilter.AllowFilterEditor = false;
            for (int i = 0; i < grdCmd.View.Columns.Count; i++)
            {
                grdCmd.View.Columns[i].Visible = false;
                grdCmd.View.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grdCmd.View.Columns[i].OptionsColumn.AllowEdit = false;
            }

            grdCmd.View.Columns["EMP_UID"].Visible = true;
            grdCmd.View.Columns["EMP_UID"].Caption = "Code";
            grdCmd.View.Columns["FullName"].Visible = true;
            #endregion

            grdCmd.ValueMember = "EMP_ID";
            grdCmd.DisplayMember = "FullName";
            grdCmd.NullText = "";
            viewEvent.Columns["NOTIFICATION_EMP_ID"].ColumnEdit = grdCmd;
            viewEvent.Columns["NOTIFICATION_EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewEvent.Columns["NOTIFICATION_EMP_ID"].Visible = true;
            viewEvent.Columns["NOTIFICATION_EMP_ID"].Caption = "Name";
            viewEvent.Columns["NOTIFICATION_EMP_ID"].OptionsColumn.AllowEdit = true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            EmployeeControl emp = cmbEmployer.SelectedItem as EmployeeControl;

            ProcessAddGBLNotification add = new ProcessAddGBLNotification();
            add.GBL_NOTIFICATION.NOTIFICATION_DESC = rtDescription.Document.RtfText;
            add.GBL_NOTIFICATION.NOTIFICATION_EMP_ID = emp.EMP_ID();
            add.GBL_NOTIFICATION.SUBJECT = txtSubject.Text.Trim();
            add.GBL_NOTIFICATION.CREATED_BY = env.UserID;
            add.Invoke();

            txtSubject.Text = "";
            rtDescription.Document.Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (viewEvent.FocusedRowHandle >= 0)
            {
                DataRow row = viewEvent.GetDataRow(viewEvent.FocusedRowHandle);

                ProcessUpdateGBLNotification up = new ProcessUpdateGBLNotification();
                up.GBL_NOTIFICATION.LAST_MODIFIED_BY = env.UserID;
                up.GBL_NOTIFICATION.NOTIFICATION_DESC = rtEvent.Document.RtfText;
                up.GBL_NOTIFICATION.NOTIFICATION_EMP_ID = Convert.ToInt32(row["NOTIFICATION_EMP_ID"]);
                up.GBL_NOTIFICATION.NOTIFICATION_UID = row["NOTIFICATION_UID"].ToString();
                up.GBL_NOTIFICATION.SUBJECT = row["SUBJECT"].ToString();
                up.GBL_NOTIFICATION.NOTIFICATION_ID = Convert.ToInt32(row["NOTIFICATION_ID"]);
                up.Invoke();
                getEventData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (viewEvent.FocusedRowHandle >= 0)
            {
                DataRow row = viewEvent.GetDataRow(viewEvent.FocusedRowHandle);

                ProcessDeleteGBLNotification del = new ProcessDeleteGBLNotification();
                del.GBL_NOTIFICATION.NOTIFICATION_ID = Convert.ToInt32(row["NOTIFICATION_ID"]);
                del.Invoke();

                getEventData();
                setGridEvent();
            }
        }

        private void viewEvent_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewEvent.FocusedRowHandle >= 0)
            {
                DataRow row = viewEvent.GetDataRow(viewEvent.FocusedRowHandle);
                rtEvent.Document.RtfText = row["NOTIFICATION_DESC"].ToString();
            }
        }
    }
    public class EmployeeControl
    {
        private int _emp_id;
        private string _emp_name;
        public EmployeeControl(int emp_id, string emp_name)
        {
            _emp_id = emp_id;
            _emp_name = emp_name;
        }
        public override string ToString()
        {
            return _emp_name;
        }
        public int EMP_ID()
        {
            return _emp_id;
        }
    }
}
