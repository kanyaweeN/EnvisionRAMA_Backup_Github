using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.CoreSQL;
using System.Reflection;
using System.Data;
using EnvisionInterface.Common.Linq;

namespace EnvisionInterface.DataAccess
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

        protected DbParameter[] createParameter(object obj)
        {
            DbParameter[] paramReturn = null;
            Type type = obj.GetType();
            EnvisionDataContext db = new EnvisionDataContext();
            var columnNames = db.Mapping.MappingSource.GetModel(typeof(EnvisionDataContext)).GetMetaType(type).DataMembers;
            if (columnNames != null)
            {
                List<DbParameter> list = new List<DbParameter>();
                PropertyInfo[] propInfo = type.GetProperties();
                for (int i = 0; i < columnNames.Count; i++)
                {
                    if (columnNames[i].IsAssociation) continue;
                    PropertyInfo dataPropery = null;
                    foreach (PropertyInfo p in propInfo)
                        if (p.Name == columnNames[i].Name)
                        {
                            dataPropery = p;
                            break;
                        }

                    if (dataPropery != null)
                    {
                        DbParameter param = coreSQL.createParameter();
                        param = coreSQL.createParameter();
                        param.ParameterName = "@" + columnNames[i].MappedName;
                        object objVal = dataPropery.GetValue(obj, null);
                        param.Value = objVal == null ? DBNull.Value : objVal;
                        list.Add(param);

                    }
                }
                if (list.Count > 0)
                {
                    paramReturn = new DbParameter[list.Count];
                    for (int i = 0; i < list.Count; i++)
                        paramReturn[i] = list[i];
                }
            }
            return paramReturn;
        }
        protected DbParameter[] createParameter(object obj, ref List<DbParameter> listReturn)
        {
            DbParameter[] paramReturn = null;
            listReturn = null;
            Type type = obj.GetType();
            EnvisionDataContext db = new EnvisionDataContext();
            var columnNames = db.Mapping.MappingSource.GetModel(typeof(EnvisionDataContext)).GetMetaType(type).DataMembers;
            if (columnNames != null)
            {
                List<DbParameter> list = new List<DbParameter>();
                PropertyInfo[] propInfo = type.GetProperties();
                for (int i = 0; i < columnNames.Count; i++)
                {
                    if (columnNames[i].IsAssociation) continue;
                    PropertyInfo dataPropery = null;
                    foreach (PropertyInfo p in propInfo)
                        if (p.Name == columnNames[i].Name)
                        {
                            dataPropery = p;
                            break;
                        }

                    if (dataPropery != null)
                    {

                        DbParameter param = coreSQL.createParameter();
                        param = coreSQL.createParameter();
                        param.ParameterName = "@" + columnNames[i].MappedName;
                        object objVal = dataPropery.GetValue(obj, null);
                        param.Value = objVal == null ? DBNull.Value : objVal;
                        list.Add(param);
                    }
                }
                if (list.Count > 0)
                {
                    listReturn = list;
                    paramReturn = new DbParameter[list.Count];
                    for (int i = 0; i < list.Count; i++)
                        paramReturn[i] = list[i];
                }
            }
            return paramReturn;
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
        protected DataSet ExecuteDataSetByString(string query)
        {
            DataSet ds = null;
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
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
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
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
        protected DataTable ExecuteDataTableByStrings(string query)
        {
            DataTable data = null;
            DbCommand cmd = coreSQL.createCommand();
            if (Transaction == null)
            {
                using (DbConnection conn = coreSQL.createConnection())
                {

                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
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
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
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
    }
}
namespace Envision.CoreSQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using EnvisionInterface.Common.Common;
    class EnvisionSQL
    {
        private string connectionString;

        public EnvisionSQL()
        {
            connectionString = Config.ConnectionString;
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
            return cmd;
        }
        public DbDataAdapter createDataAdapter(DbCommand sqlCommand)
        {
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)sqlCommand);
            return da;
        }
    }
}