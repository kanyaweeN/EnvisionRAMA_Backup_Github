using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class MISLesiontypeSelectData : DataAccessBase 
	{
		public  MISLesiontypeSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_MIS_LESIONTYPE_Select;
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

