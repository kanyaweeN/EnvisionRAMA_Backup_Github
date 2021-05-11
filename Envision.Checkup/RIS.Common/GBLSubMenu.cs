using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
    public class GBLSubMenu
    {
        private int _menuid;
        private string _menuuid;

        private int _submenuid;
        private string _submenuuid;
        private string _submenutype;
        private string _submenuclassname;
        private string _submenunamesys;
        private string _submenunameuser;
        private int _parent;
        private string _desc;
        private int _slno;
        private string _isactive;
        private string _addtohome;
        private string _canview;
        private string _canmodify;
        private string _canremove;
        private string _cancreate;
        
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;

        public GBLSubMenu()
        {
        }

        public int MenuID
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        public string MenuUID
        {
            get { return _menuuid; }
            set { _menuuid = value; }
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

        public string SubMenuType
        {
            get { return _submenutype; }
            set { _submenutype = value; }
        }

        public string SubMenuClassName
        {
            get { return _submenuclassname; }
            set { _submenuclassname = value; }
        }

        public string SubMenuNameSys
        {
            get { return _submenunamesys; }
            set { _submenunamesys = value; }
        }

        public string SubMenuNameUser
        {
            get { return _submenunameuser; }
            set { _submenunameuser = value; }
        }

        public int SubMenuParent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public string SubMenuDesc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public int SubMenuSlNo
        {
            get { return _slno; }
            set { _slno = value; }
        }

        public string SubMenuIsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        public string SubMenuAddToHome
        {
            get { return _addtohome; }
            set { _addtohome = value; }
        }

        public string SubMenuCanView
        {
            get { return _canview; }
            set { _canview = value; }
        }

        public string SubMenuCanModify
        {
            get { return _canmodify; }
            set { _canmodify = value; }
        }

        public string SubMenuCanCreate
        {
            get { return _cancreate; }
            set { _cancreate = value; }
        }

        public string SubMenuCanRemove
        {
            get { return _canremove; }
            set { _canremove = value; }
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

    public class submenuObjectCollection : CollectionBase
    {
        public void Add(GBLSubMenu _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLSubMenu this[int index]
        {
            get
            {
                return (GBLSubMenu)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
