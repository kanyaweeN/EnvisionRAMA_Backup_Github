using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_ORDERCLINICALINDICATIONTYPE
    {
        public int ORDER_CI_TYPE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int CI_TYPE_ID { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public int SCHEDULE_ID { get; set; }
        public string IS_FREE_TEXT { get; set; }
        public string IS_REQONLINE { get; set; }
    }
}
