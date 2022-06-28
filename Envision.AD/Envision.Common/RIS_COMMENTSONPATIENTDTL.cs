using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_COMMENTSONPATIENTDTL
    {
        public int COMMENT_ID { get; set; }
		public int SL_NO { get; set; }
		public int EXAM_ID { get; set; }
		public int COMMENT_TO { get; set; }
		public string IS_DELETED { get; set; }
		public string IS_TRASHED { get; set; }
		public DateTime ACK_ON { get; set; }
		public int ORG_ID { get; set; }
		public int CREATED_BY { get; set; }
		public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
		public DateTime LAST_MODIFIED_ON { get; set; }
        public string RECIPIENT_TYPE { get; set; }
    }
}
