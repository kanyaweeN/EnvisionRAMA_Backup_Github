using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvUnit
    {
        public INV_UNIT INV_UNIT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvUnit()
        {
            INV_UNIT = new INV_UNIT();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_UNITDeleteData delete = new INV_UNITDeleteData();
            delete.INV_UNIT = INV_UNIT;
            delete.Delete();
        }
    }
}
