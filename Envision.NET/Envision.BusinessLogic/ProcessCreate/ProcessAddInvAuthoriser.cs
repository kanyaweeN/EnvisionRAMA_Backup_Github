using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvAuthoriser : IDisposable
    {
        public INV_AUTHORISER INV_AUTHORISER { get; set; }
        public ProcessAddInvAuthoriser()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
        }

        public void Invoke()
        {
            InvAuthoriserInsertData insert = new InvAuthoriserInsertData();
            insert.INV_AUTHORISER = this.INV_AUTHORISER;
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
