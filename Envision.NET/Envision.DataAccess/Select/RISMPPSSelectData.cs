using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISMPPSSelectData : DataAccessBase
    {
        public RIS_MPPS RIS_MPPS { get; set; }

        public RISMPPSSelectData()
        {
            RIS_MPPS = new RIS_MPPS();
            base.StoredProcedureName = StoredProcedure.Prc_RIS_MPPSMonitoring_Select;
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
                                            Parameter( "@ORG_ID"	, new GBLEnvVariable().OrgID)
                                            ,Parameter( "@DateFrom"	, RIS_MPPS.DateForm )
                                            ,Parameter( "@DateTo"	, RIS_MPPS.DateTo )
                                       };
            return parameters;
        }
    }
}
