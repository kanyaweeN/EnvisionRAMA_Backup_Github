using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_OPNOTEITEMTEMPLATEDeleteData : DataAccessBase 
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }

        public RIS_OPNOTEITEMTEMPLATEDeleteData()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEMTEMPLATE_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@OP_ITEM_ID",RIS_OPNOTEITEMTEMPLATE.OP_ITEM_ID),
                                            Parameter("@EXAM_ID",RIS_OPNOTEITEMTEMPLATE.EXAM_ID),
                                            Parameter("@OPNOTE_TYPE",RIS_OPNOTEITEMTEMPLATE.OPNOTE_TYPE),
                                            Parameter("@LAST_MODIFIED_BY",RIS_OPNOTEITEMTEMPLATE.LAST_MODIFIED_BY)
                                     };
            return parameters;
        }
	}
}

