using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RISExamMapBillingSelectData: DataAccessBase
    {
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }

        public RISExamMapBillingSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMMAPBILLING_Select;
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
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
                                            Parameter( "@EXAM_ID"	        , RIS_EXAMMAPBILLING.EXAM_ID ),
                                       };
            return parameters;
        }
    }
}
