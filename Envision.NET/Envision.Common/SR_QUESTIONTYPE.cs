using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class SR_QUESTIONTYPE
    {
        public int Q_TPYE_ID { get; set; }
        public string Q_TPYE_NAME { get; set; }
        public string Q_TYPE_DESC { get; set; }
        public string IS_ACTIVE { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
