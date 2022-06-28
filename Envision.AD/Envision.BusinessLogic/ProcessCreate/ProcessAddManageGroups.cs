using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddManageGroups : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        public ProcessAddManageGroups()
        {
            GBL_GROUP = new GBL_GROUP();
        }

        public void Invoke()
        {
            ManageGroupsInsertData mng = new ManageGroupsInsertData();
            mng.GBL_GROUP = GBL_GROUP;
            mng.Set();
        }
    }
}
