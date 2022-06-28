using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvCategory
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }
        public ProcessAddInvCategory()
        {
            INV_CATEGORY = new INV_CATEGORY();
        }

        public void Invoke()
        {
            InvCategoryInsertData insert = new InvCategoryInsertData();
            insert.INV_CATEGORY = this.INV_CATEGORY;
            insert.Insert();
        }
    }
}
