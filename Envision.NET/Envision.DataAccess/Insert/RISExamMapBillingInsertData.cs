using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamMapBillingInsertData: DataAccessBase
    {
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }

        public RISExamMapBillingInsertData()
        {
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMMAPBILLING_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
				Parameter( "@EXAM_ID"	            , RIS_EXAMMAPBILLING.EXAM_ID ) ,
                Parameter( "@EXAM_SUB_ID"	            , RIS_EXAMMAPBILLING.EXAM_SUB_ID ) ,
                Parameter( "@EXAM_SUB_QTY"	            , RIS_EXAMMAPBILLING.EXAM_SUB_QTY ) ,
                Parameter( "@ORG_ID"	            , RIS_EXAMMAPBILLING.ORG_ID ) ,
                Parameter( "@CREATED_BY"	            , RIS_EXAMMAPBILLING.CREATED_BY ) ,
			};
            return parameters;
        }
      
    }
}