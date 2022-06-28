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
    public class ProcessGetInvItem : IDisposable
    {
        public INV_ITEM INV_ITEM { get; set; }
        DataTable _table;

        public ProcessGetInvItem()
        {
            INV_ITEM = new INV_ITEM();
        }

        public void Invoke()
        {
            InvItemSelectData select = new InvItemSelectData();
            //select.INV_ITEM = this.INV_ITEM;
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
