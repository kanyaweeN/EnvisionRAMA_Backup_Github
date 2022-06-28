using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class SR_TEMPLATE
    {
        public int TEMPLATE_ID { get; set; }
        public string TEMPLATE_NAME { get; set; }
        public string IS_ACTIVE { get; set; }
        public int EXAM_ID { get; set; }
        public int BP_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string RSNA_URL { get; set; }
        public int LANG_ID { get; set; }
        public int ORG_ID { get; set; }
        public int USER_ID { get; set; }
        public string CREATOR { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
