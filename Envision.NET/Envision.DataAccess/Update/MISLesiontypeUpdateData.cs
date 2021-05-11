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

namespace Envision.DataAccess.Update
{
	public class MISLesiontypeUpdateData : DataAccessBase 
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }

		public  MISLesiontypeUpdateData()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
			StoredProcedureName = StoredProcedure.Prc_MIS_LESIONTYPE_Update;
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
//Parameter("@LESION_TYPE_UID",MIS_LESIONTYPE.LESION_TYPE_UID)
//,Parameter("@LESION_TYPE_DESC",MIS_LESIONTYPE.LESION_TYPE_DESC)
//,Parameter("@ORG_ID",MIS_LESIONTYPE.ORG_ID)
//,Parameter("@CREATED_BY",MIS_LESIONTYPE.CREATED_BY)
//,Parameter("@CREATED_ON",MIS_LESIONTYPE.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",MIS_LESIONTYPE.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",MIS_LESIONTYPE.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

