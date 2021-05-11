using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvUnit
    {
        INV_UNIT common;

        public ProcessDeleteInvUnit()
        {
        }

        public void Invoke()
        {
            InvUnitDeleteData insert = new InvUnitDeleteData();
            insert.INV_UNIT = this.INV_UNIT;
            insert.Delete();
        }

        public INV_UNIT INV_UNIT
        {
            get { return common; }
            set { common = value; }
        }
    }
}
