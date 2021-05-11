using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateInvVendor
    {
        INV_VENDOR common;

        public ProcessUpdateInvVendor()
        {
        }

        public void Invoke()
        {
            InvVendorUpdateData insert = new InvVendorUpdateData();
            insert.INV_VENDOR = this.INV_VENDOR;
            insert.Update();
        }

        public INV_VENDOR INV_VENDOR
        {
            get { return common; }
            set { common = value; }
        }
    }
}
