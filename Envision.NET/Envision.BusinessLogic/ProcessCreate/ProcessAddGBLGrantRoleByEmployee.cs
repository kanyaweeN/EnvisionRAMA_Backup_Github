using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLGrantRoleByEmployee : IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessAddGBLGrantRoleByEmployee()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
        }
        public void Invoke()
        {
            GBLGrantRoleInsertDataEmployee update = new GBLGrantRoleInsertDataEmployee();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
