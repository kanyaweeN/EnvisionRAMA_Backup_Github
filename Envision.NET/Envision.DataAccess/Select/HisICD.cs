using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class HisICDSelectData : DataAccessBase 
    {
        public HisICDSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_HIS_ICD_Select;
		}
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
