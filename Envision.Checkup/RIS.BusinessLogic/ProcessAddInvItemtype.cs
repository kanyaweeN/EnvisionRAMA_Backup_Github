using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvItemtype
    {
        INV_ITEMTYPE common;

        public ProcessAddInvItemtype()
        {
        }

        public void Invoke()
        {
            InvItemtypeInsertData insert = new InvItemtypeInsertData();
            insert.INV_ITEMTYPE = this.INV_ITEMTYPE;
            insert.Insert();
        }

        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }
}
