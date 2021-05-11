using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;


namespace EnvisionOnline.Common
{

    public class ReportParameters
    {
        private int _sptype;
        private string _resultstatus;
        private string _accessionno;
        private int _orgid;

        private string _hn;
        private DateTime _appointdate;
        private int _modalityid;
        private int _scheduleid;

        private DateTime _fromdate;
        private DateTime _todate;
        private int _unitid;

        private int _session;
        private int _examtype;

        public ReportParameters()
        {
        }

        public string PatientId
        {
            get { return _hn; }
            set { _hn = value; }
        }
        public int Exam_type_id
        {
            get { return _examtype; }
            set { _examtype = value; }
        }
        public DateTime AppointDate
        {
            get { return _appointdate; }
            set { _appointdate = value; }
        }

        public int ModalityId
        {
            get { return _modalityid; }
            set { _modalityid = value; }
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public string ResultStatus
        {
            get { return _resultstatus; }
            set { _resultstatus = value; }
        }

        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }
        public int ScheduleID
        {
            get { return _scheduleid; }
            set { _scheduleid = value; }
        }
        public DateTime FromDate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }
        public DateTime ToDate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        public int Unit_ID
        {
            get { return _unitid; }
            set { _unitid = value; }
        }
        public int Session
        {
            get { return _session; }
            set { _session = value; }
        }
    }


}

