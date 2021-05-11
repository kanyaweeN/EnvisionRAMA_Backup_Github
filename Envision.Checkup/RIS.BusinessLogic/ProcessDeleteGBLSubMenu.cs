using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLSubMenu : IBusinessLogic
    {
        private GBLSubMenu _gblsubmenu;

        public ProcessDeleteGBLSubMenu()
        {

        }

        public void Invoke()
        {
            GBLSubMenuDeleteData menudata = new GBLSubMenuDeleteData();
            menudata.GBLSubMenu = this.GBLSubMenu;
            menudata.Delete();
        }

        public GBLSubMenu GBLSubMenu
        {
            get { return _gblsubmenu; }
            set { _gblsubmenu = value; }
        }
    }
}
