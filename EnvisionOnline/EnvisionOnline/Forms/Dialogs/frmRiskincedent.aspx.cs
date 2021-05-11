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
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.Common;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using System.Globalization;
using System.Collections.Generic;

public partial class frmRiskincedent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openTab", "SetTab('" + Request.Params["TAB_OPEN"].ToString() + "');", true);

            clearData();
            loadData();
        }
    }
    private void clearData()
    {
        txtCreatinine.Text = "-";

        chkUseContrastYes.Checked = false;
        chkUseContrastNo.Checked = false;
        //txtUseContrast.Text = string.Empty;
        //txtUseContrast.Enabled = false;

        chkWearingMetalEquipmentInTheBodyYes.Checked = false;
        chkWearingMetalEquipmentInTheBodyNo.Checked = false;
        txtWearingMetalEquipmentInTheBody.Text = string.Empty;
        txtWearingMetalEquipmentInTheBody.Enabled = false;

        chkThreadLiftingYes.Checked = false;
        chkThreadLiftingNo.Checked = false;
        txtThreadLifting.Text = string.Empty;
        txtThreadLifting.Enabled = false;

        chkMetalInEyeYes.Checked = false;
        chkMetalInEyeNo.Checked = false;
        txtMetalInEye.Text = string.Empty;
        txtMetalInEye.Enabled = false;

        chkInsertTheMetalTracheaTubeYes.Checked = false;
        chkInsertTheMetalTracheaTubeNo.Checked = false;
        txtInsertTheMetalTracheaTube.Text = string.Empty;
        txtInsertTheMetalTracheaTube.Enabled = false;

        chkWearBracesYes.Checked = false;
        chkWearBracesNo.Checked = false;
        txtWearBraces.Text = string.Empty;
        txtWearBraces.Enabled = false;

        chkPermanentRadiationImplantationYes.Checked = false;
        chkPermanentRadiationImplantationNo.Checked = false;
        txtPermanentRadiationImplantation.Text = string.Empty;
        txtPermanentRadiationImplantation.Enabled = false;

        chkClaustrophobiaYes.Checked = false;
        chkClaustrophobiaNo.Checked = false;
        txtClaustrophobia.Text = string.Empty;
        txtClaustrophobia.Enabled = false;

        chkPregnantMRIYes.Checked = false;
        chkPregnantMRINo.Checked = false;
        txtPregnantMRI.Text = string.Empty;
        txtPregnantMRI.Enabled = false;

        chkAllergicMRIContrastMediaYes.Checked = false;
        chkAllergicMRIContrastMediaNo.Checked = false;
        txtAllergicMRIContrastMedia.Text = string.Empty;
        txtAllergicMRIContrastMedia.Enabled = false;

        chkIodineAllergyYes.Checked = false;
        chkIodineAllergyNo.Checked = false;
        txtIodineAllergy.Text = string.Empty;
        txtIodineAllergy.Enabled = false;

        chkFoodAllergyYes.Checked = false;
        chkFoodAllergyNo.Checked = false;
        txtFoodAllergy.Text = string.Empty;
        txtFoodAllergy.Enabled = false;

        chkAsthmaYes.Checked = false;
        chkAsthmaNo.Checked = false;
        txtAsthma.Text = string.Empty;
        txtAsthma.Enabled = false;

        chkKidneytransplantYes.Checked = false;
        chkKidneytransplantNo.Checked = false;
        txtKidneytransplant.Text = string.Empty;
        txtKidneytransplant.Enabled = false;

        chkPregnantCTYes.Checked = false;
        chkPregnantCTNo.Checked = false;
        txtPregnantCT.Text = string.Empty;
        txtPregnantCT.Enabled = false;

        chkAllergicCTYes.Checked = false;
        chkAllergicCTNo.Checked = false;
        txtAllergicCT.Text = string.Empty;
        txtAllergicCT.Enabled = false;
    }
    private void loadData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        PatientClass getPatient = new PatientClass();

        DataSet ds = param.dsPatientData;// getPatient.get_Patient_Registration_ByHN(_hn, env);
        DateTime end = DateTime.Now;
        DateTime start = end.AddYears(-2);
        try
        {
            DataSet dsCreatinine = getPatient.Get_Lab_Creatinine("XR", ds.Tables[0].Rows[0]["HN"].ToString(), start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"));
            //DataSet dsCreatinine = getPatient.Get_Lab_Creatinine("XR", "9990001", "01/02/2000", "31/12/2019");
            if (Utilities.IsHaveData(dsCreatinine))
            {
                if (Utilities.IsHaveData(dsCreatinine.Tables[0]))
                {
                    DataView dv = dsCreatinine.Tables[0].DefaultView;
                    dv.Sort = "reportDateTime desc";
                    DataTable dt = dv.ToTable();
                    DataRow[] rows = dt.Select("rq_id=" + dt.Rows[0]["rq_id"].ToString());
                    Session["creatinine"] = rows;

                    foreach (DataRow row in rows)
                    {
                        switch (row["shortTest"].ToString().ToLower())
                        {
                            case "creatinine":
                                txtCreatinine.Attributes.Add("Style", "color:black");
                                txtCreatinine.Text = row["resultValue"].ToString();// + " " + row["unit"].ToString();
                                if (!string.IsNullOrEmpty(row["range"].ToString()))
                                {
                                    string[] range = row["range"].ToString().Split('-');
                                    double Value = Convert.ToDouble(row["resultValue"].ToString());
                                    double min = Convert.ToDouble(range[0].ToString());
                                    double max = Convert.ToDouble(range[1].ToString());
                                    if (Value < min || Value > max)
                                    {
                                        txtCreatinine.Attributes.Add("Style", "color:red");
                                    }
                                }
                                break;
                            case "egfr (ckd-epi)":
                                txtgfr.Text = row["resultValue"].ToString();//+ " " + row["unit"].ToString();
                                break;
                        }
                        txtLastestResultDate.Text = row["reportDateTime"].ToString();
                        try
                        {
                            DateTime reportDateTime = Convert.ToDateTime(row["reportDateTime"].ToString());
                            if (DateTime.Now.AddMonths(-3) > reportDateTime)
                            {
                                lblAlertLastestResultDate.Text = "ผลเลือดเกิน 3 เดือน แนะนำให้ตวรจผลเลือดใหม่";
                            }
                        }
                        catch { }
                    }
                }
            }
            else
            {
                lblAlertLastestResultDate.Text = "คนไข้ไม่มีผลเลือด";
            }
        }
        catch {
            txtCreatinine.Text = "-";
            txtLastestResultDate.Text = "-";
            txtgfr.Text = "-";
            lblAlertLastestResultDate.Text = "ไม่มีผลเลือดจากทางLab";
        }

        if (ds.Tables[0].Rows[0]["GENDER"].ToString() != "F")
        {
            chkPregnantMRINo.Enabled = false;
            chkPregnantMRIYes.Enabled = false;
            txtPregnantMRI.Enabled = false;

            chkPregnantCTNo.Enabled = false;
            chkPregnantCTYes.Enabled = false;
            txtPregnantCT.Enabled = false;
        }

        if (Request.Params["TAB_OPEN"].ToString() == "tabMRI")
        {
            lbCaution.Text = "<font color='red'>ข้อควรระวัง (CAUTION)</font><br/>" +
                "<font color='red'>*</font> 1.โลหะหรือผ่าตัดใส่อุปกรณ์ในร่างกายอันเป็นข้อห้ามเข้ารับการตรวจ MRI ได้แก่  cardiac pacemaker, implantable cardioverter, neurostimulator, cochlear implants, cardiac valve prosthesis, middle ear prosthesis, surgical clips/stent ect.<br/>" +
                "<font color='red'>*** ของดการตรวจทุกกรณี หากไม่ลงนามในใบยินยอมการทำหัตถการ หรือกรณีพบว่าผู้ป่วยมีความเสี่ยงสูงต่อการตรวจ MRI ***</font>";
        }
        else
        {
            lbCaution.Text = "";
        }

        if (string.IsNullOrEmpty(param.SCHEDULE_ID)) return;
        if (param.SCHEDULE_ID == "0") return;

        ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
        incident.RIS_RISKINCIDENTS.SCHEDULE_ID = Convert.ToInt32(param.SCHEDULE_ID);
        DataTable dtIncident = incident.getDataByScheduleID();

        foreach (DataRow rows in dtIncident.Rows)
        {
            switch (rows["RISK_CAT_ID"].ToString())
            {
                case "32":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkWearingMetalEquipmentInTheBodyYes.Checked = true;
                            txtWearingMetalEquipmentInTheBody.Enabled = true;
                            break;
                        case "N":
                            chkWearingMetalEquipmentInTheBodyNo.Checked = true;
                            txtWearingMetalEquipmentInTheBody.Enabled = false;
                            break;
                    }
                    txtWearingMetalEquipmentInTheBody.Text = rows["INCIDENT_DESC"].ToString();
                    break;
                case "24":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkThreadLiftingYes.Checked = true;
                            txtThreadLifting.Enabled = true;
                            break;
                        case "N":
                            chkThreadLiftingNo.Checked = true;
                            txtThreadLifting.Enabled = false;
                            break;
                    }
                    txtThreadLifting.Text = rows["INCIDENT_DESC"].ToString();
                    break;
                case "46":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkMetalInEyeYes.Checked = true;
                            txtMetalInEye.Enabled = true;
                            break;
                        case "N":
                            chkMetalInEyeNo.Checked = true;
                            txtMetalInEye.Enabled = false;
                            break;
                    }
                    txtMetalInEye.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "41":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkInsertTheMetalTracheaTubeYes.Checked = true;
                            txtInsertTheMetalTracheaTube.Enabled = true;
                            break;
                        case "N":
                            chkInsertTheMetalTracheaTubeNo.Checked = true;
                            txtInsertTheMetalTracheaTube.Enabled = false;
                            break;
                    }
                    txtInsertTheMetalTracheaTube.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "25":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkWearBracesYes.Checked = true;
                            txtWearBraces.Enabled = true;
                            break;
                        case "N":
                            chkWearBracesNo.Checked = true;
                            txtWearBraces.Enabled = false;
                            break;
                    }
                    txtWearBraces.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "43":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkPermanentRadiationImplantationYes.Checked = true;
                            txtPermanentRadiationImplantation.Enabled = true;
                            break;
                        case "N":
                            chkPermanentRadiationImplantationNo.Checked = true;
                            txtPermanentRadiationImplantation.Enabled = false;
                            break;
                    }
                    txtPermanentRadiationImplantation.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "23":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkClaustrophobiaYes.Checked = true;
                            txtClaustrophobia.Enabled = true;
                            break;
                        case "N":
                            chkClaustrophobiaNo.Checked = true;
                            txtClaustrophobia.Enabled = false;
                            break;
                    }
                    txtClaustrophobia.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "44":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkPregnantMRIYes.Checked = true;
                            txtPregnantMRI.Enabled = true;
                            break;
                        case "N":
                            chkPregnantMRINo.Checked = true;
                            txtPregnantMRI.Enabled = false;
                            break;
                    }
                    txtPregnantMRI.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "47":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkAllergicMRIContrastMediaYes.Checked = true;
                            txtAllergicMRIContrastMedia.Enabled = true;
                            break;
                        case "N":
                            chkAllergicMRIContrastMediaNo.Checked = true;
                            txtAllergicMRIContrastMedia.Enabled = false;
                            break;
                    }
                    txtAllergicMRIContrastMedia.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "15":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkIodineAllergyYes.Checked = true;
                            txtIodineAllergy.Enabled = true;
                            break;
                        case "N":
                            chkIodineAllergyNo.Checked = true;
                            txtIodineAllergy.Enabled = false;
                            break;
                    }
                    txtIodineAllergy.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "13":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkFoodAllergyYes.Checked = true;
                            txtFoodAllergy.Enabled = true;
                            break;
                        case "N":
                            chkFoodAllergyNo.Checked = true;
                            txtFoodAllergy.Enabled = false;
                            break;
                    }
                    txtFoodAllergy.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "16":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkAsthmaYes.Checked = true;
                            txtAsthma.Enabled = true;
                            break;
                        case "N":
                            chkAsthmaNo.Checked = true;
                            txtAsthma.Enabled = false;
                            break;
                    }
                    txtAsthma.Text = rows["INCIDENT_DESC"].ToString(); break;
                //case "12": txtCreatinine.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "17":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkKidneytransplantYes.Checked = true;
                            txtKidneytransplant.Enabled = true;
                            break;
                        case "N":
                            chkKidneytransplantNo.Checked = true;
                            txtKidneytransplant.Enabled = false;
                            break;
                    }
                    txtKidneytransplant.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "48":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkPregnantCTYes.Checked = true;
                            txtPregnantCT.Enabled = true;
                            break;
                        case "N":
                            chkPregnantCTNo.Checked = true;
                            txtPregnantCT.Enabled = false;
                            break;
                    }
                    txtPregnantCT.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "49":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkAllergicCTYes.Checked = true;
                            txtAllergicCT.Enabled = true;
                            break;
                        case "N":
                            chkAllergicCTNo.Checked = true;
                            txtAllergicCT.Enabled = false;
                            break;
                    }
                    txtAllergicCT.Text = rows["INCIDENT_DESC"].ToString(); break;
                case "22":
                    switch (rows["INCIDENT_CHOOSED"].ToString())
                    {
                        case "Y":
                            chkUseContrastYes.Checked = true;
                            //txtUseContrast.Enabled = true;
                            break;
                        case "N":
                            chkUseContrastNo.Checked = true;
                            
                            //txtUseContrast.Enabled = false;
                            break;
                    }
                    showTxtUseContrast(Request.Params["TAB_OPEN"].ToString());
                    //txtUseContrast.Text = rows["INCIDENT_DESC"].ToString();
                    break;
            }
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataSet ds = param.dsPatientData;// getPatient.get_Patient_Registration_ByHN(_hn, env);
        string tab = Request.Params["TAB_OPEN"].ToString();
        //if (tabMainRiskManagement.SelectedTab.Value == "tabMRI")
        if (tab == "tabMRI")
        {
            lblAlert.Text = "กรุณาเลือกข้อมูล Contrast และ RISK OF MRI STUDY ให้ครบ";
            if (!chkUseContrastNo.Checked && !chkUseContrastYes.Checked)
                return;
            else if (!chkUseContrastNo.Checked && (!chkAllergicMRIContrastMediaYes.Checked && !chkAllergicMRIContrastMediaNo.Checked))
                return;
            else if (ds.Tables[0].Rows[0]["GENDER"].ToString() == "F" && (!chkPregnantMRIYes.Checked && !chkPregnantMRINo.Checked))
                return;
            else if ((!chkWearingMetalEquipmentInTheBodyYes.Checked && !chkWearingMetalEquipmentInTheBodyNo.Checked) ||
                        (!chkThreadLiftingYes.Checked && !chkThreadLiftingNo.Checked) ||
                        (!chkMetalInEyeYes.Checked && !chkMetalInEyeNo.Checked) ||
                        (!chkInsertTheMetalTracheaTubeYes.Checked && !chkInsertTheMetalTracheaTubeNo.Checked) ||
                        (!chkWearBracesYes.Checked && !chkWearBracesNo.Checked) ||
                        (!chkPermanentRadiationImplantationYes.Checked && !chkPermanentRadiationImplantationNo.Checked) ||
                        (!chkClaustrophobiaYes.Checked && !chkClaustrophobiaNo.Checked))
            {
                return;
            }
            else
            {
                lblAlert.Text = "";
            }
        }
        //else if (tabMainRiskManagement.SelectedTab.Value == "tabCT")
        else if (tab == "tabCT")
        {
            lblAlert.Text = "กรุณาเลือกข้อมูล Contrast และ RISK OF CT STUDY ให้ครบ";
            if (!chkUseContrastNo.Checked && !chkUseContrastYes.Checked)
                return;
            else if (!chkUseContrastNo.Checked &&
                ((!chkIodineAllergyYes.Checked && !chkIodineAllergyNo.Checked) ||
                (!chkFoodAllergyYes.Checked && !chkFoodAllergyNo.Checked) ||
                (!chkAsthmaYes.Checked && !chkAsthmaNo.Checked) ||
                (!chkKidneytransplantYes.Checked && !chkKidneytransplantNo.Checked)))
            {
                return;
            }
            else if (ds.Tables[0].Rows[0]["GENDER"].ToString() == "F" && (!chkPregnantCTYes.Checked && !chkPregnantCTNo.Checked))
                return;
            else if (!chkAllergicCTYes.Checked && !chkAllergicCTNo.Checked)
                return;
            else
            {
                lblAlert.Text = "";
            }
        }

        lblAlert.Text = "";
        DataTable dtRisk = new DataTable();
        dtRisk.Columns.Add("RISK_CAT_ID", typeof(int));
        dtRisk.Columns.Add("ORG_ID", typeof(int));
        dtRisk.Columns.Add("INCIDENT_UID", typeof(string));
        dtRisk.Columns.Add("INCIDENT_SUBJ", typeof(string));
        dtRisk.Columns.Add("INCIDENT_DT", typeof(DateTime));
        dtRisk.Columns.Add("INCIDENT_DESC", typeof(string));
        dtRisk.Columns.Add("CREATED_BY", typeof(int));
        dtRisk.Columns.Add("COMMENT_ID", typeof(int));
        dtRisk.Columns.Add("REG_ID", typeof(int));
        dtRisk.Columns.Add("INCIDENT_CHOOSED", typeof(string));
        dtRisk.AcceptChanges();
        Session["dataRISK"] = dtRisk;

        if (chkWearingMetalEquipmentInTheBodyYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkWearingMetalEquipmentInTheBodyYes.Value), "RISK OF MRI STUDY", txtWearingMetalEquipmentInTheBody.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkWearingMetalEquipmentInTheBodyNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkWearingMetalEquipmentInTheBodyNo.Value), "RISK OF MRI STUDY", string.Empty, env.OrgID, env.UserID, param.REG_ID);

        if (chkThreadLiftingYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkThreadLiftingYes.Value), "RISK OF MRI STUDY", txtThreadLifting.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkThreadLiftingNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkThreadLiftingNo.Value), "RISK OF MRI STUDY", string.Empty, env.OrgID, env.UserID, param.REG_ID);

        if (chkMetalInEyeYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkMetalInEyeYes.Value), "RISK OF MRI STUDY", txtMetalInEye.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkMetalInEyeNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkMetalInEyeNo.Value), "RISK OF MRI STUDY", txtMetalInEye.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkInsertTheMetalTracheaTubeYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkInsertTheMetalTracheaTubeYes.Value), "RISK OF MRI STUDY", txtInsertTheMetalTracheaTube.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkInsertTheMetalTracheaTubeNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkInsertTheMetalTracheaTubeNo.Value), "RISK OF MRI STUDY", txtInsertTheMetalTracheaTube.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkWearBracesYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkWearBracesYes.Value), "RISK OF MRI STUDY", txtWearBraces.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkWearBracesNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkWearBracesNo.Value), "RISK OF MRI STUDY", txtWearBraces.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkPermanentRadiationImplantationYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkPermanentRadiationImplantationYes.Value), "RISK OF MRI STUDY", txtPermanentRadiationImplantation.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkPermanentRadiationImplantationNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkPermanentRadiationImplantationNo.Value), "RISK OF MRI STUDY", txtPermanentRadiationImplantation.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkClaustrophobiaYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkClaustrophobiaYes.Value), "RISK OF MRI STUDY", txtClaustrophobia.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkClaustrophobiaNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkClaustrophobiaNo.Value), "RISK OF MRI STUDY", txtClaustrophobia.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkPregnantMRIYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkPregnantMRIYes.Value), "RISK OF MRI STUDY", txtPregnantMRI.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkPregnantMRINo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkPregnantMRINo.Value), "RISK OF MRI STUDY", txtPregnantMRI.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkAllergicMRIContrastMediaYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkAllergicMRIContrastMediaYes.Value), "RISK OF MRI STUDY", txtAllergicMRIContrastMedia.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkAllergicMRIContrastMediaNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkAllergicMRIContrastMediaNo.Value), "RISK OF MRI STUDY", txtAllergicMRIContrastMedia.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkIodineAllergyYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkIodineAllergyYes.Value), "RISK OF CT STUDY", txtIodineAllergy.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkIodineAllergyNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkIodineAllergyNo.Value), "RISK OF CT STUDY", txtIodineAllergy.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkFoodAllergyYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkFoodAllergyYes.Value), "RISK OF CT STUDY", txtFoodAllergy.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkFoodAllergyNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkFoodAllergyNo.Value), "RISK OF CT STUDY", txtFoodAllergy.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkAsthmaYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkAsthmaYes.Value), "RISK OF CT STUDY", txtAsthma.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkAsthmaNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkAsthmaNo.Value), "RISK OF CT STUDY", txtAsthma.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (!string.IsNullOrEmpty(txtCreatinine.Text))
            saveRiskIndication("Y", 12, "ALLERGIC", txtCreatinine.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkKidneytransplantYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkKidneytransplantYes.Value), "RISK OF CT STUDY", txtKidneytransplant.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkKidneytransplantNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkKidneytransplantNo.Value), "RISK OF CT STUDY", txtKidneytransplant.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkPregnantCTYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkPregnantCTYes.Value), "RISK OF CT STUDY", txtPregnantCT.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkPregnantCTNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkPregnantCTNo.Value), "RISK OF CT STUDY", txtPregnantCT.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkAllergicCTYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkAllergicCTYes.Value), "RISK OF CT STUDY", txtAllergicCT.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);
        if (chkAllergicCTNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkAllergicCTNo.Value), "RISK OF CT STUDY", txtAllergicCT.Text.Trim(), env.OrgID, env.UserID, param.REG_ID);

        if (chkUseContrastYes.Checked)
            saveRiskIndication("Y", Convert.ToInt32(chkUseContrastYes.Value), "ALLERGIC", "" /*txtUseContrast.Text.Trim()*/, env.OrgID, env.UserID, param.REG_ID);
        if (chkUseContrastNo.Checked)
            saveRiskIndication("N", Convert.ToInt32(chkUseContrastNo.Value), "ALLERGIC", "" /*txtUseContrast.Text.Trim()*/, env.OrgID, env.UserID, param.REG_ID);

        bool flagPopup = false;
        try
        {
            ProcessGetRisRiskCategorise ProcessRiskCategorise = new ProcessGetRisRiskCategorise();
            ProcessRiskCategorise.RIS_RISKCATEGORISE.ORG_ID = env.OrgID;
            ProcessRiskCategorise.Invoke();

            string str = "";
            DataTable dtRiskCategorise = ProcessRiskCategorise.Result.Tables[0].Copy();
            dtRiskCategorise = dtRiskCategorise.Select("IS_ALERT = 'Y'").CopyToDataTable();

            if (dtRiskCategorise.Rows.Count > 0)
            {
                DataTable dtstr = new DataTable();
                dtstr.Columns.Add("ALERT_DESC");

                DataTable dataRISK = Session["dataRISK"] as DataTable;
                DataRow[] drdataRISK = dataRISK.Select("INCIDENT_CHOOSED = 'Y'");
                if (drdataRISK.Length > 0)
                {
                    foreach (DataRow dr in drdataRISK)
                    {
                        DataTable dt = dtRiskCategorise.Copy();
                        DataRow[] drSel = dt.Select("RISK_CAT_ID = '" + dr["RISK_CAT_ID"].ToString() + "'");
                        if (drSel.Length > 0)
                        {
                            dtstr.Rows.Add(drSel[0]["ALERT_DESC"].ToString());
                        }
                    }
                }

                if (dtstr.Rows.Count > 0)
                {
                    DataView view = new DataView(dtstr);
                    DataTable distinctValues = view.ToTable(true, "ALERT_DESC");

                    foreach (DataRow dr in distinctValues.Rows)
                    {
                        if (str == "")
                            str = dr["ALERT_DESC"].ToString();
                        else
                            str += "\r\n\r\n" + dr["ALERT_DESC"].ToString();
                    }
                    Session["strRisk"] = str;
                    flagPopup = true;
                }
            }
        }
        catch { }

        if(flagPopup)
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showNormalAlert", "showNormalAlert('RiskManagement');", true);
        else
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "CloseAndRebind('RiskManagement');", true);
        
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('RiskManagementClose');", true);
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "OnClientClose();", true);
    }
    private void saveRiskIndication(string incident_choose, int risk_cat_id, string risk_subject, string risk_desc, int org_id, int created_by, int reg_id)
    {
        DataTable dtt = Session["dataRISK"] as DataTable;
        DataRow row = dtt.NewRow();
        row["RISK_CAT_ID"] = risk_cat_id;
        row["ORG_ID"] = org_id;
        row["INCIDENT_UID"] = string.Empty;
        row["INCIDENT_SUBJ"] = risk_subject;
        row["INCIDENT_DT"] = DateTime.Now;
        row["INCIDENT_DESC"] = incident_choose == "Y" ? risk_desc : "";
        row["CREATED_BY"] = created_by;
        row["COMMENT_ID"] = -1;
        row["REG_ID"] = reg_id;
        row["INCIDENT_CHOOSED"] = incident_choose;
        dtt.Rows.Add(row);
        dtt.AcceptChanges();
        Session["dataRISK"] = dtt;
    }
    
    protected void chkUseContrast_CheckedChanged(object sender, EventArgs e)
    {
        showTxtUseContrast(tabMainRiskManagement.SelectedTab.Value);
    }
    protected void tabMainRiskManagement_TabClick(object sender, RadTabStripEventArgs e)
    {
        showTxtUseContrast(e.Tab.Value);
    }
    private void showTxtUseContrast(string tab)
    {
        lblAlert.Text = "";
        if (tab == "tabMRI")
        {
            lbCaution.Text = "<font color='red'>ข้อควรระวัง (CAUTION)</font><br/>" +
                "<font color='red'>*</font> 1.โลหะหรือผ่าตัดใส่อุปกรณ์ในร่างกายอันเป็นข้อห้ามเข้ารับการตรวจ MRI ได้แก่  cardiac pacemaker, implantable cardioverter, neurostimulator, cochlear implants, cardiac valve prosthesis, middle ear prosthesis, surgical clips/stent ect.<br/>" +
                "<font color='red'>*** ของดการตรวจทุกกรณี หากไม่ลงนามในใบยินยอมการทำหัตถการ หรือกรณีพบว่าผู้ป่วยมีความเสี่ยงสูงต่อการตรวจ MRI ***</font>";
        }
        else
        {
            lbCaution.Text = "";
        }

        if (chkUseContrastYes.Checked)
        {
            if (tab == "tabMRI")
            {
                txtUseContrast.Text = "- GFR น้อยกว่า 30 ml/min/1.73m<sup>2</sup> พิจารณาความเสี่ยงต่อภาวะ Nephrogenic systemic fibrosis และอธิบายความเสี่ยงนี้แก่ผู้ป่วย <br/>" +
                    "- ผู้ป่วยHemodialysis และ CAPD ส่งปรึกษาอายุรแพทย์โรคไต";

                chkAllergicMRIContrastMediaYes.Enabled = true;
                chkAllergicMRIContrastMediaNo.Enabled = true;
            }
            else if (tab == "tabCT")
            {
                txtUseContrast.Text = "- GFR 30-60 ml/min พิจารณาIV Hydration เพื่อป้องกันภาวะ CONTRAST INDUCED NEPHROPATHY <br/>" +
                    //"- <a href=" + "http:\\......" + ">Print Standing Order for IV Hydration</a> <br/>" +
                    "- Print Standing Order for IV Hydration<br/>" +
                    "- GFR น้อยกว่าหรือเท่ากับ 30 ml/min  ส่งปรึกษาอายุรแพทย์โรคไต";

                chkIodineAllergyYes.Enabled = true;
                chkIodineAllergyNo.Enabled = true;

                chkFoodAllergyYes.Enabled = true;
                chkFoodAllergyNo.Enabled = true;

                chkAsthmaYes.Enabled = true;
                chkAsthmaNo.Enabled = true;

                chkKidneytransplantYes.Enabled = true;
                chkKidneytransplantNo.Enabled = true;
            }
        }
        else if (chkUseContrastNo.Checked)
        {
            txtUseContrast.Text = "";
            if (tab == "tabMRI")
            {
                chkAllergicMRIContrastMediaYes.Enabled = false;
                chkAllergicMRIContrastMediaNo.Enabled = false;
                chkAllergicMRIContrastMediaYes.Checked = false;
                chkAllergicMRIContrastMediaNo.Checked = false;
                txtAllergicMRIContrastMedia.Enabled = false;
            }
            else if (tab == "tabCT")
            {
                chkIodineAllergyYes.Enabled = false;
                chkIodineAllergyNo.Enabled = false;
                chkIodineAllergyYes.Checked = false;
                chkIodineAllergyNo.Checked = false;
                txtIodineAllergy.Enabled = false;

                chkFoodAllergyYes.Enabled = false;
                chkFoodAllergyNo.Enabled = false;
                chkFoodAllergyYes.Checked = false;
                chkFoodAllergyNo.Checked = false;
                txtFoodAllergy.Enabled = false;

                chkAsthmaYes.Enabled = false;
                chkAsthmaNo.Enabled = false;
                chkAsthmaYes.Checked = false;
                chkAsthmaNo.Checked = false;
                txtAsthma.Enabled = false;

                chkKidneytransplantYes.Enabled = false;
                chkKidneytransplantNo.Enabled = false;
                chkKidneytransplantYes.Checked = false;
                chkKidneytransplantNo.Checked = false;
                txtKidneytransplant.Enabled = false;
            }
        }
    }
    protected void chkWearingMetalEquipmentInTheBody_CheckedChanged(object sender, EventArgs e)
    {
        if (chkWearingMetalEquipmentInTheBodyYes.Checked)
        {
            txtWearingMetalEquipmentInTheBody.Enabled = true;
        }
        else
            txtWearingMetalEquipmentInTheBody.Enabled = false;
    }
    protected void chkThreadLifting_CheckedChanged(object sender, EventArgs e)
    {
        if (chkThreadLiftingYes.Checked)
            txtThreadLifting.Enabled = true;
        else
            txtThreadLifting.Enabled = false;
    }
    protected void chkMetalInEye_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMetalInEyeYes.Checked)
            txtMetalInEye.Enabled = true;
        else
            txtMetalInEye.Enabled = false;
    }
    protected void chkInsertTheMetalTracheaTube_CheckedChanged(object sender, EventArgs e)
    {
        if (chkInsertTheMetalTracheaTubeYes.Checked)
            txtInsertTheMetalTracheaTube.Enabled = true;
        else
            txtInsertTheMetalTracheaTube.Enabled = false;
    }
    protected void chkWearBraces_CheckedChanged(object sender, EventArgs e)
    {
        if (chkWearBracesYes.Checked)
            txtWearBraces.Enabled = true;
        else
            txtWearBraces.Enabled = false;
    }
    protected void chkPermanentRadiationImplantation_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPermanentRadiationImplantationYes.Checked)
            txtPermanentRadiationImplantation.Enabled = true;
        else
            txtPermanentRadiationImplantation.Enabled = false;
    }
    protected void chkClaustrophobia_CheckedChanged(object sender, EventArgs e)
    {
        if (chkClaustrophobiaYes.Checked)
            txtClaustrophobia.Enabled = true;
        else
            txtClaustrophobia.Enabled = false;
    }
    protected void chkPregnantMRI_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPregnantMRIYes.Checked)
            txtPregnantMRI.Enabled = true;
        else
            txtPregnantMRI.Enabled = false;
    }
    protected void chkAllergicMRIContrastMedia_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllergicMRIContrastMediaYes.Checked)
            txtAllergicMRIContrastMedia.Enabled = true;
        else
            txtAllergicMRIContrastMedia.Enabled = false;
    }
    protected void chkIodineAllergy_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIodineAllergyYes.Checked)
            txtIodineAllergy.Enabled = true;
        else
            txtIodineAllergy.Enabled = false;
    }
    protected void chkFoodAllergy_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFoodAllergyYes.Checked)
            txtFoodAllergy.Enabled = true;
        else
            txtFoodAllergy.Enabled = false;
    }
    protected void chkAsthma_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAsthmaYes.Checked)
            txtAsthma.Enabled = true;
        else
            txtAsthma.Enabled = false;
    }
    protected void chkKidneytransplant_CheckedChanged(object sender, EventArgs e)
    {
        if (chkKidneytransplantYes.Checked)
            txtKidneytransplant.Enabled = true;
        else
            txtKidneytransplant.Enabled = false;
    }
    protected void chkPregnantCT_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPregnantCTYes.Checked)
            txtPregnantCT.Enabled = true;
        else
            txtPregnantCT.Enabled = false;
    }
    protected void chkAllergicCT_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllergicCTYes.Checked)
            txtAllergicCT.Enabled = true;
        else
            txtAllergicCT.Enabled = false;
    }
    protected void chkSurgeryToPutProsthesisInTheBody_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllergicCTYes.Checked)
            txtAllergicCT.Enabled = true;
        else
            txtAllergicCT.Enabled = false;
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    { 
    }
}
