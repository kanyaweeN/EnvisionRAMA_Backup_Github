using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLMenu : IBusinessLogic
    {
        public GBL_MENU GBL_MENU { get; set; }

        public ProcessAddGBLMenu()
        {
            GBL_MENU = new GBL_MENU();
        }

        public void Invoke()
        {
            GBLMenuInsertData menudata = new GBLMenuInsertData();
            menudata.GBL_MENU = this.GBL_MENU;
            menudata.Add();

        }
    }
}
