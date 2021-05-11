using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_MODALITY
    {
        public int MODALITY_ID { get; set; }
        public string MODALITY_UID { get; set; }
        public string MODALITY_NAME { get; set; }
        public int MODALITY_TYPE { get; set; }
        public string ALLPROPERTIES { get; set; }
        public int UNIT_ID { get; set; }
        public string IS_ACTIVE { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public int AVG_INV_TIME { get; set; }
        public int ROOM_ID { get; set; }
        public int CASE_PER_DAY { get; set; }
        public string RESTRICT_LEVEL { get; set; }
        public string IS_UPDATED { get; set; }
        public string IS_DELETED { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON  { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string IS_VISIBLE { get; set; }
        public string IS_DEFUALT { get; set; }
        public string IS_DEFAULT { get; set; }
        public int PAT_DEST_ID { get; set; }
        public string ANNOUNCE { get; set; }


    }
}
