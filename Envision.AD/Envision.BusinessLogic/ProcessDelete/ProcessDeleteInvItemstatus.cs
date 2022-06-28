using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvItemstatus
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvItemstatus()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
            Transaction = null;
        }

        public void Invoke()
        {
            InvItemstatusDeleteData insert = new InvItemstatusDeleteData();
            insert.INV_ITEMSTATUS = this.INV_ITEMSTATUS;
            insert.Delete();
           
        }
    }
}
