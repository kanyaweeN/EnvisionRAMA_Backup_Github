using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvTransactionType : IDisposable
    {
        INV_TRANSACTIONTYPE common;

        public ProcessAddInvTransactionType()
        { 
        }

        public void Invoke()
        {
            InvTransactionTypeInsertData insert = new InvTransactionTypeInsertData();
            insert.INV_TRANSACTIONTYPE = this.INV_TRANSACTIONTYPE;
            insert.Insert();
        }

        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE
        {
            get { return common; }
            set { common = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
