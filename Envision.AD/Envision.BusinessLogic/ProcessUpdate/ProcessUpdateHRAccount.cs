using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateHRAccount : IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }

        public ProcessUpdateHRAccount()
        {
            HR_EMP = new HR_EMP();
        }

        public void Invoke()
        {
            HRAccountUpdateData HRAccdata = new HRAccountUpdateData();
            HRAccdata.HR_EMP = this.HR_EMP;
            HRAccdata.Add();

        }
    }
}
