using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRptOrder : IBusinessLogic
    {
        private DataSet result;
        private string fromDate;
        private string toDate;
        private string specialClinic;

        public ProcessGetRptOrder(string FromDate, string ToDate, string SpecialClinic)
        {
            fromDate = FromDate;
            toDate = ToDate;
            specialClinic = SpecialClinic;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptOrderSelectData _proc = null;
            _proc = new RISRptOrderSelectData(fromDate, toDate, specialClinic);
            result = _proc.Get().Copy();
        }
    }
}
