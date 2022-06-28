using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLEmployee : IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }
        public ProcessAddGBLEmployee()
        {
            HR_EMP = new HR_EMP();
        }

        public void Invoke()
        {
            GBLEmployeeInsertData envdata = new GBLEmployeeInsertData();
            envdata.HR_EMP = this.HR_EMP;
            envdata.Add();

        }

    }
}
