using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class XRAYREQSelectData : DataAccessBase
    {
        public XRAYREQ XRAYREQ { get; set; }
        public XRAYREQSelectData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_XREGIST_WorkList;
        }

        public DataSet GetRequest()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_XREGIST_GetRequest;
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetWorkList()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetWorkListByHN()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_XREGIST_GetByHN;
            ParameterList = buildParameterHN();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetByREQ(string REQ)
        {
            DataSet ds = new DataSet();
            int intReq = Convert.ToInt32(REQ);
            StoredProcedureName = StoredProcedure.Prc_XREGIST_GetByREQ;
            ParameterList = buildParameterREQ(intReq);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetByDateLenage(string DF, string DT)
        {
            DataSet ds = new DataSet();
            int intDF = Convert.ToInt32(DF);
            int intDT = Convert.ToInt32(DT);
            StoredProcedureName = StoredProcedure.Prc_XREGIST_GetByREQDate;
            ParameterList = buildParameterREQDate(intDF, intDT);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                 Parameter("@REG_ID",XRAYREQ.ORDER_ID)
            };
            return parameters;
        }
        private DbParameter[] buildParameterHN()
        {
            DbParameter[] parameters ={			
                 Parameter("@HN",XRAYREQ.HN)
            };
            return parameters;
        }
        private DbParameter[] buildParameterREQ(int REQ)
        {
            DbParameter[] parameters ={			
                 Parameter("@XREQ_DATE",REQ)
            };
            return parameters;
        }
        private DbParameter[] buildParameterREQDate(int DF, int DT)
        {
            DbParameter[] parameters ={			
                 Parameter("@REQ_DATEFORM",DF)
                 ,Parameter("@REQ_DATETO",DT)
            };
            return parameters;
        }

        public DataSet GetMergeRequest(int xrayreq_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_SelectMergeRequest;
            ParameterList = new DbParameter[] { 
                                                Parameter("@XRAYREQ_ID",xrayreq_id)
                                                };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetBusyCase(int xrayreq_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_SelectBusyCase;
            ParameterList = new DbParameter[] { 
                                                Parameter("@XRAYREQ_ID",xrayreq_id)
                                                };
            ds = ExecuteDataSet();
            return ds.Tables[0];
        }
    }
}

