using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvAuthorisation : IDisposable
    {
        INV_AUTHORISATION common;

        public ProcessAddInvAuthorisation()
        { 
        }

        public void Invoke()
        {
            InvAuthorisationInsertData insert = new InvAuthorisationInsertData();
            insert.INV_AUTHORISATION = this.INV_AUTHORISATION;
            insert.Insert();
        }

        public INV_AUTHORISATION INV_AUTHORISATION
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
