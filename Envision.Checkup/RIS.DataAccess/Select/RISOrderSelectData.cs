using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISOrderSelectData : DataAccessBase 
	{
		private RISOrder	_risorder;
		private RISOrderInsertDataParameters	_risorderinsertdataparameters;
        private int OrderID, RegID;
        private int action;
        private int spType;
        private DateTime dt;
        public RISOrderSelectData() {
            OrderID = 0;
            RegID = 0;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectAll.ToString();
            action = 0;
            this.spType = 0;
            this.dt = DateTime.Today;
        }
        public RISOrderSelectData(int spType, DateTime dt)
        {
            OrderID = 0;
            RegID = 0;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectAll.ToString();
            action = 0;
            this.spType = spType;
            this.dt = dt;
        }
		public RISOrderSelectData(int orderID,int regID)
		{
            OrderID = orderID;
            RegID = regID;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectByOrderID.ToString();
            action = 1;
            spType = 0;
            dt = DateTime.Today;
            if (orderID > 0 && regID > 0)
                RegID = 0;
		}
		public RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public DataSet GetData()
		{
            if (action == 0) 
                _risorderinsertdataparameters=new RISOrderInsertDataParameters(spType,dt);
            else
                _risorderinsertdataparameters = new RISOrderInsertDataParameters(OrderID, RegID);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risorderinsertdataparameters.Parameters);
			return ds;
		}
        public DataSet Performance7Days(int SpType,DateTime OrderDT,int RegID) {
            RISOrderPerformance _perform = new RISOrderPerformance(SpType, OrderDT, RegID);
            StoredProcedureName = StoredProcedure.Name.Prc_ViewPerformance_Select.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, _perform.Parameters);
            return ds;
        }
        public DataSet GetPrevoisOrder(string HN) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectPreviousOrder.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter param = new SqlParameter("@HN", HN);
            DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { param });
            return ds;
        }
        public DataSet GetReprint(int SpType) { 
            //SpType    0   : print order
            //          1   : print screen
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Reprint.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { new SqlParameter("@SPType", SpType) });
            return ds;
        }
        public DataSet GetLastOrder(int UserID) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectByLastOrder.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            return ds;
        }
        public DataSet GetPrintOrder(int OrderID, int UserID) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_REPORT.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,new SqlParameter[]{new SqlParameter("@ORDER_ID",OrderID),new SqlParameter("@UserID",UserID)});
            return ds;
        }
        public DataSet GetPrintSticker(string HN, int Exam_ID)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_ReprintSticker.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { new SqlParameter("@HN", HN), new SqlParameter("@EXAM_ID", Exam_ID) });
            return ds;
        }
	}
	public class RISOrderInsertDataParameters 
	{
		private RISOrder _risorder;
		private SqlParameter[] _parameters;
        private int orderID, regID;

        public RISOrderInsertDataParameters(int spType, DateTime dt) {
            BuildSelectAll(spType, dt);
        }
		public RISOrderInsertDataParameters(int OrderID,int RegID)
		{
            //RISOrder=risorder;
            orderID = OrderID;
            regID = RegID;
			Build();
		}
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            //SqlParameter[] parameters ={new SqlParameter("@ORDER_ID",RISOrder.ORDER_ID),new SqlParameter("@REG_ID",RISOrder.REG_ID),new SqlParameter("@HN",RISOrder.HN),new SqlParameter("@VISIT_NO",RISOrder.VISIT_NO),new SqlParameter("@ADMISSION_NO",RISOrder.ADMISSION_NO)
            //,new SqlParameter("@ORDER_DT",RISOrder.ORDER_DT),new SqlParameter("@EST_START_TIME",RISOrder.EST_START_TIME),new SqlParameter("@SCHEDULE_ID",RISOrder.SCHEDULE_ID),new SqlParameter("@REFER_FROM",RISOrder.REFER_FROM),new SqlParameter("@REF_DOC_INSTRUCTION",RISOrder.REF_DOC_INSTRUCTION)
            //,new SqlParameter("@CLINICAL_INSTRUCTION",RISOrder.CLINICAL_INSTRUCTION),new SqlParameter("@REASON",RISOrder.REASON),new SqlParameter("@DIAGNOSIS",RISOrder.DIAGNOSIS),new SqlParameter("@ICD_ID",RISOrder.ICD_ID),new SqlParameter("@ARRIVAL_BY",RISOrder.ARRIVAL_BY)
            //,new SqlParameter("@ARRIVAL_ON",RISOrder.ARRIVAL_ON),new SqlParameter("@SELF_ARRIVAL",RISOrder.SELF_ARRIVAL),new SqlParameter("@ORG_ID",RISOrder.ORG_ID),new SqlParameter("@CREATED_BY",RISOrder.CREATED_BY),new SqlParameter("@CREATED_ON",RISOrder.CREATED_ON)
            //,new SqlParameter("@LAST_MODIFIED_BY",RISOrder.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISOrder.LAST_MODIFIED_ON)};
            SqlParameter[] parameters ={ new SqlParameter("@ORDER_ID", orderID), new SqlParameter("@REG_ID", regID) };
            Parameters = parameters;
		}
        public void BuildSelectAll(int spType,DateTime dt) {
            SqlParameter[] parameters ={ 
                    new SqlParameter("@SPType", spType), new SqlParameter("@dt", dt) };
            Parameters = parameters;
        }
	}
    public class RISOrderPerformance{
        private int spType;
        private DateTime orderDT;
        private int regID;
        private SqlParameter[] _parameters;

        public RISOrderPerformance(int SpType, DateTime OrderDT, int RegID) {
            this.spType = SpType;
            this.orderDT = OrderDT;
            this.regID = RegID;
            Build();
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public void Build() {
            SqlParameter[] parameters ={ 
                    new SqlParameter("@SPType", spType)
                    ,new SqlParameter("@ORDER_DT", orderDT) 
                    ,new SqlParameter("@REG_ID", regID) 
            };
            Parameters = parameters;
        }
    }
}

