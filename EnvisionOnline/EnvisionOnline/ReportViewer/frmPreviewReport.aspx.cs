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
using System.Collections.Generic;
using EnvisionOnline.Operational;
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;

public partial class frmPreviewReport : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setResult();
        }

    }
    private void setResult()
    {
        List<string> keys = new List<string>(Request.Params.AllKeys);

        if (!string.IsNullOrEmpty(keys.Find(x => x.Equals("Accession_no"))))
            Session["PreviewResult.AccessionNumber"] = Request.Params["Accession_no"].ToString();

        string accession_no = string.Empty;
        if (Session["PreviewResult.AccessionNumber"] != null)
        {
            accession_no = Session["PreviewResult.AccessionNumber"].ToString();


            if (!string.IsNullOrEmpty(accession_no))
            {
                GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
                DataTable dt = new DataTable();
                ResultEntry result = new ResultEntry();
                DataSet ds = result.getReportPreview(accession_no);
                if (Utilities.IsHaveData(ds))
                {

                    lblHNText.InnerText = "HN";
                    lblPatientNameText.InnerText = "Patient Name";
                    lblPatientDOBText.InnerText = "Birth Date";
                    lblPatientAgeAndGenderText.InnerText = "Age/Gender";

                    lblRefUnitNameText.InnerText = "Primary Location";
                    lblRefDocNameText.InnerText = "Ordering Physician";

                    lblExamDateText.InnerText = "Study Date";
                    lblRequestNoText.InnerText = "Order #";
                    lblAccessionNoText.InnerText = "Accession #";
                    lblExamNameText.InnerText = "Procedure";
                    lblResultStatusText.InnerText = "Result Status";
                    lblSeverityNameText.InnerText = "Classification";


                    DataRow dr_result = ds.Tables["Result"].Rows[0];
                    DataRow[] drs_addendum = ds.Tables["Addendum"].Select(string.Format("ACCESSION_NO = '{0}'", accession_no));

                    lblOrgNameValue.InnerText = string.Format("{0} - Radiology Report", dr_result["ORG_ALIAS"].ToString());

                    lblHNValue.InnerText = dr_result["HN"].ToString();
                    lblPatientNameValue.InnerText = dr_result["PATIENT_NAME"].ToString();
                    lblPatientDOBValue.InnerText = Utilities.ToDateTime(dr_result["PATIENT_DOB"]).ToString("dd/MM/yyyy");
                    lblPatientAgeAndGenderValue.InnerText = string.Format("{0}/{1}", dr_result["PATIENT_AGE"].ToString(), dr_result["PATIENT_GENDER"].ToString());

                    lblRefUnitNameValue.InnerText = dr_result["REF_UNIT_NAME"].ToString();
                    lblRefDocNameValue.InnerText = dr_result["REF_DOC_NAME"].ToString();

                    lblExamDateValue.InnerText = Utilities.ToDateTime(dr_result["EXAM_DT"]).ToString("dd/MM/yyyy HH:mm:ss");
                    lblRequestNoValue.InnerText = dr_result["REQUESTNO"].ToString();
                    lblAccessionNoValue.InnerText = dr_result["ACCESSION_NO"].ToString();
                    lblExamNameValue.InnerText = dr_result["EXAM_NAME"].ToString();
                    lblResultStatusValue.InnerText = dr_result["StatusText"].ToString();
                    lblSeverityNameValue.InnerText = dr_result["SEVERITY_NAME"].ToString();


                    if (string.IsNullOrEmpty(dr_result["RESULT_TEXT_HTML"].ToString()))
                    {
                        string Htmlresult = @"<font face='Times New Roman' size='3' color='white'>Report isn't available</font>";
                        divResult.InnerHtml = Htmlresult;
                    }
                    else
                    {
                        string Htmlresult = string.Empty;

                        Htmlresult += @"<font face='Times New Roman' size='3' color='white'>";

                        if (dr_result["STATUS"].ToString() == "P")
                        {
                            //result += @"(เอกสารใช้เฉพาะประกอบการคัดกรองผู้ป่วยของสถาบันโรคทรวงอกเท่านั้น)";
                            //result += @"<br/>";
                            //result += @"<br/>";
                        }

                        Htmlresult += getResultHtml(dr_result["RESULT_TEXT_HTML"].ToString(), drs_addendum);
                        divResult.InnerHtml = Htmlresult;
                    }
                }
                else
                {
                    setControls();
                }
            }
        }
        else
        {
            setControls();
        }
    }
    private void setControls()
    {

        lblHNText.InnerText = "Report isn't available";
        lblPatientNameText.InnerText = "";
        lblPatientDOBText.InnerText = "";
        lblPatientAgeAndGenderText.InnerText = "";

        lblRefUnitNameText.InnerText = "";
        lblRefDocNameText.InnerText = "";

        lblExamDateText.InnerText = "";
        lblRequestNoText.InnerText = "";
        lblAccessionNoText.InnerText = "";
        lblExamNameText.InnerText = "";
        lblResultStatusText.InnerText = "";
        lblSeverityNameText.InnerText = "";
    }
    private string getResultHtml(string resultHtml, DataRow[] addendum)
    {
        string result = string.Empty;

        if (Utilities.IsHaveData(addendum))
        {
            int length = addendum.Length;
            int counter = 0;

            result = string.Empty;

            for (int i = 0; i < length; length--)
            {
                DataRow dr = addendum[counter++];

                result += @"<font face='Times New Roman' size='3' color='white'>";
                result += string.Format("Addendum {0} ", length.ToString());
                result += string.Format("Written By {0} ", dr["Radiologist"].ToString());
                result += string.Format("Date {0:dd/MM/yyy}", Convert.ToDateTime(dr["NOTE_ON"]));
                result += @"</font>";
                result += @"<br/>";
                result += @"<font face='Times New Roman' size='3' color='white'>";
                result += dr["RESULT_TEXT"].ToString();
                result += @"</font>";
                result += @"<br/>";
                result += @"<br/>";
            }

            result += @"<br/>";
            result += @"<font face='Times New Roman' size='3' color='white'>";
            result += @"-------------------------";
            result += @"</font>";
            result += @"<br/>";
            result += @"<br/>";
        }

        result += resultHtml;

        return result
            .Replace("\r\n", "<br/>")
            .Replace("\n", "<br/>")
            .Replace("\r", "<br/>");
    }
        
}
