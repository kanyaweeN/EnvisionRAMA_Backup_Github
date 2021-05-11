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
using System.Collections.Generic;
using EnvisionOnline.Common;
using EnvisionOnline.Operational;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using System.Globalization;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class normalPageFLU : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkIsValue();
            List<string> ListPageFLU = new List<string>();
        } 
    }
    private void checkIsValue()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        foreach (Control c in Page.Controls)
        {
            foreach (Control childc in c.Controls)
            {
                if (childc is RadButton)
                {
                    string _value = ((RadButton)childc).Value;
                    RadButton chk = (RadButton)childc;
                    DataRow[] rowCheck = param.dvGridDtl.Select("EXAM_UID='" + _value + "'");
                    if (rowCheck.Length > 0)
                        chk.Checked = true;
                    else
                        chk.Checked = false;

                    string _groupName = ((RadButton)childc).GroupName;
                    DataRow[] rowCheckFav = param.dvExamFavorite.Select("EXAM_UID='" + _value + "'");
                    if (rowCheckFav.Length > 0 && _groupName == "FAV")
                        chk.Icon.PrimaryIconUrl = "../../Resources/ICON/favorite_12.png";
                    else if (rowCheckFav.Length == 0 && _groupName == "FAV")
                        chk.Icon.PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png";
                }
            }
        }
    }
    protected void chekbox_CheckedChanged(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadButton clickedButton = (RadButton)sender;
        List<string> ListPageFLU = Session["ListExamDtl"] as List<string>;
        if (clickedButton.Checked)
        {
            //try
            //{
            //    DataTable dtAllExam = Application["ExamAllData"] as DataTable;
            //    DataRow[] getCol = dtAllExam.Select("EXAM_UID = '" + clickedButton.Value + "'");
            //    int getID = Convert.ToInt32(getCol[0]["EXAM_ID"]);

            //    ScheduleClass schedule = new ScheduleClass();
            //    DataTable dt = schedule.get_ScheduleConflictExam(getID, param.REG_ID);

            //    if (dt.Rows.Count > 0)
            //    {
            //        showOnlineAlertExam();
            //        Session["ConflictExam"] = dt;
            //        Session["AddExam"] = clickedButton;
            //    }
            //    else
            //    {
            //        addExamDetail(clickedButton.Value);
            //        ListPageFLU.Add(clickedButton.Value);
            //    }
            //}
            //catch
            //{
                addExamDetail(clickedButton.Value);
                ListPageFLU.Add(clickedButton.Value);
            //}
        }
        else
        {
            removeExamDetail(clickedButton.Value);
            ListPageFLU.Remove(clickedButton.Value);
        }
    }
    protected void Favorite_Click(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = new DataTable();
        dt = param.dvExamFavorite;
        RadButton rb = sender as RadButton;

        DataRow[] dr = dt.Select("EXAM_UID = '" + rb.Value.ToString() + "'");
        if (dr.Length > 0)
            showOnlineMessageBox("RemoveExamFavorite");
        else
            showOnlineMessageBox("AddFavoriteExam");

        Session["FavoriteRadButton"] = rb;
    }
    private void addExamDetail(string value)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dt = param.dvGridDtl;
        DataTable dtAllExam = new DataTable();
        dtAllExam = Application["ExamAllData"] as DataTable;

        DataRow[] getCol = dtAllExam.Select("EXAM_UID = '" + value + "'");
        int getID = Convert.ToInt32(getCol[0]["EXAM_ID"]);
        ProcessGetONLExammapclinic pExamClinic = new ProcessGetONLExammapclinic();
        pExamClinic.ONL_EXAMMAPCLINIC.EXAM_ID = Convert.ToInt32(getID);
        pExamClinic.ONL_EXAMMAPCLINIC.CLINIC_TYPE_ID = param.CLINIC_TYPE_ID;
        pExamClinic.Invoke();
        if (Utilities.IsHaveData(pExamClinic.Result))
        {
            getID = Convert.ToInt32(pExamClinic.Result.Tables[0].Rows[0]["EXAMMAP_ID"]);
        }
        param.EXAM_ID = getID.ToString();
        DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + getID);
        RISBaseClass risbase = new RISBaseClass();
        if (rowsExam.Length > 0)
        {
            if (!string.IsNullOrEmpty(rowsExam[0]["CAN_REQONLINE"].ToString()))
                if (rowsExam[0]["CAN_REQONLINE"].ToString() == "Y" &&
                    SpecifyData.checkCanOrderwithUnit(param.REF_UNIT_UID, Convert.ToInt32(rowsExam[0]["EXAM_TYPE"]))
                    )
                {
                    setInsertOrderDtl(dt, rowsExam, "0");
                    if (string.IsNullOrEmpty(rowsExam[0]["NEED_SCHEDULE"].ToString()))
                        if (rowsExam[0]["NEED_SCHEDULE"].ToString() == "N")
                            addExamPanel(dtAllExam, rowsExam[0]["EXAM_ID"].ToString());

                    param.dvGridDtl = dt;

                    if (rowsExam[0]["IS_COMMENTS"].ToString() == "Y")
                        addCommentWord("# กรุณาระบุส่วนที่ต้องการตรวจ #", rowsExam[0]["EXAM_ID"].ToString());
                    param.FlagChecked = "Y";
                }
                else
                {
                    showOnlineMessageBox("checkCanRequest");
                    param.FlagChecked = "N";
                }
        }
        else
        {
            showOnlineMessageBox("checkCanRequest");
            param.FlagChecked = "N";
        }
        Session["ONL_PARAMETER"] = param;

    }
    private void removeExamDetail(string value)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dt = param.dvGridDtl;
        DataTable dtAllExam = new DataTable();
        dtAllExam = Application["ExamAllData"] as DataTable;

        DataRow[] getCol = dtAllExam.Select("EXAM_UID = '" + value + "'");
        DataRow[] dr = dt.Select("EXAM_ID=" + Convert.ToInt32(getCol[0]["EXAM_ID"]));

        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }

        param.dvGridDtl = dt;
        Session["ONL_PARAMETER"] = param;
    }
    private void showOnlineMessageBox(string messagePopup)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "');", true);
    }
    private void showOnlineAlertExam()
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showNormalAlert", "showNormalAlert('ShowalertExam');", true);
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
            }
            else
            {
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
    private DataTable set_DistinctTable(DataTable dt, string[] column)
    {
        DataView view = new DataView(dt);
        DataTable distinctValues = view.ToTable(true, column);
        return distinctValues;
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
                dr["COMMENTS"] = clearCommentWord(dr["COMMENTS"].ToString());
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
    private void showEditDialog(string exam_id)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showBPViewCheck", "showBPViewCheck('" + exam_id + "');", true);
    }

    private void addExamFavorite(string values)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        RISBaseClass baseMange = new RISBaseClass();

        DataRow[] getCol = dtAllExam.Select("EXAM_UID = '" + values + "'");

        baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(getCol[0]["EXAM_ID"]);
        baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
        baseMange.RIS_EXAMFAVORITE.SL_NO = 999;
        baseMange.RIS_EXAMFAVORITE.ORG_ID = env.OrgID;
        baseMange.RIS_EXAMFAVORITE.CREATED_BY = env.UserID;
        baseMange.set_Ris_ExamFavorite_Insert();

        int value = 0;
        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
            baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
            baseMange.RIS_EXAMFAVORITE.SL_NO = i + 1;
            baseMange.set_Ris_ExamFavorite_Update();
        }
        param.dvExamFavorite = dt;
        Session["ONL_PARAMETER"] = param;
    }
    private void deleteExamFavorite(string values)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtAllExam = Application["ExamAllData"] as DataTable;
        RISBaseClass baseMange = new RISBaseClass();

        DataRow[] getCol = dtAllExam.Select("EXAM_UID = '" + values + "'");

        baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(getCol[0]["EXAM_ID"]);
        baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
        baseMange.RIS_EXAMFAVORITE.ORG_ID = env.OrgID;
        baseMange.set_Ris_ExamFavorite_Delete();

        int value = 0;
        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        param.dvExamFavorite = dt;
        Session["ONL_PARAMETER"] = param;
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dt = new DataTable();
        string str = "";
        switch (e.Argument)
        {
            case "AddFavoriteExam":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    RadButton rb = Session["FavoriteRadButton"] as RadButton;
                    addExamFavorite(rb.Value);
                    checkIsValue();
                }
                break;
            case "RemoveExamFavorite":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    RadButton rb = Session["FavoriteRadButton"] as RadButton;
                    deleteExamFavorite(rb.Value);
                    checkIsValue();
                }
                break;
            case "checkCanRequest":
                checkIsValue();
                break;
            case "ShowalertExam":
                RadButton clickedButton = Session["AddExam"] as RadButton;
                if (Session["MessageBoxAlertexamValue"].ToString().ToLower() == "save")
                {
                    List<string> ListPageCT = Session["ListExamDtl"] as List<string>;
                    addExamDetail(clickedButton.Value);
                    ListPageCT.Add(clickedButton.Value);
                }
                else
                {
                    //clickedButton.Checked = false;
                    checkIsValue();
                }
                break;
        }

        Session["ONL_PARAMETER"] = param;

    }
}