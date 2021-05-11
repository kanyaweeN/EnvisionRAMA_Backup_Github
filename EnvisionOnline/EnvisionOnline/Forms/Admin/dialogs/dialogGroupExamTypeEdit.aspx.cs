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
using EnvisionOnline.BusinessLogic.ProcessUpdate;

public partial class dialogGroupExamTypeEdit : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsGDept = Session["GDEPT"] as DataSet;
            cmbDept.DataTextField = "GDEPT_TEXT";
            cmbDept.DataValueField = "GDEPT_ID";
            cmbDept.DataSource = dsGDept.Tables[0];
            cmbDept.DataBind();

            DataRow row = Session["rowGExamTypeSelected"] as DataRow;
            cmbDept.SelectedValue = row["GDEPT_ID"].ToString();
            txtGroupExamType.Text = row["GTYPE_TEXT"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtGroupExamType.Text))
            return;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        DataRow row = Session["rowGExamTypeSelected"] as DataRow;
        ProcessUpdateONLGroupExamType up = new ProcessUpdateONLGroupExamType();
        up.ONL_GROUPEXAMTYPE.GTYPE_ID = Convert.ToInt32(row["GTYPE_ID"]);
        up.ONL_GROUPEXAMTYPE.GTYPE_TEXT = txtGroupExamType.Text.Trim();
        up.ONL_GROUPEXAMTYPE.GDEPT_ID = Convert.ToInt32(cmbDept.SelectedValue);
        up.ONL_GROUPEXAMTYPE.LAST_MODIFIED_BY = env.UserID;
        up.Invoke();
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveTabHeader');", true);
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveTabHeader');", true);
    }
}
