using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISOrderSelectData : DataAccessBase
    {
        public RIS_ORDER RIS_ORDER { get; set; }
        private int OrderID, RegID;
        private int action;
        private int spType;
        private DateTime dt;

        public RISOrderSelectData()
        {
            OrderID = 0;
            RegID = 0;
            action = 0;
            this.spType = 0;
            this.dt = DateTime.Today;
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectAll;

        }
        public RISOrderSelectData(int spType, DateTime dt)
        {
            OrderID = 0;
            RegID = 0;
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectAll;
            action = 0;
            this.spType = spType;
            this.dt = dt;
        }
        public RISOrderSelectData(int orderID, int regID)
        {
            OrderID = orderID;
            RegID = regID;
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectByOrderID;// Prc_RIS_ORDER_SelectAll;
            action = 1;
            spType = 0;
            dt = DateTime.Today;
            if (orderID > 0 && regID > 0)
                RegID = 0;
        }

        public DataSet GetData()
        {
            if (action == 0)
                ParameterList = buildParameter();
            else
                ParameterList = buildParameterOrder();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet Performance7Days(int SpType, DateTime OrderDT, int RegID)
        {
            ParameterList = buildParameterPerformance();
            StoredProcedureName = StoredProcedure.Prc_ViewPerformance_Select;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPrevoisOrder(string HN)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectPreviousOrder;
            ParameterList = buildParameterPreviosOrder(HN);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetReprint(int SpType)
        {
            //SpType    0   : print order
            //          1   : print screen
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Reprint;
            ParameterList = buildParameterReprint(SpType);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetLastOrder(int UserID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectByLastOrder;
            ParameterList = buildParameterLastOrder(UserID);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPrintOrder(int OrderID, int UserID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_REPORT;
            ParameterList = buildParameterPrintOrder(OrderID, UserID);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPrintSticker(string HN, int Exam_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_ReprintSticker;
            ParameterList = buildParameterPrintSticker(HN, Exam_ID);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetOrderByXray()
        {
            ParameterList = buildParameterXrayNo();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectByXrayNumber;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt.Copy();
        }
        public DataSet GetCancelTemplate()//เพิ่มตรงนี้ครับ
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_CancelTemplate;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetOrderCancelWorklist(DateTime START_DATE, DateTime END_DATE)//เพิ่มตรงนี้ครับ
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Select_frmOrderIsCancel;
            ParameterList
                = new DbParameter[] 
                    { 
                        Parameter("@START_DATE", START_DATE)
                        ,Parameter("@END_DATE", END_DATE) 
                    };
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetReportBillingOnline(string setOrderID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_ReportBillingOnline;
            ParameterList = new DbParameter[]
            {
                Parameter("@ORDER_ID", setOrderID)
            };

            return ExecuteDataSet();
        }
        public DataSet GetReportBilling(string setOrderID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_ReportBilling;
            ParameterList = new DbParameter[]
            {
                Parameter("@ORDER_ID", setOrderID)
            };

            return ExecuteDataSet();
        }
        public DataSet GetReprint(int SpType, string HN, DateTime from, DateTime to)
        {
            //SpType    0   : print order with datetime
            //          1   : print screen with datetime
            //          2   : print order with HN
            //          3   : print screen with HN

            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { 
            //    new SqlParameter("@SPType", SpType)
            //    , new SqlParameter("@FROM_DT", from)
            //    , new SqlParameter("@TO_DT", to)
            //    , new SqlParameter("@HN", HN)
            //});

            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Reprint_1;
            ParameterList
                    = new DbParameter[] 
                    { 
                         Parameter("@SPType", SpType)
                        , Parameter("@FROM_DT", from)
                        , Parameter("@TO_DT", to)
                        , Parameter("@HN", HN)
                    };
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }


        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@SPType",spType),
                                          Parameter("@dt",dt),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterOrder()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ORDER_ID",OrderID),
                                          Parameter("@REG_ID",RegID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPerformance()
        {
            DbParameter[] parameters = { 
                                          Parameter("@SPType",spType),
                                          Parameter("@ORDER_DT",dt),
                                          Parameter("@REG_ID",RegID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPreviosOrder(string HN)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterReprint(int Type)
        {
            DbParameter[] parameters = { 
                                          Parameter("@SPType",Type),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterLastOrder(int UserID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UserID",UserID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPrintOrder(int ORDER_ID, int UserID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ORDER_ID",ORDER_ID),
                                           Parameter("@UserID",UserID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPrintSticker(string HN, int EXAM_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                           Parameter("@EXAM_ID",EXAM_ID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterXrayNo()
        {
            DbParameter[] parameters = { 
                                          Parameter("@XRAY_NO",RIS_ORDER.XRAY_NO)
                                       };
            return parameters;
        }
    }
}
