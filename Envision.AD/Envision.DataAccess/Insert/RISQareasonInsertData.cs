using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISQareasonInsertData : DataAccessBase 
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }

        public RISQareasonInsertData()
		{
            RIS_QAREASON = new RIS_QAREASON();
            StoredProcedureName = StoredProcedure.Prc_RIS_QAREASON_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public bool Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={			
                Parameter("@REASON_UID",RIS_QAREASON.REASON_UID)
                ,Parameter("@REASON_TEXT",RIS_QAREASON.REASON_TEXT)
                ,Parameter("@REASON_ACTION",RIS_QAREASON.REASON_ACTION)
                ,Parameter("@ORG_ID",RIS_QAREASON.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_QAREASON.CREATED_BY)
			};
            return parameters;
        
        }
	}
}

