using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvSettingsUpdateData : DataAccessBase
    {
        public INV_SETTING INV_SETTING { get; set; }

        public InvSettingsUpdateData()
        {
            INV_SETTING = new INV_SETTING();
            this.StoredProcedureName = StoredProcedure.Prc_INV_SETTINGS_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@SETTINGS_ID",INV_SETTING.SETTINGS_ID),
                                Parameter("@SETTINGS_UID",INV_SETTING.SETTINGS_UID),
                                Parameter("@INV_METHOD",INV_SETTING.INV_METHOD),
                                Parameter("@FREE_PROD_PRICING",INV_SETTING.FREE_PROD_PRICING),
                                Parameter("@DISCOUNT_EFFECT",INV_SETTING.DISCOUNT_EFFECT),
                                Parameter("@PO_AUTH_LEVEL",INV_SETTING.PO_AUTH_LEVEL),
                                Parameter("@GENERATE_AUTO_PR",INV_SETTING.GENERATE_AUTO_PR),
                                Parameter("@AUTO_PR_FREQ_DAYS",INV_SETTING.AUTO_PR_FREQ_DAYS),
                                Parameter("@GLOBAL_SELLING_MARKUP",INV_SETTING.GLOBAL_SELLING_MARKUP),
                                Parameter("@ALLOW_NEW_IF_PENDING",INV_SETTING.ALLOW_NEW_IF_PENDING),
                                Parameter("@OVERRIDE_IF_EMERGENCY",INV_SETTING.OVERRIDE_IF_EMERGENCY),
                                Parameter("@SELL_REUSED_WO_RENTRY",INV_SETTING.SELL_REUSED_WO_RENTRY),
                                Parameter("@REORDER_CALC_METHOD",INV_SETTING.REORDER_CALC_METHOD),
                                Parameter("@CENTRAL_STOCK_UNIT",INV_SETTING.CENTRAL_STOCK_UNIT),
                                Parameter("@DEPT_STOCK_UNIT",INV_SETTING.DEPT_STOCK_UNIT),
                                Parameter("@ORG_ID",INV_SETTING.ORG_ID),
                                Parameter("@CREATED_BY",INV_SETTING.CREATED_BY),
                                      };
            return parameters;
        }
    }
}
