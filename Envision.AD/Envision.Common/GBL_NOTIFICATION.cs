using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class GBL_NOTIFICATION
    {
        public GBL_NOTIFICATION() { }

        public int MODE { get; set; }
        public int NOTIFICATION_ID { get; set; }
        public string NOTIFICATION_UID { get; set; }
        public string NOTIFICATION_DESC { get; set; }
        public string SUBJECT { get; set; }
        public int NOTIFICATION_EMP_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
