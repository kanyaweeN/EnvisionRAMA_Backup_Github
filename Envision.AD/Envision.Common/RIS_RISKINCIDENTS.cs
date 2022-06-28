using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_RISKINCIDENTS
    {
        public int INCIDENT_ID { get; set; }
        public string INCIDENT_UID { get; set; }
        public DateTime INCIDENT_DT { get; set; }
        public int RISK_CAT_ID { get; set; }
        public string INCIDENT_SUBJ { get; set; }
        public string INCIDENT_DESC { get; set; }
        public int COMMENT_ID { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string PRIORITY { get; set; }
        public int REG_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int XRAYREQ_ID { get; set; }
        public string INCIDENT_CHOOSED { get; set; }
    }
}
