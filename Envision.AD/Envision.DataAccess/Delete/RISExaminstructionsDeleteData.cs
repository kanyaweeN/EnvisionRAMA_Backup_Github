using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_EXAMINSTRUCTIONDeleteData : DataAccessBase 
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }

        public RIS_EXAMINSTRUCTIONDeleteData()
		{
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONS_Delete;
		}
       
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@EXAM_ID",RIS_EXAMINSTRUCTION.INS_ID),
                                         Parameter("@EXAM_UID",RIS_EXAMINSTRUCTION.EXAM_ID)
                                     };
            return parameters;
        }
	}
}

