using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvTxnunit
    {
        public INV_TXNUNIT INV_TXNUNIT { get; set; }

        public ProcessAddInvTxnunit()
        {
            INV_TXNUNIT = new INV_TXNUNIT();
        }

        public void Invoke()
        {
            InvTxnunitInsertData insert = new InvTxnunitInsertData();
            insert.INV_TXNUNIT = this.INV_TXNUNIT;
            insert.Insert();
        }
    }
}
