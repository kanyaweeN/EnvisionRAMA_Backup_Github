using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleDefaultDestination : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttDestination;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private List<int> delItem;
        private DataTable dttModality;
        private DataSet dsDefault;
        private int patId;

        public frmScheduleDefaultDestination()
        {
            InitializeComponent();
            dttDestination = null;
            delItem = new List<int>();
            patId = 0;
        }

        private void loadPatientDestination() { 
            ProcessGetRISPatientDestination proc = new ProcessGetRISPatientDestination();
            proc.RIS_PATIENTDESTINATION.ORG_ID = env.OrgID;
            proc.Invoke();
            if ((proc.Result != null)) {
                dttDestination = new DataTable();
                dttDestination = proc.Result.Tables[0];
                dttDestination.AcceptChanges();
            }
        }
        private void loadDefaultDestination() {
            ProcessGetRISScheduleDefaultDestination proc = new ProcessGetRISScheduleDefaultDestination();
            proc.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
            proc.Invoke();
            dsDefault = proc.Result;
        }
        private void bindDestinationGrid() {
            if (dttDestination == null) return;
            grdDestination.DataSource = dttDestination;
            grdDestination.DataSource = dttDestination;
            for (int i = 0; i < dttDestination.Columns.Count; i++)
            {
                viewDestination.Columns[i].Visible = false;
                viewDestination.Columns[i].OptionsColumn.AllowEdit = false;
            }
            viewDestination.Columns["LABEL"].Visible = true;
            viewDestination.Columns["LABEL"].Caption = "Destination";
            viewDestination.Columns["LABEL"].Width = 160;
        }
      
        private void frmScheduleDefaultDestination_Load(object sender, EventArgs e)
        {
            loadPatientDestination();
            loadDefaultDestination();
            bindDestinationGrid();
            base.CloseWaitDialog();
            sptCtrl.Panel2.Enabled = false;
            loadDefaultModality(0);
            patId = 0;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ("2" == msg.ShowAlert("UID1019", env.CurrentLanguageID)) {
                ProcessAddRISScheduleDefaultDestination proc = new ProcessAddRISScheduleDefaultDestination();
                proc.RIS_SCHEDULEDEFAULTDESTINATION.CREATED_BY = env.UserID;
                proc.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
                proc.RIS_SCHEDULEDEFAULTDESTINATION.ORG_ID = env.OrgID;
                proc.RIS_SCHEDULEDEFAULTDESTINATION.PAT_DEST_ID = patId;
                proc.Invoke();
                if (proc.RIS_SCHEDULEDEFAULTDESTINATION.SCH_DEF_DEST_ID > 0)
                { 
                    foreach(DataRow rowHandle in dttModality.Rows)
                        if (rowHandle["colCheck"].ToString() == "Y") {
                            ProcessAddRISScheduleDefaultModality procModality = new ProcessAddRISScheduleDefaultModality();
                            procModality.RIS_SCHEDULEDEFAULTMODALITY.CREATED_BY = env.UserID;
                            procModality.RIS_SCHEDULEDEFAULTMODALITY.LAST_MODIFIED_BY = env.UserID;
                            procModality.RIS_SCHEDULEDEFAULTMODALITY.MODALITY_ID = Convert.ToInt32(rowHandle["MODALITY_ID"].ToString());
                            procModality.RIS_SCHEDULEDEFAULTMODALITY.ORG_ID = env.OrgID;
                            procModality.RIS_SCHEDULEDEFAULTMODALITY.SCH_DEF_DEST_ID = proc.RIS_SCHEDULEDEFAULTDESTINATION.SCH_DEF_DEST_ID;
                            procModality.Invoke();
                        }
                }
                dttDestination = new DataTable();
                delItem = new List<int>();
                loadPatientDestination();
                loadDefaultDestination();
                bindDestinationGrid();
                rbEdit.Visible = true;
                rbSave.Visible = false;
                rbCancel.Visible = false;
                sptCtrl.Panel2.Enabled = false;
                loadDefaultModality(0); 
                grdDestination.Enabled = true;
            }   
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bindDefaultModality() {
            if (dttModality == null) return;
            grdModality.DataSource = dttModality;
            for (int i = 0; i < dttModality.Columns.Count; i++)
            {
                viewModality.Columns[i].Visible = false;
                viewModality.Columns[i].OptionsColumn.AllowEdit = false;
            }
            viewModality.OptionsView.ShowAutoFilterRow = true;
            viewModality.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewModality.OptionsSelection.EnableAppearanceFocusedRow = true;

            viewModality.Columns["colCheck"].Visible = true;
            viewModality.Columns["MODALITY_UID"].Visible = true;
            viewModality.Columns["MODALITY_NAME"].Visible = true;

            viewModality.Columns["colCheck"].VisibleIndex = 1;
            viewModality.Columns["MODALITY_UID"].VisibleIndex = 2;
            viewModality.Columns["MODALITY_NAME"].VisibleIndex = 3;


            viewModality.Columns["colCheck"].Caption = " ";
            viewModality.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewModality.Columns["colCheck"].Width = 30;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            viewModality.Columns["colCheck"].ColumnEdit = chk;

            viewModality.Columns["MODALITY_UID"].Caption = "Code";
            viewModality.Columns["MODALITY_UID"].Width = 100;

            viewModality.Columns["MODALITY_NAME"].Caption = "Modality Name";
            viewModality.Columns["MODALITY_NAME"].Width = 350;
        }
        private void loadDefaultModality(int Id) {
            ScheduleInfo info = new ScheduleInfo();
            DataTable dtt = info.GetModality();
            dttModality = dtt.Clone();
            dttModality.Columns.Add("colCheck", typeof(string));
            dttModality.AcceptChanges();
            patId = Id;
            DataRow[] rows = dtt.Select("PAT_DEST_ID=" + Id);
            if (rows.Length > 0) {
                foreach (DataRow rowHandle in rows) {
                    DataRow rowAdd = dttModality.NewRow();
                    for (int i = 0; i < dtt.Columns.Count; i++) rowAdd[i] = rowHandle[i];
                    dttModality.Rows.Add(rowAdd);
                    dttModality.AcceptChanges();
                }
                dtt = dsDefault.Tables[0];
                rows = dtt.Select("PAT_DEST_ID=" + Id);
                if (rows.Length > 0) {
                    dtt = dsDefault.Tables[1];
                    foreach (DataRow rowHandle in dtt.Rows) { 
                        foreach(DataRow rowUpdate in dttModality.Rows)
                            if (rowHandle["MODALITY_ID"].ToString() == rowUpdate["MODALITY_ID"].ToString()) {
                                rowUpdate["colCheck"] = "Y";
                                break;
                            }
                    }
                    dttModality.AcceptChanges();
                }
            }
            bindDefaultModality();
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (viewModality.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewModality.GetDataRow(viewModality.FocusedRowHandle);
            if (chk.Checked)
                rowHandle["colCheck"] = "Y";
            else
                rowHandle["colCheck"] = "N";

        }

        private void viewDestination_DoubleClick(object sender, EventArgs e)
        {
            if (viewDestination.FocusedRowHandle < 0) return;
            sptCtrl.Panel2.Enabled = true;
            rbEdit.Visible = false;
            rbSave.Visible = true;
            rbCancel.Visible = true;
            grdDestination.Enabled = false;
        }
        private void viewDestination_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (viewDestination.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewDestination.GetDataRow(viewDestination.FocusedRowHandle);
            loadDefaultModality(Convert.ToInt32(rowHandle["PAT_DEST_ID"].ToString()));
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (patId == 0) return;
            sptCtrl.Panel2.Enabled = true;
            rbEdit.Visible = false;
            rbSave.Visible = true;
            rbCancel.Visible = true;
            grdDestination.Enabled = false;
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rbEdit.Visible = true;
            rbSave.Visible = false;
            rbCancel.Visible = false;
            sptCtrl.Panel2.Enabled = false;
            grdDestination.Enabled = true;
        }
    }
}
