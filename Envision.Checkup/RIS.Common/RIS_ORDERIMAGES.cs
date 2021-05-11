using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace RIS.Common
{
    public class RIS_ORDERIMAGE
    {
        public int ORDER_IMAGE_ID { get; set; }
        public string HN { get; set; }
        public int ORDER_ID { get; set; }
        public Byte SL_NO { get; set; }
        public string IMAGE_NAME { get; set; }
        public int ORG_ID { get; set; }
        public char IS_DELETED { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public int SCHEDULE_ID { get; set; }
    }
}
