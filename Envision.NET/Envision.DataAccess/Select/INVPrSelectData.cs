using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVPrSelectData : DataAccessBase 
	{
        public INV_PR INV_PR { get; set; }
		public  INVPrSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_PR_Select;
            INV_PR = new INV_PR();
		}
		
		public DataSet GetData()
		{
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet SelectAll()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PR_SelectAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@PR_ID"   ,INV_PR.PR_ID),
                                       };
            return parameters;
        }
	}
}

