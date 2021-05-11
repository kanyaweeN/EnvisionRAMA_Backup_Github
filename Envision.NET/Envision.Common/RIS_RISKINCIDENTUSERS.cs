using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_RISKINCIDENTUSERS
    {
        public int INCIDENT_ID { get; set; }
        public int EMP_ID { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
