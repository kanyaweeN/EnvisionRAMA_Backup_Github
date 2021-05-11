using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLSubMenu : IBusinessLogic
    {
        private GBLSubMenu _gblsubmenu;

        public ProcessUpdateGBLSubMenu()
        {

        }

        public void Invoke()
        {
            GBLSubMenuUpdateData menudata = new GBLSubMenuUpdateData();
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
