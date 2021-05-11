using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvAuthoriser : IDisposable
    {
        public INV_AUTHORISER INV_AUTHORISER { get; set; }

        public ProcessUpdateInvAuthoriser()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
        }

        public void Invoke()
        {
            InvAuthoriserUpdateData insert = new InvAuthoriserUpdateData();
            insert.INV_AUTHORISER = this.INV_AUTHORISER;
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
