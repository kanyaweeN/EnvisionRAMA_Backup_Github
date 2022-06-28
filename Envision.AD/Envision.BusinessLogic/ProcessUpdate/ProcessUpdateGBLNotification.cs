using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLNotification: IBusinessLogic
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }

        public ProcessUpdateGBLNotification()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
        }

        public void Invoke()
        {
            GBLNotificationUpdateData data = new GBLNotificationUpdateData();
            data.GBL_NOTIFICATION = this.GBL_NOTIFICATION;
            data.Add();

        }
    }
}