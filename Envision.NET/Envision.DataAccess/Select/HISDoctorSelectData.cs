using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class HISDoctorSelectData : DataAccessBase 
	{
        
		public  HISDoctor	HISDoctor{get;set;}
		public  HISDoctorSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectDoctor;
            HISDoctor = new HISDoctor();
		}

        public DataSet GetDataByID(int EMP_ID)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectDoctorByID;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@EMP_ID",EMP_ID)
            };
            ds = ExecuteDataSet();
            return ds;
        }
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@DOC_ID",HISDoctor.DOC_ID)
                                                    , Parameter("@FNAME",HISDoctor.FNAME)
                                                    , Parameter("@MNAME",HISDoctor.MNAME)
                                                    , Parameter("@LNAME",HISDoctor.LNAME)
                                       };
            return parameters;
        }
	}
}

