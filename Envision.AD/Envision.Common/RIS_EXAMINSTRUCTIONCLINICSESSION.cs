using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_EXAMINSTRUCTIONCLINICSESSION
    {
        public int INS_ID { get; set; }
        public int EXAM_ID { get; set; }
        public int SESSION_ID { get; set; }
        public string INS_UID { get; set; }
        public string INS_TEXT { get; set; }
        public string INS_TEXT_KID { get; set; }
        public string IS_UPDATED { get; set; }
        public int CREATED_BY { get; set; }
    }
}
