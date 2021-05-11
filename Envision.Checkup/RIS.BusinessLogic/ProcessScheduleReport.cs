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
    public class ProcessScheduleReport : IBusinessLogic
    {
        private ReportParameters _rptparameters;
        private DataSet _resultset;
        private DateTime dStart;
        private DateTime dEnd;
        private int Case = 0;
        private int Session = 0;

        public ProcessScheduleReport()
        {

        }
        public ProcessScheduleReport(DateTime Start,DateTime End,int SessionID)
        {
            dStart = Start;
            dEnd = End;
            Case = 1;
            Session = SessionID;
        }
        public void Invoke()
        {
            if (Case == 0)
            {
                ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
                rsentry.ReportParameters = this.ReportParameters;
                ResultSet = rsentry.Get();
            }
            else
            {
                ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
                rsentry.ReportParameters = this.ReportParameters;
                ResultSet = rsentry.Get(dStart, dEnd, Session);
            }
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
