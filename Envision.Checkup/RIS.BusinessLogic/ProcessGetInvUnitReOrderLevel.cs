using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvUnitReOrderLevel : IDisposable
    {
        DataTable _table;
        INV_UNITREORDERLEVEL common;

        public ProcessGetInvUnitReOrderLevel()
        { 
        }

        public void Invoke()
        {
            InvUnitReOrderLevelSelectData select = new InvUnitReOrderLevelSelectData();
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
