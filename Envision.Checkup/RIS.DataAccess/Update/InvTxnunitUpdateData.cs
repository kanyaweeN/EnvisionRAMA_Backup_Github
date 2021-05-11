using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvTxnunitUpdateData : DataAccessBase
    {
        INV_TXNUNIT common;

        public InvTxnunitUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_TXNUNIT_Update.ToString();
        }

        public void Update()
        {
            InvTxnunitUpdateData_Parameter param = new InvTxnunitUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_TXNUNIT INV_TXNUNIT
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvTxnunitUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_TXNUNIT common;

        public InvTxnunitUpdateData_Parameter(INV_TXNUNIT _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                            new SqlParameter("@TXN_UNIT_ID",common.TXN_UNIT_ID),
                            new SqlParameter("@TXN_UNIT_UID",common.TXN_UNIT_UID),
                            new SqlParameter("@TXN_UNIT_NAME",common.TXN_UNIT_NAME),
                            new SqlParameter("@TXN_UNIT_DESC",common.TXN_UNIT_DESC),
                            //new SqlParameter("@EXTERNAL_UNIT",common.EXTERNAL_UNIT),
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
