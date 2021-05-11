using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
namespace RIS.DataAccess.Select
{
    public class HisICDSelectData : DataAccessBase 
    {
        public HisICDSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_HIS_ICD_Select.ToString();
		}
        public DataSet GetData()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
    }
}
