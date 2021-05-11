using System;

namespace EnvisionInterfaceEngine.Common
{
    public class RIS_ORDERDTL
    {
        public RIS_ORDERDTL()
        {
			QTY = 1;
            RATE = decimal.Zero;
            STATUS = 'A';
            PRIORITY = 'R';
            IS_DELETED = 'N';
			HIS_SYNC = 'N';
        }

        public int ORDER_ID { get; set; }
        public DateTime EXAM_DT { get; set; }
        public string Q_NO { get; set; }
        public string ACCESSION_NO { get; set; }
        public int EXAM_ID { get; set; }
        public int SERVICE_TYPE { get; set; }
        public int MODALITY_ID { get; set; }
		public int ASSIGNED_TO { get; set; }
        public string INSTANCE_UID { get; set; }
		public int AE_TITLE_ID { get; set; }
        public int QTY { get; set; }
        public decimal RATE { get; set; }
        public int CLINIC_TYPE { get; set; }
        public char PRIORITY { get; set; }
		public char STATUS { get; set; }
		public int IMAGE_CAPTURED_BY{ get; set; }
		public DateTime IMAGE_CAPTURED_ON { get; set; }
        public int IMAGECOUNT { get; set; }
        public char IS_DELETED { get; set; }
        public string COMMENTS { get; set; }
		public char HIS_SYNC { get; set; }
		public int WORK_STATION_ID { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
    }
}