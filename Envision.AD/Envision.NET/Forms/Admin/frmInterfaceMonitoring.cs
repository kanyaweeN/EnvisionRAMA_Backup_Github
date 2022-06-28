using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.API.Word;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;
using Envision.Operational.PACS;
using Miracle.Util;

namespace Envision.NET.Forms.Admin
{
    public partial class frmInterfaceMonitoring : MasterForm
    {
        public frmInterfaceMonitoring()
        {
            InitializeComponent();
        }

        private void frmInterfaceMonitoring_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 0;

            dateBegin.Properties.AllowNullInput = DefaultBoolean.False;
            dateEnd.Properties.AllowNullInput = DefaultBoolean.False;

            dateBegin.DateTime = DateTime.Today;
            dateEnd.DateTime = DateTime.Today;

            addBaseColumnsGrid();
            loadDataLog();

            base.CloseWaitDialog();
        }

        private void addBaseColumnsGrid()
        {
            view.Columns.Add(new GridColumn() { FieldName = "chkSelect" });
            view.Columns.Add(new GridColumn() { FieldName = "SENDER" });
            view.Columns.Add(new GridColumn() { FieldName = "RECEIVER" });
            view.Columns.Add(new GridColumn() { FieldName = "MESSAGE_TYPE" });
            view.Columns.Add(new GridColumn() { FieldName = "EVENT_TYPE" });
            view.Columns.Add(new GridColumn() { FieldName = "HN" });
            view.Columns.Add(new GridColumn() { FieldName = "ACCESSION_NO" });
            view.Columns.Add(new GridColumn() { FieldName = "COMPARE_VALUE" });
            view.Columns.Add(new GridColumn() { FieldName = "StatusText" });
            view.Columns.Add(new GridColumn() { FieldName = "HL7_TEXT" });
            view.Columns.Add(new GridColumn() { FieldName = "AckDesc" });
            view.Columns.Add(new GridColumn() { FieldName = "TEXT_MESSAGE" });
            view.Columns.Add(new GridColumn() { FieldName = "IS_LOCK" });
            view.Columns.Add(new GridColumn() { FieldName = "CREATED_ON" });
            view.Columns.Add(new GridColumn() { FieldName = "lblRemark" });

            int length = 0;
            foreach (GridColumn col in view.Columns)
            {
                col.VisibleIndex = length++;
                col.Visible = true;
                col.OptionsColumn.AllowEdit = false;
            }

            RepositoryItemCheckEdit chkSelect = new RepositoryItemCheckEdit();
            chkSelect.ValueChecked = "Y";
            chkSelect.ValueUnchecked = "N";
            chkSelect.CheckStyle = CheckStyles.Standard;
            chkSelect.NullStyle = StyleIndeterminate.Unchecked;
            view.Columns["chkSelect"].Width = 25;
            view.Columns["chkSelect"].ColumnEdit = chkSelect;
            view.Columns["chkSelect"].ColumnEdit.DisplayFormat.FormatType = FormatType.Custom;
            view.Columns["chkSelect"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            view.Columns["chkSelect"].OptionsColumn.AllowSort = DefaultBoolean.False;
            view.Columns["chkSelect"].OptionsColumn.AllowEdit = true;
            view.Columns["COMPARE_VALUE"].Visible = false;
            view.Columns["HL7_TEXT"].Visible = false;
            view.Columns["CREATED_ON"].DisplayFormat.FormatType = FormatType.Custom;
            view.Columns["CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
        }
        private void checkFilterGrid()
        {
            List<string> filters = new List<string>();

            if (!chkShowAccept.Checked)
            {
                filters.Add("ACKNOWLEDGMENT_CODE in ('AR', 'AE')");
            }
            if (!chkShowLock.Checked)
            {
                filters.Add("ISNULL(IS_LOCK,'N') = 'N'");
            }

            DataView dv = (DataView)grid.DataSource;
            dv.RowFilter = string.Join(" and ", filters.ToArray());

            view.BestFitColumns();
        }
        private void view_RowClick(object sender, RowClickEventArgs e)
        {
            int index = e.RowHandle;

            if (e.Clicks == 2 && index > -1)
            {
                DataRow dr = view.GetFocusedDataRow();

                txtDescription.Text = dr["HL7_TEXT"].ToString().Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", "\r\n");
            }
        }

        private void cmbSearch_EditValueChanged(object sender, EventArgs e)
        {
            pnlSearchDate.Visible = false;
            pnlSearchHN.Visible = false;
            pnlSearchAccessionNo.Visible = false;

            switch (cmbSearch.SelectedIndex)
            {
                case 0://Date
                    pnlSearchDate.Visible = true;
                    break;
                case 1: //HN
                    pnlSearchHN.Visible = true;
                    break;
                case 2: //Accession No
                    pnlSearchAccessionNo.Visible = true;
                    break;
            }
        }
        private void dateBegin_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal)
            {
                if (dateBegin.DateTime == DateTime.MinValue)
                {
                    dateBegin.DateTime = DateTime.Today;
                }
                if (dateBegin.DateTime > dateEnd.DateTime)
                {
                    dateEnd.DateTime = dateBegin.DateTime;
                }
            }
        }
        private void dateEnd_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal)
            {
                if (dateEnd.DateTime == DateTime.MinValue)
                {
                    dateEnd.DateTime = DateTime.Today;
                }
                if (dateBegin.DateTime > dateEnd.DateTime)
                {
                    dateBegin.DateTime = dateEnd.DateTime;
                }
            }
        }
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loadDataLog();
            }
        }
        private void txtAccessionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loadDataLog();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadDataLog();
        }
        private void chkShowAccept_CheckedChanged(object sender, EventArgs e)
        {
            checkFilterGrid();
        }
        private void chkShowLock_CheckedChanged(object sender, EventArgs e)
        {
            view.Columns["IS_LOCK"].Visible = (chkShowLock.Checked);

            checkFilterGrid();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();

            if (diag.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(diag.SelectedPath);

                if (dir.Exists)
                {
                    DataRow[] drs = ((DataView)grid.DataSource).ToTable().Select("chkSelect = 'Y'");

                    if (!Utilities.IsHaveData(drs) && view.FocusedRowHandle > 0)
                    {
                        drs = new DataRow[] { view.GetFocusedDataRow() };
                    }

                    foreach (DataRow dr in drs)
                    {
                        using (StreamWriter sw = new StreamWriter(
                            string.Format("{0}\\{1}_{2}_{3}.txt", dir.FullName, dr["MESSAGE_TYPE"], (string.IsNullOrEmpty(dr["ACCESSION_NO"].ToString())) ? dr["HN"] : dr["ACCESSION_NO"], dr["LOG_ID"]),
                            false,
                            Encoding.GetEncoding(874)))
                        {
                            sw.Write(
                                Convert.ToChar(0x0b).ToString()
                                + dr["HL7_TEXT"].ToString()
                                + Convert.ToChar(0x1c).ToString()
                                + Convert.ToChar(0x0d).ToString());
                            sw.Flush();
                            sw.Close();
                        }
                    }

                    DataView dv = ((DataView)grid.DataSource);

                    foreach (DataRowView drv in dv)
                    {
                        drv["chkSelect"] = "N";
                    }
                }
            }
        }
        private void btnResend_Click(object sender, EventArgs e)
        {
            DataView dv_temp = ((DataView)grid.DataSource).ToTable().DefaultView;
            string filter = "chkSelect = 'Y'";
            if (!string.IsNullOrEmpty(view.FilterPanelText))
            {
                filter += " and " + view.FilterPanelText;
            }
            foreach (DataColumn col in dv_temp.Table.Columns)
            {
                filter = filter.Replace("[" + col.Caption + "]", "[" + col.ColumnName + "]");
            }
            dv_temp.RowFilter = filter;

            foreach (DataRowView drv in dv_temp)
            {
                SendToPacs send = new SendToPacs();

                int log_id = (drv["ACKNOWLEDGMENT_CODE"].ToString() == "AA") ? 0 : Convert.ToInt32(drv["LOG_ID"]);
                int org_id = Convert.ToInt32(drv["ORG_ID"]);

                string remark = string.Empty;

                if (drv["IS_LOCK"].ToString() == "Y")
                {
                    remark = "Message locked";
                }
                else
                {
                    switch (drv["EVENT_TYPE"].ToString())
                    {
                        case "A08":
                            send.Set_ADTByHNQueue(log_id, drv["HN"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        case "A18":
                            send.Set_ADTReconcileQueue(log_id, drv["HN"].ToString(), drv["COMPARE_VALUE"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        case "O01":
                            send.Set_ORMByAccessionNoQueue(log_id, drv["ACCESSION_NO"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        case "BDR":
                            send.Set_ORMBidirectionalByAccessionNoQueue(log_id, drv["ACCESSION_NO"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        case "MGR":
                            send.Set_ORMMergeByAccessionNoQueue(log_id, drv["ACCESSION_NO"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        case "R01":
                            send.Set_ORUByAccessionNoQueue(log_id, drv["ACCESSION_NO"].ToString(), org_id);

                            remark = "Processing";
                            break;
                        default:
                            remark = "Event type invalid";
                            break;
                    }
                }

                drv["lblRemark"] = remark;
            }

            DataView dv = (DataView)grid.DataSource;

            foreach (DataRowView drv in dv)
            {
                dv_temp.RowFilter = "LOG_ID = " + drv["LOG_ID"].ToString();
                if (dv_temp.Count > 0)
                {
                    drv["lblRemark"] = dv_temp[0]["lblRemark"].ToString();
                }
                drv["chkSelect"] = "N";
            }

            MessageBox.Show("Resend Complete");
        }

        private void loadDataLog()
        {
            DateTime dtFrom = new DateTime(dateBegin.DateTime.Year,dateBegin.DateTime.Month,dateBegin.DateTime.Day,0,0,0);
            DateTime dtTo = new DateTime(dateEnd.DateTime.Year,dateEnd.DateTime.Month,dateEnd.DateTime.Day,23,59,59);
            ProcessGetRISInterfaceMonitoring prc = new ProcessGetRISInterfaceMonitoring();
            prc.RIS_HL7IELOG.MODE = cmbSearch.SelectedIndex;
            prc.RIS_HL7IELOG.HN = txtHN.Text.Trim();
            prc.RIS_HL7IELOG.ACCESSION_NO = txtAccessionNo.Text.Trim();
            prc.RIS_HL7IELOG.DATE_FROM = dtFrom;
            prc.RIS_HL7IELOG.DATE_TO = dtTo;
            prc.Invoke();

            DataTable data = prc.Result.Tables[0].Copy();
            data.Columns["SENDER"].Caption = "Sender";
            data.Columns["RECEIVER"].Caption = "Receiver";
            data.Columns["MESSAGE_TYPE"].Caption = "Message";
            data.Columns["EVENT_TYPE"].Caption = "Event";
            data.Columns["HN"].Caption = "HN";
            data.Columns["ACCESSION_NO"].Caption = "Accession No";
            data.Columns["COMPARE_VALUE"].Caption = "Compare Value";
            data.Columns["STATUS"].Caption = "Status";
            data.Columns["StatusText"].Caption = "Status";
            data.Columns["HL7_TEXT"].Caption = "HL7 Text";
            data.Columns["ACKNOWLEDGMENT_CODE"].Caption = "Ack Code";
            data.Columns["AckDesc"].Caption = "Ack Code";
            data.Columns["TEXT_MESSAGE"].Caption = "Ack Message";
            data.Columns["IS_LOCK"].Caption = "Lock";
            data.Columns["ORG_ID"].Caption = "Org Id";
            data.Columns["LAST_MODIFIED_BY"].Caption = "Last By";
            data.Columns["LAST_MODIFIED_ON"].Caption = "Last Date-Time";
            data.Columns["CREATED_BY"].Caption = "Created By";
            data.Columns["CREATED_ON"].Caption = "Created Date-Time";

            data.Columns.Add(new DataColumn("chkSelect") { Caption = string.Empty });
            data.Columns.Add(new DataColumn("lblRemark") { Caption = "Remark" });
            data.AcceptChanges();

            grid.DataSource = data.DefaultView;
            checkFilterGrid();
        }
    }
}