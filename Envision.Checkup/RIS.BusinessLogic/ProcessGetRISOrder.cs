using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOrder : IBusinessLogic
	{
        RISOrder _risorder;
		private DataSet result;
        private int OrderID, RegID;
        private int action;
        private int spType;
        private DateTime dt;
         
        
        public ProcessGetRISOrder(int SpType,DateTime dt) {
            OrderID = 0;
            RegID = 0;
            action = 0;
            _risorder = new RISOrder();
            spType = SpType;
            this.dt = dt;

        }
		public ProcessGetRISOrder(int orderID,int regID)
		{
            OrderID = orderID;
            RegID = regID;
            action = 1;
			_risorder = new  RISOrder();
            spType = 0;
            dt = DateTime.Today;
		}

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISOrderSelectData _proc = null;
            if (action == 0)
               _proc = new RISOrderSelectData(spType, dt);
            else
               _proc = new RISOrderSelectData(OrderID, RegID);
            result = _proc.GetData().Copy();
		}

        public DataTable Get7Days(int spType,DateTime dtOrder,int regID) {
            RISOrderSelectData _proc = new RISOrderSelectData();
            DataSet ds = _proc.Performance7Days(spType, dtOrder, regID);
            return ds.Tables[0].Copy();
        }
        public DataTable Get7DaysCompare(DateTime dtPer)
        {
            DataTable dtt = new DataTable("7Days");
           
            dtt.Columns.Add("Day", typeof(string));
            dtt.Columns.Add("Min", typeof(decimal));
            dtt.Columns.Add("Max", typeof(decimal));
            dtt.Columns.Add("MinAll", typeof(decimal));
            dtt.Columns.Add("MaxAll", typeof(decimal));

            return dtt;
        }
        public DataSet PreviosOrder(string HN) {
            
            DataSet ds = new DataSet();
            try
            {
                RISOrderSelectData _proc = new RISOrderSelectData();
                ds = _proc.GetPrevoisOrder(HN);
            }
            catch (Exception ex) { 
            
            }
            return ds;
        }
        public DataSet GetReprint(int SpType) {
            DataSet ds = new DataSet();
            RISOrderSelectData _proc = new RISOrderSelectData();
            ds = _proc.GetReprint(SpType);
            return ds;
        }
        public DataTable GetLastOrder(int UserID) {
            DataTable dtt = null;
            RISOrderSelectData _proc = new RISOrderSelectData();
            DataSet ds = _proc.GetLastOrder(UserID);
            if(ds!=null)
                if (ds.Tables.Count > 0)
                {
                    dtt = ds.Tables[0].Copy();
                }
            return dtt;
        }
        public DataTable GetPrintData(int OrderID, int UserID) {
            RISOrderSelectData process = new RISOrderSelectData();
            DataSet ds = process.GetPrintOrder(OrderID, UserID);
            DataTable dtt = new DataTable();
            if(ds!=null)
                if (ds.Tables.Count > 0)
                    dtt = ds.Tables[0].Copy();
            return dtt;
        }
        public DataTable GetPrintStickerData(string HN, int Exam_ID) {
            RISOrderSelectData process = new RISOrderSelectData();
            DataSet ds = process.GetPrintSticker(HN, Exam_ID);
            DataTable dtt = new DataTable();
            if (ds != null)
                if (ds.Tables.Count > 0)
                    dtt = ds.Tables[0].Copy();
            return dtt;
        }
	}
}

