using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateInvVendor
    {
        public INV_VENDOR INV_VENDOR { get; set; }

        public ProcessUpdateInvVendor()
        {
            INV_VENDOR = new INV_VENDOR();
        }

        public void Invoke()
        {
            InvVendorUpdateData insert = new InvVendorUpdateData();
            insert.INV_VENDOR = this.INV_VENDOR;
            insert.Update();
        }
    }
}
