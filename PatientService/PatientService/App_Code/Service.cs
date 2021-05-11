using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.IO;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public PatientWrapper pt = new PatientWrapper();

    public Service () {
    
       
    }

    [WebMethod]
    public string About() {
        return "Miracle Advance Technologies";
    }

    #region Get Method.
    [WebMethod]
    public DataSet Get_demographic_long(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_demographic_long(hn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_demographic_long_outsidepatient(string DeptCode, string refMrn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_demographic_long_outsidepatient(DeptCode,refMrn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_demographic_short(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_demographic_short(hn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_demographic_shortByName(string cName)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_demographic_shortByName(cName.Trim()).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_ForeignDemographic(string pFHn)
    {
        DataSet ds = new DataSet();
        try
        {
            ds.Tables.Add(pt.Get_ForeignDemographic(pFHn.Trim()).Copy());
            LogSaving_Get_ForeignDemographic("Get_ForeignDemographic", pFHn, "", "", ds.GetXml());
        }
        catch
        {
            try
            {
                LogSaving_Get_ForeignDemographic("Get_ForeignDemographic", pFHn, "", "", ds.GetXml());
            }
            catch { }
        }
        return ds;
    }
    [WebMethod]
    public DataSet Get_Adr(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Adr(hn.Trim()).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_ipd_detail(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_ipd_detail(hn.Trim()).Copy());
        try
        {
            LogSaving_Get_ipd_detail("Get_ipd_detail", hn, "", "", ds.GetXml());
        }
        catch { }
        return ds;
    }

    //[WebMethod]
    //public DataSet Get_appointment(string hn)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_appointment(hn.ToUpper().Trim()).Copy());
    //    return ds;
    //}
    [WebMethod]
    public DataSet Get_appointment_detail(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_appointment_detail(hn.ToUpper().Trim()).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Claim_Amt(string hn, string accession_No)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Claim_Amt(hn.ToUpper().Trim(), accession_No.ToUpper().Trim()).Copy());
        return ds;
    }
    //[WebMethod]
    //public DataSet Get_insurance_detail(string hn)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_insurance_detail(hn.ToUpper().Trim()).Copy());
    //    return ds;
    //}

    [WebMethod]
    public DataSet Get_ForeignXrayOrder(string pFHn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_ForeignXrayOrder(pFHn.ToUpper().Trim()).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Lab_order(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Lab_order(hn.ToUpper().Trim()).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_Lab_OrderFull(string pHn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Lab_OrderFull(pHn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_Lab_OrderRegisted(string pHn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Lab_OrderRegisted(pHn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_lab_data(string hn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_lab_data(hn.ToUpper().Trim()).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_lab_data_researchall(string pHn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_lab_data_researchall(pHn).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_lab_data_researchbydate(string pHn, string pStartDate, string pEndDate)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_lab_data_researchbydate(pHn, pStartDate, pEndDate).Copy());
        return ds;
    }
    //[WebMethod]
    //public DataSet Get_lab_datachem_outside(string pReqname)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_lab_datachem_outside(pReqname).Copy());
    //    return ds;
    //}
    //[WebMethod]
    //public DataSet Get_lab_datahemato_outside(string pReqname)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_lab_datahemato_outside(pReqname).Copy());
    //    return ds;
    //}
    //[WebMethod]
    //public DataSet Get_lab_dataimmuno_outside(string pReqname)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_lab_dataimmuno_outside(pReqname).Copy());
    //    return ds;
    //}
    //[WebMethod]
    //public DataSet Get_lab_dataua_outside(string pReqname)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_lab_dataua_outside(pReqname).Copy());
    //    return ds;
    //}
    //[WebMethod]
    //public DataSet Get_lab_datavirus_outside(string pReqname)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Tables.Add(pt.Get_lab_datavirus_outside(pReqname).Copy());
    //    return ds;
    //}

    [WebMethod]
    public DataSet Get_MedPatient(string hn, string an)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_MedPatient(hn.ToUpper().Trim(), an.ToUpper().Trim()).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Payment_Status(string hn, string an, string accNo)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Payment_Status(hn.ToUpper().Trim(), an.ToUpper().Trim(), accNo.ToUpper().Trim()).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_payment_status_outsidepatient(string refMrn, string accession_No, string dept_Code)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_payment_status_outsidepatient(refMrn.ToUpper().Trim(), accession_No.ToUpper().Trim(), dept_Code.ToUpper().Trim()));
        return ds;
    }

    [WebMethod]
    public DataSet Get_XrayOrder(string pHn)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_XrayOrder(pHn.ToUpper().Trim()).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_all_exam(string exam_code)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_all_exam(exam_code.ToUpper().Trim()).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Org_detail(string pOrgID)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Org_detail(pOrgID).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Place_detail(string pPlaceID)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_Place_detail(pPlaceID).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_sdloc_all()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_sdloc_all().Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_sdloc_detail(string pSrc)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_sdloc_detail(pSrc).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_staff_detail(string user_id, string password_id)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_staff_detail(user_id, password_id).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Get_staff_fulldetail(string sCode)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_staff_fulldetail(sCode).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_TubeID(string pHn, string pSpecimenType)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Get_TubeID(pHn, pSpecimenType).Copy());
        return ds;
    }

    [WebMethod]
    public object Get_Version()
    {
        object obj = pt.Get_Version();
        return obj;
    }

    [WebMethod]
    public DataSet GetEligibilityInsuranceDetail(string pMRN, string pEncType, string PEncID, string pSDLOC, string pPerfDate, string pClinicType)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.GetEligibilityInsuranceDetail(pMRN, pEncType, PEncID, pSDLOC, pPerfDate, pClinicType).Copy());
        try
        {
            LogSaving_GetEligibilityInsuranceDetail("GetEligibilityInsuranceDetail"
                , pMRN, pEncType, PEncID, pSDLOC, pPerfDate, pClinicType, ds.GetXml());
        }
        catch { }
        return ds;
    }
    
    [WebMethod]
    public DataSet GetEncounterDetailByMRNForToday(string pMRN)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.GetEncounterDetailByMRNForToday(pMRN).Copy());
        LogSaving("GetEncounterDetailByMRNForToday", pMRN, "", "", ds.GetXml());
        return ds;
    }
    
    [WebMethod]
    public DataSet GetEncounterDetailByMRNDATE(string pMRN, string pCDate)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.GetEncounterDetailByMRNDATE(pMRN, pCDate).Copy());
        LogSaving("GetEncounterDetailByMRNDATE", pMRN, pCDate, "", ds.GetXml());
        return ds;
    }
    
    [WebMethod]
    public DataSet GetEncounterDetailByMRNENCTYPE(string pMRN, string pEncType)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.GetEncounterDetailByMRNENCTYPE(pMRN, pEncType).Copy());
        LogSaving("GetEncounterDetailByMRNENCTYPE", pMRN, "", pEncType, ds.GetXml());
        return ds;
    }

    [WebMethod]
    public DataSet GetEncounterDetailClinicTypePriceType(string pMRN, string pStrProductCode, string pActiveDate, string pNonresident)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.GetEncounterDetailClinicTypePriceType(pMRN, pStrProductCode, pActiveDate, pNonresident).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet searchPatientIdentificationByMRNandActiveDate(string pMRN, string ActiveDate)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.searchPatientIdentificationByMRNandActiveDate(pMRN, ActiveDate).Copy());
        return ds;
    }

    [WebMethod]
    public DataSet Get_Lab_Creatinine(string pBType, string pMRN, string pStartDate, string pEndDate)
    {
        return pt.Get_Lab_Creatinine(pBType, pMRN, pStartDate, pEndDate);
    }

    [WebMethod]
    public string Get_Lab_Creatinine_String(string pBType, string pMRN, string pStartDate, string pEndDate)
    {
        return pt.Get_Lab_Creatinine_String(pBType, pMRN, pStartDate, pEndDate);
    }
    #endregion

    #region Set Method.
    [WebMethod]
    public string Set_Billing(string xString)
    {
        //DataSet ds = new DataSet();
        //ds.Tables.Add(pt.Set_Billing(xString).Copy());
        //return ds;
        string str=string.Empty;
        //try
        //{ 
            str = pt.Set_Billing(xString);
        //    System.IO.File.AppendAllText(@"d:\envision\log.txt", "SEND:" + xString + "\r\n ACK:" + str + "\r\n");
        //}
        //catch
        //{ System.IO.File.AppendAllText(@"d:\envision\log.txt", "SEND:" + xString + "\r\n ACK:" + str + "\r\n"); }
        return str;

    }
    [WebMethod]
    public DataSet Set_Billing_OutsidePatient(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_Billing_OutsidePatient(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_ConfirmTube(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_ConfirmTube(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_Demographic_Long_OutsidePatient(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_Demographic_Long_OutsidePatient(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_OR(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_OR(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_PAE(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_PAE(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_StaffPayroll(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_StaffPayroll(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_Ward2Xray(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_Ward2Xray(xString).Copy());
        return ds;
    }
    [WebMethod]
    public DataSet Set_WorkStaff(string xString)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(pt.Set_WorkStaff(xString).Copy());
        return ds;
    }
    #endregion

    #region Cancel Method.
    [WebMethod]
    public string Cancel_Billing(string hn, string accession_No, string an, string iseq)
    {
        //DataSet ds = new DataSet();
        //ds.Tables.Add(pt.Cancel_Billing(hn, accession_No, an, iseq).Copy());
        //return ds;
        string str = string.Empty;
        //string send = string.Empty;
        //try 
        //{
           str = pt.Cancel_Billing(hn, accession_No, an, iseq);
        //   send = "HN:" + hn.ToString() + " Acession:" + accession_No.ToString() + " AN:" + an.ToString() + " iseq:" + iseq.ToString(); 
        //   System.IO.File.AppendAllText(@"d:\envision\log.txt", "CANCLE:" + send + "\r\n ACK:" + str + "\r\n");
        //}
        //catch
        //{ System.IO.File.AppendAllText(@"d:\envision\log.txt", "CANCLE:" + send + "\r\n ACK:" + str + "\r\n"); }
        return str;
    }
    #endregion 

    private string strLogFolder = ConfigurationSettings.AppSettings["LogPath"];
    private void LogSaving(string his_type, string HN, string Date, string EncType,string return_data)
    {
        try
        {
            if (!Directory.Exists(strLogFolder+@"\EnvisionBillingLog"))
                Directory.CreateDirectory(strLogFolder + @"\EnvisionBillingLog");

            File.AppendAllText(
                strLogFolder + @"\EnvisionBillingLog\" + DateTime.Now.ToString("dd MM yyyy") + ".txt"
                , his_type + " " + HN + " " + Date + " " + EncType + " " + DateTime.Now.ToString("HH:mm") +
                "\r\n" + return_data + "\r\n\r\n"
                );
        }
        catch
        { }        
    }
    private void LogSaving_Get_ipd_detail(string his_type, string HN, string Date, string EncType, string return_data)
    {
        try
        {
            if (!Directory.Exists(strLogFolder + @"\EnvisionGetIpdDetailLog"))
                Directory.CreateDirectory(strLogFolder + @"\EnvisionGetIpdDetailLog");

            File.AppendAllText(
                strLogFolder + @"\EnvisionGetIpdDetailLog\" + DateTime.Now.ToString("dd MM yyyy") + ".txt"
                , his_type + " " + HN + " " + Date + " " + EncType + " " + DateTime.Now.ToString("HH:mm") +
                "\r\n" + return_data + "\r\n\r\n"
                );
        }
        catch
        { }
    }
    private void LogSaving_Get_ForeignDemographic(string his_type, string HN, string Date, string EncType, string return_data)
    {
        try
        {
            if (!Directory.Exists(strLogFolder + @"\EnvisionGetForeignDemographic"))
                Directory.CreateDirectory(strLogFolder + @"\EnvisionGetForeignDemographic");

            File.AppendAllText(
                strLogFolder + @"\EnvisionGetForeignDemographic\" + DateTime.Now.ToString("dd MM yyyy") + ".txt"
                , his_type + " " + HN + " " + Date + " " + EncType + " " + DateTime.Now.ToString("HH:mm") +
                "\r\n" + return_data + "\r\n\r\n"
                );
        }
        catch
        { }
    }
    private void LogSaving_GetEligibilityInsuranceDetail(string his_type, string pMRN, string pEncType, string PEncID, string pSDLOC, string pPerfDate, string pClinicType, string return_data)
    {
        try
        {
            if (!Directory.Exists(strLogFolder + @"\EnvisionGetEligibilityInsuranceDetail"))
                Directory.CreateDirectory(strLogFolder + @"\EnvisionGetEligibilityInsuranceDetail");

            File.AppendAllText(
                strLogFolder + @"\EnvisionGetEligibilityInsuranceDetail\" + DateTime.Now.ToString("dd MM yyyy") + ".txt"
                , his_type + " " + pMRN + " " + pEncType + " " + PEncID + " " + pSDLOC + " " 
                + pPerfDate + " " + pClinicType + " " + DateTime.Now.ToString("HH:mm") +
                "\r\n" + return_data + "\r\n\r\n"
                );
        }
        catch
        { }
    }
    
}
    