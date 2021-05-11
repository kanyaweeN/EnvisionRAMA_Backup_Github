using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLQuicktextUpdateData : DataAccessBase
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public GBLQuicktextUpdateData()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
            StoredProcedureName = StoredProcedure.Prc_GBL_QUICKTEXT_Update;
        }
        public bool Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@QUICKTEXT_ID",GBL_QUICKTEXT.QUICKTEXT_ID)
,Parameter("@QUICK_TEXT",GBL_QUICKTEXT.QUICK_TEXT)
,Parameter("@QUICK_TAG",GBL_QUICKTEXT.QUICK_TAG)
,Parameter("@LAST_MODIFIED_BY",GBL_QUICKTEXT.LAST_MODIFIED_BY)
,Parameter("@IS_GLOBAL",GBL_QUICKTEXT.IS_GLOBAL)
,Parameter("@FILTER_MODE",GBL_QUICKTEXT.FILTER_MODE)
                                      };
            return parameters;
        }
    }
}
