using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLSubMenuObjectLabelUpdateData : DataAccessBase
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }

        public GBLSubMenuObjectLabelUpdateData()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjectLabel_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENUOBJECTLABEL.SubMenuUID ) ,
                Parameter( "@ObjectID"	, GBL_SUBMENUOBJECTLABEL.OBJECT_ID ) ,
                Parameter( "@LangID"	, GBL_SUBMENUOBJECTLABEL.LANG_ID ) ,
                Parameter( "@Label"	, GBL_SUBMENUOBJECTLABEL.LABEL ) ,
                Parameter( "@OrgID"        , GBL_SUBMENUOBJECTLABEL.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENUOBJECTLABEL.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_SUBMENUOBJECTLABEL.CREATED_ON ) ,
                Parameter( "@ModifiedBy" , GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_BY ),
	            Parameter( "@ModifiedOn" , GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_ON ),
                                      };
            return parameters;
        }
    }
}
