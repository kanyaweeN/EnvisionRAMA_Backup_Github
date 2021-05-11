using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_CLINICALINDICATION
    {
        public int CI_ID { get; set; }
        public string CI_UID { get; set; }
        public string CI_DESC { get; set; }
        public byte CI_LEVEL { get; set; }
        public int CI_PARENT { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string IS_USER_DEFINED { get; set; }
        public int SL_NO { get; set; }
        public string NEED_DETAIL { get; set; }
        public string NEED_DETAILLIST { get; set; }
        public int EMP_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int UNIT_ID { get; set; }
    }
}
