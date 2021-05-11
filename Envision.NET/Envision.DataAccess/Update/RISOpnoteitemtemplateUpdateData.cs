using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISOpnoteitemtemplateUpdateData : DataAccessBase 
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }

		public  RISOpnoteitemtemplateUpdateData()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
			StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEMTEMPLATE_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@OP_ITEM_ID",RIS_OPNOTEITEMTEMPLATE.OP_ITEM_ID)
//,Parameter("@EXAM_ID",RIS_OPNOTEITEMTEMPLATE.EXAM_ID)
//,Parameter("@ITEM_VALUE",RIS_OPNOTEITEMTEMPLATE.ITEM_VALUE)
//,Parameter("@ITEM_UNIT",RIS_OPNOTEITEMTEMPLATE.ITEM_UNIT)
//,Parameter("@OPNOTE_TYPE",RIS_OPNOTEITEMTEMPLATE.OPNOTE_TYPE)
//,Parameter("@IS_DELETED",RIS_OPNOTEITEMTEMPLATE.IS_DELETED)
//,Parameter("@IS_ACTIVE",RIS_OPNOTEITEMTEMPLATE.IS_ACTIVE)
//,Parameter("@CREATED_BY",RIS_OPNOTEITEMTEMPLATE.CREATED_BY)
//,Parameter("@CREATED_ON",RIS_OPNOTEITEMTEMPLATE.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEMTEMPLATE.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",RIS_OPNOTEITEMTEMPLATE.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

