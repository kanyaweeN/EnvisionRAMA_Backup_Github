using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLAlert : IBusinessLogic
    {
        public GBL_ALERT_ALERTDTL GBL_ALERT_ALERTDTL { get; set; }

        public ProcessUpdateGBLAlert()
        {
            GBL_ALERT_ALERTDTL = new GBL_ALERT_ALERTDTL();
        }

        public void Invoke()
        {
            GBLAlertUpdateData alertdata = new GBLAlertUpdateData();
            alertdata.GBL_ALERT_ALERTDTL = this.GBL_ALERT_ALERTDTL;
            alertdata.Add();

        }
    }
}
