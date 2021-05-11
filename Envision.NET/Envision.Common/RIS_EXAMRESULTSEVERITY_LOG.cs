using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_EXAMRESULTSEVERITY_LOG
    {
        public int SEVERITYLOG_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int SEVERITY_ID { get; set; }
        public DateTime VERBAL_DATETIME { get; set; }
        public int VERBAL_TIME { get; set; }
        public int VERBAL_WITH { get; set; }
        public string VERBAL_WITH_NAME { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public int CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public int LAST_MODIFIED_ON { get; set; }
    }
}
