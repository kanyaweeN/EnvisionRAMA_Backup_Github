using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBL_ROLEDeleteData : DataAccessBase
    {
        public GBL_ROLE GBL_ROLE { get; set; }
        public string ObjectId { get; set; }

        public GBL_ROLEDeleteData()
        {
            GBL_ROLE = new GBL_ROLE();
            ObjectId = "0";
            StoredProcedureName = StoredProcedure.GBLRole_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@RoleDTLId"		,ObjectId)
                                       };
            return parameters;
        }
    }
}
