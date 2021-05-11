using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLEmployee : IBusinessLogic
    {
        private GBLEmployee _gblemp;

        public ProcessUpdateGBLEmployee()
        {

        }

        public void Invoke()
        {
            GBLEmployeeUpdateData envdata = new GBLEmployeeUpdateData();
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
