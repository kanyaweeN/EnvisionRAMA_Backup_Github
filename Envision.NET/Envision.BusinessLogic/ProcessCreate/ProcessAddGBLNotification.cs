using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLNotification : IBusinessLogic
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }
		public ProcessAddGBLNotification()
		{
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
		}
		public void Invoke()
		{
            GBLNotificationInsertData _proc = new GBLNotificationInsertData();
            _proc.GBL_NOTIFICATION = this.GBL_NOTIFICATION;
            _proc.Add();
		}
    }
}
