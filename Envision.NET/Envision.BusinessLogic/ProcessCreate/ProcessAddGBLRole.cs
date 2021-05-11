using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLRole : IBusinessLogic
    {
        public GBLRole GBLRole { get; set; }
        public List<GBLRole> _objectsitem { get; set; }

        public ProcessAddGBLRole()
        {
            GBLRole = new GBLRole();
            _objectsitem = new List<GBLRole>();
        }

        public void Invoke()
        {
            foreach (GBLRole item in _objectsitem)
            {
                GBLRoleInsertData menudata = new GBLRoleInsertData();
                menudata.GBLRole = item;
                menudata.Add();
            }

        }
    }
}
