using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLEnv : IBusinessLogic
    {
        private GBLEnv _gblenv;

        public ProcessUpdateGBLEnv()
        {

        }

        public void Invoke()
        {
            GBLEnvUpdateData envdata = new GBLEnvUpdateData();
            envdata.GBLEnv = this.GBLEnv;
            envdata.Add();

        }

        public GBLEnv GBLEnv
        {
            get { return _gblenv; }
            set { _gblenv = value; }
        }
    }
}
