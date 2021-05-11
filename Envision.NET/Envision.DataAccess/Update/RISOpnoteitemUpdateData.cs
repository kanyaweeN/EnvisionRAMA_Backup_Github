using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISOpnoteitemUpdateData : DataAccessBase 
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }

		public  RISOpnoteitemUpdateData()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
			StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEM_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@OP_ITEM_ID",RIS_OPNOTEITEM.OP_ITEM_ID)
,Parameter("@OP_ITEM_UID",RIS_OPNOTEITEM.OP_ITEM_UID)
,Parameter("@OP_ITEM_NAME",RIS_OPNOTEITEM.OP_ITEM_NAME)
,Parameter("@UNIT_ID",RIS_OPNOTEITEM.UNIT_ID)
,Parameter("@IS_ACTIVE",RIS_OPNOTEITEM.IS_ACTIVE)
,Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEM.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

