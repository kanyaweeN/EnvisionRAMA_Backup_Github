using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_OPNOTEITEMDeleteData : DataAccessBase 
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }

        public RIS_OPNOTEITEMDeleteData()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
            StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEM_Delete;
		}
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@OP_ITEM_ID",RIS_OPNOTEITEM.OP_ITEM_ID),
                                            Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEM.LAST_MODIFIED_BY)
                                     };
            return parameters;
        }
	}
}

