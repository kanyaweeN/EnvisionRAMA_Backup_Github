using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISBpviewSelectData : DataAccessBase 
	{
		public  RISBpviewSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEW_Select;
		}
	
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataTable GetBodyPart()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_BODYPART_Select;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
	}
}

