using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class RISPatstatus
    {
        private int _selectcase;
        private int _statusid;
        private string _statusuid;
        private string _statustext;
        private string _isactive;
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;
        private string _isdefault;


        public RISPatstatus()
        {
        }

        public int SELECTCASE
        {
            get { return _selectcase; }
            set { _selectcase = value; }
        }
        public int STATUS_ID
        {
            get { return _statusid; }
            set { _statusid = value; }
        }

        public string STATUS_UID
        {
            get { return _statusuid; }
            set { _statusuid = value; }
        }

        public string STATUS_TEXT
        {
            get { return _statustext; }
            set { _statustext = value; }
        }

        public string IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        public int ORG_ID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int CREATED_BY
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public string CREATED_ON
        {
            get { return _createdon; }
            set { _createdon = value; }
        }

        public int LAST_MODIFIED_BY
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }

        public string LAST_MODIFIED_ON
        {
            get { return _lastmodifiedon; }
            set { _lastmodifiedon = value; }
        }
        public string IS_DEFAULT
        {
            get { return _isdefault; }
            set { _isdefault = value; }
        }

    }

    public class PatienObjectCollection : CollectionBase
    {
        public void Add(RISPatstatus _alertObject)
        {
            this.List.Add(_alertObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }

        //public RISPatstatus this[int index]
        //{
        //    get
        //    {
        //        return (RISPatstatus)List[index];
        //    }
        //    set
        //    {
        //        List[index] = value;
        //    }
        //}
    }

}
