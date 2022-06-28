using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMyMenu : IBusinessLogic
    {
        int submenu;
        string active;

        public ProcessUpdateMyMenu(int uid,string status)
        {
            submenu = uid;
            active = status;
        }

        public void Invoke()
        {
            MymenuUpdateData mydata = new MymenuUpdateData(submenu, active);
            mydata.Update();

        }

        
    }
}
