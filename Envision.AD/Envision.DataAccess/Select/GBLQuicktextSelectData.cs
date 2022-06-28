using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLQuicktextSelectData : DataAccessBase
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public GBLQuicktextSelectData()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
            StoredProcedureName = StoredProcedure.Prc_GBL_QUICKTEXT_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@CREATED_BY",GBL_QUICKTEXT.CREATED_BY)
                                          ,Parameter("@STR_FILTER_MODE",GBL_QUICKTEXT.STR_FILTER_MODE)
                                       };
            return parameters;
        }
        public DataSet GetQuickTextFilterMode()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_QUICKTEXT_SelectFilterMode;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
