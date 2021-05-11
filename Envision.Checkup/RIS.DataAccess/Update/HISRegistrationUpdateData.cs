//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    28/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class HISRegistrationUpdateData : DataAccessBase 
	{
		private HISRegistration	_hisregistration;
		private HISRegistrationInsertDataParameters	_hisregistrationinsertdataparameters;
		public  HISRegistrationUpdateData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_HIS_REGISTRATION_UpdateByOrder.ToString();
		}
		public  HISRegistration	HISRegistration
		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}
		public void Update()
		{
			_hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_hisregistrationinsertdataparameters.Parameters);
		}
        public void Update(SqlTransaction tran) {
            try
            {
                _hisregistrationinsertdataparameters = new HISRegistrationInsertDataParameters(HISRegistration);
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                object id = dbhelper.RunScalar(tran, _hisregistrationinsertdataparameters.Parameters);
            }
            catch (Exception ex) { 
            
            }
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
            //@REG_ID
            SqlParameter pDOB = new SqlParameter();
            pDOB.ParameterName = "@DOB";
            if (HISRegistration.DOB == DateTime.MinValue)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HISRegistration.DOB;

            SqlParameter[] parameters ={
                new SqlParameter("@REG_ID",HISRegistration.REG_ID)
                ,new SqlParameter("@FNAME",HISRegistration.FNAME)
                ,new SqlParameter("@LNAME",HISRegistration.LNAME)
                ,new SqlParameter("@FNAME_ENG",HISRegistration.FNAME_ENG)
                ,new SqlParameter("@LNAME_ENG",HISRegistration.LNAME_ENG)
                ,new SqlParameter("@PHONE1",HISRegistration.PHONE1)
                ,new SqlParameter("@SSN",HISRegistration.SSN)
                ,pDOB
                ,new SqlParameter("@GENDER",HISRegistration.GENDER)
                ,new SqlParameter("@PATIENT_TYPE",HISRegistration.PATIENT_TYPE)
                ,new SqlParameter("@LINK_DOWN",HISRegistration.LINK_DOWN)
                ,new SqlParameter("@INSURANCE_TYPE",HISRegistration.INSURANCE_TYPE)
                ,new SqlParameter("@LAST_MODIFIED_BY",HISRegistration.LAST_MODIFIED_BY)
            };
			Parameters = parameters;
		}
	}
}

