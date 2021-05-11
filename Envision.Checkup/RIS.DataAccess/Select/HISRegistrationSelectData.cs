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
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class HISRegistrationSelectData : DataAccessBase 
	{
		private HISRegistration	_hisregistration;
		private HISRegistrationInsertDataParameters	_hisregistrationinsertdataparameters;
        private int action = 0;
		public HISRegistrationSelectData()
		{
            action = 0;
            _hisregistration = new HISRegistration();
			StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_Select.ToString();
		}
        public HISRegistrationSelectData(bool getDataFromHIS) 
        {
            if (getDataFromHIS)
            {
                action = 1;
                _hisregistration = new HISRegistration();
                StoredProcedureName = StoredProcedure.Name.Prc_HIS_SelectFromHIS.ToString();
            }
            else {
                action = 0;
                _hisregistration = new HISRegistration();
                StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_Select.ToString();
            }
        }

		public  HISRegistration	HISRegistration
		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}

		public DataSet GetData()
		{
            _hisregistrationinsertdataparameters = null;// new HISRegistrationInsertDataParameters(HISRegistration);
            if (action == 0)
                _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration);
            else
                _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration.HN);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_hisregistrationinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class HISRegistrationInsertDataParameters 
	{
		private HISRegistration _hisregistration;
		private SqlParameter[] _parameters;

		public HISRegistrationInsertDataParameters(HISRegistration hisregistration)
		{
			HISRegistration=hisregistration;
			Build();
		}
        public HISRegistrationInsertDataParameters(string HN)
        {
            _hisregistration = new HISRegistration();
            _hisregistration.HN= HN;
            BuildGetDataFromHIS();
        }

		public  HISRegistration	HISRegistration
		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}

		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}

		public void Build()
		{
            SqlParameter[] parameters ={ 
                       new SqlParameter("@REG_ID"  , HISRegistration.REG_ID),new SqlParameter("@HN" , HISRegistration.HN)
            };//,new SqlParameter("@REG_UID",HISRegistration.REG_UID),new SqlParameter("@TITLE",HISRegistration.TITLE),new SqlParameter("@REG_DT",HISRegistration.REG_DT),new SqlParameter("@FNAME",HISRegistration.FNAME)
            //,new SqlParameter("@MNAME",HISRegistration.MNAME),new SqlParameter("@LNAME",HISRegistration.LNAME),new SqlParameter("@TITLE_ENG",HISRegistration.TITLE_ENG),new SqlParameter("@FNAME_ENG",HISRegistration.FNAME_ENG),new SqlParameter("@MNAME_ENG",HISRegistration.MNAME_ENG)
            //,new SqlParameter("@LNAME_ENG",HISRegistration.LNAME_ENG),new SqlParameter("@SSN",HISRegistration.SSN),new SqlParameter("@DOB",HISRegistration.DOB),new SqlParameter("@AGE",HISRegistration.AGE),new SqlParameter("@ADDR1",HISRegistration.ADDR1)
            //,new SqlParameter("@ADDR2",HISRegistration.ADDR2),new SqlParameter("@ADDR3",HISRegistration.ADDR3),new SqlParameter("@ADDR4",HISRegistration.ADDR4),new SqlParameter("@ADDR5",HISRegistration.ADDR5),new SqlParameter("@PHONE1",HISRegistration.PHONE1)
            //,new SqlParameter("@PHONE2",HISRegistration.PHONE2),new SqlParameter("@PHONE3",HISRegistration.PHONE3),new SqlParameter("@EMAIL",HISRegistration.EMAIL),new SqlParameter("@GENDER",HISRegistration.GENDER),new SqlParameter("@MARITAL_STATUS",HISRegistration.MARITAL_STATUS)
            //,new SqlParameter("@OCCUPATION_ID",HISRegistration.OCCUPATION_ID),new SqlParameter("@NATIONALITY",HISRegistration.NATIONALITY),new SqlParameter("@PASSPORT_NO",HISRegistration.PASSPORT_NO),new SqlParameter("@BLOOD_GROUP",HISRegistration.BLOOD_GROUP),new SqlParameter("@RELIGEON",HISRegistration.RELIGEON)
            //,new SqlParameter("@PATIENT_TYPE",HISRegistration.PATIENT_TYPE),new SqlParameter("@EM_CONTACT_PERSON",HISRegistration.EM_CONTACT_PERSON),new SqlParameter("@EM_RELATION",HISRegistration.EM_RELATION),new SqlParameter("@EM_ADDR",HISRegistration.EM_ADDR),new SqlParameter("@EM_PHONE",HISRegistration.EM_PHONE)
            //,new SqlParameter("@INSURANCE_TYPE",HISRegistration.INSURANCE_TYPE),new SqlParameter("@HL7_FORMAT",HISRegistration.HL7_FORMAT),new SqlParameter("@HL7_SEND",HISRegistration.HL7_SEND),new SqlParameter("@ALLERGIES",HISRegistration.ALLERGIES),new SqlParameter("@ORG_ID",HISRegistration.ORG_ID)
            //,new SqlParameter("@CREATED_BY",HISRegistration.CREATED_BY),new SqlParameter("@CREATED_ON",HISRegistration.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",HISRegistration.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",HISRegistration.LAST_MODIFIED_ON)};
			Parameters = parameters;
		}
        public void BuildGetDataFromHIS() {
            SqlParameter[] parameters ={new SqlParameter("@HN"  , HISRegistration.HN)};
            Parameters = parameters;
        }
	}
}

