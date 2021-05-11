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
    public class ProcessGetInvUnitReOrderLevel : IDisposable
    {
        public INV_UNITREORDERLEVEL INV_UNITREORDERLEVEL { get; set; }
        DataTable _table;

        public ProcessGetInvUnitReOrderLevel()
        {
            INV_UNITREORDERLEVEL = new INV_UNITREORDERLEVEL();
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
