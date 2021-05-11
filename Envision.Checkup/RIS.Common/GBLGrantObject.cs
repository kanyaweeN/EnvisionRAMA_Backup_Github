using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLGrantObject
    {
        private int _grantObjectId;
        private int _subMenuUid;
        private int _empID;
        private string _canView;
        private string _canCreate;
        private string _canModify;
        private string _canRemove;

        public GBLGrantObject(int grantObjectId, int subMenuUid, int empID, string canView, string canCreate, string canModify, string canRemove)
        {
            this._grantObjectId = grantObjectId;
            this._subMenuUid = subMenuUid;
            this._empID = empID;
            this._canView = canView;
            this._canCreate = canCreate;
            this._canModify = canModify;
            this._canRemove = canRemove;
        }

        public int GrantObjectId
        {
            get { return _grantObjectId; }
            set { _grantObjectId = value; }
        }

        public int SubMenuUid
        {
            get { return _subMenuUid; }
            set { _subMenuUid = value; }
        }

        public int EmpID
        {
            get { return _empID; }
            set { _empID = value; }
        }

        public string CanView
        {
            get { return _canView; }
            set { _canView = value; }
        }

        public string CanCreate
        {
            get { return _canCreate; }
            set { _canCreate = value; }
        }

        public string CanModify
        {
            get { return _canModify; }
            set { _canModify = value; }
        }

        public string CanRemove
        {
            get { return _canRemove; }
            set { _canRemove = value; }
        }
    }
}
