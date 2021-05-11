using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RIS.DataAccess.Select
{
    public class RISAutoMergeConfigSelect : DataAccessBase
    {
        private DataSet result;
        public DataSet Result
        {
            get { return result; }
        }
        public void Select()
        {
            SqlParameter[] parameter = { };
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_AutoMergeConfig_Select.ToString());
            result = dbHelper.Run(base.ConnectionString, parameter);
        }
    }
}
