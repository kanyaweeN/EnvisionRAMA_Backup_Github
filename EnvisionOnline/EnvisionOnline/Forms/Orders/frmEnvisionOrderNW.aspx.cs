using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessUpdate;

public partial class frmEnvisionOrderNW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
        if (!IsPostBack)
        {
            recieveSession();
            CheckForm();
            BindingPatientData();
            BindingDataOnNewOrder();
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            switch (param.QUICKEXAM_MODE)
            {
                case "REF_DOC":
                    addExamDetail("AddExamAll", param.QUICKEXAM_ID);
                    cmbRefDoc.OpenDropDownOnLoad = true;
                    break;
                case "SCHEDULE":
                case "WAITING":
                    addExamDetail("AddExamAll", param.QUICKEXAM_ID);
                    break;
            }
        }
        if (cmbRefDoc.Text.Length > 0)
            cmbRefDoc.OpenDropDownOnLoad = false;
    }
    #region Header tab
    private void recieveSession()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> fullpath = new List<string>();
        List<string> fullpath2 = new List<string>();
        param.TEMP_CLINICALINDICATION = fullpath;
        param.TEMP_CLINICALINDICATIONTYPE = fullpath2;

        Session["GBLEnvVariable"] = env;
        Session["ONL_PARAMETER"] = param;
    }
    private void CheckForm()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        rtbMainNW.Visible = true;
        rtoolPatient.Visible = true;
        //switch (param.FORM)
        //{
        //    case "O1":
        //        //rtbMainNW.Visible = true;
        //        rtoolPatient.Visible = true;
        //        break;
        //    case "O2":
        //        //rtbMainNW.Visible = false;
        //        rtoolPatient.Visible = false;
        //        break;
        //    case "R1":
        //rtbMainNW.Visible = true;
        //rtoolPatient.Visible = false;
        //        break;
        //    case "R2":
        //        //rtbMainNW.Visible = false;
        //        rtoolPatient.Visible = false;
        //        break;
        //    case "A1":
        //        //rtbMainNW.Visible = true;
        //        rtoolPatient.Visible = true;
        //        break;
        //}
    }
    private void BindingPatientData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        #region Load Control Patient
        Label lblHN = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblHN");
        Label lblPatientName = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblPatientName");
        Label lblGender = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblGender");
        Label lblAge = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblAge");
        Label lblDOB = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblDOB");
        Label lblPhone = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblPhone");
        Label lblNonResident = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblNonResident");
        #endregion

        PatientClass getPatient = new PatientClass();

        string _hn = param.HN;
        DataSet ds = param.dsPatientData;// getPatient.get_Patient_Registration_ByHN(_hn, env);

        lblEmployeeName.Text = param.EmpName;
        lblHN.Text = _hn;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            param.REG_ID = Convert.ToInt32(dr["REG_ID"]);
            lblPatientName.Text = dr["TITLE"].ToString() + dr["FNAME"].ToString() + " " + dr["LNAME"].ToString();
            switch (dr["GENDER"].ToString())
            {
                case "M": lblGender.Text = "Male"; break;
                case "F": lblGender.Text = "Female"; break;
                default: lblGender.Text = "Other"; break;
            }

            lblAge.Text = dr["AGE2"].ToString();
            try
            {
                lblDOB.Text = Utilities.ToStringDatetimeTH("d MMM yyyy", Convert.ToDateTime(dr["DOB"]));
                //int index = lblAge.Text.IndexOf(' ');
                //string resultAge = lblAge.Text.Substring(0, index + 1);
                //param.IS_CHILDEN = Convert.ToInt32(resultAge) <= 15 ? true : false;
                param.IS_CHILDEN = (DateTime.Now.Year - Convert.ToDateTime(dr["DOB"]).Year) <= 15 ? true : false; 
            }
            catch (Exception ex)
            {
                param.IS_CHILDEN = true;
            }
            lblPhone.Text = dr["PHONE1"].ToString();
        }
        lblNonResident.Text = param.IS_NONRESIDENT ? "Non-Resident" : "";
        //Session["ONL_PARAMETER"] = param;
    }
    protected void btnLogout_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("../../Logout.aspx");
    }
    #endregion
    #region Ribbon
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        if (e.Item.Value == "btnWorklist")
            setPageMain();
        else if (e.Item.Value == "btnSaveNewOrder")
            checkParameterInsert();
        else if (e.Item.Value == "btnClearAll")
        {
            DataTable dtDtl = param.dvGridDtl;
            bool flag = true;
            foreach (DataRow dr in dtDtl.Rows)
                if (Convert.ToInt32(dr["ORDER_ID"]) != 0)
                    flag = false;
            if (flag)
                setClearData();
        }
    }
    private void setClearData()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dtDtl = param.dvGridDtl;
        if (dtDtl != null)
        {
            DataTable dt = new DataTable();
            dt = dtDtl.Clone();
            param.dvGridDtl = dt;
            fillDataGrid_Filter(grdDetail, dt);
        }

        DataTable dtt = new DataTable();
        fillDataGrid_Filter(grdAppointment, set_NullAppointData(dtt, "Regular", "W"));
        fillDataGrid_Filter(grdAppointmentSP, set_NullAppointData(dtt, "Special", "W"));
        fillDataGrid_Filter(grdAppointmentPM, set_NullAppointData(dtt, "Premium", "W"));
        fillDataGrid_Filter(grdAppointmentCNMI, set_NullAppointData(dtt, "CNMI", "W"));

        cmbRadiologistAppoint.Text = "";

        txtEditor.Text = "";
        treeIndicationView.UncheckAllNodes();
        List<string> list = param.TEMP_CLINICALINDICATION;
        List<string> list2 = param.TEMP_CLINICALINDICATIONTYPE;
        if (list != null)
            list.Clear();
        if (list2 != null)
            list2.Clear();

        Session["ONL_PARAMETER"] = param;
    }
    private void setPageMain()
    {
        updateBusy();
        Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderWL.aspx");
    }
    private DataTable setOrderTemplate()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dtTemp = new DataTable();
        dtTemp.Columns.Add("REG_ID");
        dtTemp.Columns.Add("FULLNAME_PAT");
        dtTemp.Columns.Add("FULLNAME");
        dtTemp.Columns.Add("INSURANCE_TYPE_ID");
        dtTemp.Columns.Add("REF_UNIT_ID");
        dtTemp.Columns.Add("REF_UNIT_UID");
        dtTemp.Columns.Add("REF_DOC_ID");
        dtTemp.Columns.Add("REF_DOC_UID");
        dtTemp.Columns.Add("REF_DOCNAME");
        dtTemp.Columns.Add("REF_DOC_FNAME");
        dtTemp.Columns.Add("REF_DOC_LNAME");
        dtTemp.Columns.Add("CLINIC_TYPE_ID");
        dtTemp.Columns.Add("txtEditor");
        dtTemp.Columns.Add("PAT_STATUS");
        dtTemp.Columns.Add("ENC_CLINIC");
        dtTemp.Columns.Add("ENC_TYPE");
        dtTemp.Columns.Add("ENC_ID");
        dtTemp.Columns.Add("IS_TELEMED");
        dtTemp.Columns.Add("IS_ALERT_CLINICAL_INSTRUCTION");
        dtTemp.Columns.Add("CLINICAL_INSTRUCTION_TAG");
        dtTemp.AcceptChanges();

        Label lblPatientName = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblPatientName");
        DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
        DataTable dtDept = Application["UnitData"] as DataTable;
        RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
        string cmbPatientStatus = "Walk";

        int lastIndex = cmbRefDoc.Text.LastIndexOf(":") + 1;
        int lengthDoc = cmbRefDoc.Text.Length - lastIndex;
        DataRow[] rowsDoc = dtHisDoc.Select("RadioName='" + cmbRefDoc.Text.Substring(lastIndex, lengthDoc) + "'");
        DataRow[] rowsUnit = dtDept.Select("UNIT_DESC='" + cmbRefUnit.Text + "'");
        DataTable dtPat = (DataTable)Application["PatientStatusData"];
        DataRow[] rowsPat = dtPat.Select("STATUS_TEXT='" + cmbPatientStatus + "'");
        DataRow addRow = dtTemp.NewRow();

        string IS_ALERT_CLINICA = null;
        string CLINICAL_INSTRUCTION_TAG = null;
        try
        {
            List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
            DataTable dtCItype = param.dtCLINICALINDICATIONTYPE;

            foreach (string str in data)
            {
                DataRow[] rowCItype = dtCItype.Select("CI_DESC='" + str.Trim() + "'");
                if (!string.IsNullOrEmpty(rowCItype[0]["CI_TAG"].ToString()))
                {
                    IS_ALERT_CLINICA = "Y";
                    if (CLINICAL_INSTRUCTION_TAG == null)
                        CLINICAL_INSTRUCTION_TAG = rowCItype[0]["CI_TAG"].ToString();
                    else
                        CLINICAL_INSTRUCTION_TAG += "," + rowCItype[0]["CI_TAG"].ToString();
                }
            }
        }
        catch { }

        addRow["REG_ID"] = param.REG_ID;
        addRow["FULLNAME_PAT"] = lblPatientName.Text;
        addRow["FULLNAME"] = lblEmployeeName.Text;
        addRow["INSURANCE_TYPE_ID"] = param.INSURANCE_TYPE_ID;
        addRow["REF_UNIT_ID"] = rowsUnit[0]["UNIT_ID"].ToString();//param.REF_UNIT_ID;
        addRow["REF_UNIT_UID"] = rowsUnit[0]["UNIT_UID"].ToString();
        addRow["REF_DOC_ID"] = rowsDoc[0]["EMP_ID"].ToString();
        addRow["REF_DOC_UID"] = rowsDoc[0]["EMP_UID"].ToString();
        addRow["REF_DOCNAME"] = rowsDoc[0]["RadioName"].ToString();
        addRow["REF_DOC_FNAME"] = rowsDoc[0]["FNAME"].ToString();
        addRow["REF_DOC_LNAME"] = rowsDoc[0]["LNAME"].ToString();
        addRow["CLINIC_TYPE_ID"] = param.CLINIC_TYPE_ID;
        addRow["txtEditor"] = txtEditor.Text;
        addRow["PAT_STATUS"] = rowsPat[0]["STATUS_ID"].ToString();
        addRow["ENC_CLINIC"] = param.ENC_CLINIC;
        addRow["ENC_TYPE"] = param.ENCOUNTER_TYPE;
        addRow["ENC_ID"] = param.ENC_ID;
        addRow["IS_TELEMED"] = param.IS_TELEMED ? "Y" : "N";
        addRow["IS_ALERT_CLINICAL_INSTRUCTION"] = IS_ALERT_CLINICA;
        addRow["CLINICAL_INSTRUCTION_TAG"] = CLINICAL_INSTRUCTION_TAG;

        dtTemp.Rows.Add(addRow);
        dtTemp.AcceptChanges();

        return dtTemp;
    }
    private void setInsertOrder(DataTable dt)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        OrderClass order = new OrderClass();
        DataTable dtTemp = setOrderTemplate();
        DataTable dtDelete = param.dvGridDtl_Remove;
        int ord_id = 0;
        DataSet ds = new DataSet();
        DateTime dateCompare = DateTime.Now;
        DataView dv = dt.DefaultView;
        dv.Sort = "EXAM_DT";
        DataTable dtt = dv.ToTable();
        DataTable dtSeparate = dt.Clone();
        dtSeparate.TableName = "SEP_0";
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            if (i == 0)
            {
                dateCompare = Convert.ToDateTime(dtt.Rows[i]["EXAM_DT"]);
                dtSeparate.Rows.Add(dtt.Rows[i].ItemArray);
            }
            else
                if (dateCompare.Date.CompareTo(Convert.ToDateTime(dtt.Rows[i]["EXAM_DT"]).Date) == 0)
                    dtSeparate.Rows.Add(dtt.Rows[i].ItemArray);
                else
                {
                    ds.Tables.Add(dtSeparate.Copy());
                    ds.AcceptChanges();
                    dateCompare = Convert.ToDateTime(dtt.Rows[i]["EXAM_DT"]);
                    dtSeparate = new DataTable();
                    dtSeparate = dt.Clone();
                    dtSeparate.TableName = "SEP_" + i.ToString();
                    dtSeparate.Rows.Add(dtt.Rows[i].ItemArray);
                }
        }
        ds.Tables.Add(dtSeparate.Copy());
        ds.AcceptChanges();
        for (int y = 0; y < ds.Tables.Count; y++)
        {
            ord_id = order.check_ONLOrder(ds.Tables[y], dtTemp, dtDelete, env);//chkData ? order.set_ONLOrder_Insert(dt, dtTemp, env) : order.set_ONLOrder_Update(dt, dtTemp, dtDelete, env);

            List<string> list = param.TEMP_CLINICALINDICATION;
            order.set_RIS_ORDERCLINICALINDICATION(list, ord_id, true, env);
            order.set_RIS_ORDERCLINICALINDICATION(list, ord_id, false, env);

            List<string> list2 = param.TEMP_CLINICALINDICATIONTYPE;
            order.set_RIS_ORDERCLINICALINDICATIONTYPE(list2, ord_id, true, env);
            order.set_RIS_ORDERCLINICALINDICATIONTYPE(list2, ord_id, false, env);

            DataTable dtRisk = Session["dataRISK"] as DataTable;
            if (Utilities.IsHaveData(dtRisk))
                order.set_RiskManagement(ord_id, dtRisk);
        }
    }
    private void setInsertSchedule(DataTable dt)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        ScheduleClass schedule = new ScheduleClass();
        DataTable dtTemp = setOrderTemplate();
        DataTable dtDelete = param.dvGridDtl_Remove;

        List<int> listSch = schedule.check_ONLSchedule(dt, dtTemp, dtDelete, env) as List<int>;//chkData ? schedule.set_ONLSchedule_Insert(dt, dtTemp, env) : schedule.set_ONLSchedule_Update(dt, dtTemp, dtDelete, env);
        foreach (int schedule_id in listSch)
        {
            List<string> list = param.TEMP_CLINICALINDICATION;
            schedule.set_RIS_ORDERCLINICALINDICATION(list, schedule_id, true, env);
            schedule.set_RIS_ORDERCLINICALINDICATION(list, schedule_id, false, env);

            List<string> list2 = param.TEMP_CLINICALINDICATIONTYPE;
            schedule.set_RIS_ORDERCLINICALINDICATIONTYPE(list2, schedule_id, true, env);
            schedule.set_RIS_ORDERCLINICALINDICATIONTYPE(list2, schedule_id, false, env);

            DataTable dtRisk = Session["dataRISK"] as DataTable;
            if (Utilities.IsHaveData(dtRisk))
                schedule.set_RiskManagement(schedule_id, dtRisk);

            DataRow[] drcreatinine = Session["creatinine"] as DataRow[];
            if (Utilities.IsHaveData(drcreatinine))
                setInsertCreatinine(0, schedule_id, drcreatinine);
        }
    }
    private void setInsertScheduleToCNMI(DataTable dt)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        ScheduleClass schedule = new ScheduleClass();
        DataTable dtTemp = setOrderTemplate();
        DataTable dtDelete = param.dvGridDtl_Remove;
        DataTable dtPatient = param.dsPatientData.Tables[0].Copy();

        List<int> listSch = schedule.check_ONLSchedule_ToCNMI(dt, dtTemp, dtDelete, env, dtPatient) as List<int>;
    }
    private void setInsertOnline()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        DataTable dt = param.dvGridDtl;
        DataTable dtTemp = setOrderTemplate();
        if (dt == null)
            return;
        DataTable dtDirectOrder = new DataTable(); dtDirectOrder = dt.Clone();
        DataTable dtNormalOrder = new DataTable(); dtNormalOrder = dt.Clone();
        foreach (DataRow row in dt.Rows)
        {
            ProcessGetONLDirectlyOrder chkDirect = new ProcessGetONLDirectlyOrder(
                Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"]),
                Convert.ToInt32(row["CLINIC_TYPE"]),
                Convert.ToInt32(row["EXAM_ID"]));
            chkDirect.Invoke();
            if (chkDirect.Result.Tables[0].Rows.Count == 0)
            {
                dtNormalOrder.ImportRow(row);
            }
            else
            {
                dtDirectOrder.ImportRow(row);
            }
            dtDirectOrder.AcceptChanges();
            dtNormalOrder.AcceptChanges();
        }
        if (Utilities.IsHaveData(dtDirectOrder))
        {
            dt = dtDirectOrder.Copy();
            #region Insert Directly Order
            DataTable dtDelete = param.dvGridDtl_Remove;

            OrderClass order = new OrderClass();
            int order_id = 0;
            foreach (DataRow drChkOrderID in dt.Rows)
            {
                if (!string.IsNullOrEmpty(drChkOrderID["ORDER_ID"].ToString()))
                    order_id = Convert.ToInt32(drChkOrderID["ORDER_ID"]) > 0 ? Convert.ToInt32(drChkOrderID["ORDER_ID"]) : order_id;
                if (order_id > 0)
                    break;
            }

            if (order_id > 0)
            {
                #region Check Delete Order
                foreach (DataRow drDel in dtDelete.Rows)
                {
                    ProcessDeleteRISOrderDtl del = new ProcessDeleteRISOrderDtl();
                    del.RIS_ORDERDTL.ORDER_ID = order_id;
                    del.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(drDel["EXAM_ID"]);
                    del.Invoke();
                }
                #endregion

                order.set_ONLDirectlyOrder_Update(order_id, dt, dtTemp, env);
            }
            else
                order.set_ONLDirectlyOrder_Insert(dt, dtTemp, env);
            #endregion
        }
        if (Utilities.IsHaveData(dtNormalOrder))
        {
            dt = dtNormalOrder.Copy();
            #region Normal Online

            DataTable dtPanel = Application["ExamPanel"] as DataTable;

            DataTable dtOrd = new DataTable(); dtOrd = dt.Clone();
            DataTable dtOrd2 = new DataTable(); dtOrd2 = dt.Clone();
            DataTable dtSch = new DataTable(); dtSch = dt.Clone();

            #region Check Rate Before Save
            DataTable dtAllExam = Application["ExamAllData"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int _clinicType = string.IsNullOrEmpty(dt.Rows[i]["CLINIC_TYPE"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i]["CLINIC_TYPE"]);
                DataRow[] rowsExam = dtAllExam.Select("EXAM_ID = " + dt.Rows[i]["EXAM_ID"].ToString());
                string rate = checkExamRate(rowsExam[0], _clinicType, param.IS_NONRESIDENT);
                dt.Rows[i]["RATE"] = rate;
                dt.Rows[i]["TOTAL_RATE"] = rate;
                dt.AcceptChanges();
            }
            #endregion

            #region Separate Request
            while (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["SCHEDULE_FLAG"]))
                {
                    //if (dt.Rows[0]["PRIORITY"].ToString() == "R" || dt.Rows[0]["PRIORITY"].ToString() == "U")
                    //{
                    DataRow[] rowPanel;
                    DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dt.Rows[0]["EXAM_ID"].ToString());
                    if (chkPanel.Length > 0)
                    {
                        rowPanel = dt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                        if (rowPanel.Length > 0)
                        {
                            dtSch.Rows.Add(rowPanel[0].ItemArray);
                            dt.Rows.Remove(rowPanel[0]);
                            dt.AcceptChanges();
                        }
                    }
                    dtSch.Rows.Add(dt.Rows[0].ItemArray);
                    dt.Rows.Remove(dt.Rows[0]);
                    dt.AcceptChanges();

                    foreach (DataRow rowSch in dtSch.Rows)
                    {
                        if (rowSch["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
                            if (rowSch["PRIORITY"].ToString() == "S")
                                rowSch["STATUS"] = "V";
                            else
                                rowSch["STATUS"] = "W";
                        else
                        {
                            rowSch["STATUS"] = "S";
                        }
                    }
                    //}
                    //else
                    //{
                    //    dtOrd2.Rows.Add(dt.Rows[0].ItemArray);
                    //    dt.Rows.Remove(dt.Rows[0]);
                    //    dt.AcceptChanges();
                    //}
                }
                else
                {
                    dtOrd.Rows.Add(dt.Rows[0].ItemArray);
                    dt.Rows.Remove(dt.Rows[0]);
                    dt.AcceptChanges();
                }

                dtSch.AcceptChanges();
                dtOrd.AcceptChanges();
                dtOrd2.AcceptChanges();

                
            }
            #endregion

            if (Utilities.IsHaveData(dtOrd))
                setInsertOrder(dtOrd);
            if (Utilities.IsHaveData(dtOrd2))
                setInsertOrder(dtOrd2);
            if (Utilities.IsHaveData(dtSch))
            {
                setInsertSchedule(dtSch);

                #region set data CNMI
                //try
                //{
                //    DataTable dtSchCNMI = new DataTable(); dtSchCNMI = dt.Clone();

                //    foreach (DataRow rowSch in dtSch.Rows)
                //    {
                //        DataTable drModalityCNMI = new DataTable();
                //        RISBaseClass risbase = new RISBaseClass();
                //        DataTable drModality = risbase.get_Ris_Modality().Copy();
                //        drModalityCNMI = risbase.get_Ris_ModalityCNMI().Copy();

                //        if (rowSch["STATUS"].ToString() == "S")
                //        {
                //            DataRow[] modality = drModality.Select("MODALITY_ID=" + Convert.ToInt16(rowSch["MODALITY_ID"].ToString()));
                //            if (modality[0]["LABEL"].ToString().ToLower() == "cnmi" || modality[0]["PAT_DEST_ID"].ToString().ToLower() == "10")
                //            {
                //                DataRow[] modalitycnmi = drModalityCNMI.Select("TYPE_NAME='" + modality[0]["TYPE_NAME"].ToString() + "'");
                //                if (modalitycnmi.Length > 0)
                //                {
                //                    DataRow rowCNIM = dtSchCNMI.NewRow();
                //                    rowCNIM.ItemArray = rowSch.ItemArray;
                //                    rowCNIM["MODALITY_ID"] = modalitycnmi[0]["MODALITY_ID"].ToString();
                //                    dtSchCNMI.Rows.Add(rowCNIM);
                //                }
                //            }
                //        }
                //    }
                //    dtSchCNMI.AcceptChanges();
                //    if (Utilities.IsHaveData(dtSchCNMI))
                //        setInsertScheduleToCNMI(dtSchCNMI);
                //}
                //catch (Exception ex) { }
                #endregion
            }

            #endregion
        }
    }
    private void setInsertCreatinine(int ord_id, int schedule_id, DataRow[] rows)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        try
        {
            ProcessGetCreatinine labcreatinine = new ProcessGetCreatinine();
            labcreatinine.RIS_LABCREATININE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
            labcreatinine.Invoke();
            DataTable dtLabcreatinine = labcreatinine.Result;
            foreach (DataRow row in rows)
            {
                RIS_LABCREATININE RIS_LABCREATININE = new RIS_LABCREATININE();
                if (Utilities.IsHaveData(dtLabcreatinine))
                {
                    DataRow[] rowcreatinine = dtLabcreatinine.Select("SHORT_TEST= '" + row["shortTest"].ToString() + "'");
                    ProcessGetCreatinine creatinine = new ProcessGetCreatinine();
                    if (Utilities.IsHaveData(rowcreatinine))
                    {
                        RIS_LABCREATININE.LAB_CREATININE_ID = Convert.ToInt32(rowcreatinine[0]["LAB_CREATININE_ID"].ToString());
                        RIS_LABCREATININE.REG_ID = param.REG_ID;
                        RIS_LABCREATININE.ORDER_ID = Convert.ToInt32(ord_id);
                        RIS_LABCREATININE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
                        RIS_LABCREATININE.HIS_RQ_ID = Convert.ToInt32(row["rq_id"].ToString());
                        RIS_LABCREATININE.MRN = row["mrn"].ToString();
                        RIS_LABCREATININE.SDLOC = row["sdloc"].ToString();
                        RIS_LABCREATININE.PRODUCT_ID = row["productId"].ToString();
                        RIS_LABCREATININE.PERFORM_UNIT = row["performUnit"].ToString();
                        RIS_LABCREATININE.COD_TEST = row["codTest"].ToString();
                        RIS_LABCREATININE.SHORT_TEST = row["shortTest"].ToString();
                        RIS_LABCREATININE.RESULT_VALUE = row["resultValue"].ToString();
                        RIS_LABCREATININE.UNIT = row["unit"].ToString();
                        RIS_LABCREATININE.RANGE = row["range"].ToString();
                        RIS_LABCREATININE.OBSERV_DATETIME = Convert.ToDateTime(row["observDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                        RIS_LABCREATININE.REPORT_DATETIME = Convert.ToDateTime(row["reportDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                        RIS_LABCREATININE.ORG_ID = env.OrgID;
                        RIS_LABCREATININE.LAST_MODIFIED_BY = env.UserID;
                        creatinine.RIS_LABCREATININE = RIS_LABCREATININE;
                        creatinine.updateCreatinine();
                    }
                    else
                    {
                        RIS_LABCREATININE.REG_ID = param.REG_ID;
                        RIS_LABCREATININE.ORDER_ID = Convert.ToInt32(ord_id);
                        RIS_LABCREATININE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
                        RIS_LABCREATININE.HIS_RQ_ID = Convert.ToInt32(row["rq_id"].ToString());
                        RIS_LABCREATININE.MRN = row["mrn"].ToString();
                        RIS_LABCREATININE.SDLOC = row["sdloc"].ToString();
                        RIS_LABCREATININE.PRODUCT_ID = row["productId"].ToString();
                        RIS_LABCREATININE.PERFORM_UNIT = row["performUnit"].ToString();
                        RIS_LABCREATININE.COD_TEST = row["codTest"].ToString();
                        RIS_LABCREATININE.SHORT_TEST = row["shortTest"].ToString();
                        RIS_LABCREATININE.RESULT_VALUE = row["resultValue"].ToString();
                        RIS_LABCREATININE.UNIT = row["unit"].ToString();
                        RIS_LABCREATININE.RANGE = row["range"].ToString();
                        RIS_LABCREATININE.OBSERV_DATETIME = Convert.ToDateTime(row["observDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                        RIS_LABCREATININE.REPORT_DATETIME = Convert.ToDateTime(row["reportDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                        RIS_LABCREATININE.ORG_ID = env.OrgID;
                        RIS_LABCREATININE.CREATED_BY = env.UserID;
                        creatinine.RIS_LABCREATININE = RIS_LABCREATININE;
                        creatinine.insertCreatinine();
                    }
                }
                else
                {
                    ProcessGetCreatinine creatinine = new ProcessGetCreatinine();
                    RIS_LABCREATININE.REG_ID = param.REG_ID;
                    RIS_LABCREATININE.ORDER_ID = Convert.ToInt32(ord_id);
                    RIS_LABCREATININE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
                    RIS_LABCREATININE.HIS_RQ_ID = Convert.ToInt32(row["rq_id"].ToString());
                    RIS_LABCREATININE.MRN = row["mrn"].ToString();
                    RIS_LABCREATININE.SDLOC = row["sdloc"].ToString();
                    RIS_LABCREATININE.PRODUCT_ID = row["productId"].ToString();
                    RIS_LABCREATININE.PERFORM_UNIT = row["performUnit"].ToString();
                    RIS_LABCREATININE.COD_TEST = row["codTest"].ToString();
                    RIS_LABCREATININE.SHORT_TEST = row["shortTest"].ToString();
                    RIS_LABCREATININE.RESULT_VALUE = row["resultValue"].ToString();
                    RIS_LABCREATININE.UNIT = row["unit"].ToString();
                    RIS_LABCREATININE.RANGE = row["range"].ToString();
                    RIS_LABCREATININE.OBSERV_DATETIME = Convert.ToDateTime(row["observDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                    RIS_LABCREATININE.REPORT_DATETIME = Convert.ToDateTime(row["reportDateTime"].ToString(), CultureInfo.GetCultureInfo("en-EN").DateTimeFormat);
                    RIS_LABCREATININE.ORG_ID = env.OrgID;
                    RIS_LABCREATININE.CREATED_BY = env.UserID;
                    creatinine.RIS_LABCREATININE = RIS_LABCREATININE;
                    creatinine.insertCreatinine();
                }
            }
        }
        catch { }
    }
    private bool checkParameterInsert()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        bool flag = true;
        DataTable dt = param.dvGridDtl;
        RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;

        if (string.IsNullOrEmpty(cmbRefDoc.Text))
        {
            flag = false;
            showOnlineMessageBox("checkRefDoc");
        }
        if (string.IsNullOrEmpty(cmbRefUnit.Text) || cmbRefUnit.Text.LastIndexOf('*') > 0)
        {
            flag = false;
            showOnlineMessageBox("checkRefUnit");
        }
        if (string.IsNullOrEmpty(txtEditor.Text.Trim()))
        {
            flag = false;
            showOnlineMessageBox("checkIndication");
        }

        foreach (DataRow drr in dt.Rows)
        {
            if (drr["strEXAM_DT"].ToString() == "Pending.." && drr["PRIORITY"].ToString() != "S")
            {
                flag = false;
                showOnlineMessageBox("checkAppointCase");
                break;
            }
            if (drr["BPVIEW_NAME"].ToString() == "" && drr["NEED_SIDE"].ToString() == "Y")
            {
                flag = false;
                showOnlineMessageBox("checkBPView");
                break;
            }
        }

        if (flag)
            flag = checkParameterInsert_Holiday();

        if (flag)
            flag = checkParameterInsert_Covid();
        return flag;
    }
    private bool checkParameterInsert_Holiday()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        bool flag = true;
        DataTable dt = param.dvGridDtl;

        ProcessGetHoliday checkHoliday = new ProcessGetHoliday();
        DataTable dtholiday = checkHoliday.get().Tables[0];

        if (dtholiday.Rows.Count > 0)
        {
            foreach (DataRow drholiday in dtholiday.Rows)
            {
                DateTime holiday = new DateTime(DateTime.Now.Year, Convert.ToDateTime(drholiday["DATE"].ToString()).Month, Convert.ToDateTime(drholiday["DATE"].ToString()).Day, 0, 0, 0);
                foreach (DataRow drr in dt.Rows)
                {
                    if (drr["strEXAM_DT"].ToString().IndexOf("Pending") < 0 || drr["strEXAM_DT"].ToString().IndexOf("Waiting") < 0)
                    {
                        DateTime examdt = new DateTime(DateTime.Now.Year, Convert.ToDateTime(drr["EXAM_DT"].ToString()).Month, Convert.ToDateTime(drr["EXAM_DT"].ToString()).Day, 0, 0, 0);
                        if (holiday == examdt)
                        {
                            flag = false;
                            showOnlineMessageBox("Holiday");
                            break;
                        }
                    }
                }
                if (!flag)
                    break;
            }
        }

        return flag;
    }
    private bool checkParameterInsert_Covid()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        param.REF_DOC_INSTRUCTION = txtEditor.Text;
        bool flag = true;

        ProcessGetHRUnit getCovidUnit = new ProcessGetHRUnit();
        DataSet ds = getCovidUnit.checkCovidUnit(param.REF_UNIT_ID);

        if (ds.Tables[0].Rows.Count > 0)
            showCovid();
        else
            checkParameterInsert_MRPC();

        return flag;
    }
    private bool checkParameterInsert_MRPC()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        param.REF_DOC_INSTRUCTION = txtEditor.Text;
        bool flag = true;

        DataRow[] rowChk = param.dvGridDtl.Select("EXAM_UID = 'XM113'");

        if (rowChk.Length > 0)
            showClinicalIndicationWithParameter("MRPC");
        else
            checkParameterInsert_RiskManagement();

        return flag;
    }
    private bool checkParameterInsert_RiskManagement()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        bool flag = true;
        DataTable dt = param.dvGridDtl;

        foreach (DataRow rowsCheckRisk in dt.Rows)
        {
            ProcessGetRISExam chkExam = new ProcessGetRISExam();
            String risk_mode = chkExam.GetExamtypeRiskManagement(Convert.ToInt32(rowsCheckRisk["EXAM_ID"]));
            if (risk_mode == "MRI")
            {
                flag = false;
                showRiskManagement("tabMRI");
                break;
            }
            else if (risk_mode == "CT")
            {
                flag = false;
                showRiskManagement("tabCT");
                break;
            }

        }

        if (flag)
            set_SaveOrder();

        return flag;
    }
    private void set_SaveOrder()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDept = Application["UnitData"] as DataTable;
        RISBaseClass risbase = new RISBaseClass();

        DataTable dt = param.dvGridDtl;

        #region set Time with waitting list
        foreach (DataRow drr in dt.Rows)
        {
            int schedule_id = string.IsNullOrEmpty(drr["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(drr["SCHEDULE_ID"]);
            if (schedule_id == 0)
                if (drr["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
                {
                    DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(drr["EXAM_ID"]), Convert.ToInt32(drr["PAT_DEST_ID"]), SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
                    dtMod_ID = Utilities.filterModalityByClinic(dtMod_ID, param.ENC_CLINIC);
                    if (dtMod_ID.Rows.Count > 0)
                        set_FillWaitingListData(drr, dtMod_ID);
                }
        }
        #endregion
        setInsertOnline();
        setPageMain();
    }
    private void setClearFilterGrid(RadGrid grdClearFilter)
    {
        foreach (GridColumn column in grdClearFilter.MasterTableView.Columns)
        {
            column.CurrentFilterFunction = GridKnownFunction.NoFilter;
            column.CurrentFilterValue = string.Empty;
        }
        grdClearFilter.MasterTableView.FilterExpression = string.Empty;
        grdClearFilter.MasterTableView.Rebind();

    }
    #endregion
    #region Grid New Order
    private void BindingDataOnNewOrder()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        string strorder_id = param.ORDER_ID == null ? "0" : param.ORDER_ID;
        string strschedule_id = param.SCHEDULE_ID == null ? "0" : param.SCHEDULE_ID;
        DataTable dt = param.dvGrid;
        DataRow[] row = dt.Select("ORDER_ID=" + strorder_id +
                                  " AND SCHEDULE_ID = " + strschedule_id);
        DataTable dtFilter = Utilities.arrayRowsToDataTable(dt.Clone(), row);
        dtFilter.Columns.Add("IS_CHOOSED_BPVIEW");
        dtFilter.AcceptChanges();

        BindingControlOnNewOrder();

        foreach (DataRow rows in dtFilter.Rows)
        {
            DataTable dtPanelPortable = new DataTable();
            RISBaseClass baseMange = new RISBaseClass();
            dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(rows["EXAM_ID"]), Convert.ToInt32(rows["CLINIC_TYPE"]));
            foreach (DataRow rowss in dtPanelPortable.Rows)
            {
                DataRow[] chkPortable = dtFilter.Select("EXAM_ID=" + rowss["AUTO_EXAM_ID"].ToString());
                if (chkPortable.Length > 0)
                    rows["IS_PORTABLE_VALUE"] = "Y";
            }

            param.ENC_CLINIC = rows["ENC_CLINIC"].ToString();
            if (rows["STATUS"].ToString() == "W" || rows["STATUS"].ToString() == "V")
                rows["strEXAM_DT"] = "Waiting list";
            else
                rows["strEXAM_DT"] = Convert.ToDateTime(rows["EXAM_DT"]).ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

            rows["IS_CHOOSED_BPVIEW"] = "Y";

            RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
            DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
            DataRow[] rowsDoc = dtHisDoc.Select("EMP_ID=" + rows["REF_DOC"].ToString());
            cmbRefDoc.Text = rowsDoc.Length > 0 ? rowsDoc[0]["EMP_UID"].ToString() + ":" + rowsDoc[0]["RadioName"].ToString() : "";
        }
        dtFilter.AcceptChanges();
        param.dvGridDtl = dtFilter;

        BindingTreeview();

        fillDataGrid_Filter(grdDetail, dtFilter);
        if (dtFilter.Rows.Count > 0)
            txtEditor.Text = dtFilter.Rows[0]["CLINICAL_INSTRUCTION"].ToString();
        Session["ONL_PARAMETER"] = param;
    }
    private void BindingControlOnNewOrder()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseManage = new RISBaseClass();
        DataTable dtPatStatus = (DataTable)Application["PatientStatusData"];

        DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
        DataTable dtInsurance = (DataTable)Application["InsuranceTypeData"];
        DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
        DataTable dtDept = Application["UnitData"] as DataTable;

        //RadComboBox cmbPatientStatus = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbPatientStatus") as RadComboBox;
        RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
        RadTextBox txtInsurance = rtbDemographic.FindItemByValue("groupDemographic").FindControl("txtInsurance") as RadTextBox;
        //RadTextBox txtRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("txtRefUnit") as RadTextBox;
        RadTextBox txtClinicType = rtbDemographic.FindItemByValue("groupDemographic").FindControl("txtClinicType") as RadTextBox;

        //cmbPatientStatus.SelectedValue = param.dvGridDtl.Rows.Count > 0 ? param.dvGridDtl.Rows[0]["PAT_STATUS"].ToString() : "1";

        switch (param.ENC_CLINIC)
        {
            case "RGL": param.CLINIC_TYPE = "Normal"; break;
            case "SPC": param.CLINIC_TYPE = "Special"; break;
            case "PM": param.CLINIC_TYPE = "VIP"; break;
            default: param.CLINIC_TYPE = "Normal"; break;
        }

        string strClinicTypeUID = param.CLINIC_TYPE; //param.dvGridDtl.Rows.Count > 0 ? param.dvGridDtl.Rows[0]["CLINIC_TYPE_UID"].ToString() : param.CLINIC_TYPE;
        DataRow[] rowClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + strClinicTypeUID + "'");
        txtClinicType.Text = rowClinic[0]["CLINIC_TYPE_ONLINEDESC"].ToString();
        param.CLINIC_TYPE_ID = Convert.ToInt32(rowClinic[0]["CLINIC_TYPE_ID"]);

        string strInsuranceTypeUID = param.dvGridDtl.Rows.Count > 0 ? param.dvGridDtl.Rows[0]["INSURANCE_TYPE_UID"].ToString() : param.INSURANCE_TYPE_UID;
        DataRow[] rowIns = dtInsurance.Select("INSURANCE_TYPE_UID='" + strInsuranceTypeUID + "'");
        txtInsurance.Text = rowIns[0]["INSURANCE_TYPE_DESC"].ToString();
        param.INSURANCE_TYPE_ID = Convert.ToInt32(rowIns[0]["INSURANCE_TYPE_ID"]);

        DataRow[] rowRefDoc = dtHisDoc.Select("EMP_ID=" + env.UserID);
        cmbRefDoc.Text = rowRefDoc.Length > 0 ? rowRefDoc[0]["EMP_UID"].ToString() + ":" + rowRefDoc[0]["RadioName"].ToString() : "";


        DataView dv = new DataView();
        DataTable dtt = new DataTable();
        dv = dtDept.DefaultView;
        dv.RowFilter = "UNIT_UID='" + param.REF_UNIT_UID + "'";
        dtt = dv.ToTable();
        if (dtt.Rows.Count > 0)
        {
            cmbRefUnit.Text = dtt.Rows[0]["UNIT_DESC"].ToString();
            param.REF_UNIT_ID = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"]);
        }
        Session["ONL_PARAMETER"] = param;
    }
    protected void cmbRefDoc_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtDoc = (DataTable)Application["HisDoctorData"];
        RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;

        cmbRefDoc.Items.Clear();

        string text = e.Text.Trim();
        DataRow[] rows = dtDoc.Select("EMP_UID+RadioName LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefDoc.Items.Add(new RadComboBoxItem(rows[i]["EMP_UID"].ToString() + ":" + rows[i]["RadioName"].ToString(), rows[i]["EMP_ID"].ToString()));
    }
    protected void cmbRefUnit_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        //if (string.IsNullOrEmpty(e.Text.Trim())) return;
        DataTable dtUnit = (DataTable)Application["UnitData"];
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;

        cmbRefUnit.Items.Clear();

        string text = e.Text.Trim();
        DataRow[] rows = dtUnit.Select("UNIT_DESC LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefUnit.Items.Add(new RadComboBoxItem(rows[i]["UNIT_DESC"].ToString(), rows[i]["UNIT_ID"].ToString()));
    }
    protected void cmbRefUnit_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Text)) return;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDept = Application["UnitData"] as DataTable;
        int regUnit_id = Convert.ToInt32(e.Value);
        DataRow[] rowUnit = dtDept.Select("UNIT_ID=" + regUnit_id.ToString());
        param.REF_UNIT_ID = regUnit_id;
        param.REF_UNIT_UID = rowUnit[0]["UNIT_UID"].ToString();

        RISBaseClass baseManage = new RISBaseClass();
        DataTable dtPatDest = baseManage.get_PAT_DEST_ID(param.REF_UNIT_ID, param.CLINIC_TYPE_ID);
        if (Utilities.IsHaveData(dtPatDest))
        {
            if (dtPatDest.Rows[0]["PAT_DEST_ID"].ToString() == "3")
                param.FlagCTMR = true;

            param.PAT_DEST_ID = Convert.ToInt32(dtPatDest.Rows[0]["PAT_DEST_ID"]);
        }

        Session["ONL_PARAMETER"] = param;
        getClinicalIndicationWithUnit(regUnit_id);
        BindingTreeview();
    }

    protected void grdDetail_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        param.ORDER_ID = "0";
        if (param.dvGridDtl == null)
        {
            DataTable dtt = param.dvGrid;

            param.dvGridDtl = dtt.Clone();

            param.dvGridDtl_Remove = dtt.Clone();
        }
        DataTable dt = param.dvGridDtl;
        fillDataGridDataTable(grdDetail, dt);
        Session["ONL_PARAMETER"] = param;

    }
    protected void grdDetail_ItemCommand(object source, GridCommandEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (e.CommandName == "DeleteColumn")
        {
            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            item.ExtractValues(values);

            DataTable dt = param.dvGridDtl;
            DataTable dtRemove = param.dvGridDtl_Remove;


            #region remove Exam Panel

            DataTable dtPanel = Application["ExamPanel"] as DataTable;
            DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dt.Rows[item.ItemIndex]["EXAM_ID"].ToString());
            foreach (DataRow rows in chkPanel)
            {
                DataRow[] chkRows = dt.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
                if (chkRows.Length > 0)
                {
                    if (chkRows[0]["ORDER_ID"].ToString() != "0"
                        || chkRows[0]["SCHEDULE_ID"].ToString() != "0" && chkRows[0]["SCHEDULE_ID"].ToString().Trim() != "")
                    {
                        if (dtRemove.Columns.Contains("IS_CHOOSED_BPVIEW"))
                            dtRemove.Columns.Add("IS_CHOOSED_BPVIEW");
                        dtRemove.Rows.Add(chkRows[0].ItemArray);
                        dtRemove.AcceptChanges();
                    }
                    dt.Rows.Remove(chkRows[0]);
                }
            }

            #endregion


            ///// CHeck Null Rows == 0 ////////
            if (dt.Rows[item.ItemIndex]["ORDER_ID"].ToString() != "0"
                || dt.Rows[item.ItemIndex]["SCHEDULE_ID"].ToString() != "0" && dt.Rows[item.ItemIndex]["SCHEDULE_ID"].ToString().Trim() != "")
            {
                if (!dtRemove.Columns.Contains("IS_CHOOSED_BPVIEW"))
                    dtRemove.Columns.Add("IS_CHOOSED_BPVIEW");
                dtRemove.Rows.Add(dt.Rows[item.ItemIndex].ItemArray);
                dtRemove.AcceptChanges();
            }
            dt.Rows.RemoveAt(item.ItemIndex);
            dt.AcceptChanges();




            param.dvGridDtl = dt;
            param.dvGridDtl_Remove = dtRemove;

            fillDataGrid_Filter(grdDetail, dt);
            e.ExecuteCommand(values);

            tabExam.Tabs[3].Enabled = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabExamTop10');", true);
        }
    }
    protected void grdDetail_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

            GridDataItem item = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;
            DataTable dt = param.dvGridDtl;

            CheckBox chkbx = (CheckBox)item["CheckBoxTemplateColumn"].FindControl("chkPortable");
            chkbx.Visible = dv.Row["IS_PORTABLE"].ToString() == "Y" ? true : false;
            chkbx.Checked = dv.Row["IS_PORTABLE_VALUE"].ToString() == "Y" ? true : false;

            #region Combobox Priority
            RadComboBox cmbPriority = (RadComboBox)item["cmbtempPriority"].FindControl("cmbPriority");
            cmbPriority.Enabled = dv.Row["IS_PORTABLE_VALUE"].ToString() == "D" ? false : true;

            DataTable dtPriority = new DataTable();
            dtPriority.Columns.Add("PRIORITY_UID");
            dtPriority.Columns.Add("PRIORITY_TEXT");
            dtPriority.AcceptChanges();
            dtPriority.Rows.Add("R", "Routine");
            dtPriority.Rows.Add("S", "Stat");
            dtPriority.Rows.Add("U", "Urgent");
            dtPriority.AcceptChanges();

            foreach (DataRow row in dtPriority.Rows)
            {
                RadComboBoxItem selectedItem = new RadComboBoxItem();
                selectedItem.Text = row["PRIORITY_TEXT"].ToString();
                selectedItem.Value = row["PRIORITY_UID"].ToString();
                selectedItem.Attributes.Add("PRIORITY_TEXT", row["PRIORITY_TEXT"].ToString());
                cmbPriority.Items.Add(selectedItem);
                selectedItem.DataBind();
            }
            cmbPriority.SelectedValue = dv.Row["PRIORITY"].ToString();
            #endregion
            #region Combobox Side

            RadComboBox cmbSide = (RadComboBox)item["cmbtempSide"].FindControl("cmbSide");
            RISBaseClass getBpview = new RISBaseClass();
            DataTable dtBP = getBpview.get_BP_ViewMapping(dv.Row["EXAM_ID"].ToString());
            for (int i = 0; i < dtBP.Rows.Count; i++)
            {
                RadComboBoxItem selectedItem = new RadComboBoxItem();
                selectedItem.Text = dtBP.Rows[i]["BPVIEW_NAME"].ToString();
                selectedItem.Value = dtBP.Rows[i]["BPVIEW_ID"].ToString();
                selectedItem.Attributes.Add("BPVIEW_DESC", dtBP.Rows[i]["BPVIEW_DESC"].ToString());
                cmbSide.Items.Add(selectedItem);
                selectedItem.DataBind();
            }
            cmbSide.Enabled = false;
            if (!string.IsNullOrEmpty(dv.Row["NEED_SIDE"].ToString()))
                if (dv.Row["NEED_SIDE"].ToString() == "Y")
                {
                    cmbSide.Enabled = true;
                    if (dv.Row["IS_CHOOSED_BPVIEW"].ToString() == "N" || dv.Row["IS_CHOOSED_BPVIEW"].ToString().Trim() == "")
                    {
                        if (dtBP.Rows.Count == 0)
                            cmbSide.Enabled = false;
                        else if (dtBP.Rows.Count == 1)
                        {
                            dv.Row["BPVIEW_ID"] = dtBP.Rows[0]["BPVIEW_ID"];
                            dv.Row["BPVIEW_NAME"] = dtBP.Rows[0]["BPVIEW_NAME"];
                            dv.Row["IS_CHOOSED_BPVIEW"] = "Y";

                            DataTable dtAllExam = Application["ExamAllData"] as DataTable;
                            DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + dv.Row["EXAM_ID"].ToString());
                            string _rate = checkExamRate(rowsExam[0], param.ENC_CLINIC, param.IS_NONRESIDENT);
                            double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(dtBP.Rows[0]["NO_OF_EXAM"]);
                            dv.Row["TOTAL_RATE"] = sumrate.ToString("#.00");
                            dv.Row["RATE"] = _rate;
                            dv.Row["QTY"] = Convert.ToDouble(dtBP.Rows[0]["NO_OF_EXAM"]);

                            if (dtBP.Rows[0]["NEED_DETAIL"].ToString() == "Y")
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + rowsExam[0]["EXAM_ID"].ToString() + "');", true);
                        }
                        else
                            cmbSide.OpenDropDownOnLoad = true;
                    }
                    else
                        cmbSide.SelectedValue = dv.Row["BPVIEW_ID"].ToString();
                }
            #endregion
            #region Combobox Clinic
            RadComboBox cmbClinic = (RadComboBox)item["cmbtempClinic"].FindControl("cmbClinic");
            DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
            switch (param.CLINIC_TYPE)
            {
                case "Special":
                    DataView dvClinicSpecial = dtClinicType.DefaultView;
                    dvClinicSpecial.RowFilter = "CLINIC_TYPE_UID in ('Special','VIP') AND CLINIC_TYPE_ID not in (5,8)";
                    DataTable dtTempSpecial = dvClinicSpecial.ToTable();
                    for (int i = 0; i < dtTempSpecial.Rows.Count; i++)
                    {
                        RadComboBoxItem selectedItem = new RadComboBoxItem();
                        selectedItem.Text = dtTempSpecial.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString();
                        selectedItem.Value = dtTempSpecial.Rows[i]["CLINIC_TYPE_ID"].ToString();
                        selectedItem.Attributes.Add("CLINIC_TYPE_ONLINEDESC", dtTempSpecial.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString());
                        cmbClinic.Items.Add(selectedItem);
                        selectedItem.DataBind();
                    }
                    break;
                case "VIP":
                    DataView dvClinicVIP = dtClinicType.DefaultView;
                    dvClinicVIP.RowFilter = "CLINIC_TYPE_UID in ('VIP') AND CLINIC_TYPE_ID not in (5,8)";
                    DataTable dtTempVIP = dvClinicVIP.ToTable();
                    for (int i = 0; i < dtTempVIP.Rows.Count; i++)
                    {
                        RadComboBoxItem selectedItem = new RadComboBoxItem();
                        selectedItem.Text = dtTempVIP.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString();
                        selectedItem.Value = dtTempVIP.Rows[i]["CLINIC_TYPE_ID"].ToString();
                        selectedItem.Attributes.Add("CLINIC_TYPE_ONLINEDESC", dtTempVIP.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString());
                        cmbClinic.Items.Add(selectedItem);
                        selectedItem.DataBind();
                    }
                    break;
                default:
                    DataView dvClinic = dtClinicType.DefaultView;
                    dvClinic.RowFilter = "CLINIC_TYPE_ID not in (5,8)";
                    DataTable dtTemp = dvClinic.ToTable();
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        RadComboBoxItem selectedItem = new RadComboBoxItem();
                        selectedItem.Text = dtTemp.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString();
                        selectedItem.Value = dtTemp.Rows[i]["CLINIC_TYPE_ID"].ToString();
                        selectedItem.Attributes.Add("CLINIC_TYPE_ONLINEDESC", dtTemp.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString());
                        cmbClinic.Items.Add(selectedItem);
                        selectedItem.DataBind();
                    }
                    break;
            }
            if (param.IS_NONRESIDENT)
            {
                DataView dvClinic3 = dtClinicType.DefaultView;
                dvClinic3.RowFilter = "CLINIC_TYPE_ID =9";
                DataTable dtTemp3 = dvClinic3.ToTable();
                for (int i = 0; i < dtTemp3.Rows.Count; i++)
                {
                    RadComboBoxItem selectedItem = new RadComboBoxItem();
                    selectedItem.Text = dtTemp3.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString();
                    selectedItem.Value = dtTemp3.Rows[i]["CLINIC_TYPE_ID"].ToString();
                    selectedItem.Attributes.Add("CLINIC_TYPE_ONLINEDESC", dtTemp3.Rows[i]["CLINIC_TYPE_ONLINEDESC"].ToString());
                    cmbClinic.Items.Clear();
                    cmbClinic.Items.Add(selectedItem);
                    selectedItem.DataBind();
                }
            }


            cmbClinic.SelectedValue = dv.Row["CLINIC_TYPE"].ToString();

            cmbClinic.Enabled = true;

            if (Convert.ToBoolean(dv.Row["SCHEDULE_FLAG"]))//&& dv.Row["PRIORITY"].ToString() != "S")
                cmbClinic.Enabled = false;
            if (param.IS_NONRESIDENT)
                cmbClinic.Enabled = false;
            if (dv.Row["IS_PORTABLE_VALUE"].ToString() == "D")
                cmbClinic.Enabled = false;
            #endregion
        }
    }

    protected void chkPortable_CheckedChanged(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        CheckBox chk = sender as CheckBox;
        DataTable dt = param.dvGridDtl;
        DataTable dtAllExam = new DataTable();
        dtAllExam = Application["ExamAllData"] as DataTable;
        DataRow row = dt.Rows[((sender as CheckBox).NamingContainer as GridItem).DataSetIndex];
        if (chk.Checked)
        {
            row["IS_PORTABLE_VALUE"] = "Y";
            addExamPanelPortable(dtAllExam, row);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabExamTop10');", true);
        }
        else
        {
            row["IS_PORTABLE_VALUE"] = "N";
            removeExamPanelPortable(row);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabExamTop10');", true);
        }
        param.EXAM_ID = row["EXAM_ID"].ToString();

        fillDataGrid_Filter(grdDetail, dt);

    }
    protected void cmbPriority_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Text)) return;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtPanel = Application["ExamPanel"] as DataTable;

        DataRow row = dt.Rows[((source as RadComboBox).NamingContainer as GridItem).DataSetIndex];
        row["PRIORITY"] = e.Value;
        row["PRIORITY_TEXT"] = e.Text;

        foreach (RadTab tabsExam in tabExam.Tabs)
        {
            if (row["PRIORITY"].ToString() == "R" || row["PRIORITY"].ToString() == "U")
                tabsExam.Enabled = true;
            else
                if (tabsExam.Value == "tabAppointment")
                    tabsExam.Enabled = false;
                else
                    tabsExam.Enabled = true;
        }

        if (row["NEED_APPROVE"].ToString() == "Y" || row["NEED_SCHEDULE"].ToString() == "Y") // Appointment Case
        {
            set_RebindDataDetail(row);
        }
        else // Request Case
        {
            row["strEXAM_DT"] = DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
            row["EXAM_DT"] = row["ORDER_DT"];
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabExamTop10');", true);
        }
        if (row["PRIORITY"].ToString() == "S")
            showOnlineMessageBox("checkStat");

        //if (row["PRIORITY"].ToString() == "R" || row["PRIORITY"].ToString() == "U")
        //    if (row["NEED_APPROVE"].ToString() == "Y" || row["NEED_SCHEDULE"].ToString() == "Y")
        //        set_RebindDataDetail(row);
        //    else
        //        row["strEXAM_DT"] = DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
        //else
        //{
        //    row["strEXAM_DT"] = DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
        //    row["EXAM_DT"] = row["ORDER_DT"];
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabExamTop10');", true);
        //    showOnlineMessageBox("checkStat");
        //}

        if (row["IS_PORTABLE_VALUE"].ToString() == "Y")
        {
            DataTable dtPanelPortable = new DataTable();
            RISBaseClass baseMange = new RISBaseClass();
            dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(row["EXAM_ID"]), param.CLINIC_TYPE_ID);
            foreach (DataRow drPortable in dtPanelPortable.Rows)
            {
                DataRow[] arryrows = dt.Select("EXAM_ID=" + drPortable["AUTO_EXAM_ID"].ToString());
                if (arryrows.Length > 0)
                {
                    arryrows[0]["PRIORITY"] = e.Value;
                    arryrows[0]["PRIORITY_TEXT"] = e.Text;
                    arryrows[0]["strEXAM_DT"] = row["strEXAM_DT"];
                }
            }
        }

        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
        if (chkPanel.Length > 0)
        {
            DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
            if (rowFillPanel.Length > 0)
            {
                rowFillPanel[0]["PRIORITY"] = e.Value;
                rowFillPanel[0]["PRIORITY_TEXT"] = e.Text;
                rowFillPanel[0]["strEXAM_DT"] = row["strEXAM_DT"];
            }
        }

        param.dvGridDtl = dt;
        param.EXAM_ID = row["EXAM_ID"].ToString();
        Session["ONL_PARAMETER"] = param;

        fillDataGrid_Filter(grdDetail, dt);

    }
    protected void cmbSide_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Text)) return;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataRow row = dt.Rows[((source as RadComboBox).NamingContainer as GridItem).DataSetIndex];
        row["BPVIEW_ID"] = e.Value;
        row["BPVIEW_NAME"] = e.Text;
        row["IS_CHOOSED_BPVIEW"] = "Y";

        RISBaseClass getBpview = new RISBaseClass();
        DataTable dtBP = getBpview.get_BP_ViewMapping(row["EXAM_ID"].ToString());

        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
        DataRow[] rowbp = dtBP.Select("BPVIEW_ID=" + e.Value);
        string _rate = checkExamRate(rowsExam[0], param.ENC_CLINIC, param.IS_NONRESIDENT);
        double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(rowbp[0]["NO_OF_EXAM"]);
        row["TOTAL_RATE"] = sumrate.ToString("#.00");
        row["RATE"] = _rate;
        row["QTY"] = Convert.ToDouble(rowbp[0]["NO_OF_EXAM"]);


        param.dvGridDtl = dt;
        param.EXAM_ID = row["EXAM_ID"].ToString();

        fillDataGrid_Filter(grdDetail, dt);


        if (rowbp[0]["NEED_DETAIL"].ToString() == "Y")
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + rowsExam[0]["EXAM_ID"].ToString() + "');", true);

    }
    protected void cmbClinic_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Text)) return;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataRow row = dt.Rows[((source as RadComboBox).NamingContainer as GridItem).DataSetIndex];
        row["CLINIC_TYPE"] = e.Value;
        row["CLINIC_TYPE_UID"] = e.Text;

        DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
        DataRow[] rowsClinic = dtClinicType.Select("CLINIC_TYPE_ID=" + e.Value);
        string _rate;
        string _clinic = rowsClinic[0]["CLINIC_TYPE_UID"].ToString();
        switch (_clinic)
        {
            case "Normal": _rate = rowsExam[0]["RATE"].ToString(); break;
            case "Special": _rate = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
            case "VIP": _rate = rowsExam[0]["VIP_RATE"].ToString(); break;
            case "Non-Resident": _rate = rowsExam[0]["FOREIGN_RATE"].ToString(); break;
            default: _rate = rowsExam[0]["RATE"].ToString(); break;
        }
        double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(row["QTY"]);
        row["TOTAL_RATE"] = sumrate.ToString("#.00");
        row["RATE"] = _rate;

        if (row["IS_PORTABLE_VALUE"].ToString() == "Y")
        {
            DataTable dtPanelPortable = new DataTable();
            RISBaseClass baseMange = new RISBaseClass();
            dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(row["EXAM_ID"]));
            if (Utilities.IsHaveData(dtPanelPortable))
            {
                DataRow[] rowClinicPortableSelect = dtPanelPortable.Select("CLINIC_TYPE_ID=" + e.Value);
                if (rowClinicPortableSelect.Length > 0)
                {
                    string _strExamPortAll = "";
                    foreach (DataRow rowExamPortAll in dtPanelPortable.Rows)
                        _strExamPortAll += "," + rowExamPortAll["AUTO_EXAM_ID"].ToString();

                    DataRow[] arryrows = dt.Select("EXAM_ID in (" + _strExamPortAll.Substring(1) + ")");
                    if (arryrows.Length > 0)
                    {
                        foreach (DataRow rowRemove in arryrows)
                            dt.Rows.Remove(rowRemove);

                        addExamPanelPortable(dtAllExam, row);

                        //arryrows[0]["CLINIC_TYPE"] = e.Value;
                        //arryrows[0]["CLINIC_TYPE_UID"] = e.Text;

                        //DataRow[] rowsExamPort = dtAllExam.Select("EXAM_ID=" + rowClinicPortableSelect[0]["AUTO_EXAM_ID"].ToString());
                        //switch (_clinic)
                        //{
                        //    case "Normal": _rate = rowsExamPort[0]["RATE"].ToString(); break;
                        //    case "Special": _rate = rowsExamPort[0]["SPECIAL_RATE"].ToString(); break;
                        //    case "VIP": _rate = rowsExamPort[0]["VIP_RATE"].ToString(); break;
                        //    case "Non-Resident": _rate = rowsExam[0]["FOREIGN_RATE"].ToString(); break;
                        //    default: _rate = rowsExamPort[0]["RATE"].ToString(); break;
                        //}
                        //sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(arryrows[0]["QTY"]);
                        //arryrows[0]["TOTAL_RATE"] = sumrate.ToString("#.00");
                        //arryrows[0]["RATE"] = _rate;
                    }
                }
            }
        }

        param.dvGridDtl = dt;
        param.EXAM_ID = row["EXAM_ID"].ToString();
        fillDataGrid_Filter(grdDetail, dt);

    }

    private void set_RebindDataDetail(DataRow row)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        //if (row["PRIORITY"].ToString() == "R" || row["PRIORITY"].ToString() == "U")
        //{

        if (row["NEED_SCHEDULE"].ToString() == "Y")
            if (row["PRIORITY"].ToString() == "U")
            {
                row["strEXAM_DT"] = "Waiting list";
                addCommentWord("# ขอคิวก่อนพบแพทย์ #", row["EXAM_ID"].ToString());
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + row["EXAM_ID"].ToString() + "');", true);
            }
            else if (row["PRIORITY"].ToString() == "S")
            {
                row["strEXAM_DT"] = "Waiting list";
                addCommentWord("# ขอคิวด่วน #", row["EXAM_ID"].ToString());
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + row["EXAM_ID"].ToString() + "');", true);
            }
            else
            {
                rdoIndicationDate6.Checked = true;
                dtIndicationDate.Enabled = true;
                dtIndicationDate.SelectedDate = DateTime.Now;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabAppointment','" + param.CLINIC_TYPE + "');", true);
            }

        if (row["NEED_APPROVE"].ToString() == "Y")
            row["strEXAM_DT"] = "Waiting list";

        //}

        if (row["strEXAM_DT"].ToString() == "Waiting list" ||
            row["strEXAM_DT"].ToString() == "Pending.." ||
            row["NEED_APPROVE"].ToString() == "Y" ||
            row["NEED_SCHEDULE"].ToString() == "Y")
            row["SCHEDULE_FLAG"] = true;

        if (row["NEED_APPROVE"].ToString() != "Y" &&
           row["NEED_SCHEDULE"].ToString() == "Y")
        {
            switch (param.CLINIC_TYPE)
            {
                case "Normal": tabAppoint.Tabs[0].Enabled = row["PRIORITY"].ToString() == "R" ? true : false;
                    tabAppoint.Tabs[1].Enabled = row["PRIORITY"].ToString() == "R" ? true : false;
                    tabAppoint.Tabs[2].Enabled = row["PRIORITY"].ToString() == "R" ? true : false;
                    tabAppoint.Tabs[0].Selected = true;
                    break;
                case "Special":
                    tabAppoint.Tabs[1].Enabled = row["PRIORITY"].ToString() == "R" ? true : false;
                    tabAppoint.Tabs[1].Selected = true;
                    break;
                case "VIP":
                    tabAppoint.Tabs[2].Enabled = row["PRIORITY"].ToString() == "R" ? true : false;
                    tabAppoint.Tabs[2].Selected = true;
                    break;
            }
            grdAppointment.Enabled = true;
            tabAppoint.Enabled = true;
        }

    }

    protected void grdExamFavorite_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseMange = new RISBaseClass();
        int value = 0;

        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        param.dvExamFavorite = dt;
        fillDataGridDataTable(grdExamFavorite, dt);

    }
    protected void grdExamFavorite_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "AddExam")
        {
            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            item.ExtractValues(values);
            e.ExecuteCommand(values);
            addExamDetail("AddExamFavorite", values["EXAM_ID"].ToString());
        }
        else if (e.CommandName == "RemoveExamFavorite")
        {
            showOnlineMessageBox("RemoveExamFavorite");
            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            Session["HashtableAddFavoriteExam"] = values;
            item.ExtractValues(values);
            e.ExecuteCommand(values);
        }
    }
    protected void grdExamFavorite_RowDrop(object sender, GridDragDropEventArgs e)
    {
        if (string.IsNullOrEmpty(e.HtmlElement))
        {
            if (e.DraggedItems[0].OwnerGridID == grdExamFavorite.ClientID)
            {
                // items are dragged from pending to shipped grid
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == grdExamFavorite.ClientID)
                {
                    GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
                    ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
                    DataTable dtFavorite = param.dvExamFavorite;

                    int _dt_count = dtFavorite.Rows.Count;
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    dt1 = dtFavorite.Clone();
                    dt2 = dtFavorite.Clone();
                    DataRow drr = dtFavorite.Rows[e.DraggedItems[0].ItemIndex];
                    dt2.Rows.Add(drr.ItemArray);
                    dtFavorite.Rows.Remove(drr);
                    int y = 0;
                    for (int i = 0; i < _dt_count; i++)
                    {
                        if (i == e.DestDataItem.ItemIndex)
                            dt1.Rows.Add(dt2.Rows[0].ItemArray);
                        else
                        {
                            dt1.Rows.Add(dtFavorite.Rows[y].ItemArray);
                            y++;
                        }
                    }

                    RISBaseClass updateSlNo = new RISBaseClass();
                    for (int z = 0; z < dt1.Rows.Count; z++)
                    {
                        dt1.Rows[z]["SL_NO"] = z + 1;
                        updateSlNo.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(dt1.Rows[z]["EXAM_ID"]);
                        updateSlNo.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
                        updateSlNo.RIS_EXAMFAVORITE.SL_NO = z + 1;
                        updateSlNo.set_Ris_ExamFavorite_Update();
                    }
                    dt1.AcceptChanges();
                    param.dvExamFavorite = dt1;
                    Session["ONL_PARAMETER"] = param;

                    fillDataGrid_Filter(grdExamFavorite, dt1);

                    int destinationItemIndex = e.DestDataItem.ItemIndex - (grdExamFavorite.PageSize * grdExamFavorite.CurrentPageIndex);
                    e.DestinationTableView.Items[destinationItemIndex].Selected = true;



                }
            }
        }
    }
    private void deleteExamFavorite(Hashtable values)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        RISBaseClass baseDelFavorite = new RISBaseClass();
        baseDelFavorite.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(values["EXAM_ID"]);
        baseDelFavorite.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
        baseDelFavorite.RIS_EXAMFAVORITE.ORG_ID = env.OrgID;
        baseDelFavorite.set_Ris_ExamFavorite_Delete();

        DataTable dt = baseDelFavorite.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, 1, env == null ? 1 : env.OrgID);
        param.dvExamFavorite = dt;
        fillDataGrid_Filter(grdExamFavorite, dt);
        fillDataGrid_Filter(grdExamTop10, param.dvExamTop10);
        Session["ONL_PARAMETER"] = param;
    }
    private void addExamFavorite(Hashtable values)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass baseMange = new RISBaseClass();

        baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(values["EXAM_ID"]);
        baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
        baseMange.RIS_EXAMFAVORITE.SL_NO = 999;
        baseMange.RIS_EXAMFAVORITE.ORG_ID = env.OrgID;
        baseMange.RIS_EXAMFAVORITE.CREATED_BY = env.UserID;
        baseMange.set_Ris_ExamFavorite_Insert();

        int value = 0;
        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        param.dvExamFavorite = dt;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
            baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
            baseMange.RIS_EXAMFAVORITE.SL_NO = i + 1;
            baseMange.set_Ris_ExamFavorite_Update();
        }


        fillDataGrid_Filter(grdExamFavorite, dt);
        fillDataGrid_Filter(grdExamTop10, param.dvExamTop10);
    }

    protected void grdExamTop10_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseMange = new RISBaseClass();
        DataTable dtDept = (DataTable)Application["UnitData"];
        DataRow[] rowRefUnit = dtDept.Select("UNIT_UID='" + param.REF_UNIT_UID + "'");
        param.REF_UNIT_ID = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

        //int lengthDay = 0;
        int value = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

        DataTable dt = baseMange.get_Ris_ModalityExamTop10(value, 90);
        param.dvExamTop10 = dt;
        fillDataGridDataTable(grdExamTop10, dt);
        Session["ONL_PARAMETER"] = param;
    }
    protected void grdExamTop10_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "AddExam")
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            item.ExtractValues(values);
            e.ExecuteCommand(values);
            addExamDetail("AddExamTop10", values["EXAM_ID"].ToString());
        }
        else if (e.CommandName == "AddFavoriteExam")
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            Session["HashtableAddFavoriteExam"] = values;
            item.ExtractValues(values);
            e.ExecuteCommand(values);

            DataTable dtFavorite = new DataTable();
            dtFavorite = param.dvExamFavorite;

            DataRow[] getCol = dtFavorite.Select("EXAM_ID = '" + values["EXAM_ID"].ToString() + "'");
            if (getCol.Length > 0)
                showOnlineMessageBox("RemoveExamFavorite");
            else
                showOnlineMessageBox("AddFavoriteExam");
        }
    }
    protected void grdExamTop10_ItemDataBound(object source, GridItemEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvExamFavorite;
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem gridDataItem = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;
            string _examCode = dv.Row["EXAM_UID"].ToString();
            DataRow[] rowCheckFav = param.dvExamFavorite.Select("EXAM_UID='" + _examCode + "'");

            ImageButton imgBtnEdit = (ImageButton)gridDataItem["AddFavoriteExam"].Controls[0];

            bool flag = false;
            if (rowCheckFav.Length > 0)
                flag = true;

            imgBtnEdit.ImageUrl = flag ? "../../Resources/ICON/favorite.png" : "../../Resources/ICON/favorite_gray.png";
        }

    }
    private void modifiedData_grdExamTop10()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseMange = new RISBaseClass();
        int value = param.REF_UNIT_ID;
        //int lengthDay = 0;
        //if (rdoSearchExamGroup1.Checked)
        //    lengthDay = 30;
        //if (rdoSearchExamGroup2.Checked)
        //    lengthDay = 60;
        //if (rdoSearchExamGroup3.Checked)
        //    lengthDay = 90;

        //DataTable dt = baseMange.get_Ris_ModalityExamTop10(value, lengthDay);
        DataTable dt = baseMange.get_Ris_ModalityExamTop10(value, 90);
        param.dvExamTop10 = dt;
        fillDataGrid_Filter(grdExamTop10, dt);
    }

    private void addExamDetail(string dvExam, string values)
    {
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
        if (string.IsNullOrEmpty(cmbRefUnit.Text) || cmbRefUnit.Text.LastIndexOf('*') > 0)
        {
            showOnlineMessageBox("checkRefUnit");
            return;
        }

        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        ProcessGetONLExammapclinic pExamClinic = new ProcessGetONLExammapclinic();
        pExamClinic.ONL_EXAMMAPCLINIC.EXAM_ID = Convert.ToInt32(values);
        pExamClinic.ONL_EXAMMAPCLINIC.CLINIC_TYPE_ID = param.CLINIC_TYPE_ID;
        pExamClinic.Invoke();
        if (Utilities.IsHaveData(pExamClinic.Result))
        {
            values= pExamClinic.Result.Tables[0].Rows[0]["EXAMMAP_ID"].ToString();
        }
        param.EXAM_ID = values;

        DataTable dt = param.dvGridDtl;
        DataTable dtExam = new DataTable();
        DataTable dtAllExam = new DataTable();
        dtAllExam = Application["ExamAllData"] as DataTable;
        switch (dvExam)
        {
            case "AddExamAll": dtExam = Application["ExamData"] as DataTable; break;
            case "AddExamTop10": dtExam = param.dvExamTop10; break;
            case "AddExamFavorite": dtExam = param.dvExamFavorite; break;
        }

        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + values);
        RISBaseClass risbase = new RISBaseClass();
        if (rowsExam.Length > 0)
        {
            if (!string.IsNullOrEmpty(rowsExam[0]["CAN_REQONLINE"].ToString()))
                if (rowsExam[0]["CAN_REQONLINE"].ToString() == "Y"
                    && SpecifyData.checkCanOrderwithUnit(param.REF_UNIT_UID, Convert.ToInt32(rowsExam[0]["EXAM_TYPE"]))
                    || param.FlagCTMR == true// Check can use online
                    )
                {
                    setInsertOrderDtl(dt, rowsExam, "0");
                    if (rowsExam[0]["NEED_SCHEDULE"].ToString() == "N" || dt.Select("EXAM_ID=" + values)[0]["PRIORITY"].ToString() == "S")
                        addExamPanel(dtAllExam, rowsExam[0]["EXAM_ID"].ToString());

                    param.dvGridDtl = dt;
                    fillDataGrid_Filter(grdDetail, dt);

                    if (rowsExam[0]["IS_COMMENTS"].ToString() == "Y")
                        addCommentWord("# กรุณาระบุส่วนที่ต้องการตรวจ #", rowsExam[0]["EXAM_ID"].ToString());
                }
                else { showOnlineMessageBox("checkCanRequest"); }
        }
        else
        { showOnlineMessageBox("checkCanRequest"); }
        Session["ONL_PARAMETER"] = param;
    }
    private void addExamPanel(DataTable dtExam, string exam_id)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtPanel = Application["ExamPanel"] as DataTable;

        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + exam_id);
        foreach (DataRow rows in chkPanel)
        {
            DataRow[] chkRows = dt.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
            DataRow[] rowsExam = dtExam.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
            if (chkRows.Length <= 0)
                setInsertOrderDtl(dt, rowsExam, exam_id);
        }
        param.dvGridDtl = dt;
        fillDataGrid_Filter(grdDetail, dt);
    }
    private void addExamPanelPortable(DataTable dtExam, DataRow rowExam)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        string exam_id = rowExam["EXAM_ID"].ToString();
        int clinic_type_id = string.IsNullOrEmpty(rowExam["CLINIC_TYPE"].ToString()) ? param.CLINIC_TYPE_ID : Convert.ToInt32(rowExam["CLINIC_TYPE"].ToString());
        DataTable dt = param.dvGridDtl;
        DataTable dtPanelPortable = new DataTable();
        RISBaseClass baseMange = new RISBaseClass();
        dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(exam_id), clinic_type_id);

        foreach (DataRow rows in dtPanelPortable.Rows)
        {
            DataRow[] rowsExam = dtExam.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
            setInsertOrderDtlPortable(dt, rowsExam, rowExam);
        }
    }
    private void removeExamPanelPortable(DataRow rowExam)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        string exam_id = rowExam["EXAM_ID"].ToString();
        int clinic_type_id = string.IsNullOrEmpty(rowExam["CLINIC_TYPE"].ToString()) ? param.CLINIC_TYPE_ID : Convert.ToInt32(rowExam["CLINIC_TYPE"].ToString());
        DataTable dt = param.dvGridDtl;
        DataTable dtPanelPortable = new DataTable();
        RISBaseClass baseMange = new RISBaseClass();
        dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(exam_id), clinic_type_id);

        foreach (DataRow rows in dtPanelPortable.Rows)
        {
            DataRow[] rowsExam = dt.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
            if (rowsExam.Length > 0)
            {
                dt.Rows.Remove(rowsExam[0]);
                dt.AcceptChanges();
            }
        }
    }

    private void setInsertOrderDtl(DataTable dt, DataRow[] rowsExam, string panelExam)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDept = Application["UnitData"] as DataTable;

        #region Check Conflict Exam
        DataRow[] chkRows = dt.Select("EXAM_ID=" + rowsExam[0]["EXAM_ID"].ToString());
        if (chkRows.Length > 0)
        {
            showOnlineMessageBox("ExamConflict");
            return;
        }
        int reg_id = param.REG_ID;
        OrderClass ord = new OrderClass();
        ord.RIS_CONFLICTEXAMGROUP.REG_ID = reg_id;
        ord.RIS_CONFLICTEXAMGROUP.EXAM_ID = Convert.ToInt32(rowsExam[0]["EXAM_ID"]);
        DataSet dsConflict = ord.check_conflictExam();
        if (Utilities.IsHaveData(dsConflict))
        {
            foreach (DataRow drConflict in dsConflict.Tables[0].Rows)
            {
                if (Convert.ToInt32(drConflict["DATE_DIFF"]) <= Convert.ToInt32(drConflict["DURATION_MIN_AFTER"]))
                {
                    showOnlineMessageBox("ExamConflict");
                    return;
                }
            }
        }
        #endregion

        RISBaseClass risbase = new RISBaseClass();
        DataRow dr = dt.NewRow();
        dr["ORDER_ID"] = 0;
        dr["HN"] = param.HN;
        dr["REG_ID"] = param.REG_ID;
        dr["STATUS"] = "R";
        dr["PRIORITY"] = "R";
        dr["PRIORITY_TEXT"] = "Routine";
        dr["ORDER_DT"] = DateTime.Now;
        dr["EXAM_DT"] = DateTime.Now;
        dr["BPVIEW_ID"] = 5;
        dr["NEED_SCHEDULE"] = rowsExam[0]["NEED_SCHEDULE"];
        dr["NEED_APPROVE"] = checkNeedApprove(rowsExam[0], param.REF_UNIT_UID); // Check some Unit
        dr["NEED_SIDE"] = rowsExam[0]["NEED_SIDE"];
        dr["IS_PORTABLE"] = rowsExam[0]["IS_PORTABLE"];
        dr["EXAM_ID"] = rowsExam[0]["EXAM_ID"].ToString();
        dr["EXAM_UID"] = rowsExam[0]["EXAM_UID"].ToString();
        dr["EXAM_NAME"] = rowsExam[0]["EXAM_NAME"].ToString();
        dr["EXAM_TYPE"] = rowsExam[0]["EXAM_TYPE"].ToString();
        dr["RATE"] = checkExamRate(rowsExam[0], param.ENC_CLINIC, param.IS_NONRESIDENT);
        dr["TOTAL_RATE"] = dr["RATE"].ToString();
        dr["QTY"] = 1;
        dr["CLINIC_TYPE"] = param.CLINIC_TYPE_ID;
        dr["CREATED_BY"] = env.UserID;
        dr["CREATED_NAME"] = env.FirstName + " " + env.LastName;
        dr["CLINICAL_INSTRUCTION"] = param.CLINICAL_INSTRUCTION == null ? "" : param.CLINICAL_INSTRUCTION;
        dr["REF_DOC_INSTRUCTION"] = param.REF_DOC_INSTRUCTION == null ? "" : param.REF_DOC_INSTRUCTION;
        dr["COMMENTS"] = "";


        DataTable dtPatDest = risbase.get_PAT_DEST_ID(param.REF_UNIT_ID, param.CLINIC_TYPE_ID);
        if (Utilities.IsHaveData(dtPatDest))
        {
            dr["PAT_DEST_ID"] = dtPatDest.Rows[0]["PAT_DEST_ID"].ToString();
            dr["PAT_DEST_DESC"] = dtPatDest.Rows[0]["LABEL"].ToString();
            if (rowsExam[0]["NEED_SCHEDULE"].ToString() == "Y")
                dr["strEXAM_DT"] = "Pending..";
            if (dr["NEED_APPROVE"].ToString() == "Y")
                dr["strEXAM_DT"] = "Waiting list";
            switch (SpecifyData.setAutoPriority(param.REF_UNIT_UID))  // Force Priority per Unit
            {
                case "S":
                    dr["SCHEDULE_FLAG"] = false;
                    dr["PRIORITY"] = "S";
                    dr["PRIORITY_TEXT"] = "Stat";
                    dr["ORDER_DT"] = DateTime.Now;
                    dr["EXAM_DT"] = DateTime.Now;
                    dr["strEXAM_DT"] = DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                    break;
                case "U":
                    if (dr["strEXAM_DT"].ToString().IndexOf("Pending") >= 0 || dr["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
                    {
                        dr["PRIORITY"] = "U";
                        dr["PRIORITY_TEXT"] = "Urgent";
                        dr["strEXAM_DT"] = "Waiting list";
                    }
                    else
                    {
                        dr["PRIORITY"] = "R";
                        dr["PRIORITY_TEXT"] = "Routine";
                    }
                    break;
                case "R":
                    dr["PRIORITY"] = "R";
                    dr["PRIORITY_TEXT"] = "Routine";
                    break;
            }

            if (dr["strEXAM_DT"].ToString().IndexOf("Pending") >= 0 || dr["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
            {
                dr["SCHEDULE_FLAG"] = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabAppointment','" + param.CLINIC_TYPE + "');", true);
            }
            else
            {
                tabExam.Tabs[3].Enabled = false;
                dr["SCHEDULE_FLAG"] = false;
                dr["strEXAM_DT"] = dr["strEXAM_DT"].ToString() == "" ? DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat) : dr["strEXAM_DT"];
            }
        }

        int pat_dest_id = string.IsNullOrEmpty(dr["PAT_DEST_ID"].ToString()) ? 0 : Convert.ToInt32(dr["PAT_DEST_ID"]);
        DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(rowsExam[0]["EXAM_ID"]), pat_dest_id, SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
        dtMod_ID = Utilities.filterModalityByClinic(dtMod_ID, param.ENC_CLINIC);

        dr["MODALITY_ID"] = dtMod_ID.Rows.Count > 0 ? dtMod_ID.Rows[0][0] : 0;
        param.dtMod_ID = dtMod_ID;

        if (panelExam.ToString() != "0")
        {
            DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + panelExam.ToString());
            if (rowFillPanel.Length > 0)
            {
                dr["ORDER_DT"] = rowFillPanel[0]["ORDER_DT"];
                dr["EXAM_DT"] = rowFillPanel[0]["EXAM_DT"];
                dr["MODALITY_ID"] = Convert.ToBoolean(rowFillPanel[0]["SCHEDULE_FLAG"]) ? rowFillPanel[0]["MODALITY_ID"] : dr["MODALITY_ID"];
                dr["SESSION_ID"] = rowFillPanel[0]["SESSION_ID"];
                dr["AVG_INV_TIME"] = rowFillPanel[0]["AVG_INV_TIME"];
                dr["START_DATETIME"] = rowFillPanel[0]["START_DATETIME"];
                dr["END_DATETIME"] = rowFillPanel[0]["END_DATETIME"];
                dr["strEXAM_DT"] = rowFillPanel[0]["strEXAM_DT"];
            }
        }

        dt.Rows.Add(dr);
        dt.AcceptChanges();

        Session["ONL_PARAMETER"] = param;
    }
    private void setInsertOrderDtlPortable(DataTable dt, DataRow[] rowsExam, DataRow rowsPortable)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtUnit = Application["UnitData"] as DataTable;
        DataRow[] chkRows = dt.Select("EXAM_ID=" + rowsExam[0]["EXAM_ID"].ToString());
        if (chkRows.Length > 0)
        {
            showOnlineMessageBox("ExamConflict");
            return;
        }

        #region Check Conflict Exam
        int reg_id = param.REG_ID;
        OrderClass ord = new OrderClass();
        ord.RIS_CONFLICTEXAMGROUP.REG_ID = reg_id;
        ord.RIS_CONFLICTEXAMGROUP.EXAM_ID = Convert.ToInt32(rowsExam[0]["EXAM_ID"]);
        DataSet dsConflict = ord.check_conflictExam();
        if (Utilities.IsHaveData(dsConflict))
        {
            foreach (DataRow drConflict in dsConflict.Tables[0].Rows)
            {
                if (Convert.ToInt32(drConflict["DATE_DIFF"]) <= Convert.ToInt32(drConflict["DURATION_MIN_AFTER"]))
                {
                    showOnlineMessageBox("ExamConflict");
                    return;
                }
            }
        }
        #endregion

        RISBaseClass risbase = new RISBaseClass();
        DataRow dr = dt.NewRow();
        dr["ORDER_ID"] = 0;
        dr["HN"] = param.HN;
        dr["REG_ID"] = param.REG_ID;
        dr["STATUS"] = rowsPortable["STATUS"];
        dr["PRIORITY"] = rowsPortable["PRIORITY"];
        dr["PRIORITY_TEXT"] = rowsPortable["PRIORITY_TEXT"];

        dr["SCHEDULE_FLAG"] = rowsPortable["SCHEDULE_FLAG"];
        dr["ORDER_DT"] = rowsPortable["ORDER_DT"];
        dr["EXAM_DT"] = rowsPortable["EXAM_DT"];
        dr["strEXAM_DT"] = rowsPortable["strEXAM_DT"];
        dr["BPVIEW_ID"] = 5;
        dr["NEED_SCHEDULE"] = rowsExam[0]["NEED_SCHEDULE"];
        dr["NEED_APPROVE"] = checkNeedApprove(rowsExam[0], param.REF_UNIT_UID); // Check some Unit
        dr["NEED_SIDE"] = rowsExam[0]["NEED_SIDE"];
        dr["IS_PORTABLE"] = rowsExam[0]["IS_PORTABLE"];
        dr["IS_PORTABLE_VALUE"] = "D";
        dr["EXAM_ID"] = rowsExam[0]["EXAM_ID"].ToString();
        dr["EXAM_UID"] = rowsExam[0]["EXAM_UID"].ToString();
        dr["EXAM_NAME"] = rowsExam[0]["EXAM_NAME"].ToString();
        dr["EXAM_TYPE"] = rowsExam[0]["EXAM_TYPE"].ToString();
        dr["QTY"] = 1;
        dr["RATE"] = checkExamRate(rowsExam[0], param.ENC_CLINIC, param.IS_NONRESIDENT);
        dr["TOTAL_RATE"] = dr["RATE"].ToString();
        dr["CLINIC_TYPE"] = rowsPortable["CLINIC_TYPE"].ToString();
        dr["CREATED_BY"] = env.UserID;
        dr["CREATED_NAME"] = env.FirstName + " " + env.LastName;
        dr["CLINICAL_INSTRUCTION"] = param.CLINICAL_INSTRUCTION == null ? "" : param.CLINICAL_INSTRUCTION;
        dr["REF_DOC_INSTRUCTION"] = param.REF_DOC_INSTRUCTION == null ? "" : param.REF_DOC_INSTRUCTION;
        dr["COMMENTS"] = "";
        dr["PAT_DEST_ID"] = rowsPortable["PAT_DEST_ID"];
        dr["PAT_DEST_DESC"] = rowsPortable["PAT_DEST_DESC"];
        dr["MODALITY_ID"] = rowsPortable["MODALITY_ID"];
        dt.Rows.Add(dr);
        dt.AcceptChanges();
        Session["ONL_PARAMETER"] = param;
    }

    private string checkExamRate(DataRow row_exam, string clinic, bool is_nonresident)
    {
        string rate = "0";
        switch (clinic)
        {
            case "RGL": rate = is_nonresident ? row_exam["FOREIGN_RATE"].ToString() : row_exam["RATE"].ToString(); break;
            case "SPC": rate = is_nonresident ? row_exam["FOREIGN_SPCIAL_RATE"].ToString() : row_exam["SPECIAL_RATE"].ToString(); break;
            case "PM": rate = is_nonresident ? row_exam["FOREIGN_VIP_RATE"].ToString() : row_exam["VIP_RATE"].ToString(); break;
            default: rate = is_nonresident ? row_exam["FOREIGN_RATE"].ToString() : row_exam["RATE"].ToString(); break;
        }
        return rate;
    }
    private string checkExamRate(DataRow row_exam, int clinic, bool is_nonresident)
    {
        string rate = "0";
        switch (clinic)
        {
            case 1: rate = is_nonresident ? row_exam["FOREIGN_RATE"].ToString() : row_exam["RATE"].ToString(); break;
            case 8: rate = is_nonresident ? row_exam["FOREIGN_RATE"].ToString() : row_exam["RATE"].ToString(); break;
            case 7: rate = is_nonresident ? row_exam["FOREIGN_SPCIAL_RATE"].ToString() : row_exam["SPECIAL_RATE"].ToString(); break;
            case 6: rate = is_nonresident ? row_exam["FOREIGN_VIP_RATE"].ToString() : row_exam["VIP_RATE"].ToString(); break;
            default: rate = is_nonresident ? row_exam["FOREIGN_RATE"].ToString() : row_exam["RATE"].ToString(); break;
        }
        return rate;
    }
    private string checkNeedApprove(DataRow row_exam, string ref_unit_uid)
    {
        DataTable dtUnit = Application["UnitData"] as DataTable;
        string _need_approve = row_exam["NEED_APPROVE"].ToString();
        if (row_exam["NEED_SCHEDULE"].ToString() == "Y")
            if (!SpecifyData.checkForceWaitingList(dtUnit, ref_unit_uid))   // Force waiting list per Unit
                _need_approve = "Y";

        return _need_approve;
    }
    private void checkAppointment(DataRow dr)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        rdoIndicationDate1.Checked = false;
        rdoIndicationDate2.Checked = false;
        rdoIndicationDate3.Checked = false;
        rdoIndicationDate4.Checked = false;
        rdoIndicationDate5.Checked = false;
        rdoIndicationDate6.Checked = true;
        if (dtIndicationDate.SelectedDate == null)
            dtIndicationDate.SelectedDate = DateTime.Now;

        grdAppointment.Enabled = false;

        foreach (RadTab tabsExam in tabExam.Tabs)
        {
            if (dr["PRIORITY"].ToString() == "R")
                tabsExam.Enabled = true;
            else
                if (tabsExam.Value == "tabAppointment")
                    tabsExam.Enabled = false;
                else
                    tabsExam.Enabled = true;
        }

        foreach (RadTab tab in tabAppoint.Tabs)
            tab.Enabled = false;
        if (dr["PRIORITY"].ToString() == "R" &&
            dr["NEED_APPROVE"].ToString() != "Y" &&
            dr["NEED_SCHEDULE"].ToString() == "Y")//&&
        //!param.IS_CHILDEN)
        {
            switch (param.CLINIC_TYPE)
            {
                case "Normal": tabAppoint.Tabs[0].Enabled = true;
                    tabAppoint.Tabs[1].Enabled = true;
                    tabAppoint.Tabs[2].Enabled = true;
                    ProcessGetONLExamCNMI prc = new ProcessGetONLExamCNMI();
                    prc.Invoke(Convert.ToInt32(dr["EXAM_ID"]));
                    if (Utilities.IsHaveData(prc.Result))
                    {
                        tabAppoint.Tabs[3].Enabled = true;
                        tabAppoint.Tabs[3].Visible = true;
                    }
                    else
                        tabAppoint.Tabs[3].Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTabAppoint('Regular');", true);
                    break;
                case "Special":
                    tabAppoint.Tabs[1].Enabled = true;
                    tabAppoint.Tabs[2].Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTabAppoint('Special');", true);
                    break;
                case "VIP":
                    tabAppoint.Tabs[2].Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTabAppoint('VIP');", true);
                    break;
            }
            grdAppointment.Enabled = true;
            tabAppoint.Enabled = true;
            setAppointment(dr);
        }
        else if (dr["PRIORITY"].ToString() == "R" &&
            dr["NEED_APPROVE"].ToString() == "Y" &&
            dr["NEED_SCHEDULE"].ToString() == "Y")
        {
            addCommentWord("# ขอคิวก่อนพบแพทย์ #", dr["EXAM_ID"].ToString());
        }
        else if (dr["PRIORITY"].ToString() == "U")
        {
            addCommentWord("# ขอคิวก่อนพบแพทย์ #", dr["EXAM_ID"].ToString());
        }
    }
    private void setAppointment(DataRow drOrdDtl)
    {
        dtIndicationDate.Enabled = false;
        if (rdoIndicationDate1.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays(7), true, drOrdDtl);
        if (rdoIndicationDate2.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays(7*2), true, drOrdDtl);
        if (rdoIndicationDate3.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays(7*4), true, drOrdDtl);
        if (rdoIndicationDate4.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays((7*4)*3), true, drOrdDtl);
        if (rdoIndicationDate5.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays((7*4)*6), true, drOrdDtl);
        if (rdoIndicationDate7.Checked)
            fillDataGrid_Filter(DateTime.Now.AddDays((7*4)*12), true, drOrdDtl);
        if (rdoIndicationDate6.Checked)
        {
            dtIndicationDate.Enabled = true;
            if (dtIndicationDate.SelectedDate == null)
                dtIndicationDate.SelectedDate = DateTime.Now;
            DateTime days = string.IsNullOrEmpty(dtIndicationDate.SelectedDate.Value.ToString()) ? DateTime.Now : dtIndicationDate.SelectedDate.Value;
            fillDataGrid_Filter(days, false, drOrdDtl);
        }

    }
    #endregion
    #region Popup
    private void showNormalPage(string page_name)
    {
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
        if (string.IsNullOrEmpty(cmbRefUnit.Text) || cmbRefUnit.Text.LastIndexOf('*') > 0)
        {
            showOnlineMessageBox("checkRefUnit");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openNormalPage", "showNormalPage('" + page_name + "');", true);
        }
    }
    private void showNormalPageAllGroup(string group_text)
    {
        RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
        if (string.IsNullOrEmpty(cmbRefUnit.Text) || cmbRefUnit.Text.LastIndexOf('*') > 0)
        {
            showOnlineMessageBox("checkRefUnit");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openNormalPageOR", "showNormalPageAllGroup('" + group_text + "');", true);
        }
    }
    private void showOnlineAlertExam()
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showNormalAlert", "showNormalAlert('ShowalertExam');", true);
    }
    private void showOnlineMessageBox(string messagePopup)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "');", true);
    }
    private void showEditDialog(string exam_id)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showBPViewCheck", "showBPViewCheck('" + exam_id + "');", true);
    }
    private void showRiskManagement(string tab_name)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showRiskManagement", "showRiskManagement('" + tab_name + "');", true);
    }
    private void showCovid()
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showCovid", "showCovid();", true);
    }
    private void showClinicalIndicationWithParameter(string param)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showClinicalIndicationWithParams", "showClinicalIndicationWithParams('"+param+"');", true);
    }
    #endregion
    #region Appointment page
    protected void grdAppointment_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();

        dt = set_NullAppointData(dt, "Regular", "W");
        fillDataGridDataTable(grdAppointment, dt);
    }
    protected void grdAppointment_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;

            RadButton rdoMorning = (RadButton)item["rdotempMorning"].FindControl("rdoMorning");
            rdoMorning.GroupName = "Appintment";
            rdoMorning.ForeColor = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoMorning.Font.Bold = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Checked = dv.Row["IS_CHECKED_M"].ToString() == "Y" ? true : false;
            rdoMorning.Enabled = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Value = dv.Row["VALUE_M"].ToString();

            RadButton rdoAfternoon = (RadButton)item["rdotempAfternoon"].FindControl("rdoAfternoon");
            rdoAfternoon.GroupName = "Appintment";
            rdoAfternoon.ForeColor = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoAfternoon.Font.Bold = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Checked = dv.Row["IS_CHECKED_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Enabled = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Value = dv.Row["VALUE_A"].ToString();

            RadButton rdoEvening = (RadButton)item["rdotempEvening"].FindControl("rdoEvening");
            rdoEvening.GroupName = "Appintment";
            rdoEvening.ForeColor = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoEvening.Font.Bold = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Checked = dv.Row["IS_CHECKED_E"].ToString() == "Y" ? true : false;
            rdoEvening.Enabled = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Value = dv.Row["VALUE_E"].ToString();
        }
    }
    protected void grdAppointmentSP_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = set_NullAppointData(dt, "Special", "W");
        fillDataGridDataTable(grdAppointmentSP, dt);
    }
    protected void grdAppointmentSP_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;

            RadButton rdoMorning = (RadButton)item["rdotempMorningSP"].FindControl("rdoMorningSP");
            rdoMorning.GroupName = "Appintment";
            rdoMorning.ForeColor = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoMorning.Font.Bold = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Checked = dv.Row["IS_CHECKED_M"].ToString() == "Y" ? true : false;
            rdoMorning.Enabled = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Value = dv.Row["VALUE_M"].ToString();

            RadButton rdoAfternoon = (RadButton)item["rdotempAfternoonSP"].FindControl("rdoAfternoonSP");
            rdoAfternoon.GroupName = "Appintment";
            rdoAfternoon.ForeColor = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoAfternoon.Font.Bold = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Checked = dv.Row["IS_CHECKED_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Enabled = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Value = dv.Row["VALUE_A"].ToString();

            RadButton rdoEvening = (RadButton)item["rdotempEveningSP"].FindControl("rdoEveningSP");
            rdoEvening.GroupName = "Appintment";
            rdoEvening.ForeColor = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoEvening.Font.Bold = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Checked = dv.Row["IS_CHECKED_E"].ToString() == "Y" ? true : false;
            rdoEvening.Enabled = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Value = dv.Row["VALUE_E"].ToString();
        }
    }
    protected void grdAppointmentPM_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = set_NullAppointData(dt, "Premium", "W");
        fillDataGridDataTable(grdAppointmentPM, dt);
    }
    protected void grdAppointmentPM_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;

            RadButton rdoMorning = (RadButton)item["rdotempMorningPM"].FindControl("rdoMorningPM");
            rdoMorning.GroupName = "Appintment";
            rdoMorning.ForeColor = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoMorning.Font.Bold = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Checked = dv.Row["IS_CHECKED_M"].ToString() == "Y" ? true : false;
            rdoMorning.Enabled = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Value = dv.Row["VALUE_M"].ToString();

            RadButton rdoAfternoon = (RadButton)item["rdotempAfternoonPM"].FindControl("rdoAfternoonPM");
            rdoAfternoon.GroupName = "Appintment";
            rdoAfternoon.ForeColor = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoAfternoon.Font.Bold = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Checked = dv.Row["IS_CHECKED_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Enabled = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Value = dv.Row["VALUE_A"].ToString();

            RadButton rdoEvening = (RadButton)item["rdotempEveningPM"].FindControl("rdoEveningPM");
            rdoEvening.GroupName = "Appintment";
            rdoEvening.ForeColor = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoEvening.Font.Bold = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Checked = dv.Row["IS_CHECKED_E"].ToString() == "Y" ? true : false;
            rdoEvening.Enabled = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Value = dv.Row["VALUE_E"].ToString();
        }
    }
    protected void grdAppointmentCNMI_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = set_NullAppointData(dt, "CNMI", "W");
        fillDataGridDataTable(grdAppointmentCNMI, dt);
    }
    protected void grdAppointmentCNMI_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;

            RadButton rdoMorning = (RadButton)item["rdotempMorningCNMI"].FindControl("rdoMorningCNMI");
            rdoMorning.GroupName = "Appintment";
            rdoMorning.ForeColor = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoMorning.Font.Bold = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Checked = dv.Row["IS_CHECKED_M"].ToString() == "Y" ? true : false;
            rdoMorning.Enabled = dv.Row["IS_ENABLE_M"].ToString() == "Y" ? true : false;
            rdoMorning.Value = dv.Row["VALUE_M"].ToString();

            RadButton rdoAfternoon = (RadButton)item["rdotempAfternoonCNMI"].FindControl("rdoAfternoonCNMI");
            rdoAfternoon.GroupName = "Appintment";
            rdoAfternoon.ForeColor = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoAfternoon.Font.Bold = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Checked = dv.Row["IS_CHECKED_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Enabled = dv.Row["IS_ENABLE_A"].ToString() == "Y" ? true : false;
            rdoAfternoon.Value = dv.Row["VALUE_A"].ToString();

            RadButton rdoEvening = (RadButton)item["rdotempEveningCNMI"].FindControl("rdoEveningCNMI");
            rdoEvening.GroupName = "Appintment";
            rdoEvening.ForeColor = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? System.Drawing.Color.Blue : System.Drawing.Color.LightGray;
            rdoEvening.Font.Bold = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Checked = dv.Row["IS_CHECKED_E"].ToString() == "Y" ? true : false;
            rdoEvening.Enabled = dv.Row["IS_ENABLE_E"].ToString() == "Y" ? true : false;
            rdoEvening.Value = dv.Row["VALUE_E"].ToString();
        }
    }

    protected void rdoMorning_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppoint;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_M=" + clickedButton.Value);
            rows[0]["IS_CHECKED_M"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_M"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_M"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_M"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_M"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_M"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {

                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointment, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }

    }
    protected void rdoAfternoon_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppoint;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_A=" + clickedButton.Value);
            rows[0]["IS_CHECKED_A"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_A"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_A"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_A"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_A"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_A"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }

            fillDataGrid_Filter(grdAppointment, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoEvening_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppoint;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_E=" + clickedButton.Value);
            rows[0]["IS_CHECKED_E"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_E"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_E"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_E"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_E"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_E"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointment, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoMorningSP_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointSP;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_M=" + clickedButton.Value);
            rows[0]["IS_CHECKED_M"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_M"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_M"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_M"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_M"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_M"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {

                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentSP, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }

    }
    protected void rdoAfternoonSP_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointSP;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_A=" + clickedButton.Value);
            rows[0]["IS_CHECKED_A"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_A"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_A"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_A"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_A"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_A"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }

            fillDataGrid_Filter(grdAppointmentSP, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoEveningSP_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointSP;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_E=" + clickedButton.Value);
            rows[0]["IS_CHECKED_E"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_E"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_E"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_E"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_E"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_E"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentSP, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoMorningPM_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointPM;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_M=" + clickedButton.Value);
            rows[0]["IS_CHECKED_M"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_M"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_M"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_M"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_M"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_M"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {

                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentPM, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }

    }
    protected void rdoAfternoonPM_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointPM;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_A=" + clickedButton.Value);
            rows[0]["IS_CHECKED_A"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_A"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_A"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_A"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_A"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_A"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }

            fillDataGrid_Filter(grdAppointmentPM, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoEveningPM_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointPM;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_E=" + clickedButton.Value);
            rows[0]["IS_CHECKED_E"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_E"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_E"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_E"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_E"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_E"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentPM, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoMorningCNMI_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointCNMI;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_M=" + clickedButton.Value);
            rows[0]["IS_CHECKED_M"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_M"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_M"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_M"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_M"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_M"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {

                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentCNMI, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }

    }
    protected void rdoAfternoonCNMI_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointCNMI;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_A=" + clickedButton.Value);
            rows[0]["IS_CHECKED_A"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_A"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_A"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_A"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_A"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_A"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }

            fillDataGrid_Filter(grdAppointmentCNMI, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void rdoEveningCNMI_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtSch = param.dvAppointCNMI;

        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            foreach (DataRow dr in param.dvAppoint.Rows)
            {
                dr["IS_CHECKED_M"] = "N";
                dr["IS_CHECKED_A"] = "N";
                dr["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointment, param.dvAppoint);
            foreach (DataRow drSP in param.dvAppointSP.Rows)
            {
                drSP["IS_CHECKED_M"] = "N";
                drSP["IS_CHECKED_A"] = "N";
                drSP["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentSP, param.dvAppointSP);
            foreach (DataRow drPM in param.dvAppointPM.Rows)
            {
                drPM["IS_CHECKED_M"] = "N";
                drPM["IS_CHECKED_A"] = "N";
                drPM["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentPM, param.dvAppointPM);
            foreach (DataRow drCNMI in param.dvAppointCNMI.Rows)
            {
                drCNMI["IS_CHECKED_M"] = "N";
                drCNMI["IS_CHECKED_A"] = "N";
                drCNMI["IS_CHECKED_E"] = "N";
            }
            fillDataGrid_Filter(grdAppointmentCNMI, param.dvAppointCNMI);

            DataRow[] rows = dtSch.Select("VALUE_E=" + clickedButton.Value);
            rows[0]["IS_CHECKED_E"] = "Y";

            rows[0]["SCHEDULE_STARTDATE"] = rows[0]["SCHEDULE_STARTDATE_E"];
            rows[0]["SCHEDULE_ENDDATE"] = rows[0]["SCHEDULE_ENDDATE_E"];
            rows[0]["SESSION_ID"] = rows[0]["SESSION_ID_E"];
            rows[0]["MODALITY_ID"] = rows[0]["MODALITY_ID_E"];
            rows[0]["AVG_INV_TIME"] = rows[0]["AVG_INV_TIME_E"];

            if (string.IsNullOrEmpty(param.EXAM_ID))
            {
                foreach (DataRow drr in dt.Rows)
                    set_FillAppointData(drr, rows[0]);
            }
            else
            {
                DataRow[] rowData = dt.Select("EXAM_ID=" + param.EXAM_ID);
                foreach (DataRow dr in rowData)
                    set_FillAppointData(dr, rows[0]);
            }
            fillDataGrid_Filter(grdAppointmentCNMI, dtSch);

            param.CLINICAL_INSTRUCTION = txtEditor.Text;
            param.dvGridDtl = dt;
            param.dvGridDtlRebind = dt;

            fillDataGrid_Filter(grdDetail, dt);
            Session["ONL_PARAMETER"] = param;
        }
    }

    protected void cmbRadiologistAppoint_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtDoc = Application["HisDoctorData"] as DataTable;
        cmbRadiologistAppoint.Items.Clear();

        string text = e.Text;
        DataRow[] rows = dtDoc.Select("EMP_UID+RadioName LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRadiologistAppoint.Items.Add(new RadComboBoxItem(rows[i]["EMP_UID"].ToString() + ":" + rows[i]["RadioName"].ToString()));

    }
    protected void cmbRadiologistAppoint_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Text)) return;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtDoc = Application["HisDoctorData"] as DataTable;
        if (!string.IsNullOrEmpty(param.EXAM_ID))
        {
            DataRow[] rows = dt.Select("EXAM_ID=" + param.EXAM_ID);
            foreach (DataRow dr in rows)
            {
                DataRow[] rowDoc = dtDoc.Select("RadioName='" + e.Text.Substring(e.Text.LastIndexOf(':') + 1) + "'");
                dr["ASSIGNED_TO"] = rowDoc.Length > 0 ? Convert.ToInt32(rowDoc[0]["EMP_ID"]) : 0;
            }
            dt.AcceptChanges();

            fillDataGrid_Filter(grdDetail, dt);
        }
    }
    protected void rdoIndicationDate_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtMod_ID = param.dtMod_ID;
        DataTable dt = param.dvGridDtl;

        DataRow dr = dt.Select("EXAM_ID=" + param.EXAM_ID)[0];
        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            dtIndicationDate.Enabled = false;
            switch (clickedButton.ID)
            {
                case "rdoIndicationDate1":
                    fillDataGrid_Filter(DateTime.Now.AddDays(7), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 1 สัปดาห์ #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate2":
                    fillDataGrid_Filter(DateTime.Now.AddDays(14), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 2 สัปดาห์ #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate3":
                    fillDataGrid_Filter(DateTime.Now.AddDays(28), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 4 สัปดาห์ #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate4":
                    fillDataGrid_Filter(DateTime.Now.AddDays(90), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 3 เดือน #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate5":
                    fillDataGrid_Filter(DateTime.Now.AddDays(180), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 6 เดือน #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate7":
                    fillDataGrid_Filter(DateTime.Now.AddDays(365), true, dr);
                    addCommentWord("# ขอคิวนัดภายใน 1 ปี #", dr["EXAM_ID"].ToString());
                    break;
                case "rdoIndicationDate6":
                    dtIndicationDate.Enabled = true;
                    //if(dtIndicationDate.SelectedDate == null)
                    //    dtIndicationDate.SelectedDate = DateTime.Now;
                    //DateTime date = string.IsNullOrEmpty(dtIndicationDate.SelectedDate.Value.ToString()) ? DateTime.Now : dtIndicationDate.SelectedDate.Value;
                    dtIndicationDate.SelectedDate = DateTime.Now;
                    fillDataGrid_Filter(DateTime.Now, false, dr);
                    break;
            }
        }
    }
    private void addCommentWord(string addComment, string exam_id)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;

        DataRow dr = dt.Select("EXAM_ID=" + exam_id)[0];

        string _comment = "";
        string comment = dr["COMMENTS"].ToString();
        if (comment.Trim().Length > 0)
        {
            comment = clearCommentWord(comment);
            _comment = addComment + "\r\n" + comment;
        }
        else
            _comment = addComment;


        if (dr["NEED_APPROVE"].ToString() == "Y")
        {
            dr["COMMENTS"] = _comment;
            showEditDialog(exam_id);
        }
        else
        {
            bool flag = false;
            switch (param.CLINIC_TYPE)
            {
                case "Normal": flag = param.dvAppoint.Rows.Count > 1 ? true : false; break;
                case "Special": flag = param.dvAppointSP.Rows.Count > 1 ? true : false; break;
                case "VIP": flag = param.dvAppointPM.Rows.Count > 1 ? true : false; break;
            }
            if (flag)
                dr["COMMENTS"] = _comment;// clearCommentWord(dr["COMMENTS"].ToString());
            else
            {
                dr["COMMENTS"] = _comment;
                showEditDialog(exam_id);
            }
        }
    }
    private string clearCommentWord(string comment)
    {
        string _comment = comment;
        if (comment.Length > 0)
        {
            int _start = comment.IndexOf("#");
            int _end = comment.LastIndexOf("#");
            if (_start != _end && _start >= 0 && _end >= 0)
                _comment = comment.Remove(_start, _end + 1);
        }
        return _comment;
    }
    protected void dtIndicationDate_SelectedDateChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass risbase = new RISBaseClass();
        DataTable dt = param.dvGridDtl;
        //param.EXAM_ID = param.dvGridDtl.Rows[0]["EXAM_ID"].ToString();
        DataRow dr = dt.Select("EXAM_ID=" + param.EXAM_ID)[0];

        if (tabExam.SelectedTab != null)
            if (tabExam.SelectedTab.Value != "tabAppointment")// fix bug combobox in grid when changed priority
                return;
        DateTime days = dtIndicationDate.SelectedDate == null ? DateTime.Now : dtIndicationDate.SelectedDate.Value;
        if (dtIndicationDate.SelectedDate == null)
            dtIndicationDate.SelectedDate = days;

        DateTime chkDate1 = new DateTime(dtIndicationDate.SelectedDate.Value.Year, dtIndicationDate.SelectedDate.Value.Month, dtIndicationDate.SelectedDate.Value.Day, 0, 0, 0);
        DateTime chkDate2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        if (chkDate1 == chkDate2)
            fillDataGrid_Filter(days, false, dr);
        else
            fillDataGrid_Filter(days, true, dr);

        DataTable dtt = new DataTable();
        switch (param.CLINIC_TYPE)
        {
            case "Normal":
                if (tabAppoint.SelectedIndex == 0)
                    dtt = param.dvAppoint;
                else if (tabAppoint.SelectedIndex == 1)
                    dtt = param.dvAppointSP;
                else if (tabAppoint.SelectedIndex == 2)
                    dtt = param.dvAppointPM;
                break;
            case "Special": dtt = param.dvAppointSP; break;
            case "VIP": dtt = param.dvAppointPM; break;
        }
        if (Utilities.IsHaveData(dtt))
        {
            DateTime dtStart = new DateTime();
            DateTime dt1 = new DateTime(dtIndicationDate.SelectedDate.Value.Year, dtIndicationDate.SelectedDate.Value.Month, dtIndicationDate.SelectedDate.Value.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]).Year, Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]).Month, Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]).Day, 0, 0, 0);
            if (dt1 == dt2)
            {
                dtStart = dr["NEED_APPROVE"].ToString() == "Y" ? DateTime.Now : Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]);
                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : dtStart.ToString("d MMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                dr["COMMENTS"] = clearCommentWord(dr["COMMENTS"].ToString());
            }
            else
            {
                dtStart = dr["NEED_APPROVE"].ToString() == "Y" ? DateTime.Now : Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]);
                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : dtStart.ToString("d MMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                //dtStart = dr["NEED_APPROVE"].ToString() == "Y" ? DateTime.Now : dtIndicationDate.SelectedDate.Value;
                //dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : Convert.ToDateTime(dtt.Rows[0]["SCHEDULE_STARTDATE"]).ToString("d MMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                addCommentWord("# ขอคิวนัดภายในวันที่ " + dt1.ToString("d MMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat) + " #", dr["EXAM_ID"].ToString());
            }
            dr["EXAM_DT"] = dtStart;
            dr["START_DATETIME"] = dtStart;
            dr["SESSION_ID"] = string.IsNullOrEmpty(dtt.Rows[0]["SESSION_ID"].ToString()) ? 0 : Convert.ToInt32(dtt.Rows[0]["SESSION_ID"]);
            dr["AVG_INV_TIME"] = dtt.Rows[0]["AVG_INV_TIME"].ToString();
        }
        else
        {
            if (dr["PRIORITY"].ToString() == "S")
                dr["COMMENTS"] = clearCommentWord(dr["COMMENTS"].ToString());
            else
            {
                DateTime dt1 = new DateTime(dtIndicationDate.SelectedDate.Value.Year, dtIndicationDate.SelectedDate.Value.Month, dtIndicationDate.SelectedDate.Value.Day, 0, 0, 0);
                addCommentWord("# ขอคิวนัดภายในวันที่ " + dt1.ToString("d MMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat) + " #", dr["EXAM_ID"].ToString());
            }
        }
        fillDataGrid_Filter(grdDetail, dt);
        Session["ONL_PARAMETER"] = param;
    }
    private int calculateDayOfYears(DateTime date_start, DateTime date_end)
    {
        int lengthDays = (((date_end.Year - date_start.Year) * 365) + date_end.DayOfYear) - date_start.DayOfYear;
        return lengthDays;
    }
    private void fillDataGrid_Filter(DateTime date, bool IS_Length, DataRow drOrddtl)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass risbase = new RISBaseClass();
        DataTable dttRG = param.dvAppoint;
        DataTable dttSP = param.dvAppointSP;
        DataTable dttPM = param.dvAppointPM;
        DataTable dttCNMI = param.dvAppointCNMI;

        DataTable dt = param.dvGridDtl;
        DataRow dr = drOrddtl;
        DataTable dtt = new DataTable();
        if (dr["PRIORITY"].ToString() != "S")
        {
            if (dr["NEED_APPROVE"].ToString() != "Y")
            {
                switch (param.CLINIC_TYPE)
                {
                    case "Normal":
                        dttRG = set_AppointGridData(dttRG.Clone(), IS_Length, date, "Regular");
                        dttSP = set_AppointGridData(dttSP.Clone(), IS_Length, date, "Special");
                        dttPM = set_AppointGridData(dttPM.Clone(), IS_Length, date, "Premium");
                        dttCNMI = set_AppointGridData(dttCNMI.Clone(), IS_Length, date, "CNMI");
                        dtt = dttRG;
                        if (tabAppoint.SelectedIndex == 1)
                            dtt = dttSP;
                        else if (tabAppoint.SelectedIndex == 2)
                            dtt = dttPM;
                        if (Utilities.IsHaveData(dtt))
                            if (!string.IsNullOrEmpty(dtt.Rows[0]["SCHEDULE_DESC_DATE"].ToString()))
                            {
                                set_FillAppointData(dr, dtt);
                                if (dtt.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dtt.Rows[0]["SCHEDULE_STARTDATE_M"].ToString())
                                    dtt.Rows[0]["IS_CHECKED_M"] = "Y";
                                else
                                    dtt.Rows[0]["IS_CHECKED_M"] = "N";
                                if (dtt.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dtt.Rows[0]["SCHEDULE_STARTDATE_A"].ToString())
                                    dtt.Rows[0]["IS_CHECKED_A"] = "Y";
                                else
                                    dtt.Rows[0]["IS_CHECKED_A"] = "N";
                                if (dtt.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dtt.Rows[0]["SCHEDULE_STARTDATE_E"].ToString())
                                    dtt.Rows[0]["IS_CHECKED_E"] = "Y";
                                else
                                    dtt.Rows[0]["IS_CHECKED_E"] = "N";
                            }
                            else
                                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : "Pending..";
                        break;
                    case "Special":
                        dttSP = set_AppointGridData(dttSP.Clone(), IS_Length, date, "Special");
                        dttPM = set_AppointGridData(dttPM.Clone(), IS_Length, date, "Premium");
                        if (Utilities.IsHaveData(dttSP))
                            if (!string.IsNullOrEmpty(dttSP.Rows[0]["SCHEDULE_DESC_DATE"].ToString()))
                            {
                                set_FillAppointData(dr, dttSP.Rows[0]);
                                if (dttSP.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttSP.Rows[0]["SCHEDULE_STARTDATE_M"].ToString())
                                    dttSP.Rows[0]["IS_CHECKED_M"] = "Y";
                                else
                                    dttSP.Rows[0]["IS_CHECKED_M"] = "N";
                                if (dttSP.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttSP.Rows[0]["SCHEDULE_STARTDATE_A"].ToString())
                                    dttSP.Rows[0]["IS_CHECKED_A"] = "Y";
                                else
                                    dttSP.Rows[0]["IS_CHECKED_A"] = "N";
                                if (dttSP.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttSP.Rows[0]["SCHEDULE_STARTDATE_E"].ToString())
                                    dttSP.Rows[0]["IS_CHECKED_E"] = "Y";
                                else
                                    dttSP.Rows[0]["IS_CHECKED_E"] = "N";
                            }
                            else
                                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : "Pending..";
                        break;
                    case "VIP":
                        dttPM = set_AppointGridData(dttPM.Clone(), IS_Length, date, "Premium");
                        if (Utilities.IsHaveData(dttPM))
                            if (!string.IsNullOrEmpty(dttPM.Rows[0]["SCHEDULE_DESC_DATE"].ToString()))
                            {
                                set_FillAppointData(dr, dttPM.Rows[0]);
                                if (dttPM.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttPM.Rows[0]["SCHEDULE_STARTDATE_M"].ToString())
                                    dttPM.Rows[0]["IS_CHECKED_M"] = "Y";
                                else
                                    dttPM.Rows[0]["IS_CHECKED_M"] = "N";
                                if (dttPM.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttPM.Rows[0]["SCHEDULE_STARTDATE_A"].ToString())
                                    dttPM.Rows[0]["IS_CHECKED_A"] = "Y";
                                else
                                    dttPM.Rows[0]["IS_CHECKED_A"] = "N";
                                if (dttPM.Rows[0]["SCHEDULE_STARTDATE"].ToString() == dttPM.Rows[0]["SCHEDULE_STARTDATE_E"].ToString())
                                    dttPM.Rows[0]["IS_CHECKED_E"] = "Y";
                                else
                                    dttPM.Rows[0]["IS_CHECKED_E"] = "N";
                            }
                            else
                                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : "Pending..";
                        break;
                }
            }
            else
            {
                dttRG = set_NullAppointData(dttRG.Clone(), "Regular", "W");
                dttSP = set_NullAppointData(dttSP.Clone(), "Special", "W");
                dttPM = set_NullAppointData(dttPM.Clone(), "Premium", "W");
            }
        }
        else
        {

            dttRG = set_NullAppointData(dttRG.Clone(), "Regular", "W");
            dttSP = set_NullAppointData(dttSP.Clone(), "Special", "W");
            dttPM = set_NullAppointData(dttPM.Clone(), "Premium", "W");
        }

        if (IS_Length) {
            DataView dvdttRG = dttRG.DefaultView;
            dvdttRG.Sort = "SCHEDULE_STARTDATE desc";
            dttRG = dvdttRG.ToTable();

            DataView dvdttSP = dttSP.DefaultView;
            dvdttSP.Sort = "SCHEDULE_STARTDATE desc";
            dttSP = dvdttSP.ToTable();

            DataView dvdttPM = dttPM.DefaultView;
            dvdttPM.Sort = "SCHEDULE_STARTDATE desc";
            dttPM = dvdttPM.ToTable();

            DataView dvdttCNMI = dttCNMI.DefaultView;
            dvdttCNMI.Sort = "SCHEDULE_STARTDATE desc";
            dttCNMI = dvdttCNMI.ToTable();
        }
        else
        {
            DataView dvdttRG = dttRG.DefaultView;
            dvdttRG.Sort = "SCHEDULE_STARTDATE";
            dttRG = dvdttRG.ToTable();

            DataView dvdttSP = dttSP.DefaultView;
            dvdttSP.Sort = "SCHEDULE_STARTDATE";
            dttSP = dvdttSP.ToTable();

            DataView dvdttPM = dttPM.DefaultView;
            dvdttPM.Sort = "SCHEDULE_STARTDATE";
            dttPM = dvdttPM.ToTable();

            DataView dvdttCNMI = dttCNMI.DefaultView;
            dvdttCNMI.Sort = "SCHEDULE_STARTDATE";
            dttCNMI = dvdttCNMI.ToTable();
        }

        param.dvAppoint = dttRG;
        param.dvAppointSP = dttSP;
        param.dvAppointPM = dttPM;
        param.dvAppointCNMI = dttCNMI;
        param.dvGridDtl = dt;

        fillDataGrid_Filter(grdAppointment, dttRG);
        fillDataGrid_Filter(grdAppointmentSP, dttSP);
        fillDataGrid_Filter(grdAppointmentPM, dttPM);
        fillDataGrid_Filter(grdAppointmentCNMI, dttCNMI);
        fillDataGrid_Filter(grdDetail, dt);
        Session["ONL_PARAMETER"] = param;

    }
    private void set_FillAppointData(DataRow dr, DataTable dtSchTime)
    {
        DateTime dtStart = new DateTime();
        dtStart = dr["NEED_APPROVE"].ToString() == "Y" ? DateTime.Now : Convert.ToDateTime(dtSchTime.Rows[0]["SCHEDULE_STARTDATE"]);
        int avg_time = Convert.ToInt32(dtSchTime.Rows[0]["AVG_INV_TIME"]);
        dr["EXAM_DT"] = dtStart;
        dr["MODALITY_ID"] = Convert.ToInt32(dtSchTime.Rows[0]["MODALITY_ID"]);
        dr["SESSION_ID"] = string.IsNullOrEmpty(dtSchTime.Rows[0]["SESSION_ID"].ToString()) ? 0 : Convert.ToInt32(dtSchTime.Rows[0]["SESSION_ID"]);
        dr["AVG_INV_TIME"] = avg_time;
        switch (dr["PRIORITY"].ToString())
        {
            case "R":
                dr["START_DATETIME"] = dr["NEED_APPROVE"].ToString() == "Y" ? dtStart.AddMinutes(-avg_time) : Convert.ToDateTime(dtSchTime.Rows[0]["SCHEDULE_STARTDATE"]);
                dr["END_DATETIME"] = dr["NEED_APPROVE"].ToString() == "Y" ? dtStart.AddSeconds(-1) : Convert.ToDateTime(dtSchTime.Rows[0]["SCHEDULE_ENDDATE"]);
                dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : dtStart.ToString("d MMM yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                break;
            case "U":
                dr["START_DATETIME"] = dtStart.AddMinutes(-avg_time);
                dr["END_DATETIME"] = dtStart.AddSeconds(-1);
                dr["strEXAM_DT"] = "Waiting list";
                break;
        }
        UpdateExamPanel(dr, dtSchTime);
    }
    private void UpdateExamPanel(DataRow dr, DataTable dtSch)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        DataTable dtPanel = Application["ExamPanel"] as DataTable;

        DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
        string clinic_value = "";
        string _rate = "0";

        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
        if (chkPanel.Length > 0)
        {
            DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
            if (rowFillPanel.Length > 0)
            {
                rowFillPanel[0]["ORDER_DT"] = dr["ORDER_DT"];
                rowFillPanel[0]["EXAM_DT"] = dr["EXAM_DT"];
                rowFillPanel[0]["MODALITY_ID"] = dr["MODALITY_ID"];

                rowFillPanel[0]["SESSION_ID"] = dr["SESSION_ID"];
                rowFillPanel[0]["AVG_INV_TIME"] = dr["AVG_INV_TIME"];
                rowFillPanel[0]["START_DATETIME"] = dr["START_DATETIME"];
                rowFillPanel[0]["END_DATETIME"] = dr["END_DATETIME"];
                rowFillPanel[0]["strEXAM_DT"] = dr["strEXAM_DT"];

                rowsExam = dtAllExam.Select("EXAM_ID=" + rowFillPanel[0]["EXAM_ID"].ToString());
                clinic_value = "";
                _rate = "0";
                switch (dtSch.Rows[0]["CLINIC_TYPE"].ToString())
                {
                    case "Regular": clinic_value = "Normal";
                        _rate = rowsExam[0]["RATE"].ToString(); break;
                    case "Special": clinic_value = "Special";
                        _rate = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                    case "Premium": clinic_value = "VIP";
                        _rate = rowsExam[0]["VIP_RATE"].ToString(); break;
                }
                if (param.IS_NONRESIDENT)
                    _rate = rowsExam[0]["FOREIGN_RATE"].ToString();


                DataRow[] rowsClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + clinic_value + "'");
                rowFillPanel[0]["CLINIC_TYPE"] = rowsClinic[0]["CLINIC_TYPE_ID"];
                double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(dr["QTY"]);
                rowFillPanel[0]["TOTAL_RATE"] = sumrate.ToString("#.00");
                rowFillPanel[0]["RATE"] = _rate;
            }
        }
    }
    private void set_FillAppointData(DataRow dr, DataRow drSch)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DateTime dtStart = Convert.ToDateTime(drSch["SCHEDULE_STARTDATE"].ToString());
        int avg_time = Convert.ToInt32(drSch["AVG_INV_TIME"].ToString());
        dr["EXAM_DT"] = dtStart;
        dr["MODALITY_ID"] = Convert.ToInt32(drSch["MODALITY_ID"].ToString());
        dr["SESSION_ID"] = string.IsNullOrEmpty(drSch["SESSION_ID"].ToString()) ? 0 : Convert.ToInt32(drSch["SESSION_ID"].ToString());
        dr["CLINICAL_INSTRUCTION"] = txtEditor.Text;
        dr["AVG_INV_TIME"] = avg_time;
        dr["COMMENTS"] = clearCommentWord(dr["COMMENTS"].ToString());
        dr["START_DATETIME"] = Convert.ToDateTime(drSch["SCHEDULE_STARTDATE"].ToString());
        dr["END_DATETIME"] = Convert.ToDateTime(drSch["SCHEDULE_ENDDATE"].ToString());
        dr["strEXAM_DT"] = dr["NEED_APPROVE"].ToString() == "Y" ? "Waiting list" : dtStart.ToString("d MMM yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

        DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
        string clinic_value = "";
        string _rate = "0";
        switch (drSch["CLINIC_TYPE"].ToString())
        {
            case "Regular": clinic_value = "Normal";
                _rate = rowsExam[0]["RATE"].ToString(); break;
            case "Special": clinic_value = "Special";
                _rate = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
            case "Premium": clinic_value = "VIP";
                _rate = rowsExam[0]["VIP_RATE"].ToString(); break;
            case "CNMI": clinic_value = "CNMI";
                _rate = rowsExam[0]["RATE"].ToString(); break;

        }
        if (param.IS_NONRESIDENT)
            _rate = rowsExam[0]["FOREIGN_RATE"].ToString();


        DataRow[] rowsClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + clinic_value + "'");
        dr["CLINIC_TYPE"] = rowsClinic[0]["CLINIC_TYPE_ID"];
        double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(dr["QTY"]);
        dr["TOTAL_RATE"] = sumrate.ToString("#.00");
        dr["RATE"] = _rate;


        DataTable dt = param.dvGridDtl;
        if (dr["IS_PORTABLE_VALUE"].ToString() == "Y")
        {
            DataTable dtPanelPortable = new DataTable();
            RISBaseClass baseMange = new RISBaseClass();
            dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(dr["EXAM_ID"]), Convert.ToInt32(dr["CLINIC_TYPE"]));
            foreach (DataRow drPortable in dtPanelPortable.Rows)
            {
                DataRow[] arryrows = dt.Select("EXAM_ID=" + drPortable["AUTO_EXAM_ID"].ToString());
                if (arryrows.Length > 0)
                {
                    arryrows[0]["EXAM_DT"] = dr["EXAM_DT"];
                    arryrows[0]["MODALITY_ID"] = dr["MODALITY_ID"];

                    arryrows[0]["SESSION_ID"] = dr["SESSION_ID"];
                    arryrows[0]["AVG_INV_TIME"] = dr["AVG_INV_TIME"];
                    arryrows[0]["START_DATETIME"] = dr["START_DATETIME"];
                    arryrows[0]["END_DATETIME"] = dr["END_DATETIME"];
                    arryrows[0]["strEXAM_DT"] = dr["strEXAM_DT"];
                }
            }
        }

        DataTable dtPanel = Application["ExamPanel"] as DataTable;
        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
        if (chkPanel.Length > 0)
        {
            DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
            if (rowFillPanel.Length > 0)
            {
                rowFillPanel[0]["ORDER_DT"] = dr["ORDER_DT"];
                rowFillPanel[0]["EXAM_DT"] = dr["EXAM_DT"];
                rowFillPanel[0]["MODALITY_ID"] = dr["MODALITY_ID"];

                rowFillPanel[0]["SESSION_ID"] = dr["SESSION_ID"];
                rowFillPanel[0]["AVG_INV_TIME"] = dr["AVG_INV_TIME"];
                rowFillPanel[0]["START_DATETIME"] = dr["START_DATETIME"];
                rowFillPanel[0]["END_DATETIME"] = dr["END_DATETIME"];
                rowFillPanel[0]["strEXAM_DT"] = dr["strEXAM_DT"];

                rowsExam = dtAllExam.Select("EXAM_ID=" + rowFillPanel[0]["EXAM_ID"].ToString());
                clinic_value = "";
                _rate = "0";
                switch (drSch["CLINIC_TYPE"].ToString())
                {
                    case "Regular": clinic_value = "Normal";
                        _rate = rowsExam[0]["RATE"].ToString(); break;
                    case "Special": clinic_value = "Special";
                        _rate = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                    case "Premium": clinic_value = "VIP";
                        _rate = rowsExam[0]["VIP_RATE"].ToString(); break;
                    case "CNMI": clinic_value = "CNMI";
                        _rate = rowsExam[0]["RATE"].ToString(); break;

                }

                if (param.IS_NONRESIDENT)
                    _rate = rowsExam[0]["FOREIGN_RATE"].ToString();

                rowsClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + clinic_value + "'");
                rowFillPanel[0]["CLINIC_TYPE"] = rowsClinic[0]["CLINIC_TYPE_ID"];
                sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(dr["QTY"]);
                rowFillPanel[0]["TOTAL_RATE"] = sumrate.ToString("#.00");
                rowFillPanel[0]["RATE"] = _rate;
            }
        }

        dr["PRIORITY"] = "R";
        dr["PRIORITY_TEXT"] = "Routine";
    }
    private void set_FillWaitingListData(DataRow drr, DataTable dtModId)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtClinicType = Application["ClinicTypeData"] as DataTable;
        DataTable dtDept = Application["UnitData"] as DataTable;

        ScheduleClass sch = new ScheduleClass();
        RISBaseClass risbase = new RISBaseClass();

        DateTime dtStart = DateTime.Now;
        int session_id = sch.get_SessionID_ByAppointDate(dtStart, Convert.ToInt32(drr["CLINIC_TYPE"]));
        int avg_time = 5;

        int _modality_id = 0;
        if (dtModId.Rows.Count > 0)
            _modality_id = Convert.ToInt32(dtModId.Rows[0]["MODALITY_ID"]);
        else
            _modality_id = Convert.ToInt32(drr["MODALITY_ID"]);


        if (string.IsNullOrEmpty(drr["AVG_INV_TIME"].ToString()))
            avg_time = Convert.ToInt32(dtModId.Rows[0]["AVG_INV_TIME"]);
        else
            avg_time = Convert.ToInt32(drr["AVG_INV_TIME"]);
        drr["EXAM_DT"] = dtStart;
        if (drr["MODALITY_ID"].ToString() == "0")
            drr["MODALITY_ID"] = _modality_id;

        switch (drr["MODALITY_ID"].ToString())
        {
            case "155":
            case "156":
            case "157":
            case "158": session_id = 5; break;
            default:
                switch (session_id)
                {
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        session_id = 5;
                        break;
                }
                break;
        }


        switch (drr["MODALITY_ID"].ToString())
        {
            case "162":
            case "163": session_id = 13; break;
        }

        drr["SESSION_ID"] = session_id == 0 ? 5 : session_id;
        drr["START_DATETIME"] = dtStart.AddMinutes(-avg_time);
        drr["END_DATETIME"] = dtStart.AddSeconds(-1);
        drr["AVG_INV_TIME"] = avg_time;
        drr["strEXAM_DT"] = "Waiting list";

    }

    private DataTable set_AppointGridData(DataTable dt, bool IS_Length, DateTime date, string enc_clinic)
    {
        string strSession = "";
        string strModality = "";
        string strModlaityFilter = "";
        ScheduleClass sche = new ScheduleClass();
        RISBaseClass risbase = new RISBaseClass();
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtSessionTimeAll = Application["SessionTimeAll"] as DataTable;// sche.get_SessionTimeAll();
        DataTable dtSession = Application["SessionType"] as DataTable;// risbase.get_CLINICSESSION_TYPE();
        DataTable dtClinicType = Application["ClinicTypeData"] as DataTable;
        DataTable dtDept = Application["UnitData"] as DataTable;

        DataRow[] rowsession = dtSession.Select("SUBSTRING(session_uid,1,1)='" + enc_clinic.Substring(0, 1) + "'");//Fix CODE
        foreach (DataRow rowSe in rowsession)
            strSession += "," + rowSe["SESSION_ID"].ToString();

        DataTable dtModTemp = new DataTable();
        DataRow[] rowClinic = dtClinicType.Select("CLINIC_TYPE_ONLINEDESC like '" + enc_clinic + "%'");

        DataTable dtPatDest = risbase.get_PAT_DEST_ID(param.REF_UNIT_ID, Convert.ToInt32(rowClinic[0]["CLINIC_TYPE_ID"]));
        if (Utilities.IsHaveData(dtPatDest))
        {
            dtModTemp = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(param.EXAM_ID), Convert.ToInt32(dtPatDest.Rows[0]["PAT_DEST_ID"]), SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, enc_clinic));
            string _enc = enc_clinic.Substring(0, 1) == "P" ? "VIP" : "RGL";
            dtModTemp = Utilities.filterModalityByClinic(dtModTemp, _enc);

        }
        foreach (DataRow rowModFilter in dtModTemp.Rows)
            strModlaityFilter += "," + rowModFilter["MODALITY_ID"].ToString();

        if (strModlaityFilter.Length > 0)
        {
            if (enc_clinic.Substring(0, 1) == "P")
            {
                strSession = "";
                strModality = strModlaityFilter.Substring(1);
            }
            else
            {
                strModality = strModlaityFilter.Substring(1);
                strSession = string.Format("and RIS_CLINICSESSION.SESSION_ID in ({0})", strSession.Substring(1));
            }

            string str = QueryAppoint(strSession, strModality, IS_Length);

            DateTime dt_start = DateTime.Now.AddDays(1);// add 1 days
            int chkDate = date.CompareTo(dt_start);
            DateTime dtend = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            if (chkDate < 0)
                dtend = new DateTime(dt_start.Year, dt_start.Month, dt_start.Day, 23, 59, 59);

            DataTable dtSche = sche.get_ScheduleAppCount(str, dt_start, dtend);

            foreach (DataRow drChk in dtSche.Rows)
            {
                string strIsChilden = param.IS_CHILDEN ? "Y" : "N";
                string strSession2 = string.IsNullOrEmpty(drChk["SESSION_ID"].ToString()) ? "0" : drChk["SESSION_ID"].ToString();
                string timeFilter = "SESSION_ID=" + strSession2;
                timeFilter += " AND MODALITY_ID =" + drChk["MODALITY_ID"].ToString();
                timeFilter += " AND WEEKDAY=" + drChk["WEEKDAY"].ToString();
                timeFilter += " AND IS_CHILDREN = '" + strIsChilden + "'";
                DataView dvSessionTime = dtSessionTimeAll.DefaultView;
                dvSessionTime.RowFilter = timeFilter;
                DataTable dtSessionTime = dvSessionTime.ToTable();

                if (Utilities.IsHaveData(dtSessionTime))
                {
                    DateTime sessionDS = Convert.ToDateTime(dtSessionTime.Rows[0]["START_TIME"]);
                    DateTime sessionDE = Convert.ToDateTime(dtSessionTime.Rows[0]["END_TIME"]);
                    DateTime dt_end = Convert.ToDateTime(drChk["APP_DATE"]);
                    DateTime dtF = new DateTime(dt_end.Year, dt_end.Month, dt_end.Day, sessionDS.Hour, sessionDS.Minute, sessionDS.Second);
                    DateTime dtT = new DateTime(dt_end.Year, dt_end.Month, dt_end.Day, sessionDE.Hour, sessionDE.Minute, sessionDE.Second);
                    int avg_time = Convert.ToInt32(drChk["AVG_INV_TIME"]);

                    DataTable dttCheckSch = sche.get_ScheduleApp(dtF, dtT, Convert.ToInt32(drChk["MODALITY_ID"]));
                    dttCheckSch.Rows.Add(dtF, dtF);
                    dttCheckSch.Rows.Add(dtT, dtT);
                    dttCheckSch.AcceptChanges();
                    DataView dv = new DataView(dttCheckSch);
                    dv.Sort = "START_DATETIME,END_DATETIME";
                    dttCheckSch = dv.ToTable();
                    for (int i = 0; i < dttCheckSch.Rows.Count; i++)
                    {
                        int y = i + 1 < dttCheckSch.Rows.Count ? i + 1 : i;
                        DateTime date1 = Convert.ToDateTime(dttCheckSch.Rows[i]["END_DATETIME"]);
                        DateTime date2 = Convert.ToDateTime(dttCheckSch.Rows[y]["START_DATETIME"]);
                        double dateDiff = date2.TimeOfDay.TotalMinutes - date1.TimeOfDay.TotalMinutes;
                        double hoursDiff = date2.TimeOfDay.TotalHours - date1.TimeOfDay.TotalHours;
                        if (hoursDiff > 4)
                            break;
                        else if (dateDiff > avg_time)
                        {
                            if (sche.get_ScheduleAppCountDisplay(
                                Convert.ToInt32(drChk["MODALITY_ID"])
                                , date2
                                , drChk["SESSION_UID"].ToString()
                                ) == 1)
                            {
                                dt = set_AppointData(
                                    dt, date1.AddSeconds(1), date1.AddMinutes(avg_time),
                                    Convert.ToInt32(drChk["SESSION_ID"]), enc_clinic, Convert.ToInt32(drChk["MODALITY_ID"]),
                                    Convert.ToInt32(drChk["AVG_INV_TIME"]), drChk["SESSION_UID"].ToString());
                                if (dt.Rows.Count == SpecifyData.setShowRowAppointment())
                                {
                                    dt.DefaultView.Sort = "SCHEDULE_STARTDATE";
                                    return dt;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        if (!Utilities.IsHaveData(dt))
            dt = set_NullAppointData(dt, enc_clinic, "P");

        return dt;
    }
    private string QueryAppoint(string session, string modality, bool IS_Length)
    {
        string str = "";
        if (IS_Length)
        {
            str = @"    select RIS_MODALITY.MODALITY_ID,RIS_MODALITY.AVG_INV_TIME,RIS_CLINICSESSION.SESSION_ID,RIS_CLINICSESSION.SESSION_UID,CONVERT(datetime,
							convert(nvarchar(4),YEAR(app_date))+'-'+
							convert(nvarchar(2),MONTH(app_date))+'-'+
							convert(nvarchar(2),DAY(app_date))
							) as [APP_DATE],APP_COUNT,RIS_SESSIONAPPCOUNT.WEEKDAY from RIS_SESSIONAPPCOUNT inner join
                        RIS_MODALITY on RIS_SESSIONAPPCOUNT.MODALITY_ID = RIS_MODALITY.MODALITY_ID inner join
                        RIS_CLINICSESSION on RIS_SESSIONAPPCOUNT.SESSION_ID = RIS_CLINICSESSION.SESSION_ID
                        where APP_DATE between @APP_DATE_START and @APP_DATE_END
                        and RIS_MODALITY.MODALITY_ID in ({0})
                        {1}
                        and MAX_APP>APP_COUNT
                        and MAX_ONLINE_APP>ONLINE_APP_COUNT
                        and ISNULL(RIS_SESSIONAPPCOUNT.IS_BLOCKED,'N') = 'N'
                        order by APP_DATE desc,APP_COUNT 
                        ";
        }
        else
        {
            str = @"    
                        select RIS_MODALITY.MODALITY_ID,RIS_MODALITY.AVG_INV_TIME,RIS_CLINICSESSION.SESSION_ID,RIS_CLINICSESSION.SESSION_UID,CONVERT(datetime,
							convert(nvarchar(4),YEAR(app_date))+'-'+
							convert(nvarchar(2),MONTH(app_date))+'-'+
							convert(nvarchar(2),DAY(app_date))
							) as [APP_DATE],APP_COUNT,RIS_SESSIONAPPCOUNT.WEEKDAY from RIS_SESSIONAPPCOUNT inner join
                        RIS_MODALITY on RIS_SESSIONAPPCOUNT.MODALITY_ID = RIS_MODALITY.MODALITY_ID inner join
                        RIS_CLINICSESSION on RIS_SESSIONAPPCOUNT.SESSION_ID = RIS_CLINICSESSION.SESSION_ID
                        where DATEDIFF(DD,APP_DATE,@APP_DATE_END) < 0
                        and RIS_MODALITY.MODALITY_ID in ({0})
                        {1}
                        and MAX_APP>APP_COUNT
                        and MAX_ONLINE_APP>ONLINE_APP_COUNT
                        and ISNULL(RIS_SESSIONAPPCOUNT.IS_BLOCKED,'N') = 'N'
                        order by APP_DATE asc,APP_COUNT 
                        ";
        }
        str = string.Format(str, modality, session);
        return str;
    }
    private DataTable set_AppointData(DataTable dt, DateTime dt_start, DateTime dt_end,
                                        int Session_id, string ClinicType, int modality_id,
                                        int avg_time, string Session_uid)
    {
        DataRow[] rows = dt.Select("SCHEDULE_DESC = '" + dt_start.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat) + "'");
        if (rows.Length > 0)
        {
            switch (Session_uid.Substring(1))
            {
                case "M":
                    rows[0]["SCHEDULE_STARTDATE_M"] = dt_start;
                    rows[0]["SCHEDULE_ENDDATE_M"] = dt_end;
                    rows[0]["SESSION_ID_M"] = Session_id;
                    rows[0]["MODALITY_ID_M"] = modality_id;
                    rows[0]["AVG_INV_TIME_M"] = avg_time;
                    rows[0]["IS_ENABLE_M"] = "Y";
                    rows[0]["VALUE_M"] = rows[0]["SCHEDULE_ID"];
                    break;
                case "A":
                    rows[0]["SCHEDULE_STARTDATE_A"] = dt_start;
                    rows[0]["SCHEDULE_ENDDATE_A"] = dt_end;
                    rows[0]["SESSION_ID_A"] = Session_id;
                    rows[0]["MODALITY_ID_A"] = modality_id;
                    rows[0]["AVG_INV_TIME_A"] = avg_time;
                    rows[0]["IS_ENABLE_A"] = "Y";
                    rows[0]["VALUE_A"] = rows[0]["SCHEDULE_ID"];
                    break;
                case "E":
                    rows[0]["SCHEDULE_STARTDATE_E"] = dt_start;
                    rows[0]["SCHEDULE_ENDDATE_E"] = dt_end;
                    rows[0]["SESSION_ID_E"] = Session_id;
                    rows[0]["MODALITY_ID_E"] = modality_id;
                    rows[0]["AVG_INV_TIME_E"] = avg_time;
                    rows[0]["IS_ENABLE_E"] = "Y";
                    rows[0]["VALUE_E"] = rows[0]["SCHEDULE_ID"];
                    break;
            }
        }
        else
        {
            DataRow dr = dt.NewRow();
            dr["SCHEDULE_DESC_DATE"] = dt_start.ToString("dddd", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
            dr["SCHEDULE_DESC"] = dt_start.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
            dr["CLINIC_TYPE"] = ClinicType;
            dr["SCHEDULE_ID"] = dt.Rows.Count + 1;

            dr["SCHEDULE_STARTDATE"] = dt_start;
            dr["SCHEDULE_ENDDATE"] = dt_end;
            dr["SESSION_ID"] = Session_id;
            dr["MODALITY_ID"] = modality_id;
            dr["AVG_INV_TIME"] = avg_time;

            switch (Session_uid.Substring(1))
            {
                case "M":
                    dr["SCHEDULE_STARTDATE_M"] = dt_start;
                    dr["SCHEDULE_ENDDATE_M"] = dt_end;
                    dr["SESSION_ID_M"] = Session_id;
                    dr["MODALITY_ID_M"] = modality_id;
                    dr["AVG_INV_TIME_M"] = avg_time;
                    dr["IS_ENABLE_M"] = "Y";
                    dr["VALUE_M"] = dr["SCHEDULE_ID"];
                    break;
                case "A":
                    dr["SCHEDULE_STARTDATE_A"] = dt_start;
                    dr["SCHEDULE_ENDDATE_A"] = dt_end;
                    dr["SESSION_ID_A"] = Session_id;
                    dr["MODALITY_ID_A"] = modality_id;
                    dr["AVG_INV_TIME_A"] = avg_time;
                    dr["IS_ENABLE_A"] = "Y";
                    dr["VALUE_A"] = dr["SCHEDULE_ID"];
                    break;
                case "E":
                    dr["SCHEDULE_STARTDATE_E"] = dt_start;
                    dr["SCHEDULE_ENDDATE_E"] = dt_end;
                    dr["SESSION_ID_E"] = Session_id;
                    dr["MODALITY_ID_E"] = modality_id;
                    dr["AVG_INV_TIME_E"] = avg_time;
                    dr["IS_ENABLE_E"] = "Y";
                    dr["VALUE_E"] = dr["SCHEDULE_ID"];
                    break;
            }

            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }
        return dt;
    }
    private DataTable set_NullAppointData(DataTable dt, string ClinicType, string strCase)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        dt = new DataTable();
        dt.Columns.Add("SCHEDULE_DESC_DATE");
        dt.Columns.Add("SCHEDULE_DESC");
        dt.Columns.Add("CLINIC_TYPE");
        dt.Columns.Add("SCHEDULE_ID", typeof(int));

        dt.Columns.Add("SCHEDULE_STARTDATE", typeof(DateTime));
        dt.Columns.Add("SCHEDULE_ENDDATE", typeof(DateTime));
        dt.Columns.Add("SESSION_ID", typeof(int));
        dt.Columns.Add("MODALITY_ID", typeof(int));
        dt.Columns.Add("AVG_INV_TIME", typeof(int));

        dt.Columns.Add("SCHEDULE_STARTDATE_M", typeof(DateTime));
        dt.Columns.Add("SCHEDULE_ENDDATE_M", typeof(DateTime));
        dt.Columns.Add("SESSION_ID_M", typeof(int));
        dt.Columns.Add("MODALITY_ID_M", typeof(int));
        dt.Columns.Add("AVG_INV_TIME_M", typeof(int));
        dt.Columns.Add("IS_CHECKED_M");
        dt.Columns.Add("IS_ENABLE_M");
        dt.Columns.Add("VALUE_M");

        dt.Columns.Add("SCHEDULE_STARTDATE_A", typeof(DateTime));
        dt.Columns.Add("SCHEDULE_ENDDATE_A", typeof(DateTime));
        dt.Columns.Add("SESSION_ID_A", typeof(int));
        dt.Columns.Add("MODALITY_ID_A", typeof(int));
        dt.Columns.Add("AVG_INV_TIME_A", typeof(int));
        dt.Columns.Add("IS_CHECKED_A");
        dt.Columns.Add("IS_ENABLE_A");
        dt.Columns.Add("VALUE_A");

        dt.Columns.Add("SCHEDULE_STARTDATE_E", typeof(DateTime));
        dt.Columns.Add("SCHEDULE_ENDDATE_E", typeof(DateTime));
        dt.Columns.Add("SESSION_ID_E", typeof(int));
        dt.Columns.Add("MODALITY_ID_E", typeof(int));
        dt.Columns.Add("AVG_INV_TIME_E", typeof(int));
        dt.Columns.Add("IS_CHECKED_E");
        dt.Columns.Add("IS_ENABLE_E");
        dt.Columns.Add("VALUE_E");
        dt.AcceptChanges();

        DataRow dr = dt.NewRow();
        DateTime dt_start = DateTime.Now;
        DateTime dt_end = dt_start.AddMinutes(-10);
        dr["SCHEDULE_DESC_DATE"] = "";
        if (strCase == "P")
            dr["SCHEDULE_DESC"] = "เปลี่ยนสถานะเป็น Urgent เพื่อส่ง Waiting list";
        else
            dr["SCHEDULE_DESC"] = "กรุณาระบุช่วงเวลาที่ต้องการนัดแล้วกดปุ่ม Save order";
        dr["CLINIC_TYPE"] = ClinicType;
        dr["SCHEDULE_ID"] = dt.Rows.Count + 1;

        dr["SCHEDULE_STARTDATE"] = dt_start;
        dr["SCHEDULE_ENDDATE"] = dt_end;
        dr["SESSION_ID"] = 0;
        dr["MODALITY_ID"] = 0;
        dr["AVG_INV_TIME"] = 0;

        dr["SCHEDULE_STARTDATE_M"] = dt_start;
        dr["SCHEDULE_ENDDATE_M"] = dt_end;
        dr["SESSION_ID_M"] = 0;
        dr["MODALITY_ID_M"] = 0;
        dr["AVG_INV_TIME_M"] = 0;
        dr["VALUE_M"] = "N";

        dr["SCHEDULE_STARTDATE_A"] = dt_start;
        dr["SCHEDULE_ENDDATE_A"] = dt_end;
        dr["SESSION_ID_A"] = 0;
        dr["MODALITY_ID_A"] = 0;
        dr["AVG_INV_TIME_A"] = 0;
        dr["VALUE_A"] = "N";

        dr["SCHEDULE_STARTDATE_E"] = dt_start;
        dr["SCHEDULE_ENDDATE_E"] = dt_end;
        dr["SESSION_ID_E"] = 0;
        dr["MODALITY_ID_E"] = 0;
        dr["AVG_INV_TIME_E"] = 0;
        dr["VALUE_E"] = "N";
        dt.Rows.Add(dr);
        dt.AcceptChanges();

        switch (ClinicType)
        {
            case "Regular": param.dvAppoint = dt.Clone(); break;
            case "Special": param.dvAppointSP = dt.Clone(); break;
            case "Premium": param.dvAppointPM = dt.Clone(); break;
            case "CNMI": param.dvAppointCNMI = dt.Clone(); break;

        }
        return dt;
    }
    #endregion
    #region Clinical Indication page
    private void BindingTreeview()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        RISBaseClass ris_base = new RISBaseClass();
        DataTable dtIndDefault = new DataTable();
        DataSet dsInd = new DataSet();
        DataSet dsIndType = new DataSet();
        DataTable dtIndType = new DataTable();
        DataTable dtIndTypeFav = new DataTable();
        DataTable dtIndTypeLast = new DataTable();
        DataTable dtInd = new DataTable();
        DataTable dtIndFav = new DataTable();
        DataTable dtIndLast = new DataTable();

        ris_base.RIS_CLINICALINDICATIONTYPE.EMP_ID = env.UserID;
        ris_base.RIS_CLINICALINDICATIONTYPE.ORG_ID = env.OrgID;
        ris_base.RIS_CLINICALINDICATION.EMP_ID = env.UserID;
        ris_base.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;

        #region Preparing Indication Type data
        dsIndType = ris_base.get_RIS_CLINICALINDICATIONTYPE(env.OrgID, env.UserID);
        dtIndType = dsIndType.Tables[1];
        dtIndType.Merge(dsIndType.Tables[2].Copy());//Add by user
        dtIndTypeLast = dsIndType.Tables[3];
        #endregion

        #region Preparing Indication data
        int ref_unit_id = param.REF_UNIT_ID == null ? 0 : param.REF_UNIT_ID;
        dtIndDefault = ris_base.get_RIS_CLINICALINDICATION_WITH_UNIT(env.OrgID, ref_unit_id);
        dtIndFav = ris_base.get_RIS_CLINICALINDICATIONFAVORITE();
        dsInd = ris_base.get_RIS_CLINICALINDICATION(env.OrgID, env.UserID);

        dtInd = dtIndFav.Rows.Count > 0 ? dtIndFav : dtIndDefault;
        dtInd.Merge(checkDataClinicalIndicationID(dtInd, dsInd.Tables[2].Copy()));//Add by user
        dtIndLast = dsInd.Tables[3];
        #endregion

        dtIndTypeFav = ris_base.get_RIS_CLINICALINDICATIONTYPEFAVORITE();

        param.dtOrderClinicalIndication = ris_base.get_RIS_ORDERCLINICALINDICATION(Convert.ToInt32(param.ORDER_ID), Convert.ToInt32(param.SCHEDULE_ID));
        param.dtOrderClinicalIndicationType = ris_base.get_RIS_ORDERCLINICALINDICATIONTYPE(Convert.ToInt32(param.ORDER_ID), Convert.ToInt32(param.SCHEDULE_ID));

        param.dtCLINICALINDICATIONTYPE = dtIndType;
        param.dtCLINICALINDICATION = dtInd;
        param.dtCLINICALINDICATIONTYPEFAVORITE = dtIndTypeFav;
        param.dtCLINICALINDICATIONFAVORITE = dtIndFav;
        param.dtCLINICALINDICATIONLASTVISIT = dtIndLast;
        param.dtCLINICALINDICATIONTYPELASTVISIT = dtIndTypeLast;

        treeIndicationTypeView.DataFieldID = "CI_TYPE_ID";
        treeIndicationTypeView.DataFieldParentID = "PARENT_ID";
        treeIndicationTypeView.DataTextField = "CI_DESC";
        treeIndicationTypeView.DataSource = dtIndType;
        treeIndicationTypeView.DataBind();

        treeIndicationView.DataFieldID = "CI_ID";
        treeIndicationView.DataFieldParentID = "CI_PARENT";
        treeIndicationView.DataTextField = "CI_DESC";
        treeIndicationView.DataSource = dtInd;
        treeIndicationView.DataBind();

        Session["ONL_PARAMETER"] = param;
    }
    private DataTable checkDataClinicalIndicationID(DataTable dtMain, DataTable dtCheck)
    {
        DataTable result = new DataTable();
        result = dtCheck.Clone();

        foreach (DataRow rows in dtCheck.Rows)
        {
            string _ci_parent = string.IsNullOrEmpty(rows["CI_PARENT"].ToString()) ? "0" : rows["CI_PARENT"].ToString();
            DataRow[] arryRow = dtMain.Select("CI_ID=" + _ci_parent);
            if (arryRow.Length > 0)
            {
                result.Rows.Add(rows.ItemArray);
                result.AcceptChanges();
            }
        }

        return result;
    }
    private DataTable getClinicalIndicationWithUnit(int unit_id)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        return ris_base.get_RIS_CLINICALINDICATION_WITH_UNIT(env.OrgID, unit_id);
    }
    private void JustBindingClinicalIndicationTypeTreeview()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        RISBaseClass ris_base = new RISBaseClass();
        DataSet dsIndType = new DataSet();
        DataTable dtIndType = new DataTable();
        DataTable dtIndTypeFav = new DataTable();

        ris_base.RIS_CLINICALINDICATIONTYPE.EMP_ID = env.UserID;
        ris_base.RIS_CLINICALINDICATIONTYPE.ORG_ID = env.OrgID;
        ris_base.RIS_CLINICALINDICATION.EMP_ID = env.UserID;
        ris_base.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;

        dsIndType = ris_base.get_RIS_CLINICALINDICATIONTYPE(env.OrgID, env.UserID);
        dtIndType = dsIndType.Tables[1];
        dtIndType.Merge(dsIndType.Tables[2].Copy());//Add by user

        dtIndTypeFav = ris_base.get_RIS_CLINICALINDICATIONTYPEFAVORITE();

        param.dtCLINICALINDICATIONTYPE = dtIndType;
        param.dtCLINICALINDICATIONTYPEFAVORITE = dtIndTypeFav;

        treeIndicationTypeView.DataFieldID = "CI_TYPE_ID";
        treeIndicationTypeView.DataFieldParentID = "PARENT_ID";
        treeIndicationTypeView.DataTextField = "CI_DESC";
        treeIndicationTypeView.DataSource = dtIndType;
        treeIndicationTypeView.DataBind();

        Session["ONL_PARAMETER"] = param;
    }

    protected void treeIndicationTypeView_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        RISBaseClass risbase = new RISBaseClass();

        if (e.MenuItem.Value == "addClinical")
        {
            Session["treeIndicationTypeView"] = treeIndicationTypeView;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "windowCreateNewClinical", "showNormalAlert('createNewClinicalIndicationType');", true);
        }
        else if (e.MenuItem.Value == "delClinical")
        {
            risbase.RIS_CLINICALINDICATIONTYPE.EMP_ID = env.UserID;
            risbase.RIS_CLINICALINDICATIONTYPE.ORG_ID = env.OrgID;

            DataTable dt = param.dtCLINICALINDICATIONTYPE;
            IList<RadTreeNode> nodeCollection = treeIndicationTypeView.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                DataRow[] rows = dt.Select("CI_DESC='" + node.Text + "'");
                DataRow[] rowSub = dt.Select("PARENT_ID=" + rows[0]["CI_TYPE_ID"].ToString());
                foreach (DataRow dr in rowSub)
                {
                    risbase.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = Convert.ToInt32(dr["CI_TYPE_ID"]);
                    risbase.set_RIS_CLINICALINDICATIONTYPE_Delete();
                }
                foreach (DataRow drr in rows)
                {
                    risbase.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = Convert.ToInt32(drr["CI_TYPE_ID"]);
                    risbase.set_RIS_CLINICALINDICATIONTYPE_Delete();
                }
            }
            JustBindingClinicalIndicationTypeTreeview();
        }
        else
        {

            risbase.RIS_CLINICALINDICATIONTYPE.EMP_ID = env.UserID;
            risbase.RIS_CLINICALINDICATIONTYPE.ORG_ID = env.OrgID;
            risbase.RIS_CLINICALINDICATIONTYPE.CREATED_BY = env.UserID;

            DataTable dt = param.dtCLINICALINDICATIONTYPE;
            IList<RadTreeNode> nodeCollection = treeIndicationTypeView.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                string[] strNode = node.FullPath.Split('/');
                string strParent = "";
                for (int i = 0; i < strNode.Length; i++)
                {
                    DataRow[] rows;
                    if (i == 0)
                        rows = dt.Select("CI_DESC='" + strNode[i].ToString() + "'");
                    else
                        rows = dt.Select("CI_DESC='" + strNode[i].ToString() + "' and PARENT_ID='" + strParent + "'");
                    risbase.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = Convert.ToInt32(rows[0]["CI_TYPE_ID"]);
                    risbase.set_RIS_CLINICALINDICATIONTYPEFAVORITE_Insert();
                    strParent = rows[0]["CI_TYPE_ID"].ToString();
                }

            }
        }

        DataTable dtt = new DataTable();
        dtt = risbase.get_RIS_CLINICALINDICATIONTYPEFAVORITE();
        param.dtCLINICALINDICATIONTYPEFAVORITE = dtt;
        Session["ONL_PARAMETER"] = param;
    }
    protected void treeIndicationView_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (e.MenuItem.Value == "addBasicIndication")
        {
            RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
            if (cmbRefUnit.SelectedValue != "")
                param.REF_UNIT_ID = Convert.ToInt32(cmbRefUnit.SelectedValue);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openBasicIndication", "showBasicIndication();", true);
        }
        else if (e.MenuItem.Value == "createSelfIndication")
        {
            Session["treeIndicationView"] = treeIndicationView;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "windowCreateNewClinical", "showNormalAlert('createNewClinicalIndication');", true);
        }
        else if (e.MenuItem.Value == "removeIndication")
        {
            RISBaseClass risbase = new RISBaseClass();
            risbase.RIS_CLINICALINDICATION.EMP_ID = env.UserID;
            risbase.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;

            DataTable dt = param.dtCLINICALINDICATION;
            IList<RadTreeNode> nodeCollection = treeIndicationView.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                DataRow[] rows = dt.Select("CI_DESC='" + node.Text + "'");
                DataRow[] rowSub = dt.Select("CI_PARENT=" + rows[0]["CI_ID"].ToString());
                foreach (DataRow dr in rowSub)
                {
                    risbase.RIS_CLINICALINDICATION.CI_ID = Convert.ToInt32(dr["CI_ID"]);
                    risbase.set_RIS_CLINICALINDICATION_Delete();
                }
                foreach (DataRow drr in rows)
                {
                    risbase.RIS_CLINICALINDICATION.CI_ID = Convert.ToInt32(drr["CI_ID"]);
                    risbase.set_RIS_CLINICALINDICATION_Delete();
                }
            }

            BindingTreeview();
        }
    }

    protected void treeIndicationTypeView_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
        if (e.Node.Checked)
            data.Remove(e.Node.FullPath);
        else
            data.Add(e.Node.FullPath);
        e.Node.Checked = !e.Node.Checked;

        if (e.Node.Checked)
            fillinEditorType(e.Node);
        param.TEMP_CLINICALINDICATIONTYPE = data;
        Session["ONL_PARAMETER"] = param;
        Session["nodeIndicationTypeFocus"] = e.Node;
    }
    protected void treeIndicationTypeView_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
        if (e.Node.Checked)
            data.Add(e.Node.FullPath);
        else
            data.Remove(e.Node.FullPath);
        e.Node.Checked = e.Node.Checked;

        if (e.Node.Checked)
            fillinEditorType(e.Node);
        param.TEMP_CLINICALINDICATIONTYPE = data;
        Session["ONL_PARAMETER"] = param;
    }
    protected void treeIndicationTypeView_NodeCreated(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode node = e.Node;
        if (node.ParentNode != null)
            node.ParentNode.Checkable = false;

    }
    protected void treeIndicationTypeView_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadTreeNode node = e.Node;
        if (!string.IsNullOrEmpty(node.FullPath))
        {
            RISBaseClass baseOrder = new RISBaseClass();
            int ci_type_id = baseOrder.get_CITypeID_ClinicalIndicationType(node.FullPath);
            if (param.dvGridDtl.Rows.Count > 0)
                if (param.dtOrderClinicalIndicationType.Rows.Count > 0)
                {
                    DataRow[] rows = param.dtOrderClinicalIndicationType.Select("CI_TYPE_ID=" + ci_type_id.ToString());
                    if (rows.Length > 0)
                    {
                        node.Checked = true;
                        node.ExpandParentNodes();
                        bool flag = true;
                        foreach (string str in param.TEMP_CLINICALINDICATIONTYPE)
                            if (str == node.FullPath)
                                flag = false;
                        if (flag)
                            param.TEMP_CLINICALINDICATIONTYPE.Add(node.FullPath);
                    }
                }
            //if (param.dtCLINICALINDICATIONLASTVISIT.Rows.Count > 0)
            //{
            //    DataRow[] rows = param.dtCLINICALINDICATIONTYPELASTVISIT.Select("CI_TYPE_ID=" + ci_type_id.ToString());
            //    if (rows.Length > 0)
            //        node.ExpandParentNodes();
            //}
        }
        Session["ONL_PARAMETER"] = param;
    }

    protected void treeIndicationView_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATION;
        if (e.Node.Checked)
            data.Remove(e.Node.FullPath);
        else
            data.Add(e.Node.FullPath);
        e.Node.Checked = !e.Node.Checked;

        if (e.Node.Checked)
            fillinEditor(e.Node);
        param.TEMP_CLINICALINDICATION = data;
        Session["ONL_PARAMETER"] = param;
        Session["nodeIndicationFocus"] = e.Node;
    }
    protected void treeIndicationView_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATION;
        if (e.Node.Checked)
            data.Add(e.Node.FullPath);
        else
            data.Remove(e.Node.FullPath);
        e.Node.Checked = e.Node.Checked;

        if (e.Node.Checked)
            fillinEditor(e.Node);
        param.TEMP_CLINICALINDICATION = data;
        Session["ONL_PARAMETER"] = param;
    }
    protected void treeIndicationView_NodeCreated(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode node = e.Node;
        if (node.ParentNode != null)
            node.ParentNode.Checkable = false;
    }
    protected void treeIndicationView_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadTreeNode node = e.Node;
        if (!string.IsNullOrEmpty(node.FullPath))
        {
            RISBaseClass baseOrder = new RISBaseClass();
            int ci_id = baseOrder.get_CIID_ClinicalIndication(node.FullPath);
            if (param.dvGridDtl.Rows.Count > 0)
                if (param.dtOrderClinicalIndication.Rows.Count > 0)
                {
                    DataRow[] rows = param.dtOrderClinicalIndication.Select("CI_ID=" + ci_id.ToString());
                    if (rows.Length > 0)
                    {
                        node.Checked = true;
                        node.ExpandParentNodes();
                        bool flag = true;
                        foreach (string str in param.TEMP_CLINICALINDICATION)
                            if (str == node.FullPath)
                                flag = false;
                        if (flag)
                            param.TEMP_CLINICALINDICATION.Add(node.FullPath);
                    }
                }
            if (param.dtCLINICALINDICATIONLASTVISIT.Rows.Count > 0)
            {
                DataRow[] rows = param.dtCLINICALINDICATIONLASTVISIT.Select("CI_ID=" + ci_id.ToString());
                if (rows.Length > 0)
                    node.ExpandParentNodes();
            }
        }
        Session["ONL_PARAMETER"] = param;
    }

    private void fillinEditor(RadTreeNode data)
    {
        if (data.Checkable)
        {
            string s = data.Text;
            //RadTreeNode currentObject = data.ParentNode;
            //int i = 0;
            //while (i < data.Level)
            //{
            //    if (data.ParentNode != null)
            //        s = currentObject.Text + " : " + s;
            //    currentObject = currentObject.ParentNode;
            //    i++;
            //}
            if (string.IsNullOrEmpty(txtEditor.Text))
                txtEditor.Text = s + "  \r\n";
            else
                txtEditor.Text = txtEditor.Text + s + "  \r\n";
        }
    }
    private void fillinEditorType(RadTreeNode data)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (data.Checkable)
        {
            string s = data.Text;
            //RadTreeNode currentObject = data.ParentNode;
            //int i = 0;
            //while (i < data.Level)
            //{
            //    if (data.ParentNode != null)
            //        s = currentObject.Text + " : " + s;
            //    currentObject = currentObject.ParentNode;
            //    i++;
            //}

            RISBaseClass ord = new RISBaseClass();
            DataTable dtCItype = param.dtCLINICALINDICATIONTYPE;
            int ciid = ord.get_CITypeID_ClinicalIndicationType(data.FullPath);

            DataRow[] rowCItype = dtCItype.Select("CI_TYPE_ID=" + ciid.ToString());
            if (rowCItype.Length > 0)
                if (!string.IsNullOrEmpty(rowCItype[0]["DEFAULT_TEXT"].ToString()))
                    s = s + " : " + rowCItype[0]["DEFAULT_TEXT"].ToString();

            if (string.IsNullOrEmpty(txtEditor.Text))
                txtEditor.Text = s + "  \r\n";
            else
                txtEditor.Text = txtEditor.Text + s + "  \r\n";

        }
    }
    #endregion
    #region Button open Normal Page
    protected void btnCR_Click(object sender, EventArgs e)
    {
        showNormalPage("tabCR");
    }
    protected void btnUS_Click(object sender, EventArgs e)
    {
        showNormalPage("tabUS");
    }
    protected void btnCT_Click(object sender, EventArgs e)
    {
        showNormalPage("tabCT");
    }
    protected void btnFLU_Click(object sender, EventArgs e)
    {
        showNormalPage("tabFLU");
    }
    protected void btnMR_Click(object sender, EventArgs e)
    {
        showNormalPage("tabMR");
    }
    protected void btnMAMMO_Click(object sender, EventArgs e)
    {
        showNormalPage("tabMAMMO");
    }
    protected void btnOR_Click(object sender, EventArgs e)
    {
        showNormalPageAllGroup("OR");
    }
    protected void btnOPD_Click(object sender, EventArgs e)
    {
        showNormalPageAllGroup("OPD");
    }
    #endregion
    private DataTable set_DistinctTable(DataTable dt, string[] column)
    {
        DataView view = new DataView(dt);
        DataTable distinctValues = view.ToTable(true, column);
        return distinctValues;
    }
    private void get_AllRowFilter(RadGrid radGridData, DataTable dt, string _search)
    {
        StringBuilder sb = new StringBuilder();
        foreach (DataColumn col in dt.Columns)
            if (col.DataType.Name == "String")
                sb.Append(col.Caption + " like '%" + _search + "%' \r\n OR ");

        sb.Remove(sb.ToString().LastIndexOf("OR"), 3);
        DataRow[] rows = dt.Select(sb.ToString());
        fillDataGrid_Filter(radGridData, Utilities.arrayRowsToDataTable(dt.Clone(), rows));
    }
    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    #region Update Busy
    private void updateBusy()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        string strorder_id = param.ORDER_ID == null ? "0" : param.ORDER_ID;
        string strschedule_id = param.SCHEDULE_ID == null ? "0" : param.SCHEDULE_ID;

        if (!(strorder_id == "0" && strschedule_id == "0"))
        {
            updateBusyCase(strorder_id != "0" ? "XRAYREQ" : "SCHEDULE",
                        Convert.ToInt32(strorder_id),
                        Convert.ToInt32(strschedule_id),
                        "N"
                        );
        }
    }
    private void updateBusyCase(string mode, int orderId, int scheduleId, string busy)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        switch (mode)
        {
            case "SCHEDULE":
                ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
                proc.RIS_SCHEDULE.IS_BUSY = busy;
                proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                proc.UpdateBusy();
                break;
            case "XRAYREQ":
                ProcessUpdateXRAYREQ xryReq = new ProcessUpdateXRAYREQ();
                xryReq.updateLockCase(orderId, busy, env.UserID);
                break;
        }
    }
    #endregion
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDept = Application["UnitData"] as DataTable;

        DataTable dt = new DataTable();
        DataTable dtFav = new DataTable();
        DataTable dtTop10 = new DataTable();
        string str = "";
        switch (e.Argument)
        {
            #region Grid
            case "DeleteOrder":
                dt = param.dvGrid;
                break;
            case "Rebind":
                dt = param.dvGridDtlRebind;
                param.dvGridDtl = dt;
                DataRow[] rows = dt.Select("EXAM_ID=" + param.EXAM_ID);

                fillDataGrid_Filter(grdDetail, dt);
                break;
            case "RebindFromNormalPage":
                dt = param.dvGridDtl;
                fillDataGrid_Filter(grdDetail, dt);
                dtFav = param.dvExamFavorite;
                fillDataGrid_Filter(grdExamFavorite, dtFav);
                dtTop10 = param.dvExamTop10;
                fillDataGrid_Filter(grdExamTop10, dtTop10);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["NEED_SCHEDULE"].ToString() == "Y")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabAppointment','" + param.CLINIC_TYPE + "');", true);
                    }
                }
                break;
            case "CancelFromNormalPage":
                dt = param.dvGridDtl;
                fillDataGrid_Filter(grdDetail, dt);
                break;
            case "Loading":
                setPageMain();
                break;
            case "checkAppointmentUS":
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('tabAppointment','" + param.CLINIC_TYPE + "');", true);
                    break;
                }
            case "checkAppointment":
                if (!string.IsNullOrEmpty(param.EXAM_ID))
                {
                    DataTable dtMod_ID = param.dtMod_ID;
                    DataTable dtDetail = param.dvGridDtl;
                    DataRow[] drDetail = dtDetail.Select("EXAM_ID=" + param.EXAM_ID);
                    if (drDetail.Length > 0)
                        checkAppointment(drDetail[0]);

                    DataTable dtAllExam = new DataTable();
                    dtAllExam = Application["ExamAllData"] as DataTable;
                    addExamPanel(dtAllExam, param.EXAM_ID.ToString());

                    if (param.QUICKEXAM_MODE == "WAITING")
                        addCommentWord("# ขอคิวนัดก่อนพบแพทย์ #", param.QUICKEXAM_ID.ToString());
                }
                else
                {
                    return;
                }
                break;
            #endregion
            #region Popup
            case "SaveOrder":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                    set_SaveOrder();
                break;
            case "RiskManagement":
                set_SaveOrder();
                break;
            case "COVID":
                txtEditor.Text = param.REF_DOC_INSTRUCTION;
                checkParameterInsert_RiskManagement();
                break;
            case "ClinicalIndicationWithParam":
                txtEditor.Text = param.REF_DOC_INSTRUCTION;
                checkParameterInsert_RiskManagement();
                break;
            case "Holiday":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    checkParameterInsert_RiskManagement();
                }
                break;
            case "AddFavoriteExam":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    Hashtable values = Session["HashtableAddFavoriteExam"] as Hashtable;
                    addExamFavorite(values);
                }
                break;
            case "RemoveExamFavorite":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    Hashtable values = Session["HashtableAddFavoriteExam"] as Hashtable;
                    deleteExamFavorite(values);
                }
                break;
            case "checkAppointCase":
                str = Session["MessageBoxValue"] as string;
                dt = param.dvGridDtl;
                if (str == "3")
                {
                    foreach (DataRow drr in dt.Rows)
                    {
                        if (drr["strEXAM_DT"].ToString().IndexOf("Pending") >= 0 || drr["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
                        {
                            DataTable dtt = new DataTable();
                            RISBaseClass risbase = new RISBaseClass();
                            DataTable dtMod_id = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(drr["EXAM_ID"]), Convert.ToInt32(drr["PAT_DEST_ID"]), SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
                            dtMod_id = Utilities.filterModalityByClinic(dtMod_id, param.ENC_CLINIC);

                            setAppointment(drr);
                            switch (param.CLINIC_TYPE)
                            {
                                case "Normal": dtt = param.dvAppoint; break;
                                case "Special": dtt = param.dvAppointSP; break;
                                case "VIP": dtt = param.dvAppointPM; break;
                            }
                            if (Utilities.IsHaveData(dtt))
                            {
                                if (!string.IsNullOrEmpty(dtt.Rows[0]["SCHEDULE_DESC_DATE"].ToString()))
                                    set_FillAppointData(drr, dtt);
                                else
                                    set_FillWaitingListData(drr, dtMod_id);
                            }
                            else
                                showOnlineMessageBox("alertCannotInsertAppointment");
                        }
                    }
                    setInsertOnline();
                    setPageMain();
                }
                else if (str == "2")
                {
                    RISBaseClass risbase = new RISBaseClass();
                    foreach (DataRow drr in dt.Rows)
                    {
                        if (drr["strEXAM_DT"].ToString().IndexOf("Pending") >= 0 || drr["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0)
                        {
                            DataTable dtMod_id = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(drr["EXAM_ID"]), Convert.ToInt32(drr["PAT_DEST_ID"]), SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
                            dtMod_id = Utilities.filterModalityByClinic(dtMod_id, param.ENC_CLINIC);

                            set_FillWaitingListData(drr, dtMod_id);
                        }
                    }
                    setInsertOnline();
                    setPageMain();
                }
                break;
            case "ClinicalPopup":
                if (string.IsNullOrEmpty(txtEditor.Text))
                    txtEditor.Text = Session["ClinicalPopup"].ToString() + "  \r\n";
                else
                    txtEditor.Text = txtEditor.Text + Session["ClinicalPopup"].ToString() + "  \r\n";
                break;
            case "checkRefDoc":
                RadComboBox cmbRefDoc = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
                if (cmbRefDoc.Text.Length <= 0)
                    cmbRefDoc.OpenDropDownOnLoad = true;
                break;
            case "checkRefUnit":
                RadComboBox cmbRefUnit = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
                cmbRefUnit.OpenDropDownOnLoad = true;
                break;
            case "createdClinicalIndication":
                BindingTreeview();
                break;
            case "createdClinicalIndicationType":
                JustBindingClinicalIndicationTypeTreeview();
                break;
            case "RebindBasicClinicalIndication":
                BindingTreeview();
                break;
            #endregion
            case "LOGIN":
                BindingPatientData();
                break;
            case "txtExamSearch":
                dt = Application["ExamData"] as DataTable;
                break;
            case "ShowalertExam":
                List<string> clickedButton = Session["AddExam"] as List<string>;
                if (Session["MessageBoxAlertexamValue"].ToString().ToLower() == "save")
                {
                    addExamDetail(clickedButton[0].ToString(), clickedButton[1].ToString());
                }
                break;
            default:
                string[] strCheck = e.Argument.Split(',');
                if (strCheck.Length > 1)
                {
                    switch (strCheck[0].ToString())
                    {
                        case "getAppointment":
                            RISBaseClass risbase = new RISBaseClass();
                            DataTable dtDetail = param.dvGridDtl;
                            param.EXAM_ID = strCheck[1].ToString();
                            DataRow[] drDetail = dtDetail.Select("EXAM_ID=" + param.EXAM_ID);
                            DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(param.EXAM_ID), Convert.ToInt32(drDetail[0]["PAT_DEST_ID"]), SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
                            dtMod_ID = Utilities.filterModalityByClinic(dtMod_ID, param.ENC_CLINIC);
                            if (drDetail.Length > 0)
                                checkAppointment(drDetail[0]);
                            break;
                        case "doubleClickEditExam":
                            DataTable dtPanel = Application["ExamPanel"] as DataTable;
                            dt = param.dvGridDtl;
                            DataRow[] chkPanel = dtPanel.Select("AUTO_EXAM_ID=" + strCheck[1].ToString());
                            if (chkPanel.Length > 0)
                            {
                                foreach (DataRow rowPanel in chkPanel)
                                {
                                    DataRow[] chkRows = dt.Select("EXAM_ID=" + rowPanel["EXAM_ID"].ToString());
                                    if (chkRows.Length > 0)
                                    {
                                        DataTable dtAlert = new DataTable();
                                        dtAlert.Columns.Add("ALT_TEXT");
                                        dtAlert.Columns.Add("ALT_BUTTON");
                                        dtAlert.Columns.Add("CAPTION_BTN1");
                                        dtAlert.Columns.Add("CAPTION_BTN2");
                                        dtAlert.Columns.Add("CAPTION_BTN3");
                                        dtAlert.Columns.Add("ALT_TYPE");
                                        dtAlert.AcceptChanges();
                                        dtAlert.Rows.Add("กรุณาแก้ไขข้อมูลที่ \r\n" + chkRows[0]["EXAM_NAME"].ToString()
                                                        , 1, "ตกลง", "", "", "W");
                                        dtAlert.AcceptChanges();
                                        Session["dtAlert"] = dtAlert;
                                        showOnlineMessageBox("ManualPopup");
                                    }
                                }
                            }
                            else
                            {
                                bool flag = true;
                                RadComboBox cmbRefDocCheck = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefDoc") as RadComboBox;
                                if (cmbRefDocCheck.Text.Length <= 0)
                                    cmbRefDocCheck.OpenDropDownOnLoad = true;
                                if (string.IsNullOrEmpty(cmbRefDocCheck.Text))
                                {
                                    flag = false;
                                    showOnlineMessageBox("checkRefDoc");
                                }
                                if (flag)
                                {
                                    RadComboBox cmbRefUnitCheck = rtbDemographic.FindItemByValue("groupDemographic").FindControl("cmbRefUnit") as RadComboBox;
                                    if (cmbRefUnitCheck.Text.Length <= 0)
                                        cmbRefUnitCheck.OpenDropDownOnLoad = true;
                                    if (string.IsNullOrEmpty(cmbRefUnitCheck.Text))
                                    {
                                        flag = false;
                                        showOnlineMessageBox("checkRefUnit");
                                    }
                                }
                                if (flag)
                                {
                                    param.dtBasicData = setOrderTemplate();
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + strCheck[1].ToString() + "');", true);
                                }
                            }
                            break;
                        default:
                            param.EXAM_ID = strCheck[1].ToString();
                            addExamDetail(strCheck[0].ToString(), strCheck[1].ToString()); break;
                    }

                }
                break;
        }

        Session["ONL_PARAMETER"] = param;
    }
}