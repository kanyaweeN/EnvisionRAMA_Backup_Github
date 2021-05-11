using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_SCHEDULELOGS
    {
        public int SCHEDULELOG_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int REG_ID { get; set; }
        public DateTime SCHEDULE_DT { get; set; }
        public int MODALITY_ID { get; set; }
        public string SCHEDULE_DATA { get; set; }
        public int SESSION_ID { get; set; }
        public DateTime START_DATETIME { get; set; }
        public DateTime END_DATETIME { get; set; }
        public int REF_UNIT { get; set; }
        public int REF_DOC { get; set; }
        public string REF_DOC_INSTRUCTION { get; set; }
        public string CLINICAL_INSTRUCTION { get; set; }
        public string REASON { get; set; }
        public string DIAGNOSIS { get; set; }
        public int PAT_STATUS { get; set; }
        public DateTime LMP_DT { get; set; }
        public int ICD_ID { get; set; }
        public char SCHEDULE_STATUS { get; set; }
        public int INSURANCE_TYPE_ID { get; set; }
        public int CONFIRMED_BY { get; set; }
        public DateTime CONFIRMED_ON { get; set; }
        public char IS_BLOCKED { get; set; }
        public string BLOCK_REASON { get; set; }
        public string COMMENTS { get; set; }
        public char IS_REQONLINE { get; set; }
        public bool ALLDAY { get; set; }
        public int EVENTTYPE { get; set; }
        public string RECURRENCEINFO { get; set; }
        public int LABEL { get; set; }
        public string LOCATION { get; set; }
        public int STATUS { get; set; }
        public char IS_BUSY { get; set; }
        public DateTime REQUESTED_SCHEDULE_DT { get; set; }
        public int SCHEDULE_EXCEED_BY { get; set; }
        public int WL_CONFIRMED_BY { get; set; }
        public DateTime WL_CONFIRMED_ON { get; set; }
        public int ENC_ID { get; set; }
        public string ENC_TYPE { get; set; }
        public string ENC_CLINIC { get; set; }
        public char NOTIFY_ADMIN_WL { get; set; }
        public char HIS_SYNC { get; set; }
        public string ADMISSION_NO { get; set; }
        public int PENDING_BY { get; set; }
        public DateTime PENDING_ON { get; set; }
        public char IS_COMMENTS { get; set; }
        public int BUSY_BY { get; set; }
        public DateTime BUSY_ON { get; set; }
        public string PENDING_COMMENTS { get; set; }
        public int ORG_ID { get; set; }
        public int LOGS_MODIFIED_BY { get; set; }
        public DateTime LOGS_MODIFIED_ON { get; set; }
        public string LOGS_DESC { get; set; }
        public char LOGS_STATUS { get; set; }

    }
}
