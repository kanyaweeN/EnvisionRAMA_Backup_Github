using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using Envision.Common;
using Envision.Common.Linq;
using Envision.DataAccess.Select;
using Envision.WebService.HISWebService;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Miracle.HL7;
using Miracle.Translator;
using Miracle.Util;
using Envision.Operational.Translator;
namespace Envision.BusinessLogic
{
    public class Patient : IPatientDemographic
    {
        private bool linkdown;
        private bool hasHN;
        private bool dataFromHIS;
        private bool dataFromLocal;
        private bool dataFromManual;


        #region Member
        private int reg_id;
        private string reg_uid;
        private string title;
        private DateTime reg_dt;
        private string fname;
        private string mname;
        private string lname;
        private string title_eng;
        private string fname_eng;
        private string mname_eng;
        private string lname_eng;
        private string ssn;
        private DateTime dob;
        private int age;
        private string addr1;
        private string addr2;
        private string addr3;
        private string addr4;
        private string addr5;
        private string phone1;
        private string phone2;
        private string phone3;
        private string email;
        private string gender;
        private string marital_status;
        private int occupation_id;
        private string nationality;
        private string passport_no;
        private string blood_group;
        private string religeon;
        private string patient_type;
        private string em_contact_person;
        private string em_relation;
        private string em_addr;
        private string em_phone;
        private string insurance_type;
        private string insurance_name;
        private string hl7_format;
        private string hl7_send;
        private string allergies;
        private int org_id;
        private int created_by;
        private DateTime created_on;
        private int last_modified_by;
        private DateTime last_modified_on;
        private string ref_doc_instruction;
        private string refer_from;
        private string department_name;
        private string doctor_name;
        private int ref_doc;
        private int ref_unit;
        private int insuranceID;
        private bool is_allergy;
        private DataTable allergyData;
        private string non_residence;
        private string patientIDLabel;
        private string patientIDDetail;
        #endregion

