using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvCategory
    {
        INV_CATEGORY common;

        public ProcessAddInvCategory()
        {
        }

        public void Invoke()
        {
            InvCategoryInsertData insert = new InvCategoryInsertData();
            insert.INV_CATEGORY = this.INV_CATEGORY;
            insert.Insert();
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }
}
