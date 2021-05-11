using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvSettings : IDisposable
    {
        INV_SETTINGS common;

        public ProcessAddInvSettings()
        { 
        }

        public void Invoke()
        {
            InvSettingsInsertData insert = new InvSettingsInsertData();
            insert.INV_SETTINGS = this.INV_SETTINGS;
            insert.Insert();
        }

        public INV_SETTINGS INV_SETTINGS
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
