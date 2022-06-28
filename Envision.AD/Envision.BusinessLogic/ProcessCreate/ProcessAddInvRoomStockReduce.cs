using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{ 
    public class ProcessAddInvRoomStockReduce : IDisposable
    {
        public INV_ROOMSTOCKREDUCE INV_ROOMSTOCKREDUCE { get; set; }

        public ProcessAddInvRoomStockReduce()
        {
            INV_ROOMSTOCKREDUCE = new INV_ROOMSTOCKREDUCE();
        }

        public void Invoke()
        {
            InvRoomStockReduceInsertData insert = new InvRoomStockReduceInsertData();
            insert.INV_ROOMSTOCKREDUCE = this.INV_ROOMSTOCKREDUCE;
            insert.Insert();
        }


        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
