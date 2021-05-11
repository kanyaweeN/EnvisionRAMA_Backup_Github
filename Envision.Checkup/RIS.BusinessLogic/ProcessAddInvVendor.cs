using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddInvVendor
    {
        INV_VENDOR common;

        public ProcessAddInvVendor()
        {
        }

        public void Invoke()
        {
            InvVendorInsertData insert = new InvVendorInsertData();
            insert.INV_VENDOR = this.INV_VENDOR;
            insert.Insert();
        }

        public INV_VENDOR INV_VENDOR
        {
            get { return common; }
            set { common = value; }
        }
    }
}
