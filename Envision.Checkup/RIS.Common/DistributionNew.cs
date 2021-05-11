using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class DistributionNew
    {
                #region Constructor
        public DistributionNew()
        {
        }
        #endregion



        #region Member

        private int _selectcase;
        private DateTime _datefrom;
        private DateTime _todate;
        private string _assignName;
        private string _accessionNo;
        private string _hn;
        private int _assignedto;
        private int _empid;
        private int _lastmodifiedby;
        private string _priority;

        #endregion


        #region Property


        public int selectcase
        {
            get { return _selectcase; }
            set { _selectcase = value; }
        }
        public DateTime datefrom
        {
            get { return _datefrom; }
            set { _datefrom = value; }
        }
        public DateTime todate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        public string assignname
        {
            get { return _assignName; }
            set { _assignName = value; }
        }
        public string accessionno
        {
            get { return _accessionNo; }
            set { _accessionNo = value; }
        }
        public string hn
        {
            get { return _hn; }
            set { _hn = value; }
        }
        public int assignedTo
        {
            get { return _assignedto; }
            set { _assignedto = value; }
        }
        public int EMP_ID
        {
            get { return _empid; }
            set { _empid = value; }
        }
        public int LAST_MODIFIED_BY
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }
        public string PRIORITY
        {
            get { return _priority; }
            set { _priority = value; }
        }

        #endregion


        public void Update()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
