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
    public class ProcessGetManageGroupsTable : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        private DataSet _dataresult;

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
    }
}
