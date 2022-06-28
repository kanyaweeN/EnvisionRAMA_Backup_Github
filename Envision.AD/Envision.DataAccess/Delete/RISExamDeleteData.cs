using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_EXAMDeleteData : DataAccessBase 
	{
        public RIS_EXAM RIS_EXAM { get; set; }

        public RIS_EXAMDeleteData()
		{
            RIS_EXAM = new RIS_EXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@EXAM_ID",RIS_EXAM.EXAM_ID)
                                     };
            return parameters;
        }
	}
}

