using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
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

        public ReportParameters()
        {
        }

        public string PatientId
        {
            get { return _hn; }
            set { _hn = value; }
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

    }


}

