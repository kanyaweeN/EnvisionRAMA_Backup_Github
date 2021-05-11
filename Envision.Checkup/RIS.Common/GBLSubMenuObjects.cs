using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
    public class GBLSubMenuObjects
    {
        private int _submenuid;
        private string _submenuuid;
        private string _submenunameuser;

        private int _objectid;
        private string _objecttype;
        private string _objectname;
        
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;

        public GBLSubMenuObjects(string sSubMenuUID, int iObjectID, string sObjectName, string sObjectType, int iOrgID, int iCreateBy, string sCreateOn)
        {
            _submenuuid = sSubMenuUID;
            _objectid = iObjectID;
            _objectname = sObjectName;
            _objecttype = sObjectType;
            _orgid = iOrgID;
            _createdby = iCreateBy;
            _createdon = sCreateOn;
            
        }

        public GBLSubMenuObjects()
        {
        }

        public int SubMenuID
        {
            get { return _submenuid; }
            set { _submenuid = value; }
        }

        public string SubMenuUID
        {
            get { return _submenuuid; }
            set { _submenuuid = value; }
        }

        public int ObjectID
        {
            get { return _objectid; }
            set { _objectid = value; }
        }

        public string ObjectType
        {
            get { return _objecttype; }
            set { _objecttype = value; }
        }

        public string ObjectName
        {
            get { return _objectname; }
            set { _objectname = value; }
        }

        public string SubMenuNameUser
        {
            get { return _submenunameuser; }
            set { _submenunameuser = value; }
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

        public string CreatedOn
        {
            get { return _createdon; }
            set { _createdon = value; }
        }

        public int ModifiedBy
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }

        public string ModifiedOn
        {
            get { return _lastmodifiedon; }
            set { _lastmodifiedon = value; }
        }
    }

    public class submenuobjectsObjectCollection : CollectionBase
    {
        public void Add(GBLSubMenuObjects _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLSubMenuObjects this[int index]
        {
            get
            {
                return (GBLSubMenuObjects)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
