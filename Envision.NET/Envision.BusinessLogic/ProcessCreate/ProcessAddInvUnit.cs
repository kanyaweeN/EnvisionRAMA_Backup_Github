using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvUnit
    {
        public INV_UNIT INV_UNIT { get; set; }

        public ProcessAddInvUnit()
        {
            INV_UNIT = new INV_UNIT();
        }

        public void Invoke()
        {
            InvUnitInsertData insert = new InvUnitInsertData();
            insert.INV_UNIT = this.INV_UNIT;
            insert.Insert();
        }
    }
}
