using System;
using System.Data;
using System.Data.Common;
using EnvisionInterfaceEngine.Operational;
using MySql.Data.MySqlClient;

/// <summary>
/// Server=127.0.0.1;Port=3306;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
/// </summary>
namespace EnvisionInterfaceEngine.Connection.Engine
{
    public class MySqlEngine : IDisposable
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
                    connection = new MySqlConnection(ConnectionString);

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

        public MySqlEngine() { title_log = this.ToString(); }
        public MySqlEngine(string connectionString)
        {
            title_log = this.ToString();
            ConnectionString = connectionString;
        }
        ~MySqlEngine() { Dispose(); }

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
            DbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;

            if (Utilities.HasData(Parameters))
                cmd.Parameters.AddRange(Parameters);

            return cmd;
        }

        public DataTable SelectData(string query)
        {
            bool success;

            return SelectData(query, out  success);
        }
        public DataTable SelectData(string query, out bool success)
        {
            DataTable dtt = new DataTable();

            try
            {
                using (DbCommand cmd = DoCommand(query))
                {
                    using (DbDataAdapter dap = new MySqlDataAdapter((MySqlCommand)cmd))
                    {
                        dap.Fill(dtt);

                        dtt.TableName = "RIS";
                        dtt.AcceptChanges();
                    }
                }

                success = true;
            }
            catch (MySqlException ex)
            {
                success = false;

                DbManager.SaveLog(title_log, "SelectData(string query) : MySqlException", query, Parameters, ex);
            }
            catch (Exception ex)
            {
                success = false;

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
                catch (MySqlException ex)
                {
                    flag = false;

                    DbManager.SaveLog(title_log, "Execute(string query) : MySqlException", query, Parameters, ex);
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