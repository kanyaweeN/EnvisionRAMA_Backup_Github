using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class GBLHospitalSelectData : DataAccessBase 
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; }

		public  GBLHospitalSelectData()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
            StoredProcedureName = StoredProcedure.Prc_GBL_HOSPITAL_SelectAll;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetDataAll() {
            StoredProcedureName = StoredProcedure.Prc_GBL_HOSPITAL_SelectAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetMappingHosID() {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectDoctorMapping;
            DataSet ds = new DataSet();
            ParameterList = buildParameterHOSID();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
				                                     
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterHOSID()
        {
            DbParameter[] parameters = { 
				                              Parameter("@HOS_ID", GBL_HOSPITAL.HOS_ID)   
                                       };
            return parameters;
        }
	}
}

