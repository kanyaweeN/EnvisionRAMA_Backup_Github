using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{

    public class ProcessGetONLWorklist : IBusinessLogic
    {
        public ONL_WORKLIST ONL_WORKLIST { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetONLWorklist()
        {
            ONL_WORKLIST = new ONL_WORKLIST();
            Result = new DataSet();
        }

        public void Invoke()
        {
            ONLWorklistSelectData get = new ONLWorklistSelectData();
            get.ONL_WORKLIST = this.ONL_WORKLIST;
            Result = get.Get();
        }
    }
}
