using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{

    public class RISSF09Data
    {
        private int _examtypeid;
        private string _examtypeuid;
        private string _examtypetext;
        private string _isactive;
        private int _orgid;
        private int _createdby;
        private int _lastmodifiedby;

        public RISSF09Data()
        {
        }
        public int EXAM_TYPE_ID
        {
            get { return _examtypeid; }
            set { _examtypeid = value; }
        }

        public string EXAM_TYPE_UID
        {
            get { return _examtypeuid; }
            set { _examtypeuid = value; }
        }

        public string EXAM_TYPE_TEXT
        {
            get { return _examtypetext; }
            set { _examtypetext = value; }
        }

        public string IS_ACTIVE
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

        public int LASTMODIFIED_BY
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }
    }

    public class RIS_SF09ObjectCollection : CollectionBase
    {
        public void Add(RISSF09Data _alertObject)
        {
            this.List.Add(_alertObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }

        public RISSF09Data this[int index]
        {
            get
            {
                return (RISSF09Data)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }

}
