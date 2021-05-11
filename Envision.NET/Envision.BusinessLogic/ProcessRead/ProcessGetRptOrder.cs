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
