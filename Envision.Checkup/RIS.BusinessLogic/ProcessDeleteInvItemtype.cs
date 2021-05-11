using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvItemtype
    {
        INV_ITEMTYPE common;

        public ProcessDeleteInvItemtype()
        {
        }

        public void Invoke()
        {
            InvItemtypeDeleteData insert = new InvItemtypeDeleteData();
            insert.INV_ITEMTYPE = this.INV_ITEMTYPE;
            insert.Delete();
        }

        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }
}
