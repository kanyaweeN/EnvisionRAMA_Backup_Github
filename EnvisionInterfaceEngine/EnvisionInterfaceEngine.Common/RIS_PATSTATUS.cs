using System;

namespace EnvisionInterfaceEngine.Common
{
    public class RIS_PATSTATUS
    {
        public RIS_PATSTATUS() { }

        public int STATUS_ID { get; set; }
        public string STATUS_UID { get; set; }
        public string STATUS_TEXT { get; set; }
        public char IS_DEFAULT { get; set; }
        public char IS_ACTIVE { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
    }
}