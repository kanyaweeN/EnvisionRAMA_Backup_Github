using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISBpview : IBusinessLogic
    {
        public RIS_BPVIEW RIS_BPVIEW { get; set; }
        private DataSet result;

        public ProcessGetRISBpview()
        {
            RIS_BPVIEW = new RIS_BPVIEW();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISBpviewSelectData _proc = new RISBpviewSelectData();
            result = _proc.GetData();
        }
    }
}

