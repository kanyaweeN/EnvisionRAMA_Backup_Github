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
using EnvisionOnline.BusinessLogic.ProcessDelete;

public partial class dialogGroupExamTypeDelete : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataRow row = Session["rowGExamTypeSelected"] as DataRow;
        ProcessDeleteONLGroupExamType del = new ProcessDeleteONLGroupExamType();
        del.delete(Convert.ToInt32(row["GTYPE_ID"]));
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveGExamType');", true);
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveGExamType');", true);
    }
}
