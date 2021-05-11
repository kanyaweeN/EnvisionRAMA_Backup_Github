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
    public class RIS_OPNOTEITEMTEMPLATEInsertData : DataAccessBase
    {
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }

        public RIS_OPNOTEITEMTEMPLATEInsertData()
        {
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEMTEMPLATE_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@OP_ITEM_ID",RIS_OPNOTEITEMTEMPLATE.OP_ITEM_ID)
                ,Parameter("@EXAM_ID",RIS_OPNOTEITEMTEMPLATE.EXAM_ID)
                ,Parameter("@ITEM_VALUE",RIS_OPNOTEITEMTEMPLATE.ITEM_VALUE)
                ,Parameter("@ITEM_UNIT",RIS_OPNOTEITEMTEMPLATE.ITEM_UNIT)
                ,Parameter("@OPNOTE_TYPE",RIS_OPNOTEITEMTEMPLATE.OPNOTE_TYPE)
                ,Parameter("@CREATED_BY",RIS_OPNOTEITEMTEMPLATE.CREATED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEMTEMPLATE.LAST_MODIFIED_BY)
			            };
            return parameters;
        }

    }
}


