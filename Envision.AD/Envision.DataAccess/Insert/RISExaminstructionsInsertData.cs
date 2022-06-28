//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExaminstructionsInsertData : DataAccessBase 
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
		public  RISExaminstructionsInsertData()
		{
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONS_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_TYPE_ID",RIS_EXAMINSTRUCTION.EXAM_TYPE_ID),
                Parameter("@EXAM_ID",RIS_EXAMINSTRUCTION.EXAM_ID),
                Parameter("@INS_UID",RIS_EXAMINSTRUCTION.EXAM_ID),
                Parameter("@INS_TEXT",RIS_EXAMINSTRUCTION.INS_TEXT),
                Parameter("@INHERIT_GROUP",DBNull.Value),
                Parameter("@IS_UPDATED",DBNull.Value),
                Parameter("@IS_DELETED",DBNull.Value),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                Parameter("@CREATED_BY",new GBLEnvVariable().UserID),
                Parameter("@CREATED_ON",DateTime.Now),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                Parameter("@LAST_MODIFIED_ON",DateTime.Now)
			            };
            return parameters;
        }
	}
}
