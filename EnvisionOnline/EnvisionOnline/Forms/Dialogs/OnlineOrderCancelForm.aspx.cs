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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using EnvisionOnline.Common;
using EnvisionOnline.WebService;

public partial class OnlineOrderCancelForm : System.Web.UI.Page 
{
    private string strFrom;
    private string strID;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbAlertReason.Text = "";
        strFrom = Request.Params["FRM"].ToString();
        strID = Request.Params["ID"].ToString();
    }
    
    protected void grdReason_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        OrderClass ord = new OrderClass();
        DataTable dt = Application["CANCELTEMPLATE"] as DataTable;
        param.CanID = "0";
        fillDataGridDataTable(grdReason,dt);
    }
    protected void grdReason_SelectedIndexChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (grdReason.SelectedItems.Count > 0)
        {
            if (grdReason.SelectedItems[0] is GridDataItem)
            {
                GridDataItem selectedItem = grdReason.SelectedItems[0] as GridDataItem;
                if (selectedItem["CAN_UID"].Text == "CAN0013")
                    txtReason.Enabled = true;
                else
                {
                    txtReason.Enabled = false;
                    lbAlertReason.Text = "";
                }

                param.CanID = selectedItem["CAN_ID"].Text;
            }
        }
        Session["ONL_PARAMETER"] = param;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGrid;
        DataTable dtReason = Application["CANCELTEMPLATE"] as DataTable;
        string strCanID = param.CanID;
        DataRow[] rows = dtReason.Select("CAN_ID=" + strCanID);
        if (rows.Length > 0)
        {
            string _reason = "";
            if (txtReason.Enabled)
            {
                if (txtReason.Text == "")
                {
                    lbAlertReason.Text = "กรุณากรอกเหตุผล";
                    return;
                }
                else
                {
                    _reason = txtReason.Text.Trim();
                }
            }
            else
            {
                _reason = rows[0]["CAN_NAME"].ToString();
            }

            switch (strFrom)
            {
                case "SCH":
                    ScheduleClass sch = new ScheduleClass();
                    DataRow[] rowsch = dt.Select("SCHEDULE_ID =" + strID);
                    sch.set_ONLSchedule_Delete(Convert.ToInt32(strID), _reason, env.UserID,rowsch[0][1].ToString());
                    dt.Rows.Remove(rowsch[0]);
                    break;
                case "ORD":
                    OrderClass ord = new OrderClass();
                    ord.XRAYREQ.ORDER_ID = Convert.ToInt32(strID);
                    ord.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    ord.XRAYREQ.REASON = _reason;
                    ord.set_ONLXrayreq_Delete();

                    DataRow[] roword = dt.Select("ORDER_ID =" + strID);
                    dt.Rows.Remove(roword[0]);
                    break;
                case "DEN":
                    OrderClass den = new OrderClass();
                    den.XRAYREQ.ORDER_ID = Convert.ToInt32(strID);
                    den.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    den.XRAYREQ.REASON = _reason;
                    den.set_ONLOrderDirectly_Delete();

                    DataRow[] rowden = dt.Select("ORDER_ID =" + strID);
                    dt.Rows.Remove(rowden[0]);

                    new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMByOrderIdQueue(0, Convert.ToInt32(strID));
                    break;
            }
            
        }
        Session["ONL_PARAMETER"] = param;
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('DeleteOrder');", true);
    }

    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
        {
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }
    }
    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
        {
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }
    }
}