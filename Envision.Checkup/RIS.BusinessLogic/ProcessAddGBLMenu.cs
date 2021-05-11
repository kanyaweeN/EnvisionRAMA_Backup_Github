using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLMenu : IBusinessLogic
    {
        private GBLMenu _gblmenu;

        public ProcessAddGBLMenu()
        {

        }

        public void Invoke()
        {
            GBLMenuInsertData menudata = new GBLMenuInsertData();
            menudata.GBLMenu = this.GBLMenu;
            menudata.Add();

        }

        public GBLMenu GBLMenu
        {
            get { return _gblmenu; }
            set { _gblmenu = value; }
        }
    }
}
