using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvSettingsDeleteData : DataAccessBase
    {
        INV_SETTINGS common;

        public InvSettingsDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_SETTINGS_Delete.ToString();
        }

        public void Delete()
        {
            InvSettingsDeleteData_Parameter param = new InvSettingsDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_SETTINGS INV_SETTINGS
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvSettingsDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_SETTINGS common;

        public InvSettingsDeleteData_Parameter(INV_SETTINGS _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@SETTINGS_ID",common.SETTINGS_ID),
                        };
            sqlparam = SqlParameter;
        }

        public SqlParameter[] SqlParameter
        {
            get { return sqlparam; }
            set { sqlparam = value; }
        }

    }
}
