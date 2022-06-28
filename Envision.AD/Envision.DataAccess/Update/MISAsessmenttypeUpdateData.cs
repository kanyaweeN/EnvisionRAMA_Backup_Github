//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:23
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class MISAsessmenttypeUpdateData : DataAccessBase 
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }

		public  MISAsessmenttypeUpdateData()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
			StoredProcedureName = StoredProcedure.Prc_MIS_ASESSMENTTYPE_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@ASESSMENT_TYPE_UID",MIS_ASESSMENTTYPE.ASESSMENT_TYPE_UID)
//,Parameter("@ASESSMENT_TYPE_DESC",MIS_ASESSMENTTYPE.ASESSMENT_TYPE_DESC)
//,Parameter("@ORG_ID",MIS_ASESSMENTTYPE.ORG_ID)
//,Parameter("@CREATED_BY",MIS_ASESSMENTTYPE.CREATED_BY)
//,Parameter("@CREATED_ON",MIS_ASESSMENTTYPE.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",MIS_ASESSMENTTYPE.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",MIS_ASESSMENTTYPE.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

