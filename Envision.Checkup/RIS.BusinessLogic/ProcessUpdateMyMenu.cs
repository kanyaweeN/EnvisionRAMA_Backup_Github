/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
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
