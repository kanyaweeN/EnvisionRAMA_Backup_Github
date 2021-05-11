using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ScheduleCatagorySelectData : DataAccessBase
    {
        public GBL_EMPSCHEDULECATEGORY GBL_EMPSCHEDULECATEGORY { get; set; }
        public ScheduleCatagorySelectData()
        {
            GBL_EMPSCHEDULECATEGORY = new GBL_EMPSCHEDULECATEGORY();
            StoredProcedureName = StoredProcedure.Prc_EmployeeScheduleCatagory;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter( "@SP_TYPE"	, GBL_EMPSCHEDULECATEGORY.SpType ),
                Parameter( "@CATEGORY_ID"	, GBL_EMPSCHEDULECATEGORY.CATEGORY_ID ),
				Parameter( "@ORG_ID"	, GBL_EMPSCHEDULECATEGORY.OrgID )
			};
            return parameters;
        }
    }
}
