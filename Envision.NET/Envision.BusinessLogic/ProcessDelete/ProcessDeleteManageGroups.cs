using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteManageGroups : IBusinessLogic
    {
        public GBL_GROUP GBL_GROUP { get; set; }

        public ProcessDeleteManageGroups()
        {
            GBL_GROUP = new GBL_GROUP();
        }

        public void Invoke()
        {
            ManageGroupsDeleteData mng = new ManageGroupsDeleteData();
            mng.GBL_GROUP = GBL_GROUP;
            mng.Set();
        }
    }
}
