using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class MG_BREASTMARK
    {
        public int BREAST_MARK_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int BREAST_SCREEN_WIDTH { get; set; }
        public int BREAST_SCREEN_HIGHT { get; set; }
        public byte[] BREAST_SCREEN_IMG { get; set; }
        public int BREAST_SCREEN_SCALE { get; set; }
        public int NO_OF_MASS { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
