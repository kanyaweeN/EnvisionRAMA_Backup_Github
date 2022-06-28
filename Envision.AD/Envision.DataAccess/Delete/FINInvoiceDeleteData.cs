using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class FIN_INVOICEDeleteData : DataAccessBase 
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }

        public FIN_INVOICEDeleteData()
		{
            FIN_INVOICE = new FIN_INVOICE();
            StoredProcedureName = StoredProcedure.Prc_FIN_INVOICE_Delete;
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
                                           //Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID) 
                                       };
            return parameters;
        }
	}
}

