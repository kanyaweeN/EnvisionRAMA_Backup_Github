using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetManageGroupsTableDtl : IBusinessLogic
    {
        private DataSet _dataresult;
        private ManageGroups _managegroups;

        public ProcessGetManageGroupsTableDtl()
        {
        }

        public void Invoke()
        {
            ManageGroupsTableDtlSelectData mng = new ManageGroupsTableDtlSelectData();
            mng.ManageGroups = this.ManageGroups;
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
