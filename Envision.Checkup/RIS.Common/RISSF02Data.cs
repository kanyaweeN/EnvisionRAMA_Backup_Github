using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class RISSF02Data
    {
        private int _icdid;
        private string _icduid;
        private string _icddesc;
        private string _icdversion;
        private string _isupdate;
        private string _isdeleted;
        private int _orgid;
        private int _createdby;
        private int _lastmodifiedby;

        public RISSF02Data()
        {
        }
        public int ICD_ID
        {
            get { return _icdid; }
            set { _icdid = value; }
        }

        public string ICD_UID
        {
            get { return _icduid; }
            set { _icduid = value; }
        }

        public string ICD_DESC
        {
            get { return _icddesc; }
            set { _icddesc = value; }
        }

        public string ICD_VERSION
        {
            get { return _icdversion; }
            set { _icdversion = value; }
        }

        public string IS_UPDATE
        {
            get { return _isupdate; }
            set { _isupdate = value; }
        }

        public string IS_DELETED
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
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

        public int LASTMODIFIED_BY
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }
    }

    public class RIS_SF02ObjectCollection : CollectionBase
    {
        public void Add(RISSF02Data _alertObject)
        {
            this.List.Add(_alertObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }

        public RISSF02Data this[int index]
        {
            get
            {
                return (RISSF02Data)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }

}
