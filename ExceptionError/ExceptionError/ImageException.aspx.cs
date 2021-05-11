using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using EnvisionOnline.Common;

namespace ExceptionError
{
    public partial class ImageException : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           bool ii= IsPostBack;
           if (!IsPostBack)
           {
               GBL_ERRORLOGS gblErrorLog = Session["GBL_ERRORLOGS"] as GBL_ERRORLOGS;
               txtUserId.Text = gblErrorLog.USER_LOGIN;
               txtHostAddress.Text = gblErrorLog.USER_HOST_ADDRESS;
               txtErrorMessage.Text = gblErrorLog.ERROR_MESSAGE;
               txtErrorSource.Text = gblErrorLog.ERROR_SOURCE;
               txtCreatedOn.Text = gblErrorLog.CREATED_ON.ToString();
               txtTroubleshootingGuide.Text = "";
               txtErrorMessage.Text = gblErrorLog.ERROR_MESSAGE;
               errorImage.ImageUrl = "http://miracle99/EnvisionErrorImages/" + gblErrorLog.PIC_PATH;

           }
        }
    }
}