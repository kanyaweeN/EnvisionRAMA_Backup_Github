using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using EnvisionOnline.BusinessLogic.ProcessCreate;

namespace HISLink
{
    public partial class getHISLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _hisurl = string.Empty;
                string _hn = string.Empty;
                string _username = string.Empty;
                string _unit = string.Empty;
                string _clinic = string.Empty;
                string _insr = string.Empty;
                string _role = string.Empty;
                string _enc = string.Empty;
                string _form = string.Empty;
                string _ip = string.Empty;
                string _ie = string.Empty;

                _ie = Request.Browser.Type;
                _ip = Request.UserHostAddress;

                _hisurl = Request.Url.ToString();

                if (has_value(Request.Params["HN"]))
                    _hn = Request.Params["HN"].Trim();
                if (has_value(Request.Params["USER_NAME"]))
                    _username = Request.Params["USER_NAME"].Trim();
                if (has_value(Request.Params["UNIT"]))
                    _unit = Request.Params["UNIT"].Trim();
                if (has_value(Request.Params["CLINIC"]))
                    _clinic = Request.Params["CLINIC"].ToString().Trim();
                if (has_value(Request.Params["INSR"]))
                    _insr = Request.Params["INSR"].Trim();
                if (has_value(Request.Params["ROLE"]))
                    _role = Request.Params["ROLE"].Trim();
                if (has_value(Request.Params["ENC"]))
                    _enc = Request.Params["ENC"].Trim();
                if (has_value(Request.Params["FORM"]))
                    _form = Request.Params["FORM"].Trim();

                ProcessAddONLHISLinkLogs prc = new ProcessAddONLHISLinkLogs();
                prc.ONL_HISLINKLOG.HIS_URL = _hisurl;
                prc.ONL_HISLINKLOG.HN = _hn;
                prc.ONL_HISLINKLOG.USER_NAME =_username;
                prc.ONL_HISLINKLOG.UNIT=_unit;
                prc.ONL_HISLINKLOG.CLINIC =_clinic;
                prc.ONL_HISLINKLOG.INSR = _insr;
                prc.ONL_HISLINKLOG.ROLE = _role;
                prc.ONL_HISLINKLOG.ENC = _enc;
                prc.ONL_HISLINKLOG.FORM = _form;
                prc.ONL_HISLINKLOG.LOG_DESC = "HISLink";
                prc.ONL_HISLINKLOG.BROWSER_TYPE = _ie;
                prc.ONL_HISLINKLOG.USER_HOST_ADDRESS = _ip;
                prc.Invoke();

                Response.Redirect("http://miracleonline/envisiononline/OnlineRequestPage.aspx?" + Request.QueryString.ToString());
                //Response.Redirect("http://localhost:37503/OnlineRequestPage.aspx?" + Request.QueryString.ToString());
            }

        }
        private bool has_value(object source)
        {
            bool flag;
            if (source != null)
            {
                if (string.IsNullOrEmpty(source.ToString()))
                    flag = false;
                else
                    flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}