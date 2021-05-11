using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class GBLGrantRoleSelectData : DataAccessBase
    {
        DataSet _dataset;
        public GBLGrantRoleSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_Select.ToString();
        }
        public DataSet Get()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            _dataset = dbhelper.Run(base.ConnectionString);
            return _dataset;
        }

    }
}
