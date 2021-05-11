using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{ 
    public class ProcessUpdateInvItem : IDisposable
    {
        public INV_ITEM INV_ITEM { get; set; }

        public ProcessUpdateInvItem()
        {
            INV_ITEM = new INV_ITEM();
        }

        public void Invoke()
        {
            InvItemUpdateData update = new InvItemUpdateData();
            update.INV_ITEM = this.INV_ITEM;
            update.Update();
        }
        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
