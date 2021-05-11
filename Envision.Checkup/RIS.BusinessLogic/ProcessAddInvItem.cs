using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvItem : IDisposable
    {
        INV_ITEM common;

        public ProcessAddInvItem()
        { 
        }

        public void Invoke()
        {
            InvItemInsertData insert = new InvItemInsertData();
            insert.INV_ITEM = this.INV_ITEM;
            insert.Insert();
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