        #region IPatientDemographic Members
        public int Reg_ID
        {
            get
            {
                return reg_id;
            }
            set
            {
                reg_id = value;
            }
        }
        public string Reg_UID
        {
            get
            {
                return reg_uid;
            }
            set
            {
                reg_uid = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public DateTime Reg_DT
        {
            get
            {
                return reg_dt;
            }
            set
            {
                reg_dt = value;
            }
        }
        public string FirstName
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return mname;
            }
            set
            {
                mname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }
        public string Title_ENG
        {
            get
            {
                return title_eng;
            }
            set
            {
                title_eng = value;
            }
        }
        public string FirstName_ENG
        {
            get
            {
                return fname_eng;
            }
            set
            {
                fname_eng = value;
            }
        }
        public string MiddleName_ENG
        {
            get
            {
                return mname_eng;
            }
            set
            {
                mname_eng = value;
            }
        }
        public string LastName_ENG
        {
            get
            {
                return lname_eng;
            }
            set
            {
                lname_eng = value;
            }
        }
        public string SocialNumber
        {
            get
            {
                return ssn;
            }
            set
            {
                ssn = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Address1
        {
            get
            {
                return addr1;
            }
            set
            {
                addr1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return addr2;
            }
            set
            {
                addr2 = value;
            }
        }
        public string Address3
        {
            get
            {
                return addr3;
            }
            set
            {
                addr3 = value;
            }
        }
        public string Address4
        {
            get
            {
                return addr4;
            }
            set
            {
                addr4 = value;
            }
        }
        public string Address5
        {
            get
            {
                return addr5;
            }
            set
            {
                addr5 = value;
            }
        }
        public string Phone1
        {
            get
            {
                return phone1;
            }
            set
            {
                phone1 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Phone3
        {
            get
            {
                return phone3;
            }
            set
            {
                phone3 = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string Marital_Status
        {
            get
            {
                return marital_status;
            }
            set
            {
                marital_status = value;
            }
        }
        public int Occupation_ID
        {
            get
            {
                return occupation_id;
            }
            set
            {
                occupation_id = value;
            }
        }
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }
        public string Passport_No
        {
            get
            {
                return passport_no;
            }
            set
            {
                passport_no = value;
            }
        }
        public string Blood_Group
        {
            get
            {
                return blood_group;
            }
            set
            {
                blood_group = value;
            }
        }
        public string Religeon
        {
            get
            {
                return religeon;
            }
            set
            {
                religeon = value;
            }
        }
        public string Patient_type
        {
            get
            {
                return patient_type;
            }
            set
            {
                patient_type = value;
            }
        }
        public string Em_Contact_Person
        {
            get
            {
                return em_contact_person;
            }
            set
            {
                em_contact_person = value;
            }
        }
        public string Em_Relation
        {
            get
            {
                return em_relation;
            }
            set
            {
                em_relation = value;
            }
        }
        public string Em_Address
        {
            get
            {
                return em_addr;
            }
            set
            {
                em_addr = value;
            }
        }
        public string Em_Phone
        {
            get
            {
                return em_phone;
            }
            set
            {
                em_phone = value;
            }
        }
        public string Insurance_Type
        {
            get
            {
                return insurance_type;
            }
            set
            {
                insurance_type = value;
            }
        }
        public string Insurance_Name
        {
            get
            {
                return insurance_name;
            }
            set
            {
                insurance_name = value;
            }
        }
        public string HL7_Format
        {
            get
            {
                return hl7_format;
            }
            set
            {
                hl7_format = value;
            }
        }
        public string HL7_send
        {
            get
            {
                return hl7_send;
            }
            set
            {
                hl7_send = value;
            }
        }
        public string Allergies
        {
            get
            {
                return allergies;
            }
            set
            {
                allergies = value;
            }
        }
        public int Org_ID
        {
            get
            {
                return org_id;
            }
            set
            {
                org_id = value;
            }
        }
        public int Created_BY
        {
            get
            {
                return created_by;
            }
            set
            {
                created_by = value;
            }
        }
        public DateTime Created_ON
        {
            get
            {
                return created_on;
            }
            set
            {
                created_on = value;
            }
        }
        public int Last_Modified_BY
        {
            get
            {
                return last_modified_by;
            }
            set
            {
                last_modified_by = value;
            }
        }
        public DateTime Last_Modified_ON
        {
            get
            {
                return last_modified_on;
            }
            set
            {
                last_modified_on = value;
            }
        }
        public string REFER_FROM
        {
            get { return refer_from; }
            set { refer_from = value; }

        }
        public string REF_DOC_INSTRUCTION
        {
            get { return ref_doc_instruction; }
            set { ref_doc_instruction = value; }

        }

        public int REF_DOC
        {
            get { return ref_doc; }
            set { ref_doc = value; }
        }
        public int REF_UNIT
        {
            get { return ref_unit; }
            set { ref_unit = value; }
        }
        public string Department_Name
        {
            get { return department_name; }
            set { department_name = value; }
        }
        public string Doctor_Name
        {
            get { return doctor_name; }
            set { doctor_name = value; }
        }
        public int InsuranceID
        {
            get { return insuranceID; }
            set { insuranceID = value; }
        }
        public bool ISAllergy
        {
            get { return is_allergy; }
            set { is_allergy = value; }
        }
        public DataTable AllergyData
        {
            get { return allergyData; }
            set { allergyData = value; }
        }
        public string NON_RESIDENCE
        {
            get { return non_residence; }
            set { non_residence = value; }
        }
        public string PATIENT_ID_LABEL
        {
            get { return patientIDLabel; }
            set { patientIDLabel = value; }
        }
        public string PATIENT_ID_DETAIL
        {
            get { return patientIDDetail; }
            set { patientIDDetail = value; }
        }
        #endregion

        public Patient()
        {
            linkdown = true;
            hasHN = false;
            dataFromHIS = false;
            dataFromLocal = false;
            dataFromManual = true;

            reg_uid = string.Empty;
        }
        public Patient(string HN)
        {
            hasHN = true;
            linkdown = false;
            reg_uid = HN;
            GetData(HN);
        }
        public Patient(string HN, bool getLocal)
        {
            hasHN = true;
            linkdown = false;
            reg_uid = HN;
            if (getLocal)
                GetLocalData(HN);
            else
                GetData(HN);
        }

        public void GetData(string HN)
        {
            try
            {
                GetDataFromHIS(HN);
                if (linkdown)
                {
                    ProcessGetHISRegistration process = new ProcessGetHISRegistration(HN);
                    process.Invoke();
                    if (process.Result != null)
                        FillData(process.Result.Tables[0]);
                    if (!hasHN)
                    {
                        dataFromHIS = false;
                        dataFromLocal = false;
                        dataFromManual = true;
                    }
                    else
                    {

                    }
                    {
                        dataFromHIS = false;
                        dataFromLocal = true;
                        dataFromManual = false;
                    }
                }
                else if (hasHN)
                {
                    dataFromHIS = true;
                    dataFromLocal = false;
                    dataFromManual = false;
                }



            }
            catch (Exception ex)
            {
                this.hasHN = false;
            }
        }

        private void GetDataFromHIS(string hn)
        {
            hasHN = true;
            linkdown = false;

            try
            {
                HIS_Patient p = new HIS_Patient();
                DataSet ds = p.Get_demographic_long(hn);
                
                DataTable dtt = null;
                if (ds != null)
                    if (ds.Tables.Count > 0)
                        dtt = ds.Tables[0].Copy();
                if (dtt == null)
                {
                    hasHN = false;
                    dtt = new DataTable();
                    FillData(dtt);
                }
                else
                {
                    DataSet dsRet = new DataSet();
                    dsRet.Tables.Add(dtt.Copy());
                    dsRet.AcceptChanges();

                    DataSet dsRef;
                    bool flag = true;
                    try
                    {
                        dsRef = p.Get_ipd_detail(hn);
                        if (dsRef != null)
                            if (dsRef.Tables.Count > 0)
                                if (dsRef.Tables[0].Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dsRef.Tables[0].Rows[0]["an"].ToString()))
                                    {
                                        if (!string.IsNullOrEmpty(dsRef.Tables[0].Rows[0]["current_location"].ToString()))
                                        {
                                            dsRet.Tables.Add(dsRef.Tables[0].Copy());
                                            dsRet.AcceptChanges();
                                            flag = false;
                                        }
                                    }
                                }
                    }
                    catch (Exception exIPD)
                    {

                    }

                    DataTable dtall = new DataTable();
                    dtall.Columns.Add("allergies", typeof(string));
                    DataRow drall = dtall.NewRow();
                    try
                    {
                        HIS_Patient HIS_p = new HIS_Patient();
                        DataSet dsHIS = HIS_p.Get_Adr(hn);
                        if (hn.Length > 0)
                        {
                            if (dsHIS.Tables[0].Rows.Count > 0)
                            {
                                dtall.Rows.Add("Y");
                            }
                        }
                    }
                    catch { }
                    dtall.TableName = "allergies";
                    dsRet.Tables.Add(dtall);

                    if (flag)
                    {

                        try
                        {
                            dsRef = new DataSet();
                            dsRef = p.Get_appointment_detail(hn);

                            DataTable dttRef = null;
                            if (dsRef != null)
                                if (dsRef.Tables.Count > 0)
                                    if (dsRef.Tables[0].Rows.Count > 0)
                                        dsRet.Tables.Add(dsRef.Tables[0].Copy());
                            dsRet.AcceptChanges();
                        }
                        catch (Exception exRef)
                        {

                        }
                    }

                    if (Utilities.IsHaveData(dsRet))
                    {
                        if (!dsRet.Tables[0].Columns.Contains("PatientIdentificationLabel"))
                            dsRet.Tables[0].Columns.Add("PatientIdentificationLabel");
                        if (!dsRet.Tables[0].Columns.Contains("PatientIdentificationDetail"))
                            dsRet.Tables[0].Columns.Add("PatientIdentificationDetail");
                        if (!dsRet.Tables[0].Columns.Contains("is_foreign"))
                            dsRet.Tables[0].Columns.Add("is_foreign");
                        dsRet.AcceptChanges();
                        DateTime dateEntry = DateTime.Now;
                        DataSet dsCheckNonResident = new DataSet();
                        try
                        {
                            if (dsRet.Tables.IndexOf("appoint_detail") > 0)
                                dateEntry = Convert.ToDateTime(dsRet.Tables[dsRet.Tables.IndexOf("appoint_detail")].Rows[0]["appt_date"]);
                            else if (dsRet.Tables.IndexOf("ipd_detail") > 0)
                                dateEntry = Convert.ToDateTime(dsRet.Tables[dsRet.Tables.IndexOf("ipd_detail")].Rows[0]["admission_date"]);

                            dsCheckNonResident = p.GetEncounterDetailByMRNDATE(hn, dateEntry.ToString("dd/MM/yyyy"));
                            //dsCheckNonResident = p.GetEncounterDetailByMRNENCTYPE(hn, "ALL");
                            dsRet.Tables.Add(dsCheckNonResident.Tables[0].Copy());
                            dsRet.AcceptChanges();

                            DataSet dsPatID = p.searchPatientIdentificationByMRNandActiveDate(hn, DateTime.Now.ToString("dd/MM/yyyy"));
                            if (Utilities.IsHaveData(dsPatID))
                            {
                                dsRet.Tables[0].Rows[0]["PatientIdentificationLabel"] = dsPatID.Tables[0].Rows[0]["PatientIdentificationLabel"].ToString();
                                dsRet.Tables[0].Rows[0]["PatientIdentificationDetail"] = dsPatID.Tables[0].Rows[0]["PatientIdentificationDetail"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        DataSet dsInsurance = new DataSet();
                        //Check Non-Resident

                        if (Utilities.IsHaveData(dsCheckNonResident))
                        {
                            DataView view = dsCheckNonResident.Tables[0].DefaultView;
                            view.Sort = "object_id DESC";
                            DataTable dtSort = view.ToTable();

                            dsInsurance = p.GetEligibilityInsuranceDetail(hn
                                , dtSort.Rows[0]["enc_type"].ToString()
                                , dtSort.Rows[0]["enc_id"].ToString()
                                , dtSort.Rows[0]["sdloc_id"].ToString()
                                , DateTime.Now.ToString("dd/MM/yyyy")// Convert.ToDateTime(dsCheckNonResident.Tables[0].Rows[0]["effectivestartdate"]).ToString("dd/MM/yyyy")
                                , "RGL");
                        }
                        else
                        {
                           
                            dsCheckNonResident = p.GetEncounterDetailByMRNENCTYPE(hn, "ALL");
                            if (Utilities.IsHaveData(dsCheckNonResident))
                            {
                                DateTime dt = DateTime.ParseExact(dsCheckNonResident.Tables[0].Rows[0]["effectivestartdate"].ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                                dsInsurance = p.GetEligibilityInsuranceDetail(hn
                                   , dsCheckNonResident.Tables[0].Rows[0]["enc_type"].ToString()
                                   , dsCheckNonResident.Tables[0].Rows[0]["enc_id"].ToString()
                                   , dsCheckNonResident.Tables[0].Rows[0]["sdloc_id"].ToString()
                                   , dt.ToString("dd/MM/yyyy")
                                   , "RGL");
                            }
                            else
                            {
                                dsInsurance = p.GetEligibilityInsuranceDetail(hn
                                    , ""
                                    , ""
                                    , ""
                                    , ""
                                    , "RGL");
                            }
                        }
                        if(dsRet.Tables[0].Rows[0]["nonresidence"].ToString() == "non-resident(v)")
                        {
                            if(dsInsurance.Tables[0].Rows[0]["insurance_name"].ToString() == "")
                                dsRet.Tables[0].Rows[0]["is_foreign"] = "Y";
                            else
                                dsRet.Tables[0].Rows[0]["is_foreign"] = "N";
                        }

                        #region Insurance Type.
                        try
                        {
                            DataTable dttInsurance = null;
                            if (dsInsurance != null)
                                if (dsInsurance.Tables.Count > 0)
                                {
                                    dttInsurance = dsInsurance.Tables[0].Copy();
                                    DataTable dttTmp = RISBaseData.Ris_InsuranceType();
                                    //DataRow[] row = dttTmp.Select("INSURANCE_TYPE_UID ='" + dttInsurance.Rows[0]["policy_no"].ToString() + "'");
                                    DataRow[] row = dttTmp.Select("INSURANCE_TYPE_UID ='" + dttInsurance.Rows[0]["insurance"].ToString().Trim() + "' and INSURANCE_TYPE_DESC = '" + dttInsurance.Rows[0]["insurance_name"].ToString().Trim() + "'");
                                    if (row.Length == 0)
                                    {
                                        //insert
                                        ProcessAddRISInsurancetype procINS = new ProcessAddRISInsurancetype();
                                        procINS.RIS_INSURANCETYPE.CREATED_BY = new GBLEnvVariable().UserID;
                                        procINS.RIS_INSURANCETYPE.INSURANCE_TYPE_DESC = dttInsurance.Rows[0]["insurance_name"].ToString();
                                        procINS.RIS_INSURANCETYPE.INSURANCE_TYPE_UID = dttInsurance.Rows[0]["insurance"].ToString();
                                        procINS.RIS_INSURANCETYPE.ORG_ID = new GBLEnvVariable().OrgID;
                                        procINS.Invoke();
                                        //
                                        dttTmp = RISBaseData.Ris_InsuranceType();
                                        row = dttTmp.Select("INSURANCE_TYPE_UID ='" + dttInsurance.Rows[0]["insurance"].ToString().Trim() + "' and INSURANCE_TYPE_DESC = '" + dttInsurance.Rows[0]["insurance_name"].ToString().Trim() + "'");
                                        if (row.Length > 0)
                                            insuranceID = Convert.ToInt32(row[0]["INSURANCE_TYPE_ID"]);
                                    }
                                    else
                                        insuranceID = Convert.ToInt32(row[0]["INSURANCE_TYPE_ID"]);
                                }
                            dsRet.Tables.Add(dttInsurance.Copy());
                            dsRet.AcceptChanges();

                        }
                        catch (Exception exIns)
                        {

                        }
                        #endregion
                    }


                    FillData(dsRet);
                    HasEngName = true;

                    ProcessGetHISRegistration process = new ProcessGetHISRegistration(hn);
                    process.Invoke();
                    if (process.Result != null)
                        if (process.Result.Tables.Count > 0)
                            if (process.Result.Tables[0].Rows.Count > 0)
                            {
                                if (this.fname_eng.Trim().Length == 0)
                                    this.fname_eng = process.Result.Tables[0].Rows[0]["FNAME_ENG"].ToString();

                                if (this.lname_eng.Trim().Length == 0)
                                    this.lname_eng = process.Result.Tables[0].Rows[0]["LNAME_ENG"].ToString();
                                if (this.phone1.Trim().Length == 0)
                                    this.phone1 = process.Result.Tables[0].Rows[0]["PHONE1"].ToString();
                            }

                    if (this.fname_eng.Trim().Length == 0)
                    {
                        HasEngName = false;
                        this.fname_eng = string.IsNullOrEmpty(fname_eng) ? TransToEnglish.Trans(fname) : fname_eng;
                    }
                    if (this.lname_eng.Trim().Length == 0)
                    {
                        HasEngName = false;
                        this.lname_eng = string.IsNullOrEmpty(lname_eng) ? TransToEnglish.Trans(lname) : lname_eng;
                    }

                   
                }
            }
            catch (Exception exe)
            {
                linkdown = true;
                hasHN = false;

                //Utilities.LogException(exe);
            }
        }
        private void GetLocalData(string HN)
        {
            ProcessGetHISRegistration process = new ProcessGetHISRegistration(HN);
            process.Invoke();
            if (process.Result != null)
                FillData(process.Result.Tables[0]);
            dataFromLocal = true;
            dataFromHIS = false;
            dataFromManual = false;
        }

        private void FillData(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                #region ไม่พบข้อมูล
                reg_id = 0;
                reg_uid = string.Empty;
                title = string.Empty;
                fname = string.Empty;
                mname = string.Empty;
                lname = string.Empty;
                title_eng = string.Empty;
                fname_eng = string.Empty;
                mname_eng = string.Empty;
                lname_eng = string.Empty;
                ssn = string.Empty;
                age = 0;
                dob = DateTime.Today;
                addr1 = addr2 = addr3 = addr4 = addr5 = string.Empty;
                phone1 = phone2 = phone3 = string.Empty;
                em_addr = string.Empty;
                gender = string.Empty;
                marital_status = string.Empty;
                occupation_id = 0;
                nationality = string.Empty;
                passport_no = string.Empty;
                blood_group = string.Empty;
                religeon = string.Empty;
                patient_type = string.Empty;
                em_addr = string.Empty;
                em_contact_person = string.Empty;
                em_phone = string.Empty;
                em_relation = string.Empty;
                insurance_type = string.Empty;
                hl7_format = string.Empty;
                hl7_send = string.Empty;
                allergies = string.Empty;
                org_id = 0;
                created_by = 0;
                created_on = DateTime.Today;
                last_modified_by = 0;
                last_modified_on = DateTime.Today;
                hasHN = false;

                #endregion
            }
            else
            {

                #region FillData from HIS_REGISTRATIION
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["REG_ID"].ToString() != string.Empty)
                        reg_id = Convert.ToInt32(dr["REG_ID"]);
                    if (dr["HN"].ToString() != string.Empty)
                        reg_uid = dr["HN"].ToString();
                    if (dr["TITLE"].ToString() != string.Empty)
                        title = dr["TITLE"].ToString();
                    if (dr["REG_DT"].ToString() != string.Empty)
                        reg_dt = Convert.ToDateTime(dr["REG_DT"]);
                    if (dr["FNAME"].ToString() != string.Empty)
                        fname = dr["FNAME"].ToString();
                    if (dr["MNAME"].ToString() != string.Empty)
                        mname = dr["MNAME"].ToString();
                    if (dr["LNAME"].ToString() != string.Empty)
                        lname = dr["LNAME"].ToString();
                    if (dr["TITLE_ENG"].ToString().Trim() != string.Empty)
                        title_eng = dr["TITLE_ENG"].ToString();
                    else
                        title_eng = TransToEnglish.Trans(title);

                    if (dr["FNAME_ENG"].ToString().Trim() != string.Empty)
                        fname_eng = dr["FNAME_ENG"].ToString();
                    else
                        fname_eng = TransToEnglish.Trans(fname);
                    if (dr["MNAME_ENG"].ToString().Trim() != string.Empty)
                        mname_eng = dr["MNAME_ENG"].ToString();
                    else
                        mname_eng = TransToEnglish.Trans(mname);
                    if (dr["LNAME_ENG"].ToString().Trim() != string.Empty)
                        lname_eng = dr["LNAME_ENG"].ToString();
                    else
                        lname_eng = TransToEnglish.Trans(lname);

                    if (dr["SSN"].ToString() != string.Empty)
                        ssn = dr["SSN"].ToString();
                    if (dr["DOB"].ToString() != string.Empty)
                        dob = Convert.ToDateTime(dr["DOB"]);
                    if (dr["AGE"].ToString() != string.Empty)
                        age = Convert.ToInt32(dr["AGE"]);
                    if (dr["ADDR1"].ToString() != string.Empty)
                        addr1 = dr["ADDR1"].ToString();
                    if (dr["ADDR2"].ToString() != string.Empty)
                        addr2 = dr["ADDR2"].ToString();
                    if (dr["ADDR3"].ToString() != string.Empty)
                        addr3 = dr["ADDR3"].ToString();
                    if (dr["ADDR4"].ToString() != string.Empty)
                        addr4 = dr["ADDR4"].ToString();
                    if (dr["ADDR5"].ToString() != string.Empty)
                        addr5 = dr["ADDR5"].ToString();
                    if (dr["PHONE1"].ToString() != string.Empty)
                        phone1 = dr["PHONE1"].ToString();
                    if (dr["PHONE2"].ToString() != string.Empty)
                        phone2 = dr["PHONE2"].ToString();
                    if (dr["PHONE3"].ToString() != string.Empty)
                        phone3 = dr["PHONE3"].ToString();
                    if (dr["EMAIL"].ToString() != string.Empty)
                        email = dr["EMAIL"].ToString();
                    if (dr["GENDER"].ToString() != string.Empty)
                        gender = dr["GENDER"].ToString();
                    if (dr["MARITAL_STATUS"].ToString() != string.Empty)
                        marital_status = dr["MARITAL_STATUS"].ToString();
                    if (dr["OCCUPATION_ID"].ToString() != string.Empty)
                        occupation_id = Convert.ToInt32(dr["OCCUPATION_ID"]);
                    if (dr["NATIONALITY"].ToString() != string.Empty)
                        nationality = dr["NATIONALITY"].ToString();
                    if (dr["PASSPORT_NO"].ToString() != string.Empty)
                        passport_no = dr["PASSPORT_NO"].ToString();
                    if (dr["BLOOD_GROUP"].ToString() != string.Empty)
                        blood_group = dr["BLOOD_GROUP"].ToString();
                    if (dr["RELIGION"].ToString() != string.Empty)
                        religeon = dr["RELIGION"].ToString();//RELIGEON
                    if (dr["PATIENT_TYPE"].ToString() != string.Empty)
                        patient_type = dr["PATIENT_TYPE"].ToString();
                    if (dr["EM_CONTACT_PERSON"].ToString() != string.Empty)
                        em_contact_person = dr["EM_CONTACT_PERSON"].ToString();
                    if (dr["EM_RELATION"].ToString() != string.Empty)
                        em_relation = dr["EM_RELATION"].ToString();
                    if (dr["EM_ADDR"].ToString() != string.Empty)
                        em_addr = dr["EM_ADDR"].ToString();
                    if (dr["EM_PHONE"].ToString() != string.Empty)
                        em_phone = dr["EM_PHONE"].ToString();
                    if (dr["INSURANCE_TYPE"].ToString() != string.Empty)
                        insurance_type = dr["INSURANCE_TYPE"].ToString();
                    if (dr["HL7_FORMAT"].ToString() != string.Empty)
                        hl7_format = dr["HL7_FORMAT"].ToString();
                    if (dr["HL7_SEND"].ToString() != string.Empty)
                        hl7_send = dr["HL7_SEND"].ToString();
                    if (dr["ALLERGIES"].ToString() != string.Empty)
                        allergies = dr["ALLERGIES"].ToString();
                    if (dr["ORG_ID"].ToString() != string.Empty)
                        org_id = Convert.ToInt32(dr["ORG_ID"]);
                    if (dr["CREATED_BY"].ToString() != string.Empty)
                        created_by = Convert.ToInt32(dr["CREATED_BY"]);
                    if (dr["CREATED_ON"].ToString() != string.Empty)
                        created_on = Convert.ToDateTime(dr["CREATED_ON"]);
                    if (dr["LAST_MODIFIED_BY"].ToString() != string.Empty)
                        last_modified_by = Convert.ToInt32(dr["LAST_MODIFIED_BY"]);
                    if (dr["LAST_MODIFIED_ON"].ToString() != string.Empty)
                        last_modified_on = Convert.ToDateTime(dr["LAST_MODIFIED_ON"]);
                    non_residence = dr["IS_FOREIGNER"].ToString() == "Y" ? "Y" : "N";
                    patientIDDetail = string.IsNullOrEmpty(dr["PATIENT_ID_DETAIL"].ToString()) ? string.Empty : dr["PATIENT_ID_DETAIL"].ToString();
                    patientIDLabel = string.IsNullOrEmpty(dr["PATIENT_ID_LABEL"].ToString()) ? string.Empty : dr["PATIENT_ID_LABEL"].ToString();
                    hasHN = true;
                    title_eng = title_eng.Trim();
                    fname_eng = fname_eng.Trim();
                    mname_eng = mname_eng.Trim();
                    lname_eng = lname_eng.Trim();
                    string s = string.Empty;
                    if (title_eng.Length > 0)
                    {
                        s = title_eng[0].ToString();
                        title_eng = title_eng.Substring(1);
                        title_eng = s.ToUpper() + title_eng;
                    }
                    if (fname_eng.Length > 0)
                    {
                        s = fname_eng[0].ToString();
                        fname_eng = fname_eng.Substring(1);
                        fname_eng = s.ToUpper() + fname_eng;
                    }
                    if (mname_eng.Length > 0)
                    {
                        s = mname_eng[0].ToString();
                        mname_eng = mname_eng.Substring(1);
                        mname_eng = s.ToUpper() + mname_eng;
                    }
                    if (lname_eng.Length > 0)
                    {
                        s = lname_eng[0].ToString();
                        lname_eng = lname_eng.Substring(1);
                        lname_eng = s.ToUpper() + lname_eng;
                    }
                    insurance_type = "11";
                }
                #endregion
            }
        }
        private void FillData(DataSet ds)
        {
            DataRow dr = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                reg_id = 0;
                dob = dr["dob"].ToString().Trim() == string.Empty || dr["dob"].ToString() == null ? DateTime.MinValue : Convert.ToDateTime(dr["dob"]);

                //title = dr["initial_name"].ToString().Trim();
                //if (string.IsNullOrEmpty(dr["first_name"].ToString().Trim()))
                //{
                //    if (string.IsNullOrEmpty(dr["first_name_eng"].ToString().Trim()))
                //        fname = "Anonymous";
                //    else
                //        fname = dr["first_name_eng"].ToString().Trim();
                //}
                //else
                //    fname = dr["first_name"].ToString().Trim();
                //mname = string.Empty;
                //if (string.IsNullOrEmpty(dr["last_name"].ToString().Trim()))
                //{
                //    if (string.IsNullOrEmpty(dr["last_name_eng"].ToString().Trim()))
                //        lname = "Anonymous";
                //    else
                //        lname = dr["last_name_eng"].ToString().Trim();
                //}
                //else
                //    lname = dr["last_name"].ToString().Trim();

                ////title_eng = TransToEnglish.Trans(title);
                //title_eng = string.Empty;
                //fname_eng = TransToEnglish.Trans(fname);
                //mname_eng = dr["middle_name_eng"].ToString();
                //lname_eng = TransToEnglish.Trans(lname);

                title = dr["initial_name"].ToString().Trim();
                title_eng = dr["initial_name_eng"].ToString().Trim();
                fname = dr["first_name"].ToString().Trim();
                mname = string.Empty;
                lname = dr["last_name"].ToString().Trim();
                fname_eng = dr["first_name_eng"].ToString().Trim();
                mname_eng = dr["middle_name_eng"].ToString().Trim();
                lname_eng = dr["last_name_eng"].ToString().Trim();


                fname = string.IsNullOrEmpty(fname) ? string.IsNullOrEmpty(fname_eng) ? "Anonymous" : fname_eng : fname;
                lname = string.IsNullOrEmpty(lname) ? string.IsNullOrEmpty(lname_eng) ? "Anonymous" : lname_eng : lname;
                //fname_eng = string.IsNullOrEmpty(fname_eng) ? TransToEnglish.Trans(fname) : fname_eng;
                //lname_eng = string.IsNullOrEmpty(lname_eng) ? TransToEnglish.Trans(lname) : lname_eng;

                ssn = dr["id_card_no"].ToString();
                age = 0;

                addr1 = dr["address"].ToString().Trim() == string.Empty || dr["address"].ToString().Trim() == null ? string.Empty : dr["address"].ToString().Trim();
                addr2 = dr["amphur"].ToString();
                addr3 = dr["province"].ToString();
                addr4 = dr["zipcode"].ToString();
                addr5 = string.Empty;

                phone1 = String.IsNullOrEmpty(dr["home_tel"].ToString()) ? string.Empty : dr["home_tel"].ToString().Trim();
                phone2 = dr["office_tel"].ToString();
                phone3 = dr["mobile_no"].ToString();

                em_addr = dr["email"].ToString();
                gender = dr["gender"].ToString();

                if (ds.Tables["allergies"].Rows.Count > 0)
                {
                    DataRow drall = ds.Tables["allergies"].Rows[0];
                    if (drall["allergies"].ToString() == "Y")
                    {
                        allergies = "Y";
                    }
                    else
                        allergies = string.Empty;

                }
                else
                {
                    allergies = string.Empty;
                }

                nationality = dr["nationality_code"].ToString();
                em_contact_person = dr["emergency_contact"].ToString();

                non_residence = dr["is_foreign"].ToString() == "Y" ? "Y" : "N";
                patientIDLabel = string.IsNullOrEmpty(dr["PatientIdentificationLabel"].ToString()) ? "" : dr["PatientIdentificationLabel"].ToString();
                patientIDDetail = string.IsNullOrEmpty(dr["PatientIdentificationDetail"].ToString()) ? "" : dr["PatientIdentificationDetail"].ToString();

                int id = ds.Tables.IndexOf("insurance_detail");
                if (id > -1)
                {
                    DataTable dtIns = ds.Tables[id].Copy();
                    if (dtIns.Rows.Count > 0)
                    {
                        //insurance_type = dtIns.Rows[0]["policy_no"].ToString().Trim();
                        insurance_type = dtIns.Rows[0]["insurance"].ToString().Trim();
                        insurance_name = dtIns.Rows[0]["insurance_name"].ToString().Trim();
                    }
                }
                if (ds.Tables.IndexOf("ipd_detail") >= 0)
                {
                    id = ds.Tables.IndexOf("ipd_detail");
                    setUnitDoctorByIPD(ds.Tables[id].Copy());
                }
                else if (ds.Tables.IndexOf("appoint_detail") >= 0)
                {
                    id = ds.Tables.IndexOf("appoint_detail");
                    DataTable dtRef = ds.Tables[id].Copy();
                    DataTable dttTime = new DataTable();
                    dttTime.Columns.Add("row", typeof(int));
                    dttTime.Columns.Add("appt_date", typeof(DateTime));
                    dttTime.Columns.Add("appt_time", typeof(string));
                    int i = -1;
                    if (dtRef.Rows.Count > 0)
                    {
                        #region seach unit and doctor sent to x-ray.
                        DateTime dt = DateTime.Today;
                        try
                        {
                            for (i = 0; i < dtRef.Rows.Count; i++)
                            {
                                #region search today.
                                DateTime dtTemp = Convert.ToDateTime(dtRef.Rows[i]["appt_date"]);
                                if (dtTemp == dt)
                                {
                                    DataRow drTime = dttTime.NewRow();
                                    drTime["row"] = i;
                                    drTime["appt_date"] = dtRef.Rows[i]["appt_date"];
                                    drTime["appt_time"] = dtRef.Rows[i]["appt_time"];
                                    dttTime.Rows.Add(drTime);
                                    dttTime.AcceptChanges();
                                    break;
                                }
                                #endregion
                            }
                            if (dttTime.Rows.Count > 0)
                            {
                                #region found in day.
                                i = 0;
                                if (dttTime.Rows.Count > 1)
                                {
                                    DateTime dtnow = DateTime.Now;
                                    for (int j = 0; j < dttTime.Rows.Count; j++)
                                    {
                                        DateTime dtDs = Convert.ToDateTime(dttTime.Rows[j]["appt_date"]);
                                        string[] str = dttTime.Rows[j]["appt_time"].ToString().Split(':');
                                        int hour = Convert.ToInt32(str[0]);
                                        int miniute = Convert.ToInt32(str[1]);
                                        dtDs = new DateTime(dtDs.Year, dtDs.Month, dtDs.Day, hour, miniute, 0);
                                        if (dtnow == dtDs)
                                        {
                                            i = Convert.ToInt32(dttTime.Rows[j]["row"]);
                                            break;
                                        }
                                    }


                                    i = i < 0 ? 0 : i;
                                }
                                #endregion
                            }
                            else
                            {
                                #region found another day.
                                for (i = 0; i < dtRef.Rows.Count; i++)
                                {
                                    DateTime dtDsFound = Convert.ToDateTime(dtRef.Rows[i]["appt_date"]);
                                    if (dtDsFound > dt)
                                        break;
                                }
                                i = i == dtRef.Rows.Count ? i - 1 : i;
                                #endregion
                            }
                        }
                        catch
                        {
                            i = -1;
                        }
                        #endregion
                        if (i > -1)
                        {

                            ProcessGetHRUnit processDep = new ProcessGetHRUnit();
                            processDep.Invoke();
                            DataTable dttDept = processDep.Result.Tables[0].Copy();
                            DataRow[] drr = dttDept.Select("UNIT_UID='" + ds.Tables[id].Rows[i]["appt_doc_dept_code"].ToString() + "'");
                            if (drr.Length > 0)
                                ref_unit = Convert.ToInt32(drr[0]["UNIT_ID"]);
                            else
                                insertHR_UNIT(ds.Tables[id].Rows[i]["appt_doc_dept_code"].ToString());

                            ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
                            processDoctor.Invoke();
                            dttDept = processDoctor.Result.Tables[0].Copy();
                            drr = dttDept.Select("EMP_UID='" + ds.Tables[id].Rows[i]["appt_doc_code"].ToString() + "'");
                            if (drr.Length > 0)
                                ref_doc = Convert.ToInt32(drr[0]["EMP_ID"]);
                            else
                                insertHR_EMP(ds.Tables[id].Rows[i]["appt_doc_code"].ToString(), ds.Tables[id].Rows[i]["appt_doc_name"].ToString());
                        }
                    }
                }
                else
                {
                    id = ds.Tables.IndexOf("encounter_detail");
                    DataView view = ds.Tables[id].DefaultView;
                    view.Sort = "object_id DESC";
                    DataTable dtSort = view.ToTable();

                    if (dtSort.Rows.Count > 0)
                    {
                        ProcessGetHRUnit processDep = new ProcessGetHRUnit();
                        processDep.Invoke();
                        DataTable dttDept = processDep.Result.Tables[0].Copy();
                        DataRow[] drr = dttDept.Select("UNIT_UID='" + dtSort.Rows[0]["sdloc_id"].ToString() + "'");
                        if (drr.Length > 0)
                            ref_unit = Convert.ToInt32(drr[0]["UNIT_ID"]);
                        else
                            insertHR_UNIT(ds.Tables[id].Rows[0]["sdloc_id"].ToString());
                    }
                }

                marital_status = string.Empty;
                occupation_id = 0;

                passport_no = string.Empty;
                blood_group = string.Empty;
                religeon = string.Empty;
                patient_type = string.Empty;
                em_addr = string.Empty;

                em_phone = string.Empty;
                em_relation = string.Empty;
                hl7_format = string.Empty;
                hl7_send = string.Empty;
                //allergies = string.Empty;
                org_id = 0;
                created_by = 0;
                created_on = DateTime.Today;
                last_modified_by = 0;
                last_modified_on = DateTime.MinValue;
                hasHN = true;
                title_eng = title_eng.Trim();
                fname_eng = fname_eng.Trim();
                mname_eng = mname_eng.Trim();
                lname_eng = lname_eng.Trim();
                string s = string.Empty;
                if (title_eng.Length > 0)
                {
                    s = title_eng[0].ToString();
                    title_eng = title_eng.Substring(1);
                    title_eng = s.ToUpper() + title_eng;
                }
                if (fname_eng.Length > 0)
                {
                    s = fname_eng[0].ToString();
                    fname_eng = fname_eng.Substring(1);
                    fname_eng = s.ToUpper() + fname_eng;
                }
                if (mname_eng.Length > 0)
                {
                    s = mname_eng[0].ToString();
                    mname_eng = mname_eng.Substring(1);
                    mname_eng = s.ToUpper() + mname_eng;
                }
                if (lname_eng.Length > 0)
                {
                    s = lname_eng[0].ToString();
                    lname_eng = lname_eng.Substring(1);
                    lname_eng = s.ToUpper() + lname_eng;
                }
            }
            
            else hasHN = false;
        }
        private void setUnitDoctorByIPD(DataTable dtt)
        {

            ProcessGetHRUnit processDep = new ProcessGetHRUnit();
            processDep.Invoke();
            DataTable dttDept = processDep.Result.Tables[0].Copy();
            DataRow[] drr = dttDept.Select("UNIT_UID='" + dtt.Rows[0]["current_location"].ToString().Trim() + "'");
            if (drr.Length > 0)
                ref_unit = Convert.ToInt32(drr[0]["UNIT_ID"]);
            else
            {
                string hrID = string.IsNullOrEmpty(dtt.Rows[0]["current_location"].ToString()) ? dtt.Rows[0]["primary_location"].ToString() : dtt.Rows[0]["current_location"].ToString();
                insertHR_UNIT(hrID);
            }
            if (!string.IsNullOrEmpty(dtt.Rows[0]["attending_doc_code"].ToString()))
            {
                ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
                processDoctor.Invoke();
                dttDept = processDoctor.Result.Tables[0].Copy();
                drr = dttDept.Select("EMP_UID='" + dtt.Rows[0]["attending_doc_code"].ToString() + "'");
                if (drr.Length > 0)
                    ref_doc = Convert.ToInt32(drr[0]["EMP_ID"]);
                else
                {
                    insertHR_EMP(dtt.Rows[0]["attending_doc_code"].ToString(), dtt.Rows[0]["attending_doc_name"].ToString().Trim());

                }
            }
        }
        private void insertHR_UNIT(string ID)
        {
            try
            {
                GBLEnvVariable env = new GBLEnvVariable();
                HIS_Patient his = new HIS_Patient();
                DataSet dtHIS = his.Get_sdloc_detail(ID);
                if (dtHIS != null)
                    if (dtHIS.Tables.Count > 0)
                    {
                        ProcessAddHRUnit proHR = new ProcessAddHRUnit();
                        proHR.HR_UNIT.CREATED_BY = env.UserID;
                        proHR.HR_UNIT.DESCR = dtHIS.Tables[0].Rows[0]["desc"].ToString();
                        proHR.HR_UNIT.ORG_ID = env.OrgID;
                        proHR.HR_UNIT.PHONE_NO = dtHIS.Tables[0].Rows[0]["tel1"].ToString();
                        proHR.HR_UNIT.UNIT_ALIAS = string.Empty;
                        proHR.HR_UNIT.UNIT_ID = 0;
                        proHR.HR_UNIT.UNIT_ID_PARENT = 0;
                        proHR.HR_UNIT.UNIT_INS = string.Empty;
                        proHR.HR_UNIT.UNIT_NAME = dtHIS.Tables[0].Rows[0]["sdlocname"].ToString();
                        proHR.HR_UNIT.UNIT_NAME_ALIAS = string.Empty;
                        proHR.HR_UNIT.UNIT_UID = dtHIS.Tables[0].Rows[0]["sdlocid"].ToString();
                        proHR.Invoke();
                        ref_unit = proHR.HR_UNIT.UNIT_ID;
                    }
            }
            catch { }
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
                ref_doc = proEMP.HR_EMP.EMP_ID;
            }
            catch { }
        }
        public bool LinkDown
        {
            get { return linkdown; }

        }
        public bool HasHN
        {
            get { return hasHN; }
        }
        public bool DataFromHIS
        {
            get { return dataFromHIS; }
            set { dataFromHIS = value; }
        }
        public bool DataFromLocal
        {
            get { return dataFromLocal; }
            set { dataFromLocal = value; }
        }
        public bool DataFromManual
        {
            get { return dataFromManual; }
            set { dataFromManual = value; }
        }
        public bool HasEngName { get; set; }

        public PatientHL7 ConvertToPatientHL7()
        {
            GBLEnvVariable env = new GBLEnvVariable();
            PatientHL7 p = new PatientHL7();
            p.Address = this.addr1;
            p.DateOfBirth = this.dob;
            p.DepartmentName = this.department_name;
            p.DoctorName = this.doctor_name;
            p.FirstEnglishName = this.fname_eng;
            p.FirstThaiName = this.fname;
            p.Gender = this.gender;
            p.HN = this.reg_uid;
            p.LastEnglishame = this.lname_eng;
            p.LastThaiName = this.lname;
            p.MiddleEnglishName = this.mname_eng;
            p.MiddleThaiName = this.mname;
            p.OperatorName = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
            p.Phone = this.phone1;
            return p;
        }
    }
    public class HIS_Patient
    {
        private Service proxy;

        public HIS_Patient()
        {
            proxy = new Service();
        }

        #region Get Method.

        public DataSet Get_demographic_long(string hn)
        {
            DataSet ds = proxy.Get_demographic_long(hn);
            if (Utilities.IsHaveData(ds))
                if (Utilities.IsHaveData(ds.Tables[0]))
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["effectiveenddate"].ToString()))
                        if (Convert.ToDateTime(ds.Tables[0].Rows[0]["effectiveenddate"]).CompareTo(DateTime.Now) < 0)
                            MessageBox.Show("HN นี้ถูกยกเลิก กรุณาติดต่อหน่วยเวชรเบียน", "แจ้งเตือน", MessageBoxButtons.OK);
            return ds;
        }
        public DataSet Get_demographic_long_outsidepatient(string DeptCode, string refMrn)
        {
            return proxy.Get_demographic_long_outsidepatient(DeptCode, refMrn);
        }
        public DataSet Get_demographic_short(string hn)
        {
            return proxy.Get_demographic_short(hn);
        }
        public DataSet Get_demographic_shortByName(string cName)
        {
            return proxy.Get_demographic_shortByName(cName.Trim());
        }
        public DataSet Get_ForeignDemographic(string pFHn)
        {
            return proxy.Get_ForeignDemographic(pFHn.Trim());
        }
        public DataSet Get_Adr(string hn)
        {
            return proxy.Get_Adr(hn.Trim());
        }
        public DataSet Get_ipd_detail(string hn)
        {
            return proxy.Get_ipd_detail(hn.Trim());

        }

        //public DataSet Get_appointment(string hn)
        //{
        //    return proxy.Get_appointment(hn.ToUpper().Trim());
        //}
        public DataSet Get_appointment_detail(string hn)
        {
            return proxy.Get_appointment_detail(hn.ToUpper().Trim());
        }

        public DataSet Get_Claim_Amt(string hn, string accession_No)
        {
            return proxy.Get_Claim_Amt(hn.ToUpper().Trim(), accession_No.ToUpper().Trim());
        }
        //public DataSet Get_insurance_detail(string hn)
        //{
        //    return proxy.Get_insurance_detail(hn.ToUpper().Trim());
        //}

        public DataSet Get_ForeignXrayOrder(string pFHn)
        {
            return proxy.Get_ForeignXrayOrder(pFHn.ToUpper().Trim());
        }

        public DataSet Get_Lab_order(string hn)
        {
            return proxy.Get_Lab_order(hn.ToUpper().Trim());
        }
        public DataSet Get_Lab_OrderFull(string pHn)
        {
            return proxy.Get_Lab_OrderFull(pHn);
        }
        public DataSet Get_Lab_OrderRegisted(string pHn)
        {
            return proxy.Get_Lab_OrderRegisted(pHn);
        }
        public DataSet Get_lab_data(string hn)
        {
            return proxy.Get_lab_data(hn.ToUpper().Trim());
        }
        public DataSet Get_lab_data_researchall(string pHn)
        {
            return proxy.Get_lab_data_researchall(pHn);
        }
        public DataSet Get_lab_data_researchbydate(string pHn, string pStartDate, string pEndDate)
        {
            return proxy.Get_lab_data_researchbydate(pHn, pStartDate, pEndDate);
        }
        //public DataSet Get_lab_datachem_outside(string pReqname)
        //{
        //    return proxy.Get_lab_datachem_outside(pReqname);
        //}
        //public DataSet Get_lab_datahemato_outside(string pReqname)
        //{
        //    return proxy.Get_lab_datahemato_outside(pReqname);
        //}
        //public DataSet Get_lab_dataimmuno_outside(string pReqname)
        //{
        //    return proxy.Get_lab_dataimmuno_outside(pReqname);
        //}
        //public DataSet Get_lab_dataua_outside(string pReqname)
        //{
        //    return proxy.Get_lab_dataua_outside(pReqname);
        //}
        //public DataSet Get_lab_datavirus_outside(string pReqname)
        //{
        //    return proxy.Get_lab_datavirus_outside(pReqname);
        //}

        public DataSet Get_MedPatient(string hn, string an)
        {
            return proxy.Get_MedPatient(hn.ToUpper().Trim(), an.ToUpper().Trim());
        }

        public DataSet Get_Payment_Status(string hn, string an, string accNo)
        {
            return proxy.Get_Payment_Status(hn.ToUpper().Trim(), an.ToUpper().Trim(), accNo.ToUpper().Trim());
        }
        public DataSet Get_payment_status_outsidepatient(string refMrn, string accession_No, string dept_Code)
        {
            return proxy.Get_payment_status_outsidepatient(refMrn.ToUpper().Trim(), accession_No.ToUpper().Trim(), dept_Code.ToUpper().Trim());
        }

        public DataSet Get_XrayOrder(string pHn)
        {
            return proxy.Get_XrayOrder(pHn.ToUpper().Trim());
        }

        public DataSet Get_all_exam(string exam_code)
        {
            return proxy.Get_all_exam(exam_code.ToUpper().Trim());
        }

        public DataSet Get_Org_detail(string pOrgID)
        {
            return proxy.Get_Org_detail(pOrgID);
        }


        public DataSet Get_Place_detail(string pPlaceID)
        {
            return proxy.Get_Place_detail(pPlaceID);
        }

        public DataSet Get_sdloc_all()
        {
            return proxy.Get_sdloc_all();
        }
        public DataSet Get_sdloc_detail(string pSrc)
        {
            return proxy.Get_sdloc_detail(pSrc);
        }

        public DataSet Get_staff_detail(string user_id, string password_id)
        {
            return proxy.Get_staff_detail(user_id, password_id);
        }
        public DataSet Get_staff_fulldetail(string sCode)
        {
            return proxy.Get_staff_fulldetail(sCode);
        }

        public DataSet Get_TubeID(string pHn, string pSpecimenType)
        {
            return proxy.Get_TubeID(pHn, pSpecimenType);
        }

        public object Get_Version()
        {
            object obj = proxy.Get_Version();
            return obj;
        }

        public DataSet GetEligibilityInsuranceDetail(string pMRN, string pEncType, string PEncID, string pSDLOC, string pPerfDate, string pClinicType)
        {
            return proxy.GetEligibilityInsuranceDetail(pMRN, pEncType, PEncID, pSDLOC, pPerfDate, pClinicType);
        }
        public DataSet GetEncounterDetailByMRNForToday(string pMRN)
        {
            return proxy.GetEncounterDetailByMRNForToday(pMRN);
        }
        public DataSet GetEncounterDetailByMRNDATE(string pMRN, string pCDate)
        {
            return proxy.GetEncounterDetailByMRNDATE(pMRN, pCDate);
        }
        public DataSet GetEncounterDetailByMRNENCTYPE(string pMRN, string pEncType)
        {
            return proxy.GetEncounterDetailByMRNENCTYPE(pMRN, pEncType);
        }
        public DataSet GetEncounterDetailClinicTypePriceType(string pMRN, string pStrProductCode, string pActiveDate, string pNonresident)
        {
            return proxy.GetEncounterDetailClinicTypePriceType(pMRN, pStrProductCode, pActiveDate, pNonresident);
        }
        public DataSet searchPatientIdentificationByMRNandActiveDate(string pMRN, string ActiveDate)
        {
            return proxy.searchPatientIdentificationByMRNandActiveDate(pMRN, ActiveDate);
        }
        #endregion

        #region Set Method.

        public string Set_Billing(string xString)
        {
            string ack_msg = proxy.Set_Billing(xString);
            BillingLog_Set_Billing(xString, ack_msg);
            return ack_msg;

        }
        public DataSet Set_Billing_OutsidePatient(string xString)
        {
            return proxy.Set_Billing_OutsidePatient(xString);
        }

        public DataSet Set_ConfirmTube(string xString)
        {
            return proxy.Set_ConfirmTube(xString);
        }

        public DataSet Set_Demographic_Long_OutsidePatient(string xString)
        {
            return proxy.Set_Demographic_Long_OutsidePatient(xString);
        }

        public DataSet Set_OR(string xString)
        {
            return proxy.Set_OR(xString);
        }

        public DataSet Set_PAE(string xString)
        {
            return proxy.Set_PAE(xString);
        }

        public DataSet Set_StaffPayroll(string xString)
        {
            return proxy.Set_StaffPayroll(xString);
        }

        public DataSet Set_Ward2Xray(string xString)
        {
            return proxy.Set_Ward2Xray(xString);
        }

        public DataSet Set_WorkStaff(string xString)
        {
            return proxy.Set_WorkStaff(xString);
        }
        #endregion

        #region Cancel Method.
        public string Cancel_Billing(string hn, string accession_No, string an, string iseq)
        {
            string ack_msg = proxy.Cancel_Billing(hn, accession_No, an, iseq);
            BillingLog_Cancel_Billing(hn, accession_No, an, iseq, ack_msg);
            return ack_msg;
        }
        #endregion

        public void BillingLog_Set_Billing(string str_data, string ack_msg)
        {
            //string[] msgs = str_data.Substring(str_data.IndexOf("#") + 1).Split(new string[] { "#" }, StringSplitOptions.None);

            //string hn = msgs[1];
            //string Acc = msgs[2];
            //string AN = msgs[3];
            //string ISEQ = msgs[4];
            //string UNIT_UID = msgs[5];

            ////string str_date = msgs[6] + " " + msgs[19];
            ////DateTime ORDER_DT = Convert.ToDateTime(str_date);

            //string str_day = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[0];
            //string str_month = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[1];
            //string str_year = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[2];
            //string str_hour = msgs[19].Split(new string[] { ":" }, StringSplitOptions.None)[0];
            //string str_minute = msgs[19].Split(new string[] { ":" }, StringSplitOptions.None)[1];

            //int day = Convert.ToInt32(str_day);
            //int month = Convert.ToInt32(str_month);
            //int year = Convert.ToInt32(str_year);
            //int hour = Convert.ToInt32(str_hour);
            //int minute = Convert.ToInt32(str_minute);
            //DateTime ORDER_DT = new DateTime(year, month, day, hour, minute, 0);

            //string EXAM_UID = msgs[9];
            //string QTY = msgs[10];
            //string RATE = msgs[11];
            //string AMOUNT = msgs[12];
            //string HR_UNIT = msgs[13];
            //string ORDER_DATE = msgs[18];
            //string ORDER_TIME = msgs[19];
            //string MSG_TYPE = msgs[20];
            //string CLINIC_TYPE = msgs[21];
            //string COL_22 = msgs[22];
            //string INSURANCE_TYPE_UID = msgs[23];
            //string RD = msgs[24];
            //string COL_25 = msgs[25];
            //string HR_EMP = msgs[26];
            ////+ "#" + strISEQ
            ////+ "#" + unit_uid
            ////+ "#" + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year
            ////+ "#" + "C"
            ////+ "#" + "3"
            ////+ "#" + exam_uid
            ////+ "#" + intQTY.ToString()
            ////+ "#" + rate.ToString("#0.0")
            ////+ "#" + Amt.ToString("#.0")
            ////+ "#" + emp_uid
            ////+ "# # # # #" + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year
            ////+ "#" + item.ORDER_DT.ToString("HH:mm")
            ////+ "#" + strMstype
            ////+ "#" + strClinic
            ////+ "#" + "3"
            ////+ "#" + strInSu
            ////+ "#" + "RD-0101"
            ////+ "#" + "0"
            ////+ "#" + env.UserUID
            ////+ "#";

            //ProcessAddRISBillingtransactionlog insertMaster
            //    = new ProcessAddRISBillingtransactionlog();
            //insertMaster.RISBillingtransactionlog.ACCESSION_NO = Acc;
            //try
            //{
            //    insertMaster.Invoke();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            //ProcessAddRISBillingtransactionlogdtl insertDetail
            //    = new ProcessAddRISBillingtransactionlogdtl();
            //insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = Acc;
            //insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = str_data;
            //insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ack_msg;
            //insertDetail.RISBillingtransactionlogdtl.HN = hn;
            //insertDetail.RISBillingtransactionlogdtl.AN = AN;
            //insertDetail.RISBillingtransactionlogdtl.ISEQ = ISEQ;
            //insertDetail.RISBillingtransactionlogdtl.UNIT_UID = UNIT_UID;
            //insertDetail.RISBillingtransactionlogdtl.ORDER_DT = ORDER_DT;
            ////insertDetail.RISBillingtransactionlogdtl.ORDER_DT = DateTime.Now;
            //insertDetail.RISBillingtransactionlogdtl.EXAM_UID = EXAM_UID;
            //insertDetail.RISBillingtransactionlogdtl.QTY = Convert.ToInt32(QTY);
            //insertDetail.RISBillingtransactionlogdtl.RATE = Convert.ToDecimal(RATE);
            //insertDetail.RISBillingtransactionlogdtl.AMOUNT = Convert.ToDecimal(AMOUNT);
            //insertDetail.RISBillingtransactionlogdtl.HR_UNIT = HR_UNIT;
            //insertDetail.RISBillingtransactionlogdtl.MSG_TYPE = MSG_TYPE;
            //insertDetail.RISBillingtransactionlogdtl.CLINIC_TYPE = CLINIC_TYPE;
            //insertDetail.RISBillingtransactionlogdtl.INSURANCE_TYPE_UID = INSURANCE_TYPE_UID;
            //insertDetail.RISBillingtransactionlogdtl.HR_EMP = HR_EMP;
            //insertDetail.RISBillingtransactionlogdtl.CREATED_BY = new GBLEnvVariable().UserID;
            //insertDetail.RISBillingtransactionlogdtl.BILLING_TYPE = "Set_Billing";

            //try
            //{
            //    insertDetail.Invoke();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        public void BillingLog_Cancel_Billing(string hn, string accession_No, string an, string iseq, string ack_msg)
        {
            //ProcessAddRISBillingtransactionlog insertMaster
            //   = new ProcessAddRISBillingtransactionlog();
            //insertMaster.RISBillingtransactionlog.ACCESSION_NO = accession_No;
            //try
            //{
            //    insertMaster.Invoke();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //ProcessAddRISBillingtransactionlogdtl insertDetail
            //    = new ProcessAddRISBillingtransactionlogdtl();
            //insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = accession_No;
            //insertDetail.RISBillingtransactionlogdtl.HN = hn;
            //insertDetail.RISBillingtransactionlogdtl.AN = an;
            //insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = "";
            //insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ack_msg;
            //insertDetail.RISBillingtransactionlogdtl.BILLING_TYPE = "Cancel_Billing";
            //insertDetail.RISBillingtransactionlogdtl.ORDER_DT = DateTime.Now;
            //try
            //{
            //    insertDetail.Invoke();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}
