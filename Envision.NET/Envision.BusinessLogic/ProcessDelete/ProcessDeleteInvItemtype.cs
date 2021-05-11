using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvItemtype
    {
        public INV_ITEMTYPE INV_ITEMTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvItemtype()
        {
            INV_ITEMTYPE = new INV_ITEMTYPE();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_ITEMTYPEDeleteData proc = new INV_ITEMTYPEDeleteData();
            proc.INV_ITEMTYPE = INV_ITEMTYPE;
            proc.Delete();
        }
    }
}
