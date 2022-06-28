using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISOpnoteitemSelectData : DataAccessBase 
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
		public  RISOpnoteitemSelectData()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
			StoredProcedureName = StoredProcedure.Prc_RIS_OPNOTEITEM_Select;
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
                   Parameter("@OP_ITEM_ID",RIS_OPNOTEITEM.OP_ITEM_ID)
			};
            return parameters;
        }
	}
}

