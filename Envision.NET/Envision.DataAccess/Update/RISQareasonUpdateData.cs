using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISQareasonUpdateData : DataAccessBase 
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }

		public  RISQareasonUpdateData()
		{
            RIS_QAREASON = new RIS_QAREASON();
			StoredProcedureName = StoredProcedure.Prc_RIS_QAREASON_Update;
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
                Parameter("@REASON_ID",RIS_QAREASON.REASON_ID)
                ,Parameter("@REASON_UID",RIS_QAREASON.REASON_UID)
                ,Parameter("@REASON_TEXT",RIS_QAREASON.REASON_TEXT)
                ,Parameter("@REASON_ACTION",RIS_QAREASON.REASON_ACTION)
                ,Parameter("@ORG_ID",RIS_QAREASON.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_QAREASON.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

