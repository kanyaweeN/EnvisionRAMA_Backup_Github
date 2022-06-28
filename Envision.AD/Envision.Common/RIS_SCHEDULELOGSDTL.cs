using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_SCHEDULELOGSDTL
    {
        public int SCHEDULELOG_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int EXAM_ID { get; set; }
        public int QTY { get; set; }
        public Double RATE { get; set; }
        public int GEN_DTL_ID { get; set; }
        public int RAD_ID { get; set; }
        public int PREPARATION_ID { get; set; }
        public int BPVIEW_ID { get; set; }
        public int AVG_REQ_MIN { get; set; }
        public int PAT_DEST_ID { get; set; }
        public char IS_PORTABLE { get; set; }

    }
}
