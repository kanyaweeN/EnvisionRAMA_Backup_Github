using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_COMMENTSONPATIENT
    {
        public int COMMENT_ID { get; set; }
        public int PARENT_ID { get; set; }
        public int REG_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public DateTime COMMENT_DT { get; set; }
        public int COMMENT_FROM { get; set; }
        public string COMMENT_SUBJECT { get; set; }
        public string COMMENT_BODY { get; set; }
        public string COMMENT_STATUS { get; set; }
        public string COMMENT_PRIORITY { get; set; }
        public string IS_DELETED { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }

        public string HN { get; set; }
        public int EMP_ID { get; set; }
        public int MODE { get; set; }
        public int EXAM_ID { get; set; }
    }
}
