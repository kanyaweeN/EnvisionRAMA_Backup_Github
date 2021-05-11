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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using EnvisionOnline.Operational;
using System.Globalization;
using EnvisionOnline.Common;
using System.IO;
using System.Drawing;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class frmEnvisionOrderWL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
            refreshSetupData();
            LoadUserData();
            CheckForm();
            BindingPatientData();
            BindingQuickExam();
        }
    }
    #region Header
    private void refreshSetupData() {
        RISBaseClass baseManage = new RISBaseClass();
        DataTable dtt = baseManage.get_His_Department(1);
        dtt.PrimaryKey = new[] { dtt.Columns["UNIT_ID"] };
        Application["UnitData"] = dtt;

        dtt = baseManage.get_Ris_Radiologist();
        Application["RISDoctorData"] = dtt;

        dtt = baseManage.get_HIS_ICD();
        dtt.Columns.Add("ICD_FULL_TEXT");
        Application["HisICDData"] = dtt;

        dtt = baseManage.get_ONL_GroupExamtype();
        Application["ONL_GROUPEXAMTYPE"] = dtt;

        dtt = baseManage.get_ONL_GroupExam();
        Application["ONL_GROUPEXAM"] = dtt;

        dtt = baseManage.get_ONL_GroupDepartment();
        Application["ONL_GROUPDEPARTMENT"] = dtt;
    }
    private void LoadUserData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        //if (env == null)
        //{
        RISBaseClass ris_base = new RISBaseClass();
        ris_base.HR_EMP.MODE = "UserName";
        ris_base.HR_EMP.EMP_UID = param.USER_NAME;

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

            param.EmpName = dt.Rows[0]["FullName"].ToString();
        }
        else
        {
            EnvisionOnline.Webservice.HISWebService.Service serHIS = new EnvisionOnline.Webservice.HISWebService.Service();
            DataSet ds = serHIS.Get_staff_fulldetail(param.USER_NAME);
            if (Utilities.IsHaveData(ds))
            {
                insertHR_EMP(ds.Tables[0].Rows[0]["pid"].ToString(), ds.Tables[0].Rows[0]["name"].ToString());
                ris_base.HR_EMP.MODE = "UserName";
                ris_base.HR_EMP.EMP_UID = param.USER_NAME;
                dt = ris_base.check_HR_Emp();
                if (Utilities.IsHaveData(dt))
                {

                    updateRole(dt.Rows[0]["EMP_ID"].ToString(), ds.Tables[0].Rows[0]["role"].ToString());
                    RISBaseClass baseManage = new RISBaseClass();
                    DataTable dtt = baseManage.get_His_Doctor(1);
                    dtt.PrimaryKey = new[] { dtt.Columns["EMP_ID"] };
                    Application["HisDoctorData"] = dtt;

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

                    param.EmpName = dt.Rows[0]["FullName"].ToString();
                }
            }
            else
            {
                string url = "USERNAME=" + param.USER_NAME;
                Response.Redirect(@"../../Forms/Dialogs/OnlineNewEmployee.aspx?" + url, true);
            }
        }
        Session["GBLEnvVariable"] = env;
        Session["ONL_PARAMETER"] = param;
        //}
    }
    private void insertHR_EMP(string ID, string Name)
    {
        try
        {
            GBLEnvVariable env = new GBLEnvVariable();
            ProcessAddHREmp proEMP = new ProcessAddHREmp();
            proEMP.HR_EMP.EMP_UID = ID;
            proEMP.HR_EMP.USER_NAME = ID;
            string[] name = Name.Trim().Split(' '.ToString().ToCharArray());
            proEMP.HR_EMP.FNAME = name[0];
            proEMP.HR_EMP.LNAME = name[2];
            proEMP.HR_EMP.ORG_ID = env.OrgID;
            proEMP.HR_EMP.CREATED_BY = env.UserID;
            proEMP.AddFromHis();
        }
        catch { }
    }
    private void updateRole(string id, string role)
    {
        try
        {
            char jobType = 'N';
            switch (role.Substring(0, 1))
            {
                case "S": jobType = 'D'; break;
                case "T": jobType = 'T'; break;
                case "U": jobType = 'T'; break;
                case "N": jobType = 'N'; break;
                case "M": jobType = 'M'; break;
                case "P": jobType = 'N'; break;
                case "G": jobType = 'N'; break;
                case "W": jobType = 'N'; break;
                case "L": jobType = 'N'; break;
                case "R": jobType = 'D'; break;
                case "A": jobType = 'D'; break;
                default: jobType = 'N'; break;
            }
            ProcessUpdateHREmp upRole = new ProcessUpdateHREmp();
            upRole.HR_EMP.EMP_ID = Convert.ToInt32(id);
            upRole.HR_EMP.JOB_TYPE = jobType;
            upRole.Invoke();
        }
        catch { }
    }
    private void CheckForm()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        RadDatePicker dtFromDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtFromDate");
        RadDatePicker dtToDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtToDate");
        dtFromDate.Culture = CultureInfo.GetCultureInfo("th-TH");
        dtToDate.Culture = CultureInfo.GetCultureInfo("th-TH");
        if (param.REF_UNIT_UID == "0")
            rtbMainWL.Visible = false;
        else
            rtbMainWL.Visible = true;
        rtoolPatient.Visible = true;
        //switch (param.FORM)
        //{
        //    case "O1":
        //        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        //        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //        rtbMainWL.Visible = false;
        //        rtoolPatient.Visible = false;
        //        break;
        //    default:
        //        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        //        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //        break;
        //}

        //switch (param.FORM)
        //{
        //    case "O1":
        //        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        //        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //        rtbMainWL.Visible = true;
        //        rtoolPatient.Visible = true;
        //        break;
        //    case "O2":
        //    case "W":
        //        //dtFromDate.SelectedDate = DateTime.Now;
        //        //dtToDate.SelectedDate = DateTime.Now;
        //        //rtbMainWL.Visible = true;
        //        //rtoolPatient.Visible = false;
        //        //break;
        //    case "R1":
        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //rtbMainWL.Visible = true;
        //rtoolPatient.Visible = false;
        //        break;
        //    case "R2":
        //        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        //        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //        rtbMainWL.Visible = true;
        //        rtoolPatient.Visible = false;
        //        break;
        //    case "A1":
        //        dtFromDate.SelectedDate = DateTime.Now.AddMonths(-3);
        //        dtToDate.SelectedDate = DateTime.Now.AddMonths(+6);
        //        rtbMainWL.Visible = true;
        //        rtoolPatient.Visible = true;
        //        break;
        //}
    }
    private void BindingPatientData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        #region Load Control Patient
        Label lblHN = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblHN");
        Label lblPatientName = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblPatientName");
        Label lblGender = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblGender");
        Label lblAge = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblAge");
        Label lblDOB = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblDOB");
        Label lblPhone = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblPhone");
        Label lblNonResident = (Label)rtoolPatient.Items.FindItemByValue("rtoolbtnPatient").FindControl("lblNonResident");
        #endregion

        PatientClass getPatient = new PatientClass();

        string _hn = param.HN;
        DataSet ds = new DataSet();
        if (param.dsPatientData == null)
        {
            bool isTele = false;
            int encId = 0;
            ds = param.dsPatientData = getPatient.get_Patient_Registration_ByHN(_hn, env, false);
            param.IS_NONRESIDENT = getPatient.get_Patient_NonResident(_hn, out isTele, out encId);
            param.IS_TELEMED = isTele;
            param.ENC_ID = encId;
        }
        else
            ds = param.dsPatientData;

        if (Utilities.IsHaveData(ds))
        {
            lblEmployeeName.Text = param.EmpName;
            lblHN.Text = _hn;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                param.REG_ID = Convert.ToInt32(dr["REG_ID"]);
                lblPatientName.Text = dr["TITLE"].ToString() + dr["FNAME"].ToString() + " " + dr["LNAME"].ToString();
                switch (dr["GENDER"].ToString())
                {
                    case "M": lblGender.Text = "Male"; break;
                    case "F": lblGender.Text = "Female"; break;
                    default: lblGender.Text = "Other"; break;
                }

                lblAge.Text = dr["AGE2"].ToString();
                try
                {
                    lblDOB.Text = Utilities.ToStringDatetimeTH("d MMM yyyy", Convert.ToDateTime(dr["DOB"]));
                    param.IS_CHILDEN = (DateTime.Now.Year - Convert.ToDateTime(dr["DOB"]).Year) <= 15 ? true : false;
                }
                catch (Exception ex)
                {
                    param.IS_CHILDEN = true;
                }
                lblPhone.Text = dr["PHONE1"].ToString();
            }
            lblNonResident.Text = param.IS_NONRESIDENT ? "Non-Resident" : "";
            Session["ONL_PARAMETER"] = param;
        }
        else
        {
            ProcessAddONLHISLinkLogs prc = new ProcessAddONLHISLinkLogs();
            prc.ONL_HISLINKLOG.HIS_URL = Request.Url.ToString();
            prc.ONL_HISLINKLOG.HN = param.HN;
            prc.ONL_HISLINKLOG.USER_NAME = param.USER_NAME;
            prc.ONL_HISLINKLOG.UNIT = param.REF_UNIT_UID;
            prc.ONL_HISLINKLOG.CLINIC = param.ENC_CLINIC;
            prc.ONL_HISLINKLOG.INSR = param.INSURANCE_TYPE_UID;
            prc.ONL_HISLINKLOG.ROLE = param.ROLE;
            prc.ONL_HISLINKLOG.ENC = param.ENCOUNTER_TYPE;
            prc.ONL_HISLINKLOG.FORM = param.FORM;
            prc.ONL_HISLINKLOG.LOG_DESC = "PatientError";
            prc.ONL_HISLINKLOG.BROWSER_TYPE = Request.Browser.Type;
            prc.ONL_HISLINKLOG.USER_HOST_ADDRESS = Request.UserHostAddress;
            prc.Invoke();

            Response.Redirect(@"../../Forms/Errors/pagePatientError.aspx", true);
        }

        RISBaseClass baseManage = new RISBaseClass();
        DataTable dtPatStatus = (DataTable)Application["PatientStatusData"];

        DataTable dtClinicType = (DataTable)Application["ClinicTypeData"];
        DataTable dtInsurance = (DataTable)Application["InsuranceTypeData"];
        DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];
        DataTable dtDept = Application["UnitData"] as DataTable;

        Label txtInsurance = rtoolHISPatient.FindItemByValue("rtoolbtnHISPatient").FindControl("txtInsurance") as Label;
        Label txtRefUnit = rtoolHISPatient.FindItemByValue("rtoolbtnHISPatient").FindControl("txtRefUnit") as Label;
        Label txtClinicType = rtoolHISPatient.FindItemByValue("rtoolbtnHISPatient").FindControl("txtClinicType") as Label;

        switch (param.ENC_CLINIC)
        {
            case "RGL": param.CLINIC_TYPE = "Normal"; break;
            case "SPC": param.CLINIC_TYPE = "Special"; break;
            case "PM": param.CLINIC_TYPE = "VIP"; break;
            default: param.CLINIC_TYPE = "Normal"; break;
        }

        string strClinicTypeUID = param.CLINIC_TYPE; //param.dvGridDtl.Rows.Count > 0 ? param.dvGridDtl.Rows[0]["CLINIC_TYPE_UID"].ToString() : param.CLINIC_TYPE;
        DataRow[] rowClinic = dtClinicType.Select("CLINIC_TYPE_UID='" + strClinicTypeUID + "'");
        txtClinicType.Text = rowClinic[0]["CLINIC_TYPE_ONLINEDESC"].ToString();
        param.CLINIC_TYPE_ID = Convert.ToInt32(rowClinic[0]["CLINIC_TYPE_ID"]);

        string strInsuranceTypeUID = param.INSURANCE_TYPE_UID;
        DataRow[] rowIns = dtInsurance.Select("INSURANCE_TYPE_UID='" + strInsuranceTypeUID + "'");
        if (rowIns.Length == 0)
        {
            dtInsurance = baseManage.get_Ris_InsuranceType(env.OrgID);
            rowIns = dtInsurance.Select("INSURANCE_TYPE_UID='" + strInsuranceTypeUID + "'");
            if (rowIns.Length > 0)
                Application["InsuranceTypeData"] = dtInsurance;
        }

        txtInsurance.Text = rowIns[0]["INSURANCE_TYPE_DESC"].ToString();
        param.INSURANCE_TYPE_ID = Convert.ToInt32(rowIns[0]["INSURANCE_TYPE_ID"]);

        DataView dv = new DataView();
        DataTable dtt = new DataTable();
        dv = dtDept.DefaultView;
        dv.RowFilter = "UNIT_UID='" + param.REF_UNIT_UID + "'";
        dtt = dv.ToTable();
        if (dtt.Rows.Count == 0){
            txtRefUnit.Text = param.REF_UNIT_UID;
            param.REF_UNIT_ID = Convert.ToInt32(param.REF_UNIT_UID);
        }
        else
        {
            txtRefUnit.Text = dtt.Rows[0]["UNIT_UID"].ToString() + ":" + dtt.Rows[0]["UNIT_NAME"].ToString();
            param.REF_UNIT_ID = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"].ToString());
        }

        DataTable dtPatDest = baseManage.get_PAT_DEST_ID(param.REF_UNIT_ID, param.CLINIC_TYPE_ID);
        if (Utilities.IsHaveData(dtPatDest))
        {
            DataTable checkCTMR = baseManage.getFlagCTMR(Convert.ToInt32(dtPatDest.Rows[0]["PAT_DEST_ID"]));
            //if (dtPatDest.Rows[0]["PAT_DEST_ID"].ToString() == "3" || dtPatDest.Rows[0]["PAT_DEST_ID"].ToString() == "2")
            if (Utilities.IsHaveData(checkCTMR))
                if (checkCTMR.Rows[0]["FLAG_CTMR"].ToString() == "Y")
                    param.FlagCTMR = true;

            param.PAT_DEST_ID = Convert.ToInt32(dtPatDest.Rows[0]["PAT_DEST_ID"]);
        }
    }
    private void BindingQuickExam()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass baseMange = new RISBaseClass();

        if(param.REF_UNIT_UID == "0") return;
        DataTable dt = baseMange.get_Ris_ModalityExamFavorite(env == null ? 1 : env.UserID, 0, env == null ? 1 : env.OrgID);
        if (dt.Rows.Count <= 10)
        {
            DataTable dtDept = (DataTable)Application["UnitData"];
            DataRow[] rowRefUnit = dtDept.Select("UNIT_UID='" + param.REF_UNIT_UID + "'");
            param.REF_UNIT_ID = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

            int lengthDay = 0;
            int value = Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);

            lengthDay = 30;
            //dt = baseMange.get_Ris_ModalityExamTop10(value, lengthDay);
            ///////////////// Start Mootoo /////////////////////////
            DataTable dtTop = new DataTable();
            dtTop = baseMange.get_Ris_ModalityExamTop10(value, lengthDay);

            dt.Merge(dtTop.Copy());

            ///////////////// End Mootoo /////////////////////////

        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strImageUrl = "";
            switch (dt.Rows[i]["EXAM_TYPE"].ToString())
            {
                case "2": strImageUrl = "../../Resources/ICON/CT32.png"; break;
                case "3": strImageUrl = "../../Resources/ICON/CR32.png"; break;
                case "4": strImageUrl = "../../Resources/ICON/US_2_32.png"; break;
                default: strImageUrl = "../../Resources/ICON/CR32.png"; break;
            }
            switch (i)
            {
                case 0:
                    RadToolBarButton btnQuickOrder = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder");
                    btnQuickOrder.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder.ImageUrl = strImageUrl;
                    btnQuickOrder.Visible = true;
                    param.QUICKEXAM1_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 1:
                    RadToolBarButton btnQuickOrder2 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder2");
                    btnQuickOrder2.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder2.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder2.ImageUrl = strImageUrl;
                    btnQuickOrder2.Visible = true;
                    param.QUICKEXAM2_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 2:
                    RadToolBarButton btnQuickOrder3 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder3");
                    btnQuickOrder3.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder3.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder3.ImageUrl = strImageUrl;
                    btnQuickOrder3.Visible = true;
                    param.QUICKEXAM3_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 3:
                    RadToolBarButton btnQuickOrder4 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder4");
                    btnQuickOrder4.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder4.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder4.ImageUrl = strImageUrl;
                    btnQuickOrder4.Visible = true;
                    param.QUICKEXAM4_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 4:
                    RadToolBarButton btnQuickOrder5 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder5");
                    btnQuickOrder5.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder5.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder5.ImageUrl = strImageUrl;
                    btnQuickOrder5.Visible = true;
                    param.QUICKEXAM5_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 5:
                    RadToolBarButton btnQuickOrder6 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder6");
                    btnQuickOrder6.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder6.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder6.ImageUrl = strImageUrl;
                    btnQuickOrder6.Visible = true;
                    param.QUICKEXAM6_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 6:
                    RadToolBarButton btnQuickOrder7 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder7");
                    btnQuickOrder7.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder7.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder7.ImageUrl = strImageUrl;
                    btnQuickOrder7.Visible = true;
                    param.QUICKEXAM7_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 7:
                    RadToolBarButton btnQuickOrder8 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder8");
                    btnQuickOrder8.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder8.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder8.ImageUrl = strImageUrl;
                    btnQuickOrder8.Visible = true;
                    param.QUICKEXAM8_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 8:
                    RadToolBarButton btnQuickOrder9 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder9");
                    btnQuickOrder9.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder9.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder9.ImageUrl = strImageUrl;
                    btnQuickOrder9.Visible = true;
                    param.QUICKEXAM9_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
                case 9:
                    RadToolBarButton btnQuickOrder10 = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnQuickOrder10");
                    btnQuickOrder10.Text = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder10.ToolTip = dt.Rows[i]["EXAM_NAME"].ToString();
                    btnQuickOrder10.ImageUrl = strImageUrl;
                    btnQuickOrder10.Visible = true;
                    param.QUICKEXAM10_ID = Convert.ToInt32(dt.Rows[i]["EXAM_ID"]);
                    break;
            }
        }
        ProcessGetVNAHRUnit vna_checkUnit = new ProcessGetVNAHRUnit();
        DataSet ds_vna_checkUnit = vna_checkUnit.CheckUnit(param.REF_UNIT_UID);
        if (Utilities.IsHaveData(ds_vna_checkUnit))
        {
            RadToolBarButton btnVNA = (RadToolBarButton)rtbMainWL.Items.FindItemByValue("btnVNA");
            btnVNA.Visible = true;
        }

        Session["ONL_PARAMETER"] = param;
    }
    protected void btnLogout_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("../../Logout.aspx");
    }
    #endregion
    #region Ribbon
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        param.QUICKEXAM_MODE = "ORDER";
        switch (e.Item.Value.ToString())
        {
            case "btnNewOrder": setPageDetail("0", "0"); break;
            case "btnRefresh": modifiedData_grdData(); break;
            case "btnQuickOrder": checkSchedule(param.QUICKEXAM1_ID); break;
            case "btnQuickOrder2": checkSchedule(param.QUICKEXAM2_ID); break;
            case "btnQuickOrder3": checkSchedule(param.QUICKEXAM3_ID); break;
            case "btnQuickOrder4": checkSchedule(param.QUICKEXAM4_ID); break;
            case "btnQuickOrder5": checkSchedule(param.QUICKEXAM5_ID); break;
            case "btnQuickOrder6": checkSchedule(param.QUICKEXAM6_ID); break;
            case "btnQuickOrder7": checkSchedule(param.QUICKEXAM7_ID); break;
            case "btnQuickOrder8": checkSchedule(param.QUICKEXAM8_ID); break;
            case "btnQuickOrder9": checkSchedule(param.QUICKEXAM9_ID); break;
            case "btnQuickOrder10": checkSchedule(param.QUICKEXAM10_ID); break;
            case "btnVNA": setPageVNA(); break;
        }
    }
    private void checkSchedule(int exam_id)
    {
        Label txtRefUnit = rtoolHISPatient.FindItemByValue("rtoolbtnHISPatient").FindControl("txtRefUnit") as Label;
        if (string.IsNullOrEmpty(txtRefUnit.Text) || txtRefUnit.Text.LastIndexOf('*') > 0)
        {
            showOnlineMessageBox("checkRefUnit");
            return;
        }
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        DataTable dtHisDoc = (DataTable)Application["HisDoctorData"];

        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtExamAll = Application["ExamAllData"] as DataTable;
        DataView dv = dtExamAll.DefaultView;
        dv.RowFilter = "EXAM_ID=" + exam_id.ToString();
        DataTable dt = dv.ToTable();
        bool flag = false;
        if (dt.Rows[0]["NEED_SCHEDULE"].ToString() == "Y")
        {
            param.QUICKEXAM_MODE = "SCHEDULE";
            if (dt.Rows[0]["NEED_APPROVE"].ToString() == "Y")
                param.QUICKEXAM_MODE = "WAITING";
            flag = true;
        }

        DataRow[] rowRefDoc = dtHisDoc.Select("EMP_ID=" + env.UserID.ToString());
        if (rowRefDoc.Length <= 0)
        {
            param.QUICKEXAM_MODE = "REF_DOC";
            flag = true;
        }

        RISBaseClass risbase = new RISBaseClass();
        if (!string.IsNullOrEmpty(dt.Rows[0]["CAN_REQONLINE"].ToString()))
            if (
                dt.Rows[0]["CAN_REQONLINE"].ToString() == "Y" &&
                SpecifyData.checkCanOrderwithUnit(param.REF_UNIT_UID, Convert.ToInt32(dt.Rows[0]["EXAM_TYPE"]))
                || param.FlagCTMR == true
                )
            {
                //flag = true;
            }
            else
            {
                param.QUICKEXAM_MODE = "CANNOT_REQONLINE";
                flag = true;
            }

        param.ORDER_ID = "0";
        param.SCHEDULE_ID = "0";
        param.QUICKEXAM_ID = exam_id.ToString();
        Session["ONL_PARAMETER"] = param;

        if (flag)
            if (param.QUICKEXAM_MODE == "REF_DOC")
                showOnlineMessageBox("checkRefDoc");
            else if (param.QUICKEXAM_MODE == "CANNOT_REQONLINE")
                showOnlineMessageBox("CANNOT_REQONLINE");
            else
                Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderNW.aspx");
        else
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openQuickOrder", "showQuickOrder(" + exam_id.ToString() + ");", true);
    }
    private void setPageDetail(string _order_id, string _schedule_id)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        param.ORDER_ID = _order_id;
        param.SCHEDULE_ID = _schedule_id;

        Session["ONL_PARAMETER"] = param;
        Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderNW.aspx");
    }
    private void setPageVNA()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        string _hn = param.HN;
        PatientClass getPatient = new PatientClass();
        getPatient.get_Patient_Registration_ByHN(_hn, env, true);
        Response.Redirect(@"../VNA/frmVNAWorklist.aspx");
    }
    private void setPageDetail(string _exam_id)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        param.QUICKEXAM_ID = _exam_id;
        param.QUICKEXAM_MODE = "ORDER";

        Session["ONL_PARAMETER"] = param;

        Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderNW.aspx");
    }
    #endregion
    #region Worklist
    private void set_ColumnWorklist()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        //switch (param.FORM)
        //{
        //    case "O1":
        //    grdData.MasterTableView.GetColumn("colHN").Visible = false;
        //    grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = false;
        //    grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colModality").Visible = false;
        //    grdData.MasterTableView.GetColumn("colSide").Visible = false;
        //    grdData.Rebind();
        //    break;
        //case "O2":
        //case "W1":
        //    grdData.MasterTableView.GetColumn("colHN").Visible = true;
        //    grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = true;
        //    grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colModality").Visible = true;
        //    grdData.MasterTableView.GetColumn("colSide").Visible = true;
        //    grdData.Rebind();
        //    break;
        //case "W2":
        //    grdData.MasterTableView.GetColumn("colHN").Visible = true;
        //    grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = true;
        //    grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = false;
        //    grdData.MasterTableView.GetColumn("colModality").Visible = true;
        //    grdData.MasterTableView.GetColumn("colSide").Visible = true;
        //    grdData.Rebind();
        //    break;
        //case "R1":
        grdData.MasterTableView.GetColumn("colHN").Visible = false;
        grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = false;
        grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = true;
        grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = true;
        grdData.MasterTableView.GetColumn("colModality").Visible = false;
        grdData.MasterTableView.GetColumn("colSide").Visible = false;
        grdData.Rebind();
        //        break;
        //    case "R2":
        //        grdData.MasterTableView.GetColumn("colHN").Visible = false;
        //        grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = false;
        //        grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = true;
        //        grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = true;
        //        grdData.MasterTableView.GetColumn("colModality").Visible = false;
        //        grdData.MasterTableView.GetColumn("colSide").Visible = false;
        //        grdData.Rebind();
        //        break;
        //    case "A1":
        //        grdData.MasterTableView.GetColumn("colHN").Visible = true;
        //        grdData.MasterTableView.GetColumn("colPATIENT_NAME").Visible = true;
        //        grdData.MasterTableView.GetColumn("colPAT_DEST_DESC").Visible = true;
        //        grdData.MasterTableView.GetColumn("colREF_UNIT_DESC").Visible = true;
        //        grdData.MasterTableView.GetColumn("colModality").Visible = true;
        //        grdData.MasterTableView.GetColumn("colSide").Visible = true;
        //        grdData.Rebind();
        //        break;
        //}
        if (param.REF_UNIT_UID == "0")
        {
            grdData.MasterTableView.GetColumn("grdbtnEdit_Unigue").Visible = false;
            grdData.MasterTableView.GetColumn("grdbtnDelete_Unigue").Visible = false;
            grdData.MasterTableView.GetColumn("grdbtnFilterPrint_Unigue").Visible = false;
            grdData.MasterTableView.GetColumn("grdbtnDirectPrint_Unigue").Visible = false;
        }
        //grdData.Rebind();
    }
    protected void txtSearch_OnTextChanged(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    protected void btnSearchDate_OnClick(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    protected void chkShowAllData_OnCheckedChanged(object sender, EventArgs e)
    {
        modifiedData_grdData();
    }
    protected void grdData_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        LoadData();
        fillDataGridDataTable(grdData, param.dvGrid);
    }
    protected void grdData_ItemCommand(object source, GridCommandEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        Session["values"] = values;
        item.ExtractValues(values);

        if (Convert.ToBoolean(values["ONL_REQ"]))
        {
            if (e.CommandName == "grdbtnEdit")
            {
                LoadData();
                DataTable dt = param.dvGrid;
                DataView dv = dt.DefaultView;

                if (values["ORDER_ID"].ToString() != "0")
                {
                    dv.RowFilter = "(ORDER_ID = '" + values["ORDER_ID"].ToString() + "')" +
                        "and EXAM_ID = '" + values["EXAM_ID"].ToString() + "'";
                }
                else if (values["SCHEDULE_ID"].ToString() != "0")
                {
                    dv.RowFilter = "(SCHEDULE_ID = '" + values["SCHEDULE_ID"].ToString() + "')" +
                        "and EXAM_ID = '" + values["EXAM_ID"].ToString() + "'";
                }

                try
                {
                    if (dv[0]["IS_BUSY"].ToString() == "Y")
                    {
                        showOnlineMessageBox("IsBusy");
                    }
                    else
                    {
                        param.ORDER_ID = values["ORDER_ID"].ToString();
                        param.SCHEDULE_ID = values["SCHEDULE_ID"].ToString();
                        Session["ONL_PARAMETER"] = param;

                        showOnlineMessageBox("EditOrder");
                    }
                }
                catch { }
            }
            else if (e.CommandName == "grdbtnDelete")
            {
                LoadData();
                DataTable dt = param.dvGrid;
                DataView dv = dt.DefaultView;

                if (values["ORDER_ID"].ToString() != "0")
                {
                    dv.RowFilter = "(ORDER_ID = '" + values["ORDER_ID"].ToString() + "')" +
                        "and EXAM_ID = '" + values["EXAM_ID"].ToString() + "'";
                }
                else if (values["SCHEDULE_ID"].ToString() != "0")
                {
                    dv.RowFilter = "(SCHEDULE_ID = '" + values["SCHEDULE_ID"].ToString() + "')" +
                        "and EXAM_ID = '" + values["EXAM_ID"].ToString() + "'";
                }

                if (Utilities.IsHaveData(dv))
                {
                    try
                    {
                        switch (dv[0]["STATUS"].ToString())
                        {
                            case "W":
                            case "V":
                                param.FlagStatus = "W";
                                showOnlineMessageBox("RemoveExamFavorite");
                                break;
                            case "R":
                                param.FlagStatus = "R";
                                showOnlineMessageBox("RemoveExamFavorite");
                                break;
                            case "A":
                                param.FlagStatus = "Den";
                                showOnlineMessageBox("RemoveExamFavorite");
                                break;
                            case "S":
                                showOnlineMessageBox("DeleteSchedule");
                                break;
                            default:
                                break;
                        }
                    }
                    catch
                    {
                        showOnlineMessageBox("DeleteSchedule");
                    }
                }
                else
                {
                    showOnlineMessageBox("DeleteSchedule");
                }
            }
        }
        else
        {
            if (e.CommandName == "grdbtnDelete")
            {
                if (values["PAT_DEST_ID"].ToString() == "9")
                    if (values["STATUS"].ToString() == "A")
                    {
                        param.FlagStatus = "Den";
                        showOnlineMessageBox("RemoveExamFavorite");
                    }
            }
        }
        if (e.CommandName == "grdbtnSynapse")
        {
            //string url = env.PacsUrl + values["ACCESSION_NO"].ToString();
            string url = values["ACCESSION_NO"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSynapse", "showNewWindows('" + url + "');", true);
        }
        else if (e.CommandName == "grdbtnFilterPrint")
        {
            string url = @"../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xtraReportScreening&IS_ONLINE=" + values["ONL_REQ"].ToString() +
                                                                                                                    "&SCHEDULE_ID=" + values["SCHEDULE_ID"].ToString() +
                                                                                                                    "&HN=" + values["HN"].ToString() +
                                                                                                                    "&PATIENT_NAME=" + values["PATIENT_NAME"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openFilterPrint", "showFilter('" + values["TYPE_NAME_ALIAS"].ToString().Trim() + "');", true);
        }
        else if (e.CommandName == "grdbtnDirectPrint")
        {
            string url = "";
            ScheduleClass sch = new ScheduleClass();
            DataSet dsNav = sch.check_NavigationInstruction(Convert.ToInt32(values["EXAM_ID"]));
            switch (values["STATUS"].ToString())
            {
                case "P":
                    if (Utilities.IsHaveData(dsNav))
                    {
                        url += "../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptNavigatorApplication&IS_ONLINE=" + values["ONL_REQ"].ToString() +
                                                                                                                "&ORDER_ID=" + values["SCHEDULE_ID"].ToString() +
                                                                                                                "&ORG_ID=" + env.OrgID.ToString() +
                                                                                                                "&PRINTOR=" + env.FirstName + " " + env.LastName +
                                                                                                                "&USER_ID=" + env.UserID.ToString() +
                                                                                                                "&EXAM_UID=" + values["EXAM_UID"].ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    }
                    else
                    {
                        DataTable dtAlert = new DataTable();
                        dtAlert.Columns.Add("ALT_TEXT");
                        dtAlert.Columns.Add("ALT_BUTTON");
                        dtAlert.Columns.Add("CAPTION_BTN1");
                        dtAlert.Columns.Add("CAPTION_BTN2");
                        dtAlert.Columns.Add("CAPTION_BTN3");
                        dtAlert.Columns.Add("ALT_TYPE");
                        dtAlert.AcceptChanges();
                        dtAlert.Rows.Add("กรุณารอการยืนยัน วันนัดตรวจ X-ray \r\n 30 นาทีโดยประมาณ"
                                        , 1, "ตกลง", "", "", "W");
                        dtAlert.AcceptChanges();
                        Session["dtAlert"] = dtAlert;
                        showOnlineMessageBox("ManualPopup");
                    }
                    break;
                case "F":
                    url += "../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptResultReportEnvision&IS_ONLINE=" + values["ONL_REQ"].ToString() + "&ACCESSION_NO=" + values["ACCESSION_NO"].ToString() +
                                                                                                                    "&ORG_ID=" + env.OrgID.ToString() +
                                                                                                                    "&PRINTOR=" + env.FirstName + " " + env.LastName +
                                                                                                                    "&USER_ID=" + env.UserID.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    break;
                case "W":
                case "V":
                    if (Utilities.IsHaveData(dsNav))
                    {
                        url += "../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptNavigatorApplication&IS_ONLINE=" + values["ONL_REQ"].ToString() + "&ORDER_ID=" + values["SCHEDULE_ID"].ToString() +
                                                                                                                    "&ORG_ID=" + env.OrgID.ToString() +
                                                                                                                    "&PRINTOR=" + env.FirstName + " " + env.LastName +
                                                                                                                    "&USER_ID=" + env.UserID.ToString() +
                                                                                                                    "&EXAM_UID=" + values["EXAM_UID"].ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    }
                    else
                    {
                        DataTable dtAlert = new DataTable();
                        dtAlert.Columns.Add("ALT_TEXT");
                        dtAlert.Columns.Add("ALT_BUTTON");
                        dtAlert.Columns.Add("CAPTION_BTN1");
                        dtAlert.Columns.Add("CAPTION_BTN2");
                        dtAlert.Columns.Add("CAPTION_BTN3");
                        dtAlert.Columns.Add("ALT_TYPE");
                        dtAlert.AcceptChanges();
                        dtAlert.Rows.Add("กรุณารอการยืนยัน วันนัดตรวจ X-ray \r\n 30 นาทีโดยประมาณ"
                                        , 1, "ตกลง", "", "", "W");
                        dtAlert.AcceptChanges();
                        Session["dtAlert"] = dtAlert;
                        showOnlineMessageBox("ManualPopup");
                    }

                    break;
                case "S":
                    sch.set_scheduleLogs(Convert.ToInt32(values["SCHEDULE_ID"]), env.UserID, 'U', "Print Online");
                    url += "XTRAFORM=xrptSchedule&IS_ONLINE=" + values["ONL_REQ"].ToString() + "&ORDER_ID=" + values["SCHEDULE_ID"].ToString() + "&REG_ID=" + values["REG_ID"].ToString() + "&PRINTOR=" + env.FirstName + " " + env.LastName;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showAlertPatientPhone('" + url + "');", true);
                    break;
                case "A":
                case "R":
                    string _is_online = "";
                    if (values["ONL_REQ"].ToString() == "true")
                    {
                        ProcessGetONLDirectlyOrder chkDirect = new ProcessGetONLDirectlyOrder(
                            Convert.ToInt32(values["REF_UNIT"]),
                            Convert.ToInt32(values["CLINIC_TYPE"]),
                            Convert.ToInt32(values["EXAM_ID"]));
                        chkDirect.Invoke();
                        if (chkDirect.Result.Tables[0].Rows.Count != 0)
                            _is_online = "false";
                        else
                            _is_online = "true";
                    }
                    else
                        _is_online = values["ONL_REQ"].ToString();
                    url = @"../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=xrptOrderReport&IS_ONLINE=" + _is_online + "&ORDER_ID=" + values["ORDER_ID"].ToString() +
                                                                                                                            "&ORG_ID=" + env.OrgID.ToString() +
                                                                                                                            "&PRINTOR=" + env.FirstName + " " + env.LastName +
                                                                                                                            "&USER_ID=" + env.UserID.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertPrintPreview", "showPrintPreview('" + url + "');", true);
                    break;
                case "D":
                case "C":
                    showOnlineMessageBox("CannotPrint");
                    break;
            }

        }
        else if (e.CommandName == "grdbtnPreviewReport")
        {
            string acc = values["ACCESSION_NO"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openPreviewReport", "showPreviewReport('" + acc + "');", true);
        }
        else if (e.CommandName == "grdbtnShowComment")
        {
            param.ORDER_ID = values["ORDER_ID"].ToString();
            param.SCHEDULE_ID = values["SCHEDULE_ID"].ToString();
            param.EXAM_ID = values["EXAM_ID"].ToString();
            Session["ONL_PARAMETER"] = param;

            string url = @"../../Forms/Dialogs/frmComments.aspx?TAB_OPEN=Comment";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openPreviewReport", "showPreviewComment('" + url + "');", true);
        }
        else if (e.CommandName == "grdbtnShowClinical")
        {
            param.ORDER_ID = values["ORDER_ID"].ToString();
            param.SCHEDULE_ID = values["SCHEDULE_ID"].ToString();
            param.EXAM_ID = values["EXAM_ID"].ToString();
            Session["ONL_PARAMETER"] = param;

            string url = @"../../Forms/Dialogs/frmComments.aspx?TAB_OPEN=Clinical";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openPreviewReport", "showPreviewComment('" + url + "');", true);
        }

    }

    protected void grdData_ItemDataBound(object source, GridItemEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Item is GridDataItem)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            GridDataItem gridDataItem = (GridDataItem)e.Item;
            DataRowView dv = e.Item.DataItem as DataRowView;
            DateTime dt = Convert.ToDateTime(dv.Row["ORDER_DT"]);
            ((GridDataItem)e.Item)["colOrderDT"].Text = dt.ToString("dd MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

            ImageButton imgBtnEdit = (ImageButton)gridDataItem["grdbtnEdit_Unigue"].Controls[0];
            ImageButton imgBtnDel = (ImageButton)gridDataItem["grdbtnDelete_Unigue"].Controls[0];
            ImageButton imgBtnSynpase = (ImageButton)gridDataItem["grdbtnSynapse_Unigue"].Controls[0];
            ImageButton imgBtnPreviewReport = (ImageButton)gridDataItem["grdbtnPreviewReport_Unigue"].Controls[0];
            ImageButton imgBtnFilterPrint = (ImageButton)gridDataItem["grdbtnFilterPrint_Unigue"].Controls[0];
            ImageButton imgComment = (ImageButton)gridDataItem["grdbtnShowComment_Unigue"].Controls[0];

            bool flag = false;
            bool flagSynapse = false;
            bool flagPreveiewReport = false;
            bool flagFilterPrint = false;
            bool flagDelete = false;

            if (Convert.ToBoolean(dv.Row["ONL_REQ"]))
            {
                switch (dv.Row["STATUS"].ToString())
                {
                    case "R": flag = true; break;
                    case "W":
                    case "V": flag = true; break;
                    case "S":
                        gridDataItem["colSTATUS_TEXT"].BackColor = Color.Pink; // change particuler cell
                        e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
                        break;
                }
            }
            if (!string.IsNullOrEmpty(dv.Row["SEVERITY_COLOR"].ToString()))
                gridDataItem["colSEVERITY_TEXT"].ForeColor = Color.FromName(dv.Row["SEVERITY_COLOR"].ToString());

            //if (dv.Row["IS_SCHEDULE"].ToString() != "Y")
            //{
            switch (dv.Row["STATUS"].ToString())
            {
                case "C": flagSynapse = true;
                    break;
                case "D": flagSynapse = true;
                    break;
                case "P": flagSynapse = true;
                    flagPreveiewReport = true;
                    break;
                case "F": flagSynapse = true;
                    flagPreveiewReport = true;
                    break;
            }
            if (dv.Row["STATUS_TEXT"].ToString() == "Pending")
            {
                flagSynapse = false;
                flagPreveiewReport = false;
            }
            if (dv.Row["TYPE_NAME_ALIAS"].ToString().ToString() == "CT" || dv.Row["TYPE_NAME_ALIAS"].ToString().ToString() == "MR")
            {
                flagFilterPrint = true;

                if (dv.Row["IS_PRINT_CONSENTFORM"].ToString() == "N")
                {
                    gridDataItem.BackColor = System.Drawing.Color.Pink;
                    gridDataItem.ForeColor = System.Drawing.Color.White;
                }
            }
            //}

            ProcessGetONLDirectlyOrder chkDirect = new ProcessGetONLDirectlyOrder(Convert.ToInt32(dv.Row["EXAM_ID"]));
            chkDirect.Invoke();
            if (chkDirect.Result.Tables[0].Rows.Count != 0)
            {
                flagDelete = true;
            }

            imgBtnEdit.Enabled = flag;
            imgBtnEdit.ImageUrl = flag ? "../../Resources/ICON/adminstrator_16.png" : "../../Resources/ICON/adminstrator_grey_16.png";

            if (flagDelete)
            {
                imgBtnDel.Enabled = flagDelete;
                imgBtnDel.ImageUrl = flagDelete ? "../../Resources/ICON/delete.png" : "../../Resources/ICON/delete_grey.png";

                imgBtnEdit.Enabled = flagDelete;
                imgBtnEdit.ImageUrl = flagDelete ? "../../Resources/ICON/adminstrator_16.png" : "../../Resources/ICON/adminstrator_grey_16.png";
            }
            else
            {
                imgBtnDel.Enabled = flag;
                imgBtnDel.ImageUrl = flag ? "../../Resources/ICON/delete.png" : "../../Resources/ICON/delete_grey.png";
            }

            imgBtnSynpase.Enabled = flagSynapse;
            imgBtnSynpase.ImageUrl = flagSynapse ? "../../Resources/Logo/synapse16.jpg" : "../../Resources/Logo/synapse16_gray.jpg";

            imgBtnPreviewReport.Enabled = flagPreveiewReport;
            imgBtnPreviewReport.ImageUrl = flagPreveiewReport ? "../../Resources/ICON/report_16.png" : "../../Resources/ICON/report_grey_16.png";

            imgBtnFilterPrint.Enabled = flagFilterPrint;
            imgBtnFilterPrint.ImageUrl = flagFilterPrint ? "../../Resources/ICON/preferences-desktop-peripherals-3_16.png" : "../../Resources/ICON/preferences-desktop-peripherals-3_G16.png";

            if (dv.Row["COMMENTS"].ToString() == "")
            {
                imgComment.Enabled = false;
                imgComment.ImageUrl = "../../Resources/ICON/Comment-add-icon16_gray.png";
            }
        }

    }
    protected void grdData_PreRender(object sender, EventArgs e)
    {
        set_ColumnWorklist();
    }
    protected void grdData_OnDataBound(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        bool flag = true;
        switch (param.FORM)
        {
            case "O1": flag = true; break;
            case "O2": flag = false; break;
            case "R1": flag = true; break;
            case "R2": flag = false; break;
            default: flag = true; break;
        }

        this.grdData.Columns[0].Visible = flag;
        this.grdData.Columns[1].Visible = flag;
    }

    private void modifiedData_grdData()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        LoadData();
        TextBox txt = (TextBox)rtoolSearch.FindItemByValue("rtoolbtnSearch").FindControl("txtSearch");
        get_AllRowFilter(grdData, param.dvGrid, txt.Text);
    }
    private void LoadData()
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        param.dvGrid = new DataTable();
        RadDatePicker dtFromDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtFromDate");
        RadDatePicker dtToDate = (RadDatePicker)rtoolSearch.Items.FindItemByValue("rtoolbtnDatetime").FindControl("dtToDate");
        RadButton chkShowAllData = (RadButton)rtoolSearch.FindItemByValue("rtoolbtnChkAll").FindControl("chkShowAllData");
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();
        if (dtFromDate.SelectedDate != null)
            dtFrom = new DateTime(dtFromDate.SelectedDate.Value.Year, dtFromDate.SelectedDate.Value.Month, dtFromDate.SelectedDate.Value.Day, 0, 0, 0);
        if (dtToDate.SelectedDate != null)
            dtTo = new DateTime(dtToDate.SelectedDate.Value.Year, dtToDate.SelectedDate.Value.Month, dtToDate.SelectedDate.Value.Day, 23, 59, 59);
        int _mode = 0;

        if(param.REF_UNIT_UID == "0")
            _mode = 4;
        else
            _mode = chkShowAllData.Checked ? 3 : 4;

        DataTable dtDept = (DataTable)Application["UnitData"];
        DataRow[] rowRefUnit = dtDept.Select("UNIT_UID='" + param.REF_UNIT_UID + "'");

        //switch (param.FORM)
        //{
        //    case "O1": _mode = 90;
        //        dtTo = dtTo.AddYears(10);
        //        break;
        //    default:
        //        _mode = chkShowAllData.Checked ? 3 : 4;
        //        dtTo = dtTo.AddYears(10);
        //        break;
        //}
        //switch (param.FORM)
        //{
        //    case "O1": _mode = chkShowAllData.Checked ? 3 : 4;
        //        dtTo = dtTo.AddYears(10);
        //        break;
        //    case "O2": _mode = chkShowAllData.Checked ? 3 : 4; break;

        //    case "R1": 
        //_mode = chkShowAllData.Checked ? 3 : 4;
        dtTo = dtTo.AddYears(10);
        //        break;

        //    case "W": 
        //        //_mode = string.IsNullOrEmpty(param.REF_UNIT_UID) ? 3 : 2;
        //        //chkShowAllData.Visible = false; break;
        //    case "R2": _mode = 4;
        //        dtTo = dtTo.AddYears(10);
        //        break;



        //    default: _mode = chkShowAllData.Checked ? 3 : 4;
        //        dtTo = dtTo.AddYears(10);
        //        break;
        //}

        OrderClass getWorklist = new OrderClass();
        getWorklist.ONL_WORKLIST.MODE = _mode;
        getWorklist.ONL_WORKLIST.HN = param.HN;
        getWorklist.ONL_WORKLIST.UNIT_ID = rowRefUnit.Length <= 0 ? 0 : Convert.ToInt32(rowRefUnit[0]["UNIT_ID"]);
        getWorklist.ONL_WORKLIST.UNIT_ALIAS = param.REF_UNIT_UID;
        getWorklist.ONL_WORKLIST.FromDate = dtFromDate.SelectedDate == null ? DateTime.Now : dtFrom;
        getWorklist.ONL_WORKLIST.ToDate = dtToDate.SelectedDate == null ? DateTime.Now : dtTo;
        DataTable dt = getWorklist.get_OnlineWorklist().Tables[0];
        dt.Columns.Add("IS_PORTABLE_VALUE");
        dt.AcceptChanges();
        param.dvGrid = dt;
        if (string.IsNullOrEmpty(param.ORDER_ID) || param.ORDER_ID == "0")
            param.dvGridDtl = dt.Clone();

        foreach (DataRow rows in dt.Rows)
        {
            if (rows["STATUS"].ToString() == "W" || rows["STATUS"].ToString() == "V")
                rows["strEXAM_DT"] = "...";
            else
                rows["strEXAM_DT"] = Convert.ToDateTime(rows["strEXAM_DT"]).ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
        }

        param.dvGridDtl_Remove = dt.Clone();
        Session["ONL_PARAMETER"] = param;
    }
    private void get_AllRowFilter(RadGrid radGridData, DataTable dt, string _search)
    {
        StringBuilder sb = new StringBuilder();
        foreach (DataColumn col in dt.Columns)
            if (col.DataType.Name == "String")
                sb.Append(col.Caption + " like '%" + _search + "%' \r\n OR ");

        sb.Remove(sb.ToString().LastIndexOf("OR"), 3);
        DataRow[] rows = dt.Select(sb.ToString());
        fillDataGrid_Filter(radGridData, Utilities.arrayRowsToDataTable(dt.Clone(), rows));
    }
    #endregion
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
    private void showOnlineMessageBox(string messagePopup)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAlertConflict", "showNormalAlert('" + messagePopup + "');", true);
    }
    private void printDocument(string url)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "printdocumentWindows", "printDocument('" + url + "');", true);
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = new DataTable();
        string str = "";
        switch (e.Argument)
        {
            #region Grid
            case "RemoveExamFavorite":
                Hashtable valuesRemove = (Hashtable)Session["values"];
                string MessageBoxValue = (string)Session["MessageBoxValue"];
                if (param.FlagStatus == "R" && MessageBoxValue == "2")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openDeleteCase", "showDeleteCase('FRM=ORD&ID=" + valuesRemove["ORDER_ID"].ToString() + "');", true);
                else if (param.FlagStatus == "W" && MessageBoxValue == "2")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openDeleteCase", "showDeleteCase('FRM=SCH&ID=" + valuesRemove["SCHEDULE_ID"].ToString() + "');", true);
                else if (param.FlagStatus == "Den" && MessageBoxValue == "2")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openDeleteCase", "showDeleteCase('FRM=DEN&ID=" + valuesRemove["ORDER_ID"].ToString() + "');", true);
                else
                    break;
                break;
            case "DeleteOrder":
                LoadData();
                fillDataGrid_Filter(grdData, param.dvGrid);
                break;
            #endregion
            #region Popup
            case "EditOrder":
                str = Session["MessageBoxValue"] as string;
                if (str == "2")
                {
                    setPageDetail(param.ORDER_ID, param.SCHEDULE_ID);
                }
                break;
            case "ClinicalPopup":
                modifiedData_grdData();
                break;
            case "checkRefDoc":
                Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderNW.aspx");
                break;
            case "checkRefUnit":
                Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderNW.aspx");
                break;
            #endregion
        }
    }
}
