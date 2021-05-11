using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLGrantRole :IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessUpdateGBLGrantRole()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
        }
        public void Invoke()
        {
            GBLGrantRoleUpdateData update = new GBLGrantRoleUpdateData();
            update.GBL_GRANTROLE = GBL_GRANTROLE;
            update.Get();
        }
    }
}
