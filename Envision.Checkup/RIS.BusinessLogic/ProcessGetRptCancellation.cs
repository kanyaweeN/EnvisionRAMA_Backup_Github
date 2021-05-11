using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRptCancellation : IBusinessLogic
    {
        private DataSet result;
        private string fromDate;
        private string toDate;
        
        public ProcessGetRptCancellation(string FromDate, string ToDate)
        {
            fromDate = FromDate;
            toDate = ToDate;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptCancellationSelectData _proc = null;
            _proc = new RISRptCancellationSelectData(fromDate, toDate);
            result = _proc.Get().Copy();
        }
    }
}
