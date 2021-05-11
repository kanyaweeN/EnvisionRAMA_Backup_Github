using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISPatientinationSelectData : DataAccessBase
    {
        public RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
        public RISPatientinationSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PATIENTDESTINATION_Select;
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
                                          Parameter("@ORG_ID"	, 1  )
                                       };
            return parameters;
        }
    }
}
