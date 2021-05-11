//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class MISTechniquetypeInsertData : DataAccessBase 
	{
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
		public  MISTechniquetypeInsertData()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
			StoredProcedureName = StoredProcedure.Prc_MIS_TECHNIQUETYPE_Insert;
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
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
//Parameter("@TECHNIQUE_TYPE_UID",MIS_TECHNIQUETYPE.TECHNIQUE_TYPE_UID)
//,Parameter("@TECHNIQUE_TYPE_DESC",MIS_TECHNIQUETYPE.TECHNIQUE_TYPE_DESC)
//,Parameter("@ORG_ID",MIS_TECHNIQUETYPE.ORG_ID)
//,Parameter("@CREATED_BY",MIS_TECHNIQUETYPE.CREATED_BY)
//,Parameter("@CREATED_ON",MIS_TECHNIQUETYPE.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",MIS_TECHNIQUETYPE.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",MIS_TECHNIQUETYPE.LAST_MODIFIED_ON)
			            };
            return parameters;
        }
	}
}

