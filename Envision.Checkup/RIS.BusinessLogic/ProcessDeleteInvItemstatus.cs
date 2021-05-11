using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvItemstatus
    {
        INV_ITEMSTATUS common;

        public ProcessDeleteInvItemstatus()
        {
        }

        public void Invoke()
        {
            InvItemstatusDeleteData insert = new InvItemstatusDeleteData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Delete();
        }

        public INV_ITEMSTATUS INV_ITEMSTATUS
        {
            get { return common; }
            set { common = value; }
        }
    }
}
