using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Properties;

namespace RIS.Forms.Financial
{
    public partial class frmBillingViewer : Form
    {
        DataTable tb_payment;
        DataView dv_payment;
        List<int> selectModId = new List<int>();
        List<int> selectDepId = new List<int>();

        BackgroundWorker bgW = new BackgroundWorker();

        HIS_Patient web_service = new HIS_Patient();

        public frmBillingViewer()
        {
            InitializeComponent();
        }
        private void frmHL7Monitoring_Load(object sender, EventArgs e)
        {
            dedFromdate.DateTime = DateTime.Now;
            dedTodate.DateTime = DateTime.Now;

            #region initial modality combobox

            //RIS.BusinessLogic.Technologist tech = new RIS.BusinessLogic.Technologist();
            //tech.LoadModality();
            RIS.BusinessLogic.Technologist tech = new RIS.BusinessLogic.Technologist();
            tech.LoadModality_forAIMC();

            DataTable dt = tech.dtModality;

            selectModId.Clear();
            selectModId.Add(0);

            chkListModality.Properties.Items.Clear();
            chkListModality.Properties.Items.Add("ALL:MODALITY");

            foreach (DataRow dr in dt.Rows)
            {
                selectModId.Add((int)dr["MODALITY_ID"]);
                chkListModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["MODALITY_UID"].ToString() + ")");
            }

            chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
            chkListModality.Text = "ALL:MODALITY";
            #endregion

            #region initial department combobox

            //ProcessGetHRUnit getData = new ProcessGetHRUnit();
            //getData.Invoke();
            ProcessGetHRUnit getData = new ProcessGetHRUnit();
            getData.Invoke_forAIMC();

            DataTable dtDep = getData.Result.Tables[0];
            DataRow[] drs = dtDep.Select("UNIT_TYPE = 'S'","UNIT_NAME ASC");
            dt = dtDep.Clone();
            foreach (DataRow dr in drs)
                dt.Rows.Add(dr.ItemArray);

            selectDepId.Clear();
            selectDepId.Add(0);

            chkListDepartment.Properties.Items.Clear();
            chkListDepartment.Properties.Items.Add("ALL:DEPARTMENT");

            foreach (DataRow dr in dt.Rows)
            {
                selectDepId.Add((int)dr["UNIT_ID"]);
                chkListDepartment.Properties.Items.Add(dr["UNIT_NAME"].ToString() + "(" + dr["UNIT_UID"].ToString() + ")");
            }

            //chkListDepartment.Properties.Items[0].CheckState = CheckState.Checked;
            //chkListDepartment.Text = "ALL:DEPARTMENT";
            foreach (CheckedListBoxItem item in chkListDepartment.Properties.Items)
                item.CheckState = CheckState.Checked;
            chkListDepartment.Text = "AIMC(AIMC)";
            #endregion

            SetData();
            SetFilter();
            SetGrid();
            viewData.OptionsView.ColumnAutoWidth = false;
            //viewData.BestFitColumns();

