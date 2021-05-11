using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_LABCREATININE
    {
        public int LAB_CREATININE_ID { get; set; }
        public int REG_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int HIS_RQ_ID { get; set; }
        public string MRN { get; set; }
        public string SDLOC { get; set; }
        public string PRODUCT_ID { get; set; }
        public string PERFORM_UNIT { get; set; }
        public string COD_TEST { get; set; }
        public string SHORT_TEST { get; set; }
        public string RESULT_VALUE { get; set; }
        public string UNIT { get; set; }
        public string RANGE { get; set; }
        public DateTime OBSERV_DATETIME { get; set; }
        public DateTime REPORT_DATETIME { get; set; }
        public int ORG_ID { get; set; }
        public string IS_DELETED { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
