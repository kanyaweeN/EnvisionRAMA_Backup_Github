using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISExamMapBillingDeleteData: DataAccessBase
    {
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }
        public RISExamMapBillingDeleteData()
        {
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMMAPBILLING_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@EXAM_ID"		, RIS_EXAMMAPBILLING.EXAM_ID)
                                       };
            return parameters;
        }
       
    }
}
