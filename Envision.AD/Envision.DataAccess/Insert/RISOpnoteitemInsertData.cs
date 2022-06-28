//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    02/03/2552 02:02:06
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RIS_OPNOTEITEMInsertData : DataAccessBase
    {
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
        public RIS_OPNOTEITEMInsertData()
        {
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
            StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEM_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@OP_ITEM_UID",RIS_OPNOTEITEM.OP_ITEM_UID)
,Parameter("@OP_ITEM_NAME",RIS_OPNOTEITEM.OP_ITEM_NAME)
,Parameter("@UNIT_ID",RIS_OPNOTEITEM.UNIT_ID)
,Parameter("@IS_ACTIVE",RIS_OPNOTEITEM.IS_ACTIVE)
,Parameter("@CREATED_BY",RIS_OPNOTEITEM.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEM.LAST_MODIFIED_BY)
			            };
            return parameters;
        }
    }
}

