using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISExaminstructionsUpdateData : DataAccessBase 
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }

		public  RISExaminstructionsUpdateData()
		{
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONS_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@SP_TYPE",RIS_EXAMINSTRUCTION.SP_TYPE),
                Parameter("@INS_ID",RIS_EXAMINSTRUCTION.INS_ID),
                Parameter("@UNIT_ID",RIS_EXAMINSTRUCTION.UNIT_ID),
                Parameter("@UNIT_INS",RIS_EXAMINSTRUCTION.UNIT_INS),
                Parameter("@EXAM_TYPE_ID",RIS_EXAMINSTRUCTION.EXAM_TYPE_ID),
                Parameter("@EXAM_TYPE_INS",RIS_EXAMINSTRUCTION.EXAM_TYPE_INS),
                Parameter("@EXAM_TYPE_INS_KID",RIS_EXAMINSTRUCTION.EXAM_TYPE_INS_KID),
                Parameter("@INS_TEXT",RIS_EXAMINSTRUCTION.INS_TEXT),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

