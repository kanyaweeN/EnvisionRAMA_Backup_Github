using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLMenu : IBusinessLogic
    {
        public GBL_MENU GBL_MENU { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLMenu()
        {
            GBL_MENU = new GBL_MENU();
            Transaction = null;
        }

        public void Invoke()
        {
            GBL_MENUDeleteData menudata = new GBL_MENUDeleteData();
            menudata.GBL_MENU = GBL_MENU;
            if (Transaction == null)
                menudata.Delete();
               
        }
    }
}
