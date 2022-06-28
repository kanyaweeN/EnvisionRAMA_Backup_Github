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
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Main;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Envision.NET.Forms.Admin
{
    public partial class frmBillingMonitoring : MasterForm
    {
        private List<string> AccessionNO;
        private List<string> AccessionList_Can;
        private int _OrderID;
        FinancialBilling fnBill = new FinancialBilling();
      
        private GBLEnvVariable env = new GBLEnvVariable();
        private string HNCan, AccessionCan, ANCan, ISEQCan;

        private DataTable dtUnitSelected;
        private DataView dvUnitSelected;

        private int Enc_ID;
        private string Enc_Type;
        private string Insurance_UID;

        public frmBillingMonitoring()
        {
            InitializeComponent();

            AccessionNO = new List<string>();
            AccessionNO.Clear();

            dedFromdate.DateTime = DateTime.Now;
            dedTodate.DateTime = DateTime.Now;
        }
        private void frmHL7Monitoring_Load(object sender, EventArgs e)
        {
            dedFromdate.DateTime = DateTime.Now;
            dedTodate.DateTime = DateTime.Now;
            if (AccessionNO.Count > 0)
            {
                BindData(_OrderID);
                layoutControlGroup2.Expanded = false;
                layoutControlGroup2.ExpandButtonVisible = false;
                viewData.OptionsView.ColumnAutoWidth = false;
                viewData.BestFitColumns();
            }
            else
            {
                BindData();
            }

            base.CloseWaitDialog();
        }

        private void BindData()
        {
            DateTime dtFrom = new DateTime(dedFromdate.DateTime.Year, dedFromdate.DateTime.Month, dedFromdate.DateTime.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(dedTodate.DateTime.Year, dedTodate.DateTime.Month, dedTodate.DateTime.Day, 23, 59, 59);
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7Monitoring.SpType = 2;
            geHL.HL7Monitoring.FromDate = dtFrom;
            geHL.HL7Monitoring.ToDate = dtTo;
            geHL.Invoke();
            DataTable dt = geHL.Result.Tables[0];

            grdData.DataSource = dt;

            SetGrid();
        }
        private void BindData(int OrderID)
        {
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7Monitoring.SpType = 0;
            geHL.HL7Monitoring.OrgID = _OrderID;
            geHL.Invoke();
            DataTable dt = geHL.Result.Tables[0];

            bool Check = false;
            foreach (DataRow dr in dt.Rows)
            {
                Check = false;
                for (int i = 0; i < AccessionNO.Count; i++)
                {
                    if (AccessionNO[i].ToString() == dr["ACCESSION NO"].ToString())
                    {
                        Check = true;
                        break;
                    }
                }
                if (Check == false)
                    dt.Rows.Remove(dr);
            }
            dt.AcceptChanges();
            DataRow[] drt = dt.Select("HISSYNC='N'");
            DataTable dtr = new DataTable();
            dtr = dt.Clone();
            for (int d = 0; d < drt.Length; d++)
			{
                dtr.Rows.Add(drt[d].ItemArray);
			}
            dtr.AcceptChanges();
            grdData.DataSource = dtr;

            SetGrid();
            viewData.Columns["SENTC"].Visible = false;
            viewData.Columns["CHANGE TO"].Visible = false;
        }
        private void SetData()
        {
            DateTime dtFrom = new DateTime(dedFromdate.DateTime.Year, dedFromdate.DateTime.Month, dedFromdate.DateTime.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(dedTodate.DateTime.Year, dedTodate.DateTime.Month, dedTodate.DateTime.Day, 23, 59, 59);
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7Monitoring.SpType = 2;
            geHL.HL7Monitoring.FromDate = dtFrom;
            geHL.HL7Monitoring.ToDate = dtTo;
            geHL.Invoke();
            DataTable dt = geHL.Result.Tables[0];

            grdData.DataSource = dt;
        }
        private void SetGrid()
        {
            viewData.OptionsView.ShowAutoFilterRow = true;
            
            foreach (BandedGridColumn col in viewData.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.ReadOnly = true;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSend = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSend.ButtonsStyle = BorderStyles.Office2003;
            btnSend.Buttons[0].Caption = string.Empty;
            btnSend.Buttons[0].Kind = ButtonPredefines.Plus;
            btnSend.TextEditStyle = TextEditStyles.HideTextEditor;
            btnSend.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnSend_ButtonClick);

            viewData.Columns["CHANGE TO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["CHANGE TO"].ColumnEdit = btnSend;
            viewData.Columns["CHANGE TO"].Caption = "Resend Billing";
            viewData.Columns["CHANGE TO"].ColVIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnCan = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnCan.ButtonsStyle = BorderStyles.Office2003;
            btnSend.Buttons[0].Caption = string.Empty;
            btnCan.Buttons[0].Kind = ButtonPredefines.Delete;
            btnCan.TextEditStyle = TextEditStyles.HideTextEditor;
            btnCan.ButtonClick += new ButtonPressedEventHandler(btnCan_ButtonClick);

            viewData.Columns["SENTC"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["SENTC"].ColumnEdit = btnCan;
            viewData.Columns["SENTC"].Caption = "Cancel Billing";
            viewData.Columns["SENTC"].ColVIndex = 2;

            viewData.Columns["ACCESSION NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ACCESSION NO"].Caption = "Accession No.";
            viewData.Columns["ACCESSION NO"].ColVIndex = 3;

            viewData.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HN"].Caption = "HN";
            viewData.Columns["HN"].ColVIndex = 4;

            viewData.Columns["EXAM CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM CODE"].Caption = "Exam Code";
            viewData.Columns["EXAM CODE"].ColVIndex = 5;

            viewData.Columns["EXAM NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM NAME"].Caption = "Exam Name";
            viewData.Columns["EXAM NAME"].ColVIndex = 6;

            viewData.Columns["SERVICE_TYPE_TEXT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["SERVICE_TYPE_TEXT"].Caption = "Service Type";
            viewData.Columns["SERVICE_TYPE_TEXT"].ColVIndex = 7;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtRp = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            viewData.Columns["ORDER TIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ORDER TIME"].Caption = "Study Date";
            viewData.Columns["ORDER TIME"].ColumnEdit = txtRp;
            viewData.Columns["ORDER TIME"].ColVIndex = 8;

            viewData.Columns["EMP_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EMP_UID"].Caption = "User Code";
            viewData.Columns["EMP_UID"].ColVIndex = 9;

            viewData.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["QTY"].Caption = "Qty";
            viewData.Columns["QTY"].ColVIndex = 10;

            viewData.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["RATE"].Caption = "Rate";
            viewData.Columns["RATE"].ColVIndex = 11;

            viewData.Columns["HISSYNC"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HISSYNC"].Caption = "His Sync";
            viewData.Columns["HISSYNC"].ColVIndex = 12;

            RepositoryItemMemoExEdit memx = new RepositoryItemMemoExEdit();

            viewData.Columns["HIS_ACK"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HIS_ACK"].Caption = "His Ack";
            viewData.Columns["HIS_ACK"].ColumnEdit = memx;
            viewData.Columns["HIS_ACK"].ColVIndex = 13;

            viewData.Columns["UNIT_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["UNIT_UID"].Caption = "Dept. Code";
            viewData.Columns["UNIT_UID"].ColVIndex = 14;

            viewData.Columns["STATUS_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["STATUS_NAME"].Caption = "Status";
            viewData.Columns["STATUS_NAME"].ColVIndex = 15;      

            viewData.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["MODALITY_NAME"].Caption = "Modality Name";
            viewData.Columns["MODALITY_NAME"].ColVIndex = 16;

            //viewData.Columns["ASSIGNED_TO_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //viewData.Columns["ASSIGNED_TO_NAME"].Caption = "Assigned To";
            //viewData.Columns["ASSIGNED_TO_NAME"].ColVIndex = 17;

            viewData.Columns["INSURANCE_TYPE_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["INSURANCE_TYPE_ID"].Caption = "Insurance Type";
            viewData.Columns["INSURANCE_TYPE_ID"].ColVIndex = 18;

            viewData.Columns["CLINIC_TYPE_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["CLINIC_TYPE_NAME"].Caption = "Clinic Type";
            viewData.Columns["CLINIC_TYPE_NAME"].ColVIndex = 19;
        }

        private void btnCan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CancelBilling();
            frmMonitoringConfirm frmMC = new frmMonitoringConfirm(AccessionCan, HNCan, ANCan, ISEQCan);
            frmMC.MinimizeBox = false;
            frmMC.MaximizeBox = false;
            frmMC.StartPosition = FormStartPosition.CenterParent;
            frmMC.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmMC.Text = "Take Billing";
            frmMC.ShowDialog();
            if (frmMC.DialogResult == DialogResult.Cancel)
            {
                BindData();
            }

        }
        private void btnSend_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (viewData.FocusedRowHandle < 0)
            {
                MessageBox.Show("No Item was selected.");
                return;
            }
            DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);

            #region ENCOUNTER & ADMISSION UPDATING
            DataTable enc_tb = fnBill.LoadCurrentEncounter(dr["ACCESSION NO"].ToString());
            if (enc_tb.Rows.Count == 0)
            {
                MessageBox.Show("Can't update encounter.");
                return;
            }
            try
            {
                string enc_hn = enc_tb.Rows[0]["HN"].ToString();
                string enc_unit_uid = enc_tb.Rows[0]["UNIT_UID"].ToString();
                int enc_order_id = Convert.ToInt32(enc_tb.Rows[0]["ORDER_ID"]);

                if (enc_tb.Rows[0]["ADMISSION_NO"].ToString().Trim().Length == 0)
                {
                    string admission_no = fnBill.LoadAdmissinNo(enc_hn);
                    if (admission_no.Length != 0)
                        fnBill.UpdateAddmissionNo(enc_order_id, admission_no);
                }

                if (enc_tb.Rows[0]["ENC_TYPE"].ToString().Trim().Length == 0)
                {
                    string strEnc_id = "";
                    string strEnc_type = "";
                    fnBill.LoadEncounter(enc_hn, enc_unit_uid, ref strEnc_id, ref strEnc_type);
                    fnBill.UpdateEncount(enc_order_id, strEnc_id, strEnc_type);
                }
            }
            catch
            {
                MessageBox.Show("Can't update encounter.");
                return;
            }
            #endregion

            string str = SendBilling();

            frmMonitoringConfirm frmMC = new frmMonitoringConfirm(str, dr["ACCESSION NO"].ToString(), dr["HN"].ToString());
            frmMC.MinimizeBox = false;
            frmMC.MaximizeBox = false;
            frmMC.StartPosition = FormStartPosition.CenterParent;
            frmMC.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmMC.Text = "Take Billing";
            frmMC.ShowDialog();
            if (frmMC.DialogResult == DialogResult.Cancel)
            {
                BindData();
            }
        }
        private void btnResend_Click(object sender, EventArgs e)
        {
            SetData();
            SetGrid();
        }

        private void LoadUnitSelectedData()
        {
            dtUnitSelected = new DataTable();
            dvUnitSelected = new DataView(dtUnitSelected);
            

        }
        private void LoadUnitSelectedFilter()
        {
        }
        private void LoadUnitSelectedGrid()
        {
        }
        private void ReloadUnitSelected()
        {
            LoadUnitSelectedData();
            LoadUnitSelectedFilter();
            LoadUnitSelectedGrid();
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

        private void LoadInsuranceDetail(string HN, string OrderDept)
        {
            try
            {
                if (OrderDept.Trim().Length == 0) return;

                DataSet dsInsurance = new DataSet();
                DataSet dsExcount = new DataSet();

                string enc_id = " ";
                string enc_type = " ";
                DataRow[] rows_insurance;
                string sdloc = " ";

                HIS_Patient p = new HIS_Patient();
                dsExcount = p.GetEncounterDetailByMRNForToday(HN);
                if (dsExcount.Tables[0].Rows.Count < 1)
                {
                    dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                    if (dsExcount.Tables[0].Rows.Count < 1)
                    {
                        enc_id = "0";
                        enc_type = "OTH";
                    }
                    else
                    {
                        string[] str_insurance = OrderDept.Split(new string[] { ":" }, StringSplitOptions.None);
                        rows_insurance = dsExcount.Tables[0].Select("sdloc_id='" + str_insurance[0] + "'", " enc_id desc ");

                        if (rows_insurance.Length > 0)
                        {
                            enc_id = rows_insurance[0]["enc_id"].ToString();
                            enc_type = rows_insurance[0]["enc_type"].ToString();
                        }
                        else
                        {
                            enc_id = "0";
                            enc_type = "OTH";
                        }
                    }
                }
                else
                {
                    string[] str_insurance = OrderDept.Split(new string[] { ":" }, StringSplitOptions.None);
                    rows_insurance = dsExcount.Tables[0].Select("sdloc_id='" + str_insurance[0] + "'", " enc_id desc ");

                    if (rows_insurance.Length > 0)
                    {
                        enc_id = rows_insurance[0]["enc_id"].ToString();
                        enc_type = rows_insurance[0]["enc_type"].ToString();
                    }
                    else
                    {
                        dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                        if (dsExcount.Tables[0].Rows.Count < 1)
                        {
                            enc_id = "0";
                            enc_type = "OTH";
                        }
                        else
                        {
                            str_insurance = OrderDept.Split(new string[] { ":" }, StringSplitOptions.None);
                            rows_insurance = dsExcount.Tables[0].Select("sdloc_id='" + str_insurance[0] + "'", " enc_id desc ");

                            if (rows_insurance.Length > 0)
                            {
                                enc_id = rows_insurance[0]["enc_id"].ToString();
                                enc_type = rows_insurance[0]["enc_type"].ToString();
                            }
                            else
                            {
                                enc_id = "0";
                                enc_type = "OTH";
                            }
                        }
                    }

                    sdloc = str_insurance[0];
                }

                string perf_date = DateTime.Now.ToString("dd/MM") + "/" + DateTime.Now.Year.ToString();
                string clinic_type = "RGL";

                dsInsurance = p.GetEligibilityInsuranceDetail(HN, enc_type, enc_id, sdloc, perf_date, clinic_type);

                if (dsInsurance.Tables[0].Rows.Count > 0)
                {
                    //DataTable dtt = order.Ris_InsuranceType();
                    //foreach (DataRow drIns in dtt.Rows)
                    //{
                    //    if (drIns["INSURANCE_TYPE_UID"].ToString() == dsInsurance.Tables[0].Rows[0]["insurance"].ToString())
                    //    {
                    //        txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
                    //        txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
                    //        txtTempInsurance.Text = txtInsurace.Text;

                    //        thisOrder.Item.INSURANCE_TYPE_ID = Convert.ToInt32(txtInsurace.Tag);
                    //        thisOrder.Demographic.InsuranceID = Convert.ToInt32(txtInsurace.Tag);
                    //        thisOrder.Demographic.Insurance_Type = dsInsurance.Tables[0].Rows[0]["insurance"].ToString();
                    //        break;
                    //    }
                    //}

                    Insurance_UID = dsInsurance.Tables[0].Rows[0]["insurance"].ToString();
                }
                else
                {
                    Insurance_UID = "UNK";
                }

                Enc_ID = Convert.ToInt32(enc_id == null ? "0" : enc_id);
                Enc_Type = enc_type;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[Insurance Type]");
            }
        }
        private void CancelBilling()
        {
            HIS_Patient BillHis = new HIS_Patient();
            //DataTable dtG = (DataTable)grdData.DataSource;
            DataRow drv = viewData.GetDataRow(viewData.FocusedRowHandle);
            string strAN = "";
            string strISEQ = "";
            DataSet dsIPD = BillHis.Get_ipd_detail(drv["HN"].ToString());
            for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
            {
                strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                if (strAN != "")
                {
                    //strMstype = "I";
                    strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                }
                else
                {
                    //strMstype = "O";
                    strAN = " ";
                }
                strISEQ = "";// dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
            }
            //for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
            //{
            //    //strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
            //    //if (strAN != "")
            //    //{
            //    //    strMstype = "I";
            //    //}
            //    //else
            //    //{
            //    //    strMstype = "O";
            //    //}
            //    strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
            //}
            if (string.IsNullOrEmpty(strISEQ)) strISEQ = "1";
            if (string.IsNullOrEmpty(strAN)) strAN = " ";

            AccessionCan = drv["ACCESSION NO"].ToString();
            HNCan = drv["HN"].ToString();
            ANCan = strAN;
            ISEQCan = strISEQ;
        }
        private string SendBilling()
        {
            string strBilling = "";

            try
            {
                DataRow drv = viewData.GetDataRow(viewData.FocusedRowHandle);

                string HN = drv["HN"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["HN"].ToString();
                string Accession = drv["ACCESSION NO"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["ACCESSION NO"].ToString();

                DataTable dt = fnBill.GetBillingMessage(Accession).Tables[0];
                if (dt.Rows.Count == 1)
                    strBilling = dt.Rows[0]["BILLING_MESSAGE"].ToString();
                else
                    for (int i = 0; i < dt.Rows.Count; i++)
                        if (i == 0)
                            strBilling = dt.Rows[i]["BILLING_MESSAGE"].ToString();
                        else
                            strBilling += "^" + dt.Rows[i]["BILLING_MESSAGE"].ToString();

            }
            catch (Exception exx)
            {

                MessageBox.Show("Error :" + exx.Message);
            }

            return strBilling;
        }
    }
}