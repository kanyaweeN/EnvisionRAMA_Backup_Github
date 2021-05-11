using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class GBL_SUBMENUOBJECTLABELDeleteData : DataAccessBase
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }
        public string ObjectId { get; set; }

        public GBL_SUBMENUOBJECTLABELDeleteData()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjectLabel_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@txtUID",GBL_SUBMENUOBJECTLABEL.SubMenuUID),
                                         Parameter("@ObjectsID",GBL_SUBMENUOBJECTLABEL.OBJECT_ID),
                                         Parameter("@LangID",GBL_SUBMENUOBJECTLABEL.LANG_ID)
                                     };
            return parameters;
        }
    }
}
