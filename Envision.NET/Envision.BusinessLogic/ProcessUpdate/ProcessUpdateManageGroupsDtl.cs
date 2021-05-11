using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateManageGroupsDtl : IBusinessLogic
    {
        public GBL_GROUPDTL GBL_GROUPDTL { get; set; }

        public ProcessUpdateManageGroupsDtl()
        {
            GBL_GROUPDTL = new GBL_GROUPDTL();
        }

        public void Invoke()
        {
            ManageGroupsUpdateDataDtl mngdtl = new ManageGroupsUpdateDataDtl();
            mngdtl.GBL_GROUPDTL = this.GBL_GROUPDTL;
            mngdtl.Set();
        }
    }
}
