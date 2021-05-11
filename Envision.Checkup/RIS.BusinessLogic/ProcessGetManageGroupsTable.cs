using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetManageGroupsTable : IBusinessLogic
    {
        private DataSet _dataresult;
        ManageGroups _managegroups;

        public ProcessGetManageGroupsTable()
        { 
        }

        public void Invoke()
        {
            ManageGroupsTableSelectData mng = new ManageGroupsTableSelectData();
            DataResult = mng.Get();
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }

        public ManageGroups ManageGroups
        {
            get { return _managegroups; }
            set { _managegroups = value; }
        }
    }
}
