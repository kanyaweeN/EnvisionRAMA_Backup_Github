using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessLoadTreeGrantRole
    {

        private int _type;
        private int _subType;
        private int _pid;
        private int _cid;
        private string _search;
        private DataSet _resultset;
        

        public DataSet Invoke()
        {
            
            GBLGrantRoleLoadTreeData obj = new GBLGrantRoleLoadTreeData();
            obj.Type = _type;
            obj.SubType = _subType;
            obj.ParentId = _pid;
            obj.ChildId = _cid;
            obj.Search = _search;
            _resultset = obj.Get();
            return _resultset;
        }

        public int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public int SubType
        {
            get { return this._subType; }
            set { this._subType = value; }
        }
        public int ParentId
        {
            get { return this._pid; }
            set { this._pid = value; }
        }
        public int ChildId
        {
            get { return this._cid; }
            set { this._cid = value; }
        }
        public string Search
        {
            get { return this._search; }
            set { this._search = value; }
        }
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

    }
}
