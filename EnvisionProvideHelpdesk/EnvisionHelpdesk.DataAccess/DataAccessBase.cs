using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace EnvisionHelpdesk.DataAccess
{
    public class DataAccessBase
    {
        private string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        private DbParameter[] param;
        public DbParameter[] ParameterList
        {
            get { return param; }
            set
            {
                param = value;
                if (param == null) return;
                foreach (DbParameter p in param)
                {
                    if (p.Value == null) p.Value = DBNull.Value;
                }
            }
        }
        public string StoreProcedureName { get; set; }
        public DbParameter Parameter(string argumentName, object value)
        {
            SqlParameter param = new SqlParameter(argumentName, value);
            return param;
        }
        protected DataSet ExecuteDataSet()
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(connectionString);//ConnectionString.envisionConnection);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = StoreProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (ParameterList != null)
                if (ParameterList.Length > 0)
                    cmd.Parameters.AddRange(ParameterList);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();

            return ds;
        }
    }
}
