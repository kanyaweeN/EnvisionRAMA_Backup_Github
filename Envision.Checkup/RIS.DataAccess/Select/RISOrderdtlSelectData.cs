//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISOrderdtlSelectData : DataAccessBase
    {
        private RISOrderdtl _risorderdtl;
        private DateTime start, end;
        private string hn;
        private char Type;
        private int RegID;
        private RISOrderdtlInsertDataParameters _risorderdtlinsertdataparameters;

        public RISOrderdtlSelectData() {
            _risorderdtl = new RISOrderdtl();
            start = DateTime.Today;
            end = DateTime.Today;
        }
        public RISOrderdtlSelectData(DateTime dtStart,DateTime dtEnd)
        {
            _risorderdtl = new RISOrderdtl();
            start = dtStart;
            end = dtEnd;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Select.ToString();
        }
        public RISOrderdtlSelectData(char type,int order, int regID)
        {
            _risorderdtl = new RISOrderdtl();
            RISOrderdtl.ORDER_ID = order;
            Type = type;
            RegID = regID;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_SelectByOrderID.ToString();
        }
        public RISOrderdtlSelectData(string HN) {
            _risorderdtl = new RISOrderdtl();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectByHN.ToString();
            hn = HN;
        }

        public RISOrderdtl RISOrderdtl
        {
            get { return _risorderdtl; }
            set { _risorderdtl = value; }
        }

        public string GenAccessionNo(int ModalityID) {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_GenAccession.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString,new SqlParameter[]{new SqlParameter("@MODALITY",ModalityID)});
            string ret = ds.Tables[0].Rows[0][0].ToString().Trim();
            ret = ret == null ? string.Empty : ret;
            return ret;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            switch (StoredProcedureName)
            {
                case "Prc_RIS_ORDER_Select" :
                    _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(start, end);
                    break;
                case "Prc_RIS_ORDERDTL_SelectByOrderID" :
                    _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(Type,_risorderdtl.ORDER_ID, RegID);
                    break;
                case "Prc_RIS_ORDER_SelectByHN" :
                    _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(hn);
                    break;
            }
            ds = dbhelper.Run(base.ConnectionString, _risorderdtlinsertdataparameters.Parameters);
            return ds;
        }
        public DataSet GetRadioLogist()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectRadiologist.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
        public DataSet GetRadioLogistWork(int RadioID,DateTime ExamDate) {
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RadioID, ExamDate);
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectRadioWork.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString,_risorderdtlinsertdataparameters.Parameters);
            return ds;
        }
        public DataSet GetDataCapture(DateTime dtFrom, DateTime dtTo)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_SelectByCapture.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@dtFrom", dtFrom), new SqlParameter("@dtTo", dtTo) };
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
        public DataSet GetDataQA(DateTime dtFrom,DateTime dtTo)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_SelectByQA.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@dtFrom", dtFrom), new SqlParameter("@dtTo", dtTo) };
            ds = dbhelper.Run(base.ConnectionString,param);
            return ds;
        }
        public DataSet GetPreview(string accessionNo) {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_SelectByPreview.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@ACCESSION_NO", accessionNo)};
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
        public DataSet GetReport_OrderDTL(DateTime FromDate, DateTime ToDate, int UserID)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_Select_rptOrderDTL.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(FromDate, ToDate, UserID);
            ds = dbhelper.Run(base.ConnectionString, _risorderdtlinsertdataparameters.Parameters);
            return ds;
        }
    }

    public class RISOrderdtlInsertDataParameters
    {

        private SqlParameter[] _parameters;
        private DateTime dtFrom, dtTo;

        public RISOrderdtlInsertDataParameters(DateTime dtFrom, DateTime dtTo)
        {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            Build_SearchByDate();
        }
        public RISOrderdtlInsertDataParameters(char Type,int OrderID, int RegID) {
           
            Build_SearchByOrderID(Type,OrderID,RegID);
        }
        public RISOrderdtlInsertDataParameters(int RadioID, DateTime ExamDateTime) {
            Build_SearchByRadioLogistWork(RadioID, ExamDateTime);
        }
        public RISOrderdtlInsertDataParameters(string HN) {
            Build_SearchByHN(HN);
        }
        public RISOrderdtlInsertDataParameters(DateTime FromDate, DateTime ToDate, int UserID)
        {
            BuildReport(FromDate, ToDate, UserID);
        }

        public SqlParameter[] Parameters 
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build_SearchByDate()
        {
            SqlParameter[] parameters ={ new SqlParameter("@DateFrom", dtFrom), new SqlParameter("@DateTo", dtTo) };
            Parameters = parameters;
        }
        public void Build_SearchByOrderID(char Type,int OrderID,int RegID)
        {
            SqlParameter[] parameters ={ 
                    new SqlParameter("@Type", Type)
                    ,new SqlParameter("@ORDER_ID", OrderID)
                    ,new SqlParameter("@REG_ID", RegID)
            };
            Parameters = parameters;
        }
        public void Build_SearchByRadioLogistWork(int RadioID, DateTime ExamDateTime) {
            SqlParameter[] parameters ={ 
                    new SqlParameter("@ASSIGNED_TO", RadioID)
                    ,new SqlParameter("@EXAM_DT", ExamDateTime)
            };
            Parameters = parameters;
        }
        public void Build_SearchByHN(string HN) {
            SqlParameter[] parameters ={ 
                new SqlParameter("@HN", HN)
            };
            Parameters = parameters;
        }
        public void BuildReport(DateTime FromDate, DateTime ToDate, int UserID)
        {
            SqlParameter[] parameters ={ 
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@USER_ID",UserID)
            };
            Parameters = parameters;
        }
    }
}

