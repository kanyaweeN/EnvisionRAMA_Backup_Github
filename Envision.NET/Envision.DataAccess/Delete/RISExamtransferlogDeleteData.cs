using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_EXAMTRANSFERLOGDeleteData : DataAccessBase 
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }

        public RIS_EXAMTRANSFERLOGDeleteData()
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTRANSFERLOG_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            //Parameter("@ACCESSION_NO",RIS_EXAMTRANSFERLOG.ACCESSION_NO),
                                            //Parameter("@SL_NO",RIS_EXAMTRANSFERLOG.SL_NO)
                                     };
            return parameters;
        }
	}
}

