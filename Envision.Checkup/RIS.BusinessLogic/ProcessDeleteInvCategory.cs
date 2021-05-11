using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvCategory
    {
        INV_CATEGORY common;

        public ProcessDeleteInvCategory()
        {
        }

        public void Invoke()
        {
            InvCategoryDeleteData insert = new InvCategoryDeleteData();
            insert.INV_CATEGORY = this.INV_CATEGORY;
            insert.Delete();
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }
}
