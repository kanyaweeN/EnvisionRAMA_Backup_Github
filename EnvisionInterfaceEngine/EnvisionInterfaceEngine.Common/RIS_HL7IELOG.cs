using System;

namespace EnvisionInterfaceEngine.Common
{
    public class RIS_HL7IELOG
    {
		public RIS_HL7IELOG()
		{
			IS_DELETED = 'N';
		}

		public int LOG_ID { get; set; }
		public int SENDER_ID { get; set; }
		//public string SENDER { get; set; }
		public int RECEIVER_ID { get; set; }
		//public string RECEIVER { get; set; }
		public string MESSAGE_TYPE { get; set; }
		public string EVENT_TYPE { get; set; }
		public string HN { get; set; }
		public string ACCESSION_NO { get; set; }
		public string COMPARE_VALUE { get; set; }
		public char IS_DELETED { get; set; }
        public char STATUS { get; set; }
        public string HL7_TEXT { get; set; }
        public string ACKNOWLEDGMENT_CODE { get; set; }
        public string TEXT_MESSAGE { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
    }
}