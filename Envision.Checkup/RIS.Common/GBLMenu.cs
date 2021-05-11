using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
    public class GBLMenu
    {
        private int _menuid;
        private string _menuuid;
        private string _menuname;
        private string _menunamespace;
        private string _menudesc;
        private int _menuparent;
        private int _menuslno;
        private string _menu_isactive;
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;
        private byte[] _menuicon;

        public GBLMenu()
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

        public string MenuName
        {
            get { return _menuname; }
            set { _menuname = value; }
        }

        public string MenuNameSpace
        {
            get { return _menunamespace; }
            set { _menunamespace = value; }
        }

        public string MenuDesc
        {
            get { return _menudesc; }
            set { _menudesc = value; }
        }

        public int MenuParent
        {
            get { return _menuparent; }
            set { _menuparent = value; }
        }

        public int MenuSLNo
        {
            get { return _menuslno; }
            set { _menuslno = value; }
        }

        public string MenuIsActive
        {
            get { return _menu_isactive; }
            set { _menu_isactive = value; }
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

        public byte[] MenuICon
        {
            get { return _menuicon; }
            set { _menuicon = value; }
        }
    }

    public class menuObjectCollection : CollectionBase
    {
        public void Add(GBLMenu _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLMenu this[int index]
        {
            get
            {
                return (GBLMenu)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
