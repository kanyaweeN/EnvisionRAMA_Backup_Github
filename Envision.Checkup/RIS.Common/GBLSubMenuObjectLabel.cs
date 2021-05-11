using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
    public class GBLSubMenuObjectLabel
    {
        private int _submenuid;
        private string _submenuuid;
        private int _objectid;
        private string _objectname;
        private int _langid;
        private string _label;
        
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;

        public GBLSubMenuObjectLabel()
        {
        }

        public GBLSubMenuObjectLabel(string sSubMenuUID, int iObjectID, int iLangID, string sLabel, int iOrgID, int iCreateBy, string sCreateOn, string sObjectName)
        {
            _submenuuid = sSubMenuUID;
            _objectid = iObjectID;
            _langid = iLangID;
            _label = sLabel;
            _orgid = iOrgID;
            _createdby = iCreateBy;
            _createdon = sCreateOn;
            _objectname = sObjectName;
            
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

        public string ObjectName
        {
            get { return _objectname; }
            set { _objectname = value; }
        }

        public int LangID
        {
            get { return _langid; }
            set { _langid = value; }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
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

    public class submenuobjectlabelObjectCollection : CollectionBase
    {
        public void Add(GBLSubMenuObjectLabel _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLSubMenuObjectLabel this[int index]
        {
            get
            {
                return (GBLSubMenuObjectLabel)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
