using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISBpviewMapping : IBusinessLogic
    {

        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }
        private DataSet result;
        public string Exam_UID;

        public ProcessGetRISBpviewMapping()
        {
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISBpviewMappingSelectData _proc = new RISBpviewMappingSelectData();
            result = _proc.GetData(Exam_UID);
        }
    }
}

