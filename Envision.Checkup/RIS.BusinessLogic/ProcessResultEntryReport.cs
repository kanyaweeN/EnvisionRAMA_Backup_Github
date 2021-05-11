/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
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
