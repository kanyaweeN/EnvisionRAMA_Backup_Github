using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class GBLGrantRoleLoadTreeData : DataAccessBase
    {
        private GBLGrantRoleLoadTreeDataParameters _GBLGrantRoleLoadTreeDataParameters;
        private int _type;
        private int _subType;
        private int _pid;
        private int _cid;
        private string _search;

        public GBLGrantRoleLoadTreeData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantRole_LoadTree.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _GBLGrantRoleLoadTreeDataParameters = new GBLGrantRoleLoadTreeDataParameters(_type, _subType, _pid, _cid, _search);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _GBLGrantRoleLoadTreeDataParameters.Parameters);
            return ds;
        }

        public int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public int SubType
        {
            get { return this._subType; }
            set { this._subType = value; }
        }
        public int ParentId
        {
            get { return this._pid; }
            set { this._pid = value; }
        }
        public int ChildId
        {
            get { return this._cid; }
            set { this._cid = value; }
        }
        public string Search
        {
            get { return this._search; }
            set { this._search = value; }
        }
    }

    public class GBLGrantRoleLoadTreeDataParameters
    {
        private SqlParameter[] _parameters;
        private int _type;
        private int _subType;
        private int _pid;
        private int _cid;
        private string _search;

        public GBLGrantRoleLoadTreeDataParameters(int type,int subType,int pid,int cid, string search)
        {
            this._type = type;
            this._subType = subType;
            this._pid = pid;
            this._cid = cid;
            this._search = search;
            Build();
        }

        private void Build()
        {
            //@p_type, @p_sub_type, @p_pid, @p_cid, @p_search, @p_orgid

            SqlParameter[] parameters =
		    {
                new SqlParameter("@p_type", this._type),
                new SqlParameter("@p_sub_type", this._subType),
                new SqlParameter("@p_pid", this._pid),
                new SqlParameter("@p_cid", this._cid),
                new SqlParameter("@p_search", this._search),
				new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
				
				
		    };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
