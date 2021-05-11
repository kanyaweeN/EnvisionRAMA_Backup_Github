using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ResultEntryWorkList
    {
        private int _sptype;
        private int _assignto;
        private DateTime _fromdate;
        private DateTime _todate;
        private int _orgid;
        private string _hn;


        public ResultEntryWorkList()
        {
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public int AssignedTo
        {
            get { return _assignto; }
            set { _assignto = value; }
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

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public string PatientID
        {
            get { return _hn; }
            set { _hn = value; }
        }

       
    }



}
