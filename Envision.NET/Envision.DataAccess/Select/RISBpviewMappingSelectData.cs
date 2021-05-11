using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISBpviewMappingSelectData: DataAccessBase
    {
            public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }

            public RISBpviewMappingSelectData()
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEWMAPPING_SelectNew;
                RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
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
                                                Parameter( "@EXAM_ID"     ,RIS_BPVIEWMAPPING.EXAM_ID),
                                       };
                return parameters;
            }
    }
}

