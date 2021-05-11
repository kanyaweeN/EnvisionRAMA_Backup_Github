using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using EnvisionInterfaceEngine.Operational;

/// <summary>
///Data Source=myDataSource;User Id=myUsername;Password=myPassword;Integrated Security=no;
/// </summary>
namespace EnvisionInterfaceEngine.Connection.Engine
{
  public  class OracleEngine: IDisposable
    {
        private readonly string title_log;
        private bool disposed = false;

        public string ConnectionString { get; set; }

        private DbConnection connection;
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new OracleConnection(ConnectionString);

                switch (connection.State)
                {
                    case ConnectionState.Closed: connection.Open(); break;
                    case ConnectionState.Open: break;
                    default:
                        Utilities.SaveLog(title_log, "Connection : get", "ConnectionState is " + connection.State.ToString(), false);
                        break;
                }

                return connection;
            }
            set { connection = value; }
        }

        private DbParameter[] parameters;
        public DbParameter[] Parameters
        {
            get
            {
                if (parameters != null)
                {
                    foreach (DbParameter parameter in parameters)
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                    }
                }

                return parameters;
            }
            set { parameters = value; }
        }

        public OracleEngine() { title_log = this.ToString(); }
        public OracleEngine(string connectionString)
        {
            title_log = this.ToString();
            ConnectionString = connectionString;
        }
        ~OracleEngine() { Dispose(); }

        public void Dispose()
        {
            if (!disposed)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }

                    if (parameters != null)
                        parameters = null;
                }
                catch (Exception ex)
                {
                    Utilities.SaveLog(title_log, "Dispose()", ex.ToString(), true);
                }
            }

            disposed = true;
        }

        private DbCommand DoCommand() { return DoCommand(string.Empty, null); }
        private DbCommand DoCommand(string query) { return DoCommand(query, null); }
        private DbCommand DoCommand(DbTransaction transaction) { return DoCommand(string.Empty, transaction); }
        private DbCommand DoCommand(string query, DbTransaction transaction)
        {
            DbCommand cmd = new OracleCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;

            if (transaction == null)
                cmd.Connection = Connection;
            else
            {
                cmd.Connection = transaction.Connection;

                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();
            }

            if (Utilities.HasData(Parameters))
                cmd.Parameters.AddRange(Parameters);

            return cmd;
        }

        public DataTable SelectData(string query)
        {
            DataSet ds = SelectData(new string[] { query });

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0].Copy();

            return null;
        }
        public DataSet SelectData(string[] queries)
        {
            DataSet ds = new DataSet();
            int index = 0;

            try
            {
                using (DbCommand cmd = DoCommand())
                {
                    int length = queries.Length;

                    while (index < length)
                    {
                        cmd.CommandText = queries[index];

                        using (DbDataAdapter dap = new OracleDataAdapter((OracleCommand)cmd))
                        {
                            DataTable dtt = new DataTable();
                            dap.Fill(dtt);

                            dtt.TableName = string.Format("RIS_{0:00}", index);
                            dtt.AcceptChanges();

                            ds.Tables.Add(dtt.Copy());
                        }

                        index++;
                    }

                    ds.AcceptChanges();
                    cmd.Connection.Close();
                }
            }
            catch (OracleException ex)
            {
                DbManager.SaveLog(title_log, "SelectData(string[] queries) : OracleException", queries[index], Parameters, ex);
            }
            catch (Exception ex)
            {
                DbManager.SaveLog(title_log, "SelectData(string[] queries) : Exception", queries[index], Parameters, ex);
            }

            return ds.Copy();
        }

        public bool Execute(string query)
        {
            bool flag = true;

            using (DbCommand cmd = DoCommand(query))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    flag = false;

                    DbManager.SaveLog(title_log, "Execute(string query) : OracleException", query, Parameters, ex);
                }
                catch (Exception ex)
                {
                    flag = false;

                    DbManager.SaveLog(title_log, "Execute(string query) : Exception", query, Parameters, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }

            return flag;
        }
        public void Execute(string query, DbTransaction transaction) { Execute(new string[] { query }, transaction); }
        public void Execute(string[] queries, DbTransaction transaction)
        {
            using (DbCommand cmd = DoCommand(transaction))
            {
                foreach (string query in queries)
                {
                    cmd.CommandText = query;

                    if (cmd.Transaction.Connection.State == ConnectionState.Closed)
                        cmd.Transaction.Connection.Open();
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}