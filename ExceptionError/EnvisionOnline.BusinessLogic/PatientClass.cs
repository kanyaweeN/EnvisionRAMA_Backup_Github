using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Webservice.HISWebService;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic
{
    public class PatientClass
    {
        private bool IsHaveData(DataSet ds)
        {
            if (ds == null) return false;
            if (ds.Tables.Count == 0) return false;
            bool flag = false;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable dtt = ds.Tables[i];
                if (IsHaveData(dtt))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private bool IsHaveData(DataTable dtt)
        {
            if (dtt == null) return false;
            if (dtt.Rows.Count == 0) return false;
            return true;
        }
        
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public PatientClass()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
        }
        public bool get_Patient_NonResident(string _hn)
        {
            bool flag = false;
            Service proxy = new Service();
            try
            {
               

                DataSet dsCheckNonResident = proxy.GetEncounterDetailByMRNDATE(_hn, DateTime.Now.ToString("dd/MM/yyyy"));
                if (dsCheckNonResident.Tables[0].Rows.Count > 0)
                {
                    DataSet dsEl = proxy.GetEligibilityInsuranceDetail(_hn
                        , dsCheckNonResident.Tables[0].Rows[0]["enc_type"].ToString()
                        , dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString()
                        , dsCheckNonResident.Tables[0].Rows[0]["sdloc_id"].ToString()
                        , DateTime.Now.ToString("dd/MM/yyyy")
                        , "RGL");
                    if (dsEl.Tables[0].Rows.Count > 0)
                        flag = dsEl.Tables[0].Rows[0]["detail"].ToString() == "non-resident(v)" ? true : false;

                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
        public DataSet get_Patient_Registration_ByHN(string _hn,GBLEnvVariable env)
        {
            bool flag = false;
            DataSet ds = new DataSet();
            Service proxy = new Service();
            try
            {
                ds = proxy.Get_demographic_long(_hn);

                DataTable dtt = null;
                if (ds != null)
                    if (ds.Tables.Count > 0)
                        dtt = ds.Tables[0].Copy();

                DataSet dsRet = new DataSet();
                dsRet.Tables.Add(dtt.Copy());
                dsRet.AcceptChanges();

                DataSet dsRef;
                try
                {
                    dsRef = proxy.Get_ipd_detail(_hn);
                    if (dsRef != null)
                        if (dsRef.Tables.Count > 0)
                            if (dsRef.Tables[0].Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dsRef.Tables[0].Rows[0]["an"].ToString()))
                                {
                                    dsRet.Tables.Add(dsRef.Tables[0].Copy());
                                    dsRet.AcceptChanges();
                                    flag = false;
                                }
                            }
                }
                catch (Exception exIPD)
                {

                }
                if (flag)
                {

                    try
                    {
                        dsRef = new DataSet();
                        dsRef = proxy.Get_appointment_detail(_hn);

                        DataTable dttRef = null;
                        if (dsRef != null)
                            if (dsRef.Tables.Count > 0)
                                dttRef = dsRef.Tables[0].Copy();
                        dsRet.Tables.Add(dttRef.Copy());
                        dsRet.AcceptChanges();
                    }
                    catch (Exception exRef)
                    {

                    }
                }
                if (IsHaveData(ds))
                {
                    if (!ds.Tables[0].Columns.Contains("PatientIdentificationLabel"))
                        ds.Tables[0].Columns.Add("PatientIdentificationLabel");
                    if (!ds.Tables[0].Columns.Contains("PatientIdentificationDetail"))
                        ds.Tables[0].Columns.Add("PatientIdentificationDetail");
                    ds.AcceptChanges();
                    DateTime dateEntry = DateTime.Now;
                    try
                    {
                        string _tablename = dsRet.Tables.IndexOf("appoint_detail") > 0 ? "appoint_detail" : dsRet.Tables.IndexOf("ipd_detail") > 0 ? "ipd_detail" : "";
                        switch (_tablename)
                        {
                            case "appoint_detail": dateEntry = Convert.ToDateTime(dsRet.Tables[dsRet.Tables.IndexOf("appoint_detail")].Rows[0]["appt_date"]); break;
                            case "ipd_detail": dateEntry = Convert.ToDateTime(dsRet.Tables[dsRet.Tables.IndexOf("ipd_detail")].Rows[0]["admission_date"]); break;
                        }
                        DataSet dsPatID = proxy.searchPatientIdentificationByMRNandActiveDate(_hn, dateEntry.ToString("dd/MM/yyyy"));
                        if (IsHaveData(dsPatID))
                        {
                            ds.Tables[0].Rows[0]["PatientIdentificationLabel"] = dsPatID.Tables[0].Rows[0]["PatientIdentificationLabel"].ToString();
                            ds.Tables[0].Rows[0]["PatientIdentificationDetail"] = dsPatID.Tables[0].Rows[0]["PatientIdentificationDetail"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    DataSet dsInsurance = new DataSet();
                    //Check Non-Resident
                    DataSet dsCheckNonResident = proxy.GetEncounterDetailByMRNDATE(_hn, dateEntry.ToString("dd/MM/yyyy"));
                    if (IsHaveData(dsCheckNonResident))
                    {
                        dsInsurance = proxy.GetEligibilityInsuranceDetail(_hn
                            , dsCheckNonResident.Tables[0].Rows[0]["enc_type"].ToString()
                            , dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString()
                            , dsCheckNonResident.Tables[0].Rows[0]["sdloc_id"].ToString()
                            , DateTime.Now.ToString("dd/MM/yyyy")// Convert.ToDateTime(dsCheckNonResident.Tables[0].Rows[0]["effectivestartdate"]).ToString("dd/MM/yyyy")
                            , "RGL");
                        if (IsHaveData(dsInsurance))
                            ds.Tables[0].Rows[0]["nonresidence"] = dsInsurance.Tables[0].Rows[0]["detail"].ToString() == "non-resident(v)" ? "Y" : "N";
                    }
                    else
                    {
                        dsInsurance = proxy.GetEligibilityInsuranceDetail(_hn
                            , ""
                            , ""
                            , ""
                            , ""
                            , "RGL");
                        if (IsHaveData(dsInsurance))
                            ds.Tables[0].Rows[0]["nonresidence"] = dsInsurance.Tables[0].Rows[0]["detail"].ToString() == "non-resident(v)" ? "Y" : "N";
                    }
                }
            }
            catch (Exception ex)
            {
            }
            

            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    flag = true;
            if (flag)
            {
                ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                pAddHIS.HIS_REGISTRATION.ADDR1 = ds.Tables[0].Rows[0]["address"].ToString();// patient.Address1;
                pAddHIS.HIS_REGISTRATION.ADDR2 = ds.Tables[0].Rows[0]["amphur"].ToString();// patient.Address2;
                pAddHIS.HIS_REGISTRATION.ADDR3 = ds.Tables[0].Rows[0]["province"].ToString();// patient.Address3;
                pAddHIS.HIS_REGISTRATION.ADDR4 = ds.Tables[0].Rows[0]["zipcode"].ToString();// patient.Address4;
                pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = "";// patient.Em_Contact_Person;
                pAddHIS.HIS_REGISTRATION.EMAIL = ds.Tables[0].Rows[0]["email"].ToString();//patient.Email;
                pAddHIS.HIS_REGISTRATION.NATIONALITY = ds.Tables[0].Rows[0]["id_card_no"].ToString();//patient.Nationality;
                pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                pAddHIS.HIS_REGISTRATION.DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]);//patient.DateOfBirth;
                pAddHIS.HIS_REGISTRATION.FNAME = ds.Tables[0].Rows[0]["first_name"].ToString();//patient.FirstName;
                pAddHIS.HIS_REGISTRATION.FNAME_ENG = ds.Tables[0].Rows[0]["first_name_eng"].ToString();//patient.FirstName_ENG;
                pAddHIS.HIS_REGISTRATION.MNAME_ENG = "";//patient.MiddleName_ENG;
                if (ds.Tables[0].Rows[0]["gender"].ToString() != null)
                    pAddHIS.HIS_REGISTRATION.GENDER = Convert.ToChar(ds.Tables[0].Rows[0]["gender"].ToString());
                pAddHIS.HIS_REGISTRATION.HN = _hn;
                pAddHIS.HIS_REGISTRATION.LNAME = ds.Tables[0].Rows[0]["last_name"].ToString();// patient.LastName;
                pAddHIS.HIS_REGISTRATION.LNAME_ENG = ds.Tables[0].Rows[0]["last_name_eng"].ToString();// patient.LastName_ENG;
                pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pAddHIS.HIS_REGISTRATION.PHONE1 = ds.Tables[0].Rows[0]["home_tel"].ToString();//patient.Phone1;
                pAddHIS.HIS_REGISTRATION.PHONE2 = ds.Tables[0].Rows[0]["office_tel"].ToString();//patient.Phone2;
                pAddHIS.HIS_REGISTRATION.PHONE3 = ds.Tables[0].Rows[0]["mobile_no"].ToString();//patient.Phone3;
                pAddHIS.HIS_REGISTRATION.SSN = ds.Tables[0].Rows[0]["id_card_no"].ToString();//patient.SocialNumber;
                pAddHIS.HIS_REGISTRATION.TITLE = ds.Tables[0].Rows[0]["initial_name"].ToString();//patient.Title;
                pAddHIS.HIS_REGISTRATION.TITLE_ENG = ds.Tables[0].Rows[0]["initial_name_eng"].ToString();//patient.Title_ENG;
                pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = "";// patient.InsuranceID.ToString();
                pAddHIS.HIS_REGISTRATION.IS_FOREIGNER = ds.Tables[0].Rows[0]["nonresidence"].ToString();
                pAddHIS.HIS_REGISTRATION.PATIENT_ID_DETAIL = ds.Tables[0].Rows[0]["PatientIdentificationDetail"].ToString();
                pAddHIS.HIS_REGISTRATION.PATIENT_ID_LABEL = ds.Tables[0].Rows[0]["PatientIdentificationLabel"].ToString();
                pAddHIS.Invoke();
            }

                ProcessGetHISRegistration _his = new ProcessGetHISRegistration(_hn);
                _his.Invoke();
                ds = _his.Result;
            return ds;
        }
        public DataSet get_Patient_Registration_ByREG_ID(int reg_id)
        {
            DataSet ds = new DataSet();
            ProcessGetHISRegistration _his = new ProcessGetHISRegistration(reg_id);
            _his.Invoke();
            ds = _his.Result;
            return ds;
        }
        public void set_Patient_Phone()
        {
            ProcessUpdatePatientPhone _his = new ProcessUpdatePatientPhone();
            _his.HIS_REGISTRATION = this.HIS_REGISTRATION;
            _his.Invoke();
        }
    }
}
