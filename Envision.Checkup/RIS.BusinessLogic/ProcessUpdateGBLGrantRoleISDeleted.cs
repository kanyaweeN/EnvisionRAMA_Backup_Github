using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLGrantRoleISDeleted :IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessUpdateGBLGrantRoleISDeleted() { }
        public void Invoke()
        {
            GBLGrantRoleUpdateDataISDeleted update = new GBLGrantRoleUpdateDataISDeleted();
            update.GBLGrantRole = GBLGrantRole;
            update.Get();
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
}
