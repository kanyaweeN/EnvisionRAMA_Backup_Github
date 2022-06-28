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
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class HISRegistrationUpdateData : DataAccessBase 
	{
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

		public  HISRegistrationUpdateData()
		{
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateByOrder;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Update(DbTransaction tran) {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        public void UpdateAllergies()
        {
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateAllergies2;
            ParameterList = buildParameterAllergies();
            ExecuteNonQuery();
        }
        public void UpdateAllergies(DbTransaction tran)
        {
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateAllergies2;
            ParameterList = buildParameterAllergies();
            Transaction = tran;
            ExecuteNonQuery();
        }
        public void UpdateFromArrival()
        {
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateByOrder2;
            ParameterList = buildParameterFromArrival();
            ExecuteNonQuery();
        }
        public void UpdateFromArrival(DbTransaction tran)
        {
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateByOrder2;
            ParameterList = buildParameterFromArrival();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter pDOB = Parameter();
            pDOB.ParameterName = "@DOB";
            if (HIS_REGISTRATION.DOB == null)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HIS_REGISTRATION.DOB == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.DOB;

            DbParameter[] parameters ={
                Parameter("@REG_ID",HIS_REGISTRATION.REG_ID)
                ,Parameter("@FNAME",HIS_REGISTRATION.FNAME)
                ,Parameter("@LNAME",HIS_REGISTRATION.LNAME)
                ,Parameter("@FNAME_ENG",HIS_REGISTRATION.FNAME_ENG)
                ,Parameter("@LNAME_ENG",HIS_REGISTRATION.LNAME_ENG)
                ,Parameter("@TITLE",HIS_REGISTRATION.TITLE)
                ,Parameter("@TITLE_ENG",HIS_REGISTRATION.TITLE_ENG)
                ,Parameter("@PHONE1",HIS_REGISTRATION.PHONE1)
                ,Parameter("@SSN",HIS_REGISTRATION.SSN)
                ,pDOB
                ,Parameter("@GENDER",HIS_REGISTRATION.GENDER)
                ,Parameter("@PATIENT_TYPE",HIS_REGISTRATION.PATIENT_TYPE)
                ,Parameter("@LINK_DOWN",HIS_REGISTRATION.LINK_DOWN)
                ,Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
                ,Parameter("@LAST_MODIFIED_BY",HIS_REGISTRATION.LAST_MODIFIED_BY)
                ,Parameter("@IS_JOHNDOE",HIS_REGISTRATION.IS_JOHNDOE)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterAllergies()
        {
            DbParameter[] parameters ={
                Parameter("@HN",HIS_REGISTRATION.HN)
                ,Parameter("@LAST_MODIFIED_BY",HIS_REGISTRATION.LAST_MODIFIED_BY)
                ,Parameter("@ALLERGIES",HIS_REGISTRATION.ALLERGIES)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterFromArrival()
        {
            DbParameter pDOB = Parameter();
            pDOB.ParameterName = "@DOB";
            if (HIS_REGISTRATION.DOB == null)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HIS_REGISTRATION.DOB == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.DOB;

            DbParameter[] parameters ={
                Parameter("@REG_ID",HIS_REGISTRATION.REG_ID)
                ,Parameter("@FNAME",HIS_REGISTRATION.FNAME)
                ,Parameter("@LNAME",HIS_REGISTRATION.LNAME)
                ,Parameter("@FNAME_ENG",HIS_REGISTRATION.FNAME_ENG)
                ,Parameter("@LNAME_ENG",HIS_REGISTRATION.LNAME_ENG)
                ,Parameter("@TITLE",HIS_REGISTRATION.TITLE)
                ,Parameter("@TITLE_ENG",HIS_REGISTRATION.TITLE_ENG)
                ,Parameter("@PHONE1",HIS_REGISTRATION.PHONE1)
                ,Parameter("@SSN",HIS_REGISTRATION.SSN)
                ,pDOB
                ,Parameter("@GENDER",HIS_REGISTRATION.GENDER)
                ,Parameter("@PATIENT_TYPE",HIS_REGISTRATION.PATIENT_TYPE)
                ,Parameter("@LINK_DOWN",HIS_REGISTRATION.LINK_DOWN)
                ,Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
                ,Parameter("@LAST_MODIFIED_BY",HIS_REGISTRATION.LAST_MODIFIED_BY)
                ,Parameter("@IS_JOHNDOE",HIS_REGISTRATION.IS_JOHNDOE)
                ,Parameter("@ALLERGIES",HIS_REGISTRATION.ALLERGIES)
                                      };
            return parameters;
        }
	}
}

