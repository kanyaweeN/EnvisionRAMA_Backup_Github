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
        public bool get_Patient_NonResident(string _hn, out bool _isTeleMed, out int _encId)
        {
            _isTeleMed = false;
            _encId = 0;
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

                    DataTable dtTele = new DataTable();
                    dtTele.Columns.Add("encId");
                    dtTele.Columns.Add("encType");
                    dtTele.Rows.Add(dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString(), dsCheckNonResident.Tables[0].Rows[0]["enc_type"].ToString());
                    DataSet dsTele = new DataSet();
                    dsTele.Tables.Add(dtTele.Copy());
                    EnvisionOnline.WebService.EnvisionIEGet3rdPartyData getParty = new WebService.EnvisionIEGet3rdPartyData("http://miracle99/");
                    _isTeleMed = getParty.Get_TeleMedByEncIdAndType(dsTele);
                    _encId = string.IsNullOrEmpty(dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString()) ? 0 : Convert.ToInt32(dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString());

                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
        public DataSet get_Patient_Registration_ByHN(string _hn, GBLEnvVariable env, bool is_vna)
        {
            bool flag = false;
            DataSet ds = new DataSet();
            DataSet dsCheckNonResident = new DataSet();
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
                    dsCheckNonResident = proxy.GetEncounterDetailByMRNDATE(_hn, dateEntry.ToString("dd/MM/yyyy"));
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
                    #region Check Insurance
                    ProcessGetRISInsurancetype getIns = new ProcessGetRISInsurancetype(env.OrgID);
                    getIns.Invoke();
                    DataRow[] rowsCheck = getIns.Result.Tables[0].Select("INSURANCE_TYPE_UID='" + dsInsurance.Tables[0].Rows[0]["insurance"].ToString() + "'");
                    if (rowsCheck.Length == 0)
                    {
                        //insert
                        ProcessAddRISInsurancetype procINS = new ProcessAddRISInsurancetype();
                        procINS.RIS_INSURANCETYPE.CREATED_BY = env.UserID;
                        procINS.RIS_INSURANCETYPE.INSURANCE_TYPE_DESC = dsInsurance.Tables[0].Rows[0]["insurance_name"].ToString();
                        procINS.RIS_INSURANCETYPE.INSURANCE_TYPE_UID = dsInsurance.Tables[0].Rows[0]["insurance"].ToString();
                        procINS.RIS_INSURANCETYPE.ORG_ID = env.OrgID;
                        procINS.Invoke();
                        //
                    }
                    #endregion


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
                HIS_REGISTRATION his = new Common.HIS_REGISTRATION();
                his.ADDR1 = ds.Tables[0].Rows[0]["address"].ToString();// patient.Address1;
                his.ADDR2 = ds.Tables[0].Rows[0]["amphur"].ToString();// patient.Address2;
                his.ADDR3 = ds.Tables[0].Rows[0]["province"].ToString();// patient.Address3;
                his.ADDR4 = ds.Tables[0].Rows[0]["zipcode"].ToString();// patient.Address4;
                his.EM_CONTACT_PERSON = "";// patient.Em_Contact_Person;
                his.EMAIL = ds.Tables[0].Rows[0]["email"].ToString();//patient.Email;
                his.NATIONALITY = ds.Tables[0].Rows[0]["id_card_no"].ToString();//patient.Nationality;
                his.CREATED_BY = env.UserID;
                his.DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]);//patient.DateOfBirth;
                his.FNAME = ds.Tables[0].Rows[0]["first_name"].ToString();//patient.FirstName;
                his.FNAME_ENG = ds.Tables[0].Rows[0]["first_name_eng"].ToString();//patient.FirstName_ENG;
                his.MNAME_ENG = "";//patient.MiddleName_ENG;
                if (ds.Tables[0].Rows[0]["gender"].ToString() != null)
                    his.GENDER = Convert.ToChar(ds.Tables[0].Rows[0]["gender"].ToString());
                his.HN = _hn;
                his.LNAME = ds.Tables[0].Rows[0]["last_name"].ToString();// patient.LastName;
                his.LNAME_ENG = ds.Tables[0].Rows[0]["last_name_eng"].ToString();// patient.LastName_ENG;
                his.ORG_ID = env.OrgID;
                his.PHONE1 = ds.Tables[0].Rows[0]["home_tel"].ToString();//patient.Phone1;
                his.PHONE2 = ds.Tables[0].Rows[0]["office_tel"].ToString();//patient.Phone2;
                his.PHONE3 = ds.Tables[0].Rows[0]["mobile_no"].ToString();//patient.Phone3;
                his.SSN = ds.Tables[0].Rows[0]["id_card_no"].ToString();//patient.SocialNumber;
                his.TITLE = ds.Tables[0].Rows[0]["initial_name"].ToString();//patient.Title;
                his.TITLE_ENG = ds.Tables[0].Rows[0]["initial_name_eng"].ToString();//patient.Title_ENG;
                his.INSURANCE_TYPE = "";// patient.InsuranceID.ToString();
                his.IS_FOREIGNER = ds.Tables[0].Rows[0]["nonresidence"].ToString();
                his.PATIENT_ID_DETAIL = ds.Tables[0].Rows[0]["PatientIdentificationDetail"].ToString();
                his.PATIENT_ID_LABEL = ds.Tables[0].Rows[0]["PatientIdentificationLabel"].ToString();
                ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                pAddHIS.HIS_REGISTRATION = his;
                pAddHIS.Invoke();

                //if (is_vna)
                //{
                //    int _vna_id = 0;
                //    ProcessAddHISRegistration vnaAddHIS = new ProcessAddHISRegistration(false);
                //    vnaAddHIS.HIS_REGISTRATION = his;
                //    vnaAddHIS.InvokeVNA();
                //    dsCheckNonResident = proxy.GetEncounterDetailByMRNENCTYPE(_hn, "ALL");
                //    foreach (DataRow rowVNA in dsCheckNonResident.Tables[0].Rows)
                //    {
                //        DateTime efDate = DateTime.MinValue;
                //        string[] spDatetime = rowVNA["effectivestartdate"].ToString().Split(' ');
                //        if (spDatetime.Length > 0)
                //        {
                //            string[] spDate = spDatetime[0].Split('/');
                //            string[] spTime = spDatetime[1].Split(':');
                //            efDate = new DateTime(Convert.ToInt32(spDate[2]), Convert.ToInt32(spDate[1]), Convert.ToInt32(spDate[0]), Convert.ToInt32(spTime[0]), Convert.ToInt32(spTime[1]), Convert.ToInt32(spTime[2]));
                //        }

                //        ProcessAddVNAWorklist vna = new ProcessAddVNAWorklist();
                //        vna.VNA_WORKLIST.VN = rowVNA["enc_id"].ToString();
                //        vna.VNA_WORKLIST.REG_ID = vnaAddHIS.HIS_REGISTRATION.REG_ID;
                //        vna.VNA_WORKLIST.ORG_ID = env.OrgID;
                //        vna.VNA_WORKLIST.ENC_ID = Convert.ToInt32(rowVNA["enc_id"].ToString());
                //        vna.VNA_WORKLIST.ENC_TYPE = rowVNA["enc_type"].ToString();
                //        vna.VNA_WORKLIST.SDLOC_ID = rowVNA["sdloc_id"].ToString();
                //        vna.VNA_WORKLIST.INSURANCE = rowVNA["insurance"].ToString();
                //        vna.VNA_WORKLIST.EFFECTIVE_START_DATE = efDate;
                //        vna.VNA_WORKLIST.CREATED_BY_UID = env.UserUID;
                //        vna.VNA_WORKLIST.LAST_MODIFIED_BY_UID = env.UserUID;
                //        vna.Invoke();

                //        _vna_id = vna.VNA_WORKLIST.VNA_ID;
                //    }
                //    EnvisionOnline.Webservice.VNAWebServices.Service vnaService = new Webservice.VNAWebServices.Service();
                //    new Webservice.VNAWebServices.Service().Set_ADTPendingAdmitByVnaIdQueue(0, _vna_id);
                //}
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
        public DataSet get_appointment_detail(string _hn)
        {
            DataSet ds = new DataSet();
            Service proxy = new Service();
            try
            {
                ds = proxy.Get_appointment_detail(_hn);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        public DataSet Get_Lab_Creatinine(string pBType, string pMRN, string pStartDate, string pEndDate)
        {
            Service proxy = new Service();
            return proxy.Get_Lab_Creatinine(pBType, pMRN, pStartDate, pEndDate);
        }
        public string Get_Lab_Creatinine_String(string pBType, string pMRN, string pStartDate, string pEndDate)
        {
            Service proxy = new Service();
            return proxy.Get_Lab_Creatinine_String(pBType, pMRN, pStartDate, pEndDate);
        }
    }
}
