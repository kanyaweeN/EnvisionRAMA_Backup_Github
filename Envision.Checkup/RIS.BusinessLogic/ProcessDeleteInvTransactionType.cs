using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvTransactionType : IDisposable
    {
        INV_TRANSACTIONTYPE common;

        public ProcessDeleteInvTransactionType()
        {
        }

        public void Invoke()
        {
            InvTransactionTypeDeleteData insert = new InvTransactionTypeDeleteData();
            insert.INV_TRANSACTIONTYPE = this.INV_TRANSACTIONTYPE;
            insert.Delete();
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
