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
using System.Globalization;
using EnvisionOnline.BusinessLogic;

public partial class OnlinePopupDatetime : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            if (Request.QueryString["EXAM_ID"] != null)
                param.EXAM_ID = Request.QueryString["EXAM_ID"];
            setControl();
        }

    }
    protected void rdoChangeDate_CheckedChanged(object source, EventArgs e)
    {
        RadButton clickedButton = (RadButton)source;
        if (clickedButton.Checked)
        {
            int lengthDay = 0;

            if (rdoWeek1.Checked)
                lengthDay = 7;
            if (rdoWeek2.Checked)
                lengthDay = 7 * 2;
            if (rdoWeek4.Checked)
                lengthDay = 7 * 4;
            if (rdoWeek6.Checked)
                lengthDay = 7 * 6;

            if (rdoMonth3.Checked)
                lengthDay = 28*3;
            if (rdoMonth6.Checked)
                lengthDay = 28*6;
            if (rdoMonth9.Checked)
                lengthDay = 28*9;
            
            if (rdoYear1.Checked)
                lengthDay = 364;
            if (rdoYear2.Checked)
                lengthDay = 728;
            DateTime date = DateTime.Now.AddDays(lengthDay);
            setData(date);
        }
    }
    protected void numericValue_TextChanged(object sender, System.EventArgs e)
    {
        setDateDate();
    }
    protected void cmbMode_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        setDateDate();
    }
    private void setDateDate()
    {
        if (!string.IsNullOrEmpty(numericValue.Text))
        {
            double _value = Convert.ToDouble(numericValue.Text);
            string _Mode = cmbMode.Text;
            switch (cmbMode.Text)
            {
                case "Weeks":
                    _value = _value * 7;
                    datetimeChange.SelectedDate = DateTime.Now.AddDays(_value);
                    break;
                case "Months":
                    _value = _value * 28;
                    datetimeChange.SelectedDate = DateTime.Now.AddDays(_value);
                    break;
                case "Years":
                    _value = _value * 364;
                    datetimeChange.SelectedDate = DateTime.Now.AddDays(_value);
                    break;
            }
        }
    }
    private void setControl()
    {
        //this.datetimeChange.TimeView.StartTime = new TimeSpan(8, 8, 8);
        //this.datetimeChange.TimeView.EndTime = new TimeSpan(11, 11, 11);
        //this.datetimeChange.TimeView.Interval = new TimeSpan(0, 30, 0);

        datetimeChange.MinDate = DateTime.Now;
        
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        string _exam_id = param.EXAM_ID;

        DataRow[] rows = dt.Select("EXAM_ID=" + _exam_id);
        //datetimeChange.SelectedDate = Convert.ToDateTime(rows[0]["ORDER_DT"]);
    }
    private void setData(DateTime setDatetime)
    {
        if (setDatetime.Hour == 0 && setDatetime.Minute == 0)
            setDatetime = setDatetime.AddHours(8);

        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        string _exam_id = param.EXAM_ID;
        DataRow[] rows = dt.Select("EXAM_ID=" + _exam_id);

        rows[0]["ORDER_DT"] = setDatetime;
        rows[0]["EXAM_DT"] = setDatetime;
        rows[0]["strEXAM_DT"] = setDatetime.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

        if (!string.IsNullOrEmpty(rows[0]["IS_PORTABLE_VALUE"].ToString()))
            if (rows[0]["IS_PORTABLE_VALUE"].ToString() == "Y")
            {
                DataTable dtPanelPortable = new DataTable();
                RISBaseClass baseMange = new RISBaseClass();
                dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(rows[0]["EXAM_ID"]), param.CLINIC_TYPE_ID);
                foreach (DataRow drPortable in dtPanelPortable.Rows)
                {
                    DataRow[] arryrows = dt.Select("EXAM_ID=" + drPortable["AUTO_EXAM_ID"].ToString());
                    if (arryrows.Length > 0)
                    {
                        arryrows[0]["ORDER_DT"] = setDatetime;
                        arryrows[0]["EXAM_DT"] = setDatetime;
                        arryrows[0]["strEXAM_DT"] = setDatetime.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                    }
                }
            }

        param.dvGridDtl = dt;
        param.dvGridDtlRebind = dt;
        Session["ONL_PARAMETER"] = param;
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        if (datetimeChange.SelectedDate.HasValue)
            setData(datetimeChange.SelectedDate.Value);
    }
}
