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
    public class ProcessGetXRAYREQ : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public XRAYREQ XRAYREQ { get; set; }
        public int StoreType { get; set; }

        public ProcessGetXRAYREQ()
        {
            XRAYREQ = new XRAYREQ();
            Result = new DataSet();
        }

        public void Invoke()
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            _proc.XRAYREQ = XRAYREQ;
            Result = _proc.GetWorkList();
        }
        public DataSet GetWorkListByDate()
        {
            DataSet ds = new DataSet();
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            _proc.XRAYREQ = XRAYREQ;
            //ds = _proc
            return ds;
        }
        public DataSet GetRequest()
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            _proc.XRAYREQ = XRAYREQ;
            DataSet ds = new DataSet();
            ds = _proc.GetRequest();
            return ds;
        }
        public DataSet GetWorkListByHN()
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            _proc.XRAYREQ = XRAYREQ;
            DataSet ds = new DataSet();
            ds = _proc.GetWorkListByHN();
            return ds;
        }
        public DataSet GetRequestReq(string Req)
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            DataSet ds = new DataSet();
            ds = _proc.GetByREQ(Req);
            return ds;
        }
        public DataSet GetRequestDateLenge(string DF, string DT)
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            DataSet ds = new DataSet();
            ds = _proc.GetByDateLenage(DF, DT);
            return ds;
        }
        public DataSet GetMergeRequest(int xrayreq_id)
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            DataSet ds = new DataSet();
            ds = _proc.GetMergeRequest(xrayreq_id);
            return ds;
        }
        public DataTable GetBusyCase(int xrayreq_id)
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            return _proc.GetBusyCase(xrayreq_id);
        }
    }
}

