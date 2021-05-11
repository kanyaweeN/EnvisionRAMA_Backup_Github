using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Miracle.Util;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleMerge : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int _schedule_id, _modality_id, _reg_id;
        private DateTime _appoint_dt;
        private Patient patient;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        public frmScheduleMerge(int schedule_id, int modality_id, DateTime appoint_dt, string hn)
        {
            InitializeComponent();
            patient = new Patient(hn, true);
            _schedule_id = schedule_id;
            _modality_id = modality_id;
            _reg_id = patient.Reg_ID;

            _appoint_dt = appoint_dt;
        }

        private void frmScheduleMerge_Load(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISSchedule prc = new ProcessGetRISSchedule();
            DataTable dt = prc.getAppointmentMerge(_schedule_id,_modality_id, _appoint_dt, _reg_id);
            if (!dt.Columns.Contains("colCheck"))
                dt.Columns.Add("colCheck");

            grdData.DataSource = dt;
            setGridColumns();

            dlg.Close();
        }
        private void setGridColumns()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
                viewData.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewData.Columns["colCheck"].VisibleIndex = 1;
            viewData.Columns["colCheck"].Caption = " ";
            viewData.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewData.Columns["colCheck"].Width = 30;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            viewData.Columns["colCheck"].ColumnEdit = chk;

            viewData.Columns["START_DATETIME"].Visible = true;
            viewData.Columns["START_DATETIME"].Caption = "Start";
            viewData.Columns["START_DATETIME"].ColVIndex = 4;
            viewData.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewData.Columns["START_DATETIME"].Width = 100;

            viewData.Columns["END_DATETIME"].Visible = true;
            viewData.Columns["END_DATETIME"].Caption = "End";
            viewData.Columns["END_DATETIME"].ColVIndex = 5;
            viewData.Columns["END_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewData.Columns["END_DATETIME"].Width = 100;

            viewData.Columns["MODALITY_NAME"].Visible = true;
            viewData.Columns["MODALITY_NAME"].Caption = "Modality";
            viewData.Columns["MODALITY_NAME"].Width = 100;
            viewData.Columns["MODALITY_NAME"].ColVIndex = 7;

            viewData.Columns["REF_DOC_NAME"].Visible = true;
            viewData.Columns["REF_DOC_NAME"].Caption = "Ordering Doctor";
            viewData.Columns["REF_DOC_NAME"].Width = 100;
            viewData.Columns["REF_DOC_NAME"].ColVIndex = 7;

            viewData.Columns["REF_UNIT_NAME"].Visible = true;
            viewData.Columns["REF_UNIT_NAME"].Caption = "Ordering Dept";
            viewData.Columns["REF_UNIT_NAME"].Width = 100;
            viewData.Columns["REF_UNIT_NAME"].ColVIndex = 7;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit mem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            mem.ScrollBars = ScrollBars.None;
            mem.LinesCount = 0;
            viewData.Columns["SCHEDULE_DATA"].Visible = true;
            viewData.Columns["SCHEDULE_DATA"].Caption = "Schedule Data";
            viewData.Columns["SCHEDULE_DATA"].Width = 500;
            viewData.Columns["SCHEDULE_DATA"].ColumnEdit = mem;
            viewData.Columns["SCHEDULE_DATA"].ColVIndex = 9;
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewData.GetDataRow(viewData.FocusedRowHandle);
            if (chk.Checked)
                rowHandle["colCheck"] = "Y";
            else
                rowHandle["colCheck"] = "N";
        }
        
        private void btnMerge_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (memReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                memReason.Focus();
                return;
            }

            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Processing Data", s);

            ProcessGetRISSchedule prc = new ProcessGetRISSchedule();
            DataSet dsMaster = prc.getAppointmentMerge(_schedule_id);
            DataTable dtGrid = grdData.DataSource as DataTable;
            DataRow[] rowsSelected = dtGrid.Select("colCheck='Y'");

            string _ref_doc_instruction = dsMaster.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            string _clinical_instruction = dsMaster.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            string _reason = memReason.Text.Trim() + "\r\n Old Reason : " + dsMaster.Tables[0].Rows[0]["REASON"].ToString();
            string _text_show = dsMaster.Tables[0].Rows[0]["TEXT_SHOW"].ToString();
            string _comments = dsMaster.Tables[0].Rows[0]["COMMENTS"].ToString();

            #region Insert Merge Exam into RIS_SCHEDULEDTL
            foreach (DataRow rows in rowsSelected)
            {
                DataSet dsDetail = prc.getAppointmentMerge(Convert.ToInt32(rows["SCHEDULE_ID"]));
                if (Utilities.IsHaveData(dsDetail))
                {
                    if (!string.IsNullOrEmpty(dsDetail.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString()))
                        _ref_doc_instruction += "\r\n\r\n [Merge From " + rows["SCHEDULE_ID"].ToString() + "] : " + dsDetail.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                    if (!string.IsNullOrEmpty(dsDetail.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString()))
                        _clinical_instruction += "\r\n\r\n [Merge From " + rows["SCHEDULE_ID"].ToString() + "] : " + dsDetail.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
                    if (!string.IsNullOrEmpty(dsDetail.Tables[0].Rows[0]["REASON"].ToString()))
                        _reason += "\r\n\r\n [Merge From " + rows["SCHEDULE_ID"].ToString() + "] : " + dsDetail.Tables[0].Rows[0]["REASON"].ToString();
                    if (!string.IsNullOrEmpty(dsDetail.Tables[0].Rows[0]["TEXT_SHOW"].ToString()))
                        _text_show += "\r\n\r\n [Merge From " + rows["SCHEDULE_ID"].ToString() + "] : " + dsDetail.Tables[0].Rows[0]["TEXT_SHOW"].ToString();
                    if (!string.IsNullOrEmpty(dsDetail.Tables[0].Rows[0]["COMMENTS"].ToString()))
                        _comments += "\r\n\r\n [Merge From " + rows["SCHEDULE_ID"].ToString() + "] : " + dsDetail.Tables[0].Rows[0]["COMMENTS"].ToString();

                    for (int i = 0; i < dsDetail.Tables[1].Rows.Count; i++)
                    {
                        DataSet dsCheckConflict = prc.checkExamConflictMerge(_schedule_id, Convert.ToInt32(dsDetail.Tables[1].Rows[i]["EXAM_ID"].ToString()));
                        if (!Utilities.IsHaveData(dsCheckConflict))
                        {
                            ProcessAddRISScheduleDtl procDtl = new ProcessAddRISScheduleDtl();
                            procDtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["AVG_REQ_MIN"].ToString());
                            procDtl.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dsDetail.Tables[1].Rows[i]["BPVIEW_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.CREATED_BY = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["CREATED_BY"].ToString());
                            procDtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["EXAM_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.GEN_DTL_ID = string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["GEN_DTL_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dsDetail.Tables[1].Rows[i]["GEN_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.ORG_ID = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["ORG_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.PREPARATION_ID = string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["PREPARATION_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dsDetail.Tables[1].Rows[i]["PREPARATION_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["QTY"].ToString());
                            procDtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["RAD_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dsDetail.Tables[1].Rows[i]["RAD_ID"].ToString());
                            procDtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(dsDetail.Tables[1].Rows[i]["RATE"].ToString());
                            procDtl.RIS_SCHEDULEDTL.SCHEDULE_ID = _schedule_id;
                            procDtl.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["SCHEDULE_PRIORITY"].ToString().Trim()) ? "R" : dsDetail.Tables[1].Rows[i]["SCHEDULE_PRIORITY"].ToString().Trim();
                            if (!string.IsNullOrEmpty(dsDetail.Tables[1].Rows[i]["PAT_DEST_ID"].ToString()))
                                procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = Convert.ToInt32(dsDetail.Tables[1].Rows[i]["PAT_DEST_ID"].ToString());
                            procDtl.Invoke();
                        }
                    }
                }
            } 
            #endregion
            #region Update Merge Appointment into RIS_SCHEDULE
            DataSet dsUpdateMaster = prc.getAppointmentMerge(_schedule_id);
            string patient_id_label = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "" : "[" + patient.PATIENT_ID_LABEL + "]";

            string _schedule_data = "HN : " + patient.Reg_UID + patient_id_label + " " + patient.Title + patient.FirstName.Trim() + " " + patient.LastName.Trim();
            _schedule_data += "; ";
            foreach (DataRow dr in dsUpdateMaster.Tables[1].Rows)
            {
                _schedule_data += dr["EXAM_NAME"].ToString().Trim();// +"; ";
                if (!string.IsNullOrEmpty(dr["RAD_NAME"].ToString()))
                    _schedule_data += " (" + dr["RAD_NAME"].ToString() + ") ; ";
                else
                    _schedule_data += "; ";
            }
            _schedule_data = _schedule_data.Remove(_schedule_data.LastIndexOf(';'), 1);

            if (_text_show.Trim().Length != 0)
                _schedule_data += " (" + _text_show + ") ";

            ProcessUpdateRISSchedule updateAppointMerge = new ProcessUpdateRISSchedule();
            updateAppointMerge.RIS_SCHEDULE.SCHEDULE_ID = _schedule_id;
            updateAppointMerge.RIS_SCHEDULE.SCHEDULE_DATA = _schedule_data;
            updateAppointMerge.RIS_SCHEDULE.REASON = _reason;
            updateAppointMerge.RIS_SCHEDULE.TEXT_SHOW = _text_show;
            updateAppointMerge.RIS_SCHEDULE.REF_DOC_INSTRUCTION = _ref_doc_instruction;
            updateAppointMerge.RIS_SCHEDULE.CLINICAL_INSTRUCTION = _clinical_instruction;
            updateAppointMerge.RIS_SCHEDULE.COMMENTS = _comments;
            updateAppointMerge.UpdateAppointmentMerge();
            #endregion
            #region Remove Merge Appointment
            foreach (DataRow rows in rowsSelected)
            {
                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(rows["SCHEDULE_ID"]);
                process.RIS_SCHEDULE.REASON_CHANGE = memReason.Text.Trim();
                process.RIS_SCHEDULE.REASON = "Merge Appointment";
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();
            }
            #endregion
            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = _schedule_id;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'U';
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Merge Appointment Envision";
            schLogs.Invoke();
            #endregion

            dlg.Close();
            this.Close();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}