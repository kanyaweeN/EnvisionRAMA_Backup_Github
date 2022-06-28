using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_CONTRASTLOT
    {
        public int LOT_ID { get; set; }
        public string LOT_UID { get; set; }
        public string LOT_TEXT { get; set; }
        public string IS_ACTIVE { get; set; }
        public DateTime EXPIRED_DATETIME { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
