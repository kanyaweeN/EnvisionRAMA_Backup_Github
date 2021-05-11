using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVPodtlSelectData : DataAccessBase 
	{
        public INV_PODTL INV_PODTL { get; set; }
		public  INVPodtlSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Select;
            INV_PODTL = new INV_PODTL();
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
                                          Parameter("@PO_ID"   ,INV_PODTL.PO_ID),
                                       };
            return parameters;
        }
	}
	
}

