using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvItem : IDisposable
    {
        public INV_ITEM INV_ITEM { get; set; }

        public ProcessAddInvItem()
        {
            INV_ITEM = new INV_ITEM();
        }

        public void Invoke()
        {
            InvItemInsertData insert = new InvItemInsertData();
            insert.INV_ITEM = this.INV_ITEM;
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
