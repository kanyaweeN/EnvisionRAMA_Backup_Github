using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISAuthlevelSelectData : DataAccessBase 
	{
		public  RISAuthlevelSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_AUTHLEVEL_Select;
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

