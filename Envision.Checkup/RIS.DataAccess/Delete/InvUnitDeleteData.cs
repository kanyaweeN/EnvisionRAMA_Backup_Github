using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvUnitDeleteData : DataAccessBase
    {
        INV_UNIT common;

        public InvUnitDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_UNIT_Delete.ToString();
        }

        public void Delete()
        {
            InvUnitDeleteData_Parameter param = new InvUnitDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_UNIT INV_UNIT
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvUnitDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_UNIT common;

        public InvUnitDeleteData_Parameter(INV_UNIT _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@UNIT_ID",common.UNIT_ID),
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
