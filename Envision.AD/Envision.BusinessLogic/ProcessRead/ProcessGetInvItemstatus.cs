using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ProcessGetInvItemstatus
    {
        DataTable _table;

        public ProcessGetInvItemstatus()
        { 
        }

        public void Invoke()
        {
            InvItemstatusSelectData select = new InvItemstatusSelectData();
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
