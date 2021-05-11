using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvUnitReOrderLevel : IDisposable
    {
        INV_UNITREORDERLEVEL common;

        public ProcessAddInvUnitReOrderLevel()
        { 
        }

        public void Invoke()
        {
            InvUnitReOrderLevelInsertData insert = new InvUnitReOrderLevelInsertData();
            insert.INV_UNITREORDERLEVEL = this.INV_UNITREORDERLEVEL;
            insert.Insert();
        }

        public INV_UNITREORDERLEVEL INV_UNITREORDERLEVEL
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
