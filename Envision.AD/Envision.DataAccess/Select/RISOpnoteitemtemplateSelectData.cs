using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISOpnoteitemtemplateSelectData : DataAccessBase 
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }
		public  RISOpnoteitemtemplateSelectData()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
			StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEMTEMPLATE_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
			return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",RIS_OPNOTEITEMTEMPLATE.EXAM_ID)
                ,Parameter("@OPNOTE_TYPE",RIS_OPNOTEITEMTEMPLATE.OPNOTE_TYPE)
                ,Parameter("@REG_ID",RIS_OPNOTEITEMTEMPLATE.LAST_MODIFIED_BY)
			};
            return parameters;
        }
	}
}

