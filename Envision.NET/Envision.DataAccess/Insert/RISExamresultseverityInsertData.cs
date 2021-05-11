//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    21/05/2552 04:00:04
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExamresultseverityInsertData : DataAccessBase 
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
		public  RISExamresultseverityInsertData()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSEVERITY_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
//Parameter("@SEVERITY_UID",RIS_EXAMRESULTSEVERITY.SEVERITY_UID)
//,Parameter("@SEVERITY_NAME",RIS_EXAMRESULTSEVERITY.SEVERITY_NAME)
//,Parameter("@SEVERITY_DESC",RIS_EXAMRESULTSEVERITY.SEVERITY_DESC)
//,Parameter("@ORG_ID",RIS_EXAMRESULTSEVERITY.ORG_ID)
//,Parameter("@CREATED_BY",RIS_EXAMRESULTSEVERITY.CREATED_BY)
//,Parameter("@CREATED_ON",RIS_EXAMRESULTSEVERITY.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",RIS_EXAMRESULTSEVERITY.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",RIS_EXAMRESULTSEVERITY.LAST_MODIFIED_ON)
			            };
            return parameters;
        }
	}
}

