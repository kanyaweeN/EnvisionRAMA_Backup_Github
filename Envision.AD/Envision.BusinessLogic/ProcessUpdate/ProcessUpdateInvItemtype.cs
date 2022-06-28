using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvItemtype
    {
        public INV_ITEMTYPE INV_ITEMTYPE { get; set; }

        public ProcessUpdateInvItemtype()
        {
            INV_ITEMTYPE = new INV_ITEMTYPE();
        }

        public void Invoke()
        {
            InvItemtypeUpdateData insert = new InvItemtypeUpdateData();
            insert.INV_ITEMTYPE = this.INV_ITEMTYPE;
            insert.Update();
        }
    }
}
