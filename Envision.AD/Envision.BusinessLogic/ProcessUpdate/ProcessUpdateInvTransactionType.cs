using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvTransactionType : IDisposable
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE { get; set; }

        public ProcessUpdateInvTransactionType()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
        }

        public void Invoke()
        {
            InvTransactionTypeUpdateData insert = new InvTransactionTypeUpdateData();
            insert.INV_TRANSACTIONTYPE = this.INV_TRANSACTIONTYPE;
            insert.Update();
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
