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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

public partial class frmMasterNormalPages : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('" + Request.Params["TAB_OPEN"].ToString() + "');", true);
            List<string> ListMasterNormalPages = new List<string>();
            Session["ListExamDtl"] = ListMasterNormalPages;

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
                        Timer1.Enabled = false;
                        param.FlagChecked = "N";
                    }
                }
                param.FlagChecked = "N";
            }
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
        Timer1.Enabled = false;
    }
    public void Timer1_Tick(object sender, EventArgs e)
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
                    Timer1.Enabled = false;
                    param.FlagChecked = "N";
                }
            }
            param.FlagChecked = "N";
        }
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        
    }
    
}
