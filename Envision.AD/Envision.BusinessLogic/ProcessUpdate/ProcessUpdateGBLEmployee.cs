using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLEmployee : IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }

        public ProcessUpdateGBLEmployee()
        {
            HR_EMP = new HR_EMP();
        }

        public void Invoke()
        {
            GBLEmployeeUpdateData envdata = new GBLEmployeeUpdateData();
            envdata.HR_EMP = this.HR_EMP;
            envdata.Add();

        }
    }
}
