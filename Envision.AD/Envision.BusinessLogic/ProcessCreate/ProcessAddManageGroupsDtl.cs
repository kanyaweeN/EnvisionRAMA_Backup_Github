using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddManageGroupsDtl : IBusinessLogic
    {
        public GBL_GROUPDTL GBL_GROUPDTL { get; set; }
        public ProcessAddManageGroupsDtl()
        {
            GBL_GROUPDTL = new GBL_GROUPDTL();
        }

        public void Invoke()
        {
            ManageGroupsInsertDataDtl mngdtl = new ManageGroupsInsertDataDtl();
            mngdtl.GBL_GROUPDTL = this.GBL_GROUPDTL;
            mngdtl.Set();
        }

    }
}
