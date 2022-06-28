using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class MIS_ASESSMENTTYPEDeleteData : DataAccessBase 
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }
        public MIS_ASESSMENTTYPEDeleteData()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
            StoredProcedureName = StoredProcedure.Prc_MIS_ASESSMENTTYPE_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Delete(DbTransaction tran) 
		{
			if (tran!=null)
			{
                Transaction = tran;
                ParameterList = buildParameter();
                ExecuteNonQuery();
			}
			else Delete();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                      //   Parameter("@ASESSMENT_TYPE_ID",MIS_ASESSMENTTYPE.ASESSMENT_TYPE_ID)
                                     };
            return parameters;
        }
	}
}

