using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExaminstructionsSelectData : DataAccessBase
    {
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
        private int _action;

        public RISExaminstructionsSelectData(RIS_EXAMINSTRUCTION common, int action)
		{
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONS_Select;
            RIS_EXAMINSTRUCTION = common;
            _action = action;
        }
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                             Parameter("@SP_TYPE",_action),
                                             Parameter("@INS_UID",RIS_EXAMINSTRUCTION.INS_UID),
                                             Parameter("@EXAM_UID",RIS_EXAMINSTRUCTION.EXAM_UID),
                                             Parameter("@IS_DELETED","N"),
                                             Parameter("@ORG_ID",RIS_EXAMINSTRUCTION.ORG_ID),
                                             Parameter("@EXAM_ID",RIS_EXAMINSTRUCTION.EXAM_ID)
                                       };
            return parameters;
        }
	}
}

