using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLGrantRoleByEmployee : IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessAddGBLGrantRoleByEmployee() { }
        public void Invoke()
        {
            GBLGrantRoleInsertDataEmployee update = new GBLGrantRoleInsertDataEmployee();
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
