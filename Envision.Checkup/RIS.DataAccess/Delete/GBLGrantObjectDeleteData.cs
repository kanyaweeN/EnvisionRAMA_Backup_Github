using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLGrantObjectDeleteData :DataAccessBase
    {
        private GBLGrantObjectDeleteDataParameters _GBLGrantObjectDeleteDataParameters;
        private string grantId;

        public GBLGrantObjectDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantObject_Delete.ToString();
        }

        public void Get()
        {
            _GBLGrantObjectDeleteDataParameters = new  GBLGrantObjectDeleteDataParameters(this.grantId);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantObjectDeleteDataParameters.Parameters);
        }

        public string GrantId
        {
            get { return grantId; }
            set { grantId = value; }
        }
    }

    public class GBLGrantObjectDeleteDataParameters
    {
        private SqlParameter[] _parameters;
        private string grantId;

        public GBLGrantObjectDeleteDataParameters(string grantId)
        {
            this.grantId = grantId;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_modify_by"	, new GBLEnvVariable().UserID ),
                new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID ),
                new SqlParameter( "@p_delete"	, Int32.Parse( this.grantId) )
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
