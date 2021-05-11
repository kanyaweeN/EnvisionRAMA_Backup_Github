using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLSubMenu : IBusinessLogic
    {
        private GBLSubMenu _gblsubmenu;

        public ProcessAddGBLSubMenu()
        {

        }

        public void Invoke()
        {
            GBLSubMenuInsertData menudata = new GBLSubMenuInsertData();
            menudata.GBLSubMenu = this.GBLSubMenu;
            menudata.Add();

        }

        public GBLSubMenu GBLSubMenu
        {
            get { return _gblsubmenu; }
            set { _gblsubmenu = value; }
        }
    }
}
