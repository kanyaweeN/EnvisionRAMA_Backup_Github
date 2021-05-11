using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteManageGroupsDtl : IBusinessLogic
    {
        public GBL_GROUPDTL GBL_GROUPDTL { get; set; }

        public ProcessDeleteManageGroupsDtl()
        {
            GBL_GROUPDTL = new GBL_GROUPDTL();
        }

        public void Invoke()
        {
            ManageGroupsDeleteDataDtl mng = new ManageGroupsDeleteDataDtl();
            mng.GBL_GROUPDTL = GBL_GROUPDTL;
            mng.Set();
        }
    }
}
