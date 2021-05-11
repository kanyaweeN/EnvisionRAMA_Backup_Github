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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using EnvisionOnline.Common;
using System.Collections;
using System.Collections.Generic;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblAlert.Visible = false;
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        bool flag = false;
        ProcessGetHREmp hrEmp = new ProcessGetHREmp();
        hrEmp.HR_EMP.EMP_UID = UserName.Text;
        hrEmp.checkUser();
        DataSet dsAccount = hrEmp.Result;
        if (Utilities.IsHaveData(dsAccount))
        {
            DataView dv = dsAccount.Tables[0].DefaultView;
            dv.RowFilter = "PWD='" + Utilities.Encrypt(Password.Text.Trim()) + "' and SUPPORT_USER='Y' and IS_ACTIVE='Y'";
            DataTable dt = dv.ToTable();
            if (!Utilities.IsHaveData(dt))
                flag = true;

        }
        else
            flag = true;

        lblAlert.Visible = flag;
        if (!flag)
        {
            LoadUserData(UserName.Text.Trim());
            Session["UserLogin"] = UserName.Text;
            Session["PasswordLogin"] = Password.Text;
            string _redirect = @"Forms/Admin/frmManualParameter.aspx";
            Response.Redirect(_redirect);
        }
    }
    private void LoadUserData(string emp_uid)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;

        if (env == null)
        {
            RISBaseClass ris_base = new RISBaseClass();
            ris_base.HR_EMP.MODE = "UserName";
            ris_base.HR_EMP.EMP_UID = emp_uid;

            DataTable dt = ris_base.check_HR_Emp();
            if (Utilities.IsHaveData(dt))
            {
                env = new GBLEnvVariable();
                env.ActiveDate = DateTime.Today;
                env.AuthLevelID = dt.Rows[0]["AUTH_LEVEL_ID"].ToString();
                env.CurrentLanguageID = 1;
                env.LangName = "Thai";

                env.FirstName = dt.Rows[0]["FNAME"].ToString();
                env.FirstNameEng = dt.Rows[0]["FNAME_ENG"].ToString();
                env.LastName = dt.Rows[0]["LNAME"].ToString();
                env.LastNameEng = dt.Rows[0]["LNAME_ENG"].ToString();
                env.LoginType = dt.Rows[0]["JOB_TYPE"].ToString();
                env.OrgID = Convert.ToInt32(dt.Rows[0]["ORG_ID"]);
                env.SUPPORT_USER = dt.Rows[0]["SUPPORT_USER"].ToString();
                env.TitleEng = dt.Rows[0]["TITLE_ENG"].ToString();
                env.UserID = Convert.ToInt32(dt.Rows[0]["EMP_ID"]);
                env.UserName = dt.Rows[0]["USER_NAME"].ToString();
                env.UserUID = dt.Rows[0]["EMP_UID"].ToString();

                DataTable dtGBL = Application["GBL_ENV"] as DataTable;

                env.TimeFormat = dtGBL.Rows[0]["TIME_FMT"].ToString();
                env.WebServiceIP = dtGBL.Rows[0]["WS_IP"].ToString();
                env.WebServiceIP_PICTURE = dtGBL.Rows[0]["WS_IP_PICTURE"].ToString();
                env.OrgaizationName = dtGBL.Rows[0]["ORG_NAME"].ToString();
                env.CurrencyFormat = dtGBL.Rows[0]["CURRENCY_FMT"].ToString();
                env.DateFormat = dtGBL.Rows[0]["DT_FMT"].ToString();
                env.FontName = dtGBL.Rows[0]["DEFAULT_FONT_FACE"].ToString();
                env.FontSize = dtGBL.Rows[0]["DEFAULT_FONT_SIZE"].ToString();
                env.PacsIp = dtGBL.Rows[0]["PACS_IP"].ToString();
                env.PacsPort = dtGBL.Rows[0]["PACS_PORT"].ToString();
                env.PacsUrl = dtGBL.Rows[0]["PACS_URL1"].ToString();
                env.PacsUrl2 = dtGBL.Rows[0]["PACS_URL2"].ToString();
                env.PacsUrl3 = dtGBL.Rows[0]["PACS_URL3"].ToString();
                env.TemplateID = 0;
                env.CurrencyName = string.Empty;
                env.CurrencySymbol = string.Empty;
                env.USED_120DPI = "N";
                env.USED_MENUBAR = "N";
            }
            
            Session["GBLEnvVariable"] = env;
        }
    }
}
