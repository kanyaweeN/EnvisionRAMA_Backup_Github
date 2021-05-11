using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvItem
    {
        public INV_ITEM INV_ITEM { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvItem()
        {
            INV_ITEM = new INV_ITEM();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_ITEMDeleteData proc = new INV_ITEMDeleteData();
            proc.INV_ITEM = INV_ITEM;
            proc.Delete();
        }
       
    }
}
