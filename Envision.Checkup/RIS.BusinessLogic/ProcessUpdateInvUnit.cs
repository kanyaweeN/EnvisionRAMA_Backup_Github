using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvUnit
    {
        INV_UNIT common;

        public ProcessUpdateInvUnit()
        {
        }

        public void Invoke()
        {
            InvUnitUpdateData insert = new InvUnitUpdateData();
            insert.INV_UNIT = this.INV_UNIT;
            insert.Update();
        }

        public INV_UNIT INV_UNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
