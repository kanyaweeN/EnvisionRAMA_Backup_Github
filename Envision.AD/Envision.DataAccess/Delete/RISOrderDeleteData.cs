using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_ORDERDeleteData : DataAccessBase 
	{
        public RIS_ORDER RIS_ORDER { get; set; }

        public RIS_ORDERDeleteData()
		{
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Delete;
		}
	
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Delete(DbTransaction tran)
        {
            if (tran == null)
            {
                ParameterList = buildParameter();
                ExecuteNonQuery();
            }
            else
            {
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
            }
        }
        private DbParameter[] buildParameter() {
            DbParameter[] parameters={Parameter("@ORDER_ID",RIS_ORDER.ORDER_ID)};
            return parameters;
        }
	}
}

