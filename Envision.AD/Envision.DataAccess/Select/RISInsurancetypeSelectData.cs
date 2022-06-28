using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISInsurancetypeSelectData : DataAccessBase 
	{
        public RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }
		public  RISInsurancetypeSelectData()
		{
            RIS_INSURANCETYPE = new RIS_INSURANCETYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_INSURANCETYPE_SelectAll;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
			return ds;
		}
	}
}

