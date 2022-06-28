using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_EXAMRESULT_DTL
    {
        public int RIS_EXAMRESULT_DTL_ID { get; set; }
        public int RPT_FINDING_DTL_ITEM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int ORDER_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string INPUT_TEXT { get; set; }
        public char IS_ACTIVE { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
