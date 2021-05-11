using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
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
