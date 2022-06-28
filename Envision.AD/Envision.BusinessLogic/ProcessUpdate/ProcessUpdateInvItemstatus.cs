using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvItemstatus
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS { get; set; }

        public ProcessUpdateInvItemstatus()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
        }

        public void Invoke()
        {
            InvItemstatusUpdateData insert = new InvItemstatusUpdateData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Update();
        }
    }
}
