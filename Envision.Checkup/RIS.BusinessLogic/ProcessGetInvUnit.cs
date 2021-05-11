using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvUnit
    {
        DataTable _table;

        public ProcessGetInvUnit()
        { 
        }

        public void Invoke()
        {
            InvUnitSelectData select = new InvUnitSelectData();
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
