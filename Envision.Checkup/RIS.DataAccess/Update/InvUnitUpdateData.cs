using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvUnitUpdateData : DataAccessBase
    {
        INV_UNIT common;

        public InvUnitUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_UNIT_Update.ToString();
        }

        public void Update()
        {
            InvUnitUpdateData_Parameter param = new InvUnitUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_UNIT INV_UNIT
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvUnitUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_UNIT common;

        public InvUnitUpdateData_Parameter(INV_UNIT _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@UNIT_ID",common.UNIT_ID),
                                new SqlParameter("@UNIT_UID",common.UNIT_UID),
                                new SqlParameter("@UNIT_NAME",common.UNIT_NAME),
                                new SqlParameter("@UNIT_DESC",common.UNIT_DESC),
                                new SqlParameter("@EXTERNAL_UNIT",common.EXTERNAL_UNIT),
                                new SqlParameter("@ORG_ID",common.ORG_ID),
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
