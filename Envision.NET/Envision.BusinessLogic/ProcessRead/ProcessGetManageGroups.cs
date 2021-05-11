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
    public class ProcessGetManageGroups : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        private DataSet _resultset;

        public ProcessGetManageGroups()
        {
        }
        public void Invoke()
        {
            ManageGroupsSelectData manage = new ManageGroupsSelectData();
            manage.GBL_GROUP = this.GBL_GROUP;
            ResultSet = manage.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
