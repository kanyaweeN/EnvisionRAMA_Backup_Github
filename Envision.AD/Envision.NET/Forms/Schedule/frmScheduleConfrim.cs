using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using Envision.BusinessLogic;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Miracle.Util;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleConfrim : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtShare;
        private DataSet dsCreateOrder;
        private Order thisOrder;
        private OrderManager orderManger;
        private int scheduleID, orderID;
        private int[] langid;
        private string defaultlangs;
        Patient patient;
        GBLEnvVariable env = new GBLEnvVariable();
        MyMessageBox msg = new MyMessageBox();

        public frmScheduleConfrim()
        {
            InitializeComponent();
        }
        public frmScheduleConfrim(DataRow dr)
        {
            InitializeComponent();
            dtShare = new DataTable();
            ProcessGetRISScheduledtl process = new ProcessGetRISScheduledtl(DateTime.Now, DateTime.Now, Convert.ToInt32(dr["SCHEDULE_ID"]));
            DataSet ds = new DataSet();
            process.Invoke();
            ds = process.Result;
            dtShare = ds.Tables[0].Copy();
            btnSave.Focus();
            BindData();
            patient = new Patient(dr["HN"].ToString().Trim(),true);
            //btnPatientAllergy.Enabled = patient.ISAllergy;
        }
        private void frmScheduleConfrim_Load(object sender, EventArgs e)
        {

        }
        private void loadFormLanguage()
        {
            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;
            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch { }
            try
            {

                DataTable dt = langs.ResultSet.Tables[0];
                langid = new int[dt.Rows.Count];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    langid[k] = Convert.ToInt32(lid);
                    if ((dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim()) == ("Y"))
                    {
                        defaultlangs = dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim();
                        new GBLEnvVariable().CurrentLanguageID = Convert.ToInt32(dt.Rows[k]["LANG_ID"].ToString().Trim());
                    }
                    k++;
                }
            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }
        }

        private void BindData()
        {
            grdControl.DataSource = dtShare;
            SetGrid();

            foreach (DataRow dr in dtShare.Rows)
            {
                txtHN.Tag = Convert.ToInt32(dr["REG_ID"]);
                txtHN.Text = dr["HN"].ToString();

                txtThaiName.Text = dr["NameThai"].ToString();
                txtEngName.Text = dr["NameEng"].ToString();


                txtHN.Properties.ReadOnly = true;
                txtThaiName.Properties.ReadOnly = true;
                txtEngName.Properties.ReadOnly = true;

                ProcessGetRISSchedule process = new ProcessGetRISSchedule(Convert.ToInt32(dr["SCHEDULE_ID"]));
                process.Invoke();
                dsCreateOrder = new DataSet();
                dsCreateOrder = process.Result;
                try
                {
                    DataRow[] drC = RISBaseData.His_Department().Select("UNIT_ID = " + Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_UNIT"]));
                    if (drC.Length == 0)
                    {
                        txtOrderDept.Text = "";
                    }
                    else
                    {
                        txtOrderDept.Tag = Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_UNIT"]);

                        txtOrderDept.Text = drC[0]["UNIT_UID"].ToString() + ":" + drC[0]["UNIT_NAME"].ToString();
                    }
                }
                catch { txtOrderDept.Text = ""; }
                try
                {
                    DataRow[] drD = RISBaseData.His_Doctor().Select("EMP_ID=" + Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_DOC"]));
                    if (drD.Length == 0)
                    {
                        txtOrderDoc.Tag = null;
                        txtOrderDoc.Text = "";

                    }
                    else
                    {
                        txtOrderDoc.Tag = Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_DOC"]);
                        txtOrderDoc.Text = drD[0]["EMP_UID"].ToString() + ":" + drD[0]["FNAME"].ToString() + " " + drD[0]["LNAME"].ToString();
                    }
                }
                catch { txtOrderDoc.Text = ""; }

                #region Insurance

                HIS_Patient p = new HIS_Patient();
                DataSet ds = p.GetEligibilityInsuranceDetail(txtHN.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                txtInsurance.Tag = null;
                txtInsurance.Text = string.Empty;
                DataTable dtI = RISBaseData.Ris_InsuranceType();
                if (Utilities.IsHaveData(ds))
                {
                    DataRow[] drIn = dtI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["insurance"].ToString() + "'");
                    if (drIn.Length == 0)
                    {
                        Patient pat = new Patient(txtHN.Text);
                    }
                    DataTable dtSI = RISBaseData.Ris_InsuranceType();
                    DataRow[] drSI = dtSI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["insurance"].ToString() + "'");
                    txtInsurance.Tag = Convert.ToInt32(drSI[0]["INSURANCE_TYPE_ID"].ToString());
                    txtInsurance.Text = drSI[0]["INSURANCE_TYPE_DESC"].ToString();
                }
                else
                {
                    DataRow[] drIn = dtI.Select("INSURANCE_TYPE_UID='UNK'");
                    txtInsurance.Tag = Convert.ToInt32(drIn[0]["INSURANCE_TYPE_ID"].ToString());
                    txtInsurance.Text = drIn[0]["INSURANCE_TYPE_DESC"].ToString();
                }
                #endregion

                if (string.IsNullOrEmpty(dr["PREPARATION_ID"].ToString()))
                {
                    txtPrepation.Tag = 0;
                    txtPrepation.Text = "";
                }
                else
                {
                    LookUpSelect lvS = new LookUpSelect();
                    DataRow[] drPre = lvS.ScheduleNotParameter("Prepation").Tables[0].Select("PREPARATION_ID=" + dr["PREPARATION_ID"].ToString());
                    txtPrepation.Tag = Convert.ToInt32(dr["PREPARATION_ID"].ToString());
                    txtPrepation.Text = drPre[0]["PREPARATION_DESC"].ToString();
                }

            }
        }
        private void SetGrid()
        {
            view.Columns["SCHEDULE_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["SCHEDULE_ID"].Visible = false;
            view.Columns["SCHEDULE_ID"].OptionsColumn.AllowEdit = false;
            //view.Columns["SCHEDULE_ID"].Caption = "Exam Date";
            view.Columns["SCHEDULE_ID"].OptionsColumn.ReadOnly = true;

            view.Columns["REG_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["REG_ID"].Visible = false;
            view.Columns["REG_ID"].OptionsColumn.AllowEdit = false;
            //view.Columns["REG_ID"].Caption = "Exam Date";
            view.Columns["REG_ID"].OptionsColumn.ReadOnly = true;

            view.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["HN"].Visible = false;
            view.Columns["HN"].OptionsColumn.AllowEdit = false;
            //view.Columns["HN"].Caption = "Exam Date";
            view.Columns["HN"].OptionsColumn.ReadOnly = true;

            view.Columns["RAD_ID"].Visible = false;


            view.Columns["NameThai"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["NameThai"].Visible = false;
            view.Columns["NameThai"].OptionsColumn.AllowEdit = false;
            //view.Columns["NameThai"].Caption = "Exam Date";
            view.Columns["NameThai"].OptionsColumn.ReadOnly = true;

            view.Columns["NameEng"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["NameEng"].Visible = false;
            view.Columns["NameEng"].OptionsColumn.AllowEdit = false;
            //view.Columns["NameEng"].Caption = "Exam Date";
            view.Columns["NameEng"].OptionsColumn.ReadOnly = true;

            view.Columns["EXAM_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["EXAM_ID"].Visible = false;
            view.Columns["EXAM_ID"].OptionsColumn.AllowEdit = false;
            view.Columns["EXAM_ID"].Caption = "Exam ID";
            view.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;

            view.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["EXAM_UID"].Visible = true;
            view.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;
            view.Columns["EXAM_UID"].Caption = "Exam Code";
            view.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;

            view.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["EXAM_NAME"].Visible = true;
            view.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
            view.Columns["EXAM_NAME"].Caption = "Exam Name";
            view.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

            view.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["RATE"].Visible = true;
            view.Columns["RATE"].OptionsColumn.AllowEdit = false;
            view.Columns["RATE"].Caption = "Rate";
            view.Columns["RATE"].OptionsColumn.ReadOnly = true;

            view.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["QTY"].Visible = true;
            view.Columns["QTY"].OptionsColumn.AllowEdit = false;
            view.Columns["QTY"].Caption = "QTY";
            view.Columns["QTY"].OptionsColumn.ReadOnly = true;

            view.Columns["SCHEDULE_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["SCHEDULE_DT"].Visible = true;
            view.Columns["SCHEDULE_DT"].OptionsColumn.AllowEdit = false;
            view.Columns["SCHEDULE_DT"].Caption = "Appoint Time";
            view.Columns["SCHEDULE_DT"].OptionsColumn.ReadOnly = true;

            view.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["MODALITY_NAME"].Visible = false;
            view.Columns["MODALITY_NAME"].OptionsColumn.AllowEdit = false;
            //view.Columns["MODALITY_NAME"].Caption = "Appoint Time";
            view.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = true;

            view.Columns["PAT_STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["PAT_STATUS"].Visible = false;
            view.Columns["PAT_STATUS"].OptionsColumn.AllowEdit = false;
            //view.Columns["PAT_STATUS"].Caption = "Appoint Time";
            view.Columns["PAT_STATUS"].OptionsColumn.ReadOnly = true;

            view.Columns["MODALITY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["MODALITY_ID"].Visible = true;
            view.Columns["MODALITY_ID"].OptionsColumn.AllowEdit = false;
            view.Columns["MODALITY_ID"].Caption = "Modality";
            view.Columns["MODALITY_ID"].OptionsColumn.ReadOnly = true;

            DataTable dtMo = RISBaseData.Ris_Modality();
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdLMo = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            grdLMo.DataSource = dtMo;
            //grdLMo.NullText = "";
            grdLMo.ValueMember = "MODALITY_ID";
            grdLMo.DisplayMember = "MODALITY_NAME";
            #region SetGridMo in Grid
            grdLMo.View.OptionsView.ShowAutoFilterRow = true;

            grdLMo.View.Columns["MODALITY_ID"].Visible = false;
            grdLMo.View.Columns["MODALITY_UID"].Visible = false;
            grdLMo.View.Columns["MODALITY_NAME"].Visible = true;
            grdLMo.View.Columns["ROOM_UID"].Visible = false;
            grdLMo.View.Columns["MODALITY_TYPE"].Visible = false;


            grdLMo.View.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdLMo.View.Columns["MODALITY_NAME"].Caption = "MODALITY";
            #endregion

            view.Columns["MODALITY_ID"].ColumnEdit = grdLMo;


            view.Columns["SCHEDULE_STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["SCHEDULE_STATUS"].Visible = false;
            view.Columns["SCHEDULE_STATUS"].OptionsColumn.AllowEdit = false;
            //view.Columns["SCHEDULE_STATUS"].Caption = "Modality";
            view.Columns["SCHEDULE_STATUS"].OptionsColumn.ReadOnly = true;

            view.Columns["PREPARATION_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["PREPARATION_ID"].Visible = false;
            view.Columns["PREPARATION_ID"].OptionsColumn.AllowEdit = false;
            view.Columns["PREPARATION_ID"].OptionsColumn.ReadOnly = true;

            view.Columns["GEN_DTL_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["GEN_DTL_ID"].Visible = false;
            view.Columns["GEN_DTL_ID"].OptionsColumn.AllowEdit = false;
            //view.Columns["GEN_DTL_ID"].Caption = "Appoint Time";
            view.Columns["GEN_DTL_ID"].OptionsColumn.ReadOnly = true;

            view.Columns["Check"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["Check"].Visible = false;
            view.Columns["Check"].OptionsColumn.AllowEdit = false;
            //view.Columns["Check"].Caption = "Modality";
            view.Columns["Check"].OptionsColumn.ReadOnly = true;

            view.Columns["FNAMETH"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["FNAMETH"].Visible = false;
            view.Columns["FNAMETH"].OptionsColumn.AllowEdit = false;
            //view.Columns["FNAMETH"].Caption = "Modality";
            view.Columns["FNAMETH"].OptionsColumn.ReadOnly = true;

            view.Columns["LNAMETH"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["LNAMETH"].Visible = false;
            view.Columns["LNAMETH"].OptionsColumn.AllowEdit = false;
            //view.Columns["LNAMETH"].Caption = "Modality";
            view.Columns["LNAMETH"].OptionsColumn.ReadOnly = true;

            view.Columns["FNAMEENG"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["FNAMEENG"].Visible = false;
            view.Columns["FNAMEENG"].OptionsColumn.AllowEdit = false;
            //view.Columns["FNAMEENG"].Caption = "Modality";
            view.Columns["FNAMEENG"].OptionsColumn.ReadOnly = true;

            view.Columns["LNAMEENG"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["LNAMEENG"].Visible = false;
            view.Columns["LNAMEENG"].OptionsColumn.AllowEdit = false;
            //view.Columns["LNAMEENG"].Caption = "Modality";
            view.Columns["LNAMEENG"].OptionsColumn.ReadOnly = true;

            view.Columns["CLINIC_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["CLINIC_TYPE"].Visible = true;
            view.Columns["CLINIC_TYPE"].OptionsColumn.AllowEdit = false;
            view.Columns["CLINIC_TYPE"].Caption = "Clinic";
            view.Columns["CLINIC_TYPE"].OptionsColumn.ReadOnly = true;

            view.Columns["COMMENTS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["COMMENTS"].Visible = false;
            view.Columns["COMMENTS"].OptionsColumn.AllowEdit = false;
            view.Columns["COMMENTS"].Caption = "Clinic";
            view.Columns["COMMENTS"].OptionsColumn.ReadOnly = true;

        }
        private void SaveData()
        {
            DataTable dt = (DataTable)grdControl.DataSource;
            DataRow dr = dsCreateOrder.Tables[0].Rows[0];
            thisOrder = new Order();
            Patient p = new Patient(txtHN.Text,true);
            Order ord = new Order();
            ord.Demographic = p;

            LookUpSelect lvS = new LookUpSelect();
            DataTable dtG = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0];
            #region DataTemp
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("SCHEDULE_DT", typeof(DateTime));
            dtTemp.Columns.Add("QTY", typeof(int));
            dtTemp.Columns.Add("RAD_ID", typeof(int));
            dtTemp.Columns.Add("MODALITY_ID", typeof(int));
            dtTemp.Columns.Add("EXAM_ID", typeof(int));
            dtTemp.Columns.Add("RATE", typeof(decimal));
            dtTemp.Columns.Add("CLINIC_TYPE", typeof(int));
            dtTemp.Columns.Add("COMMENTS", typeof(string));
            dtTemp.Columns.Add("PREPARATION_ID", typeof(int));
            dtTemp.Columns.Add("GEN_DTL_ID", typeof(int));
            dtTemp.Columns.Add("BPVIEW_ID", typeof(int));
            dtTemp.AcceptChanges();
            #endregion
            for (int i = 0; i < dsCreateOrder.Tables[1].Rows.Count; i++)
            {
                #region checkComments
                string comments = "";
                if (string.IsNullOrEmpty(dt.Rows[i]["GEN_DTL_ID"].ToString()))
                    comments = "";
                else
                {
                    DataRow[] drCom = dtG.Select("GEN_DTL_ID=" + Convert.ToInt32(dt.Rows[i]["GEN_DTL_ID"].ToString()));
                    if (drCom.Length > 0)
                        comments = drCom[0]["GEN_TITLE"].ToString();
                    else
                        comments = "";
                }
                #endregion
                if (txtPrepation.Tag == null)
                    txtPrepation.Tag = 0;
                DataRow drTemp = dtTemp.NewRow();
                drTemp["SCHEDULE_DT"] = dsCreateOrder.Tables[0].Rows[0]["SCHEDULE_DT"];
                drTemp["QTY"] = dt.Rows[i]["QTY"];
                drTemp["RAD_ID"] = dsCreateOrder.Tables[1].Rows[i]["EMP_ID"];
                drTemp["MODALITY_ID"] = dsCreateOrder.Tables[0].Rows[0]["MODALITY_ID"];
                drTemp["EXAM_ID"] = dsCreateOrder.Tables[1].Rows[i]["EXAM_ID"];
                drTemp["RATE"] = dt.Rows[i]["RATE"];
                drTemp["CLINIC_TYPE"] = dsCreateOrder.Tables[0].Rows[0]["CLINIC_TYPE_ID"];
                drTemp["COMMENTS"] = comments;
                drTemp["PREPARATION_ID"] = Convert.ToInt32(txtPrepation.Tag);
                drTemp["GEN_DTL_ID"] = dt.Rows[i]["GEN_DTL_ID"];
                drTemp["BPVIEW_ID"] = dsCreateOrder.Tables[1].Rows[i]["BPVIEW_ID"];
                dtTemp.Rows.Add(drTemp);
                dtTemp.AcceptChanges();
            }
            ord.Item.ORDER_ID = -1;
            ord.Item.HN = txtHN.Text;
            ord.Item.ORG_ID = 1;
            ord.Item.PAT_STATUS = dr["PAT_STATUS"].ToString();
            ord.Item.REASON = dr["REASON"].ToString();
            if (txtOrderDept.Text.Trim().Length > 0)
                ord.Item.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag);
            if (txtOrderDoc.Text.Trim().Length > 0)
                ord.Item.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag);
            ord.Item.REF_DOC_INSTRUCTION = this.thisOrder.Item.REF_DOC_INSTRUCTION;
            ord.Item.CLINICAL_INSTRUCTION = this.thisOrder.Item.CLINICAL_INSTRUCTION;
            if (txtInsurance.Text.Trim().Length > 0)
                ord.Item.INSURANCE_TYPE_ID = Convert.ToInt32(txtInsurance.Tag);
            ord.Item.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
            //ord.Item.VISIT_NO = dr["VISIT_NO"].ToString();
            ord.Item.ORG_ID = env.OrgID;
            ord.Item.ORDER_DT = DateTime.Now;
            ord.Item.ORDER_START_TIME = DateTime.Now;
            ord.Item.CREATED_BY = env.UserID;
            ord.ItemDetail = dtTemp;
            ord.Invoke();


            orderID = ord.Item.ORDER_ID;
            DataRow drUp = dtShare.Rows[0];
            ProcessUpdateRISSchedule processUpdate = new ProcessUpdateRISSchedule();
            processUpdate.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(drUp["SCHEDULE_ID"]);
            processUpdate.RIS_SCHEDULE.SCHEDULE_STATUS = Convert.ToChar("O");  // dr["SCHEDULE_STATUS"].ToString();
            processUpdate.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag);
            processUpdate.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag);
            processUpdate.RIS_SCHEDULE.CREATED_BY = new GBLEnvVariable().UserID;
            processUpdate.Invoke();
            foreach (DataRow drSchDtl in dtTemp.Rows)
            {
                ProcessUpdateRISScheduledtl processUpDTL = new ProcessUpdateRISScheduledtl();
                processUpDTL.RIS_SCHEDULEDTL.SCHEDULE_ID = Convert.ToInt32(drUp["SCHEDULE_ID"]);
                processUpDTL.RIS_SCHEDULEDTL.OLD_EXAM_ID = Convert.ToInt32(drSchDtl["EXAM_ID"]);
                processUpDTL.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drSchDtl["EXAM_ID"]);
                processUpDTL.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(drSchDtl["QTY"]);
                processUpDTL.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drSchDtl["RATE"]);
                if (string.IsNullOrEmpty(drSchDtl["GEN_DTL_ID"].ToString()))
                    processUpDTL.RIS_SCHEDULEDTL.GEN_DTL_ID = 0;
                else
                    processUpDTL.RIS_SCHEDULEDTL.GEN_DTL_ID = Convert.ToInt32(drSchDtl["GEN_DTL_ID"]);
                
                processUpDTL.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drSchDtl["RAD_ID"].ToString()) ? 0 : Convert.ToInt32(drSchDtl["RAD_ID"]);
                processUpDTL.RIS_SCHEDULEDTL.PREPARATION_ID = Convert.ToInt32(drSchDtl["PREPARATION_ID"]);
                processUpDTL.RIS_SCHEDULEDTL.LAST_MODIFIED_BY = env.UserID;
                processUpDTL.Invoke();
            }
            ProcessUpdateRISOrderimages UpIM = new ProcessUpdateRISOrderimages();
            ProcessGetRISOrderimages GeIm = new ProcessGetRISOrderimages();
            GeIm.RIS_ORDERIMAGE.SCHEDULE_ID = Convert.ToInt32(drUp["SCHEDULE_ID"]);
            GeIm.Invoke();
            DataTable dtGeIM = GeIm.Result.Tables[0];
            foreach (DataRow drIM in dtGeIM.Rows)
            {
                if (drIM["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
                {
                    UpIM.RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(drIM["ORDER_IMAGE_ID"]);
                    UpIM.RIS_ORDERIMAGE.ORDER_ID = orderID;
                    UpIM.RIS_ORDERIMAGE.LAST_MODIFIED_BY = env.UserID;
                    UpIM.UpdateOrder();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtOrderDept.Text == string.Empty)
            //{
            //    txtOrderDept.Enabled = true;
            //    txtOrderDept.BackColor = Color.White;
            //    txtOrderDept.Focus();

            //    return;
            //}
            //if (txtOrderDoc.Text  == string.Empty)
            //{
            //    txtOrderDoc.Enabled = true;
            //    txtOrderDoc.BackColor = Color.White;
            //    txtOrderDoc.Focus();
            //    return;
            //}
            //if (txtInsurance.Text == string.Empty)
            //{
            //    txtInsurance.Enabled = true;
            //    txtInsurance.BackColor = Color.White;
            //    txtInsurance.Focus();
            //    return;
            //}
            SaveData();
            this.Close();
        }
        private void btnSaveprint_Click(object sender, EventArgs e)
        {
            //if (txtOrderDept.Text == string.Empty)
            //{
            //    txtOrderDept.Enabled = true;
            //    txtOrderDept.BackColor = Color.White;
            //    txtOrderDept.Focus();

            //    return;
            //}
            //if (txtOrderDoc.Text == string.Empty)
            //{
            //    txtOrderDoc.Enabled = true;
            //    txtOrderDoc.BackColor = Color.White;
            //    txtOrderDoc.Focus();
            //    return;
            //}
            //if (txtInsurance.Text == string.Empty)
            //{
            //    txtInsurance.Enabled = true;
            //    txtInsurance.BackColor = Color.White;
            //    txtInsurance.Focus();
            //    return;
            //}
            SaveData();
            insertDataBySendToPrint();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string genHhManual()
        {
            //return RIS.BusinessLogic.GlobalBaseData.GenHN();
            return Order.GenHN();
        }
        private bool insertDataBySendToPrint()
        {
            bool flag = true;
            orderManger = new OrderManager();
            try
            {
                DataTable dt = (DataTable)grdControl.DataSource;
                ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                geExam.Invoke();
                DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dt.Rows[0]["EXAM_UID"].ToString() + "'");
                if (string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderID, env.UserID, numberOfCopy);
                }
                else if (drExam[0]["UNIT_ID"].ToString() == "2")
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrintAIMC(orderID, env.UserID, numberOfCopy);
                }
                else
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderID, env.UserID, numberOfCopy);
                }



                //orderManger.RemoveAt(0);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }

        #region Lookup Data.
        private void btnOrderDept_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void find_UnitCode(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderDept.Tag = retValue[0];
            txtOrderDept.Text = retValue[1] + ":" + retValue[2];
        }

        private void btnOrderDoc_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtOrderDoc.Tag = retValue[0];
            txtOrderDoc.Text = retValue[2];

        }

        private void btnInsurance_Click(object sender, EventArgs e)
        {
            //HIS_Patient p = new HIS_Patient();
            //DataSet ds = p.GetInsurance(txtHN.Text);

            //DataTable dtI = GlobalBaseData.Ris_InsuranceType();
            //DataRow[] drIn = dtI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["policy_no"].ToString() + "'");
            //if (drIn.Length == 0)
            //{
            //    Patient pat = new Patient(txtHN.Text);
            //}
            DataTable dtSI = RISBaseData.Ris_InsuranceType();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Insurance);
            lv.AddColumn("INSURANCE_TYPE_ID", "ID", false, true);
            lv.AddColumn("INSURANCE_TYPE_UID", "Insurance Code", true, true);
            lv.AddColumn("INSURANCE_TYPE_DESC", "Insurance Name", true, true);
            lv.Text = "Insurance Search";

            lv.Data = dtSI;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Insurance(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInsurance.Tag = retValue[0];
            txtInsurance.Text = retValue[1] + ":" + retValue[2];
        }

        private void btnPrepation_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(btnPrepation_Clicks);
            lv.AddColumn("PREPARATION_ID", "ID", true, true);
            lv.AddColumn("PREPARATION_UID", "ID", false, true);
            lv.AddColumn("PREPARATION_DESC", "Prepation", true, true);
            lv.Text = "Prepation Search";

            lv.Data = lvS.ScheduleNotParameter("Prepation").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnPrepation_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPrepation.Tag = Convert.ToInt32(retValue[0]);
            txtPrepation.Text = retValue[2];
        }

        private void btnLabData_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        LookupData lv = new LookupData();
                        lv.ValueUpdated += new ValueUpdatedEventHandler(Lab_Clicks);
                        lv.Text = "Lab Detail List";

                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.PreviewFieldName = "report";
                        lv.SortFieldName = "lab_date";
                        lv.ShowDescription = true;
                        lv.ShowBox();
                    }
                }
            }
            catch { msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID); }
        }
        private void Lab_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
        }

        private void btnPatientAllergy_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_Adr(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        LookupData lv = new LookupData();
                        lv.ValueUpdated += new ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                    else
                        msg.ShowAlert("UID1129", env.CurrentLanguageID);
                }
            }
            catch { msg.ShowAlert("UID1129", env.CurrentLanguageID); }
        }
        private void Adr_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {

        }
        #endregion

        private void normalRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = view.GetDataRow(view.FocusedRowHandle);

            if (dr != null)
                if (!string.IsNullOrEmpty(dr["GEN_DTL_ID"].ToString()))
                {
                    if (Convert.ToInt32(dr["GEN_DTL_ID"]) > 0)
                    {
                        ProcessGetRISExam getExam = new ProcessGetRISExam();
                        getExam.Invoke();
                        DataTable dtExam = getExam.Result.Tables[0];

                        DataRow[] rows = dtExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());

                        if (rows != null)
                        {
                            decimal total = 0.0M;
                            decimal taxTemp = rows[0]["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(rows[0]["RATE"]);
                            int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);
                            total = taxTemp * qty;

                            dr["RATE"] = total;
                            dr["GEN_DTL_ID"] = 0;
                        }
                    }
                }
        }
        private void freeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(projectLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";
            lv.Data = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void projectLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            DataRow dr = view.GetDataRow(view.FocusedRowHandle);
            dr["GEN_DTL_ID"] = retValue[0];
            dr["RATE"] = retValue[2];
            dr["COMMENTS"] = retValue[1];
            //calTotal();
        }

        private void calTotal()
        {
            //decimal total = 0.0M;
            //ProcessGetRISExam getExam = new ProcessGetRISExam();
            //getExam.Invoke();
            //DataTable dtExam = getExam.Result.Tables[0];
            //DataRow drr = view.GetDataRow(view.FocusedRowHandle);


            //decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
            //int qty = drr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(drr["QTY"]);
            //total = taxTemp * qty;
            //dr["TOTAL"] = total;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (view.FocusedRowHandle > -1)
            {
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) { e.Cancel = true; return; }
                if (row["EXAM_UID"].ToString().Trim() == string.Empty) { e.Cancel = true; return; }
                e.Cancel = false;
                string setRate = row["GEN_DTL_ID"].ToString().Trim();
                int gen_id = setRate == string.Empty ? 0 : Convert.ToInt32(setRate);
                if (gen_id > 0)
                {
                    normalRateToolStripMenuItem.Image = null;
                    freeRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                }
                else
                {
                    normalRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                    freeRateToolStripMenuItem.Image = null;
                }
            }
            else
                e.Cancel = true;
        }
    }
}