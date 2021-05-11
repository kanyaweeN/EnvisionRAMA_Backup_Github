using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISClinictypeSelectData : DataAccessBase 
	{
		public  RISClinictypeSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICTYPE_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

