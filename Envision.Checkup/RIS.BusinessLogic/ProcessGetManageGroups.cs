using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RIS.DataAccess.Select;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetManageGroups : IBusinessLogic
    {
        private ManageGroups _mng;
        private DataSet _resultset;

        public ProcessGetManageGroups()
        {
        }
        public void Invoke()
        {
            ManageGroupsSelectData manage = new ManageGroupsSelectData();
            manage.ManageGroups = this.ManageGroups;
            ResultSet = manage.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }
}
