using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_ORDERDTLDeleteData : DataAccessBase 
	{
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }

        public RIS_ORDERDTLDeleteData()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@ORDER_ID", RIS_ORDERDTL.ORDER_ID) ,
                                            Parameter("@EXAM_ID", RIS_ORDERDTL.EXAM_ID)
                                       };
            return parameters;
        }
	}
}

