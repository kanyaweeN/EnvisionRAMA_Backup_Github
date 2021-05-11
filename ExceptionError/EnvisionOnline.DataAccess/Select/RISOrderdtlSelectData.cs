using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISOrderdtlSelectData : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        private DateTime start, end;
        private string hn;
        private char Type;
        private int RegID;

        public RISOrderdtlSelectData()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            start = DateTime.Today;
            end = DateTime.Today;
        }
        public RISOrderdtlSelectData(DateTime dtStart, DateTime dtEnd)
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            start = dtStart;
            end = dtEnd;
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Select;
        }
        public RISOrderdtlSelectData(char type, int order, int regID)
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            RIS_ORDERDTL.ORDER_ID = order;
            Type = type;
            RegID = regID;
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_SelectByOrderID;
        }
        public RISOrderdtlSelectData(string HN)
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectByHN;
            hn = HN;
        }

        public string GenAccessionNo(int ModalityID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_GenAccession;
            DataSet ds = new DataSet();
            ParameterList = build_GenAccessionNo(ModalityID);
            ds = ExecuteDataSet();
            string ret = ds.Tables[0].Rows[0][0].ToString().Trim();
            ret = ret == null ? string.Empty : ret;
            return ret;
        }
        private DbParameter[] build_GenAccessionNo(int ModalityID)
        {
            DbParameter[] parameters = { Parameter("@MODALITY", ModalityID) };
            return parameters;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            switch (StoredProcedureName)
            {
                case StoredProcedure.Prc_RIS_ORDER_Select:
                    ParameterList = build_SearchByDate(start, end);
                    break;
                case StoredProcedure.Prc_RIS_ORDERDTL_SelectByOrderID:
                    ParameterList = build_SearchByOrderID(Type, RIS_ORDERDTL.ORDER_ID, RegID);
                    break;
                case StoredProcedure.Prc_RIS_ORDER_SelectByHN:
                    ParameterList = build_SearchByHN(hn);
                    break;
            }
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] build_SearchByDate(DateTime dtFrom, DateTime dtTo)
        {
            DbParameter[] parameters = { Parameter("@DateFrom", dtFrom), Parameter("@DateTo", dtTo) };
            return parameters;
        }
        private DbParameter[] build_SearchByOrderID(char Type, int OrderID, int RegID)
        {
            DbParameter[] parameters ={ 
                    Parameter("@Type", Type)
                    ,Parameter("@ORDER_ID", OrderID)
                    ,Parameter("@REG_ID", RegID)
            };
            return parameters;
        }
        private DbParameter[] build_SearchByHN(string HN)
        {
            DbParameter[] parameters ={ 
                Parameter("@HN", HN)
            };
            return parameters;
        }

        public DataSet GetRadioLogist()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectRadiologist;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetRadioLogistWork(int RadioID, DateTime ExamDate)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectRadioWork;
            DataSet ds = new DataSet();
            ParameterList = build_SearchByRadioLogistWork(RadioID, ExamDate);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] build_SearchByRadioLogistWork(int RadioID, DateTime ExamDateTime)
        {
            DbParameter[] parameters ={ 
                    Parameter("@ASSIGNED_TO", RadioID)
                    ,Parameter("@EXAM_DT", ExamDateTime)
            };
            return parameters;
        }

        public DataSet GetDataCapture(DateTime dtFrom, DateTime dtTo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_SelectByCapture;
            DataSet ds = new DataSet();
            ParameterList = build_DataCapture(dtFrom, dtTo);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] build_DataCapture(DateTime dtFrom, DateTime dtTo)
        {
            DbParameter[] parameters = { Parameter("@dtFrom", dtFrom), Parameter("@dtTo", dtTo) };
            return parameters;
        }

        public DataSet GetDataCapturebyHN(string HN)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_SelectByCapture_withHN;
            DataSet ds = new DataSet();
            ParameterList = build_DataCapturebyHN(HN);
            ds = ExecuteDataSet();
            return ds;
        }  //เพิ่มเข้ามาใหม่
        private DbParameter[] build_DataCapturebyHN(string HN)
        {
            DbParameter[] parameters = { Parameter("@HN", HN) };
            return parameters;
        }  //เพิ่มเข้ามาใหม่

        public DataSet GetDataQA(DateTime dtFrom, DateTime dtTo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_SelectByQA;
            DataSet ds = new DataSet();
            ParameterList = build_DataQA(dtFrom, dtTo);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] build_DataQA(DateTime dtFrom, DateTime dtTo)
        {
            DbParameter[] parameters = { Parameter("@dtFrom", dtFrom), Parameter("@dtTo", dtTo) };
            return parameters;
        }

        public DataSet GetPreview(string accessionNo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_SelectByPreview;
            DataSet ds = new DataSet();
            ParameterList = build_Preview(accessionNo);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] build_Preview(string accessionNo)
        {
            DbParameter[] parameters = { Parameter("@ACCESSION_NO", accessionNo) };
            return parameters;
        }

        public DataSet GetReport_OrderDTL(DateTime FromDate, DateTime ToDate, int UserID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Select_rptOrderDTL;
            DataSet ds = new DataSet();
            ParameterList = buildReport(FromDate, ToDate, UserID);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildReport(DateTime FromDate, DateTime ToDate, int UserID)
        {
            DbParameter[] parameters ={ 
                Parameter("@FromDate",FromDate),
                Parameter("@ToDate",ToDate),
                Parameter("@USER_ID",UserID)
            };
            return parameters;
        }
    }
}

