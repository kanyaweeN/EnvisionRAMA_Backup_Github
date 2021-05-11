//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    27/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class HISRegistrationInsertData : DataAccessBase 
	{
		private HISRegistration	_hisregistration;
		private HISRegistrationInsertDataParameters	_hisregistrationinsertdataparameters;
        private int action;

		public HISRegistrationInsertData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_Insert.ToString();
            action = 0;
		}
        public HISRegistrationInsertData(bool linkdown)
        {
            if (linkdown)
            {
                StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_InsertByLinkDown.ToString();
                action = 1;
            }
            else
            {
                StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_InsertOrUpdateFromHIS.ToString();
                action = 2;
            }
        }

		public  HISRegistration	HISRegistration
		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}
		public int Add()
		{
            int retValue = 0;
            try
            {
                if (action == 0)
                    _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration);
                else if (action == 1)
                    _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration, 0, true);
                else if (action == 2)
                    _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration, 0, false);
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                dbhelper.Run(_hisregistrationinsertdataparameters.Parameters);
                retValue = _hisregistrationinsertdataparameters.Parameters[0].Value.ToString()==string.Empty  ||_hisregistrationinsertdataparameters.Parameters[0].Value.ToString()== null ? 0: Convert.ToInt32(_hisregistrationinsertdataparameters.Parameters[0].Value);
            }
            catch (Exception ex) { 
            
            }
            return retValue;
		}
        public int Add(SqlTransaction tran)
        {
           
            _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _hisregistrationinsertdataparameters.Parameters);
            return (int)_hisregistrationinsertdataparameters.Parameters[0].Value;
        }

        public int CheckHISData(HISRegistration his)//(string HN)
        {
            int retValue = 0;
            try{

            _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(his,true);
            StoredProcedureName = StoredProcedure.Name.Prc_HIS_InsertFromHIS.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(_hisregistrationinsertdataparameters.Parameters);
             retValue = Convert.ToInt32(_hisregistrationinsertdataparameters.Parameters[0].Value);

            }
            catch(Exception ex){
                string s=ex.Message;
            }
            return retValue;
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
        public HISRegistrationInsertDataParameters(HISRegistration hisregistration,int regID,bool linkdown)
        {
            HISRegistration = hisregistration;
            if (linkdown)
                BuildByLinkDown(hisregistration);
            else
                BuildInsertOrUpdate(hisregistration);
        }
        public HISRegistrationInsertDataParameters(HISRegistration hisregistration,bool flag)
        {
            //_hisregistration = new HISRegistration();
            //_hisregistration.HN = HN;
            //BuildByHIS(HN);
            _hisregistration = hisregistration;
            BuildByHIS(_hisregistration);
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
            SqlParameter pREG_ID = new SqlParameter();
            pREG_ID.ParameterName = "@REG_ID";
            if (HISRegistration.REG_ID == 0)
                pREG_ID.Value = DBNull.Value;
            else
                pREG_ID.Value = HISRegistration.REG_ID;
            pREG_ID.Direction = ParameterDirection.Output;

            SqlParameter pREG_DT = new SqlParameter();
            pREG_DT.ParameterName = "@REG_DT";
            if (HISRegistration.REG_DT == DateTime.MinValue)
                pREG_DT.Value = DBNull.Value;
            else
                pREG_DT.Value = HISRegistration.REG_DT;


            SqlParameter pDOB = new SqlParameter();
            pDOB.ParameterName = "@DOB";
            if (HISRegistration.DOB == DateTime.MinValue)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HISRegistration.DOB;

            SqlParameter pOCCUPATION_ID = new SqlParameter();
            pOCCUPATION_ID.ParameterName = "@OCCUPATION_ID";
            if (HISRegistration.OCCUPATION_ID == 0)
                pOCCUPATION_ID.Value = DBNull.Value;
            else
                pOCCUPATION_ID.Value = HISRegistration.OCCUPATION_ID;

			SqlParameter[] parameters ={
                pREG_ID
                ,new SqlParameter("@HN",HISRegistration.HN)
                ,new SqlParameter("@TITLE",HISRegistration.TITLE)
                ,pREG_DT
                ,new SqlParameter("@FNAME",HISRegistration.FNAME)

                ,new SqlParameter("@MNAME",HISRegistration.MNAME)
                ,new SqlParameter("@LNAME",HISRegistration.LNAME)
                ,new SqlParameter("@TITLE_ENG",HISRegistration.TITLE_ENG)
                ,new SqlParameter("@FNAME_ENG",HISRegistration.FNAME_ENG)
                ,new SqlParameter("@MNAME_ENG",HISRegistration.MNAME_ENG)

                ,new SqlParameter("@LNAME_ENG",HISRegistration.LNAME_ENG)
                ,new SqlParameter("@SSN",HISRegistration.SSN)
                ,pDOB
                ,new SqlParameter("@AGE",HISRegistration.AGE)
                ,new SqlParameter("@ADDR1",HISRegistration.ADDR1)

                ,new SqlParameter("@ADDR2",HISRegistration.ADDR2)
                ,new SqlParameter("@ADDR3",HISRegistration.ADDR3)
                ,new SqlParameter("@ADDR4",HISRegistration.ADDR4)
                ,new SqlParameter("@ADDR5",HISRegistration.ADDR5)
                ,new SqlParameter("@PHONE1",HISRegistration.PHONE1)

                ,new SqlParameter("@PHONE2",HISRegistration.PHONE2)
                ,new SqlParameter("@PHONE3",HISRegistration.PHONE3)
                ,new SqlParameter("@EMAIL",HISRegistration.EMAIL)
                ,new SqlParameter("@GENDER",HISRegistration.GENDER)
                ,new SqlParameter("@MARITAL_STATUS",HISRegistration.MARITAL_STATUS)

                ,pOCCUPATION_ID
                ,new SqlParameter("@NATIONALITY",HISRegistration.NATIONALITY)
                ,new SqlParameter("@PASSPORT_NO",HISRegistration.PASSPORT_NO)
                ,new SqlParameter("@BLOOD_GROUP",HISRegistration.BLOOD_GROUP)
                ,new SqlParameter("@RELIGEON",HISRegistration.RELIGEON)

                ,new SqlParameter("@PATIENT_TYPE",HISRegistration.PATIENT_TYPE)
                ,new SqlParameter("@EM_CONTACT_PERSON",HISRegistration.EM_CONTACT_PERSON)
                ,new SqlParameter("@EM_RELATION",HISRegistration.EM_RELATION)
                ,new SqlParameter("@EM_ADDR",HISRegistration.EM_ADDR)
                ,new SqlParameter("@EM_PHONE",HISRegistration.EM_PHONE)

                ,new SqlParameter("@INSURANCE_TYPE",HISRegistration.INSURANCE_TYPE)
                ,new SqlParameter("@HL7_FORMAT",HISRegistration.HL7_FORMAT)
                ,new SqlParameter("@HL7_SEND",HISRegistration.HL7_SEND)
                ,new SqlParameter("@LINK_DOWN",HISRegistration.LINK_DOWN)
                ,new SqlParameter("@ALLERGIES",HISRegistration.ALLERGIES)

                ,new SqlParameter("@ORG_ID",HISRegistration.ORG_ID)
                ,new SqlParameter("@CREATED_BY",HISRegistration.CREATED_BY)
            };
			Parameters = parameters;
		}
        public void BuildByHIS(HISRegistration his)//(string HN)
        {
            //SqlParameter param = new SqlParameter("@REG_ID", 0);
            //param.Direction = ParameterDirection.Output;
            
            // SqlParameter[] parameters ={
            //     param
            //     ,new SqlParameter("@HN",HN)
            //};
            //Parameters = parameters;

            SqlParameter pREG_ID = new SqlParameter("@REG_ID", his.REG_ID);
            pREG_ID.Direction = ParameterDirection.Output;

            SqlParameter pHN = new SqlParameter("@HN", his.HN);
            SqlParameter pRHN = new SqlParameter("@RHN", his.REG_ID.ToString());
            SqlParameter pTITLE_ENG = new SqlParameter("@TITLE_ENG", his.TITLE_ENG);
            SqlParameter pFNAME_ENG = new SqlParameter("@FNAME_ENG", his.FNAME_ENG);
            SqlParameter pLNAME_ENG = new SqlParameter("@LNAME_ENG", his.LNAME_ENG);
            SqlParameter pTEL = new SqlParameter("@TEL", his.PHONE1);
            SqlParameter[] parameters ={
                    pREG_ID
                    ,pHN 
                    ,pRHN
                    ,pTITLE_ENG
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pTEL
            };
            Parameters = parameters;
        }
        public void BuildByLinkDown(HISRegistration his) {
            SqlParameter pREG_ID = new SqlParameter("@REG_ID", 0);
            pREG_ID.Direction = ParameterDirection.Output;
            SqlParameter pHN = new SqlParameter("@HN", his.HN);
            SqlParameter pREG_DT    = new SqlParameter("@REG_DT", his.REG_DT);
            if (his.REG_DT == DateTime.MinValue)
                pREG_DT.Value = null;
            SqlParameter pFNAME     = new SqlParameter("@FNAME", his.FNAME);
            SqlParameter pLNAME     = new SqlParameter("@LNAME", his.LNAME);
            SqlParameter pFNAME_ENG = new SqlParameter("@FNAME_ENG", his.FNAME_ENG);
            SqlParameter pLNAME_ENG = new SqlParameter("@LNAME_ENG", his.LNAME_ENG);
            SqlParameter pSSN = new SqlParameter("@SSN", his.SSN);
            SqlParameter pDOB = new SqlParameter("@DOB", his.DOB);
            if (his.DOB == DateTime.MinValue)
                pDOB.Value = DBNull.Value;
            SqlParameter pPHONE1 = new SqlParameter("@PHONE1", his.PHONE1);
            SqlParameter pGENDER = new SqlParameter("@GENDER", his.GENDER);
            SqlParameter pCREATED_BY = new SqlParameter("@CREATED_BY", his.CREATED_BY);
            //SqlParameter pIS_JOHNDOE = new SqlParameter("@IS_JOHNDOE", his.IS_JOHNDOE);
            SqlParameter[] parameters ={
                    pREG_ID
                    ,pHN
                    ,pREG_DT
                    ,pFNAME
                    ,pLNAME
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pSSN
                    ,pDOB
                    ,pPHONE1
                    ,pGENDER
                    ,pCREATED_BY
                    //,pIS_JOHNDOE
            };
            Parameters = parameters;
        }
        public void BuildInsertOrUpdate(HISRegistration his) {
            SqlParameter pREG_ID = new SqlParameter("@REG_ID", 0);
            pREG_ID.Direction = ParameterDirection.Output;
            SqlParameter pHN = new SqlParameter("@HN", his.HN);
            SqlParameter pTITLE = new SqlParameter("@TITLE", his.TITLE);
            SqlParameter pFNAME = new SqlParameter("@FNAME", his.FNAME);
            SqlParameter pLNAME = new SqlParameter("@LNAME", his.LNAME);
            SqlParameter pTITLE_ENG = new SqlParameter("@TITLE_ENG", his.TITLE_ENG);
            SqlParameter pFNAME_ENG = new SqlParameter("@FNAME_ENG", his.FNAME_ENG);
            SqlParameter pLNAME_ENG = new SqlParameter("@LNAME_ENG", his.LNAME_ENG);
            SqlParameter pSSN = new SqlParameter("@SSN", his.SSN);
            SqlParameter pDOB = new SqlParameter("@DOB", his.DOB);
            if (his.DOB == DateTime.MinValue)
                pDOB.Value = DBNull.Value;
            SqlParameter pADDR1 = new SqlParameter("@ADDR1", his.ADDR1);
            SqlParameter pPHONE1 = new SqlParameter("@PHONE1", his.PHONE1);

            SqlParameter pGENDER = new SqlParameter("@GENDER", his.GENDER);
            SqlParameter pCREATED_BY = new SqlParameter("@CREATED_BY", his.CREATED_BY);
            SqlParameter[] parameters ={
                    pREG_ID
                    ,pHN
                    ,pTITLE
                    ,pFNAME
                    ,pLNAME
                    ,pTITLE_ENG
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pSSN
                    ,pDOB
                    ,pADDR1
                    ,new SqlParameter("@ADDR2",his.ADDR2)
                    ,new SqlParameter("@ADDR3",his.ADDR3)
                    ,new SqlParameter("@ADDR4",his.ADDR4)
                    ,pPHONE1
                    ,new SqlParameter("@PHONE2",his.PHONE2)
                    ,new SqlParameter("@PHONE3",his.PHONE3)
                    ,new SqlParameter("@EMAIL",his.EMAIL)
                    ,pGENDER
                    ,new SqlParameter("@NATIONALITY",his.NATIONALITY)
                    ,new SqlParameter("@EM_CONTACT_PERSON",his.EM_CONTACT_PERSON)
                    ,new SqlParameter("@INSURANCE_TYPE",his.INSURANCE_TYPE)
                    ,new SqlParameter("@ORG_ID",his.ORG_ID)
                    ,pCREATED_BY
            };
            Parameters = parameters;
        }
	}
}

