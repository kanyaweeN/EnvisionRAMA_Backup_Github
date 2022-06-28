using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessCloseSession : IBusinessLogic
    {
        public GBL_SESSION GBL_SESSION { get; set; }

        public ProcessCloseSession()
        {
            GBL_SESSION = new GBL_SESSION();
        }

        public void Invoke()
        {
            UpdateSessionData alertdata = new UpdateSessionData();
            alertdata.GBL_SESSION = this.GBL_SESSION;
            alertdata.Update();

        }
    }
}
