using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class MISAsessmenttypeSelectData : DataAccessBase 
	{
		public  MISAsessmenttypeSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_MIS_ASESSMENTTYPE_Select;
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

