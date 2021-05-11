using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISBpviewUpdateData : DataAccessBase 
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }

		public  RISBpviewUpdateData()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
			StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEW_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@BPVIEW_UID",RIS_BPVIEW.BPVIEW_UID)
//,Parameter("@BPVIEW_NAME",RIS_BPVIEW.BPVIEW_NAME)
//,Parameter("@BPVIEW_DESC",RIS_BPVIEW.BPVIEW_DESC)
//,Parameter("@NO_OF_EXAM",RIS_BPVIEW.NO_OF_EXAM)
//,Parameter("@IS_UPDATED",RIS_BPVIEW.IS_UPDATED)
//,Parameter("@IS_DELETED",RIS_BPVIEW.IS_DELETED)
//,Parameter("@ORG_ID",RIS_BPVIEW.ORG_ID)
//,Parameter("@CREATED_BY",RIS_BPVIEW.CREATED_BY)
//,Parameter("@CREATED_ON",RIS_BPVIEW.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",RIS_BPVIEW.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",RIS_BPVIEW.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

