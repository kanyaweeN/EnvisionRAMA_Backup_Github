/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMyMenu : IBusinessLogic
    {
        public GBL_MYMENU GBL_MYMENU { get; set; }
        int submenu;
        string active;
        public ProcessAddMyMenu(int uid, string status)
        {
            GBL_MYMENU = new GBL_MYMENU();
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
