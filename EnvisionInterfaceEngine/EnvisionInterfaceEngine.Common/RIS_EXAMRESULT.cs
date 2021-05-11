using System;
namespace EnvisionInterfaceEngine.Common
{
    public class RIS_EXAMRESULT
    {
        public int ORDER_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public string RESULT_TEXT_HTML { get; set; }
        public string RESULT_TEXT_PLAIN { get; set; }
        public string RESULT_TEXT_RTF { get; set; }
        public char RESULT_STATUS { get; set; }
		public int ORG_ID { get; set; }
		public int LAST_MODIFIED_BY { get; set; }
		public DateTime LAST_MODIFIED_ON { get; set; }
    }
}