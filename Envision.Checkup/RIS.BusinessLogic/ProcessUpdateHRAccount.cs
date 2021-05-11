using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateHRAccount : IBusinessLogic
    {
        private HRAccount _hraccount;

        public ProcessUpdateHRAccount()
        {

        }

        public void Invoke()
        {
            HRAccountUpdateData HRAccdata = new HRAccountUpdateData();
            HRAccdata.HRAccount = this.HRAccount;
            HRAccdata.Add();

        }

        public HRAccount HRAccount
        {
            get { return _hraccount; }
            set { _hraccount = value; }
        }
    }
}
