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
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using System.Globalization;
using System.Collections.Generic;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class OnlineClinicalIndicationPopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ClinicalPopup"] = null;
            if (Request.Params["TEXT"] != null)
                txtEditor.Text = Request.Params["TEXT"].Trim();
            else
                txtEditor.Text = string.Empty;

            if (Request.Params["EXAM_ID"] != null)
            {
                GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
                ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

                DataTable dtExamAll = Application["ExamAllData"] as DataTable;
                DataRow[] chkRows = dtExamAll.Select("EXAM_ID=" + Request.Params["EXAM_ID"].ToString());
                lblExam.Text = chkRows[0]["EXAM_UID"].ToString() + " : " + chkRows[0]["EXAM_NAME"].ToString();
                Session["chkRowsExam"] = chkRows[0];

                datetimeChange.SelectedDate = DateTime.Now;

                DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
                DataTable dtDept = Application["UnitData"] as DataTable;

                DataRow[] rowRefDoc = dtHisDoc.Select("EMP_ID=" + env.UserID);
                cmbRefDoc.Text = rowRefDoc.Length > 0 ? rowRefDoc[0]["RadioName"].ToString() : "";

                DataView dv = new DataView();
                DataTable dtt = new DataTable();
                dv = dtDept.DefaultView;
                dv.RowFilter = "UNIT_UID='" + param.REF_UNIT_UID + "'";
                dtt = dv.ToTable();
                cmbRefUnit.Text = dtt.Rows[0]["UNIT_DESC"].ToString();

                #region Checkbox Portable
                if (chkRows[0]["IS_PORTABLE"].ToString() != "Y")
                {
                    chkPortable.Enabled = false;
                }
                #endregion Checkbox Portable

                #region Combobox Side
                RISBaseClass getBpview = new RISBaseClass();
                DataTable dtBP = getBpview.get_BP_ViewMapping(Request.Params["EXAM_ID"].ToString());
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
                if (dtBP.Rows.Count == 0)
                    cmbSide.Enabled = false;
                else if (dtBP.Rows.Count == 1)
                {
                    cmbSide.Enabled = true;
                    cmbSide.SelectedValue = dtBP.Rows[0]["BPVIEW_ID"].ToString();
                    //if (dtBP.Rows[0]["NEED_DETAIL"].ToString() == "Y")
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showEditorOrder", "showEditorOrder('" + rowsExam[0]["EXAM_ID"].ToString() + "');", true);
                }
                else
                {
                    cmbSide.Enabled = true;
                    cmbSide.OpenDropDownOnLoad = true;
                }
                if (chkRows[0]["NEED_SIDE"].ToString() != "Y")
                {
                    cmbSide.Enabled = false;
                }
                #endregion

                txtEditor.Text = param.REF_DOC_INSTRUCTION;
            }



            #region Combobox Priority

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
            #endregion
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        bool flag = true;
        if (txtEditor.Text.Trim() == "")
        {
            flag = false;
            showOnlineMessageBox("checkIndication");
        }
        if (string.IsNullOrEmpty(cmbRefDoc.Text.Trim()))
        {
            flag = false;
            showOnlineMessageBox("checkRefDoc");
        }
        if (string.IsNullOrEmpty(cmbRefUnit.Text.Trim()) || cmbRefUnit.Text.LastIndexOf('*') > 0)
        {
            flag = false;
            showOnlineMessageBox("checkRefUnit");
        }
        if (flag)
            if (setInsertOrder())
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('ClinicalPopup');", true);
    }


    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('ClinicalPopupCancle');", true);
    }
    protected void rdoChangeDate_CheckedChanged(object source, EventArgs e)
    {
        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            int lengthDay = 0;

            if (rdoMonth3.Checked)
                lengthDay = 28 * 3;
            if (rdoMonth6.Checked)
                lengthDay = 28 * 6;
            if (rdoMonth9.Checked)
                lengthDay = 28 * 9;
            if (rdoWeek1.Checked)
                lengthDay = 7;
            if (rdoWeek2.Checked)
                lengthDay = 14;
            if (rdoWeek4.Checked)
                lengthDay = 28;
            if (rdoWeek6.Checked)
                lengthDay = 42;
            if (rdoYear1.Checked)
                lengthDay = 364;
            if (rdoYear2.Checked)
                lengthDay = 728;
            datetimeChange.SelectedDate = DateTime.Now.AddDays(lengthDay);
        }
    }
    protected void cmbRefDoc_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtDoc = (DataTable)Application["HisDoctorData"];

        cmbRefDoc.Items.Clear();

        string text = e.Text.Trim();
        DataRow[] rows = dtDoc.Select("EMP_UID+RadioName LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefDoc.Items.Add(new RadComboBoxItem(rows[i]["EMP_UID"].ToString() + ":" + rows[i]["RadioName"].ToString()));
    }
    protected void cmbRefUnit_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtUnit = (DataTable)Application["UnitData"];

        cmbRefUnit.Items.Clear();

        string text = e.Text.Trim();
        DataRow[] rows = dtUnit.Select("UNIT_DESC LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefUnit.Items.Add(new RadComboBoxItem(rows[i]["UNIT_DESC"].ToString()));
    }
    protected void cmbPriority_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string cmbSideID = cmbSide.SelectedValue;
    }
    protected void chkPortable_SelectedIndexChanged(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadButton clickedButton = (RadButton)sender;
        if (clickedButton.Checked)
        {
            chkPortable.Value = "Y";
        }
        else
        {
            chkPortable.Value = "N";
        }
    }
    protected void cmbSide_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cmbSide.OpenDropDownOnLoad = false;
    }
    private bool setInsertOrder()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        OrderClass order = new OrderClass();
        DataTable dtTemp = setOrderTemplate();
        DataTable dt = setInsertOrderDtl();
        DataTable dtDelete = param.dvGridDtl_Remove;
        int ord_id = 0;
        if (dtTemp == null)
            return false;
        if (dt == null)
            return false;
        ord_id = order.check_ONLOrder(dt, dtTemp, dtDelete, env);
        return true;
    }
    private DataTable setOrderTemplate()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
        DataTable dtPat = (DataTable)Application["PatientStatusData"];
        DataTable dtDept = Application["UnitData"] as DataTable;

        DataTable dtTemp = new DataTable();
        dtTemp.Columns.Add("REG_ID");
        dtTemp.Columns.Add("FULLNAME_PAT");
        dtTemp.Columns.Add("FULLNAME");
        dtTemp.Columns.Add("INSURANCE_TYPE_ID");
        dtTemp.Columns.Add("REF_UNIT_ID");
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

        PatientClass getPatient = new PatientClass();

        string _hn = param.HN;
        string _patientName = "";
        DataSet ds = new DataSet();
        if (param.dsPatientData == null)
        {
            bool isTele = false;
            int encId = 0;
            ds = param.dsPatientData = getPatient.get_Patient_Registration_ByHN(_hn, env, false);
            param.IS_NONRESIDENT = getPatient.get_Patient_NonResident(_hn, param.ENCOUNTER_TYPE, param.REF_UNIT_UID, out isTele, out encId);
            param.IS_TELEMED = isTele;
            param.ENC_ID = encId;
        }
        else
            ds = param.dsPatientData;


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            param.REG_ID = Convert.ToInt32(dr["REG_ID"]);
            _patientName = dr["TITLE"].ToString() + dr["FNAME"].ToString() + " " + dr["LNAME"].ToString();
        }

        int lastIndex = cmbRefDoc.Text.LastIndexOf(":") + 1;
        int lengthDoc = cmbRefDoc.Text.Length - lastIndex;
        DataRow[] rowsDoc = dtHisDoc.Select("RadioName='" + cmbRefDoc.Text.Substring(lastIndex, lengthDoc) + "'");
        DataRow[] rowsUnit = dtDept.Select("UNIT_DESC='" + cmbRefUnit.Text + "'");
        DataRow addRow = dtTemp.NewRow();

        string IS_ALERT_CLINICA = null;
        string CLINICAL_INSTRUCTION_TAG = null;
        //try
        //{
        //    List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
        //    DataTable dtCItype = param.dtCLINICALINDICATIONTYPE;

        //    foreach (string str in data)
        //    {
        //        DataRow[] rowCItype = dtCItype.Select("CI_DESC='" + str.Trim() + "'");
        //        if (!string.IsNullOrEmpty(rowCItype[0]["CI_TAG"].ToString()))
        //        {
        //            IS_ALERT_CLINICA = "Y";
        //            if (CLINICAL_INSTRUCTION_TAG == null)
        //                CLINICAL_INSTRUCTION_TAG = rowCItype[0]["CI_TAG"].ToString();
        //            else
        //                CLINICAL_INSTRUCTION_TAG += "," + rowCItype[0]["CI_TAG"].ToString();
        //        }
        //    }
        //}
        //catch { }

        addRow["REG_ID"] = param.REG_ID;
        addRow["FULLNAME_PAT"] = _patientName;
        addRow["FULLNAME"] = param.EmpName;
        addRow["INSURANCE_TYPE_ID"] = param.INSURANCE_TYPE_ID;
        addRow["REF_UNIT_ID"] = rowsUnit[0]["UNIT_ID"].ToString();//param.REF_UNIT_ID;
        addRow["REF_DOC_ID"] = rowsDoc[0]["EMP_ID"].ToString();
        addRow["REF_DOC_UID"] = rowsDoc[0]["EMP_UID"].ToString();
        addRow["REF_DOCNAME"] = rowsDoc[0]["RadioName"].ToString();
        addRow["REF_DOC_FNAME"] = rowsDoc[0]["FNAME"].ToString();
        addRow["REF_DOC_LNAME"] = rowsDoc[0]["LNAME"].ToString();
        addRow["CLINIC_TYPE_ID"] = param.CLINIC_TYPE_ID;
        addRow["txtEditor"] = txtEditor.Text;
        addRow["PAT_STATUS"] = dtPat.Rows[0]["STATUS_ID"].ToString();
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
    private DataTable setInsertOrderDtl()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtExamAll = Application["ExamAllData"] as DataTable;
        DataTable dtClinicType = Application["ClinicTypeData"] as DataTable;
        DataTable dtDept = Application["UnitData"] as DataTable;
        DataTable dtData = param.dvGridDtl;
        DataRow chkRows = Session["chkRowsExam"] as DataRow;

        DataRow[] RowsExam = dtData.Select("EXAM_ID=" + Request.Params["EXAM_ID"].ToString());
        switch (param.ENC_CLINIC)
        {
            case "RGL": param.CLINIC_TYPE = "Normal"; break;
            case "SPC": param.CLINIC_TYPE = "Special"; break;
            case "PM": param.CLINIC_TYPE = "VIP"; break;
            default: param.CLINIC_TYPE = "Normal"; break;
        }
        string strClinicTypeUID = param.CLINIC_TYPE; //param.dvGridDtl.Rows.Count > 0 ? param.dvGridDtl.Rows[0]["CLINIC_TYPE_UID"].ToString() : param.CLINIC_TYPE;
        DataRow[] rowClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + strClinicTypeUID + "'");
        param.CLINIC_TYPE_ID = Convert.ToInt32(rowClinic[0]["CLINIC_TYPE_ID"]);


        int reg_id = param.REG_ID;
        OrderClass ord = new OrderClass();

        DateTime setDatetime = datetimeChange.SelectedDate.Value;
        if (setDatetime.Hour == 0 && setDatetime.Minute == 0)
            setDatetime = setDatetime.AddHours(8);

        RISBaseClass risbase = new RISBaseClass();
        DataRow dr = dtData.NewRow();
        dr["ORDER_ID"] = 0;
        dr["HN"] = param.HN;
        dr["REG_ID"] = param.REG_ID;
        dr["STATUS"] = "R";
        dr["PRIORITY"] = cmbPriority.Text;
        dr["PRIORITY_TEXT"] = cmbPriority.SelectedValue;
        dr["ORDER_DT"] = setDatetime;
        dr["EXAM_DT"] = setDatetime;

        if (cmbSide.SelectedValue != "")
        {
            dr["BPVIEW_ID"] = cmbSide.SelectedValue;
        }
        dr["BPVIEW_NAME"] = cmbSide.Text;
        dr["NEED_SCHEDULE"] = chkRows["NEED_SCHEDULE"];
        dr["NEED_APPROVE"] = checkNeedApprove(chkRows, param.REF_UNIT_UID); // Check some Unit
        dr["NEED_SIDE"] = chkRows["NEED_SIDE"];
        dr["IS_PORTABLE"] = chkRows["IS_PORTABLE"];
        dr["EXAM_ID"] = chkRows["EXAM_ID"].ToString();
        dr["EXAM_UID"] = chkRows["EXAM_UID"].ToString();
        dr["EXAM_NAME"] = chkRows["EXAM_NAME"].ToString();

        string _rate = checkExamRate(chkRows, param.ENC_CLINIC, param.IS_NONRESIDENT);
        if (string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString()))
        {
            dr["RATE"] = _rate;
            dr["TOTAL_RATE"] = dr["RATE"].ToString();
            dr["QTY"] = 1;
        }
        else
        {
            DataTable dtBP = risbase.get_BP_ViewMapping(chkRows["EXAM_ID"].ToString());
            DataRow[] rowbp = dtBP.Select("BPVIEW_ID=" + dr["BPVIEW_ID"].ToString());

            double sumrate = Convert.ToDouble(_rate) * Convert.ToDouble(rowbp[0]["NO_OF_EXAM"]);
            dr["TOTAL_RATE"] = sumrate.ToString("#.00");
            dr["RATE"] = _rate;
            dr["QTY"] = Convert.ToDouble(rowbp[0]["NO_OF_EXAM"]);
        }

        dr["CLINIC_TYPE"] = param.CLINIC_TYPE_ID;
        dr["CREATED_BY"] = env.UserID;
        dr["CREATED_NAME"] = env.FirstName + " " + env.LastName;
        dr["CLINICAL_INSTRUCTION"] = param.CLINICAL_INSTRUCTION == null ? "" : param.CLINICAL_INSTRUCTION;
        dr["REF_DOC_INSTRUCTION"] = param.REF_DOC_INSTRUCTION == null ? "" : param.REF_DOC_INSTRUCTION;
        dr["COMMENTS"] = "";
        dr["IS_PORTABLE_VALUE"] = chkPortable.Value;

        DataTable dtPatDest = risbase.get_PAT_DEST_ID(param.REF_UNIT_ID, param.CLINIC_TYPE_ID);
        if (Utilities.IsHaveData(dtPatDest))
        {
            dr["PAT_DEST_ID"] = dtPatDest.Rows[0]["PAT_DEST_ID"].ToString();
            dr["PAT_DEST_DESC"] = dtPatDest.Rows[0]["LABEL"].ToString();
            if (chkRows["NEED_SCHEDULE"].ToString() == "Y")
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
            }
            else
            {
                dr["SCHEDULE_FLAG"] = false;
                dr["strEXAM_DT"] = dr["strEXAM_DT"].ToString() == "" ? DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat) : dr["strEXAM_DT"];
            }
        }


        int pat_dest_id = string.IsNullOrEmpty(dr["PAT_DEST_ID"].ToString()) ? 0 : Convert.ToInt32(dr["PAT_DEST_ID"]);
        DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(chkRows["EXAM_ID"]), pat_dest_id, SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
        dtMod_ID = Utilities.filterModalityByClinic(dtMod_ID, param.ENC_CLINIC);

        dr["MODALITY_ID"] = dtMod_ID.Rows.Count > 0 ? dtMod_ID.Rows[0][0] : 0;
        param.dtMod_ID = dtMod_ID;

        dtData.Rows.Add(dr);
        if (dr["IS_PORTABLE_VALUE"].ToString() == "Y")
        {
            addExamPanelPortable(dtExamAll, dtData.Rows[0]);
        }
        dtData.AcceptChanges();
        return dtData;
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
    private string checkNeedApprove(DataRow row_exam, string ref_unit_uid)
    {
        DataTable dtUnit = Application["UnitData"] as DataTable;
        string _need_approve = row_exam["NEED_APPROVE"].ToString();
        if (row_exam["NEED_SCHEDULE"].ToString() == "Y")
            if (!SpecifyData.checkForceWaitingList(dtUnit, ref_unit_uid))   // Force waiting list per Unit
                _need_approve = "Y";

        return _need_approve;
    }
    private void showOnlineMessageBox(string messagePopup, string length, bool is_multipopup, string multipopup_name)
    {
        Session["IS_MULTIPOPUP"] = is_multipopup;
        Session["MULTIPOPUP_NAME"] = multipopup_name;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "','" + length + "');", true);
    }
    private void showOnlineMessageBox(string messagePopup)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "','0');", true);
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
            //Session["rowsExamPort"] = rowsExam;
        }
    }
    private void setInsertOrderDtlPortable(DataTable dt, DataRow[] rowsExam, DataRow rowsPortable)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtUnit = Application["UnitData"] as DataTable;

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
        dr["STATUS"] = rowsPortable["STATUS"];
        dr["PRIORITY"] = rowsPortable["PRIORITY"];
        dr["PRIORITY_TEXT"] = rowsPortable["PRIORITY_TEXT"];
        dr["SCHEDULE_FLAG"] = rowsPortable["SCHEDULE_FLAG"];
        dr["ORDER_DT"] = rowsPortable["ORDER_DT"];
        dr["EXAM_DT"] = rowsPortable["EXAM_DT"];
        dr["strEXAM_DT"] = rowsPortable["strEXAM_DT"];
        dr["BPVIEW_ID"] = 5;
        dr["NEED_SCHEDULE"] = rowsExam[0]["NEED_SCHEDULE"];
        dr["NEED_APPROVE"] = checkNeedApprove(rowsPortable, param.REF_UNIT_UID); // Check some Unit
        dr["NEED_SIDE"] = rowsExam[0]["NEED_SIDE"];
        dr["IS_PORTABLE"] = rowsExam[0]["IS_PORTABLE"];
        dr["IS_PORTABLE_VALUE"] = "D";
        dr["EXAM_ID"] = rowsExam[0]["EXAM_ID"].ToString();
        dr["EXAM_UID"] = rowsExam[0]["EXAM_UID"].ToString();
        dr["EXAM_NAME"] = rowsExam[0]["EXAM_NAME"].ToString();
        dr["QTY"] = 1;
        dr["RATE"] = checkExamRate(rowsExam[0], param.ENC_CLINIC, param.IS_NONRESIDENT);
        dr["TOTAL_RATE"] = dr["RATE"].ToString();
        dr["CLINIC_TYPE"] = rowsPortable["CLINIC_TYPE"].ToString();
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
        }

        int pat_dest_id = string.IsNullOrEmpty(dr["PAT_DEST_ID"].ToString()) ? 0 : Convert.ToInt32(dr["PAT_DEST_ID"]);
        DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(rowsExam[0]["EXAM_ID"]), pat_dest_id, SpecifyData.checkPatientType(param.IS_CHILDEN, dtUnit, param.REF_UNIT_ID, param.ENC_CLINIC));
        dr["MODALITY_ID"] = dtMod_ID.Rows.Count > 0 ? dtMod_ID.Rows[0][0] : 0;
        param.dtMod_ID = dtMod_ID;

        dt.Rows.Add(dr);
        dt.AcceptChanges();
        Session["ONL_PARAMETER"] = param;
    }

    public void OnAjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "COVID":
                ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
                txtEditor.Text += param.REF_DOC_INSTRUCTION;
                if (setInsertOrder())
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('ClinicalPopup');", true);
                break;
        }
    }
}