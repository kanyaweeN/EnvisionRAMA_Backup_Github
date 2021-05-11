using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvAuthoriser : IDisposable
    {
        INV_AUTHORISER common;

        public ProcessAddInvAuthoriser()
        {
        }

        public void Invoke()
        {
            InvAuthoriserInsertData insert = new InvAuthoriserInsertData();
            insert.INV_AUTHORISER = this.INV_AUTHORISER;
            insert.Insert();
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
