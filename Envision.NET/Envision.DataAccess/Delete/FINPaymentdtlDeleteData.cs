using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class FIN_PAYMENTDTLDeleteData : DataAccessBase 
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }

        public FIN_PAYMENTDTLDeleteData()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
            StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENTDTL_Delete;
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
                                         //Parameter("@PAY_ID",FIN_PAYMENTDTL.PAY_ID)
                                        //,Parameter("@EXAM_ID",FIN_PAYMENTDTL.EXAM_ID)
                                       };
            return parameters;
        }
	}
}

