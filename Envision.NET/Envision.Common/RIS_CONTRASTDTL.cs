using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_CONTRASTDTL
    {
        public int CONTRASTDTL_ID { get; set; }
        public int CONTRAST_ID { get; set; }
        public decimal PATIENT_WEIGHT { get; set; }
        public int ROUTE_ID { get; set; }
        public int LOT_ID { get; set; }
        public decimal DOSE { get; set; }
        public decimal ACTUAL_QTY { get; set; }
        public decimal INJECTION_RATE { get; set; }
        public DateTime INJECTION_TIME { get; set; }
        public decimal ONSET_SYMPTOM_VALUE { get; set; }
        public string ONSET_SYMPTOM_TYPE { get; set; }
        public DateTime ONSET_SYMPTOM_DATETIME { get; set; }
        public string ONSET_SYMPTOM_LIST { get; set; }
        public string MEDIA_REACTION_LIST { get; set; }
        public decimal MEDIA_EXTRAVASATION { get; set; }
        public int ORDER_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int XRAYREQ_ID { get; set; }
        public string COMMENTS { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }

    }
}
