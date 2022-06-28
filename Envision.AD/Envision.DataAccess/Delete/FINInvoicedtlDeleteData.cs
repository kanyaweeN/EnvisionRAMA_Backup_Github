using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class FIN_INVOICEDTLDeleteData : DataAccessBase 
	{
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }

		public  FIN_INVOICEDTLDeleteData()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
            StoredProcedureName = StoredProcedure.Prc_FIN_INVOICEDTL_Delete;
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
                                             //Parameter("@INV_ID",FIN_INVOICEDTL.INV_ID)
                                            //,Parameter("@EXAM_ID",FIN_INVOICEDTL.EXAM_ID)
                                       };
            return parameters;
        }
	}
}

