using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetInvItemtype
    {
        DataTable _table;

        public ProcessGetInvItemtype()
        { 
        }

        public void Invoke()
        {
            InvItemtypeSelectData select = new InvItemtypeSelectData();
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
