using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RIS_ACR_SelectData : DataAccessBase 
    {
        public RIS_ACR_SelectData() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ACR_Select.ToString();
        }
        public DataSet GetData()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
    }
}
