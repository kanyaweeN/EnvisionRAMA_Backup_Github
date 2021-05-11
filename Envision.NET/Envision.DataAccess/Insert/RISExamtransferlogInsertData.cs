//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    27/05/2552 03:41:44
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExamtransferlogInsertData : DataAccessBase 
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }
		public  RISExamtransferlogInsertData()
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTRANSFERLOG_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@ACCESSION_NO",RIS_EXAMTRANSFERLOG.ACCESSION_NO)
,Parameter("@FROM_RAD",RIS_EXAMTRANSFERLOG.FROM_RAD)
,Parameter("@TO_RAD",RIS_EXAMTRANSFERLOG.TO_RAD)
,Parameter("@STATUS",RIS_EXAMTRANSFERLOG.STATUS)
,Parameter("@ORG_ID",RIS_EXAMTRANSFERLOG.ORG_ID)
,Parameter("@CREATED_BY",RIS_EXAMTRANSFERLOG.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",RIS_EXAMTRANSFERLOG.LAST_MODIFIED_BY)
			            };
            return parameters;
        }
	}
}

