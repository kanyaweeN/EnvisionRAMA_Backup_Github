using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLGrantRoleISUpdated :IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessUpdateGBLGrantRoleISUpdated() { GBL_GRANTROLE = new GBL_GRANTROLE(); }
        public void Invoke()
        {
            GBLGrantRoleUpdateDataISUpdated update = new GBLGrantRoleUpdateDataISUpdated();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
