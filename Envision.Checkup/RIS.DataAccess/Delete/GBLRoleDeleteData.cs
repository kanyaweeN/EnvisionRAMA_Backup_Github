using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLRoleDeleteData : DataAccessBase
    {
        private GBLRole _gblrole;
        private string objectId;

        private GBLRoleInsertDataParameters _gblroleinsertdataparameters;

        public GBLRoleDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLRole_Delete.ToString();
        }

        public void Delete()
        {
            //_gblroleinsertdataparameters = new GBLRoleInsertDataParameters(GBLRole);
            _gblroleinsertdataparameters = new GBLRoleInsertDataParameters(this.objectId);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblroleinsertdataparameters.Parameters);

        }

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }
        
        public string ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }
        

    }

    public class GBLRoleInsertDataParameters
    {
        private GBLRole _gblrole;
        private SqlParameter[] _parameters;
        private string _objectID;

        public GBLRoleInsertDataParameters(string gblrole)
        {
            this._objectID = gblrole;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@RoleDTLId"		,  _objectID),
                
			};

            Parameters = parameters;
        }

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
