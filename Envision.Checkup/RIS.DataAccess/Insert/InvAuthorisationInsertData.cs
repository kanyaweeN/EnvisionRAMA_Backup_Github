using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvAuthorisationInsertData : DataAccessBase
    {
        INV_AUTHORISATION common;

        public InvAuthorisationInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_AUTHORISATION_Insert.ToString();
        }

        public void Insert()
        {
            InvAuthorisationInsertData_Parameter param = new InvAuthorisationInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_AUTHORISATION INV_AUTHORISATION
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvAuthorisationInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_AUTHORISATION common;

        public InvAuthorisationInsertData_Parameter(INV_AUTHORISATION _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                //new SqlParameter("@AUTH_ID",common.UNIT_ID),
                                new SqlParameter("@AUTH_DT",common.AUTH_DT),
                                new SqlParameter("@REQUISITION_ID",common.REQUISITION_ID),
                                new SqlParameter("@ITEM_ID",common.ITEM_ID),
                                new SqlParameter("@EMP_ID",common.EMP_ID),
                                new SqlParameter("@QTY",common.QTY),
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
