using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class GBLGrantObjectSelectData : DataAccessBase
    {
        private GBLGrantObjectSelectDataParameters _GBLGrantObjectSelectDataParameters;
        private string _uuid;

        public GBLGrantObjectSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantObject_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _GBLGrantObjectSelectDataParameters = new GBLGrantObjectSelectDataParameters(this._uuid);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _GBLGrantObjectSelectDataParameters.Parameters);
            return ds;
        }

        public string UUID
        {
            get { return this._uuid; }
            set { this._uuid = value; }
        }
    }

    public class GBLGrantObjectSelectDataParameters
    {
        private SqlParameter[] _parameters;
        private string _uuid;

        public GBLGrantObjectSelectDataParameters(string uuid)
        {
            this._uuid = uuid;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter("@p_uuid", Int32.Parse(this._uuid)),
				new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
				
				
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
    }
}
