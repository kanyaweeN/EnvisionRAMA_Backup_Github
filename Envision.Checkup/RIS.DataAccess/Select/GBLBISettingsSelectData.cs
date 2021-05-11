using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
using RIS.DataAccess;
using System.Data.SqlClient;

namespace Envision.DataAccess.Select
{
    public class GBLBISettingsSelectData : DataAccessBase
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public GBLBISettingsSelectData()
        {
            GBL_BISETTINGS = new GBL_BISETTINGS();
            base.StoredProcedureName = StoredProcedure.Name.Prc_GBL_BISETTINGS_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            SqlParameter[] ParameterList = buildParameter();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, ParameterList);
            return ds;
        }
        private SqlParameter[] buildParameter()
        {
            SqlParameter[] parameters = { 
                                            new SqlParameter( "@MODE"	, GBL_BISETTINGS.MODE )
                                            ,new SqlParameter( "@EMP_ID"	, GBL_BISETTINGS.EMP_ID )
                                       };
            return parameters;
        }
    }
}
