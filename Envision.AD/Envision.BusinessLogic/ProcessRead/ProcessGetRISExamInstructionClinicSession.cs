using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamInstructionClinicSession : IBusinessLogic
    {
        private DataSet result;
        private int _exam_id, _session_id;

        public ProcessGetRISExamInstructionClinicSession(int exam_id, int session_id)
        {
            _exam_id = exam_id;
            _session_id = session_id;
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISExamInstructionClinicSessionSelectData _proc = new RISExamInstructionClinicSessionSelectData();
            result = _proc.GetData(_exam_id, _session_id);
        }
    }
}

