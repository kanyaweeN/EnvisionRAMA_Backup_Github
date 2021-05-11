using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVRequisitiondtlSelectData : DataAccessBase
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
		public  INVRequisitiondtlSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Select;
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
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
                                          Parameter("@REQUISITION_ID"   ,INV_REQUISITIONDTL.REQUISITION_ID),
                                       };
            return parameters;
        }
	}
}

