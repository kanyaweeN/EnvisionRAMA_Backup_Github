using System;

namespace EnvisionInterfaceEngine.Common
{
	public class HIS_REGISTRATION
	{
		public HIS_REGISTRATION() { }

		public int REG_ID { get; set; }
		public DateTime REG_DT { get; set; }
		public string HIS_HN { get; set; }
		public string HN { get; set; }
		public string EXT_HN { get; set; }
		public string TITLE { get; set; }
		public string FNAME { get; set; }
		public string MNAME { get; set; }
		public string LNAME { get; set; }
		public string TITLE_ENG { get; set; }
		public string FNAME_ENG { get; set; }
		public string MNAME_ENG { get; set; }
		public string LNAME_ENG { get; set; }
		public string SSN { get; set; }
		public DateTime DOB { get; set; }
		public int AGE { get; set; }
		public string ADDR1 { get; set; }
		public string ADDR2 { get; set; }
		public string ADDR3 { get; set; }
		public string ADDR4 { get; set; }
		public string ADDR5 { get; set; }
		public string PHONE1 { get; set; }
		public string PHONE2 { get; set; }
		public string PHONE3 { get; set; }
		public string EMAIL { get; set; }
		public char GENDER { get; set; }
		public char MARITAL_STATUS { get; set; }
		public int OCCUPATION_ID { get; set; }
		public string NATIONALITY { get; set; }
		public string PASSPORT_NO { get; set; }
		public string BLOOD_GROUP { get; set; }
		public string RELIGION { get; set; }
		public char PATIENT_TYPE { get; set; }
		public string EM_CONTACT_PERSON { get; set; }
		public string EM_RELATION { get; set; }
		public string EM_ADDR { get; set; }
		public string EM_PHONE { get; set; }
		public string INSURANCE_TYPE { get; set; }
		public string ALLERGIES { get; set; }
		public int ORG_ID { get; set; }
		public int LAST_MODIFIED_BY { get; set; }
	}
}