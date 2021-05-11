using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class VNA_WORKLIST
    {
        public VNA_WORKLIST()
        {
        }
        public int VNA_ID { get; set; }
        public string VN { get; set; }
        public int REF_UNIT { get; set; }
        public int REG_ID { get; set; }
        public int ORG_ID { get; set; }
        public int ENC_ID { get; set; }
        public string ENC_TYPE { get; set; }
        public string SDLOC_ID { get; set; }
        public string INSURANCE { get; set; }
        public DateTime EFFECTIVE_START_DATE { get; set; }
        public string CREATED_BY_UID { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string LAST_MODIFIED_BY_UID { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }

        public int MODE { get; set; }
        public string HN { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
    }
}
