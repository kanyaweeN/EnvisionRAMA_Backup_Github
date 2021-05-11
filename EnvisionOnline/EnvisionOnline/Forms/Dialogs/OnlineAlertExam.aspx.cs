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

public partial class OnlineAlertExam : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = Session["ConflictExam"] as DataTable;
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        DataTable dt = Session["ConflictExam"] as DataTable;
        RadGrid1.DataSource = dt;
        //RadGrid1.DataBind();
    }
    protected void rtoolResult_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        if (e.Item.Value == "btnSave")
            Session["MessageBoxAlertexamValue"] = "save";
        else if (e.Item.Value == "btnCancel")
            Session["MessageBoxAlertexamValue"] = "cancel";
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('ShowalertExam');", true);
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        
    }
}
