using System;

namespace Envision.Common
{
    public class GBL_MESSAGE
    {
        public int MSG_ID { get; set; }
        public DateTime MSG_DT { get; set; }
        public int MSG_FROM { get; set; }
        public string MSG_SUBJECT { get; set; }
        public string MSG_BODY { get; set; }
        public char MSG_STATUS { get; set; }
        public char MSG_PRIORITY { get; set; }
        public char IS_STARRED { get; set; }
        public char IS_FORCED { get; set; }
        public char IS_DELETED { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
