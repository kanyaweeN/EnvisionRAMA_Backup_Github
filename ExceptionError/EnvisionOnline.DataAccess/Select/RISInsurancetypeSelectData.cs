using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISInsurancetypeSelectData : DataAccessBase
    {
        public RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }
        public RISInsurancetypeSelectData()
        {
            RIS_INSURANCETYPE = new RIS_INSURANCETYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_INSURANCETYPE_SelectAll;
        }

        public DataSet GetData(int org_id)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(org_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int org_id)
        {
            DbParameter[] parameters ={			
                //Parameter("@ORG_ID", org_id)
			};
            return parameters;
        }
    }
}

