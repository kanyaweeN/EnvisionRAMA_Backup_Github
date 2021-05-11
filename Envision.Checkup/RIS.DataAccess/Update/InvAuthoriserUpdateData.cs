using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvAuthoriserUpdateData : DataAccessBase
    {
        INV_AUTHORISER common;

        public InvAuthoriserUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_AUTHORISER_Update.ToString();
        }

        public void Update()
        {
            InvAuthoriserUpdateData_Parameter param = new InvAuthoriserUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_AUTHORISER INV_AUTHORISER
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvAuthoriserUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_AUTHORISER common;

        public InvAuthoriserUpdateData_Parameter(INV_AUTHORISER _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@AUTHORISER_ID",common.AUTHORISER_ID),
                                new SqlParameter("@EMP_ID",common.EMP_ID),
                                new SqlParameter("@SERIAL",common.SERIAL),
                                new SqlParameter("@AUTH_TYPE",common.AUTH_TYPE),
                                new SqlParameter("@ORG_ID",common.ORG_ID),
                                new SqlParameter("@LAST_MODIFIED_BY",common.LAST_MODIFIED_BY),
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
