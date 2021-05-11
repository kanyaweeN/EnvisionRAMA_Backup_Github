using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLMenu : IBusinessLogic
    {
        private GBLMenu _gblmenu;

        public ProcessUpdateGBLMenu()
        {

        }

        public void Invoke()
        {
            GBLMenuUpdateData menudata = new GBLMenuUpdateData();
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
