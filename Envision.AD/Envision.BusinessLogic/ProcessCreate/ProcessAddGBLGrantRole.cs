using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLGrantRole : IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessAddGBLGrantRole() 
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
        }
        public void Invoke()
        {
            GBLGrantRoleInsertData update = new GBLGrantRoleInsertData();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
