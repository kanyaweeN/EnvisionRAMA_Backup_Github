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
    public class ProcessResultEntryReport : IBusinessLogic
    {
        private ReportParameters _rptparameters;
        private DataSet _resultset;

        public ProcessResultEntryReport()
        {

        }

        public void Invoke()
        {
            ResultEntyReportSelectData rsentry = new ResultEntyReportSelectData();
            rsentry.ReportParameters = this.ReportParameters;
            ResultSet = rsentry.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ReportParameters ReportParameters
        {
            get { return _rptparameters; }
            set { _rptparameters = value; }
        }



    }
}
