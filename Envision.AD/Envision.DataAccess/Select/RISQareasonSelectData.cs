using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISQareasonSelectData : DataAccessBase 
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }
		public  RISQareasonSelectData()
		{
            RIS_QAREASON = new RIS_QAREASON();
			StoredProcedureName = StoredProcedure.Prc_RIS_QAREASON_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

