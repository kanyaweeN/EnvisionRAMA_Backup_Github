using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvTxnunitDeleteData : DataAccessBase
    {
        INV_TXNUNIT common;

        public InvTxnunitDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_TXNUNIT_Delete.ToString();
        }

        public void Delete()
        {
            InvTxnunitDeleteData_Parameter param = new InvTxnunitDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_TXNUNIT INV_TXNUNIT
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvTxnunitDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_TXNUNIT common;

        public InvTxnunitDeleteData_Parameter(INV_TXNUNIT _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@TXN_UNIT_ID",common.TXN_UNIT_ID),
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
