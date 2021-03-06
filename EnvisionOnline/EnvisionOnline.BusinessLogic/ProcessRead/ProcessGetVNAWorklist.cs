using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetVNAWorklist: IBusinessLogic
    {
        public VNA_WORKLIST VNA_WORKLIST { get; set; }
        private DataSet result;
        public ProcessGetVNAWorklist()
        {
            VNA_WORKLIST = new VNA_WORKLIST();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            VNAWorklistSelectData _proc = new VNAWorklistSelectData();
            _proc.VNA_WORKLIST = VNA_WORKLIST;
            result = _proc.getData();
        }
        public DataSet getDataVna(string hn, int unit_id, bool is_today,bool all_dept)
        {
            VNAWorklistSelectData _proc = new VNAWorklistSelectData();
            return _proc.getDataVna(hn, unit_id, is_today, all_dept);
        }
    }
}
