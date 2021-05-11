using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVPrdtlSelectData : DataAccessBase 
	{
        public INV_PRDTL INV_PRDTL { get; set; }
		public  INVPrdtlSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Select;
            INV_PRDTL = new INV_PRDTL();
		}
		public DataSet GetData()
		{
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@PR_ID"   ,INV_PRDTL.PR_ID),
                                       };
            return parameters;
        }
	}
}

