using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{ 
    public class ProcessAddInvSettings : IDisposable
    {
        public INV_SETTING INV_SETTING { get; set; }

        public ProcessAddInvSettings()
        {
            INV_SETTING = new INV_SETTING();
        }

        public void Invoke()
        {
            InvSettingsInsertData insert = new InvSettingsInsertData();
            insert.INV_SETTING = this.INV_SETTING;
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
