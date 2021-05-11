using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBSessionView : IBusinessLogic
    {
        private string userLogin;
        private string sessionGUID;
        private string reason;
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }
        public string SessionGUID
        {
            get { return sessionGUID; }
            set { sessionGUID = value; }
        }
        public ProcessUpdateGBSessionView()
        {
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            GBLSessionViewerUpdate gBLSessionViewerUpdate = new GBLSessionViewerUpdate();
            gBLSessionViewerUpdate.SessionGUID = sessionGUID;
            gBLSessionViewerUpdate.UserLogin = userLogin;
            gBLSessionViewerUpdate.Reason = reason;
            gBLSessionViewerUpdate.Update();
        }

        #endregion
    }
}
