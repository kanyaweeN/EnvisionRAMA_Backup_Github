using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetINVItemstock : IBusinessLogic
    {
        public INV_ITEMSTOCK INV_ITEMSTOCK { get; set; }
        private DataSet result;

        public ProcessGetINVItemstock()
        {
            INV_ITEMSTOCK = new INV_ITEMSTOCK();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            INVItemstockSelectData _proc = new INVItemstockSelectData();
            result = _proc.GetData();
        }
        public void InvokeStockMaster(int unitID)
        {
            INVItemstockSelectData _proc = new INVItemstockSelectData();
            result = _proc.GetItemStockMaster(unitID);
        }
        public void InvokeStockDetail(int unitID)
        {
            INVItemstockSelectData _proc = new INVItemstockSelectData();
            result = _proc.GetItemStockDetail(unitID);
        }

    }
}
