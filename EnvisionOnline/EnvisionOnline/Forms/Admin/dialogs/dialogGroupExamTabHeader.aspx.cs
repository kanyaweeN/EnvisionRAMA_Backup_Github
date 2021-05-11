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
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.Common.Common;

public partial class dialogGroupExamTabHeader : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTabHeader.Text))
            return;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ProcessAddONLGroupDepartment prcAdd = new ProcessAddONLGroupDepartment();
        prcAdd.ONL_GROUPDEPARTMENT.GDEPT_TEXT = txtTabHeader.Text.Trim();
        prcAdd.ONL_GROUPDEPARTMENT.GDEPT_TYPE = Session["GDeptTypeSelected"].ToString();
        prcAdd.ONL_GROUPDEPARTMENT.CREATED_BY = env.UserID;
        prcAdd.Invoke();
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveTabHeader');", true);
    }
}
