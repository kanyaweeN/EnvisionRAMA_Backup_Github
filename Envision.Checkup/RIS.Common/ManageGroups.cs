using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class ManageGroups
    {
        private int _gid;
        private string _guid;
		private string _gname;
		private string _gtype;
		private string _isactive;
		private int _ghead;
		private string _gheadname;
        private int _gcontactno;

        private int _memberid;
        private byte _sl;

        private string _gusername;
        private string _gpass;

        private int _orgid;

        public ManageGroups()
        {
        }

        public int GROUP_ID
        {
            get { return _gid; }
            set { _gid = value; }
        }
        public string GROUP_UID
        {
            get { return _guid; }
            set { _guid= value; }
        }
		public string GROUP_NAME
        {
            get { return _gname; }
            set { _gname= value; }
        }
		public string GROUP_TYPE
        {
            get { return _gtype; }
            set { _gtype = value; }
        }
		public string IS_ACTIVE
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
		public int GROUP_HEAD
        {
            get { return _ghead; }
            set { _ghead =value; }
        }
		public string GROUP_HEAD_NAME
        {
            get { return _gheadname; }
            set { _gheadname = value; }
        }
		public int GROUP_CONTACT_NO
        {
            get { return _gcontactno; }
            set { _gcontactno = value; }
        }

        public int MEMBER_ID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }
        public byte SL
        {
            get { return _sl; }
            set { _sl = value; }
        }

        public string GROUP_USER_NAME
        {
            get { return _gusername; }
            set { _gusername = value; }
        }
        public string GROUP_PASS
        {
            get { return _gpass; }
            set { _gpass = value; }
        }

        public int ORG_ID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }
    }
}
