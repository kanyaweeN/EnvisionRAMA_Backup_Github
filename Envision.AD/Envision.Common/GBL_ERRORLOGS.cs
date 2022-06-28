using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class GBL_ERRORLOGS
    {
        public int ERROR_ID { get; set; }
        public string USER_LOGIN { get; set; }
        public string USER_HOST_ADDRESS { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string ERROR_SOURCE { get; set; }
        public string ERROR_FORM { get; set; }
        public string PIC_PATH { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }

        public string AAA_IS_SCHEDULE { get; set; }
        public int AAA_SCHEDULE_ID { get; set; }
        public int AAA_ORDER_ID { get; set; }
        public string AAA_SCHEDULELOG_DESC { get; set; }
        public int AAA_LAST_MODIFIED_BY { get; set; }
    }
}
