using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvItem
    {
        INV_ITEM common;

        public ProcessDeleteInvItem()
        {
        }

        public void Invoke()
        {
            InvItemDeleteData insert = new InvItemDeleteData();
            insert.INV_ITEM = this.INV_ITEM;
            insert.Delete();
        }

        public INV_ITEM INV_ITEM
        {
            get { return common; }
            set { common = value; }
        }
    }
}
