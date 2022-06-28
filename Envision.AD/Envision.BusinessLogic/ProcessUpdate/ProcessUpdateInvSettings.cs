using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvSettings : IDisposable
    {
        public INV_SETTING INV_SETTING { get; set; }
        public ProcessUpdateInvSettings()
        {
            INV_SETTING = new INV_SETTING();
        }

        public void Invoke()
        {
            InvSettingsUpdateData insert = new InvSettingsUpdateData();
            insert.INV_SETTING = this.INV_SETTING;
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
