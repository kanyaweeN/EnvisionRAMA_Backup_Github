using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvSettings : IDisposable
    {
        INV_SETTINGS common;

        public ProcessDeleteInvSettings()
        {
        }

        public void Invoke()
        {
            InvSettingsDeleteData insert = new InvSettingsDeleteData();
            insert.INV_SETTINGS = this.INV_SETTINGS;
            insert.Delete();
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
