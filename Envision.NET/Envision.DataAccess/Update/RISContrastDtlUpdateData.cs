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
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_Update2;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter prLINJECTION_TIME = Parameter();
            prLINJECTION_TIME.ParameterName = "@INJECTION_TIME";
            if (RIS_CONTRASTDTL.INJECTION_TIME == DateTime.MinValue)
                prLINJECTION_TIME.Value = DBNull.Value;
            else
                prLINJECTION_TIME.Value = RIS_CONTRASTDTL.INJECTION_TIME;

            DbParameter prONSET_SYMPTOM_DATETIME = Parameter();
            prONSET_SYMPTOM_DATETIME.ParameterName = "@ONSET_SYMPTOM_DATETIME";
            if (RIS_CONTRASTDTL.ONSET_SYMPTOM_DATETIME == DateTime.MinValue)
                prONSET_SYMPTOM_DATETIME.Value = DBNull.Value;
            else
                prONSET_SYMPTOM_DATETIME.Value = RIS_CONTRASTDTL.ONSET_SYMPTOM_DATETIME;


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
prLINJECTION_TIME,
prONSET_SYMPTOM_DATETIME,
Parameter("@ONSET_SYMPTOM_LIST",RIS_CONTRASTDTL.ONSET_SYMPTOM_LIST),

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
