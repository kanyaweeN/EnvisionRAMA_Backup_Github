using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISExamresultlocksUpdateData : DataAccessBase 
	{
        public RIS_EXAMRESULTLOCK RIS_EXAMRESULTLOCK { get; set; }

		public  RISExamresultlocksUpdateData()
		{
            RIS_EXAMRESULTLOCK = new RIS_EXAMRESULTLOCK();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTLOCKS_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran)
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@ACCESSION_NO",RIS_EXAMRESULTLOCK.ACCESSION_NO)
,Parameter("@SL_NO",RIS_EXAMRESULTLOCK.SL_NO)
,Parameter("@IS_LOCKED",RIS_EXAMRESULTLOCK.IS_LOCKED)
,Parameter("@UNLOCKED_BY",RIS_EXAMRESULTLOCK.UNLOCKED_BY)
,Parameter("@ORG_ID",RIS_EXAMRESULTLOCK.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",RIS_EXAMRESULTLOCK.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

