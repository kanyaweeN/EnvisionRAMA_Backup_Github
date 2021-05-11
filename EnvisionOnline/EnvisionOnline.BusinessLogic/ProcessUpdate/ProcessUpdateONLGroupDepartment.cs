using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateONLGroupDepartment : IBusinessLogic
    {
        public ONL_GROUPDEPARTMENT ONL_GROUPDEPARTMENT { get; set; }

        public ProcessUpdateONLGroupDepartment()
        {
            ONL_GROUPDEPARTMENT = new ONL_GROUPDEPARTMENT();
        }
        public void Invoke()
        {
            ONLGroupDepartmentUpdateData _proc = new ONLGroupDepartmentUpdateData();
            _proc.ONL_GROUPDEPARTMENT = this.ONL_GROUPDEPARTMENT;
            _proc.Update();
        }
    }
}
