using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLNotification : IBusinessLogic
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }

        public ProcessDeleteGBLNotification()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
        }

        public void Invoke()
        {
            GBLNotificationDeleteData alertData = new GBLNotificationDeleteData();
            alertData.GBL_NOTIFICATION = GBL_NOTIFICATION;
            alertData.Delete();
        }
    }
}
