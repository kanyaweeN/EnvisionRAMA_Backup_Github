using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISContrastDtlUpdateData: DataAccessBase
    {
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }

        public RISContrastDtlUpdateData()
        {
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_Update;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@CONTRASTDTL_ID",RIS_CONTRASTDTL.CONTRASTDTL_ID),
Parameter("@CONTRAST_ID",RIS_CONTRASTDTL.CONTRAST_ID),
Parameter("@PATIENT_WEIGHT",RIS_CONTRASTDTL.PATIENT_WEIGHT),
Parameter("@ROUTE_ID",RIS_CONTRASTDTL.ROUTE_ID),
Parameter("@LOT_ID",RIS_CONTRASTDTL.LOT_ID),
Parameter("@DOSE",RIS_CONTRASTDTL.DOSE),
Parameter("@ACTUAL_QTY",RIS_CONTRASTDTL.ACTUAL_QTY),
Parameter("@INJECTION_RATE",RIS_CONTRASTDTL.INJECTION_RATE),
Parameter("@ONSET_SYMPTOM_VALUE",RIS_CONTRASTDTL.ONSET_SYMPTOM_VALUE),
Parameter("@ONSET_SYMPTOM_TYPE",RIS_CONTRASTDTL.ONSET_SYMPTOM_TYPE),
Parameter("@MEDIA_REACTION_LIST",RIS_CONTRASTDTL.MEDIA_REACTION_LIST),
Parameter("@MEDIA_EXTRAVASATION",RIS_CONTRASTDTL.MEDIA_EXTRAVASATION),
Parameter("@ORDER_ID",RIS_CONTRASTDTL.ORDER_ID),
Parameter("@SCHEDULE_ID",RIS_CONTRASTDTL.SCHEDULE_ID),
Parameter("@XRAYREQ_ID",RIS_CONTRASTDTL.XRAYREQ_ID),
Parameter("@COMMENTS",RIS_CONTRASTDTL.COMMENTS),
Parameter("@LAST_MODIFIED_BY",RIS_CONTRASTDTL.LAST_MODIFIED_BY),
                                      };
            return parameters;
        }

        public void updateArrival(int order_id, int schedule_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_UpdateArrival;
            DbParameter[] parameters ={
Parameter("@ORDER_ID",order_id),
Parameter("@SCHEDULE_ID",schedule_id),
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
