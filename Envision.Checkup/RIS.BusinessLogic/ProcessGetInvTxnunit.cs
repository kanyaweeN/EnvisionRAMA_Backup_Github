using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvTxnunit
    {
        DataTable _table;

        public ProcessGetInvTxnunit()
        { 
        }

        public void Invoke()
        {
            InvTxnunitSelectData select = new InvTxnunitSelectData();
            DataSet ds = select.Query();
            _table = ds.Tables[0];
        }

        public DataTable ResultTable
        {
            get { return _table; }
            set { _table = value; }
        }
    }
}
