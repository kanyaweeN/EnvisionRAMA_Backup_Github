using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvAuthoriser : IDisposable
    {
        INV_AUTHORISER common;

        public ProcessUpdateInvAuthoriser()
        {
        }

        public void Invoke()
        {
            InvAuthoriserUpdateData insert = new InvAuthoriserUpdateData();
            insert.INV_AUTHORISER = this.INV_AUTHORISER;
            insert.Update();
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
