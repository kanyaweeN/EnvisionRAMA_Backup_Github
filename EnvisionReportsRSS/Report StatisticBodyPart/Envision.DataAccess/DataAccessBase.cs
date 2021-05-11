using Envision.DataAccess.CoreSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Envision.DataAccess
{
    public class DataAccessBase
    {
        private EnvisionSQL coreSQL;
        private DbParameter[] param;

        public StoredProcedure StoredProcedureName { get; set; }
        public DbTransaction Transaction { get; set; }
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
            return coreSQL.createParameter();
        }
        public DbParameter Parameter(string argumentName, object value)
        {
            return coreSQL.createParameter(argumentName, value);
        }
        public DbConnection Connection()
        {
            return coreSQL.createConnection();
        }


        public DataAccessBase()
        {
            coreSQL = new EnvisionSQL();
            ParameterList = null;
            Transaction = null;
        }
     
        protected DbParameter[] convertParameterToDbList(List<DbParameter> list)
        {
            DbParameter[] param = new DbParameter[list.Count];
            for (int i = 0; i < list.Count; i++)
                param[i] = list[i];
            return param;
        }
        
        protected int ExecuteNonQuery()
        {
            DbCommand cmd = coreSQL.createCommand();
            int row = -1;
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
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
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
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
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
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
            DbCommand cmd = coreSQL.createCommand();
            object obj = null;
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
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
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
                {
                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    DbDataAdapter da = coreSQL.createDataAdapter(cmd);
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
                DbDataAdapter da = coreSQL.createDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            return ds.Copy();
        }
        protected DataTable ExecuteDataTable()
        {
            DataTable data = null;
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
                {

                    cmd.CommandText = StoredProcedureName.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (ParameterList != null)
                    {
                        if (ParameterList.Length > 0)
                            cmd.Parameters.AddRange(ParameterList);
                    }
                    DbDataAdapter da = coreSQL.createDataAdapter(cmd);
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
                DbDataAdapter da = coreSQL.createDataAdapter(cmd);
                data = new DataTable();
                da.Fill(data);
            }
            return data.Copy();
        }
        protected DataSet ExecuteDataSetReportSearch()
        {
            DataSet ds = null;
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnectionReportSearch())
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
                    DbDataAdapter da = coreSQL.createDataAdapter(cmd);
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
                DbDataAdapter da = coreSQL.createDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            return ds.Copy();
        }
    }
}
