using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLGrantRoleISUpdated :IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessUpdateGBLGrantRoleISUpdated() { }
        public void Invoke()
        {
            GBLGrantRoleUpdateDataISUpdated update = new GBLGrantRoleUpdateDataISUpdated();
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
