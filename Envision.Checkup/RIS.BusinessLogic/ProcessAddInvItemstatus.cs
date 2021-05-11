using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvItemstatus
    {
        INV_ITEMSTATUS common;

        public ProcessAddInvItemstatus()
        {
        }

        public void Invoke()
        {
            InvItemstatusInsertData insert = new InvItemstatusInsertData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Insert();
        }

        public INV_ITEMSTATUS INV_ITEMSTATUS
        {
            get { return common; }
            set { common = value; }
        }
    }
}
