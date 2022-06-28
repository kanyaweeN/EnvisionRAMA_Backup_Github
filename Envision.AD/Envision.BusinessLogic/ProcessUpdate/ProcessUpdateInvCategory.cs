using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvCategory
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }

        public ProcessUpdateInvCategory()
        {
            INV_CATEGORY = new INV_CATEGORY();
        }

        public void Invoke()
        {
            InvCategoryUpdateData insert = new InvCategoryUpdateData();
            insert.INV_CATEGORY = this.INV_CATEGORY;
            insert.Update();
        }
    }
}
