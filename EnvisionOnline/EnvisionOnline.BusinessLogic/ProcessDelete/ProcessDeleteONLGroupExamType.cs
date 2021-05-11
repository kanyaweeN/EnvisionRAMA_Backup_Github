using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteONLGroupExamType
    {
        public ProcessDeleteONLGroupExamType()
        {
        }

        public void delete(int gtype_id)
        {
            ONLGroupExamTypeDeleteData _proc = new ONLGroupExamTypeDeleteData();
            _proc.Delete(gtype_id);
        }
    }
}
