using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISClinicalindicationtypeSelectData : DataAccessBase 
    {
        public RISClinicalindicationtypeSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPE_All;
        }

        public DataSet Get(int org_id, int emp_id)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(org_id, emp_id);
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter(int org_id, int emp_id)
        {
            DbParameter[] parameters = { 
                                             Parameter( "@ORG_ID"	        , org_id ),
                                             Parameter( "@EMP_ID"		    , emp_id ) ,
                                       };
            return parameters;
        }
    }
}
