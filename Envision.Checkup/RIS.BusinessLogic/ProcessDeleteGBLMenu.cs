using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLMenu : IBusinessLogic
    {
        private GBLMenu _gblmenu;

        public ProcessDeleteGBLMenu()
        {

        }

        public void Invoke()
        {
            GBLMenuDeleteData menudata = new GBLMenuDeleteData();
            menudata.GBLMenu = this.GBLMenu;
            menudata.Delete();
        }

        public GBLMenu GBLMenu
        {
            get { return _gblmenu; }
            set { _gblmenu = value; }
        }
    }
}
