using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLGrantRole
    {
        private int _grantroleid;
        private int _roleid;
        private int _empid;
        private int _cangrant;
        private int _grantor;
        private DateTime _grantdt;
        private string _isupdated;
        private string _isdeleted;

        private int _orgid;

        public int GRANTROLE_ID
        {
            get { return _grantroleid; }
            set { _grantroleid = value; }
        }
        public int ROLE_ID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public int EMP_ID
        {
            get { return _empid; }
            set { _empid = value; }
        }
        public int CAN_GRANT
        {
            get { return _cangrant; }
            set { _cangrant = value; }
        }
        public int GRANTOR
        {
            get { return _grantor; }
            set { _grantor = value; }
        }
        public DateTime GRANT_DT
        {
            get { return _grantdt; }
            set { _grantdt = value; }
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

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }
    }
}
