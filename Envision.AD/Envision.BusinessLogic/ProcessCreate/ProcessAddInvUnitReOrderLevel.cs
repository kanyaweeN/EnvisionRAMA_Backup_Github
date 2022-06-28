using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{ 
    public class ProcessAddInvUnitReOrderLevel : IDisposable
    {
        public INV_UNITREORDERLEVEL INV_UNITREORDERLEVEL { get; set; }

        public ProcessAddInvUnitReOrderLevel()
        {
            INV_UNITREORDERLEVEL = new INV_UNITREORDERLEVEL();
        }

        public void Invoke()
        {
            InvUnitReOrderLevelInsertData insert = new InvUnitReOrderLevelInsertData();
            insert.INV_UNITREORDERLEVEL = this.INV_UNITREORDERLEVEL;
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
