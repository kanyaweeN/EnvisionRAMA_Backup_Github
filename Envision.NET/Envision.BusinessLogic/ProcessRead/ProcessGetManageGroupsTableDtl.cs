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
    public class ProcessGetManageGroupsTableDtl : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        private DataSet _dataresult;

        public ProcessGetManageGroupsTableDtl()
        {
            GBL_GROUP = new GBL_GROUP();
        }

        public void Invoke()
        {
            ManageGroupsTableDtlSelectData mng = new ManageGroupsTableDtlSelectData();
            mng.GBL_GROUP = this.GBL_GROUP;
            DataResult = mng.Get();
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
