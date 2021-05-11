using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvItemstatus
    {
        INV_ITEMSTATUS common;

        public ProcessUpdateInvItemstatus()
        {
        }

        public void Invoke()
        {
            InvItemstatusUpdateData insert = new InvItemstatusUpdateData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Update();
        }

        public INV_ITEMSTATUS INV_ITEMSTATUS
        {
            get { return common; }
            set { common = value; }
        }
    }
}
