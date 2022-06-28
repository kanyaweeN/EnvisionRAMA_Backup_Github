using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvSettings : IBusinessLogic
    {
        public INV_SETTING INV_SETTING { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvSettings()
        {
            INV_SETTING = new INV_SETTING();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_SETTINGDeleteData delete = new INV_SETTINGDeleteData();
            delete.INV_SETTING = this.INV_SETTING;
            delete.Delete();
        }
       
    }
}
