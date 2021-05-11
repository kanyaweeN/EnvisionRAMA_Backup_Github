using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvUnit
    {
        INV_UNIT common;

        public ProcessAddInvUnit()
        {
        }

        public void Invoke()
        {
            InvUnitInsertData insert = new InvUnitInsertData();
            insert.INV_UNIT = this.INV_UNIT;
            insert.Insert();
        }

        public INV_UNIT INV_UNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
