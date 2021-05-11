using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvTxnunit
    {
        INV_TXNUNIT common;

        public ProcessDeleteInvTxnunit()
        {
        }

        public void Invoke()
        {
            InvTxnunitDeleteData insert = new InvTxnunitDeleteData();
            insert.INV_TXNUNIT = this.INV_TXNUNIT;
            insert.Delete();
        }

        public INV_TXNUNIT INV_TXNUNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
