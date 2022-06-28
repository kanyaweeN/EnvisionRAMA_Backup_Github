using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_COMMENTSYSTEM
    {
        public int COMMENT_ID { get; set; }
        public int SENDER_ID { get; set; }
        public string MSG_TEXT { get; set; }
        public string MSG_STATUS { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int XRAYREQ_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int CREATED_BY { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
