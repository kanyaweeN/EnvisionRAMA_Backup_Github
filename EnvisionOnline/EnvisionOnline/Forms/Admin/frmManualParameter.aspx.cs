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
using EnvisionOnline.Common;

public partial class frmManualParameter : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindingData();
    }
    private void BindingData()
    {
        RISBaseClass baseManage = new RISBaseClass();

        cmbInsuraceType.DataSource = Application["InsuranceTypeData"] as DataTable;
        cmbInsuraceType.DataTextField = "INSURANCE_TYPE_TEXT";
        cmbInsuraceType.DataValueField = "INSURANCE_TYPE_UID";
        cmbInsuraceType.DataBind();
        
        txtUser.Text = Session["UserLogin"].ToString();

        txtPass.TextMode = TextBoxMode.Password;
        txtPass.Attributes.Add("value", Session["PasswordLogin"].ToString());
        txtPass.Text = Session["PasswordLogin"].ToString();
        txtAlert.Text = "";
        set_Application();
    }
    protected void cmbRefUnit_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtUnit = Application["UnitData"] as DataTable;
        cmbRefUnit.Items.Clear();

        string text = e.Text;
        DataRow[] rows = dtUnit.Select("UNIT_UID + UNIT_NAME LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefUnit.Items.Add(new RadComboBoxItem(rows[i]["UNIT_UID"].ToString() + " : " + rows[i]["UNIT_NAME"].ToString()));

    }

    protected void chekbox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox linkedItem = sender as CheckBox;
        chkCTMR.Checked = linkedItem.Checked;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ONL_PARAMETER param = new ONL_PARAMETER();
        bool chkParameter = false;
        chkParameter = true;

        if (chkParameter)
        {
            param.HN = txtHN.Text.Trim();
            param.USER_NAME = txtUser.Text.Trim();
            param.ROLE = string.IsNullOrEmpty(cmbAuthen.Text) ? "S" : cmbAuthen.Text;
            switch (cmbClinicType.Text)
            {
                case "Regular": param.ENC_CLINIC = "RGL"; break;
                case "Special": param.ENC_CLINIC = "SPC"; break;
                case "Premium": param.ENC_CLINIC = "PM"; break;
            }
            switch (cmbEncounter.Text)
            {

                case "EMER = ER Encounter": param.ENCOUNTER_TYPE = "EMER"; break;
                case "AMB = OPD Encounter": param.ENCOUNTER_TYPE = "AMB"; break;
                case "SS = Short Stay Encounter": param.ENCOUNTER_TYPE = "SS"; break;
                case "IMP = IPD Encounter": param.ENCOUNTER_TYPE = "IMP"; break;
                case "OTH = OTHER Encounter(not use)": param.ENCOUNTER_TYPE = "IMP"; break;
                default: param.ENCOUNTER_TYPE = "EMER"; break;
            }
            param.INSURANCE_TYPE_UID = cmbInsuraceType.SelectedValue;

            if (cmbRefUnit.Text == "0")
                param.REF_UNIT_UID = "0";
            else
            {
                try
                {
                    param.REF_UNIT_UID = cmbRefUnit.Text.Substring(0, cmbRefUnit.Text.LastIndexOf(':') - 1);
                }
                catch
                {
                    txtAlert.Text = "กรุณากรอก Ordering Department ให้ถูกต้อง";
                    return;
                }
            }
            
            param.FORM = cmbForm.Text;
            param.FlagCTMR = chkCTMR.Checked;

            Session["ONL_PARAMETER"] = param;
            Response.Redirect(@"../../Forms/Orders/frmEnvisionOrderWL.aspx");
        }

        //else if (e.Item.Value == "barbtnClearCache")
        //{
        //    set_Application();
        //}
    }
    private void set_Application()
    {
        ScheduleClass sche = new ScheduleClass();
        RISBaseClass baseManage = new RISBaseClass();
        OrderClass ordManage = new OrderClass();

        DataTable dtt = baseManage.get_His_Department(1);
        dtt.PrimaryKey = new[] { dtt.Columns["UNIT_ID"] };
        Application["UnitData"] = dtt;

        dtt = baseManage.get_Patient_Status();
        dtt.PrimaryKey = new[] { dtt.Columns["STATUS_ID"] };
        Application["PatientStatusData"] = dtt;

        dtt = baseManage.get_RIS_ClinicType();
        dtt.Columns.Add("CLINIC_TYPE_ONLINEDESC");
        foreach (DataRow dr in dtt.Rows)
        {
            switch (dr["CLINIC_TYPE_UID"].ToString())
            {
                case "Special": dr["CLINIC_TYPE_ONLINEDESC"] = "Special Clinic"; break;
                case "VIP": dr["CLINIC_TYPE_ONLINEDESC"] = "Premium Clinic"; break;
                case "Non-Resident": dr["CLINIC_TYPE_ONLINEDESC"] = "Non-Resident"; break;
                case "CNMI": dr["CLINIC_TYPE_ONLINEDESC"] = "CNMI"; break;
                default: dr["CLINIC_TYPE_ONLINEDESC"] = "Regular Clinic"; break;
            }
        }
        dtt.PrimaryKey = new[] { dtt.Columns["CLINIC_TYPE_ID"] };
        Application["ClinicTypeData"] = dtt;

        dtt = baseManage.get_Ris_InsuranceType(1);
        dtt.PrimaryKey = new[] { dtt.Columns["INSURANCE_TYPE_ID"] };
        Application["InsuranceTypeData"] = dtt;

        dtt = baseManage.get_His_Doctor(1);
        dtt.PrimaryKey = new[] { dtt.Columns["EMP_ID"] };
        Application["HisDoctorData"] = dtt;

        dtt = baseManage.get_Ris_Radiologist();
        Application["RISDoctorData"] = dtt;

        dtt = baseManage.get_HIS_ICD();
        dtt.Columns.Add("ICD_FULL_TEXT");
        Application["HisICDData"] = dtt;

        dtt = baseManage.get_Ris_ExamAll();
        //dtt.Columns.Add("EXAM_SHOW");
        //foreach (DataRow row in dtt.Rows)
        //    row["EXAM_SHOW"] = row["EXAM_NAME"].ToString() + " [" + row["EXAM_UID"] + "] ";
        Application["ExamAllData"] = dtt;

        dtt = baseManage.get_Ris_Exam();
        //dtt.Columns.Add("EXAM_SHOW");
        //foreach (DataRow row in dtt.Rows)
        //    row["EXAM_SHOW"] = row["EXAM_NAME"].ToString() + " [" + row["EXAM_UID"] + "] ";
        Application["ExamData"] = dtt;


        dtt = baseManage.get_Exam_Panel();
        Application["ExamPanel"] = dtt;

        dtt = baseManage.get_Ris_ModalityType(true);
        dtt.Rows.Add(0, "--ALL--", "--ALL--", "ALL", "--ALL--");
        dtt.AcceptChanges();
        Application["ModalityType"] = dtt;

        dtt = baseManage.get_BP_View();
        Application["BP_VIEW"] = dtt;

        dtt = baseManage.get_GBL_ENV();
        Application["GBL_ENV"] = dtt;

        dtt = ordManage.get_CancelTemplate();
        Application["CANCELTEMPLATE"] = dtt;
        Application["SearchMatch"] = baseManage.get_ONL_SearchMatch();

        Application["SessionTimeAll"] = sche.get_SessionTimeAll();
        Application["SessionType"] = baseManage.get_CLINICSESSION_TYPE();
    }
}
