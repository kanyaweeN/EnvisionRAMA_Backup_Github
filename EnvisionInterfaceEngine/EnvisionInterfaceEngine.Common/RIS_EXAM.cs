namespace EnvisionInterfaceEngine.Common
{
    public class RIS_EXAM
    {
		public RIS_EXAM()
		{
			RATE = decimal.Zero;
		}

        public int EXAM_ID { get; set; }
        public string EXAM_UID { get; set; }
        public string EXAM_NAME { get; set; }
		public int EXAM_TYPE { get; set; }
		public int BP_ID { get; set; }
		public int BPVIEW_ID { get; set; }
        public decimal RATE { get; set; }
        public int SERVICE_TYPE { get; set; }
        public int UNIT_ID { get; set; }
        public char QA_REQUIRED { get; set; }
        public char DEFER_HIS_RECONCILE { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
    }
}
