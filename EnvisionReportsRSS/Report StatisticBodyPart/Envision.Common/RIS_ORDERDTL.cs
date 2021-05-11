using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_ORDERDTL
    {
        public int ORDER_ID { get; set; }
        public int EXAM_ID  { get; set; }
        public string ACCESSION_NO { get; set; }
        public string Q_NO { get; set; }
        public int MODALITY_ID { get; set; }
        public DateTime EXAM_DT { get; set; }
        public int SERVICE_TYPE { get; set; }
        public int QTY { get; set; }
        public DateTime EST_START_TIME { get; set; }
        public int ASSIGNED_TO { get; set; }
        public string HL7_TEXT { get; set; }
        public string HL7_SENT { get; set; }
        public string RATE { get; set; }
        public string COMMENTS { get; set; }
        public string SPECIAL_CLINIC { get; set; }
        public string SELF_ARRIVAL { get; set; }
        public int IMAGE_CAPTURED_BY { get; set; }
        public DateTime IMAGE_CAPTURED_ON { get; set; }
        public int QA_BY { get; set; }
        public DateTime QA_ON { get; set; }
        public int ORG_ID { get; set; }
        public string PRIORITY { get; set; }
        public string STATUS { get; set; }
        public string IS_DELETED { get; set; }
        public int ASSIGNED_BY { get; set; }
        public DateTime ASSIGNED_TIMESTAMP { get; set; }
        public int CLINIC_TYPE { get; set; }
        public int BPVIEW_ID { get; set; }
        public string MERGE { get; set; }
        public string MERGE_WITH { get; set; }
        public string HIS_SYNC { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY{ get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string HIS_ACK { get; set; }
        public int PREPARATION_ID { get; set; }
        public string COMMENTS_ONLINE { get; set; }
        public int IMAGECOUNT { get; set; }
        public string HAS_COMMENT { get; set; }
        public string INSTANCE_UID { get; set; }
        public int AE_TITLE_ID { get; set; }
        public int WORK_STATION_ID { get; set; }
    }
}
