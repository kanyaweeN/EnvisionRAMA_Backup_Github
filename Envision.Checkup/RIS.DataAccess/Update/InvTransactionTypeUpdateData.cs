using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvTransactionTypeUpdateData : DataAccessBase
    {
        INV_TRANSACTIONTYPE common;

        public InvTransactionTypeUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_TRANSACTIONTYPE_Update.ToString();
        }

        public void Update()
        {
            InvTransactionTypeUpdateData_Parameter param = new InvTransactionTypeUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvTransactionTypeUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_TRANSACTIONTYPE common;

        public InvTransactionTypeUpdateData_Parameter(INV_TRANSACTIONTYPE _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                            new SqlParameter("@TRANSACTIONTYPE_ID",common.TRANSACTIONTYPE_ID),
                            new SqlParameter("@TRANSACTIONTYPE_UID",common.TRANSACTIONTYPE_UID),
                            new SqlParameter("@TRANSACTIONTYPE_NAME",common.TRANSACTIONTYPE_NAME),
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
