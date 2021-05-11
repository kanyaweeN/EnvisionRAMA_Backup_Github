using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvCategory
    {
        INV_CATEGORY common;

        public ProcessUpdateInvCategory()
        {
        }

        public void Invoke()
        {
            InvCategoryUpdateData insert = new InvCategoryUpdateData();
            insert.INV_CATEGORY = this.INV_CATEGORY;
            insert.Update();
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }
}
