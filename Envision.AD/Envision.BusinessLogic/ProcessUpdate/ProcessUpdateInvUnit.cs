using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvUnit
    {
        public INV_UNIT INV_UNIT { get; set; }

        public ProcessUpdateInvUnit()
        {
            INV_UNIT = new INV_UNIT();
        }

        public void Invoke()
        {
            InvUnitUpdateData insert = new InvUnitUpdateData();
            insert.INV_UNIT = this.INV_UNIT;
            insert.Update();
        }
    }
}
