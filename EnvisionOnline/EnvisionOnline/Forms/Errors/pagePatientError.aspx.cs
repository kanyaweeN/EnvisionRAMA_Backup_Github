using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.Common;

namespace EnvisionOnline.Forms.Errors
{
    public partial class pagePatientError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            string str = string.Empty;
            str += "HN : " + param.HN + "\r\n";
            str += "USER_NAME : " + param.USER_NAME + "\r\n";
            str += "UNIT : " + param.REF_UNIT_UID + "\r\n";
            str += "CLINIC : " + param.ENC_CLINIC + "\r\n";
            str += "INSR : " + param.INSURANCE_TYPE_UID + "\r\n";
            str += "ROLE : " + param.ROLE + "\r\n";
            str += "ENC : " + param.ENCOUNTER_TYPE + "\r\n";
            str += "FORM : " + param.FORM + "\r\n";
            if (Session["strError"] != null)
                str += Session["strError"].ToString();

            txtShowErrorMessage.Text = str;
        }

    }
}