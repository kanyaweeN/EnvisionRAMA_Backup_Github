using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLLookupSelectData : DataAccessBase
    {
        public GBLLookupSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_GBLLookup;
        }

        public DataSet Get(string qry)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(qry);
            ds = ExecuteDataSet();
            return ds;

        }
        private DbParameter[] buildParameter(string _qry)
        {
            DbParameter[] parameters ={			
                  Parameter( "@QRY"	, _qry )
			};
            return parameters;
        }
       
    }
}
