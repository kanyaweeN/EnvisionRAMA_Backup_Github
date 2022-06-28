using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateHRUnit_forExcel : IBusinessLogic
    {
        public HR_UNIT HR_UNIT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateHRUnit_forExcel()
        {
            HR_UNIT = new HR_UNIT();
            Transaction = null;
        }
        public void Invoke()
        {
            HRUnitUpdateData_forExcel _proc = new HRUnitUpdateData_forExcel();
            _proc.HR_UNIT = this.HR_UNIT;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
        }
    }
}

