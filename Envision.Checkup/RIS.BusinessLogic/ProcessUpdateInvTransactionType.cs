using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvTransactionType : IDisposable
    {
        INV_TRANSACTIONTYPE common;

        public ProcessUpdateInvTransactionType()
        {
        }

        public void Invoke()
        {
            InvTransactionTypeUpdateData insert = new InvTransactionTypeUpdateData();
            insert.INV_TRANSACTIONTYPE = this.INV_TRANSACTIONTYPE;
            insert.Update();
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
