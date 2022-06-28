using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvCategory
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvCategory()
        {
            INV_CATEGORY = new INV_CATEGORY();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_CATEGORYDeleteData proc = new INV_CATEGORYDeleteData();
            proc.INV_CATEGORY = INV_CATEGORY;
            proc.Delete();
        }

       
    }
}
