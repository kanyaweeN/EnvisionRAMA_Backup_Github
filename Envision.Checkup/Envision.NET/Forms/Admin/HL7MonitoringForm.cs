using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Operational.PACS;
using RIS.Operational;
using System.Globalization;
using Miracle.Util;
using Miracle.HL7.ORU;

namespace RIS.Forms.Admin
{
    public partial class HL7MonitoringForm : Form
    {
        DateTime dateFrom;
        DateTime dateTo;

        DataTable tbResendOrder;
        DataTable tbChangeStatus;

        DataView dvResendOrder;
        DataView dvChangeStatus;

        DataTable tbRadiologist;

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public HL7MonitoringForm(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        private void HL7MonitoringForm_Load(object sender, EventArgs e)
        {
            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;

            ribDateFrom.EditValue = DateTime.Now;
            ribDateTo.EditValue = DateTime.Now;

            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            ReloadResendOrder();
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

            #region add checkbox column
            DataTable table = pghl7.ResultSet.Tables[0];
            table.Columns.Add("checkbox");
            foreach (DataRow dr in table.Rows)
                dr["checkbox"] = "N";
            #endregion

            tbResendOrder = table;
            dvResendOrder = new DataView(table);
        }
        private void LoadFilterResendOrder()
        { 
            
        }
        private void LoadGridResendOrder()
        {
            gridControl1.DataSource = tbResendOrder;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                //gridView1.Columns[k].OptionsColumn.ReadOnly = true;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                k++;
            }

            #region column edit
            //gridView1.Columns["checkbox"].OptionsColumn.ReadOnly = false;
            gridView1.Columns["checkbox"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["checkbox"].Caption = "";

            gridView1.Columns["ORDER TIME"].Caption = "Order Date-Time";
            gridView1.Columns["ORDER TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["ORDER TIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";

            gridView1.Columns["NAME"].Caption = "Patient Name";
            gridView1.Columns["EXAM CODE"].Caption = "Exam Code";
            gridView1.Columns["EXAM NAME"].Caption = "Exam Name";
            gridView1.Columns["ACCESSION NO"].Caption = "Accession No.";
            gridView1.Columns["HL7 SEND"].Caption = "HL7 Send";
            gridView1.Columns["MSG TYPE"].Caption = "Msg Type";
            #endregion

            #region repository item
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit 
                chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            chk.Caption = "";
            chk.CheckStateChanged += new EventHandler(chkResendOrder_CheckStateChanged);
            gridView1.Columns["checkbox"].ColumnEdit = chk;
            #endregion

            if (gridView1.RowCount < 300)
                gridView1.BestFitColumns();
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
            string _accno = "";
            string _hl7txt = "";
            string _type = "";

            int count = 0;
            int k = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("ACCESSION_NO");
            dt.Columns.Add("HL7_TXT");
            dt.Columns.Add("TYPE");

            DataTable table = tbResendOrder;
            table.AcceptChanges();
            DataRow[] rows = table.Select("checkbox = 'Y'");

            foreach (DataRow dr in rows)
            {
                //this.UltraGrid1.Rows[k].Cells[8].Selected = true;

                //if (dr["checkbox"].ToString().Trim() == "Y")
                //{
                    _accno = dr["ACCESSION NO"].ToString().Trim();
                    _type = dr["MSG TYPE"].ToString().Trim();

                    _hl7txt = getMSG(_accno, _type);

                    dt.Rows.Add(_accno, _hl7txt, _type);

                    count++;
                //}
                //k++;
            }
            if (count > 0)
            {
                //SendToPacs sp = new SendToPacs();
                //bool a = sp.SendMSGToPacs(dt, "HL7");
                //if (a)
                //{
                //    MessageBox.Show("Successfully sent to pacs", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    ReloadResendOrder();
                //}
                //else
                //{
                //    MessageBox.Show("Message send faild to pacs", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //}
            }
            else
            {
                MessageBox.Show("You must select one row", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        private string getMSG(string acc, string type)
        {
            string qry = "";
            string hl7msg = "";
            if (type == "ORU")
            {
                qry = "SELECT HL7_TEXT from RIS_EXAMRESULT WHERE ACCESSION_NO='" + acc + "'";
            }
            else
            {
                qry = "SELECT HL7_TEXT from RIS_ORDERDTL WHERE ACCESSION_NO='" + acc + "'";
            }
            try
            {
                ProcessGetGBLLookup lkp3 = new ProcessGetGBLLookup(qry);
                lkp3.Invoke();
                DataTable dt3 = lkp3.ResultSet.Tables[0];
                if (dt3.Rows.Count > 0)
                {
                    hl7msg = dt3.Rows[0]["HL7_TEXT"].ToString();
                }
            }
            catch (Exception err) { MessageBox.Show(err.ToString()); }

            return hl7msg;


        }

        private void chkResendOrder_CheckStateChanged(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                string accNo = gridView1.GetDataRow(gridView1.FocusedRowHandle)["ACCESSION NO"].ToString();
                string msgType = gridView1.GetDataRow(gridView1.FocusedRowHandle)["MSG TYPE"].ToString();
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
                rad.HREmp.MODE = "select_all_radiologist";
                rad.Invoke();
                tbRadiologist = rad.Result.Tables[0].Copy();
            }

            tbChangeStatus = table;
            dvChangeStatus = new DataView(table);
        }
        private void LoadFilterChangeReportStatus()
        {
            if (chkShowDraftPrelim.CheckState == CheckState.Checked)
                dvChangeStatus.RowFilter = "";
            else
                dvChangeStatus.RowFilter = "STATUS='Finalized'";
        }
        private void LoadGridChangeReportStatus()
        {
            //gridControl2.DataSource = tbChangeStatus;
            gridControl2.DataSource = dvChangeStatus;

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                //gridView2.Columns[k].OptionsColumn.ReadOnly = true;
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                k++;
            }

            #region column edit
            gridView2.Columns["checkbox"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["checkbox"].Caption = "";

            gridView2.Columns["ORDER TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["ORDER TIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView2.Columns["ORDER TIME"].Caption = "Order Date-Time";

            gridView2.Columns["CHANGE TO"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["CHANGE TO"].Caption = "Change To";

            gridView2.Columns["REQUESTED BY"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["REQUESTED BY"].Caption = "Request By";

            gridView2.Columns["ORDER ID"].Visible = false;

            gridView2.Columns["NAME"].Caption = "Patient Name";
            gridView2.Columns["EXAM CODE"].Caption = "Exam Code";
            gridView2.Columns["EXAM NAME"].Caption = "Exam Name";
            gridView2.Columns["ACCESSION NO"].Caption = "Accession No.";
            gridView2.Columns["SENT"].Caption = "HL7 Send";
            gridView2.Columns["STATUS"].Caption = "Status";
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
            gridView2.Columns["checkbox"].ColumnEdit = chk;

            DevExpress.XtraEditors.Repository.RepositoryItemComboBox
                combo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //combo.Items.AddRange(new object[] { "", "New", "Draft" });
            combo.Items.AddRange(new object[] { "", "Prelim" });
            combo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            combo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(combo_EditValueChanging);
            gridView2.Columns["CHANGE TO"].ColumnEdit = combo;

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
            gridView2.Columns["REQUESTED BY"].ColumnEdit = rad;
            #endregion

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["STATUS"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["STATUS"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["STATUS"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["STATUS"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["STATUS"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView2.FormatConditions.Clear();
            gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

            #endregion

            if (gridView2.RowCount < 300)
                gridView2.BestFitColumns();
        }
        private void ReloadChangeReportStatus()
        {
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
        }

        #region ChangeReportStatus
        private void btnChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GenerateORU genoru = new GenerateORU();
            Utilities uti = new Utilities();
            HL7Monitoring hlobj = new HL7Monitoring();
            ProcessAddResultStatusChangeLog chlog = new ProcessAddResultStatusChangeLog();

            SendToPacs stpacs = new SendToPacs();

            string _hn = "";
            string _orderid = "";
            string _accno = "";
            string _examid = "";
            string _examname = "";
            string _origingalstatus = "";
            string _changestatus = "";
            string _reqby = "";
            string _changepc = "";
            string _orgid = "";
            string _createdby = "";
            string _hl7text = "";
            string _ordid = "";
            bool flg = false;
            DataTable dtMSG = new DataTable();
            dtMSG.Columns.Add("HN");
            dtMSG.Columns.Add("FNAME");
            dtMSG.Columns.Add("MNAME");
            dtMSG.Columns.Add("LNAME");
            dtMSG.Columns.Add("THFNAME");
            dtMSG.Columns.Add("THMNAME");
            dtMSG.Columns.Add("GENDER");
            dtMSG.Columns.Add("DOB");
            dtMSG.Columns.Add("PHONE");
            dtMSG.Columns.Add("ADDRESS");
            dtMSG.Columns.Add("ACCESSION_NO");
            dtMSG.Columns.Add("STATUS");
            dtMSG.Columns.Add("EXAM_ID");
            dtMSG.Columns.Add("EXAM_NAME");
            dtMSG.Columns.Add("HL7TXT");
            dtMSG.Columns.Add("ORDNO");

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

            foreach (DataRow row in rows)
            {
                //this.ultraGrid2.Rows[i].Cells[11].Selected = true;
                //DataRow row = gridView2.GetDataRow(i);

                //if (row["checkbox"].ToString().Trim() == "Y")
                //{
                    _hn = row["HN"].ToString().Trim();
                    _accno = row["ACCESSION NO"].ToString().Trim();
                    _examid = row["EXAM CODE"].ToString().Trim();
                    _examname = row["EXAM CODE"].ToString().Trim();
                    _origingalstatus = row["STATUS"].ToString().Trim();
                    string _changto = row["CHANGE TO"].ToString().Trim();
                    _changestatus = "P";

                    _ordid = row["ORDER ID"].ToString().Trim();
                    _reqby = row["REQUESTED BY"].ToString().Trim();

                    if (_reqby == "")
                    {
                        MessageBox.Show("Requested By cell can't be blank !");
                        return;
                    }
                    if (_changto == "")
                    {
                        MessageBox.Show("Change To cell can't be blank !");
                        return;
                    }
                    string[] a = _reqby.Split('#');
                    _reqby = a.GetValue(0).ToString().Trim();

                    _changepc = uti.MachineName();
                    _orgid = new GBLEnvVariable().OrgID.ToString();
                    _createdby = new GBLEnvVariable().UserID.ToString();

                    DataTable dt = patientDemo(_hn);

                    dtMSG.Rows.Add(dt.Rows[0]["HN"].ToString(),
                        dt.Rows[0]["FNAME_ENG"].ToString(),
                        dt.Rows[0]["MNAME_ENG"].ToString(),
                        dt.Rows[0]["LNAME_ENG"].ToString(),
                        dt.Rows[0]["FNAME"].ToString(),
                        //dt.Rows[0]["MNAME"].ToString(),
                        dt.Rows[0]["LNAME"].ToString(),
                        dt.Rows[0]["GENDER"].ToString(),
                        dt.Rows[0]["DOB"].ToString(),
                        dt.Rows[0]["PHONE1"].ToString(),
                        dt.Rows[0]["ADDR1"].ToString(),
                        _accno,
                        "P",
                        _examid,
                        _examname,
                        "Result temporarily witheld",
                        _orderid);

                    hlmsg = genoru.createMessage(dtMSG);

                    dtlog.Rows.Add(_hn,
                        _accno,
                        _examid,
                        _origingalstatus,
                        _changestatus,
                        _reqby,
                        _changepc,
                        _orgid,
                        _createdby,
                        hlmsg.Rows[0]["HL7_TXT"].ToString());


                    SendToPacs send = new SendToPacs();
                    send.Set_ORUByAccessionNoQueue(_accno);

                    hlobj.PatientID = _hn;
                    hlobj.AccessionNo = _accno;

                    string eqry = "Select EXAM_ID FROM RIS_EXAM WHERE EXAM_UID='" + _examid + "'";
                    ProcessGetGBLLookup exm = new ProcessGetGBLLookup(eqry);
                    exm.Invoke();
                    DataTable dtex = exm.ResultSet.Tables[0];
                    if (dtex.Rows.Count > 0)
                    {
                        hlobj.ExamID = Convert.ToInt32(dtex.Rows[0]["EXAM_ID"].ToString());
                    }
                    hlobj.OriginalStatus = _origingalstatus;
                    hlobj.ChangeStatus = _changestatus;
                    hlobj.RequestBy = Convert.ToInt32(_reqby);
                    hlobj.ChangePC = _changepc;
                    hlobj.OrgID = Convert.ToInt32(_orgid);
                    hlobj.CreatedBy = Convert.ToInt32(_createdby);
                    hlobj.Hl7Text = hlmsg.Rows[0]["HL7_TXT"].ToString();

                    chlog.HL7Monitoring = hlobj;
                    chlog.Invoke();

                    counts++;
                    flg = true;
                //}
                //i++;
            }
            if (counts > 0)
            {
                if (flg)
                {
                    ReloadChangeReportStatus();
                    MessageBox.Show("Successfully sent to pacs", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Message send faild to pacs", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
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
            if (gridView2.FocusedRowHandle > -1)
            {
                string status = gridView2.GetDataRow(gridView2.FocusedRowHandle)["STATUS"].ToString();
                if (status == "Finalized")
                {
                    string accNo = gridView2.GetDataRow(gridView2.FocusedRowHandle)["ACCESSION NO"].ToString();
                    DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

                    foreach (DataRow row in rows)
                    {
                        if (row["checkbox"] == "N")
                            row["checkbox"] = "Y";
                        else if (row["checkbox"] == "Y")
                            row["checkbox"] = "N";
                    }
                    gridView2.RefreshData();
                }
                else
                {
                    MessageBox.Show("Only Finalize can be change status.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    string accNo = gridView2.GetDataRow(gridView2.FocusedRowHandle)["ACCESSION NO"].ToString();
                    DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");
                    foreach (DataRow row in rows)
                        row["checkbox"] = "N";
                    gridView2.RefreshData();
                }
            }
        }

        private void chkShowDraftPrelim_CheckStateChanged(object sender, EventArgs e)
        {
            ReloadChangeReportStatus();
        }
        private void combo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                string accNo = gridView2.GetDataRow(gridView2.FocusedRowHandle)["ACCESSION NO"].ToString();
                DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

                foreach (DataRow row in rows)
                    row["CHANGE TO"] = e.NewValue;
                gridView2.RefreshData();
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
            if (gridView2.FocusedRowHandle > -1)
            {
                string accNo = gridView2.GetDataRow(gridView2.FocusedRowHandle)["ACCESSION NO"].ToString();
                DataRow[] rows = tbChangeStatus.Select("[ACCESSION NO]='" + accNo + "'");

                foreach (DataRow row in rows)
                    row["REQUESTED BY"] = e.Value;
                gridView2.RefreshData();
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
        }
        #endregion

    }
}