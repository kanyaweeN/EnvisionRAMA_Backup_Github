using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class HISDepartmentSelectData : DataAccessBase 
	{
        private HISDepartment HISDepartment { get; set; }

		public  HISDepartmentSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_HIS_DEPARTMENT_Select;
            HISDepartment=new HISDepartment();
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@DEP_ID",HISDepartment.DEP_ID)
                                                    , Parameter("@DEP_NAME",HISDepartment.DEP_NAME)
                                                    , Parameter("@DEP_TEL",HISDepartment.DEP_TEL)
                                       };
            return parameters;
        }
	}
}

