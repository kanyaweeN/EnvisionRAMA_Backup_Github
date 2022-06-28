using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_ORDEREXAMFLAG
    {
        public int FLAG_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int XRAYREQ_ID { get; set; }
        public int EXAM_ID { get; set; }
        public int EXAMFLAG_ID { get; set; }
        public string REASON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
