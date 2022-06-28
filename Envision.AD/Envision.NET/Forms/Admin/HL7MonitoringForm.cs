using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.Operational.PACS;
using Miracle.Util;
using Envision.BusinessLogic.ProcessCreate;
using Miracle.HL7.ORU;
using Envision.NET.Forms.Main;
using DevExpress.XtraGrid.Views.BandedGrid;
using Envision.NET.Forms.Orders;
using Envision.BusinessLogic.ProcessUpdate;
using System.Data.Common;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Miracle.HL7.ORM;

namespace Envision.NET.Forms.Admin
{
    public partial class HL7MonitoringForm : MasterForm
    {
        DateTime dateFrom;
        DateTime dateTo;

        DataTable tbResendOrder;
        DataTable tbChangeStatus;

        DataView dvResendOrder;
        DataView dvChangeStatus;

        DataTable tbRadiologist;

        bool firstLoad = true;

        public HL7MonitoringForm()
        {
            InitializeComponent();
        }
        private void HL7MonitoringForm_Load(object sender, EventArgs e)
        {
            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;

            ribDateFrom.EditValue = DateTime.Now;
            ribDateTo.EditValue = DateTime.Now;

            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            ReloadResendOrder();

            base.CloseWaitDialog();
        }

        private void LoadDataResendOrder()
        {
            HL7Monitoring common = new HL7Monitoring();
            common.SpType = -1;
            common.FromDate = dateFrom;
            common.ToDate = dateTo;
            ProcessGetHL7Monitoring pghl7 = new ProcessGetHL7Monitoring();
            pghl7.HL7Monitoring = common;
            pghl7.Invoke();

            #region add Checkbox column & Cancel Order column
            DataTable table = pghl7.ResultSet.Tables[0];
            table.Columns.Add("checkbox");
            table.Columns.Add("cancelorder");
            foreach (DataRow dr in table.Rows)
            {
                dr["checkbox"] = "N";
                dr["cancelorder"] = "";
            }
            #endregion

            table.AcceptChanges();

            tbResendOrder = table;
            dvResendOrder = new DataView(table);
        }
        private void LoadFilterResendOrder()
        { 
            
        }
        private void LoadGridResendOrder()
        {
            gcResendHL7.DataSource = tbResendOrder;

            int k = 0;
            while (k < gvResendHL7.Columns.Count)
            {
                //gridView1.Columns[k].OptionsColumn.ReadOnly = true;
                gvResendHL7.Columns[k].OptionsColumn.AllowEdit = false;
                gvResendHL7.Columns[k].Visible = false;
                k++;
            }

            #region column edit
            //gridView1.Columns["checkbox"].OptionsColumn.ReadOnly = false;
            gvResendHL7.Columns["checkbox"].OptionsColumn.AllowEdit = true;
            gvResendHL7.Columns["checkbox"].Caption = "";
            gvResendHL7.Columns["checkbox"].ColVIndex = 1;
            gvResendHL7.Columns["checkbox"].Width = 30;

            gvResendHL7.Columns["HN"].Caption = "HN";
            gvResendHL7.Columns["HN"].ColVIndex = 2;

            gvResendHL7.Columns["NAME"].Caption = "Patient Name";
            gvResendHL7.Columns["NAME"].ColVIndex = 3;

            gvResendHL7.Columns["EXAM CODE"].Caption = "Exam Code";
            gvResendHL7.Columns["EXAM CODE"].ColVIndex = 4;

            gvResendHL7.Columns["EXAM NAME"].Caption = "Exam Name";
            gvResendHL7.Columns["EXAM NAME"].ColVIndex = 5;

            gvResendHL7.Columns["ACCESSION NO"].Caption = "Accession No.";
            gvResendHL7.Columns["ACCESSION NO"].ColVIndex = 6;

            gvResendHL7.Columns["HL7 SEND"].Caption = "HL7 Send";
            gvResendHL7.Columns["HL7 SEND"].ColVIndex = 7;

            gvResendHL7.Columns["ORDER TIME"].Caption = "Order Date-Time";
            gvResendHL7.Columns["ORDER TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvResendHL7.Columns["ORDER TIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gvResendHL7.Columns["ORDER TIME"].ColVIndex = 8;

            gvResendHL7.Columns["MSG TYPE"].Caption = "Msg Type";
            gvResendHL7.Columns["MSG TYPE"].ColVIndex = 9;

            gvResendHL7.Columns["HL7_TEXT"].OptionsColumn.AllowEdit = true;
            gvResendHL7.Columns["HL7_TEXT"].OptionsColumn.ReadOnly = true;
            gvResendHL7.Columns["HL7_TEXT"].ColVIndex = 10;

            gvResendHL7.Columns["cancelorder"].OptionsColumn.AllowEdit = true;
            gvResendHL7.Columns["cancelorder"].Caption = "Cancel Order";
            gvResendHL7.Columns["cancelorder"].ColVIndex = 11;
            gvResendHL7.Columns["cancelorder"].Width = 90;

            gvResendHL7.Columns["MERGE"].Visible = false;
            gvResendHL7.Columns["MERGE_WITH"].Visible = false;
            #endregion

            #region repository item
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit 
                chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            chk.Caption = "";
            chk.CheckStateChanged += new EventHandler(chkResendOrder_CheckStateChanged);
            gvResendHL7.Columns["checkbox"].ColumnEdit = chk;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
                btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btn.Buttons.Clear();
            btn.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btn.Buttons[0].Caption = "Cancel Order";
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnCancelOrder_ButtonClick);
            gvResendHL7.Columns["cancelorder"].ColumnEdit = btn;


            #endregion

            //if (gvResendHL7.RowCount < 300)
            //    gvResendHL7.BestFitColumns();
        }
        private void ReloadResendOrder()
        {
            DateTime dtfr = Convert.ToDateTime(ribDateFrom.EditValue);
            DateTime dtto = Convert.ToDateTime(ribDateTo.EditValue);

            dateFrom = new DateTime(dtfr.Year, dtfr.Month, dtfr.Day, 0, 0, 0, 0);
            dateTo = new DateTime(dtto.Year, dtto.Month, dtto.Day, 23, 59, 59, 59);

            ribbonPage1.Text = "Resend Order";

            #region control settings
            xtraTabControl1.SelectedTabPage = pageResendOrder;

            ribPageResendOrder.Visible = true;
            ribPageChangeReportStatus.Visible = true;

            ribBtnResend.Visible = true;
            ribBtnChangeStatus.Visible = false;
            ribPageDateSearch.Visible = true;
            ribPageChangeReportHistor.Visible = false;
            #endregion

            try
            {
                LoadDataResendOrder();
                LoadFilterResendOrder();
                LoadGridResendOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region ResendOrder
        private void btnResend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable table = tbResendOrder;
            table.AcceptChanges();
            DataRow[] rows = table.Select("checkbox = 'Y'");

            if (rows.Length == 0)
            {
                MessageBox.Show("Please select at less one row.", "No Selected");
                return;
            }

            foreach (DataRow dr in rows)
            {
                if (dr["MSG TYPE"].ToString() == "ORM")
                {
                    int order_id = Convert.ToInt32(dr["ORDER_ID"]);
                    SendToPacs sp = new SendToPacs();
                    try
                    {
                        sp.Set_ORMByOrderIdQueue(order_id);
                    }
                    catch
                    {
                        MessageBox.Show("Message send faild to pacs", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                else if (dr["MSG TYPE"].ToString() == "ORU")
                {
                    string accession_no = Convert.ToString(dr["ACCESSION NO"]);
                    //string hl7 = dr["HL7_TEXT"].ToString();
                    //string html = dr["RESULT_TEXT_HTML"].ToString();
                    //string rtf = dr["RESULT_TEXT_RTF"].ToString();

                    //if (html.Trim().Length == 0)
                    //{
                    //    DataTable dtSetGroup = new DataTable();
                    //    dtSetGroup.Columns.Add("SL_NO", typeof(byte));
                    //    dtSetGroup.Columns.Add("RADNAME", typeof(string));
                    //    //dtSetGroup.Columns.Add("CAN_DRAFT",typeof(bool));
                    //    dtSetGroup.Columns.Add("CAN_PRELIM", typeof(bool));
                    //    dtSetGroup.Columns.Add("CAN_FINALIZE", typeof(bool));
                    //    dtSetGroup.Columns.Add("DEL", typeof(string));
                    //    dtSetGroup.Columns.Add("ACCESSION_NO", typeof(string));
                    //    dtSetGroup.Columns.Add("RAD_ID", typeof(int));
                    //    dtSetGroup.Columns.Add("JOBTITLE_ID", typeof(int));
                    //    dtSetGroup.AcceptChanges();

                    //    ProcessGetRISExamresultrads getGpRad = new ProcessGetRISExamresultrads();
                    //    getGpRad.RIS_EXAMRESULTRADS.ACCESSION_NO = accession_no;
                    //    getGpRad.Invoke();
                    //    DataTable dtGpRad = getGpRad.Result.Tables[0];
                    //    if (dtGpRad.Rows.Count > 0)
                    //    {
                    //        foreach (DataRow drGpRad in dtGpRad.Rows)
                    //        {
                    //            dtSetGroup.AcceptChanges();
                    //            DataRow drAddTemp = dtSetGroup.NewRow();
                    //            drAddTemp["SL_NO"] = 1;
                    //            drAddTemp["RADNAME"] = drGpRad["RADNAME"].ToString();
                    //            drAddTemp["CAN_PRELIM"] = drGpRad["CAN_PRELIM"];
                    //            drAddTemp["CAN_FINALIZE"] = drGpRad["CAN_FINALIZE"];
                    //            drAddTemp["DEL"] = "";
                    //            drAddTemp["ACCESSION_NO"] = "";
                    //            drAddTemp["RAD_ID"] = drGpRad["RAD_ID"];
                    //            drAddTemp["JOBTITLE_ID"] = drGpRad["JOBTITLE_ID"];
                    //            dtSetGroup.Rows.Add(drAddTemp);
                    //            dtSetGroup.AcceptChanges();
                    //        }
                    //    }

                    //    string finalName = arrangeGroup(dtSetGroup);

                    //    RichTextBox rt = new RichTextBox();
                    //    rt.Rtf = rtf;
                    //    rt.AppendText("\r\n\r\n" + finalName);
                    //    Miracle.Translator.TransRtf tran = new Miracle.Translator.TransRtf(rt.Rtf);

                    //    string Hl7html = tran.Translator();
                    //    Hl7html = removeSyntax(Hl7html);

                    //    Envision.BusinessLogic.ResultEntry update = new Envision.BusinessLogic.ResultEntry();
                    //    update.RISExamresult.ACCESSION_NO = accession_no;
                    //    update.RISExamresult.RESULT_TEXT_HTML = Hl7html;
                    //    update.UpdateHtml();
                    //}

                    //if (hl7.Trim().Length == 0)
                    //{
                        SendToPacs sp = new SendToPacs();
                        try
                        {
                            sp.Set_ORUByAccessionNoQueue(accession_no);
                        }
                        catch
                        {
                            MessageBox.Show("Message send faild to pacs", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    //}
                }
                else
                {
                    MessageBox.Show("Message send faild to pacs", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                MessageBox.Show("Successfully sent to pacs", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            ReloadResendOrder();
        }
        private void chkResendOrder_CheckStateChanged(object sender, EventArgs e)
        {
            if (gvResendHL7.FocusedRowHandle > -1)
            {
                string accNo = gvResendHL7.GetDataRow(gvResendHL7.FocusedRowHandle)["ACCESSION NO"].ToString();
                string msgType = gvResendHL7.GetDataRow(gvResendHL7.FocusedRowHandle)["MSG TYPE"].ToString();
                DataRow[] rows = tbResendOrder.Select("[ACCESSION NO]='" + accNo +"' and [MSG TYPE]='" + msgType +"'");

                foreach (DataRow row in rows)
                {
                    if (row["checkbox"] == "N")
                        row["checkbox"] = "Y";
                    else if (row["checkbox"] == "Y")
                        row["checkbox"] = "N";
                }
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            AdvBandedGridView view = (AdvBandedGridView)sender;

            if (e.RowHandle >= 0)
            {
                DataRow dr = view.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["MERGE"].ToString() != string.Empty)
                    {
                        if (dr["MERGE_WITH"].ToString() != string.Empty)
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = SystemColors.Window;
                    }
                }
            }
        }
        private void btnCancelOrder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvResendHL7.FocusedRowHandle < 0) return;
            DataRow row = gvResendHL7.GetDataRow(gvResendHL7.FocusedRowHandle);

            DialogResult dlog = MessageBox.Show(
                "Do you want to cancel this Order? \r\n HN: " + row["HN"].ToString()
                + "\r\n ACC: " + row["ACCESSION NO"].ToString()
                + "\r\n Exam: " + row["EXAM CODE"].ToString() + " - " + row["EXAM NAME"].ToString()
                , "Cancel This Order?"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Warning
                , MessageBoxDefaultButton.Button2);

            if (dlog == DialogResult.Cancel) return;

            ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
            FinancialBilling fnBill = new FinancialBilling();

            try
            {
                processUpdate.RIS_ORDERDTL.ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);
                processUpdate.RIS_ORDERDTL.ACCESSION_NO = row["ACCESSION NO"].ToString();
                processUpdate.RIS_ORDERDTL.IS_DELETED = 'Y';
                processUpdate.RIS_ORDERDTL.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdate.UpdateIsDeleted();

                //if (processUpdate.RIS_ORDERDTL.ORDER_ID == -1)
                //    throw new Exception("Can not cancel this Order.");

                SendToPacs send = new SendToPacs();
                send.Set_ORMByOrderIdQueue(Convert.ToInt32(row["ORDER_ID"]));

                string str = fnBill.Cancel_Billing(row["HN"].ToString(), row["EXAM CODE"].ToString().Trim() + row["ACCESSION NO"].ToString(), " ", " ");
                fnBill.UpdateHisSync(row["ACCESSION NO"].ToString(), str);
                if (str.Trim() != "Success in Cancel_Billing")
                {
                    MessageBox.Show("ไม่สามารถทำการยกเลิกบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            ReloadResendOrder();
        }
        private string arrangeGroup(DataTable dtSetGroup)
        {
            ProcessGetHREmp geHr = new ProcessGetHREmp();
            geHr.HR_EMP.MODE = "select_All_Active";
            geHr.Invoke();
            DataTable dtHr = new DataTable();
            dtHr = geHr.Result.Tables[0];
            string finalName = "";
            string ResultDoctor = "";
            if (dtSetGroup.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSetGroup.Rows)
                {
                    DataTable dtAuthe = selectCheckAuthen(Convert.ToInt32(dr["RAD_ID"]));
                    if (dtAuthe.Rows.Count > 0)
                    {
                        string resultDoc = "";
                        if (dtAuthe.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";

                            if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("RAD"))
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("FEL"))
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else
                                ResultDoctor += finalName + "\r\n";
                        }
                        else
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";
                            ResultDoctor += finalName + "\r\n";
                        }

                    }
                }
            }
            return ResultDoctor;
        }
        private DataTable selectCheckAuthen(int EMP_ID)
        {
            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.HR_EMP.MODE = "check_Auther";
            hr.HR_EMP.EMP_ID = EMP_ID;
            hr.Invoke();
            DataTable dtAuth = hr.Result.Tables[0];
            dtAuth.AcceptChanges();
            return dtAuth;
        }
        private string removeSyntax(string html)
        {
            string rejectImg = "<img	src=\"none\" />";
            html = html.Replace(rejectImg, "");

            string wrongText = @"\X000d\";
            html = html.Replace(wrongText, "<br>");

            return html;
        }
        #endregion

        private void LoadDataChangeReportStatus()
        {
            HL7Monitoring hl7data = new HL7Monitoring();
            hl7data.SpType = -1;
            hl7data.FromDate = dateFrom;
            hl7data.ToDate = dateTo;
            ProcessGetReportStatusChange prchl7 = new ProcessGetReportStatusChange();
            prchl7.HL7Monitoring = hl7data;
            prchl7.Invoke();

            #region add new column
            DataTable table = prchl7.ResultSet.Tables[0];
            table.Columns.Add("checkbox");
            foreach (DataRow dr in table.Rows)
            {
                dr["checkbox"] = "N";
                dr["CHANGE TO"] = "";
            }
            #endregion

            if (tbRadiologist == null)
            {
                ProcessGetHREmp rad = new ProcessGetHREmp();
                rad.HR_EMP.MODE = "select_all_radiologist";
                rad.Invoke();
                tbRadiologist = rad.Result.Tables[0].Copy();
            }

            tbChangeStatus = table;
            dvChangeStatus = new DataView(table);
        }
        private void LoadFilterChangeReportStatus()
        {
            if (chkShowDraftPrelim.CheckState == CheckState.Checked)
                dvChangeStatus.RowFilter = "STATUS<>'Complete' AND STATUS<>'New'";
            else
                dvChangeStatus.RowFilter = "STATUS='Finalized'";
        }
        private void LoadGridChangeReportStatus()
        {
            //gridControl2.DataSource = tbChangeStatus;
            gcChangeReportStatus.DataSource = dvChangeStatus;

            int k = 0;
            while (k < gvChangeReportStatus.Columns.Count)
            {
                //gridView2.Columns[k].OptionsColumn.ReadOnly = true;
                gvChangeReportStatus.Columns[k].OptionsColumn.AllowEdit = false;
                k++;
            }

            #region column edit
            gvChangeReportStatus.Columns["checkbox"].OptionsColumn.AllowEdit = true;
            gvChangeReportStatus.Columns["checkbox"].Caption = "";

            gvChangeReportStatus.Columns["ORDER TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvChangeReportStatus.Columns["ORDER TIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gvChangeReportStatus.Columns["ORDER TIME"].Caption = "Order Date-Time";

            gvChangeReportStatus.Columns["CHANGE TO"].OptionsColumn.AllowEdit = true;
            gvChangeReportStatus.Columns["CHANGE TO"].Caption = "Change To";

            gvChangeReportStatus.Columns["REQUESTED BY"].OptionsColumn.AllowEdit = true;
            gvChangeReportStatus.Columns["REQUESTED BY"].Caption = "Request By";

            gvChangeReportStatus.Columns["ORDER ID"].Visible = false;

            gvChangeReportStatus.Columns["NAME"].Caption = "Patient Name";
            gvChangeReportStatus.Columns["EXAM CODE"].Caption = "Exam Code";
            gvChangeReportStatus.Columns["EXAM NAME"].Caption = "Exam Name";
            gvChangeReportStatus.Columns["ACCESSION NO"].Caption = "Accession No.";
            gvChangeReportStatus.Columns["SENT"].Caption = "HL7 Send";
            gvChangeReportStatus.Columns["STATUS"].Caption = "Status";

            gvChangeReportStatus.Columns["MERGE"].Visible = false;
            gvChangeReportStatus.Columns["MERGE_WITH"].Visible = false;
            #endregion

            #region repository item
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckStateChanged += new EventHandler(chkStatusChange_CheckStateChanged);
            gvChangeReportStatus.Columns["checkbox"].ColumnEdit = chk;

            DevExpress.XtraEditors.Repository.RepositoryItemComboBox
                combo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //combo.Items.AddRange(new object[] { "", "New", "Draft" });
            //combo.Items.AddRange(new object[] { "", "Prelim" });
            combo.Items.AddRange(new object[] { "", "New", "Complete", "Draft", "Prelim" });
            combo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            combo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(combo_EditValueChanging);
            //combo.Popup += new EventHandler(combo_Popup);
            gvChangeReportStatus.Columns["CHANGE TO"].ColumnEdit = combo;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
                rad = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            rad.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rad.ImmediatePopup = true;
            rad.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rad.AutoHeight = false;
            rad.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RadioName", "Radiologist", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rad.DisplayMember = "RadioName";
            rad.ValueMember = "EMP_ID";
            rad.DropDownRows = 5;
            rad.DataSource = tbRadiologist.Copy();
            rad.NullText = string.Empty;
            rad.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(rad_EditValueChanging);
            rad.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(rad_CloseUp);
            gvChangeReportStatus.Columns["REQUESTED BY"].ColumnEdit = rad;
            #endregion

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvChangeReportStatus.Columns["STATUS"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvChangeReportStatus.Columns["STATUS"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvChangeReportStatus.Columns["STATUS"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvChangeReportStatus.Columns["STATUS"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvChangeReportStatus.Columns["STATUS"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gvChangeReportStatus.FormatConditions.Clear();
            gvChangeReportStatus.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

            #endregion

            //if (gvChangeReportStatus.RowCount < 300)
            //    gvChangeReportStatus.BestFitColumns();
        }
        private void ReloadChangeReportStatus()
        {
            firstLoad = true;

            DateTime dtfr = Convert.ToDateTime(ribDateFrom.EditValue);
            DateTime dtto = Convert.ToDateTime(ribDateTo.EditValue);

            dateFrom = new DateTime(dtfr.Year, dtfr.Month, dtfr.Day, 0, 0, 0, 0);
            dateTo = new DateTime(dtto.Year, dtto.Month, dtto.Day, 23, 59, 59, 59);

            ribbonPage1.Text = "Change Report Status";

            #region control settings
            xtraTabControl1.SelectedTabPage = pageChangeReportStatus;

            ribPageChangeReportStatus.Visible = true;
            ribPageResendOrder.Visible = true;

            ribBtnResend.Visible = false;
            ribBtnChangeStatus.Visible = true;
            ribPageDateSearch.Visible = true;
            ribPageChangeReportHistor.Visible = false;
            #endregion

            try
            {
                LoadDataChangeReportStatus();
                LoadFilterChangeReportStatus();
                LoadGridChangeReportStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            firstLoad = false;
        }

        #region ChangeReportStatus
        private void btnChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HL7Monitoring hlobj = new HL7Monitoring();
            ProcessAddResultStatusChangeLog chlog = new ProcessAddResultStatusChangeLog();

            DataTable dtlog = new DataTable();

            dtlog.Columns.Add("HN");
            dtlog.Columns.Add("ACCESSION_NO");
            dtlog.Columns.Add("EXAM_ID");
            dtlog.Columns.Add("STATUS");
            dtlog.Columns.Add("CHANGE_TO");
            dtlog.Columns.Add("REQ_BY");
            dtlog.Columns.Add("PC");
            dtlog.Columns.Add("ORG_ID");
            dtlog.Columns.Add("CREATED_BY");
            dtlog.Columns.Add("HL7_TXT");
            DataTable hlmsg = new DataTable();
            ArrayList arr = new ArrayList();
            int counts = 0;
            int i = 0;

            DataTable table = tbChangeStatus;
            table.AcceptChanges();
            DataRow[] rows = table.Select("checkbox = 'Y'");
            string _reason = "";
            if (rows.Length > 0)
            {
                Reason frm = new Reason("Change Result Status");
                if (frm.ShowDialog() == DialogResult.OK)
                    _reason = frm.Comment;
            }
            foreach (DataRow row in rows)
            {
                if (row["REQUESTED BY"].ToString().Trim() == "")
                {
                    MessageBox.Show("Requested By cell can't be blank !");
                    return;
                }
                if (row["CHANGE TO"].ToString().Trim() == "")
                {
                    MessageBox.Show("Change To cell can't be blank !");
                    return;
                }
                string _changestatus = "";
                switch (row["CHANGE TO"].ToString().Trim())
                {
                    case "Prelim": _changestatus = "P"; break;
                    case "Draft": _changestatus = "D"; break;
                    case "Complete": _changestatus = "C"; break;
                    case "New": _changestatus = "A"; break;

                }
                dtlog.Rows.Add(row["HN"].ToString().Trim(),
                       row["ACCESSION NO"].ToString().Trim(),
                       row["EXAM CODE"].ToString().Trim(),
                       row["STATUS"].ToString().Trim(),
                       _changestatus,
                       row["REQUESTED BY"].ToString().Trim(),
                       Utilities.MachineName(),
                       row["ORDER ID"].ToString().Trim(),
                        new GBLEnvVariable().UserID.ToString(),
                       "");
            }
            if(dtlog.Rows.Count>0)
            {
                    for (int j = 0; j < dtlog.Rows.Count; j++)
                    {
                        #region Keep Change Report Status Log
                        try
                        {
                            hlobj.PatientID = dtlog.Rows[j]["HN"].ToString().Trim();
                            hlobj.AccessionNo = dtlog.Rows[j]["ACCESSION_NO"].ToString().Trim();

                            string eqry = "Select EXAM_ID FROM RIS_EXAM WHERE EXAM_UID='" + dtlog.Rows[j]["EXAM_ID"].ToString().Trim() + "'";
                            ProcessGetGBLLookup exm = new ProcessGetGBLLookup(eqry);
                            exm.Invoke();
                            DataTable dtex = exm.ResultSet.Tables[0];
                            if (dtex.Rows.Count > 0)
                            {
                                hlobj.ExamID = Convert.ToInt32(dtex.Rows[0]["EXAM_ID"].ToString());
                            }
                            hlobj.OriginalStatus = dtlog.Rows[j]["STATUS"].ToString().Trim();
                            hlobj.ChangeStatus = dtlog.Rows[j]["CHANGE_TO"].ToString().Trim();
                            hlobj.RequestBy = Convert.ToInt32(dtlog.Rows[j]["REQ_BY"].ToString().Trim());
                            hlobj.ChangePC = dtlog.Rows[j]["PC"].ToString().Trim();
                            hlobj.OrgID = Convert.ToInt32(dtlog.Rows[j]["ORG_ID"].ToString().Trim());
                            hlobj.CreatedBy = Convert.ToInt32(dtlog.Rows[j]["CREATED_BY"].ToString().Trim());
                            hlobj.Hl7Text = dtlog.Rows[j]["HL7_TXT"].ToString().Trim();
                            hlobj.Reason = _reason;

                            chlog.HL7Monitoring = hlobj;
                            chlog.Invoke();

                            SendToPacs pacs = new SendToPacs();
                            pacs.Set_ORUByAccessionNoQueue(dtlog.Rows[j]["ACCESSION_NO"].ToString().Trim());

                        }
                        catch (Exception errr) { MessageBox.Show(errr.ToString()); }
                        #endregion
                    }
                    ReloadChangeReportStatus();
                    MessageBox.Show("Successfully sent to pacs", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("You must select one row", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        public DataTable patientDemo(string hn)
        {
            ProcessGetPatientReg regs = new ProcessGetPatientReg(hn.ToString());
            regs.Invoke();
            DataTable dt = regs.ResultSet.Tables[0];

            return dt;
        }
        private void chkStatusChange_CheckStateChanged(object sender, EventArgs e)
        {
            if (gvChangeReportStatus.FocusedRowHandle < 0) return;

            string accNo = gvChangeReportStatus.GetDataRow(gvChangeReportStatus.FocusedRowHandle)["ACCESSION NO"].ToString();
            DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

            foreach (DataRow row in rows)
            {
                if (row["checkbox"] == "N")
                    row["checkbox"] = "Y";
                else if (row["checkbox"] == "Y")
                    row["checkbox"] = "N";
            }

            gvChangeReportStatus.RefreshData();
        }

        private void chkShowDraftPrelim_CheckStateChanged(object sender, EventArgs e)
        {
            ReloadChangeReportStatus();
        }
        private void combo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (gvChangeReportStatus.FocusedRowHandle > -1)
            {
                DataRow rowTmp = gvChangeReportStatus.GetDataRow(gvChangeReportStatus.FocusedRowHandle);
                string accNo = rowTmp["ACCESSION NO"].ToString();
                string status = rowTmp["STATUS"].ToString();

                bool canChangeStatus = true;

                if (status == "Draft")
                {
                    if (e.NewValue == "Prelim" || e.NewValue == "Draft")
                        canChangeStatus = false;
                }
                else if (status == "Prelim")
                {
                    if (e.NewValue == "Prelim")
                        canChangeStatus = false;
                }

                if (canChangeStatus)
                {
                    DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");
                    foreach (DataRow row in rows)
                        row["CHANGE TO"] = e.NewValue;
                    gvChangeReportStatus.RefreshData();
                }
                else
                { 
                    e.Cancel = true;

                    MyMessageBox msg = new MyMessageBox();
                    msg.ShowAlert("UID2122", new GBLEnvVariable().CurrentLanguageID);
                }
            }
        }
        private void rad_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (gridView2.FocusedRowHandle > -1)
            //{
            //    string accNo = gridView2.GetDataRow(gridView2.FocusedRowHandle)["ACCESSION NO"].ToString();
            //    DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

            //    foreach (DataRow row in rows)
            //        row["REQUESTED BY"] = e.NewValue;
            //}
        }
        private void rad_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gvChangeReportStatus.FocusedRowHandle > -1)
            {
                string accNo = gvChangeReportStatus.GetDataRow(gvChangeReportStatus.FocusedRowHandle)["ACCESSION NO"].ToString();
                DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

                foreach (DataRow row in rows)
                    row["REQUESTED BY"] = e.Value;
                gvChangeReportStatus.RefreshData();
            }
        }
        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            AdvBandedGridView view = (AdvBandedGridView)sender;

            if (e.RowHandle >= 0)
            {
                DataRow dr = view.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["MERGE"].ToString() != string.Empty)
                    {
                        if (dr["MERGE_WITH"].ToString() != string.Empty)
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = SystemColors.Window;
                    }
                }
            }
        }
        #endregion

        #region global function
        private void btnPageResend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadResendOrder();
        }
        private void btnPageChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadChangeReportStatus();
        }

        private void btnGO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageResendOrder)
            {
                ReloadResendOrder();
            }
            else if (xtraTabControl1.SelectedTabPage == pageChangeReportStatus)
            {
                ReloadChangeReportStatus();
            }
            else if (xtraTabControl1.SelectedTabPage == pageChangeReportHistory)
            {
                getChangedReportHistory();
            }
        }
        private void getChangedReportHistory()
        {
            ProcessGetReportStatusChange prchl7 = new ProcessGetReportStatusChange();
            DataSet dsLog = prchl7.GetLog(txtAccessionHistory.EditValue.ToString());

            grdChangeReportHistory.DataSource = dsLog.Tables[0];
            for (int i = 0; i < viewChangeReportHistory.Columns.Count; i++)
            {
                viewChangeReportHistory.Columns[i].Visible = false;
                viewChangeReportHistory.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewChangeReportHistory.Columns["HN"].Caption = "HN";
            viewChangeReportHistory.Columns["HN"].Visible = true;

            viewChangeReportHistory.Columns["ACCESSION_NO"].Caption = "Accession";
            viewChangeReportHistory.Columns["ACCESSION_NO"].Visible = true;

            viewChangeReportHistory.Columns["ORGINAL_STATUS"].Caption = "Original Status";
            viewChangeReportHistory.Columns["ORGINAL_STATUS"].Visible = true;

            viewChangeReportHistory.Columns["CHANGED_STATUS"].Caption = "Changed Status";
            viewChangeReportHistory.Columns["CHANGED_STATUS"].Visible = true;

            viewChangeReportHistory.Columns["REQUEST_NAME"].Caption = "Request By";
            viewChangeReportHistory.Columns["REQUEST_NAME"].Visible = true;

            viewChangeReportHistory.Columns["CREATED_NAME"].Caption = "Changed By";
            viewChangeReportHistory.Columns["CREATED_NAME"].Visible = true;

            viewChangeReportHistory.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            viewChangeReportHistory.Columns["CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            viewChangeReportHistory.Columns["CREATED_ON"].Caption = "Change Datetime";
            viewChangeReportHistory.Columns["CREATED_ON"].Visible = true;
        }
        #endregion

        private void barbtnChangeStatusHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            #region control settings
            xtraTabControl1.SelectedTabPage = pageChangeReportHistory;

            ribPageChangeReportStatus.Visible = true;
            ribPageResendOrder.Visible = true;

            ribBtnResend.Visible = false;
            ribBtnChangeStatus.Visible = false;
            ribPageDateSearch.Visible = false;
            ribPageChangeReportHistor.Visible = true;
            #endregion
            getChangedReportHistory();
        }
    }
}