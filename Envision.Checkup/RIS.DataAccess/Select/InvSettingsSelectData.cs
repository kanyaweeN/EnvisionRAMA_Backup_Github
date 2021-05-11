using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class InvSettingsSelectData : DataAccessBase
    {
        INV_SETTINGS common;

        public InvSettingsSelectData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_SETTINGS_Select.ToString();
        }

        public DataSet Query()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            DataSet ds = dbhelper.Run(this.ConnectionString);
            return ds;
        }

        public INV_SETTINGS INV_SETTINGS
        {
            get { return common; }
            set { common = value; }
        }
    }
}
