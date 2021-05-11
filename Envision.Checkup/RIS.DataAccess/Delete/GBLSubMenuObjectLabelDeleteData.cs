using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLSubMenuObjectLabelDeleteData : DataAccessBase
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;
        private string objectId;

        private GBLSubMenuObjectLabelInsertDataParameters _gblsubmenuobjectlabelinsertdataparameters;

        public GBLSubMenuObjectLabelDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenuObjectLabel_Delete.ToString();
        }

        public void Delete()
        {
            _gblsubmenuobjectlabelinsertdataparameters = new GBLSubMenuObjectLabelInsertDataParameters(GBLSubMenuObjectLabel);
            //_gblsubmenuobjectlabelinsertdataparameters = new GBLSubMenuObjectLabelInsertDataParameters(this.objectId);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblsubmenuobjectlabelinsertdataparameters.Parameters);

        }

        public GBLSubMenuObjectLabel GBLSubMenuObjectLabel
        {
            get { return _gblsubmenuobjectlabel; }
            set { _gblsubmenuobjectlabel = value; }
        }
        
        public string ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }
        

    }

    public class GBLSubMenuObjectLabelInsertDataParameters
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;
        private SqlParameter[] _parameters;
        private string _objectID;

        public GBLSubMenuObjectLabelInsertDataParameters(GBLSubMenuObjectLabel gblsubmenuobjectlabel)
        {
            GBLSubMenuObjectLabel = gblsubmenuobjectlabel;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@txtUID"		,  GBLSubMenuObjectLabel.SubMenuUID),
				new SqlParameter( "@ObjectsID"		,  GBLSubMenuObjectLabel.ObjectID),
                new SqlParameter( "@LangID"		,  GBLSubMenuObjectLabel.LangID),
                
			};

            Parameters = parameters;
        }

        public GBLSubMenuObjectLabel GBLSubMenuObjectLabel
        {
            get { return _gblsubmenuobjectlabel; }
            set { _gblsubmenuobjectlabel = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
