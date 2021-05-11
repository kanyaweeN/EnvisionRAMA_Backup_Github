using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLEmployee
    {
        #region Data Field

        private int _empid;
        private string _empuid;
        private string _username;
        private string _securityquestion;
        private string _securityanswer;
        private string _pwd;
        private int _unitid;
        private int _jobtitleid;
        private string _jobtype;
        private string _isradiologist;

        private string _salutation;
        private string _fname;
        private string _mname;
        private string _lname;
        private string _titleeng;
        private string _fnameeng;
        private string _mnameeng;
        private string _lnameeng;
        private string _gender;

        private string _emailpersonal;
        private string _emailofficial;
        private string _phonehome;
        private string _phonemobile;
        private string _phoneoffice;
        private string _preferredphone;
        private int _pabx_ext;
        private string _faxno;
        private DateTime _dob;

        private string _bloodgroup;
        private int _defaultlang;
        private int _religion;
        private string _peaddr1;
        private string _peaddr2;
        private string _peaddr3;
        private string _peaddr4;

        private int _authlevelid;
        private int _reportingto;
        private string _allowotherstofinalize;
        private string _cardno;
        private string _placeofbirth;
        private string _nationnality;
        private string _mstatus;

        private string _isactive;
        private string _supportuser;
        private string _cankillsession;
        private int _defaultshiftno;
        private string _imgfilename;
        private int _orgid;

        private DateTime _lastpwdmodified;
        private DateTime _lastlogin;

        private int _createdby;
        private DateTime _createdon;
        private int _lastmodifiedby;
        private DateTime _lastmodifiedon;

        private string _emp_report_footer1;
        private string _emp_report_footer2;

        #endregion Data Filed

        #region Properties

        public int Emp_ID
        {
            get { return _empid; }
            set { _empid = value; }
        }
        public string Emp_UID
        {
            get { return _empuid; }
            set { _empuid = value; }
        }   
        public string User_Name
        {
            get{ return _username; }
            set{ _username = value; }
        }
        public string Security_Question
        {
            get{return _securityquestion;}
            set{_securityquestion = value;}
        }
        public string Security_Answer
        {
            get{return _securityanswer;}
            set{_securityanswer=value;}
        }
        public string Pwd
        {
            get{return _pwd;}
            set{_pwd=value;}
        }
        public int Unit_ID
        {
            get{return _unitid;}
            set{_unitid=value;}
        }
        public int Jobtitle_ID
        {
            get{return _jobtitleid;}
            set{_jobtitleid=value;}
        }
        public string Job_Type
        {
            get{return _jobtype;}
            set{_jobtype=value;}
        }
        public string Is_Radiologist
        {
            get{return _isradiologist;}
            set{_isradiologist=value;}
        }

        public string Salutation
        {
            get{return _salutation;}
            set{_salutation=value;}
        }
        public string Fname
        {
            get{return _fname;}
            set{_fname=value;}
        }
        public string Mname
        {
            get{return _mname;}
            set{_mname = value;}
        }
        public string Lname
        {
            get{return _lname;}
            set{_lname = value;}
        }
        public string Title_Eng
        {
            get{return _titleeng;}
            set{_titleeng = value;}
        }
        public string Fname_Eng
        {
            get{return _fnameeng;}
            set{_fnameeng = value;}
        }
        public string Mname_Eng
        {
            get{return _mnameeng;}
            set{_mnameeng = value;}
        }
        public string Lname_Eng
        {
            get{return _lnameeng;}
            set{_lnameeng = value;}
        }
        public string Gender
        {
            get{return _gender;}
            set{_gender = value;}
        }

        public string Email_Personal
        {
            get{return _emailpersonal;}
            set{_emailpersonal = value;}
        }
        public string Email_Official
        {
            get{return _emailofficial;}
            set{_emailofficial = value;}
        }
        public string Phone_Home
        {
            get{return _phonehome;}
            set{_phonehome = value;}
        }
        public string Phone_Mobile
        {
            get{return _phonemobile;}
            set{_phonemobile = value;}
        }
        public string Phone_Office
        {
            get{return _phoneoffice;}
            set{_phoneoffice = value;}
        }
        public string Preferred_Phone
        {
            get{return _preferredphone;}
            set{_preferredphone = value;}
        }
        public int Pabx_Ext
        {
            get{return _pabx_ext;}
            set{_pabx_ext = value;}
        }
        public string Fax_No
        {
            get{return _faxno;}
            set{_faxno = value;}
        }

        public DateTime Dob
        {
            get{return _dob;}
            set{_dob = value;}
        }
        public string Place_Of_Birth
        {
            get{return _placeofbirth;}
            set{_placeofbirth = value;}
        }
        public string Blood_Group
        {
            get{return _bloodgroup;}
            set{_bloodgroup = value;}
        }
        public int Default_Lang
        {
            get{return _defaultlang;}
            set{_defaultlang = value;}
        }
        public int Religion
        {
            get{return _religion;}
            set{_religion = value;}
        }
        public string PE_Addr1
        {
            get{return _peaddr1;}
            set{_peaddr1 = value;}
        }
        public string PE_Addr2
        {
            get { return _peaddr2; }
            set { _peaddr2 = value; }
        }
        public string PE_Addr3
        {
            get { return _peaddr3; }
            set { _peaddr3 = value; }
        }
        public string PE_Addr4
        {
            get { return _peaddr4; }
            set { _peaddr4 = value; }
        }

        public int Auth_Level_ID
        {
            get { return _authlevelid; }
            set { _authlevelid = value; }
        }
        public int Reporting_To
        {
            get{return _reportingto;}
            set { _reportingto = value; }
        }
        public string Allow_Other_To_Finalize
        {
            get{return _allowotherstofinalize;}
            set { _allowotherstofinalize = value; }
        }
        public string Card_NO
        {
            get{return _cardno;}
            set { _cardno = value; }
        }
        public string Nationality
        {
            get{return _nationnality;}
            set { _nationnality = value; }
        }
        public string M_Status
        {
            get{return _mstatus;}
            set { _mstatus = value; }
        }

        public string Is_Active
        {
            get{return _isactive;}
            set { _isactive = value; }
        }
        public string Support_User
        {
            get{return _supportuser;}
            set { _supportuser = value; }
        }
        public string Can_Kill_Session
        {
            get{return _cankillsession;}
            set { _cankillsession = value; }
        }
        public int Default_Shift_NO
        {
            get{return _defaultshiftno;}
            set { _defaultshiftno = value; }
        }
        public string Img_File_Name
        {
            get{return _imgfilename;}
            set { _imgfilename = value; }
        }
        public int Org_ID
        {
            get{return _orgid;}
            set { _orgid = value; }
        }

        public DateTime Last_Pwd_Modified
        {
            get{return _lastpwdmodified;}
            set { _lastpwdmodified = value; }
        }
        public DateTime Last_Login
        {
            get{return _lastlogin;}
            set { _lastlogin = value; }
        }

        public int Created_By
        {
            get{return _createdby;}
            set { _createdby = value; }
        }
        public DateTime Created_On
        {
            get{return _createdon;}
            set { _createdon = value; }
        }
        public int Last_Modified_By
        {
            get{return _lastmodifiedby;}
            set { _lastmodifiedby = value; }
        }
        public DateTime Last_Modified_On
        {
            get{return _lastmodifiedon;}
            set { _lastmodifiedon = value; }
        }

        public string EMP_REPORT_FOOTER1
        {
            get { return _emp_report_footer1; }
            set { _emp_report_footer1 = value; }
        }
        public string EMP_REPORT_FOOTER2
        {
            get { return _emp_report_footer2; }
            set { _emp_report_footer2 = value; }
        }

        #endregion Properties
    }
}
