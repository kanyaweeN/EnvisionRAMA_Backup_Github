using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSplitOrder : IBusinessLogic
    {
        public SplitOrder SplitOrder { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddSplitOrder()
        {
            SplitOrder = new SplitOrder();
        }

        public void Invoke()
        {
            SplitOrderInsertData splitdata = new SplitOrderInsertData();
            splitdata.SplitOrder = this.SplitOrder;
            splitdata.Add();
        }
    }
}
