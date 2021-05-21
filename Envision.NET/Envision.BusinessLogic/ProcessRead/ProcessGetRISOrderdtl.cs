using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISOrderdtl : IBusinessLogic
	{
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
		private DataSet result;
        private DateTime dtFrom, dtTo;

        private int action = 0;
        private int RegID = 0;
        private char type;
        private string hn = string.Empty;

        public ProcessGetRISOrderdtl() {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            RIS_ORDERDTL.RIS_ORDER = new RIS_ORDER();
            action = 0;
        }
        public ProcessGetRISOrderdtl(DateTime dtFrom, DateTime dtTo) {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            action = 0;
        }
        public ProcessGetRISOrderdtl(char type, int order, int regID) {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            RIS_ORDERDTL.ORDER_ID = order;
            RegID = regID;
            this.type = type;
            action = 1;
        }
        public ProcessGetRISOrderdtl(string HN) {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            action = 2;
            hn = HN;
        }

		public DataSet Result 
		{
			get{return result;}
			set{result=value;}
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
        public DataSet GetDataCapture(DateTime dtFrom, DateTime dtTo,int empId)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataCapture(dtFrom, dtTo,empId);
            return ds.Copy();
        }
        public DataSet GetDataCapturebyHN(string HN, int empId)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataCapturebyHN(HN, empId);
            return ds.Copy();
        }
        public DataSet GetDataRejectPacsImage(DateTime dtFrom, DateTime dtTo, int empId)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataRejectPacsImage(dtFrom, dtTo, empId);
            return ds.Copy();
        }
        public DataSet GetDataRejectPacsImagebyHN(string HN, int empId)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.GetDataRejectPacsImagebyHN(HN, empId);
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

        //public string GetAccessionNo(int Modality) {
        //    RISOrderdtlSelectData proc = new RISOrderdtlSelectData();
        //    return proc.GenAccessionNo(Modality);
        //}
        public string GetAccessionNo()
        {
            RISOrderdtlSelectData proc = new RISOrderdtlSelectData();
            proc.RIS_ORDERDTL = this.RIS_ORDERDTL;
            return proc.GenAccessionNo();
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
                    _proc = new RISOrderdtlSelectData(type, RIS_ORDERDTL.ORDER_ID, RegID);
                    break;
                case 2:
                    _proc = new RISOrderdtlSelectData(hn);
                    break;
            }
            result = _proc.GetData();
		}

        public DataTable Get_Orderdtl_Intervention(int order_id)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.Get_Orderdtl_Intervention(order_id);
            DataTable dt = new DataTable("Order_Intervent");
            dt = ds.Tables[0].Copy();
            return dt;
        }

        public DataSet getOrderData(DateTime FromDate, DateTime ToDate)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.getOrderData(FromDate, ToDate);
            return ds;
        }
        public DataSet getHL7Message(string MODE, int ORDER_ID)
        {
            RISOrderdtlSelectData _proc = new RISOrderdtlSelectData();
            DataSet ds = _proc.getHL7Message(MODE, ORDER_ID);
            return ds;
        }
	}
}

