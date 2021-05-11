using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLSubMenuObjectsDeleteData : DataAccessBase
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        private string objectId;

        private GBLSubMenuObjectsInsertDataParameters _gblsubmenuobjectsinsertdataparameters;

        public GBLSubMenuObjectsDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenuObjects_Delete.ToString();
        }

        public void Delete()
        {
            //_gblsubmenuobjectsinsertdataparameters = new GBLSubMenuObjectsInsertDataParameters(GBLSubMenuObjects);
            _gblsubmenuobjectsinsertdataparameters = new GBLSubMenuObjectsInsertDataParameters(this.objectId);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblsubmenuobjectsinsertdataparameters.Parameters);

        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }
        
        public string ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }
        

    }

    public class GBLSubMenuObjectsInsertDataParameters
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        private SqlParameter[] _parameters;
        private string _objectID;

        public GBLSubMenuObjectsInsertDataParameters(string gblsubmenuobjects)
        {
            this._objectID = gblsubmenuobjects;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ObjectsID"		,  _objectID),
                
			};

            Parameters = parameters;
        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
