using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvTransactionTypeDeleteData : DataAccessBase
    {
        INV_TRANSACTIONTYPE common;

        public InvTransactionTypeDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_TRANSACTIONTYPE_Delete.ToString();
        }

        public void Delete()
        {
            InvTransactionTypeDeleteData_Parameter param = new InvTransactionTypeDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvTransactionTypeDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_TRANSACTIONTYPE common;

        public InvTransactionTypeDeleteData_Parameter(INV_TRANSACTIONTYPE _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@TRANSACTIONTYPE_ID",common.TRANSACTIONTYPE_ID),
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
