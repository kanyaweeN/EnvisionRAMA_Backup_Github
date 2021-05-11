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
    public class ProcessGetRptComparing2 : IBusinessLogic
    {
        private DataSet result;
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;
        private string empid;

        public ProcessGetRptComparing2(string FromDate, string ToDate, string FromDate2, string ToDate2, string EmpID)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            empid = EmpID;
            
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptComparing2SelectData _proc = null;
            _proc = new RISRptComparing2SelectData(fromDate, toDate, fromDate2, toDate2, empid);
            result = _proc.Get().Copy();
        }
    }
}
