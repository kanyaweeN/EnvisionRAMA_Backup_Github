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
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic.ProcessCreate;

public partial class dialogGroupExamTypeAdd : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtGroupExamType.Text))
            return;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        DataRow row = Session["rowTabHeaderSelected"] as DataRow;
        ProcessAddONLGroupExamType prcAdd = new ProcessAddONLGroupExamType();
        prcAdd.ONL_GROUPEXAMTYPE.GTYPE_TEXT = txtGroupExamType.Text.Trim();
        prcAdd.ONL_GROUPEXAMTYPE.GDEPT_ID = Convert.ToInt32(row["GDEPT_ID"]);
        prcAdd.ONL_GROUPEXAMTYPE.CREATED_BY = env.UserID;
        prcAdd.Invoke();
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveGExamType');", true);
    }
}
