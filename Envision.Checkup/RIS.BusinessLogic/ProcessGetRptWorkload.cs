using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRptWorkload : IBusinessLogic
    {
        private DataSet result;
        private int orderID;
        private DateTime fromDate;
        private DateTime toDate;
        private string jobTitle;

        public ProcessGetRptWorkload(int OrderID, DateTime FromDate, DateTime ToDate, string JobTitle)
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
