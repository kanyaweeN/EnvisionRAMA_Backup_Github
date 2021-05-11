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
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddMyMenu : IBusinessLogic
    {
        int submenu;
        string active;
        public ProcessAddMyMenu(int uid, string status)
        {
            submenu = uid;
            active = status;
        }

        public void Invoke()
        {
            MyMenuInsertData menudata = new MyMenuInsertData(submenu,active);
            menudata.Add();

        }

        
    }
}
