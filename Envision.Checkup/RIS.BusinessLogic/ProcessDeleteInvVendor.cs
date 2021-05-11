using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteInvVendor
    {
        INV_VENDOR common;

        public ProcessDeleteInvVendor()
        {
        }

        public void Invoke()
        {
            InvVendorDeleteData insert = new InvVendorDeleteData();
            insert.INV_VENDOR = this.INV_VENDOR;
            insert.Delete();
        }

        public INV_VENDOR INV_VENDOR
        {
            get { return common; }
            set { common = value; }
        }
    }
}
