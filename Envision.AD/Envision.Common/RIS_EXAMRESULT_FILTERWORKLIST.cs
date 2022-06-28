using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_EXAMRESULT_FILTERWORKLIST
    {
        public int FILTER_ID { get; set; }
        public string FILTER_NAME { get; set; }
        public string FILTER_DETAIL { get; set; }
        public int CRAETED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }

        public int EMP_ID { get; set; }
    }
}
