using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvItemUpdateData : DataAccessBase
    {
        INV_ITEM common;

        public InvItemUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEM_Update.ToString();
        }

        public void Update()
        {
            InvItemUpdateData_Parameter param = new InvItemUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_ITEM INV_ITEM
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEM common;

        public InvItemUpdateData_Parameter(INV_ITEM _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@ITEM_ID",common.ITEM_ID),
                            new SqlParameter("@ITEM_UID",common.ITEM_UID),
                            new SqlParameter("@ITEM_NAME",common.ITEM_NAME),
                            new SqlParameter("@ITEM_DESC",common.ITEM_DESC),
                            new SqlParameter("@ITEM_IMG",common.ITEM_IMG),
                            new SqlParameter("@CATEGORY_ID",common.CATEGORY_ID),
                            new SqlParameter("@TYPE_ID",common.TYPE_ID),
                            new SqlParameter("@TXN_UNIT",common.TXN_UNIT),
                            new SqlParameter("@RE_ORDER_DAYS",common.RE_ORDER_DAYS),
                            new SqlParameter("@RE_ORDER_QTY",common.RE_ORDER_QTY),
                            new SqlParameter("@IS_FOREIGN",common.IS_FOREIGN),
                            new SqlParameter("@INCLUDE_IN_AUTO_PR",common.INCLUDE_IN_AUTO_PR),
                            new SqlParameter("@GL_CODE",common.GL_CODE),
                            new SqlParameter("@IS_FA",common.IS_FA),
                            new SqlParameter("@IS_REUSABLE",common.IS_REUSABLE),
                            new SqlParameter("@REUSE_PRICE_PERC",common.REUSE_PRICE_PERC),
                            new SqlParameter("@VENDOR_ID",common.VENDOR_ID),
                            new SqlParameter("@PURCHASE_PRICE",common.PURCHASE_PRICE),
                            new SqlParameter("@SELLING_PRICE",common.SELLING_PRICE),
                            new SqlParameter("@ALLOW_PARTIAL_DELIVERY",common.ALLOW_PARTIAL_DELIVERY),
                            new SqlParameter("@ALLOW_PARTIAL_RECIEVE",common.ALLOW_PARTIAL_RECIEVE),
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
