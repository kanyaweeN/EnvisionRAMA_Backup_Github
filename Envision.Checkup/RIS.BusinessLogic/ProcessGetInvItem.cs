using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvItem : IDisposable
    {
        DataTable _table;
        INV_ITEM common;

        public ProcessGetInvItem()
        { 
        }

        public void Invoke()
        {
            InvItemSelectData select = new InvItemSelectData();
            select.INV_ITEM = this.INV_ITEM;
            DataSet ds = select.Query();
            _table = ds.Tables[0];
        }

        public DataTable ResultTable
        {
            get { return _table; }
            set { _table = value; }
        }

        public INV_ITEM INV_ITEM
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
