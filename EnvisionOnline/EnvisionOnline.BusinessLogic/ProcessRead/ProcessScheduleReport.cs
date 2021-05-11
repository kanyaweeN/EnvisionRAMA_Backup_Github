using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Select;
using System.Data;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessScheduleReport : IBusinessLogic
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        //public ReportParameters ReportParameters { get; set; }
        public ReportParameters ReportParameters
        {
            get { return param; }
            set
            {
                param = value;
                RIS_SCHEDULE.HN = param.PatientId;
                RIS_SCHEDULE.START_DATETIME = param.AppointDate;
                RIS_SCHEDULE.MODALITY_ID = param.ModalityId;
                RIS_SCHEDULE.SCHEDULE_ID = param.ScheduleID;
            }
        }

        private ReportParameters param;
        private DataSet _resultset;
        private DateTime dStart;
        private DateTime dEnd;
        private int Case = 0;
        private int Session = 0;

        public ProcessScheduleReport()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            param = new ReportParameters();
            ReportParameters = new ReportParameters();
        }
        public ProcessScheduleReport(DateTime Start, DateTime End, int SessionID)
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            ReportParameters = new ReportParameters();
            param = new ReportParameters();
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
                rsentry.RIS_SCHEDULE = this.RIS_SCHEDULE;
                ResultSet = rsentry.Get();
            }
            else
            {
                ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
                rsentry.ReportParameters = ReportParameters;
                rsentry.RIS_SCHEDULE = this.RIS_SCHEDULE;
                ResultSet = rsentry.Get(dStart, dEnd, Session);
            }
        }
        public void getReport()
        {
            ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
            rsentry.RIS_SCHEDULE = this.RIS_SCHEDULE;
            ResultSet = rsentry.getReport();
        }
        public void getReportAIMC()
        {
            ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
            rsentry.RIS_SCHEDULE = this.RIS_SCHEDULE;
            ResultSet = rsentry.getReportAIMC();
        }
        public void getReportNav()
        {
            ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
            rsentry.RIS_SCHEDULE = this.RIS_SCHEDULE;
            ResultSet = rsentry.getNav();
        }
        public int checkPatientDestination(int schedule_id)
        {
            ScheduleReportSelectData rsentry = new ScheduleReportSelectData();
            return rsentry.checkPatientDestination(schedule_id);
        }
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
