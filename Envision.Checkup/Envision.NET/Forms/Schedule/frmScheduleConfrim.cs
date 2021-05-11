using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Operational.HL7.OrderManagement;
using RIS.Operational.PACS;
using RIS.Operational.ReportManager;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace RIS.Forms.Schedule
{
    public partial class frmScheduleConfrim : Form
    {
        private DataTable dtShare;
        private DataSet dsCreateOrder;
        private order thisOrder;
        private OrderManager orderManger;
        private int scheduleID,orderID;
        private int[] langid;
        private string defaultlangs;

        GBLEnvVariable env = new GBLEnvVariable();
        RIS.Forms.GBLMessage.MyMessageBox msg = new RIS.Forms.GBLMessage.MyMessageBox();
        public frmScheduleConfrim()
        {
            InitializeComponent();
        }
        public frmScheduleConfrim(DataRow dr)
        {
            InitializeComponent();
            dtShare = new DataTable();
           
            DataRow row = dr;//dr[0];
            foreach (DataColumn col in row.Table.Columns)
                dtShare.Columns.Add(col.ColumnName);
            dtShare.NewRow();
            dtShare.Rows.Add(dr.ItemArray);
            dtShare.AcceptChanges();
            //foreach (DataRow rows in dr)
            //{
            //    dtShare.Rows.Add(rows.ItemArray);
            //}
            btnSave.Focus();
            BindData();
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
                    DataRow[] drC = order.His_Department().Select("UNIT_ID = " + Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_UNIT"]));
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
                    DataRow[] drD = order.His_Doctor().Select("EMP_ID=" + Convert.ToInt32(dsCreateOrder.Tables[0].Rows[0]["REF_DOC"]));
                    if (drD.Length == 0)
                    {
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
                DataSet ds = null;//p.Get_insurance_detail(txtHN.Text);

                DataTable dtI = order.Ris_InsuranceType();
                DataRow[] drIn = dtI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["policy_no"].ToString() + "'");
                if (drIn.Length == 0)
                {
                    Patient pat = new Patient(txtHN.Text);
                }
                DataTable dtSI = order.Ris_InsuranceType();
                DataRow[] drSI = dtSI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["policy_no"].ToString() + "'");
                txtInsurance.Tag = Convert.ToInt32(drSI[0]["INSURANCE_TYPE_ID"].ToString());
                txtInsurance.Text = drSI[0]["INSURANCE_TYPE_DESC"].ToString();
                #endregion
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

            view.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["QTY"].Visible = true;
            view.Columns["QTY"].OptionsColumn.AllowEdit = false;
            view.Columns["QTY"].Caption = "QTY";
            view.Columns["QTY"].OptionsColumn.ReadOnly = true;

            view.Columns["APPOINT_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["APPOINT_DT"].Visible = true;
            view.Columns["APPOINT_DT"].OptionsColumn.AllowEdit = false;
            view.Columns["APPOINT_DT"].Caption = "Appoint Time";
            view.Columns["APPOINT_DT"].OptionsColumn.ReadOnly = true;

            view.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["MODALITY_NAME"].Visible = false;
            view.Columns["MODALITY_NAME"].OptionsColumn.AllowEdit = false;
            //view.Columns["MODALITY_NAME"].Caption = "Appoint Time";
            view.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = true;

            view.Columns["pat_status"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["pat_status"].Visible = false;
            view.Columns["pat_status"].OptionsColumn.AllowEdit = false;
            //view.Columns["pat_status"].Caption = "Appoint Time";
            view.Columns["pat_status"].OptionsColumn.ReadOnly = true;

            view.Columns["MODALITY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns["MODALITY_ID"].Visible = true;
            view.Columns["MODALITY_ID"].OptionsColumn.AllowEdit = false;
            view.Columns["MODALITY_ID"].Caption = "Modality";
            view.Columns["MODALITY_ID"].OptionsColumn.ReadOnly = true;

            DataTable dtMo = order.Ris_Modality();
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

        }
        private void SaveData()
        {
            DataTable dt = (DataTable)grdControl.DataSource;
            DataRow dr = dsCreateOrder.Tables[0].Rows[0];
            thisOrder = new order();
            Patient p = new Patient(txtHN.Text);
            order ord = new order();
            ord.Demographic = p;

            ord.Item.ORDER_ID = -1;
            ord.Item.HN = txtHN.Text;
            ord.Item.ORG_ID = 1;
            ord.Item.PAT_STATUS = dr["PAT_STATUS"].ToString();
            ord.Item.REASON = dr["REASON"].ToString();
            ord.Item.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag);//Convert.ToInt32(dr["REF_UNIT"]);
            ord.Item.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag);//Convert.ToInt32(dr["REF_DOC"]);
            ord.Item.REF_DOC_INSTRUCTION = this.thisOrder.Item.REF_DOC_INSTRUCTION;
            ord.Item.CLINICAL_INSTRUCTION = this.thisOrder.Item.CLINICAL_INSTRUCTION;
            ord.Item.INSURANCE_TYPE_ID = Convert.ToInt32(txtInsurance.Tag);
            ord.Item.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
            ord.Item.VISIT_NO = dr["VISIT_NO"].ToString();
            ord.Item.ORG_ID = env.OrgID;
            ord.Item.ORDER_DT = DateTime.Now;
            ord.Item.ORDER_START_TIME = DateTime.Now;
            ord.Item.CREATED_BY = env.UserID;

            ord.ItemDetail = dsCreateOrder.Tables[0];
            ord.Invoke();


            orderID = ord.Item.ORDER_ID;
            DataRow drUp = dtShare.Rows[0];
            ProcessUpdateRISSchedule processUpdate = new ProcessUpdateRISSchedule();
            processUpdate.RISSchedule.SCHEDULE_ID = Convert.ToInt32(drUp["SCHEDULE_ID"]);
            processUpdate.RISSchedule.SCHEDULE_STATUS = "O";  // dr["SCHEDULE_STATUS"].ToString();
            processUpdate.RISSchedule.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag);
            processUpdate.RISSchedule.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag);
            processUpdate.RISSchedule.CREATED_BY = new GBLEnvVariable().UserID;
            processUpdate.Invoke();


            ProcessUpdateRISOrderimages UpIM = new ProcessUpdateRISOrderimages();
            ProcessGetRISOrderimages GeIm = new ProcessGetRISOrderimages();
            GeIm.RISOrderimages.SCHEDULE_ID = Convert.ToInt32(drUp["SCHEDULE_ID"]);
            GeIm.Invoke();
            DataTable dtGeIM = GeIm.Result.Tables[0];
            foreach (DataRow drIM in dtGeIM.Rows)
            {
                if (drIM["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
                {
                    UpIM.RISOrderimages.ORDER_IMAGE_ID = Convert.ToInt32(drIM["ORDER_IMAGE_ID"]);
                    UpIM.RISOrderimages.ORDER_ID = orderID;
                    UpIM.RISOrderimages.LAST_MODIFIED_BY = env.UserID;
                    UpIM.UpdateOrder();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOrderDept.Text == string.Empty)
            {
                txtOrderDept.Enabled = true;
                txtOrderDept.BackColor = Color.White;
                txtOrderDept.Focus();
                
                return;
            }
            if (txtOrderDoc.Text  == string.Empty)
            {
                txtOrderDoc.Enabled = true;
                txtOrderDoc.BackColor = Color.White;
                txtOrderDoc.Focus();
                return;
            }
            if (txtInsurance.Text == string.Empty)
            {
                txtInsurance.Enabled = true;
                txtInsurance.BackColor = Color.White;
                txtInsurance.Focus();
                return;
            }
            SaveData();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveprint_Click(object sender, EventArgs e)
        {
                if (txtOrderDept.Text == string.Empty)
                {
                    txtOrderDept.Enabled = true;
                    txtOrderDept.BackColor = Color.White;
                    txtOrderDept.Focus();

                    return;
                }
                if (txtOrderDoc.Text == string.Empty)
                {
                    txtOrderDoc.Enabled = true;
                    txtOrderDoc.BackColor = Color.White;
                    txtOrderDoc.Focus();
                    return;
                }
                if (txtInsurance.Text == string.Empty)
                {
                    txtInsurance.Enabled = true;
                    txtInsurance.BackColor = Color.White;
                    txtInsurance.Focus();
                    return;
                }
            SaveData();
            insertDataBySendToPrint();
            this.Close();
        }
        private string genHhManual()
        {
            //return RIS.BusinessLogic.Order.GenHN();
            return order.GenHN();
        }
        private bool insertDataBySendToPrint()
        {
            bool flag = true;
            orderManger = new OrderManager();
            try
            {

                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderID, env.UserID, numberOfCopy);

                    //orderManger.RemoveAt(0);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
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

        private void btnOrderDept_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void find_UnitCode(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
                txtOrderDept.Tag = retValue[0];
                txtOrderDept.Text = retValue[1] + ":" + retValue[2];
        }

        private void btnOrderDoc_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
            //setTextBoxAutoComplete();
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtOrderDoc.Tag = retValue[0];
            txtOrderDoc.Text = retValue[2];
            //txtOrderPhysician.Tag = retValue[0];
            ////txtOrderDepartment.Text = retValue[0];
            //txtOrderPhysician.Text = retValue[2];
            //view1.Focus();
            //if (view1.RowCount > 0)
            //{
            //    view1.FocusedRowHandle = view1.RowCount - 1;
            //    DevExpress.XtraGrid.Columns.GridColumn focusColumn = view1.Columns["EXAM_UID"];
            //    view1.FocusedColumn = focusColumn;
            //}

        }

        private void btnInsurance_Click(object sender, EventArgs e)
        {
            HIS_Patient p = new HIS_Patient();
            DataSet ds = null;// p.Get_insurance_detail(txtHN.Text);

            DataTable dtI = order.Ris_InsuranceType();
            DataRow[] drIn = dtI.Select("INSURANCE_TYPE_UID='" + ds.Tables[0].Rows[0]["policy_no"].ToString() + "'");
            if (drIn.Length == 0)
            {
                Patient pat = new Patient(txtHN.Text);
            }
            DataTable dtSI = order.Ris_InsuranceType();

            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Insurance);
            lv.AddColumn("INSURANCE_TYPE_ID", "ID", false, true);
            lv.AddColumn("INSURANCE_TYPE_UID", "Insurance Code", true, true);
            lv.AddColumn("INSURANCE_TYPE_DESC", "Insurance Name", true, true);
            lv.Text = "Insurance Search";

            lv.Data = dtSI;
            lv.Size = new Size(600, 400);
            lv.ShowBox();


        }
        private void find_Insurance(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInsurance.Tag = retValue[0];
            txtInsurance.Text = retValue[1]+":"+ retValue[2];
        }

    }
}