using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class GBLSubMenuObjectLabelUpdateData : DataAccessBase
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;

        private GBLSubMenuObjectLabelInsertDataParameters _gblsubmenuobjectlabelinsertdataparameters;

        public GBLSubMenuObjectLabelUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenuObjectLabel_Update.ToString();
        }

        public void Add()
        {
            _gblsubmenuobjectlabelinsertdataparameters = new GBLSubMenuObjectLabelInsertDataParameters(GBLSubMenuObjectLabel);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblsubmenuobjectlabelinsertdataparameters.Parameters);

        }

        public GBLSubMenuObjectLabel GBLSubMenuObjectLabel
        {
            get { return _gblsubmenuobjectlabel; }
            set { _gblsubmenuobjectlabel = value; }
        }
    }

    public class GBLSubMenuObjectLabelInsertDataParameters
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;
        private SqlParameter[] _parameters;

        public GBLSubMenuObjectLabelInsertDataParameters(GBLSubMenuObjectLabel gblsubmenuobjectlabel)
        {
            GBLSubMenuObjectLabel = gblsubmenuobjectlabel;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@txtUID"	, GBLSubMenuObjectLabel.SubMenuUID ) ,
                new SqlParameter( "@ObjectID"	, GBLSubMenuObjectLabel.ObjectID ) ,
                new SqlParameter( "@LangID"	, GBLSubMenuObjectLabel.LangID ) ,
                new SqlParameter( "@Label"	, GBLSubMenuObjectLabel.Label ) ,
                new SqlParameter( "@OrgID"        , GBLSubMenuObjectLabel.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLSubMenuObjectLabel.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLSubMenuObjectLabel.CreatedOn ) ,
                new SqlParameter( "@ModifiedBy" , GBLSubMenuObjectLabel.ModifiedBy ),
	            new SqlParameter( "@ModifiedOn" , GBLSubMenuObjectLabel.ModifiedOn ),
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
