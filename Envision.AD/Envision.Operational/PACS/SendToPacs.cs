using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Envision.Common;
using Envision.WebService;


namespace Envision.Operational.PACS
{
    public class SendToPacs : IDisposable
    {
        private GBLEnvVariable env;

        private bool disposed = false;

        public SendToPacs()
        {
            env = new GBLEnvVariable();
        }
        ~SendToPacs()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Set_ADTByHNQueue(string hn, int orgId)
        {
            return Set_ADTByHNQueue(0, hn, 1);
        }
        public bool Set_ADTByHNQueue(int logId, string hn, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ADTByHNQueue(logId, hn, orgId);
        }
        public bool Set_ADTReconcileQueue(string oldHn, string newHn)
        {
            return Set_ADTReconcileQueue(0, oldHn, newHn, 1);
        }
        public bool Set_ADTReconcileQueue(int logId, string oldHn, string newHn, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ADTReconcileQueue(logId, oldHn, newHn, orgId);
        }

        public bool Set_ORMByAccessionNoQueue(string accessionNo)
        {
            return Set_ORMByAccessionNoQueue(0, accessionNo, 1);
        }
        public bool Set_ORMByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMByAccessionNoQueue(logId, accessionNo, orgId);
        }
        public bool Set_ORMByOrderIdQueue(int orderId)
        {
            return Set_ORMByOrderIdQueue(0, orderId);
        }
        public bool Set_ORMByOrderIdQueue(int logId, int orderId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMByOrderIdQueue(logId, orderId);
        }
        public bool Set_ORMBidirectionalByAccessionNoQueue(string accessionNo)
        {
            return Set_ORMBidirectionalByAccessionNoQueue(0, accessionNo, 1);
        }
        public bool Set_ORMBidirectionalByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMBidirectionalByAccessionNoQueue(logId, accessionNo, orgId);
        }
        public bool Set_ORMMergeByAccessionNoQueue(string accessionNo)
        {
            return Set_ORMMergeByAccessionNoQueue(0, accessionNo, 1);
        }
        public bool Set_ORMMergeByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMMergeByAccessionNoQueue(logId, accessionNo, orgId);
        }

        public bool Set_ORUByAccessionNoQueue(string accessionNo)
        {
            return Set_ORUByAccessionNoQueue(0, accessionNo, 1);
        }
        public bool Set_ORUByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORUByAccessionNoQueue(logId, accessionNo, orgId);
        }
    }
}

