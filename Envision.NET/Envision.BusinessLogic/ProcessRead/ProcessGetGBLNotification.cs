using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLNotification: IBusinessLogic
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }
        private DataSet _resultset;

        public ProcessGetGBLNotification()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
        }

        public void Invoke()
        {
            GBLNotificationSelectData data = new GBLNotificationSelectData();
            data.GBL_NOTIFICATION = this.GBL_NOTIFICATION;
            ResultSet = data.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
