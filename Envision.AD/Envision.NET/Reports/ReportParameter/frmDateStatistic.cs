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
using Envision.Common;
using Envision.BusinessLogic;
using Miracle.Util;
using Miracle.Scanner;
using Envision.NET.Forms.Dialog;
using DevExpress.Utils;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmDateStatistic : MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        public frmDateStatistic()
        {
            InitializeComponent();
        }

        private void frmDateStatistic_Load(object sender, EventArgs e)
        {
            initialMode();
            initialModalityData();
            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;

            cmbMode.SelectedIndex = 0;
            search();
            this.CloseWaitDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            if (cmbMode.SelectedIndex >= 0)
            {
                this.ShowWaitDialog(cmbMode.Text + " loading..", "Preparing Data");
                DateTime dateF = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0);
                DateTime dateT = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);
                LookUpSelect lvS = new LookUpSelect();
                DataSet ds = lvS.SelectDateStatistic(cmbMode.SelectedIndex, dateF, dateT);
                if (Utilities.IsHaveData(ds))
                {
                    DataView dv = ds.Tables[0].DefaultView;
                    if (string.IsNullOrEmpty(chkcmbModality.EditValue.ToString()))
                        dv.RowFilter = "MODALITY_ID in (0)";
                    else
                        dv.RowFilter = "MODALITY_ID in (" + chkcmbModality.EditValue + ")";

                    generateColumns(dv.ToTable(), ds.Tables[1]);
                }

                this.CloseWaitDialog();
            }
        }
        private void generateColumns(DataTable Data, DataTable disableColumns)
        {
            viewData.Columns.Clear();
            grdData.DataSource = Data;
            viewData.RefreshData();
            for (int i = 0; i < Data.Columns.Count; i++)
                viewData.Columns[i].OptionsColumn.AllowEdit = false;

            foreach (DataRow row in disableColumns.Rows)
                viewData.Columns[row["COL"].ToString()].Visible = false;

            if (Data.Columns.Contains("CHK"))
            {
                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
           chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkTemplate.ValueChecked = "Y";
                chkTemplate.ValueUnchecked = "N";
                chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
                chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                chkTemplate.Click += new EventHandler(chkTemplate_Click);

                viewData.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                viewData.Columns["CHK"].ColVIndex = 1;
                viewData.Columns["CHK"].Caption = " ";
                viewData.Columns["CHK"].ColumnEdit = chkTemplate;
                viewData.Columns["CHK"].OptionsColumn.ReadOnly = false;
                viewData.Columns["CHK"].OptionsColumn.AllowEdit = true;
                viewData.Columns["CHK"].Width = 10;
            }
        }
        private void chkTemplate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (viewData.FocusedRowHandle >= 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);
                if (cmbMode.SelectedIndex == 1)
                {
                    int sche_id = Convert.ToInt32(dr["SCHEDULE_ID"]);
                    string is_protocal = chk.Checked ? "N" : "Y";
                    ProcessUpdateRISSchedule updateIsProtocal = new ProcessUpdateRISSchedule();
                    updateIsProtocal.UpdateIsProtocal(is_protocal, sche_id, env.UserID);

                    #region insert schedule logs
                    ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                    schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = sche_id;
                    schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
                    schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'P';
                    if (is_protocal == "Y")schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Technologist Designed";
                    else schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Technologist Undo";
                    
                    schLogs.Invoke();
                    #endregion
                }
            }
        }

        private void initialModalityData()
        {
            DataTable dtModality = new DataTable();
            #region Show All modality with all user
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //dttResource = process.GetModality();

            //ccbModality.Properties.Items.Clear();
            //foreach (DataRow row in dttResource.Rows)
            //    ccbModality.Properties.Items.Add(row["MODALITY_ID"], row["MODALITY_NAME"].ToString(), CheckState.Checked, true);

            //if (!string.IsNullOrEmpty(env.Filter_PopupWaitinglistForm_Schedule))
            //{
            //    ccbModality.EditValue = env.Filter_PopupWaitinglistForm_Schedule;
            //    ccbModality.RefreshEditValue();
            //}
            #endregion
            #region Show modality with User
            ProcessGetRISScheduleDefaultDestination procDestiantion = new ProcessGetRISScheduleDefaultDestination();
            procDestiantion.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
            procDestiantion.Invoke();
            if (Miracle.Util.Utilities.IsHaveData(procDestiantion.Result))
            {
                DataTable dtt = new DataTable();
                ProcessGetRISModality procModality = new ProcessGetRISModality();
                procModality.Invoke();
                dtt = procModality.Result.Tables[0];
                dtModality = dtt.Clone();
                dtModality.AcceptChanges();

                foreach (DataRow rowHandle in procDestiantion.Result.Tables[1].Rows)
                {
                    DataView dv = new DataView(dtt);
                    dv.RowFilter = "MODALITY_ID=" + rowHandle["MODALITY_ID"].ToString();
                    DataTable dttTemp = dv.ToTable();
                    if (dttTemp.Rows.Count > 0)
                    {
                        DataRow row = dtModality.NewRow();
                        for (int i = 0; i < dttTemp.Columns.Count; i++)
                            row[i] = dttTemp.Rows[0][i];
                        dtModality.Rows.Add(row);
                    }
                    dtModality.AcceptChanges();
                }
                if (dtModality.Rows.Count == 0)
                {
                    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                    dtModality = process.GetModality();
                }
            }
            else
            {
                ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                dtModality = process.GetModality();
            }

            chkcmbModality.Properties.DataSource = dtModality;
            chkcmbModality.Properties.DisplayMember = "MODALITY_NAME";
            chkcmbModality.Properties.ValueMember = "MODALITY_ID";


            //DataTable dtt = new DataTable();
            //ProcessGetRISModality procModality = new ProcessGetRISModality();
            //procModality.Invoke();
            //dtt = procModality.Result.Tables[0];
            //dtModality = dtt.Clone();
            //ProcessGetRISScheduleDefaultDestination procDestiantion = new ProcessGetRISScheduleDefaultDestination();
            //procDestiantion.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
            //procDestiantion.Invoke();
            //if (Miracle.Util.Utilities.IsHaveData(procDestiantion.Result))
            //{

            //    foreach (DataRow rowHandle in procDestiantion.Result.Tables[1].Rows)
            //    {
            //        DataView dv = dtt.DefaultView;
            //        dv.RowFilter = "MODALITY_ID=" + rowHandle["MODALITY_ID"].ToString();
            //        DataTable dttTemp = dv.ToTable();
            //        if (dttTemp.Rows.Count > 0)
            //        {
            //            DataRow row = dtModality.NewRow();
            //            for (int i = 0; i < dttTemp.Columns.Count; i++)
            //                row[i] = dttTemp.Rows[0][i];
            //            dtModality.Rows.Add(row);
            //        }
            //        dtModality.AcceptChanges();
            //    }
            //    if (dtModality.Rows.Count == 0)
            //    {
            //        dtModality = dtt;
            //    }

            //    chkcmbModality.Properties.DataSource = dtModality;
            //    chkcmbModality.Properties.DisplayMember = "MODALITY_NAME";
            //    chkcmbModality.Properties.ValueMember = "MODALITY_ID";
            //}
            #endregion
        }
        private void initialMode()
        {
            LookUpSelect lvS = new LookUpSelect();
            DataSet ds = lvS.SelectDateStatisticMode();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cmbMode.Properties.Items.Add(ds.Tables[0].Rows[i]["MODE_DESC"].ToString());
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();  
            if (saveFileDialog.FileName != "")
            {
                viewData.ExportToXls(saveFileDialog.FileName);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            if (cmbMode.SelectedIndex == 1)
            {
                if (viewData.FocusedRowHandle >= 0)
                {
                    e.Cancel = false;
                }
            }
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scanDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);

                ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
                process.RIS_ORDERIMAGE.ORDER_ID = 0;
                process.RIS_ORDERIMAGE.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]); ;
                DataTable dtOrderImage = process.GetDataByID();
                PointerStruct.ImageUrl = env.PacsUrl2;

                if (dtOrderImage.Rows.Count > 0)
                {
                    if (dtOrderImage.Rows.Count > 1)
                    {
                        Envision.NET.Forms.Dialog.ImageOrder img = new ImageOrder(Convert.ToInt32(dr["SCHEDULE_ID"]), "Schedule");
                        img.StartPosition = FormStartPosition.CenterParent;
                        img.ShowDialog();
                    }
                    else
                    {
                        string url = PointerStruct.ImageUrl + "/" + dtOrderImage.Rows[0]["IMAGE_NAME"].ToString();

                        Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                        Browser.Text = dtOrderImage.Rows[0]["IMAGE_NAME"].ToString();
                        Browser.StartPosition = FormStartPosition.CenterScreen;
                        Browser.ShowDialog();
                    }
                }
                else
                {
                    msg.ShowAlert("UID4029", env.CurrentLanguageID);
                }
            }
        }

        private void commentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewData.GetDataRow(viewData.FocusedRowHandle);
            if (Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString()) == 0)
                showMessageConversation(Convert.ToInt32(rowHandle["XRAYREQ_ID"].ToString()), true);
            else
                showMessageConversation(Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString()));
        }
        private void showMessageConversation(int schedule_id)
        {
            frmMessageConversation frm = new frmMessageConversation(schedule_id);
            frm.ShowDialog();
        }
        private void showMessageConversation(int xrayrequest_id, bool is_Online)
        {
            frmMessageConversation frm = new frmMessageConversation(xrayrequest_id, is_Online);
            frm.ShowDialog();
        }
        
    }
}
