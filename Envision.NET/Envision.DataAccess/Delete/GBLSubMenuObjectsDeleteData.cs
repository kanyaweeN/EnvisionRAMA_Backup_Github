using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class GBL_SUBMENUOBJECTDeleteData : DataAccessBase
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }
        public string ObjectId { get; set; }

        public GBL_SUBMENUOBJECTDeleteData()
        {
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjects_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ObjectsID",ObjectId)
                                     };
            return parameters;
        }
        

    }
}
