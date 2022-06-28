using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvVendor
    {
        public INV_VENDOR INV_VENDOR { get; set; }

        public ProcessAddInvVendor()
        {
            INV_VENDOR = new INV_VENDOR();
        }

        public void Invoke()
        {
            InvVendorInsertData insert = new InvVendorInsertData();
            insert.INV_VENDOR = this.INV_VENDOR;
            insert.Insert();
        }

    }
}
