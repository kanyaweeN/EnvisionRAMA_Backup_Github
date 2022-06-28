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
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessRead;
using System.Collections;
using System.Drawing;
using EnvisionOnline.Common.Common;
using EnvisionOnline.PACS;

public partial class frmEnvisionReprintReport : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox txt = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");
            txt.Text = string.Empty;

            GBLEnvVariable env = new GBLEnvVariable() ;
            DataTable dtGBL = Application["GBL_ENV"] as DataTable;

            env = new GBLEnvVariable();
            env.ActiveDate = DateTime.Today;
            env.AuthLevelID = "";
            env.CurrentLanguageID = 1;
            env.LangName = "Thai";

            env.FirstName = "";
            env.FirstNameEng = "";
            env.LastName = "";
            env.LastNameEng = "";
            env.LoginType = "";
            env.OrgID = 1;
            env.SUPPORT_USER = "N";
            env.TitleEng = "";
            env.UserID = 0;
            env.UserName = "";
            env.UserUID = "";

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
            env.PacsDomain = dtGBL.Rows[0]["PACS_DOMAIN"].ToString();
            env.TemplateID = 0;
            env.CurrencyName = string.Empty;
            env.CurrencySymbol = string.Empty;
            env.USED_120DPI = "N";
            env.USED_MENUBAR = "N";

            Session["GBLEnvVariable"] = env;
        }
    }
    private void LoadData()
    {
        
        TextBox txt = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");

        ResultEntryWorkList _wl = new ResultEntryWorkList();
        _wl.SpType = 5;
        _wl.FromDate = DateTime.Now;
        _wl.ToDate = DateTime.Now;
        _wl.OrgID = 1;
        _wl.PatientID = txt.Text.Trim();

        ProcessGetResultEntryWorkListByHN lkp = new ProcessGetResultEntryWorkListByHN();
        lkp.ResultEntryWorkList = _wl;
        lkp.Invoke();

        Session["DATAWORKLIST"] = lkp.ResultSet.Tables[0];
    }
    protected void grdData_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadData();
        DataTable dt = Session["DATAWORKLIST"] as DataTable;
        fillDataGridDataTable(grdData, dt);
    }
    protected void grdData_ItemCommand(object source, GridCommandEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);

        if (e.CommandName == "grdbtnSynapse")
        {
            //string url = env.PacsUrl + values["Accession No"].ToString();
            string url = values["Accession No"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSynapse", "showNewWindows('" + url + "');", true);
            //new OpenPACS(env, env.PacsUrl).OpenIEAccession(url, env.UserName, env.PasswordAD, "", env.LoginType);

        }
        else if (e.CommandName == "grdbtnPrintA5")
        {
            string url = "";
            switch (values["RESULT_STATUS"].ToString().Substring(0,1))
            {
                case "P":
                case "F":
                    url += "../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptResultReportEnvision&PAPERKIND=A5&IS_ONLINE=&ACCESSION_NO=" + values["Accession No"].ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    break;
                default: 
                        showOnlineMessageBox("ManualPopup");
                    break;
            }
        }
        else if (e.CommandName == "grdbtnPrintA4")
        {
            string url = "";
            switch (values["RESULT_STATUS"].ToString().Substring(0, 1))
            {
                case "P":
                case "F":
                    url += "../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptResultReportEnvision&PAPERKIND=A4&IS_ONLINE=&ACCESSION_NO=" + values["Accession No"].ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    break;
                default:
                    showOnlineMessageBox("ManualPopup");
                    break;
            }
        }
    }

    protected void grdData_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            GridDataItem gridDataItem = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;
            //DateTime dt = Convert.ToDateTime(dv.Row["ORDER_DT"]);
            //((GridDataItem)e.Item)["colOrderDT"].Text = dt.ToString("dd MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

            ImageButton imgBtnSynpase = (ImageButton)gridDataItem["grdbtnSynapse_Unigue"].Controls[0];

            bool flag = false;
            bool flagSynapse = false;
            //if (Convert.ToBoolean(dv.Row["ONL_REQ"]))
            //{
            //    switch (dv.Row["STATUS"].ToString())
            //    {
            //        case "R": flag = true; break;
            //        case "W": flag = true; break;
            //        case "S":
            //            gridDataItem["colSTATUS_TEXT"].BackColor = Color.Pink; // chanmge particuler cell
            //            e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
            //            break;
            //    }
            //}
            switch (dv.Row["RESULT_STATUS"].ToString().Substring(0,1))
            {
                case "C": flagSynapse = true; break;
                case "D": flagSynapse = true; break;
                case "P": flagSynapse = true; break;
                case "F": flagSynapse = true; break;
            }

            imgBtnSynpase.Enabled = flagSynapse;
            imgBtnSynpase.ImageUrl = flagSynapse ? "../../Resources/Logo/synapse16.jpg" : "../../Resources/Logo/synapse16_gray.jpg";

        }

    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        LoadData();
        DataTable dt = Session["DATAWORKLIST"] as DataTable;
        fillDataGrid_Filter(grdData, dt);
    }

    private void showOnlineMessageBox(string messagePopup)
    {
        DataTable dtAlert = new DataTable();
        dtAlert.Columns.Add("ALT_TEXT");
        dtAlert.Columns.Add("ALT_BUTTON");
        dtAlert.Columns.Add("CAPTION_BTN1");
        dtAlert.Columns.Add("CAPTION_BTN2");
        dtAlert.Columns.Add("CAPTION_BTN3");
        dtAlert.Columns.Add("ALT_TYPE");
        dtAlert.AcceptChanges();
        dtAlert.Rows.Add("\r\n* ไม่มีผลอ่านของแพทย์ \r\n * กรุณาตรวจสอบใน Synapse \r\n(ในกรณีที่เป็น CT,MRI)"
                        , 1, "ตกลง", "", "", "W");
        dtAlert.AcceptChanges();
        Session["dtAlert"] = dtAlert;

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "');", true);
    }
    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
}
