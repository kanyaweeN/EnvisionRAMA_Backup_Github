using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{ 
    public class ProcessAddInvRoomStockReduce : IDisposable
    {
        INV_ROOMSTOCKREDUCE common;

        public ProcessAddInvRoomStockReduce()
        { 
        }

        public void Invoke()
        {
            InvRoomStockReduceInsertData insert = new InvRoomStockReduceInsertData();
            insert.INV_ROOMSTOCKREDUCE = this.INV_ROOMSTOCKREDUCE;
            insert.Insert();
        }

        public INV_ROOMSTOCKREDUCE INV_ROOMSTOCKREDUCE
        {
            get { return common; }
            set { common = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
