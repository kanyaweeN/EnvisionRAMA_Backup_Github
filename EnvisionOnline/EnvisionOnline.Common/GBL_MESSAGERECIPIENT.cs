using System;

namespace EnvisionOnline.Common
{
    public class GBL_MESSAGERECIPIENT
    {
        public int MSG_ID { get; set; }
        public int CC_TO { get; set; }
        public char IS_STARRED { get; set; }
        public char IS_DELETED { get; set; }
        public DateTime ACK_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string RECIPIENT_TYPE { get; set; }
        public string IS_TRASHED { get; set; }
        public int SP_TYPE { get; set; }
        public object Parameter(string p, int p_2)
        {
            throw new NotImplementedException();
        }
    }
}
