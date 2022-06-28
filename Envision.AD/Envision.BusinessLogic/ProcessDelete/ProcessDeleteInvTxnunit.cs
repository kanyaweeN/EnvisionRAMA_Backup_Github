using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvTxnunit
    {
        public INV_TXNUNIT INV_TXNUNIT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvTxnunit()
        {
            INV_TXNUNIT = new INV_TXNUNIT();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_TXNUNITDeleteData delete = new INV_TXNUNITDeleteData();
            delete.INV_TXNUNIT = this.INV_TXNUNIT;
            delete.Delete();
        }
    }
}
