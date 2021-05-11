using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvAuthoriser : IDisposable
    {
        INV_AUTHORISER common;

        public ProcessDeleteInvAuthoriser()
        {
        }

        public void Invoke()
        {
            InvAuthoriserDeleteData insert = new InvAuthoriserDeleteData();
            insert.INV_AUTHORISER = this.INV_AUTHORISER;
            insert.Delete();
        }

        public INV_AUTHORISER INV_AUTHORISER
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
