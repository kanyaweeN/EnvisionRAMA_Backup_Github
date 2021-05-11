//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    26/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class HISRegistration
    {
        #region Constructor
        public HISRegistration()
        {

        }
        #endregion


        #region Member
        private int reg_id;
        private string hn;
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
        private string link_down;
        private byte[] _picture;
        private string is_johndoe;
        #endregion


        #region Property
        public int REG_ID
        {
            get { return reg_id; }
            set { reg_id = value; }
        }
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
        public string TITLE
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime REG_DT
        {
            get { return reg_dt; }
            set { reg_dt = value; }
        }
        public string FNAME
        {
            get { return fname; }
            set { fname = value; }
        }
        public string MNAME
        {
            get { return mname; }
            set { mname = value; }
        }
        public string LNAME
        {
            get { return lname; }
            set { lname = value; }
        }
        public string TITLE_ENG
        {
            get { return title_eng; }
            set { title_eng = value; }
        }
        public string FNAME_ENG
        {
            get { return fname_eng; }
            set { fname_eng = value; }
        }
        public string MNAME_ENG
        {
            get { return mname_eng; }
            set { mname_eng = value; }
        }
        public string LNAME_ENG
        {
            get { return lname_eng; }
            set { lname_eng = value; }
        }
        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }
        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }
        public int AGE
        {
            get { return age; }
            set { age = value; }
        }
        public string ADDR1
        {
            get { return addr1; }
            set { addr1 = value; }
        }
        public string ADDR2
        {
            get { return addr2; }
            set { addr2 = value; }
        }
        public string ADDR3
        {
            get { return addr3; }
            set { addr3 = value; }
        }
        public string ADDR4
        {
            get { return addr4; }
            set { addr4 = value; }
        }
        public string ADDR5
        {
            get { return addr5; }
            set { addr5 = value; }
        }
        public string PHONE1
        {
            get { return phone1; }
            set { phone1 = value; }
        }
        public string PHONE2
        {
            get { return phone2; }
            set { phone2 = value; }
        }
        public string PHONE3
        {
            get { return phone3; }
            set { phone3 = value; }
        }
        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }
        public string GENDER
        {
            get { return gender; }
            set { gender = value; }
        }
        public string MARITAL_STATUS
        {
            get { return marital_status; }
            set { marital_status = value; }
        }
        public int OCCUPATION_ID
        {
            get { return occupation_id; }
            set { occupation_id = value; }
        }
        public string NATIONALITY
        {
            get { return nationality; }
            set { nationality = value; }
        }
        public string PASSPORT_NO
        {
            get { return passport_no; }
            set { passport_no = value; }
        }
        public string BLOOD_GROUP
        {
            get { return blood_group; }
            set { blood_group = value; }
        }
        public string RELIGEON
        {
            get { return religeon; }
            set { religeon = value; }
        }
        public string PATIENT_TYPE
        {
            get { return patient_type; }
            set { patient_type = value; }
        }
        public string EM_CONTACT_PERSON
        {
            get { return em_contact_person; }
            set { em_contact_person = value; }
        }
        public string EM_RELATION
        {
            get { return em_relation; }
            set { em_relation = value; }
        }
        public string EM_ADDR
        {
            get { return em_addr; }
            set { em_addr = value; }
        }
        public string EM_PHONE
        {
            get { return em_phone; }
            set { em_phone = value; }
        }
        public string INSURANCE_TYPE
        {
            get { return insurance_type; }
            set { insurance_type = value; }
        }
        public string HL7_FORMAT
        {
            get { return hl7_format; }
            set { hl7_format = value; }
        }
        public string HL7_SEND
        {
            get { return hl7_send; }
            set { hl7_send = value; }
        }
        public string ALLERGIES
        {
            get { return allergies; }
            set { allergies = value; }
        }
        public int ORG_ID
        {
            get { return org_id; }
            set { org_id = value; }
        }
        public int CREATED_BY
        {
            get { return created_by; }
            set { created_by = value; }
        }
        public DateTime CREATED_ON
        {
            get { return created_on; }
            set { created_on = value; }
        }
        public int LAST_MODIFIED_BY
        {
            get { return last_modified_by; }
            set { last_modified_by = value; }
        }
        public DateTime LAST_MODIFIED_ON
        {
            get { return last_modified_on; }
            set { last_modified_on = value; }
        }
        public string LINK_DOWN
        {
            get { return link_down; }
            set { link_down = value; }
        }
        public byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public string IS_JOHNDOE
        {
            get { return is_johndoe; }
            set { is_johndoe = value; }
        }
        #endregion
    }
}

