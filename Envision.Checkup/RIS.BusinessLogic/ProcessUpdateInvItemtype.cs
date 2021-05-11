using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvItemtype
    {
        INV_ITEMTYPE common;

        public ProcessUpdateInvItemtype()
        {
        }

        public void Invoke()
        {
            InvItemtypeUpdateData insert = new InvItemtypeUpdateData();
            insert.INV_ITEMTYPE = this.INV_ITEMTYPE;
            insert.Update();
        }

        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }
}
