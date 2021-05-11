using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class GBLGrantObjectSelectInherit : DataAccessBase
    {
        private GBLGrantObjectSelectInheritParameters _GBLGrantObjectSelectInheritParameters;
        private string _uuid;
        private int _type;

        public GBLGrantObjectSelectInherit()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantObject_Inherit.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _GBLGrantObjectSelectInheritParameters = new GBLGrantObjectSelectInheritParameters(this._uuid, this._type);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _GBLGrantObjectSelectInheritParameters.Parameters);
            return ds;
        }

        public string UUID
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }
        public int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
    }

    public class GBLGrantObjectSelectInheritParameters
    {
        private SqlParameter[] _parameters;
        private string _uuid;
        private int _type;

        public GBLGrantObjectSelectInheritParameters(string uuid,int type)
        {
            this._uuid = uuid;
            this._type = type;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter("@p_uuid", Int32.Parse(this._uuid)),
				new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID ),
                new SqlParameter( "@p_type"	, this._type )
		    };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public string UUID
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }
        public int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
    }
}
