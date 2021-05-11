using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLSubMenuObjectLabelInsertData : DataAccessBase
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }

        public GBLSubMenuObjectLabelInsertData()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjectLabel_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter CreatedOn = Parameter();
            CreatedOn.ParameterName = "@CreatedOn";
            if (GBL_SUBMENUOBJECTLABEL.CREATED_ON == null)
                CreatedOn.Value = DBNull.Value;
            else
                CreatedOn.Value = GBL_SUBMENUOBJECTLABEL.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENUOBJECTLABEL.CREATED_ON;

            DbParameter ModifiedOn = Parameter();
            ModifiedOn.ParameterName = "@ModifiedOn";
            if (GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_ON == null)
                ModifiedOn.Value = DBNull.Value;
            else
                ModifiedOn.Value = GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_ON;


            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENUOBJECTLABEL.SubMenuUID ) ,
                Parameter( "@ObjectName"	, GBL_SUBMENUOBJECTLABEL.ObjectName ) ,
                Parameter( "@LangID"	, GBL_SUBMENUOBJECTLABEL.LANG_ID ) ,
                Parameter( "@Label"	, GBL_SUBMENUOBJECTLABEL.LABEL ) ,
                Parameter( "@OrgID"        , GBL_SUBMENUOBJECTLABEL.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENUOBJECTLABEL.CREATED_BY) ,
				CreatedOn ,
                Parameter( "@ModifiedBy" , GBL_SUBMENUOBJECTLABEL.LAST_MODIFIED_BY),
	            ModifiedOn,
            };
            return parameters;
        }
    }
}
