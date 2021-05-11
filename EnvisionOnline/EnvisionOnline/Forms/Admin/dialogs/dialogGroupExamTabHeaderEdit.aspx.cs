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
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.Common.Common;

public partial class dialogGroupExamTabHeaderEdit : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataRow row = Session["rowTabHeaderSelected"] as DataRow;
            cmbButtomFix.SelectedValue = Session["GDeptTypeSelected"].ToString();
            txtTabHeader.Text = row["GDEPT_TEXT"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTabHeader.Text))
            return;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        DataRow row = Session["rowTabHeaderSelected"] as DataRow;
        ProcessUpdateONLGroupDepartment up = new ProcessUpdateONLGroupDepartment();
        up.ONL_GROUPDEPARTMENT.GDEPT_ID = Convert.ToInt32(row["GDEPT_ID"]);
        up.ONL_GROUPDEPARTMENT.GDEPT_TEXT = txtTabHeader.Text.Trim();
        up.ONL_GROUPDEPARTMENT.GDEPT_TYPE = cmbButtomFix.SelectedValue;
        up.ONL_GROUPDEPARTMENT.LAST_MODIFIED_BY = env.UserID;
        up.Invoke();
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveTabHeader');", true);
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveTabHeader');", true);
    }
}