            this.bgW.WorkerSupportsCancellation = true;
            this.bgW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgW_DoWork);
        }

        private void SetData()
        {
            //DateTime dtFrom = new DateTime(dedFromdate.DateTime.Year, dedFromdate.DateTime.Month, dedFromdate.DateTime.Day, 0, 0, 0);
            //DateTime dtTo = new DateTime(dedTodate.DateTime.Year, dedTodate.DateTime.Month, dedTodate.DateTime.Day, 23, 59, 59);
            //ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            //geHL.HL7MonitoringNew.SP_TYPES = 2;
            //geHL.HL7MonitoringNew.FROM_DATE = dtFrom;
            //geHL.HL7MonitoringNew.TO_DATE = dtTo;
            //geHL.Invoke_PlaymentChecking();

            DateTime dtFrom = new DateTime(dedFromdate.DateTime.Year, dedFromdate.DateTime.Month, dedFromdate.DateTime.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(dedTodate.DateTime.Year, dedTodate.DateTime.Month, dedTodate.DateTime.Day, 23, 59, 59);
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7Monitoring.SpType = 2;
            geHL.HL7Monitoring.FromDate = dtFrom;
            geHL.HL7Monitoring.ToDate = dtTo;
            geHL.Invoke_PlaymentChecking_forAIMC();

            tb_payment = geHL.Result.Tables[0];
            tb_payment.Columns.Add("Resend");
            tb_payment.AcceptChanges();
            dv_payment = new DataView(tb_payment);
        }
        private void SetFilter()
        {

            #region less than one selected
            bool unSelAll = true;

            int kk = 0;
            while (kk < chkListModality.Properties.Items.Count)
            {
                if (chkListModality.Properties.Items[kk].CheckState == CheckState.Checked)
                {
                    unSelAll = false;
                    break;
                }
                ++kk;
            }

            if (unSelAll)
            {
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
            }

            unSelAll = true;
            kk = 0;
            while (kk < chkListDepartment.Properties.Items.Count)
            {
                if (chkListDepartment.Properties.Items[kk].CheckState == CheckState.Checked)
                {
                    unSelAll = false;
                    break;
                }
                ++kk;
            }

            if (unSelAll)
            {
                chkListDepartment.Properties.Items[0].CheckState = CheckState.Checked;
                chkListDepartment.Text = "ALL:DEPARTMENT";
            }
            #endregion

            DataView dv = tb_payment.DefaultView;
            dv.RowFilter = "";

            if (chkListModality.Properties.Items[0].CheckState == CheckState.Checked)
                dv.RowFilter = "";
            else
            {
                List<string> id = new List<string>();
                int k = 1;
                while (k < chkListModality.Properties.Items.Count)
                {
                    if (chkListModality.Properties.Items[k].CheckState == CheckState.Checked)
                    {
                        id.Add(selectModId[k].ToString());
                    }
                    ++k;
                }

                if (id.Count > 0)
                {
                    string qry = "";
                    foreach (string str in id.ToArray())
                        qry += " MODALITY_ID=" + str + " or ";
                    qry = qry.Substring(0, qry.Length - 3);

                    dv.RowFilter = "(" + qry + ")";
                }
            }

            if (chkListDepartment.Properties.Items[0].CheckState == CheckState.Checked)
            {
                if (dv.RowFilter == "")
                    dv.RowFilter = "";
            }
            else
            {
                List<string> id = new List<string>();
                int k = 1;
                while (k < chkListDepartment.Properties.Items.Count)
                {
                    if (chkListDepartment.Properties.Items[k].CheckState == CheckState.Checked)
                    {
                        id.Add(selectDepId[k].ToString());
                    }
                    ++k;
                }

                if (id.Count > 0)
                {
                    string qry = "";
                    foreach (string str in id.ToArray())
                        qry += " UNIT_ID=" + str + " or ";
                    qry = qry.Substring(0, qry.Length - 3);

                    if (dv.RowFilter == "")
                        dv.RowFilter = "(" + qry + ")";
                    else
                        dv.RowFilter += " AND (" + qry + ")";
                }
            }

            if (chkIsSetBilling.CheckState == CheckState.Checked)
            {
                if (dv.RowFilter == "")
                    dv.RowFilter += "HIS_SYNC='Y'";
                else
                    dv.RowFilter += "AND HIS_SYNC='Y'";
            }

            dv_payment = dv;

        }
        private void SetGrid()
        {
            grdData.DataSource = dv_payment;

            int k = 0;
            while (k < viewData.Columns.Count)
            {
                viewData.Columns[k].Visible = false;
                k++;
            }

            viewData.OptionsView.ShowAutoFilterRow = true;
            viewData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            //DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnReSend = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //btnReSend.ButtonsStyle = BorderStyles.Office2003;
            //btnReSend.Buttons[0].Kind = ButtonPredefines.Glyph;
            //btnReSend.Buttons[0].Caption = "Refresh";
            //btnReSend.TextEditStyle = TextEditStyles.HideTextEditor;
            //btnReSend.ButtonClick += new ButtonPressedEventHandler(btnReSend_ButtonClick);

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnReSend
                = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnReSend.ButtonsStyle = BorderStyles.Default;
            btnReSend.Buttons[0].Caption = "";
            btnReSend.Buttons[0].Image = Resources.refresh;
            btnReSend.Buttons[0].ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnReSend.TextEditStyle = TextEditStyles.HideTextEditor;
            btnReSend.ButtonClick += new ButtonPressedEventHandler(btnReSend_ButtonClick);

            viewData.Columns["Resend"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["Resend"].ColumnEdit = btnReSend;
            viewData.Columns["Resend"].Caption = "Refresh";
            viewData.Columns["Resend"].ColVIndex = 1;
            viewData.Columns["Resend"].OptionsColumn.ReadOnly = true;

            viewData.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HN"].Caption = "HN";
            viewData.Columns["HN"].ColVIndex = 2;
            viewData.Columns["HN"].OptionsColumn.ReadOnly = true;

            viewData.Columns["NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["NAME"].Caption = "Name";
            viewData.Columns["NAME"].ColVIndex = 3;
            viewData.Columns["NAME"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_UID"].Caption = "Exam Code";
            viewData.Columns["EXAM_UID"].ColVIndex = 4;
            viewData.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewData.Columns["EXAM_NAME"].ColVIndex = 5;
            viewData.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

            viewData.Columns["ORDER_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ORDER_DT"].Caption = "Study Date";
            viewData.Columns["ORDER_DT"].ColVIndex = 6;
            viewData.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            viewData.Columns["ORDER_DT"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ssss";
            viewData.Columns["ORDER_DT"].DisplayFormat.FormatType = FormatType.DateTime;

            viewData.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["QTY"].Caption = "Qty";
            viewData.Columns["QTY"].ColVIndex = 7;
            viewData.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewData.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["RATE"].Caption = "Rate";
            viewData.Columns["RATE"].ColVIndex = 8;
            viewData.Columns["RATE"].OptionsColumn.ReadOnly = true;

            //viewData.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //viewData.Columns["MODALITY_NAME"].Caption = "Modality";
            //viewData.Columns["MODALITY_NAME"].ColVIndex = 8;
            //viewData.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = true;

            //viewData.Columns["HIS_SYNC"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //viewData.Columns["HIS_SYNC"].Caption = "Billing Status";
            //viewData.Columns["HIS_SYNC"].ColVIndex = 9;
            //viewData.Columns["HIS_SYNC"].OptionsColumn.ReadOnly = true;

            viewData.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["STATUS"].Caption = "Payment Status";
            viewData.Columns["STATUS"].ColVIndex = 10;
            viewData.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            viewData.Columns["INSURANCE_TYPE_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["INSURANCE_TYPE_UID"].Caption = "Insurance Type";
            viewData.Columns["INSURANCE_TYPE_UID"].ColVIndex = 11;
            viewData.Columns["INSURANCE_TYPE_UID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["CLINIC_TYPE_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["CLINIC_TYPE_UID"].Caption = "Clinic Type";
            viewData.Columns["CLINIC_TYPE_UID"].ColVIndex = 12;
            viewData.Columns["CLINIC_TYPE_UID"].OptionsColumn.ReadOnly = true;

            //viewData.Columns["UNIT_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //viewData.Columns["UNIT_UID"].Caption = "Unit Code";
            //viewData.Columns["UNIT_UID"].ColVIndex = 12;
            //viewData.Columns["UNIT_UID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["ACCESSION_NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ACCESSION_NO"].Caption = "Accession No.";
            viewData.Columns["ACCESSION_NO"].ColVIndex = 13;
            viewData.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;

            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit btnCheckBox 
            //    = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //btnCheckBox.ButtonsStyle = BorderStyles.Default;
            //btnCheckBox.Buttons[0].Caption = "";
            //btnCheckBox.Buttons[0].Image = Resources.refresh;
            //btnCheckBox.Buttons[0].ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            //btnCheckBox.TextEditStyle = TextEditStyles.HideTextEditor;

            viewData.Columns["Resend"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["Resend"].ColumnEdit = btnReSend;
            viewData.Columns["Resend"].Caption = "Refresh";
            viewData.Columns["Resend"].ColVIndex = 1;
            viewData.Columns["Resend"].OptionsColumn.ReadOnly = true;

            txtSummary_Changing();            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetData();
            SetFilter();
            SetGrid();
        }
        private void btnReSend_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (viewData.FocusedRowHandle < 0) 
                return;

            int focusrow = viewData.FocusedRowHandle;
            DataRow dr = viewData.GetDataRow(focusrow);

            string HN = dr["HN"].ToString();
            string AN = " ";
            string ACC = dr["ACCESSION_NO"].ToString();

            string EXAM_UID = dr["EXAM_UID"].ToString();
            string PAY_ID = dr["PAY_ID"].ToString();

            int EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);

            DataSet ds;

            try
            {
                LoadProgressBar();
                ds = web_service.Get_Payment_Status(HN, AN, ACC);
                LoadStopProgressBar();
            }
            catch (Exception ex)
            {
                LoadStopProgressBar();
                //try
                //{
                //    System.Threading.Thread.Sleep(2000);
                //    ds = web_service.Get_Payment_Status(HN, AN, ACC);
                //}
                //catch (Exception ex)
                //{
                    string error_msg =
                        " [-] " + DateTime.Now.ToString("G") + " \r\n"
                        + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                        + "Can't connect to the server.\r\n  [-] Error:" + ex.Message + "\r\n\r\n";
                    MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                //}
            }
            DataTable tb = ds.Tables[0];

            if (tb == null || tb.Rows.Count == 0)
            {
                string error_msg =
                    " [-] " + DateTime.Now.ToString("G") + " \r\n"
                    + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                    + "  Null Data " + "\r\n\r\n";
                MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (tb.Rows.Count > 1)
            {
                string error_msg =
                    " [-] " + DateTime.Now.ToString("G") + " \r\n"
                    + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                    + " More than one row data " + "\r\n\r\n";
                MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                frmBillingViewer_result frm = new frmBillingViewer_result(tb);
                frm.ShowDialog();
                return;
            }

            if (tb.Rows[0][0] == null || tb.Rows[0][0].ToString().Trim().Length == 0)
            {
                string error_msg =
                    " [-] " + DateTime.Now.ToString("G") + " \r\n"
                    + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                    + " Blank Data " + "\r\n\r\n";
                MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (tb.Rows[0]["hn"].ToString() != dr["HN"].ToString())
            {
                string error_msg =
                    " [-] " + DateTime.Now.ToString("G") + " \r\n"
                    + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                    + " HN not match " + "\r\n\r\n";
                MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                frmBillingViewer_result frm = new frmBillingViewer_result(tb);
                frm.ShowDialog();
                return;
            }

            if (tb.Rows[0]["exam_code"].ToString() != dr["EXAM_UID"].ToString())
            {
                string error_msg =
                    " [-] " + DateTime.Now.ToString("G") + " \r\n"
                    + "  HN:" + HN + " ACC:" + ACC + " EXAM_UID:" + EXAM_UID + " PAY_ID:" + PAY_ID + " \r\n "
                    + " EXAM not match " + "\r\n\r\n";
                MessageBox.Show(error_msg, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                frmBillingViewer_result frm = new frmBillingViewer_result(tb);
                frm.ShowDialog();
                return;
            }

            //int tb_intdex = tb_payment.Rows.IndexOf(dr);
            //tb_payment.Rows[tb_intdex]["STATUS"] = "PAID";
            //tb_payment.AcceptChanges();
            //dv_payment = new DataView(tb_payment);

            if (tb.Rows[0]["pay_status"].ToString().Trim() == "F")
            {
                MessageBox.Show("FULL paid payment", "FULL paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                ProcessUpdateFINPaymentdtl_UpdateStatus update
                    = new ProcessUpdateFINPaymentdtl_UpdateStatus();
                update.FIN_PAYMENTDTL.PAY_ID = Convert.ToInt64(PAY_ID);
                update.FIN_PAYMENTDTL.EXAM_ID = EXAM_ID;
                update.FIN_PAYMENTDTL.STATUS = 'F';
                update.Invoke();

                SetData();
                SetFilter();
                SetGrid();
            }
            else if (tb.Rows[0]["pay_status"].ToString().Trim() == "P")
            {
                MessageBox.Show("PARTIAL paid payment", "PARTIAL paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProcessUpdateFINPaymentdtl_UpdateStatus update
                    = new ProcessUpdateFINPaymentdtl_UpdateStatus();
                update.FIN_PAYMENTDTL.PAY_ID = Convert.ToInt64(PAY_ID);
                update.FIN_PAYMENTDTL.EXAM_ID = EXAM_ID;
                update.FIN_PAYMENTDTL.STATUS = 'P';
                update.Invoke();

                SetData();
                SetFilter();
                SetGrid();
            }
            else if (tb.Rows[0]["pay_status"].ToString().Trim() == "D")
            {
                MessageBox.Show("DUE paid payment", "DUE paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProcessUpdateFINPaymentdtl_UpdateStatus update
                    = new ProcessUpdateFINPaymentdtl_UpdateStatus();
                update.FIN_PAYMENTDTL.PAY_ID = Convert.ToInt64(PAY_ID);
                update.FIN_PAYMENTDTL.EXAM_ID = EXAM_ID;
                update.FIN_PAYMENTDTL.STATUS = 'D';
                update.Invoke();

                SetData();
                SetFilter();
                SetGrid();
            }
            else
            {
                MessageBox.Show("Patient is unpaid", "Unpaid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SetFilter();
                SetGrid();
            }

        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF|*.PDF";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length == 0) return;

                viewData.ExportToPdf(saveFileDialog1.FileName);
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "XLS|*.XLS";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length == 0) return;

                viewData.ExportToExcelOld(saveFileDialog1.FileName);
            }
        }

        private void chkListModality_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.AcceptValue == true)
            {
                SetFilter();
                SetGrid(); 
            }
        }
        private void chkListDepartment_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.AcceptValue == true)
            {
                SetFilter();
                SetGrid();
            }
        }

        private void checkEdit1_Properties_CheckStateChanged(object sender, EventArgs e)
        {
            SetFilter();
            SetGrid();
        }

        private void LoadProgressBar()
        {
            if (!bgW.IsBusy)
            {
                this.Enabled = false;
                bgW.RunWorkerAsync();
            }
        }
        private void LoadStopProgressBar()
        {
            bgW.CancelAsync();
            this.Enabled = true;
            this.Focus();
        }
        private void bgW_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressBar frmPg = new ProgressBar(bgW);
            frmPg.ShowDialog();
        }

        private void txtSummary_Changing()
        {
            int total_pending = 0;
            int total_partial = 0;
            int total_paid = 0;

            decimal amount_pending = 0;
            decimal amount_partial = 0;
            decimal amount_paid = 0;

            int k = 0;
            for (int i = 0; i < viewData.RowCount; i++)
            {
                decimal pending = 0;
                decimal partial = 0;
                decimal paid = 0;

                DataRow row = viewData.GetDataRow(i);

                try
                {
                    //if (row["FIN_STATUS"].ToString() == "D")
                    if (row["FIN_STATUS"].ToString() != "P" && row["FIN_STATUS"].ToString() != "F")
                    {
                        pending = Convert.ToInt32(row["QTY"]) * Convert.ToInt32(row["RATE"]);
                        total_pending++;
                    }
                    if (row["FIN_STATUS"].ToString() == "P")
                    {
                        partial = Convert.ToInt32(row["QTY"]) * Convert.ToInt32(row["RATE"]);
                        total_partial++;
                    }
                    if (row["FIN_STATUS"].ToString() == "F")
                    {
                        paid = Convert.ToInt32(row["QTY"]) * Convert.ToInt32(row["RATE"]);
                        total_paid++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                amount_pending += pending;
                amount_partial += partial;
                amount_paid += paid;
            }

            txtPending.Text = total_pending.ToString();
            txtPartial.Text = total_partial.ToString();
            txtPaid.Text = total_paid.ToString();

            txtAmountPending_paid.Text = "0.00";//amount_pending.ToString("n");
            txtAmountPending_remain.Text = amount_pending.ToString("n");

            txtAmountPartial_paid.Text = amount_partial.ToString("n");
            txtAmountPartial_remain.Text = "0.00";//amount_partial.ToString("n");

            txtAmountPaid_paid.Text = amount_paid.ToString("n");
            txtAmountPaid_remain.Text = "0.00";//amount_paid.ToString("n");

            ++k;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < viewData.RowCount; i++)
            {
                DataRow dr = viewData.GetDataRow(i);

                string HN = dr["HN"].ToString();
                string AN = " ";
                string ACC = dr["ACCESSION_NO"].ToString();

                string EXAM_UID = dr["EXAM_UID"].ToString();
                string PAY_ID = dr["PAY_ID"].ToString();

                int EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);

                try
                {
                    //Resend_All_Data(HN, AN, ACC);
                }
                catch { }
            }
        }
        private void Resend_All_Data(string HN,string AN,string ACC, int number)
        {
            //DataSet ds = new DataSet();

            //LoadProgressBar();
            //ds = web_service.Get_Payment_Status(HN, AN, ACC);
            //LoadStopProgressBar();

            //DataTable tb = ds.Tables[0];

            //if (tb.Rows[0]["pay_status"].ToString().Trim() == "F")
            //{
            //    MessageBox.Show("FULL paid payment", "FULL paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    ProcessUpdateFINPaymentdtl_UpdateStatus update
            //        = new ProcessUpdateFINPaymentdtl_UpdateStatus();
            //    update.FINPaymentdtl.PAY_ID = Convert.ToInt64(PAY_ID);
            //    update.FINPaymentdtl.EXAM_ID = EXAM_ID;
            //    update.FINPaymentdtl.STATUS = "F";
            //    update.Invoke();

            //    SetData();
            //    SetFilter();
            //    SetGrid();
            //}
            //else if (tb.Rows[0]["pay_status"].ToString().Trim() == "P")
            //{
            //    MessageBox.Show("PARTIAL paid payment", "PARTIAL paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    ProcessUpdateFINPaymentdtl_UpdateStatus update
            //        = new ProcessUpdateFINPaymentdtl_UpdateStatus();
            //    update.FINPaymentdtl.PAY_ID = Convert.ToInt64(PAY_ID);
            //    update.FINPaymentdtl.EXAM_ID = EXAM_ID;
            //    update.FINPaymentdtl.STATUS = "P";
            //    update.Invoke();

            //    SetData();
            //    SetFilter();
            //    SetGrid();
            //}
            //else if (tb.Rows[0]["pay_status"].ToString().Trim() == "D")
            //{
            //    MessageBox.Show("DUE paid payment", "DUE paid payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    ProcessUpdateFINPaymentdtl_UpdateStatus update
            //        = new ProcessUpdateFINPaymentdtl_UpdateStatus();
            //    update.FINPaymentdtl.PAY_ID = Convert.ToInt64(PAY_ID);
            //    update.FINPaymentdtl.EXAM_ID = EXAM_ID;
            //    update.FINPaymentdtl.STATUS = "D";
            //    update.Invoke();

            //    SetData();
            //    SetFilter();
            //    SetGrid();
            //}
            //else
            //{
            //    MessageBox.Show("Patient is unpaid", "Unpaid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    SetFilter();
            //    SetGrid();
            //}
        }
        //private void LoadProgressBar_ShowNumber()
        //{
        //    if (!bgW.IsBusy)
        //    {
        //        this.Enabled = false;
        //        bgW.RunWorkerAsync();
        //    }
        //}
    }

    public class ProgressBar : Form
    {
        #region Designer

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = "In a Progress...";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(2, 2);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueeProgressBarControl1.Properties.Appearance.Options.UseFont = true;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(180, 23);
            this.marqueeProgressBarControl1.StyleController = this.layoutControl1;
            this.marqueeProgressBarControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.marqueeProgressBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(183, 26);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(183, 26);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.marqueeProgressBarControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(181, 24);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(183, 26);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.Text = "ProgressBar";
            this.Load += new System.EventHandler(this.ProgressBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;

        #endregion

        BackgroundWorker bg;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

        public ProgressBar(BackgroundWorker bg)
        {
            InitializeComponent();
            this.bg = bg;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
        }
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            tm.Interval = 500;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            if (bg.CancellationPending == true)
                this.Close();
        }
    }
}