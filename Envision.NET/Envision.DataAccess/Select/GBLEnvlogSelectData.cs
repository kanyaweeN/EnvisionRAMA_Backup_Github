using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class GBLEnvlogSelectData : DataAccessBase 
	{
        public GBL_ENVLOG GBL_ENVLOG { get; set; }

		public  GBLEnvlogSelectData()
		{
            GBL_ENVLOG = new GBL_ENVLOG();
            StoredProcedureName = StoredProcedure.Prc_GBL_ENVLOG_Select;
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
                                             Parameter( "@FROMDATE"	        , GBL_ENVLOG.FROM_DATE ),
                                             Parameter( "@TODATE"		    , GBL_ENVLOG.TO_DATE ) ,
                                       };
            return parameters;
        }
	}
}

