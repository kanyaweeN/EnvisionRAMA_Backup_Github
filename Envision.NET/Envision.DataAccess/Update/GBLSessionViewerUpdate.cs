using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLSessionViewerUpdate : DataAccessBase
    {

        public string UserLogin { get;set; }
        public string SessionGUID{get;set;}
        public string Reason { get; set; }
        public GBLSessionViewerUpdate()
        {
            StoredProcedureName = StoredProcedure.GBL_SESSION_VIEWER_UPDATE;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@GUID", SessionGUID)
                ,Parameter("@USER", UserLogin)
                ,Parameter("@REASON", Reason)
                                      };
            return parameters;
        }
    }
}
