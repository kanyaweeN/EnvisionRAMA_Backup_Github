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
using System.Text;
using EnvisionOnline.Operational;
using System.Globalization;
using EnvisionOnline.BusinessLogic.ProcessRead;
using System.Collections;
using EnvisionOnline.Common.Common;

public partial class frmVNAWorklist : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void grdData_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        fillDataGridDataTable(grdData, LoadData());
    }
    protected void grdData_ItemCommand(object source, GridCommandEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        Session["values"] = values;
        item.ExtractValues(values);
        if (e.CommandName == "grdbtnUpload")
        {

            string url = "http://synapsevna.rama.mahidol.ac.th/connext-web/portal?";
            url += "patientID=" + param.dsPatientData.Tables[0].Rows[0]["HN"].ToString(); ;
            url += "&firstName=";// +param.dsPatientData.Tables[0].Rows[0]["FNAME"].ToString(); ;
            url += "&lastName=";// +param.dsPatientData.Tables[0].Rows[0]["LNAME"].ToString(); ;
            url += "&dob=" + Convert.ToDateTime(param.dsPatientData.Tables[0].Rows[0]["DOB"]).ToString("yyyy-MM-dd");
            url += "&visitID=" + values["VN"].ToString();
            url += "&creationDate=" + Convert.ToDateTime(values["EFFECTIVE_START_DATE"]).ToString("yyyy-MM-dd");
            url += "&stmo=" + values["STMO_NAME"].ToString();
            url += "&ehrUserID=" + env.UserUID;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);

        }
        else if (e.CommandName == "grdbtnViewer")
        {

            //string url = "http://10.6.85.232:8080/launch?";
            //url += "action=search&Archive=synapsevna&username=admin&password=admin";
            //url += "&patientID=" + values["HN"].ToString();

            string url = values["VNA_PATH"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
        }
    }

    protected void grdData_ItemDataBound(object source, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem gridDataItem = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;
            bool flag = false;
            if (!string.IsNullOrEmpty(dv.Row["VNA_PATH"].ToString()))
                flag = true;

            ImageButton imgBtnViewer = (ImageButton)gridDataItem["grdbtnViewer_Unigue"].Controls[0];
            imgBtnViewer.Visible = flag;
        }
    }
    protected void grdData_PreRender(object sender, EventArgs e)
    {
        set_ColumnWorklist();
    }
    private void set_ColumnWorklist()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        //grdData.MasterTableView.GetColumn("colHN").Visible = false;
        //grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = false;
        //grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = true;
        //grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = true;
        //grdData.MasterTableView.GetColumn("colModality").Visible = false;
        //grdData.MasterTableView.GetColumn("colSide").Visible = false;
        //grdData.Rebind();
    }
    protected void grdData_OnDataBound(object sender, EventArgs e)
    {
        //ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        //bool flag = true;
        //switch (param.FORM)
        //{
        //    case "O1": flag = true; break;
        //    case "O2": flag = false; break;
        //    case "R1": flag = true; break;
        //    case "R2": flag = false; break;
        //    default: flag = true; break;
        //}

        //this.grdData.Columns[0].Visible = flag;
        //this.grdData.Columns[1].Visible = flag;
    }
    private DataTable LoadData()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        param.dvGrid = new DataTable();
        RadButton chkShowAllData = (RadButton)rtoolSearch.FindItemByValue("rtoolbtnChkAll").FindControl("chkShowAllData");
        //RadDatePicker dtFromDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtFromDate");
        //RadDatePicker dtToDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtToDate");
        //DateTime dtFrom = new DateTime();
        //DateTime dtTo = new DateTime();
        //if (dtFromDate.SelectedDate != null)
        //    dtFrom = new DateTime(dtFromDate.SelectedDate.Value.Year, dtFromDate.SelectedDate.Value.Month, dtFromDate.SelectedDate.Value.Day, 0, 0, 0);
        //if (dtToDate.SelectedDate != null)
        //    dtTo = new DateTime(dtToDate.SelectedDate.Value.Year, dtToDate.SelectedDate.Value.Month, dtToDate.SelectedDate.Value.Day, 23, 59, 59);
        //dtTo = dtTo.AddYears(10);
        int _mode = 0;

        DataTable dtDept = (DataTable)Application["UnitData"];
        DataRow[] rowRefUnit = dtDept.Select("UNIT_UID='" + param.REF_UNIT_UID + "'");

        _mode = chkShowAllData.Checked ? 2 : 1;
        ProcessGetVNAWorklist pro = new ProcessGetVNAWorklist();
        pro.VNA_WORKLIST.MODE = _mode;
        pro.VNA_WORKLIST.HN = param.HN;
        pro.VNA_WORKLIST.REF_UNIT = rowRefUnit.Length <= 0 ? 0 : Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);
        //pro.VNA_WORKLIST.FROM_DATE = dtFromDate.SelectedDate == null ? DateTime.Now : dtFrom;
        //pro.VNA_WORKLIST.TO_DATE = dtToDate.SelectedDate == null ? DateTime.Now : dtTo;
        pro.Invoke();

        return pro.Result.Tables[0];
    }
    private void get_AllRowFilter(RadGrid radGridData, DataTable dt, string _search)
    {
        StringBuilder sb = new StringBuilder();
        foreach (DataColumn col in dt.Columns)
            if (col.DataType.Name == "String")
                sb.Append(col.Caption + " like '%" + _search + "%' \r\n OR ");
        if (sb.Length >= 3)
            sb.Remove(sb.ToString().LastIndexOf("OR"), 3);
        DataRow[] rows = dt.Select(sb.ToString());
        fillDataGrid_Filter(radGridData, Utilities.arrayRowsToDataTable(dt.Clone(), rows));
    }
    
    protected void txtSearch_OnTextChanged(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    protected void btnSearchDate_OnClick(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    protected void chkShowAllData_OnCheckedChanged(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    private void modifiedData_grdData()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = LoadData();
        fillDataGrid_Filter(grdData, dt);
        TextBox txt = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");
        get_AllRowFilter(grdData, dt, txt.Text);
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
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
    }
}
