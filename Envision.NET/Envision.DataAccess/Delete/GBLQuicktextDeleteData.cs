using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLQuicktextDeleteData : DataAccessBase
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public GBLQuicktextDeleteData()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
            StoredProcedureName = StoredProcedure.Prc_GBL_QUICKTEXT_DeleteN;
        }
        public bool Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@QUICKTEXT_ID", GBL_QUICKTEXT.QUICKTEXT_ID) 
                                           ,Parameter("@CREATED_BY", GBL_QUICKTEXT.CREATED_BY) 
                                       };
            return parameters;
        }
    }
}
