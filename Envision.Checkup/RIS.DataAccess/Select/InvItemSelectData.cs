using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class InvItemSelectData : DataAccessBase
    {
        INV_ITEM common;

        public InvItemSelectData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEM_Select.ToString();
        }

        public DataSet Query()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            DataSet ds = dbhelper.Run(this.ConnectionString);
            return ds;
        }

        public INV_ITEM INV_ITEM
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class INV_ITEM_SelectData_Parameter
    {
        SqlParameter[] sqlparam;

        public INV_ITEM_SelectData_Parameter()
        {

            Build();
        }

        public void Build()
        {

        }

        public SqlParameter[] SqlParameter
        {
            get { return sqlparam; }
            set { sqlparam = value; }
        }

    }
}
