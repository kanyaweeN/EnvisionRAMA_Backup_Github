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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;

public partial class frmQuickOrder : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdExamFavorite_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseMange = new RISBaseClass();
        int value = 0;
        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, value, env == null ? 1 : env.OrgID);
        fillDataGridDataTable(grdExamFavorite, dt);
    }
    protected void grdExamTop10_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass baseMange = new RISBaseClass();
        DataTable dtDept = (DataTable)Application["UnitData"];
        DataRow[] rowRefUnit = dtDept.Select("UNIT_UID='" + param.REF_UNIT_UID + "'");
        param.REF_UNIT_ID = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

        int value = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

        DataTable dt = baseMange.get_Ris_ModalityExamTop10(value, 30);
        fillDataGridDataTable(grdExamTop10, dt);
        Session["ONL_PARAMETER"] = param;
    }

    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
}
