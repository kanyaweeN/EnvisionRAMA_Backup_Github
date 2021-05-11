using System;

namespace EnvisionInterfaceEngine.Common
{
    public class RIS_ORDER
    {
        public RIS_ORDER() { IS_CANCELED = 'N'; }

        public int ORDER_ID { get; set; }
        public DateTime ORDER_DT { get; set; }
        public int REG_ID { get; set; }
        public string HN { get; set; }
        public string VISIT_NO { get; set; }
        public string ADMISSION_NO { get; set; }
        public string REQUESTNO { get; set; }
        public string CLINICAL_INSTRUCTION { get; set; }
        public int PAT_STATUS { get; set; }
        public int INSURANCE_TYPE_ID { get; set; }
        public int REF_DOC { get; set; }
        public int REF_UNIT { get; set; }
        public char IS_CANCELED { get; set; }
        public string REASON { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
    }
}