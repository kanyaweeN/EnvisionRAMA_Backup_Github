using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLEmployee : IBusinessLogic
    {
        private GBLEmployee _gblemp;

        public ProcessAddGBLEmployee()
        {

        }

        public void Invoke()
        {
            GBLEmployeeInsertData envdata = new GBLEmployeeInsertData();
            envdata.GBLEmployee = this.GBLEmployee;
            envdata.Add();

        }

        public GBLEmployee GBLEmployee
        {
            get { return _gblemp; }
            set { _gblemp = value; }
        }
    }
}
