using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGlobalAlert : IBusinessLogic
    {
        public GBL_ALERT GBL_ALERT { get; set; }
        public DataSet ResultSet { get; set; }

        public ProcessGetGlobalAlert()
        {
            GBL_ALERT = new GBL_ALERT();
            ResultSet = new DataSet();
        }

        public void Invoke()
        {
            GlobalAlertSelectData alertdata = new GlobalAlertSelectData();
            alertdata.GBL_ALERT = this.GBL_ALERT;
            ResultSet = alertdata.Get();
        }     

    }
}
