using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddONLGroupExamType: IBusinessLogic
    {
        public ONL_GROUPEXAMTYPE ONL_GROUPEXAMTYPE { get; set; }
         public ProcessAddONLGroupExamType()
        {
            ONL_GROUPEXAMTYPE = new ONL_GROUPEXAMTYPE();
        }

        public void Invoke()
        {
            ONLGroupExamTypeInsertData insert = new ONLGroupExamTypeInsertData();
            insert.ONL_GROUPEXAMTYPE = this.ONL_GROUPEXAMTYPE;
            insert.Add();
        }
    }
}
