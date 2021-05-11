using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class GBLGrantObjectUpdateData :DataAccessBase
    {
        private GBLGrantObjectUpdateDataParameters _GBLGrantObjectUpdateDataParameters;
        private GBLGrantObject grantItem;



        public GBLGrantObjectUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLGrantObject_Update.ToString();
        }

        public void Get()
        {
            _GBLGrantObjectUpdateDataParameters = new GBLGrantObjectUpdateDataParameters(this.grantItem);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantObjectUpdateDataParameters.Parameters);
        }

        public GBLGrantObject GrantItem
        {
            get { return grantItem; }
            set { grantItem = value; }
        }
    }

    public class GBLGrantObjectUpdateDataParameters
    {
        private SqlParameter[] _parameters;
        private GBLGrantObject _grantItem;

        public GBLGrantObjectUpdateDataParameters(GBLGrantObject grantItem)
        {
            this._grantItem = grantItem;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_grantobject_id"	, this._grantItem.GrantObjectId ),
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
