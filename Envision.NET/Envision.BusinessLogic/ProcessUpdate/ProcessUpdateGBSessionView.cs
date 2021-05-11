using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBSessionView : IBusinessLogic
    {
        public string Reason{get;set;}

        public string UserLogin { get; set; }
        public string SessionGUID { get; set; }
        public ProcessUpdateGBSessionView()
        {
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            GBLSessionViewerUpdate gBLSessionViewerUpdate = new GBLSessionViewerUpdate();
            gBLSessionViewerUpdate.SessionGUID = SessionGUID;
            gBLSessionViewerUpdate.UserLogin = UserLogin;
            gBLSessionViewerUpdate.Reason = Reason;
            gBLSessionViewerUpdate.Update();
        }

        #endregion
    }
}
