using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvTxnunit
    {
        public INV_TXNUNIT INV_TXNUNIT { get; set; }

        public ProcessUpdateInvTxnunit()
        {
            INV_TXNUNIT = new INV_TXNUNIT();
        }

        public void Invoke()
        {
            InvTxnunitUpdateData insert = new InvTxnunitUpdateData();
            insert.INV_TXNUNIT = this.INV_TXNUNIT;
            insert.Update();
        }

    }
}
