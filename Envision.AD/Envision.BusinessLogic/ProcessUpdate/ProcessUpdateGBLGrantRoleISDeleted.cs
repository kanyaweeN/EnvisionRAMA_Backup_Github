using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLGrantRoleISDeleted :IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public ProcessUpdateGBLGrantRoleISDeleted()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
        }
        public void Invoke()
        {
            GBLGrantRoleUpdateDataISDeleted update = new GBLGrantRoleUpdateDataISDeleted();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
