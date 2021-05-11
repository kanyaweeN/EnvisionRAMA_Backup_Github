using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLBISettingsSelectData : DataAccessBase
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public GBLBISettingsSelectData()
        {
            GBL_BISETTINGS = new GBL_BISETTINGS();
            base.StoredProcedureName = StoredProcedure.Prc_GBL_BISETTINGS_Select;
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
                                            Parameter( "@MODE"	, GBL_BISETTINGS.MODE )
                                            ,Parameter( "@EMP_ID"	, GBL_BISETTINGS.EMP_ID )
                                       };
            return parameters;
        }
    }
}
