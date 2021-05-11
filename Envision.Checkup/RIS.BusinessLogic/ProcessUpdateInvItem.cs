using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{ 
    public class ProcessUpdateInvItem : IDisposable
    {
        INV_ITEM common;

        public ProcessUpdateInvItem()
        { 
        }

        public void Invoke()
        {
            InvItemUpdateData update = new InvItemUpdateData();
            update.INV_ITEM = this.INV_ITEM;
            update.Update();
        }

        public INV_ITEM INV_ITEM
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
