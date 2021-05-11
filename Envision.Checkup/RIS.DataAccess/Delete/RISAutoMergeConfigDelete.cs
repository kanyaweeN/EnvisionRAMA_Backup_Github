using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class RISAutoMergeConfigDelete : DataAccessBase
    {
        private string config_name;
        public string Config_Name
        {
            get { return config_name; }
            set { config_name = value; }
        }
        public void Delete()
        {
            SqlParameter [] parameter = { new SqlParameter("@config_name", config_name) };
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_AUTOMERGECONFIG_DELETE.ToString());
            dbHelper.Run(base.ConnectionString, parameter);
        }
    }
}
