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
using System.Collections;
using EnvisionOnline.Operational;
using System.Globalization;
using System.Collections.Generic;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class normalPageFavorit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> ListPageFavorit = new List<string>();
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
            List<string> ListPageFavorit = Session["ListExamDtl"] as List<string>;
            ListPageFavorit.Add(values["EXAM_UID"].ToString());
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

    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    private void addExamDetail(string dvExam, string values)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        ProcessGetONLExammapclinic pExamClinic = new ProcessGetONLExammapclinic();
        pExamClinic.ONL_EXAMMAPCLINIC.EXAM_ID = Convert.ToInt32(values);
        pExamClinic.ONL_EXAMMAPCLINIC.CLINIC_TYPE_ID = param.CLINIC_TYPE_ID;
        pExamClinic.Invoke();
        if (Utilities.IsHaveData(pExamClinic.Result))
        {
            values = pExamClinic.Result.Tables[0].Rows[0]["EXAMMAP_ID"].ToString();
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

        DataRow[] rowsExam = dtExam.Select("EXAM_ID=" + values);
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
    private DataTable set_DistinctTable(DataTable dt, string[] column)
    {
        DataView view = new DataView(dt);
        DataTable distinctValues = view.ToTable(true, column);
        return distinctValues;
    }

    private void showOnlineMessageBox(string messagePopup)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "');", true);
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataTable dt = new DataTable();
        string str = "";
        switch (e.Argument)
        {
            case "RemoveExamFavorite":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    Hashtable values = Session["HashtableAddFavoriteExam"] as Hashtable;
                    deleteExamFavorite(values);
                }
                break;
            default:
                string[] strCheck = e.Argument.Split(',');
                if (strCheck.Length > 1)
                {
                    param.EXAM_ID = strCheck[1].ToString();
                    addExamDetail(strCheck[0].ToString(), strCheck[1].ToString());
                    List<string> ListPageFavorit = Session["ListExamDtl"] as List<string>;
                    ListPageFavorit.Add(strCheck[2].ToString());
                    break;
                }
                break;

        }

        Session["ONL_PARAMETER"] = param;
    }

    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    private void addExamFavorite(Hashtable values)
    {
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
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            baseMange.RIS_EXAMFAVORITE.EMP_ID = env.UserID;
            baseMange.RIS_EXAMFAVORITE.EXAM_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
            baseMange.RIS_EXAMFAVORITE.SL_NO = i + 1;
            baseMange.set_Ris_ExamFavorite_Update();
        }

        fillDataGrid_Filter(grdExamFavorite, dt);
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
        Session["ONL_PARAMETER"] = param;
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


}
