using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Linq;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.Common.Common;
using EnvisionOnline.Common;
using EnvisionOnline.Operational;
using EnvisionOnline.BusinessLogic;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class normalPageAllExamGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> ListMasterNormalPages = new List<string>();
            Session["ListExamDtl"] = ListMasterNormalPages;

            DataTable dtGDept = Application["ONL_GROUPDEPARTMENT"] as DataTable;
            DataTable dtGType = Application["ONL_GROUPEXAMTYPE"] as DataTable;
            DataTable dtGExam = Application["ONL_GROUPEXAM"] as DataTable;
            DataRow[] rowGDept = dtGDept.Select("GDEPT_TYPE='" + Request.Params["GROUP_TEXT"].ToString() + "'");
            DataRow[] rowGType = dtGType.Select("GDEPT_TYPE='" + Request.Params["GROUP_TEXT"].ToString() + "'");
            DataRow[] rowGExam = dtGExam.Select("GDEPT_TYPE='" + Request.Params["GROUP_TEXT"].ToString() + "'");
            
            dtGExam.AcceptChanges();
            DataTable dttGDept = rowGDept.CopyToDataTable();
            DataTable dttGExam = rowGExam.CopyToDataTable();
            DataRow[] rowGExamSelected = dttGExam.Select("GTYPE_ID=" + rowGType[0]["GTYPE_ID"].ToString());

            Session["GroupDept"] = dttGDept;
            Session["GroupType"] = rowGType.CopyToDataTable();
            Session["GroupExam"] = dttGExam;
            Session["GroupExamSelected"] = rowGExamSelected.CopyToDataTable();
            RadTabStrip1.DataSource = dttGDept;
            RadTabStrip1.DataFieldID = "GDEPT_ID";
            RadTabStrip1.DataTextField = "GDEPT_TEXT";
            RadTabStrip1.DataBind();
            RadTabStrip1.Tabs[0].Selected = true;

        }
    }
    protected void RadTabStrip1_TabDataBound(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        DataRowView dataRow = (DataRowView)e.Tab.DataItem;
        e.Tab.Attributes["GDEPT_ID"] = dataRow["GDEPT_ID"].ToString();
        e.Tab.Attributes["GDEPT_TEXT"] = dataRow["GDEPT_TEXT"].ToString();
        e.Tab.ToolTip = e.Tab.Attributes["GDEPT_TEXT"];
    }  
    protected void RadTabStrip1_TabClick1(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        DataTable dtExamAll = Application["ExamData"] as DataTable;
        DataTable dttGType = Session["GroupType"] as DataTable;
        DataTable dttGExam = Session["GroupExam"] as DataTable;

        DataRow[] rowGType = dttGType.Select("GDEPT_ID=" + e.Tab.Attributes["GDEPT_ID"].ToString());
        DataRow[] rowGExam = dttGExam.Select("GTYPE_ID=" + rowGType[0]["GTYPE_ID"].ToString());
        DataTable dtGExam = dtExamAll.Clone();
        foreach (DataRow row in rowGExam)
        {
            DataRow[] rowSelect = dtExamAll.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
            if (rowSelect.Length > 0)
            {
                dtGExam.Rows.Add(rowSelect[0].ItemArray);
            }
        }

        grdGroupType.DataSource = rowGType.CopyToDataTable();
        grdGroupType.DataBind();
        DataTable dtExam = dtGExam.Copy();
        grdExam.DataSource = dtExam;
        grdExam.DataBind();

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
    protected void grdGroupType_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dttGType = Session["GroupType"] as DataTable;
        DataTable dttGDept = Session["GroupDept"] as DataTable;
        DataRow[] rowGType = dttGType.Select("GDEPT_ID=" + dttGDept.Rows[0]["GDEPT_ID"].ToString());

        fillDataGridDataTable(grdGroupType, rowGType.CopyToDataTable());
    }
    protected void grdGroupType_SelectedIndexChanged(object source, EventArgs e)
    {
        DataTable dtExamAll = Application["ExamData"] as DataTable;
        DataTable dtExam = new DataTable();
        GridEditableItem item = grdGroupType.SelectedItems[0] as GridEditableItem;
        if (!string.IsNullOrEmpty(item["colGTYPE_ID"].Text))
        {
            if (Convert.ToInt32(item["colGTYPE_ID"].Text) > 0)
            {
                DataTable dttGExam = Session["GroupExam"] as DataTable;
                DataRow[] rowGExam = dttGExam.Select("GTYPE_ID=" + item["colGTYPE_ID"].Text);
                DataTable dtGExam = dtExamAll.Clone();
                foreach (DataRow row in rowGExam)
                {
                    DataRow[] rowSelect = dtExamAll.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                    if (rowSelect.Length > 0)
                    {
                        dtGExam.Rows.Add(rowSelect[0].ItemArray);
                    }
                }

                dtExam = dtGExam.Copy();
                if (rowGExam.Length > 0)
                    Session["GroupExamSelected"] = rowGExam.CopyToDataTable();
            }
            else
            {
                dtExam = Session["GEXAM"] as DataTable;
            }
        }
        grdExam.DataSource = dtExam;
        grdExam.DataBind();
    }

    protected void grdExam_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dtExamAll = Application["ExamData"] as DataTable;
        DataTable dtGType = Session["GroupType"] as DataTable;
        DataTable dttGExam = Session["GroupExamSelected"] as DataTable;
        DataTable dtGExam = dtExamAll.Clone();
        foreach (DataRow row in dttGExam.Rows)
        {
            DataRow[] rowSelect = dtExamAll.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
            if (rowSelect.Length > 0)
            {
                dtGExam.Rows.Add(rowSelect[0].ItemArray);
            }
        }
        dtGExam.AcceptChanges();
        fillDataGridDataTable(grdExam, dtGExam);
    }
    protected void grdExam_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "AddExam")
        {
            GridEditableItem item = e.Item as GridEditableItem;
            Hashtable values = new Hashtable();
            item.ExtractValues(values);
            e.ExecuteCommand(values);
            addExamDetail("AddExamAll", values["EXAM_ID"].ToString());
            List<string> ListPageAllExam = Session["ListExamDtl"] as List<string>;
            ListPageAllExam.Add(values["EXAM_UID"].ToString());
            displaySelectExam();
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
    protected void grdExam_ItemDataBound(object source, GridItemEventArgs e)
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
    protected void rtoolResult_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (e.Item.Value == "btnSave")
        {
            List<string> ListExamDtl = Session["ListExamDtl"] as List<string>;
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('RebindFromNormalPage');", true);
        }
        else if (e.Item.Value == "btnCancel")
        {
            List<string> ListExamDtl = Session["ListExamDtl"] as List<string>;
            DataTable dt = param.dvGridDtl;
            foreach (string value in ListExamDtl)
            {
                DataRow[] getCol = dt.Select("EXAM_UID = '" + value + "'");
                if (getCol.Length > 0)
                {
                    int getID = Convert.ToInt32(getCol[0]["EXAM_ID"]);
                    dt.Rows.Remove(dt.Select("EXAM_ID=" + getID)[0]);
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('CancelFromNormalPage');", true);
        }
    }
    private void displaySelectExam()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadTextBox txtResult = rtoolResult.FindItemByValue("groupResult").FindControl("txtResult") as RadTextBox;
        txtResult.Text = "";

        foreach (DataRow rows in param.dvGridDtl.Rows)
            txtResult.Text += rows["EXAM_NAME"].ToString() + ";  ";

        if (param.FlagChecked == "Y")
        {
            DataTable dtAllExam = Application["ExamAllData"] as DataTable;
            DataRow[] rowsExam = dtAllExam.Select("EXAM_ID=" + param.EXAM_ID);

            string getneedSchedule = rowsExam[0]["NEED_SCHEDULE"].ToString();
            string getcanReqonline = rowsExam[0]["CAN_REQONLINE"].ToString();
            if (getneedSchedule == "Y" && getcanReqonline == "Y")
            {
                if (SpecifyData.checkCanOrderwithUnit(param.REF_UNIT_UID, Convert.ToInt32(rowsExam[0]["EXAM_TYPE"])) || param.FlagCTMR == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "CloseAndRebind('checkAppointmentUS');", true);
                    param.FlagChecked = "N";
                }
            }
            param.FlagChecked = "N";
        }
    }

    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
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
                    SpecifyData.checkCanOrderwithUnit(param.REF_UNIT_UID, Convert.ToInt32(rowsExam[0]["EXAM_TYPE"])) || param.FlagCTMR == true
                    )
                {
                    setInsertOrderDtl(dt, rowsExam, "0");
                    if (string.IsNullOrEmpty(rowsExam[0]["NEED_SCHEDULE"].ToString()))
                        if (rowsExam[0]["NEED_SCHEDULE"].ToString() == "N")
                            addExamPanel(dtAllExam, rowsExam[0]["EXAM_ID"].ToString());

                    param.dvGridDtl = dt;
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
        }
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
    }
    private void addExamFavorite(Hashtable values)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
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

        param.dvExamFavorite = dt;
        Session["ONL_PARAMETER"] = param;

        fillDataGrid_Filter(grdExam, param.dtExamGroup);
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

        int value = 0;
        param.dvExamFavorite = baseDelFavorite.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        Session["ONL_PARAMETER"] = param;
        fillDataGrid_Filter(grdExam, param.dtExamGroup);
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
        dr["EXAM_NAME"] += " 6[" + dr["MODALITY_ID"].ToString() + "]";
        param.dtMod_ID = dtMod_ID;

        if (panelExam.ToString() != "0")
        {
            DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + panelExam.ToString());
            if (rowFillPanel.Length > 0)
            {
                dr["ORDER_DT"] = rowFillPanel[0]["ORDER_DT"];
                dr["EXAM_DT"] = rowFillPanel[0]["EXAM_DT"];
                dr["MODALITY_ID"] = Convert.ToBoolean(rowFillPanel[0]["SCHEDULE_FLAG"]) ? rowFillPanel[0]["MODALITY_ID"] : dr["MODALITY_ID"];
                dr["EXAM_NAME"] += " 7[" + dr["MODALITY_ID"].ToString() + "]";
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
    private DataTable checkModality(ONL_PARAMETER param, int exam_id, string enc_clinic, DataTable dtMod_ID)
    {
        RISBaseClass risbase = new RISBaseClass();

        string[] strColumn = { "MODALITY_ID", "AVG_INV_TIME", "SESSION_ID" };
        DataTable dtModFilter = new DataTable();//Check RIS_MODALITYUNIT
        DataView dvFilter = new DataView();
        string strSession = "";
        DataTable dtSession = Application["SessionType"] as DataTable;

        switch (enc_clinic)
        {
            case "Regular":
                dtModFilter = set_DistinctTable(risbase.get_ModalityFilter(param.IS_CHILDEN, param.REF_UNIT_ID, Convert.ToInt32(param.EXAM_ID)), strColumn);
                DataRow[] rowsessionR = dtSession.Select("SUBSTRING(session_uid,1,1)='R'");//Fix CODE
                foreach (DataRow rowSe in rowsessionR)
                    strSession += "," + rowSe["SESSION_ID"].ToString();

                dvFilter = dtModFilter.DefaultView;
                dvFilter.RowFilter = "SESSION_ID in (" + strSession.Substring(1) + ")";
                dtModFilter = dvFilter.ToTable();
                dtModFilter.AcceptChanges();
                break;
            case "Special":
                dtModFilter = set_DistinctTable(risbase.get_ModalityFilter(param.IS_CHILDEN, param.REF_UNIT_ID, Convert.ToInt32(param.EXAM_ID)), strColumn);
                DataRow[] rowsessionS = dtSession.Select("SUBSTRING(session_uid,1,1)='S'");//Fix CODE
                foreach (DataRow rowSe in rowsessionS)
                    strSession += "," + rowSe["SESSION_ID"].ToString();

                dvFilter = dtModFilter.DefaultView;
                dvFilter.RowFilter = "SESSION_ID in (" + strSession.Substring(1) + ")";
                dtModFilter = dvFilter.ToTable();
                dtModFilter.AcceptChanges();
                break;
            case "Premium":
                string _str = "";
                DataTable dtFilter = set_DistinctTable(risbase.get_ModalityFilter(false, 11894, Convert.ToInt32(param.EXAM_ID)), strColumn);
                DataTable dtModalityExamSDMC = risbase.get_Ris_ModalityExam(0, Convert.ToInt32(param.EXAM_ID), RISBaseClass.RIS_MODALITYEXAM_MODE.EXAM_ID_SDMC);
                foreach (DataRow rowModid in dtFilter.Rows)
                    _str += "," + rowModid["MODALITY_ID"].ToString();

                DataView dvModId = dtModalityExamSDMC.DefaultView;
                if (!string.IsNullOrEmpty(_str))
                    dvModId.RowFilter = "MODALITY_ID in (" + _str.Substring(1) + ")";
                dtModFilter = dvModId.ToTable();
                break;
            default:
                dtModFilter = set_DistinctTable(risbase.get_ModalityFilter(param.IS_CHILDEN, param.REF_UNIT_ID, Convert.ToInt32(param.EXAM_ID)), strColumn);
                DataRow[] rowsession = dtSession.Select("SUBSTRING(session_uid,1,1)='" + param.ENC_CLINIC.Substring(0, 1) + "'");//Fix CODE
                foreach (DataRow rowSe in rowsession)
                    strSession += "," + rowSe["SESSION_ID"].ToString();

                dvFilter = dtModFilter.DefaultView;
                dvFilter.RowFilter = "SESSION_ID in (" + strSession.Substring(1) + ")";
                dtModFilter = dvFilter.ToTable();
                dtModFilter.AcceptChanges();
                break;
        }

        DataTable dtModTemp = new DataTable();
        if (Utilities.IsHaveData(dtModFilter))
        {
            string _strModId = "";
            foreach (DataRow rowModid in dtModFilter.Rows)
                _strModId += "," + rowModid["MODALITY_ID"].ToString();
            if (_strModId.Length > 0)
            {
                DataView dvModId = dtMod_ID.DefaultView;
                dvModId.RowFilter = "MODALITY_ID in (" + _strModId.Substring(1) + ")";
                DataTable dtTemp = dvModId.ToTable();
                if (dtTemp.Rows.Count > 0)
                    dtModTemp = dtTemp.Copy();
                else
                    dtModTemp = dtModFilter.Copy();// dtMod_ID.Copy();
            }
            else
                dtModTemp = dtMod_ID.Copy();
        }
        else
            dtModTemp = dtMod_ID.Copy();

        return dtModTemp;
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

            default:
                string[] strCheck = e.Argument.Split(',');
                if (strCheck.Length > 1)
                {
                    param.EXAM_ID = strCheck[1].ToString();
                    addExamDetail(strCheck[0].ToString(), strCheck[1].ToString());
                    List<string> ListPageAllExam = Session["ListExamDtl"] as List<string>;
                    ListPageAllExam.Add(strCheck[2].ToString());
                    break;
                }
                break;
        }

        Session["ONL_PARAMETER"] = param;

    }


}
