using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIS.Common
{
    public class RIS_HL7IELOG
    {
        public int MODE { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }

        public int LOG_ID { get; set; }
        public string SENDER { get; set; }
        public string RECEIVER { get; set; }
        public string MESSAGE_TYPE { get; set; }
        public string EVENT_TYPE { get; set; }
        public string HN { get; set; }
        public string ACCESSION_NO { get; set; }
        public string COMPARE_VALUE { get; set; }
        public char STATUS { get; set; }
        public string HL7_TEXT { get; set; }
        public string ACKNOWLEDGMENT_CODE { get; set; }
        public string TEXT_MESSAGE { get; set; }
        public char IS_LOCK { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public char IS_DELETED { get; set; }
        public int SENDER_ID { get; set; }
        public int RECEIVER_ID { get; set; }
    }
}

