using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class ENVISION_WS
    {
        public string MODE { get; set; }
        public int EXAM_ID { get; set; }
        public decimal RATE { get; set; }
        public string ACCESSION_NO { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public string HIS_SYNC { get; set; }
        public string HIS_ACK { get; set; }
        public string REF_UNIT_UID { get; set; }
        public string REF_DOC_UID { get; set; }
        public string REF_DOC_FNAME { get; set; }
        public string REF_DOC_LANME { get; set; }

        public string INSURANCE_UID { get; set; }
        public string INSURANCE_NAME { get; set; }
        public string HIS_ACCESSION_NO { get; set; }
        public string REASON { get; set; }
    }
}
