using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GlobalAlertSelectData : DataAccessBase
    {
        public GBL_ALERT GBL_ALERT { get; set; }

        public GlobalAlertSelectData()
        {
            GBL_ALERT = new GBL_ALERT();
            StoredProcedureName = StoredProcedure.Prc_ShowAlert;
        }

        public DataSet Get()
        {

            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@AltUID",GBL_ALERT.ALT_UID)
                                                    , Parameter("@LangID",GBL_ALERT.LangID)
                                       };
            return parameters;
        }

    }
}
