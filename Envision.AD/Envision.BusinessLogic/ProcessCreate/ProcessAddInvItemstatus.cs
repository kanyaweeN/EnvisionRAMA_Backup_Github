using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvItemstatus
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS { get; set; }

        public ProcessAddInvItemstatus()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
        }

        public void Invoke()
        {
            InvItemstatusInsertData insert = new InvItemstatusInsertData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Insert();
        }
    }
}
