using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvTxnunit
    {
        INV_TXNUNIT common;

        public ProcessAddInvTxnunit()
        {
        }

        public void Invoke()
        {
            InvTxnunitInsertData insert = new InvTxnunitInsertData();
            insert.INV_TXNUNIT = this.INV_TXNUNIT;
            insert.Insert();
        }

        public INV_TXNUNIT INV_TXNUNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
