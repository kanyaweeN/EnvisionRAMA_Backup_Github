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
using System.Collections;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.BusinessLogic;

public partial class frmManageExamOnline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EXAM_ID"] = 0;
            RISBaseClass baseManage = new RISBaseClass();
            Session["ExamAllData"] = baseManage.get_Ris_ExamAll();
        }
    }
    protected void grdDataExam_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dtExam = Session["ExamAllData"] as DataTable;
        fillDataGridDataTable(grdDataExam, dtExam);
    }
    protected void grdDataExam_ItemCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);
        DataTable dtExam = Session["ExamAllData"] as DataTable;
        Session["EXAM_ID"] = values["EXAM_ID"].ToString();
        DataRow[] rows = dtExam.Select("EXAM_ID=" + values["EXAM_ID"].ToString());
        if (rows.Length > 0)
        {
            lblExam.Text = rows[0]["EXAM_UID"].ToString() + " : " + rows[0]["EXAM_NAME"].ToString();

            if (!string.IsNullOrEmpty(rows[0]["CAN_REQONLINE"].ToString()))
                chkCanRequestOnline.Checked = rows[0]["CAN_REQONLINE"].ToString() == "Y" ? true : false;
            else
                chkCanRequestOnline.Checked = false;

            if (!string.IsNullOrEmpty(rows[0]["NEED_SCHEDULE"].ToString()))
                chkNeedSchedule.Checked = rows[0]["NEED_SCHEDULE"].ToString() == "Y" ? true : false;
            else
                chkNeedSchedule.Checked = false;

            if (!string.IsNullOrEmpty(rows[0]["NEED_APPROVE"].ToString()))
                chkNeedApprove.Checked = rows[0]["NEED_APPROVE"].ToString() == "Y" ? true : false;
            else
                chkNeedApprove.Checked = false;

            if (!string.IsNullOrEmpty(rows[0]["VISIBLE_REQONLINE"].ToString()))
                chkVisibleReq.Checked = rows[0]["VISIBLE_REQONLINE"].ToString() == "Y" ? true : false;
            else
                chkVisibleReq.Checked = false;

            txtOnlineDisplay.Text = rows[0]["REQONL_DISPLAY"].ToString();
        }
    }
    protected void update_Click(object sender, EventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        string _exam_id = Session["EXAM_ID"].ToString();
        if (_exam_id != "0")
        {
            ProcessUpdateRISExamCondition upExam = new ProcessUpdateRISExamCondition();
            upExam.RIS_EXAM.EXAM_ID = Convert.ToInt32(_exam_id);
            upExam.RIS_EXAM.CAN_REQONLINE = chkCanRequestOnline.Checked ? "Y" : "N";
            upExam.RIS_EXAM.NEED_SCHEDULE = chkNeedSchedule.Checked ? "Y" : "N";
            upExam.RIS_EXAM.NEED_APPROVE = chkNeedApprove.Checked ? "Y" : "N";
            upExam.RIS_EXAM.VISIBLE_REQONLINE = chkVisibleReq.Checked ? "Y" : "N";
            upExam.RIS_EXAM.REQONL_DISPLAY = txtOnlineDisplay.Text;
            upExam.RIS_EXAM.LAST_MODIFIED_BY = env.UserID.ToString();
            upExam.Invoke();

            RISBaseClass baseManage = new RISBaseClass();
            Session["ExamAllData"] = baseManage.get_Ris_ExamAll();
        }
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
}
