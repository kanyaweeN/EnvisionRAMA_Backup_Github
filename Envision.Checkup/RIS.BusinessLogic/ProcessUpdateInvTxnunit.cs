using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvTxnunit
    {
        INV_TXNUNIT common;

        public ProcessUpdateInvTxnunit()
        {
        }

        public void Invoke()
        {
            InvTxnunitUpdateData insert = new InvTxnunitUpdateData();
            insert.INV_TXNUNIT = this.INV_TXNUNIT;
            insert.Update();
        }

        public INV_TXNUNIT INV_TXNUNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
