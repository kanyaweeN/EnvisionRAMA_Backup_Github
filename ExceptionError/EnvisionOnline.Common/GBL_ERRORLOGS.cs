using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{
    public partial class GBL_ERRORLOGS
    {
        public int ERROR_ID { get; set; }
        public string USER_LOGIN { get; set; }
        public string USER_HOST_ADDRESS { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string ERROR_SOURCE { get; set; }
        public string PIC_PATH { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}