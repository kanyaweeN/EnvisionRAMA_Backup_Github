using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;

namespace RIS.DataAccess
{
    public class DataAccessBase
    {
        private DbParameter[] param;
        public DbTransaction DbTransaction { get; set; }
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

        public DbParameter Parameter()
        {
            SqlParameter param = new SqlParameter();
            return param;
        }
        public DbParameter Parameter(string argumentName, object value)
        {
            SqlParameter param = new SqlParameter(argumentName, value);
            return param;
        }
        public DbConnection Connection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }
        

        private string _storedprocedureName;
        private SqlConnection con;


        public string StoredProcedureName
        {
            get { return _storedprocedureName; }
            set { _storedprocedureName = value; }
        }

        public SqlConnection GetSQLConnection() {
            con = new SqlConnection(ConnectionString);
            return con;
        }
        protected string ConnectionString
        {
            get
            {
                return ConfigurationSettings.AppSettings["connStr"];
            }
        }


        private static SqlTransaction tran;
        private static SqlConnection conTran;

        public static void BeginTransaction()
        {
            if (conTran == null)
            {
                string connection = ConfigurationSettings.AppSettings["connStr"];
                conTran = new SqlConnection(connection);
                tran = conTran.BeginTransaction();
            }
        }
        public static void ClearTransaction()
        {
            if (conTran.State == ConnectionState.Open)  
                conTran.Close();

            conTran = null;
            tran = null;
        }
        public static void Rollback() {
            tran.Rollback();
            ClearTransaction();
        }
        public static void Commit() {
            tran.Commit();
            ClearTransaction();
        }
        public static SqlTransaction Transaction {
            get { return tran; }
        }

        protected int ExecuteNonQuery()
        {
            DbCommand cmd = new SqlCommand();
            int row = -1;
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    conn.Open();
                    row = cmd.ExecuteNonQuery();
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                if (Transaction.Connection.State == ConnectionState.Closed) Transaction.Connection.Open();
                row = cmd.ExecuteNonQuery();
            }
            return row;
        }

        protected DbDataReader ExecuteReader()
        {
            DbDataReader reader = null;
            DbCommand cmd = new SqlCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    conn.Open();
                    reader = cmd.ExecuteReader();
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                if (Transaction.Connection.State == ConnectionState.Closed) Transaction.Connection.Open();
                reader = cmd.ExecuteReader();
            }
            return reader;
        }
        protected DbDataReader ExecuteReader(CommandBehavior behavior)
        {
            DbDataReader reader = null;
            DbCommand cmd = new SqlCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    conn.Open();
                    reader = cmd.ExecuteReader(behavior);
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                if (Transaction.Connection.State == ConnectionState.Closed) Transaction.Connection.Open();
                reader = cmd.ExecuteReader(behavior);
            }
            return reader;
        }

        protected object ExecuteScalar()
        {
            DbCommand cmd = new SqlCommand();
            object obj = null;
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    conn.Open();
                    obj = cmd.ExecuteScalar();
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                if (Transaction.Connection.State == ConnectionState.Closed) Transaction.Connection.Open();
                obj = cmd.ExecuteScalar();
            }
            return obj;
        }

        protected DataSet ExecuteDataSet()
        {
            DataSet ds = null;
            DbCommand cmd = new SqlCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    ds = new DataSet();
                    da.SelectCommand.CommandTimeout = 60 * 60;
                    da.Fill(ds);
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            return ds.Copy();
        }
        protected DataTable ExecuteDataTable()
        {
            DataTable data = null;
            DbCommand cmd = new SqlCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = Connection())
                {

                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    data = new DataTable();
                    da.Fill(data);

                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                data = new DataTable();
                da.Fill(data);
            }
            return data.Copy();
        }
        protected DataSet ExecuteDataSetReportSearch()
        {
            DataSet ds = null;
            DbCommand cmd = new SqlCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["connStrReportSearch"]))
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 60 * 3;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
            }
            else
            {
                cmd.CommandText = StoredProcedureName.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Transaction.Connection;
                cmd.Transaction = Transaction;
                if (ParameterList != null)
                {
                    if (ParameterList.Length > 0)
                        cmd.Parameters.AddRange(ParameterList);
                }
                DbDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            return ds.Copy();
        }
    }
}
