using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvRoomStockReduce : IDisposable
    {
        DataTable _table;

        public ProcessGetInvRoomStockReduce()
        { 
        }

        public void Invoke()
        {
            InvRoomStockReduceSelectData select = new InvRoomStockReduceSelectData();
            DataSet ds = select.Query();
            _table = ds.Tables[0];
        }

        public DataTable ResultTable
        {
            get { return _table; }
            set { _table = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
