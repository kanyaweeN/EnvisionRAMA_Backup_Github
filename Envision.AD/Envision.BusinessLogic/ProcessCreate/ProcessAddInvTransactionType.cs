using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{ 
    public class ProcessAddInvTransactionType : IDisposable
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE { get; set; }

        public ProcessAddInvTransactionType()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
        }

        public void Invoke()
        {
            InvTransactionTypeInsertData insert = new InvTransactionTypeInsertData();
            insert.INV_TRANSACTIONTYPE = this.INV_TRANSACTIONTYPE;
            insert.Insert();
        }
        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
