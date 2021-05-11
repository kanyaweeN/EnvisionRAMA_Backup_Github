using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_PATIENTDESTINATION
    {
        public int PAT_DEST_ID { get; set; }
        public string TYPE { get; set; }
        public string LABEL { get; set; }
        public string ENCOUNTER_TYPE { get; set; }
        public string ENCOUNTER_CLINIC_TYPE { get; set; }
        public string ORDERING_DEPT { get; set; }
        public int EXAM_UNIT { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
