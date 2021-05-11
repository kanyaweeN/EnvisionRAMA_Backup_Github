using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class FIN_PAYMENTDeleteData : DataAccessBase 
	{
        public FIN_PAYMENT FIN_PAYMENT { get; set; }

        public FIN_PAYMENTDeleteData()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
            StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENT_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Delete(DbTransaction tran) 
		{
			if (tran!=null)
			{
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			}
			else Delete();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          //Parameter("@PAY_ID",FIN_PAYMENT.PAY_ID)
                                       };
            return parameters;
        }
	}
}

