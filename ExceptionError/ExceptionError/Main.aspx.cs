using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Collections;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common;

namespace ExceptionError
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void grdException_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == "ShowAlret")
            {
                GridEditableItem item = e.Item as GridEditableItem;
                Hashtable values = new Hashtable();
                item.ExtractValues(values);
                e.ExecuteCommand(values);

                GBL_ERRORLOGS gblErrorLog = Session["GBL_ERRORLOGS"] as GBL_ERRORLOGS;
                gblErrorLog = new GBL_ERRORLOGS();

                gblErrorLog.ERROR_ID = Convert.ToInt32(values["ERROR_ID"].ToString());
                if (string.IsNullOrEmpty(values["USER_LOGIN"].ToString()))
                {
                    gblErrorLog.USER_LOGIN = "User ID is Null";
                }
                else
                {
                    gblErrorLog.USER_LOGIN = values["USER_LOGIN"].ToString();
                }
                gblErrorLog.USER_HOST_ADDRESS = values["USER_HOST_ADDRESS"].ToString();
                gblErrorLog.ERROR_MESSAGE = values["ERROR_MESSAGE"].ToString();
                gblErrorLog.ERROR_SOURCE = values["ERROR_SOURCE"].ToString();
                gblErrorLog.PIC_PATH = values["PIC_PATH"].ToString();
                gblErrorLog.CREATED_ON = Convert.ToDateTime(values["CREATED_ON"].ToString());

                Session["GBL_ERRORLOGS"] = gblErrorLog;


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openNormalPage", "openRadWindow();", true);

            }
        }


        protected void grdException_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProcessGetGBLErrorLogs prc = new ProcessGetGBLErrorLogs();
            DataTable dt = prc.get_ErrorLogsWorklistAll().Tables[0];
            //param.dvExamTop10 = dt;
            fillDataGridDataTable(grdException, dt);
            //Session["ONL_PARAMETER"] = param;
        }

        private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            param = new ONL_PARAMETER();
            param.dvGrid = dt;
            Session["ONL_PARAMETER"] = param;

            radGridData.DataSource = dt;
            for (int i = 0; i < radGridData.Columns.Count; i++)
                radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        protected void comboSearch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadComboBox comboSearch = (RadComboBox)rtoolSearch.FindItemByValue("rtoolCmbSearch").FindControl("comboSearch");
            TextBox txtSearch = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");
            Label laSearch = (Label)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("labelSearch");

            RadDatePicker datePickerStart = (RadDatePicker)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("dtFromDate");
            Label labelDateFrom = (Label)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("labelDateFrom");

            RadDatePicker datePickerEnd = (RadDatePicker)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("dtToDate");
            Label labelDateTo = (Label)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("labelDateTo");

            datePickerStart.SelectedDate = DateTime.Now;
            datePickerEnd.SelectedDate = DateTime.Now;

            if (comboSearch.SelectedValue == "3")//Date
            {
                txtSearch.Visible = false;
                laSearch.Visible = false;
                datePickerStart.Visible = true;
                labelDateFrom.Visible = true;
                datePickerEnd.Visible = true;
                labelDateTo.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                laSearch.Visible = true;
                datePickerStart.Visible = false;
                labelDateFrom.Visible = false;
                datePickerEnd.Visible = false;
                labelDateTo.Visible = false;
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dtToDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }

        protected void dtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }


        protected void chkShowAllData_OnCheckedChanged(object sender, EventArgs e)
        {
            RadButton chkShowAllData = (RadButton)rtoolSearch.FindItemByValue("rtoolbtnChkAll").FindControl("chkShowAllData");
            if (chkShowAllData.Checked == true)
            {
                ProcessGetGBLErrorLogs prc = new ProcessGetGBLErrorLogs();
                DataTable dt = prc.get_ErrorLogsWorklistAll().Tables[0];
                fillDataGridDataTable(grdException, dt);
                grdException.Rebind();
            }
            else
            {
                DataTable dt = new DataTable();
                fillDataGridDataTable(grdException, dt);
                grdException.Rebind();
            }
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            RadButton chkShowAllData = (RadButton)rtoolSearch.FindItemByValue("rtoolbtnChkAll").FindControl("chkShowAllData");
            RadComboBox comboSearch = (RadComboBox)rtoolSearch.FindItemByValue("rtoolCmbSearch").FindControl("comboSearch");
            TextBox txtSearch = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");

            RadDatePicker datePickerStart = (RadDatePicker)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("dtFromDate");

            RadDatePicker datePickerEnd = (RadDatePicker)rtoolSearch.FindItemByValue("rtoolbtnDatetime").FindControl("dtToDate");

            ProcessGetGBLErrorLogs prc = new ProcessGetGBLErrorLogs();

            chkShowAllData.Checked = false;
            switch (comboSearch.SelectedValue)
            {
                case "1"://UserID
                    prc.GBL_ERRORLOGS.USER_LOGIN = txtSearch.Text;
                    dt = prc.get_ErrorLogsWorklistByUserId().Tables[0];
                    fillDataGridDataTable(grdException, dt);
                    grdException.Rebind();
                    break;
                case "2"://IPAddress
                    prc.GBL_ERRORLOGS.USER_HOST_ADDRESS = txtSearch.Text;
                    dt = prc.get_ErrorLogsWorklistByIP().Tables[0];
                    fillDataGridDataTable(grdException, dt);
                    grdException.Rebind();
                    break;
                case "3"://Date
                    DateTime dtFrom = new DateTime(datePickerStart.SelectedDate.Value.Year, datePickerStart.SelectedDate.Value.Month, datePickerStart.SelectedDate.Value.Day, 0, 0, 0);
                    DateTime dtTo = new DateTime(datePickerEnd.SelectedDate.Value.Year, datePickerEnd.SelectedDate.Value.Month, datePickerEnd.SelectedDate.Value.Day, 23, 59, 59);
                    dt = prc.get_ErrorLogsWorklistByDate(dtFrom, dtTo).Tables[0];
                    fillDataGridDataTable(grdException, dt);
                    grdException.Rebind();
                    break;
                default:
                    break;
            }
        }


        protected void radAjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            DataTable dt = param.dvGrid;

            DataRow[] rows = dt.Select("ERROR_ID=" + e.Argument);

            GBL_ERRORLOGS gblErrorLog = Session["GBL_ERRORLOGS"] as GBL_ERRORLOGS;
            gblErrorLog = new GBL_ERRORLOGS();

            gblErrorLog.ERROR_ID = Convert.ToInt32(rows[0]["ERROR_ID"].ToString());
            if (string.IsNullOrEmpty(rows[0]["USER_LOGIN"].ToString()))
            {
                gblErrorLog.USER_LOGIN = "User ID is Null";
            }
            else
            {
                gblErrorLog.USER_LOGIN = rows[0]["USER_LOGIN"].ToString();
            }
            gblErrorLog.USER_HOST_ADDRESS = rows[0]["USER_HOST_ADDRESS"].ToString();
            gblErrorLog.ERROR_MESSAGE = rows[0]["ERROR_MESSAGE"].ToString();
            gblErrorLog.ERROR_SOURCE = rows[0]["ERROR_SOURCE"].ToString();
            gblErrorLog.PIC_PATH = rows[0]["PIC_PATH"].ToString();
            gblErrorLog.CREATED_ON = Convert.ToDateTime(rows[0]["CREATED_ON"].ToString());

            Session["GBL_ERRORLOGS"] = gblErrorLog;


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openNormalPage", "openRadWindow();", true);

        }

    }
}