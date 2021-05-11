using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLGrantRole : IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessAddGBLGrantRole() { }
        public void Invoke()
        {
            GBLGrantRoleInsertData update = new GBLGrantRoleInsertData();
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
