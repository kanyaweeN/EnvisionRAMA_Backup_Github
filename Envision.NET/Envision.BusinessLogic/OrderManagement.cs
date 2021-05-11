using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.BusinessLogic
{
    /// <summary>
    /// This class use order management
    /// </summary>
    public class OrderManagement
    {
        private static ProcessUpdateRISOrderDtlHisSync _processUpdateRISOrderDtlHISSync = null;
        static OrderManagement()
        {
            _processUpdateRISOrderDtlHISSync = new ProcessUpdateRISOrderDtlHisSync();
        }
        /// <summary>
        /// This method use to update order billing his syncronize
        /// </summary>
        /// <param name="accessionNo">accession no</param>
        /// <param name="hisSync">his sync</param>
        /// <param name="hisAck">his ack</param>
        /// <param name="orgId">org Id</param>
        public static void UpdateOrderHISSync(string accessionNo, string hisSync, string hisAck, int orgId)
        {
            _processUpdateRISOrderDtlHISSync.ACCESSION_NO = accessionNo;
            _processUpdateRISOrderDtlHISSync.HIS_ACK = hisAck;
            _processUpdateRISOrderDtlHISSync.HIS_SYNC = hisSync;
            _processUpdateRISOrderDtlHISSync.ORG_ID = orgId;
            _processUpdateRISOrderDtlHISSync.Invoke();
        }
    }
}
