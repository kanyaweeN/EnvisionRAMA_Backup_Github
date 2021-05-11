using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISModalityUpdateData : DataAccessBase 
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }

		public  RISModalityUpdateData()
		{
            RIS_MODALITY = new RIS_MODALITY();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@MODALITY_ID",RIS_MODALITY.MODALITY_ID),
                Parameter("@MODALITY_UID",RIS_MODALITY.MODALITY_UID),
                Parameter("@MODALITY_NAME",RIS_MODALITY.MODALITY_NAME),
                Parameter("@MODALITY_TYPE",RIS_MODALITY.MODALITY_TYPE),
                Parameter("@UNIT_ID",RIS_MODALITY.UNIT_ID),
                Parameter("@IS_ACTIVE",RIS_MODALITY.IS_ACTIVE),
                Parameter("@ROOM_ID",RIS_MODALITY.ROOM_ID),
                Parameter("@IS_UPDATED",RIS_MODALITY.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_MODALITY.IS_DELETED),
                Parameter("@ORG_ID",RIS_MODALITY.ORG_ID),
                Parameter("@LAST_MODIFIED_BY",RIS_MODALITY.LAST_MODIFIED_BY),
                Parameter("@PAT_DEST_ID",RIS_MODALITY.PAT_DEST_ID),
                                      };
            return parameters;
        }
	}
}

