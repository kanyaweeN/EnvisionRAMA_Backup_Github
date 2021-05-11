using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateManageGroups : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        public ProcessUpdateManageGroups()
        {
            GBL_GROUP = new GBL_GROUP();
        }

        public void Invoke()
        {
            ManageGroupsUpdateData mng = new ManageGroupsUpdateData();
            mng.GBL_GROUP = GBL_GROUP;
            mng.Set();
        }
    }
}
