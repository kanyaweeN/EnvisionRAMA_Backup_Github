using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection.Engine
{
    public delegate void ODBCEventHandlerError(OdbcException e);

    public class ODBCEngine : IDisposable
    {
        private const string title_log = "EnvisionInterfaceEngine.Connection.Engine.ODBCEngine";
        private bool disposed = false;

        public event ODBCEventHandlerError Error;

        private DbConnection connection;
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new OdbcConnection(ConnectionString);

                switch (connection.State)
                {
                    case ConnectionState.Closed: connection.Open(); break;
                    case ConnectionState.Broken:
                    case ConnectionState.Connecting:
                    case ConnectionState.Executing:
                    case ConnectionState.Fetching:
                        Utilities.SaveLog(title_log, "Connection : get", "ConnectionState is " + connection.State.ToString(), false);
                        break;
                    case ConnectionState.Open: break;
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

        public string ConnectionString { get; set; }

        public ODBCEngine() { }
        public ODBCEngine(string connectionString) { ConnectionString = connectionString; }
        ~ODBCEngine()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                disposed = true;
            }
        }

        private DbCommand DoCommand(string query)
        {
            DbCommand cmd = new OdbcCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            if (Utilities.HasData(Parameters)) cmd.Parameters.AddRange(Parameters);

            return cmd;
        }

        public DataTable SelectData(string query)
        {
            DataTable dtt = new DataTable();

            try
            {
                using (DbCommand cmd = DoCommand(query))
                {
                    using (DbDataAdapter dap = new OdbcDataAdapter((OdbcCommand)cmd))
                    {
                        dap.Fill(dtt);

                        dtt.TableName = "RIS";
                        dtt.AcceptChanges();
                    }
                }
            }
            catch (OdbcException ex)
            {
                Utilities.SaveLog(title_log, "SelectData(string query) : OdbcException", "\r\n" + query + "\r\n" + ex.ToString(), true);

                if (Error != null) Error(ex);
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "SelectData(string query) : Exception", "\r\n" + query + "\r\n" + ex.ToString(), true);
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
                catch (OdbcException ex)
                {
                    flag = false;

                    Utilities.SaveLog(title_log, "Execute(string query) : OdbcException", "\r\n" + query + "\r\n" + ex.ToString(), true);

                    if (Error != null) Error(ex);
                }
                catch (Exception ex)
                {
                    flag = false;

                    Utilities.SaveLog(title_log, "Execute(string query) : Exception", "\r\n" + query + "\r\n" + ex.ToString(), true);
                }
            }

            return flag;
        }
    }
}
