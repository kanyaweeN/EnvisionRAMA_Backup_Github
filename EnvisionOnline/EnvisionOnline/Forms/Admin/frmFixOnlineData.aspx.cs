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

public partial class frmFixOnlineData : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = "";
    }
    protected void btnFix_Click(object sender, EventArgs e)
    {
        LookUpSelect FixData = new LookUpSelect();
        FixData.FixDataOnline();

        lbl.Text = "Succes...........";
    }
}
