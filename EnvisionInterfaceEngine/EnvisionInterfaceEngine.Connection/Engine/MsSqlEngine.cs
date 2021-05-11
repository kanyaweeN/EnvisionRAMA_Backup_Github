using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection.Engine
{
    public class MsSqlEngine : IDisposable
	{
        private readonly string title_log;
        private bool disposed = false;

		public string ConnectionString { get; set; }

		private DbParameter[] parameters;
		public DbParameter[] Parameters
		{
			get
			{
				if (parameters != null)
				{
					foreach (DbParameter parameter in parameters)
					{
						//MsSql data type datetime has range between '1753-01-01' and '9999-12-31'
						if ((parameter.DbType == DbType.Date
							|| parameter.DbType == DbType.DateTime
							|| parameter.DbType == DbType.DateTime2
							|| parameter.DbType == DbType.DateTimeOffset)
								&& Utilities.ToDateTime(parameter.Value) < new DateTime(1753, 01, 01))
							parameter.Value = null;

						if (parameter.Value == null)
							parameter.Value = DBNull.Value;
					}
				}

				return parameters;
			}
			set { parameters = value; }
		}

		public MsSqlEngine() { title_log = ToString(); }
		public MsSqlEngine(string connectionString)
		{
			title_log = ToString();

			ConnectionString = connectionString;
        }
        ~MsSqlEngine() { Dispose(); }

        public void Dispose()
        {
            if (!disposed)
            {
                try
                {
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

		public void MsSqlEngine_Error(SqlException e, string caption, string query) { MsSqlEngine_Error(e.GetBaseException(), caption, query); }
		public void MsSqlEngine_Error(Exception e, string caption, string query)
		{
			string message_log = string.Empty;

			message_log += "\r\n";
			message_log += query;
			message_log += "\r\n";
			message_log += "\r\n";
			if (Utilities.HasData(Parameters))
			{
				foreach (DbParameter parameter in Parameters)
					message_log += string.Format("{0} = {1}\r\n", parameter.ParameterName, parameter.Value);

				message_log += "\r\n";
			}
			message_log += e.ToString();

			Utilities.SaveLog(title_log, caption, message_log, true);
		}

		public DbConnection DoConnect() { return new SqlConnection(ConnectionString); }

		private DbCommand DoCommand() { return DoCommand(string.Empty, null); }
		private DbCommand DoCommand(string query) { return DoCommand(query, null); }
		private DbCommand DoCommand(DbTransaction transaction) { return DoCommand(string.Empty, transaction); }
		private DbCommand DoCommand(string query, DbTransaction transaction)
		{
			DbCommand cmd = new SqlCommand();
			cmd.CommandText = query;
			cmd.CommandType = CommandType.Text;

			if (Utilities.HasData(Parameters))
				cmd.Parameters.AddRange(Parameters);

			if (transaction == null)
			{
				cmd.Connection = DoConnect();
				cmd.Connection.Open();
			}
			else
			{
				cmd.Connection = transaction.Connection;
				cmd.Transaction = transaction;

				if (transaction.Connection.State == ConnectionState.Closed)
					transaction.Connection.Open();
			}

			return cmd;
		}

		public DbParameter DoParameter(string parameterName, object value) { return DoParameter(parameterName, value, ParameterDirection.Input); }
		public DbParameter DoParameter(string parameterName, object value, ParameterDirection direction) { return new SqlParameter(parameterName, value) { Direction = direction }; }

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
			string query = string.Empty;

			try
			{
				using (DbCommand cmd = DoCommand())
				{
					int length = queries.Length;

					for (int i = 0; i < length; i++)
					{
						cmd.CommandText = query = queries[i];

						using (DbDataAdapter dap = new SqlDataAdapter((SqlCommand)cmd))
						{
							DataTable dtt = new DataTable();
							dap.Fill(dtt);

							dtt.TableName = string.Format("RIS_{0:00}", i);
							dtt.AcceptChanges();

							ds.Tables.Add(dtt.Copy());
						}
					}

					cmd.Connection.Close();
					ds.AcceptChanges();
				}
			}
			catch (SqlException ex)
			{
				MsSqlEngine_Error(ex, "SelectData(string[] queries) : SqlException", query);
			}
			catch (Exception ex)
			{
				MsSqlEngine_Error(ex, "SelectData(string[] queries) : Exception", query);
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
				catch (SqlException ex)
				{
					flag = false;

					MsSqlEngine_Error(ex, "Execute(string query) : SqlException", query);
				}
				catch (Exception ex)
				{
					flag = false;

					MsSqlEngine_Error(ex, "Execute(string query) : Exception", query);
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

					if (transaction.Connection.State == ConnectionState.Closed)
						transaction.Connection.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}