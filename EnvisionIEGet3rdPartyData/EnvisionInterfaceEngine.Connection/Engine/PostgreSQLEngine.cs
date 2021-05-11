using System;
using System.Data;
using System.Data.Common;
using EnvisionInterfaceEngine.Operational;
using Npgsql;

/// <summary>
/// Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;
/// </summary>
namespace EnvisionInterfaceEngine.Connection.Engine
{
    public class PostgreSQLEngine : IDisposable
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
                    connection = new NpgsqlConnection(ConnectionString);

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

        public PostgreSQLEngine() { title_log = this.ToString(); }
        public PostgreSQLEngine(string connectionString)
        {
            title_log = this.ToString();
            ConnectionString = connectionString;
        }
        ~PostgreSQLEngine() { Dispose(); }

        public void Dispose()
        {
            if (!disposed)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Close();
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

        private DbCommand DoCommand(string query)
        {
            DbCommand cmd = new NpgsqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            
            if (Utilities.HasData(Parameters)) 
                cmd.Parameters.AddRange(Parameters);

            return cmd;
        }

        public DataTable SelectData(string query)
        {
            DataTable dtt = new DataTable();

            try
            {
                using (DbCommand cmd = DoCommand(query))
                {
                    using (DbDataAdapter dap = new NpgsqlDataAdapter((NpgsqlCommand)cmd))
                    {
                        dap.Fill(dtt);

                        dtt.TableName = "RIS";
                        dtt.AcceptChanges();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                DbManager.SaveLog(title_log, "SelectData(string query) : NpgsqlException", query, Parameters, ex);
            }
            catch (Exception ex)
            {
                DbManager.SaveLog(title_log, "SelectData(string query) : Exception", query, Parameters, ex);
            }

            return dtt.Copy();
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
                catch (NpgsqlException ex)
                {
                    flag = false;

                    DbManager.SaveLog(title_log, "Execute(string query) : NpgsqlException", query, Parameters, ex);
                }
                catch (Exception ex)
                {
                    flag = false;

                    DbManager.SaveLog(title_log, "Execute(string query) : Exception", query, Parameters, ex);
                }
            }

            return flag;
        }
    }
}