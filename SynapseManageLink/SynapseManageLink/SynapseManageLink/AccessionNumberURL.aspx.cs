using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace SynapseManageLink
{
    public partial class AccessionNumberURL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Params["AccessionNo"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSynapse", "showNewWindows('" + url + "');", true);
        }
        protected void btn_click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showPacs", "openURLFunction('" + txt.Text.Trim() + "');", true);
        }
        protected void btnHN_click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showPacs", "openURLFunctionHN('" + txtHN.Text.Trim() + "');", true);
        }
    }
}