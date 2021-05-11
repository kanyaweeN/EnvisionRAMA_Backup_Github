using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class InvItemtypeSelectData : DataAccessBase
    {
        public InvItemtypeSelectData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEMTYPE_Select.ToString();
        }

        public DataSet Query()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            DataSet ds = dbhelper.Run(this.ConnectionString);
            return ds;
        }
    }
}
