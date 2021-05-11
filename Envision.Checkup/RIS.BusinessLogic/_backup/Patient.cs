using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.Common.Common;
//using RIS.BusinessLogic.Common.HISService;
using RIS.BusinessLogic.Common.RamaService;
using RIS.Operational.Translator;
namespace RIS.BusinessLogic
{
    public class Patient : IPatientDemographic
    {
        private bool linkdown;
        private bool hasHN;
        private bool dataFromHIS;
        private bool dataFromLocal;
        private bool dataFromManual;
        public string OLDHN { get; set; }

        #region Member
        private string an;
        private string visit_number;
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
        #endregion

        #region IPatientDemographic Members
        public string AN { get { return an; } set { an = value; } }
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
        public string VisitNumber
        {
            get { return visit_number; }
            set { visit_number = value; }
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

                    DataTable rsINS = order.Ris_InsuranceType();
                    DataRow[] row = rsINS.Select("INSURANCE_TYPE_UID ='" + dtt.Rows[0]["type_pat"].ToString().Trim() + "'");
                    if (row.Length == 0)
                    { 
                        DataSet dsInsurance = p.Get_insurance_detail(dtt.Rows[0]["type_pat"].ToString());
                        if (UtilityClass.Helper.HasRow(dsInsurance))
                        {
                            DataTable dttInsurance = dsInsurance.Tables[0].Copy();
                            if (row.Length == 0)
                            {
                                ProcessAddRISInsurancetype procINS = new ProcessAddRISInsurancetype();
                                procINS.RISInsurancetype.CREATED_BY = new GBLEnvVariable().UserID;
                                procINS.RISInsurancetype.INSURANCE_TYPE_DESC = dttInsurance.Rows[0]["describe"].ToString().Trim();
                                procINS.RISInsurancetype.INSURANCE_TYPE_UID = dttInsurance.Rows[0]["code1"].ToString().Trim();
                                procINS.RISInsurancetype.ORG_ID = new GBLEnvVariable().OrgID;
                                procINS.Invoke();
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(dtt.Rows[0]["ref_unit"].ToString().Trim())) 
                    { 
                        ProcessGetHRUnit processDep = new ProcessGetHRUnit();
                        processDep.Invoke();
                        DataTable dttDept = processDep.Result.Tables[0].Copy();
                        row = null;
                        row = dttDept.Select("UNIT_UID='" + dtt.Rows[0]["ref_unit"].ToString().Trim() + "'");
                        if (row.Length > 0)
                            ref_unit = Convert.ToInt32(row[0]["UNIT_ID"]);
                        else
                            insertHR_UNIT(dtt.Rows[0]["ref_unit"].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dtt.Rows[0]["ref_doc"].ToString().Trim())) {
                        ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
                        processDoctor.Invoke();
                        DataTable dttDept = processDoctor.Result.Tables[0].Copy();
                        row = null;
                        row = dttDept.Select("EMP_UID='" + dtt.Rows[0]["ref_doc"].ToString().Trim() + "'");
                        if (row.Length > 0)
                            ref_doc = Convert.ToInt32(row[0]["EMP_ID"]);
                        else
                            insertHR_EMP(dtt.Rows[0]["ref_doc"].ToString().Trim());
                    }
                    DataSet dsRet = new DataSet();
                    dsRet.Tables.Add(dtt.Copy());
                    dsRet.AcceptChanges();
                    FillData(dsRet);
                }
            }
            catch (Exception exe)
            {
                linkdown = true;
                hasHN = false;
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

                dob = dr["birth"].ToString().Trim() == string.Empty || dr["birth"].ToString() == null ? DateTime.MinValue : Convert.ToDateTime(dr["birth"]);

                title = dr["ini_name"].ToString().Trim();
                fname = dr["name"].ToString().Trim();
                mname = string.Empty;
                lname = dr["fname"].ToString().Trim();
                title_eng = string.Empty;

                fname_eng = RIS.Operational.Translator.TransToEnglish.Trans(fname);
                mname_eng = string.Empty;
                lname_eng = RIS.Operational.Translator.TransToEnglish.Trans(lname);

                ssn = dr["cid"].ToString();
                age = Convert.ToInt32(dr["age"].ToString());

                if (!string.IsNullOrEmpty(dr["addr"].ToString()))
                    addr1 = dr["addr"].ToString().Trim();
                else
                    addr1 = string.Empty;
                if (!string.IsNullOrEmpty(dr["addrmu"].ToString()))
                    addr2 = dr["addrmu"].ToString().Trim();
                if (!string.IsNullOrEmpty(dr["soi"].ToString()))
                    addr2 += dr["soi"].ToString().Trim();
                if (!string.IsNullOrEmpty(dr["street"].ToString()))
                    addr3 = dr["street"].ToString().Trim(); 
                if (!string.IsNullOrEmpty(dr["town"].ToString()))
                    addr3 += dr["town"].ToString().Trim();
                if (!string.IsNullOrEmpty(dr["district_text"].ToString()))
                    addr4 = dr["district_text"].ToString().Trim();
                else
                    addr4 = string.Empty;
                if (!string.IsNullOrEmpty(dr["province_text"].ToString()))
                    addr5 = dr["province_text"].ToString().Trim();
                if (!string.IsNullOrEmpty(dr["zip"].ToString()))
                    addr5+= dr["zip"].ToString().Trim();

                phone1 = String.IsNullOrEmpty(dr["tel"].ToString()) ? string.Empty : dr["tel"].ToString().Trim();
                phone2 = string.Empty;
                phone3 = string.Empty;

                em_addr = dr["contact"].ToString();
                gender = dr["sex"].ToString() == "1" ? "M" : "F";

                nationality = dr["nation"].ToString();
                em_contact_person = dr["cont_pers"].ToString();

                insurance_type = dr["type_pat"].ToString().Trim();

                marital_status = string.Empty;
                occupation_id = 0;// dr["occupat"].ToString().Trim();

                passport_no = string.Empty;
                blood_group = dr["bloodgroup"].ToString();
                religeon = dr["religion"].ToString();
                patient_type = string.Empty;

                em_phone = string.Empty;
                em_relation = dr["cont_code"].ToString();
                hl7_format = string.Empty;
                hl7_send = string.Empty;
                allergies = string.Empty;
                org_id = 1;
                created_by = 0;
                created_on = DateTime.Today;
                last_modified_by = 0;
                if (!string.IsNullOrEmpty(dr["last_come"].ToString().Trim()))
                    last_modified_on = Convert.ToDateTime(dr["last_come"].ToString());
                else last_modified_on = DateTime.Now;
                visit_number = dr["visit_no"].ToString();
                an = dr["an"].ToString();

                if (string.IsNullOrEmpty(dr["oldhn"].ToString()))
                    OLDHN = string.Empty;
                else
                    OLDHN = dr["oldhn"].ToString();

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

        private void insertHR_UNIT(string ID)
        {
            try
            {
                GBLEnvVariable env = new GBLEnvVariable();
                HIS_Patient his = new HIS_Patient();
                DataSet dtHIS = his.GetLoacation(ID);
                if (dtHIS != null)
                    if (dtHIS.Tables.Count > 0)
                    {
                        ProcessAddHRUnit proHR = new ProcessAddHRUnit();
                        proHR.HRUnit.CREATED_BY = env.UserID;
                        proHR.HRUnit.DESCR = dtHIS.Tables[0].Rows[0]["desc"].ToString();
                        proHR.HRUnit.ORG_ID = env.OrgID;
                        proHR.HRUnit.PHONE_NO = dtHIS.Tables[0].Rows[0]["tel1"].ToString();
                        proHR.HRUnit.UNIT_ALIAS = string.Empty;
                        proHR.HRUnit.UNIT_ID = 0;
                        proHR.HRUnit.UNIT_ID_PARENT = 0;
                        proHR.HRUnit.UNIT_INS = string.Empty;
                        proHR.HRUnit.UNIT_NAME = dtHIS.Tables[0].Rows[0]["sdlocname"].ToString();
                        proHR.HRUnit.UNIT_NAME_ALIAS = string.Empty;
                        proHR.HRUnit.UNIT_TYPE = string.Empty;
                        proHR.HRUnit.UNIT_UID = dtHIS.Tables[0].Rows[0]["sdlocid"].ToString();
                        proHR.Invoke();
                        ref_unit = proHR.HRUnit.UNIT_ID;
                    }
            }
            catch { }
        }
        private void insertHR_EMP(string ID)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            Service proxy = new Service();
            DataSet ds = proxy.get(ID);
            if (UtilityClass.Helper.HasRow(ds))
            {
                ProcessAddHREmp proEMP = new ProcessAddHREmp();
                proEMP.HREmp.EMP_UID = ds.Tables[0].Rows[0]["code1"].ToString();
                proEMP.HREmp.USER_NAME = ds.Tables[0].Rows[0]["code1"].ToString();
                string[] name = ds.Tables[0].Rows[0]["describe"].ToString().Trim().Split(' '.ToString().ToCharArray());
                proEMP.HREmp.FNAME = name[0];
                proEMP.HREmp.LNAME = name[2];
                proEMP.HREmp.ORG_ID = env.OrgID;
                proEMP.HREmp.CREATED_BY = env.UserID;
                proEMP.AddFromHis();
                ref_doc = proEMP.HREmp.EMP_ID;
            }
            //try
            //{
            //    GBLEnvVariable env = new GBLEnvVariable();
            //    ProcessAddHREmp proEMP = new ProcessAddHREmp();
            //    proEMP.HREmp.EMP_UID = ID;
            //    proEMP.HREmp.USER_NAME = ID;
            //    string[] name = Name.Trim().Split(' '.ToString().ToCharArray());
            //    proEMP.HREmp.FNAME = name[0];
            //    proEMP.HREmp.LNAME = name[2];
            //    proEMP.HREmp.ORG_ID = env.OrgID;
            //    proEMP.HREmp.CREATED_BY = env.UserID;
            //    proEMP.AddFromHis();
            //    ref_doc = proEMP.HREmp.EMP_ID;
            //}
            //catch { }
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
    }
    
    public class HIS_Patient
    {

        private Service proxy;

        public HIS_Patient()
        {
            proxy = new Service();
            //proxy.Url = "http://192.168.4.79/patientservice/service.asmx";
            proxy.Url = "http://miracle99/patientservice/service.asmx";
        }


        //public DataSet GetDemographicData(string HN) {
        //    DataSet ds = null;
        //    if (HN.Length == 0) return ds;
        //    if (HN[0] == 'L')
        //    {
        //        //ปรับชื่อฟิลด์ให้เหมือนกับ Demographic.
        //        ds = proxy.GetDemographicLabor(HN);
        //    }
        //    else
        //        ds = proxy.GetDemographic(HN);

        //    return ds;
        //}
        //public DataSet GetDemographicDataLabor(string LHN) {
        //    return proxy.GetDemographicLabor(LHN);
        //}
        //public DataSet GetDoctor(string Code) {
        //    return proxy.GetDoctor(Code);
        //}
        //public DataSet GetLoacation(string Code)
        //{
        //    return proxy.GetLocation(Code);
        //}
        //public DataSet GetInsurance(string Code) {
        //    return proxy.GetInsurance(Code);
        //}

        //public DataSet SetBilling(int OrderID) {
        //    return proxy.SetBill(OrderID);
        //}
        //public DataSet CancelBilling(int OrderID) {
        //    return proxy.CancelBill(OrderID);
        //}
        //public DataSet EditBilling(DataSet OldBill,int OrderID) {
        //    return proxy.EditBill(OldBill, OrderID);
        //}

        public DataSet Get_demographic_long(string hn)
        {
            return proxy.Get_demographic_long(hn);
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

        public DataSet Get_appointment(string hn)
        {
            return proxy.Get_appointment(hn.ToUpper().Trim());
        }
        public DataSet Get_appointment_detail(string hn)
        {
            return proxy.Get_appointment_detail(hn.ToUpper().Trim());
        }

        public DataSet Get_Claim_Amt(string hn, string accession_No)
        {
            return proxy.Get_Claim_Amt(hn.ToUpper().Trim(), accession_No.ToUpper().Trim());
        }
        public DataSet Get_insurance_detail(string hn)
        {
            return proxy.Get_insurance_detail(hn.ToUpper().Trim());
        }

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
        public DataSet Get_lab_datachem_outside(string pReqname)
        {
            return proxy.Get_lab_datachem_outside(pReqname);
        }
        public DataSet Get_lab_datahemato_outside(string pReqname)
        {
            return proxy.Get_lab_datahemato_outside(pReqname);
        }
        public DataSet Get_lab_dataimmuno_outside(string pReqname)
        {
            return proxy.Get_lab_dataimmuno_outside(pReqname);
        }
        public DataSet Get_lab_dataua_outside(string pReqname)
        {
            return proxy.Get_lab_dataua_outside(pReqname);
        }
        public DataSet Get_lab_datavirus_outside(string pReqname)
        {
            return proxy.Get_lab_datavirus_outside(pReqname);
        }

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
    }
}
