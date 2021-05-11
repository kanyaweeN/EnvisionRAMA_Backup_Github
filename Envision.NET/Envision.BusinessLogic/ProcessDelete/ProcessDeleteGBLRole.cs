using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLRole : IBusinessLogic
    {
        public GBL_ROLE GBL_ROLE { get; set; }
        public List<string> DeleteItem { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLRole()
        {
            GBL_ROLE = new GBL_ROLE();
            DeleteItem = new List<string>();
        }

        public void Invoke()
        {
            foreach (string item in DeleteItem)
            {
                GBL_ROLEDeleteData menudata = new GBL_ROLEDeleteData();
                menudata.ObjectId = item;
                menudata.Delete();
            }
            
        }
    }
}
