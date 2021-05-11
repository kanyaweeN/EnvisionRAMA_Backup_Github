using System;

namespace EnvisionInterfaceEngine.Common.HL7.Segment
{
    public class MSH
    {
        public MSH()
        {
            MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            PROCESSING_ID = "P";
            VERSION_ID = "2.3";
		}

		public string SENDING_APPLICATION { get; set; }
		public string RECEIVING_APPLICATION { get; set; }
		public string MESSAGE_TYPE { get; set; }
		public string MESSAGE_CONTROL_ID { get; set; }
		public string PROCESSING_ID { get; set; }
		public string VERSION_ID { get; set; }
    }
}