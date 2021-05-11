using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvSettings : IDisposable
    {
        INV_SETTINGS common;

        public ProcessUpdateInvSettings()
        {
        }

        public void Invoke()
        {
            InvSettingsUpdateData insert = new InvSettingsUpdateData();
            insert.INV_SETTINGS = this.INV_SETTINGS;
            insert.Update();
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
