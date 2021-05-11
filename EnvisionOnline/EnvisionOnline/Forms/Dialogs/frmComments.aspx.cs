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
using EnvisionOnline.Common;
using EnvisionOnline.Operational;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.BusinessLogic.ProcessCreate;

public partial class frmComments : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string tab = Request.Params["TAB_OPEN"].ToString();
            tabClinical.Style.Add("display", "none");
            tabComment.Style.Add("display", "none");

            GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            string strorder_id = param.ORDER_ID == null ? "0" : param.ORDER_ID;
            string strschedule_id = param.SCHEDULE_ID == null ? "0" : param.SCHEDULE_ID;
            string strexam_id = param.EXAM_ID == null ? "0" : param.EXAM_ID;
            DataTable dt = param.dvGrid;
            DataRow[] row = dt.Select("ORDER_ID=" + strorder_id +
                                      " AND SCHEDULE_ID = " + strschedule_id+
                                      " AND EXAM_ID = " + strexam_id);
            DataTable dtFilter = Utilities.arrayRowsToDataTable(dt.Clone(), row);

            if (dtFilter.Rows.Count > 0)
            {
                if (tab == "Clinical")
                {
                    tabClinical.Style.Add("display", "block");
                    txtEditor.Text = dtFilter.Rows[0]["CLINICAL_INSTRUCTION"].ToString();

                    if (env.UserID.ToString() == dtFilter.Rows[0]["REF_DOC"].ToString())
                    {
                        txtEditor.ReadOnly = true;
                        btnEdit2.Visible = true;
                        btnSave2.Visible = false;
                        btnCancel2.Visible = false;

                        switch (dtFilter.Rows[0]["STATUS"].ToString().ToUpper())
                        {
                            case "D" :
                            case "P" :
                            case "F" :
                                btnEdit2.Enabled = false;
                                break;
                            default :
                                btnEdit2.Enabled = true;
                                break;
                        }
                    }
                }
                else if (tab == "Comment")
                {
                    tabComment.Style.Add("display", "block");
                    txtComment.Text = dtFilter.Rows[0]["COMMENTS"].ToString();

                    try
                    {
                        if (dtFilter.Rows[0]["PENDING_COMMENTS"].ToString() != "")
                        {
                            txtComment.Text += "\r\n" +
                                "\r\n-- Pending Comment --" +
                                "\r\n" + dtFilter.Rows[0]["PENDING_COMMENTS"].ToString();
                        }
                    }
                    catch {
                        txtComment.Text = dtFilter.Rows[0]["COMMENTS"].ToString();
                    }
                }
            }
        }
    }

    private string get_ScheduleData(DataTable dtsch, string fullname_pat)
    {
        RISBaseClass risbase = new RISBaseClass();
        DataTable dtExam = risbase.get_Ris_Exam();
        string schedule_data = "";
        schedule_data += "HN : " + dtsch.Rows[0]["HN"].ToString();
        schedule_data += " " + fullname_pat;
        foreach (DataRow dr in dtsch.Rows)
        {
            DataRow[] rowExam = dtExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
            if (rowExam.Length > 0)
                schedule_data += " " + rowExam[0]["EXAM_NAME"].ToString() + ";";
        }
        foreach (DataRow drr in dtsch.Rows)
            schedule_data += " (" + drr["COMMENTS"].ToString() + ");";

        return schedule_data;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtEditor.ReadOnly = false;
        btnEdit2.Visible = false;
        btnSave2.Visible = true;
        btnCancel2.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        string strorder_id = param.ORDER_ID == null ? "0" : param.ORDER_ID;
        string strschedule_id = param.SCHEDULE_ID == null ? "0" : param.SCHEDULE_ID;
        string strexam_id = param.EXAM_ID == null ? "0" : param.EXAM_ID;
        DataTable dt = param.dvGrid;
        DataRow[] row = dt.Select("ORDER_ID=" + strorder_id +
                                  " AND SCHEDULE_ID = " + strschedule_id +
                                  " AND EXAM_ID = " + strexam_id);
        DataTable dtFilter = Utilities.arrayRowsToDataTable(dt.Clone(), row);

        try
        {
            if (dtFilter.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtFilter.Rows[0]["SCHEDULE_FLAG"]))
                {
                    DataRow dr = param.dsPatientData.Tables[0].Rows[0];
                    string fullname_pat = dr["TITLE"].ToString() + dr["FNAME"].ToString() + " " + dr["LNAME"].ToString();

                    ProcessUpdateRISSchedule upd = new ProcessUpdateRISSchedule();
                    upd.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(dtFilter.Rows[0]["SCHEDULE_ID"]);
                    upd.RIS_SCHEDULE.HN = dtFilter.Rows[0]["HN"].ToString();
                    upd.RIS_SCHEDULE.REG_ID = Convert.ToInt32(dtFilter.Rows[0]["REG_ID"]);
                    upd.RIS_SCHEDULE.SCHEDULE_DT = Convert.ToDateTime(dtFilter.Rows[0]["EXAM_DT"]);
                    upd.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(dtFilter.Rows[0]["MODALITY_ID"]);
                    upd.RIS_SCHEDULE.SCHEDULE_DATA = get_ScheduleData(dtFilter, fullname_pat);
                    upd.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dtFilter.Rows[0]["SESSION_ID"]);
                    upd.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(dtFilter.Rows[0]["START_DATETIME"]);
                    upd.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(dtFilter.Rows[0]["END_DATETIME"]);
                    upd.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(dtFilter.Rows[0]["REF_UNIT"]);
                    upd.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(dtFilter.Rows[0]["REF_DOC"]);
                    upd.RIS_SCHEDULE.REF_DOC_INSTRUCTION = dtFilter.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                    upd.RIS_SCHEDULE.CLINICAL_INSTRUCTION = txtEditor.Text.ToString();
                    upd.RIS_SCHEDULE.PAT_STATUS = Convert.ToInt32(dtFilter.Rows[0]["PAT_STATUS"]);
                    upd.RIS_SCHEDULE.SCHEDULE_STATUS = dtFilter.Rows[0]["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'W' : 'S';
                    upd.RIS_SCHEDULE.IS_BLOCKED = 'N';//drChk["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'Y' : 'N';
                    upd.RIS_SCHEDULE.COMMENTS = dtFilter.Rows[0]["COMMENTS"].ToString();
                    upd.RIS_SCHEDULE.ORG_ID = env.OrgID;
                    upd.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    upd.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(dtFilter.Rows[0]["INSURANCE_TYPE_ID"]);
                    upd.RIS_SCHEDULE.ENC_TYPE = dtFilter.Rows[0]["ENC_TYPE"].ToString();
                    upd.RIS_SCHEDULE.ENC_CLINIC = dtFilter.Rows[0]["ENC_CLINIC"].ToString();
                    upd.Invoke();

                    #region Keep logs
                    ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                    schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = Convert.ToInt32(dtFilter.Rows[0]["SCHEDULE_ID"]);
                    schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
                    schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'U';
                    schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Update Online";
                    schLogs.Invoke();
                    #endregion
                }
                else
                {
                    DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
                    DataRow[] rowsDoc = dtHisDoc.Select("EMP_ID='" + dtFilter.Rows[0]["REF_DOC"].ToString() + "'");

                    ProcessUpdateXRAYREQ upxreq = new ProcessUpdateXRAYREQ();
                    upxreq.XRAYREQ.ORDER_ID = Convert.ToInt32(dtFilter.Rows[0]["ORDER_ID"]);
                    upxreq.XRAYREQ.INSURANCE_TYPE_ID = dtFilter.Rows[0]["INSURANCE_TYPE_ID"].ToString();
                    upxreq.XRAYREQ.EMP_UID = rowsDoc[0]["EMP_UID"].ToString();
                    upxreq.XRAYREQ.DOCNAME = rowsDoc[0]["RadioName"].ToString();
                    upxreq.XRAYREQ.PAT_STATUS = dtFilter.Rows[0]["PAT_STATUS"].ToString();
                    upxreq.XRAYREQ.CLINICAL_INSTRUCTION = txtEditor.Text.ToString();
                    upxreq.XRAYREQ.REF_DOC_FNAME = rowsDoc[0]["FNAME"].ToString();
                    upxreq.XRAYREQ.REF_DOC_LNAME = rowsDoc[0]["LNAME"].ToString();
                    upxreq.XRAYREQ.REF_DOC_ID = dtFilter.Rows[0]["REF_DOC"].ToString();
                    upxreq.XRAYREQ.REF_UNIT = dtFilter.Rows[0]["REF_UNIT"].ToString();
                    upxreq.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    upxreq.XRAYREQ.ORG_ID = env.OrgID;
                    upxreq.Invoke();
                }
            }
        }
        catch { }

        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('');", true);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //string tab = Request.Params["TAB_OPEN"].ToString();
        //tabClinical.Style.Add("display", "none");
        //tabComment.Style.Add("display", "none");

        //ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        //string strorder_id = param.ORDER_ID == null ? "0" : param.ORDER_ID;
        //string strschedule_id = param.SCHEDULE_ID == null ? "0" : param.SCHEDULE_ID;
        //string strexam_id = param.EXAM_ID == null ? "0" : param.EXAM_ID;
        //DataTable dt = param.dvGrid;
        //DataRow[] row = dt.Select("ORDER_ID=" + strorder_id +
        //                          " AND SCHEDULE_ID = " + strschedule_id +
        //                          " AND EXAM_ID = " + strexam_id);
        //DataTable dtFilter = Utilities.arrayRowsToDataTable(dt.Clone(), row);

        //if (dtFilter.Rows.Count > 0)
        //{
        //    if (tab == "Clinical")
        //    {
        //        tabClinical.Style.Add("display", "block");
        //        txtEditor.Text = dtFilter.Rows[0]["CLINICAL_INSTRUCTION"].ToString();

                txtEditor.ReadOnly = true;
                btnEdit2.Visible = true;
                btnSave2.Visible = false;
                btnCancel2.Visible = false;
        //    }
        //}
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('');", true);
    }
}
