using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Envision.DataAccess.CoreSQL
{
    public class EnvisionSQL
    {
        private string connectionString;

        public EnvisionSQL()
        {
            connectionString = ConfigurationSettings.AppSettings["connStr"];
        }

        public DbParameter createParameter()
        {
            SqlParameter param = new SqlParameter();
            return param;
        }
        public DbParameter createParameter(string filedName, object value)
        {
            SqlParameter param = new SqlParameter(filedName, value);
            return param;

        }
        public DbConnection createConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
        public DbCommand createCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 50;
            return cmd;
        }
        public DbDataAdapter createDataAdapter(DbCommand sqlCommand)
        {
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)sqlCommand);
            return da;
        }
        public DbConnection createConnectionReportSearch()
        {
            SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["connStrReportSearch"]);
            return conn;
        }
    }
}
