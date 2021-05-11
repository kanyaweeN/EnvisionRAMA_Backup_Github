using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLGrantObjectInsertData :DataAccessBase
    {
        private GBLGrantObjectInsertDataParameters _GBLGrantObjectInsertDataParameters;
        private GBLGrantObject grantItem;



        public GBLGrantObjectInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantObject_Insert.ToString();
        }

        public void Get()
        {
            _GBLGrantObjectInsertDataParameters = new GBLGrantObjectInsertDataParameters(this.grantItem);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantObjectInsertDataParameters.Parameters);
        }

        public GBLGrantObject GrantItem
        {
            get { return grantItem; }
            set { grantItem = value; }
        }
    }

    public class GBLGrantObjectInsertDataParameters
    {
        private SqlParameter[] _parameters;
        private GBLGrantObject _grantItem;

        public GBLGrantObjectInsertDataParameters(GBLGrantObject grantItem)
        {
            this._grantItem = grantItem;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_submenu_id"	, this._grantItem.SubMenuUid ),
                new SqlParameter( "@p_empid"	, this._grantItem.EmpID ),
                new SqlParameter( "@p_view"	, this._grantItem.CanView ),
                new SqlParameter( "@p_create"	, this._grantItem.CanCreate ),
                new SqlParameter( "@p_modify"	, this._grantItem.CanModify ),
                new SqlParameter( "@p_removed"	, this._grantItem.CanRemove ),
                new SqlParameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
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
