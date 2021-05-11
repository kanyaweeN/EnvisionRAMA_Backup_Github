using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLEnv : IBusinessLogic
    {
        public GBL_ENV GBL_ENV { get; set; }

        public ProcessUpdateGBLEnv()
        {
            GBL_ENV = new GBL_ENV();
        }

        public void Invoke()
        {
            GBLEnvUpdateData envdata = new GBLEnvUpdateData();
            envdata.GBL_ENV = this.GBL_ENV;
            envdata.Add();

        }
    }
}
