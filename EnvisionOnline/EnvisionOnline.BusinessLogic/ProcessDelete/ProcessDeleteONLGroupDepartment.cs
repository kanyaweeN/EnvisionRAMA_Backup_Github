using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteONLGroupDepartment
    {
        public ProcessDeleteONLGroupDepartment()
        {
        }

        public void delete(int gdept_id)
        {
            ONLGroupDepartmentDeleteData _proc = new ONLGroupDepartmentDeleteData();
            _proc.Delete(gdept_id);
        }
    }
}
