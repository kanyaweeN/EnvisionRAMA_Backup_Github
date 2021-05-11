using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
    public class GBLRole
    {
        private int _submenuid;
        private string _submenuuid;
        private string _submenunameuser;

        private int _roleid;
        private string _roleuid;
        private string _rolename;
        private string _roledesc;
        private int _roledtlid;
        private string _roledtluid;

        private string _isupdated;
        private string _isdeleted;
        private string _isactive;

        private string _canview;
        private string _canmodify;
        private string _canremove;
        private string _cancreate;

        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;

        public GBLRole(int iRoleID, string sRoleUID, string sRoleName, string sRoleDesc,
            string sIsActive, int iRoleDTLID, string sSubMenuUID, string sSubMenuName,
            string sView, string sCreate, string sRemove, string sModify,
            int iOrgID, int iCreateBy, string sCreateOn)
        {
            _roleid = iRoleID;
            _roleuid = sRoleUID;
            _rolename = sRoleName;
            _roledesc = sRoleDesc;
            _isactive = sIsActive;
            _roledtlid = iRoleDTLID;
            _submenuuid = sSubMenuUID;
            _submenunameuser = sSubMenuName;
            _canview = sView;
            _canmodify = sModify;
            _cancreate = sCreate;
            _canremove = sRemove;
            
            _orgid = iOrgID;
            _createdby = iCreateBy;
            _createdon = sCreateOn;
            
        }

        public GBLRole()
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

        public string SubMenuNameUser
        {
            get { return _submenunameuser; }
            set { _submenunameuser = value; }
        }

        public int RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        public int RoleDTLId
        {
            get { return _roledtlid; }
            set { _roledtlid = value; }
        }

        public string RoleUID
        {
            get { return _roleuid; }
            set { _roleuid = value; }
        }

        public string RoleDTLUID
        {
            get { return _roledtluid; }
            set { _roledtluid = value; }
        }

        public string RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }

        public string RoleDesc
        {
            get { return _roledesc; }
            set { _roledesc = value; }
        }

        public string IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        public string IsUpdated
        {
            get { return _isupdated; }
            set { _isupdated = value; }
        }

        public string IsDeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        public string CanView
        {
            get { return _canview; }
            set { _canview = value; }
        }

        public string CanModify
        {
            get { return _canmodify; }
            set { _canmodify = value; }
        }

        public string CanCreate
        {
            get { return _cancreate; }
            set { _cancreate = value; }
        }

        public string CanRemove
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

    public class roleObjectCollection : CollectionBase
    {
        public void Add(GBLRole _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLRole this[int index]
        {
            get
            {
                return (GBLRole)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
