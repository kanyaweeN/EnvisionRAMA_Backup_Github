using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvSettingsUpdateData : DataAccessBase
    {
        INV_SETTINGS common;

        public InvSettingsUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_SETTINGS_Update.ToString();
        }

        public void Update()
        {
            InvSettingsUpdateData_Parameter param = new InvSettingsUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_SETTINGS INV_SETTINGS
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvSettingsUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_SETTINGS common;

        public InvSettingsUpdateData_Parameter(INV_SETTINGS _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@SETTINGS_ID",common.SETTINGS_ID),
                                new SqlParameter("@SETTINGS_UID",common.SETTINGS_UID),
                                new SqlParameter("@INV_METHOD",common.INV_METHOD),
                                new SqlParameter("@FREE_PROD_PRICING",common.FREE_PROD_PRICING),
                                new SqlParameter("@DISCOUNT_EFFECT",common.DISCOUNT_EFFECT),
                                new SqlParameter("@PO_AUTH_LEVEL",common.PO_AUTH_LEVEL),
                                new SqlParameter("@GENERATE_AUTO_PR",common.GENERATE_AUTO_PR),
                                new SqlParameter("@AUTO_PR_FREQ_DAYS",common.AUTO_PR_FREQ_DAYS),
                                new SqlParameter("@GLOBAL_SELLING_MARKUP",common.GLOBAL_SELLING_MARKUP),
                                new SqlParameter("@ALLOW_NEW_IF_PENDING",common.ALLOW_NEW_IF_PENDING),
                                new SqlParameter("@OVERRIDE_IF_EMERGENCY",common.OVERRIDE_IF_EMERGENCY),
                                new SqlParameter("@SELL_REUSED_WO_RENTRY",common.SELL_REUSED_WO_RENTRY),
                                new SqlParameter("@REORDER_CALC_METHOD",common.REORDER_CALC_METHOD),
                                new SqlParameter("@CENTRAL_STOCK_UNIT",common.CENTRAL_STOCK_UNIT),
                                new SqlParameter("@DEPT_STOCK_UNIT",common.DEPT_STOCK_UNIT),
                                new SqlParameter("@ORG_ID",common.ORG_ID),
                                new SqlParameter("@CREATED_BY",common.CREATED_BY),
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
