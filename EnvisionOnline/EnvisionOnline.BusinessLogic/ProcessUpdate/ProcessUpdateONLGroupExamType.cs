using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateONLGroupExamType: IBusinessLogic
    {
        public ONL_GROUPEXAMTYPE ONL_GROUPEXAMTYPE { get; set; }

        public ProcessUpdateONLGroupExamType()
        {
            ONL_GROUPEXAMTYPE = new ONL_GROUPEXAMTYPE();
        }
        public void Invoke()
        {
            ONLGroupExamTypeUpdateData _proc = new ONLGroupExamTypeUpdateData();
            _proc.ONL_GROUPEXAMTYPE = this.ONL_GROUPEXAMTYPE;
            _proc.Update();
        }
    }
}

