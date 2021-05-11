using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOrderdtl : IBusinessLogic
	{
		private DataSet result;
        private DateTime dtFrom, dtTo;
        private RISOrderdtl risOrderdtl;
        private int action = 0;
        private int RegID = 0;
        private char type;
        private string hn = string.Empty;

        public ProcessGetRISOrderdtl() {
            risOrderdtl = new RISOrderdtl();
            action = 0;
        }
        public ProcessGetRISOrderdtl(DateTime dtFrom, DateTime dtTo) {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            action = 0;
        }
        public ProcessGetRISOrderdtl(char type, int order, int regID) {
            risOrderdtl = new RISOrderdtl();
            risOrderdtl.ORDER_ID = order;
            RegID = regID;
            this.type = type;
            action = 1;
        }
        public ProcessGetRISOrderdtl(string HN) {
            risOrderdtl = new RISOrderdtl();
            action = 2;
            hn = HN;
        }

		public DataSet Result 
		{
			get{return result;}
			set{result=value;}
		}

        public RISOrderdtl RISOrderdtl {
            get { return risOrderdtl; }
            set { risOrderdtl = value; }
        }

        public DataTable GetRadioLogist() {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds=_proc.GetRadioLogist();
            DataTable dt=new DataTable("HR_EMP");
            dt = ds.Tables[0].Copy();
            return dt;
        }
        public DataTable GetRadioLogistWork(int RadioID,DateTime examDate) {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetRadioLogistWork(RadioID, examDate);
            DataTable dt = new DataTable("HR_EMP");
            dt = ds.Tables[0].Copy();
            return dt;
        }
        public DataSet GetDataCapture(DateTime dtFrom, DateTime dtTo)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataCapture(dtFrom, dtTo);
            return ds.Copy();
        }
        public DataSet GetDataQA(DateTime dtFrom,DateTime dtTo) {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataQA(dtFrom, dtTo);
            return ds.Copy();
        }
        public DataSet GetPreview(string AcessionNo) {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetPreview(AcessionNo);
            return ds.Copy();
        }

        public string GetAccessionNo(int Modality) {
            RISOrderdtlSelectData proc = new RISOrderdtlSelectData();
            return proc.GenAccessionNo(Modality);
        }

        public DataSet rptOrderDTL(DateTime FromDate, DateTime ToDate, int UserID)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetReport_OrderDTL(FromDate, ToDate, UserID);
            return ds;
        }

		public void Invoke()
		{
            RISOrderdtlSelectData _proc=null;
            switch (action)
            { 
                case 0:
                    _proc = new RISOrderdtlSelectData(dtFrom, dtTo);
                    break;
                case 1:
                    _proc = new RISOrderdtlSelectData(type, risOrderdtl.ORDER_ID, RegID);
                    break;
                case 2:
                    _proc = new RISOrderdtlSelectData(hn);
                    break;
            }
            result = _proc.GetData();
		}
	}
}

