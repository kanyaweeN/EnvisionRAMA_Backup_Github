using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvAuthoriserDeleteData : DataAccessBase
    {
        INV_AUTHORISER common;

        public InvAuthoriserDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_AUTHORISER_Delete.ToString();
        }

        public void Delete()
        {
            InvAuthoriserDeleteData_Parameter param = new InvAuthoriserDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_AUTHORISER INV_AUTHORISER
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvAuthoriserDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_AUTHORISER common;

        public InvAuthoriserDeleteData_Parameter(INV_AUTHORISER _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@AUTHORISER_ID",common.AUTHORISER_ID),
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
