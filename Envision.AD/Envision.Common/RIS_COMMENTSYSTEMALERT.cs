using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_COMMENTSYSTEMALERT
    {
        public int COMMENTALERT_ID { get; set; }
        public int COMMENT_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int XRAYREQ_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int READER_ID { get; set; }
        public int CREATED_BY { get; set; }
    }
}
