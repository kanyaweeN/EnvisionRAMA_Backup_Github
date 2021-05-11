//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    16/06/2009 04:23:18
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class HREmp
		{
			#region Member 
			private	int emp_id;
			private	string emp_uid;
			private	string user_name;
			private	string security_question;
			private	string security_answer;
			private	string pwd;
			private	int? unit_id;
			private	int jobtitle_id;
			private	string job_type;
			private	string is_radiologist;
			private	string salutation;
			private	string fname;
			private	string mname;
			private	string lname;
			private	string title_eng;
			private	string fname_eng;
			private	string mname_eng;
			private	string lname_eng;
			private	string gender;
			private	string email_personal;
			private	string email_official;
			private	string phone_home;
			private	string phone_mobile;
			private	string phone_office;
			private	string preferred_phone;
			private	int pabx_ext;
			private	string fax_no;
			private	DateTime dob;
			private	string blood_group;
			private	int? default_lang;
			private	int religion;
			private	string pe_addr1;
			private	string pe_addr2;
			private	string pe_addr3;
			private	string pe_addr4;
			private	int? auth_level_id;
			private	int reporting_to;
			private	string allow_others_to_finalize;
			private	DateTime last_pwd_modified;
			private	DateTime last_login;
			private	string card_no;
			private	string place_of_birth;
			private	string nationality;
			private	string m_status;
			private	string is_active;
			private	string support_user;
			private	string can_kill_session;
			private	int default_shift_no;
			private	string img_file_name;
			private	string emp_report_footer1;
			private	string emp_report_footer2;
			private	byte[] allproperties;
			private	bool visible;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string mode;
            private string is_resident;
			#endregion 


			#region Property 
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
			}
			public	string EMP_UID
			{
				get{ return emp_uid;}
				set{ emp_uid=value;}
			}
			public	string USER_NAME
			{
				get{ return user_name;}
				set{ user_name=value;}
			}
			public	string SECURITY_QUESTION
			{
				get{ return security_question;}
				set{ security_question=value;}
			}
			public	string SECURITY_ANSWER
			{
				get{ return security_answer;}
				set{ security_answer=value;}
			}
			public	string PWD
			{
				get{ return pwd;}
				set{ pwd=value;}
			}
			public	int? UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	int JOBTITLE_ID
			{
				get{ return jobtitle_id;}
				set{ jobtitle_id=value;}
			}
			public	string JOB_TYPE
			{
				get{ return job_type;}
				set{ job_type=value;}
			}
			public	string IS_RADIOLOGIST
			{
				get{ return is_radiologist;}
				set{ is_radiologist=value;}
			}
			public	string SALUTATION
			{
				get{ return salutation;}
				set{ salutation=value;}
			}
			public	string FNAME
			{
				get{ return fname;}
				set{ fname=value;}
			}
			public	string MNAME
			{
				get{ return mname;}
				set{ mname=value;}
			}
			public	string LNAME
			{
				get{ return lname;}
				set{ lname=value;}
			}
			public	string TITLE_ENG
			{
				get{ return title_eng;}
				set{ title_eng=value;}
			}
			public	string FNAME_ENG
			{
				get{ return fname_eng;}
				set{ fname_eng=value;}
			}
			public	string MNAME_ENG
			{
				get{ return mname_eng;}
				set{ mname_eng=value;}
			}
			public	string LNAME_ENG
			{
				get{ return lname_eng;}
				set{ lname_eng=value;}
			}
			public	string GENDER
			{
				get{ return gender;}
				set{ gender=value;}
			}
			public	string EMAIL_PERSONAL
			{
				get{ return email_personal;}
				set{ email_personal=value;}
			}
			public	string EMAIL_OFFICIAL
			{
				get{ return email_official;}
				set{ email_official=value;}
			}
			public	string PHONE_HOME
			{
				get{ return phone_home;}
				set{ phone_home=value;}
			}
			public	string PHONE_MOBILE
			{
				get{ return phone_mobile;}
				set{ phone_mobile=value;}
			}
			public	string PHONE_OFFICE
			{
				get{ return phone_office;}
				set{ phone_office=value;}
			}
			public	string PREFERRED_PHONE
			{
				get{ return preferred_phone;}
				set{ preferred_phone=value;}
			}
			public	int PABX_EXT
			{
				get{ return pabx_ext;}
				set{ pabx_ext=value;}
			}
			public	string FAX_NO
			{
				get{ return fax_no;}
				set{ fax_no=value;}
			}
			public	DateTime DOB
			{
				get{ return dob;}
				set{ dob=value;}
			}
			public	string BLOOD_GROUP
			{
				get{ return blood_group;}
				set{ blood_group=value;}
			}
			public	int? DEFAULT_LANG
			{
				get{ return default_lang;}
				set{ default_lang=value;}
			}
			public	int RELIGION
			{
				get{ return religion;}
				set{ religion=value;}
			}
			public	string PE_ADDR1
			{
				get{ return pe_addr1;}
				set{ pe_addr1=value;}
			}
			public	string PE_ADDR2
			{
				get{ return pe_addr2;}
				set{ pe_addr2=value;}
			}
			public	string PE_ADDR3
			{
				get{ return pe_addr3;}
				set{ pe_addr3=value;}
			}
			public	string PE_ADDR4
			{
				get{ return pe_addr4;}
				set{ pe_addr4=value;}
			}
			public	int? AUTH_LEVEL_ID
			{
				get{ return auth_level_id;}
				set{ auth_level_id=value;}
			}
			public	int REPORTING_TO
			{
				get{ return reporting_to;}
				set{ reporting_to=value;}
			}
			public	string ALLOW_OTHERS_TO_FINALIZE
			{
				get{ return allow_others_to_finalize;}
				set{ allow_others_to_finalize=value;}
			}
			public	DateTime LAST_PWD_MODIFIED
			{
				get{ return last_pwd_modified;}
				set{ last_pwd_modified=value;}
			}
			public	DateTime LAST_LOGIN
			{
				get{ return last_login;}
				set{ last_login=value;}
			}
			public	string CARD_NO
			{
				get{ return card_no;}
				set{ card_no=value;}
			}
			public	string PLACE_OF_BIRTH
			{
				get{ return place_of_birth;}
				set{ place_of_birth=value;}
			}
			public	string NATIONALITY
			{
				get{ return nationality;}
				set{ nationality=value;}
			}
			public	string M_STATUS
			{
				get{ return m_status;}
				set{ m_status=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	string SUPPORT_USER
			{
				get{ return support_user;}
				set{ support_user=value;}
			}
			public	string CAN_KILL_SESSION
			{
				get{ return can_kill_session;}
				set{ can_kill_session=value;}
			}
			public	int DEFAULT_SHIFT_NO
			{
				get{ return default_shift_no;}
				set{ default_shift_no=value;}
			}
			public	string IMG_FILE_NAME
			{
				get{ return img_file_name;}
				set{ img_file_name=value;}
			}
			public	string EMP_REPORT_FOOTER1
			{
				get{ return emp_report_footer1;}
				set{ emp_report_footer1=value;}
			}
			public	string EMP_REPORT_FOOTER2
			{
				get{ return emp_report_footer2;}
				set{ emp_report_footer2=value;}
			}
			public	byte[] ALLPROPERTIES
			{
				get{ return allproperties;}
				set{ allproperties=value;}
			}
			public	bool VISIBLE
			{
				get{ return visible;}
				set{ visible=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			public	int CREATED_BY
			{
				get{ return created_by;}
				set{ created_by=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return created_on;}
				set{ created_on=value;}
			}
			public	int LAST_MODIFIED_BY
			{
				get{ return last_modified_by;}
				set{ last_modified_by=value;}
			}
			public	DateTime LAST_MODIFIED_ON
			{
				get{ return last_modified_on;}
				set{ last_modified_on=value;}
			}
            public string MODE
            {
                get { return mode; }
                set { mode = value; }
            }
            public string IS_RESIDENT
            {
                get { return is_resident; }
                set { is_resident = value; }
            }
			#endregion 


			#region Constructor 
			public HREmp(){

			}
			#endregion 


			#region Method 
			public HREmp Copy()
			{
				return MemberwiseClone() as HREmp;
			}
			#endregion
		}
}

