using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.Common;
using System.Web.Configuration;

namespace EnvisionOnline.Forms.Errors
{
    public partial class pageError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string str = "";
            if (Request.Params["ErrorExc"] != null)
                str = Request.Params["ErrorExc"].ToString();

            txtShowErrorMessage.Text = str;
        }
    }
}