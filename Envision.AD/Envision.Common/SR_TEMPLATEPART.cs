using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class SR_TEMPLATEPART
    {
        public int PART_ID { get; set; }
        public string PART_NAME { get; set; }
        public int TEMPLATE_ID { get; set; }
        public int SL { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
