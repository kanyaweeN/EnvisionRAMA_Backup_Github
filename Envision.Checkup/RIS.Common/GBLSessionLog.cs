using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{

    public class GBLSessionLog
    {
        private int _sptype;
        private string _guid;
        private int _submenuid;
        private int _orgid;
        private int _createdby;



        public GBLSessionLog()
        {
        }

        public int SPType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public string SessionGUID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public int SubmenuID
        {
            get { return _submenuid; }
            set { _submenuid = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

   }

}
