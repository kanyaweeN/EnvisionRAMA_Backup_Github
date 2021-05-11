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
