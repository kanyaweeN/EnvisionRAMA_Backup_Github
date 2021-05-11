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
    public class ProcessGetRptWorkload : IBusinessLogic
    {
        private DataSet result;
        private int orderID;
        private string fromDate;
        private string toDate;
        private string jobTitle;

        public ProcessGetRptWorkload(int OrderID, string FromDate, string ToDate, string JobTitle)
        {
            orderID = OrderID;
            fromDate = FromDate;
            toDate = ToDate;
            jobTitle = JobTitle;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptWorkloadSelectData _proc = null;
            _proc = new RISRptWorkloadSelectData(orderID, fromDate, toDate, jobTitle);
            result = _proc.Get().Copy();
        }
    }
}
