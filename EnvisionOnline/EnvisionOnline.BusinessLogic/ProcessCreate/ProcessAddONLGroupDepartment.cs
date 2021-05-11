using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddONLGroupDepartment: IBusinessLogic
    {
        public ONL_GROUPDEPARTMENT ONL_GROUPDEPARTMENT { get; set; }
        public ProcessAddONLGroupDepartment()
        {
            ONL_GROUPDEPARTMENT = new ONL_GROUPDEPARTMENT();
        }

        public void Invoke()
        {
            ONLGroupDepartmentInsertData insert = new ONLGroupDepartmentInsertData();
            insert.ONL_GROUPDEPARTMENT = this.ONL_GROUPDEPARTMENT;
            insert.Add();
        }
    }
}