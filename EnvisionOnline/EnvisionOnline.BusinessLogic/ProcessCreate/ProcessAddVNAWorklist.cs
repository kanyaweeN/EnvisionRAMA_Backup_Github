using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddVNAWorklist : IBusinessLogic
    {
        public VNA_WORKLIST VNA_WORKLIST { get; set; }

        public ProcessAddVNAWorklist()
        {
            VNA_WORKLIST = new VNA_WORKLIST();
        }

        public void Invoke()
        {
            VNAWorklistInsertData _proc = new VNAWorklistInsertData();
            _proc.VNA_WORKLIST = VNA_WORKLIST;
            VNA_WORKLIST.VNA_ID = _proc.AddData();
        }
    }
}
