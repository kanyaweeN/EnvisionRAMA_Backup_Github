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

public partial class OnlineMultiMessageBox : System.Web.UI.Page 
{
    private string atl_uid, destination;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["FROM"] != null)
                destination = Request.QueryString["FROM"].ToString();
            if (Request.QueryString["ALT_UID"] != null)
                atl_uid = Request.QueryString["ALT_UID"].ToString();

            setControlMessageBoxNon();
        }
    }
    private void setControlMessageBoxNon()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        DataTable dt = ris_base.get_GBL_Alert(atl_uid, env.CurrentLanguageID);
        int i = 0;
        string txtMessage = "";
        string noOfButton = "";
        string cap1 = "";
        string cap2 = "";
        string cap3 = "";
        string alttype = "";

        while (i < dt.Rows.Count)
        {
            txtMessage = dt.Rows[i]["ALT_TEXT"].ToString();
            noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
            cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
            cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
            cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
            alttype = dt.Rows[i]["ALT_TYPE"].ToString();

            i++;
        }
        if (dt.Rows.Count > 0)
        {
            setBinddingControl(txtMessage, noOfButton, cap1, cap2, cap3, alttype);
        }
    }
    private void setControlMessageBox()
    {
        DataTable dt = (DataTable)Session["dtAlert"];
        int i = 0;
        string txtMessage = "";
        string noOfButton = "";
        string cap1 = "";
        string cap2 = "";
        string cap3 = "";
        string alttype = "";

        while (i < dt.Rows.Count)
        {
            txtMessage = dt.Rows[i]["ALT_TEXT"].ToString();
            noOfButton = dt.Rows[i]["ALT_BUTTON"].ToString();
            cap1 = dt.Rows[i]["CAPTION_BTN1"].ToString();
            cap2 = dt.Rows[i]["CAPTION_BTN2"].ToString();
            cap3 = dt.Rows[i]["CAPTION_BTN3"].ToString();
            alttype = dt.Rows[i]["ALT_TYPE"].ToString();

            i++;
        }
        if (dt.Rows.Count > 0)
        {
            setBinddingControl(txtMessage, noOfButton, cap1, cap2, cap3, alttype);
        }
    }
    private void setBinddingControl(string txtMessage, string noOfButton, string cap1, string cap2, string cap3, string alttype)
    {
        lblShowText.Text = txtMessage;
        switch (noOfButton)
        {
            case "1":
                btn1.Text = cap1;
                btn2.Visible = false;
                btn3.Visible = false;
                break;
            case "2":
                btn1.Text = cap2;
                btn2.Text = cap1;
                btn3.Visible = false;
                break;
            case "3":
                btn1.Text = cap3;
                btn2.Text = cap2;
                btn3.Text = cap1;
                break;
        }
        switch (alttype)
        {
            case "W":
                imgAlert.ImageUrl = "../../Resources/ICON/MessageBoxs/help48.jpg";
                break;
            default:
                imgAlert.ImageUrl = "../../Resources/ICON/MessageBoxs/priority1_48.jpg";
                break;
        }
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        Session["MessageBoxValue"] = "1";
        setReturnValue();
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Session["MessageBoxValue"] = "2";
        setReturnValue();
    }
    protected void btn3_Click(object sender, EventArgs e)
    {
        Session["MessageBoxValue"] = "3";
        setReturnValue();
    }
    private void setReturnValue()
    {
        bool is_multipopup = Session["IS_MULTIPOPUP"] == null ? false : Convert.ToBoolean(Session["IS_MULTIPOPUP"]);
        string multi_name = Session["MULTIPOPUP_NAME"] == null ? "" : Session["MULTIPOPUP_NAME"].ToString();
        if (is_multipopup)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "returnValue('" + Request.QueryString["ALT_UID"].ToString() + "','" + multi_name + "');", true);
        else
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('" + Request.QueryString["ALT_UID"].ToString() + "');", true);

    }
}
