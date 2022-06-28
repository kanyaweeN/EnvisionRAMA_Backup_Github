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
    public class ProcessGetRptComparing1 : IBusinessLogic
    {
        private DataSet result;
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;

        public ProcessGetRptComparing1(string FromDate, string ToDate, string FromDate2, string ToDate2)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptComparing1SelectData _proc = null;
            _proc = new RISRptComparing1SelectData(fromDate, toDate, fromDate2, toDate2);
            result = _proc.Get().Copy();
        }
    }
}
