using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvVendor
    {
        public INV_VENDOR INV_VENDOR { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvVendor()
        {
            INV_VENDOR = new INV_VENDOR();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_VENDORDeleteData delete = new INV_VENDORDeleteData();
            delete.INV_VENDOR = INV_VENDOR;
            delete.Delete();
        }
    }
}
