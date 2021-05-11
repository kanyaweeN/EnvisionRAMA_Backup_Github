using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{

    public class GBLSession
    {
        private string _guid;
        private int _empid;
        private int _orgid;
        private string _ipaddr;
        private string _logtype;
        private string _logstat;
        private int _sptype;
      

        public GBLSession()
        {
        }

        public string SessionGUID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public int EmpID
        {
            get { return _empid; }
            set { _empid = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public string IpAddress
        {
            get { return _ipaddr; }
            set { _ipaddr = value; }
        }

        public string LogonType
        {
            get { return _logtype; }
            set { _logtype = value; }
        }

        public string LogonStatus
        {
            get { return _logstat; }
            set { _logstat = value; }
        }

        public int SPType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }



    }

}
