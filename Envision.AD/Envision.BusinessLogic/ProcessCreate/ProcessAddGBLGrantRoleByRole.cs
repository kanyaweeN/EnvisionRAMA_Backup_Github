using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLGrantRoleByRole : IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessAddGBLGrantRoleByRole()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
        }
        public void Invoke()
        {
            GBLGrantRoleInsertDataRole update = new GBLGrantRoleInsertDataRole();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
