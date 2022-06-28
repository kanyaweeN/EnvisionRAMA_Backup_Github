using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvItemInsertData : DataAccessBase
    {
        public INV_ITEM INV_ITEM { get; set; }

        public InvItemInsertData()
        {
            INV_ITEM = new INV_ITEM();
            this.StoredProcedureName = StoredProcedure.Prc_INV_ITEM_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            try
            {
                ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                            Parameter("@ITEM_UID",INV_ITEM.ITEM_UID),
                            Parameter("@ITEM_NAME",INV_ITEM.ITEM_NAME),
                            Parameter("@ITEM_DESC",INV_ITEM.ITEM_DESC),
                            //Parameter("@ITEM_IMG",INV_ITEM.ITEM_IMG),
                            Parameter("@CATEGORY_ID",INV_ITEM.CATEGORY_ID),
                            Parameter("@TYPE_ID",INV_ITEM.TYPE_ID),
                            Parameter("@TXN_UNIT",INV_ITEM.TXN_UNIT),
                            Parameter("@RE_ORDER_DAYS",INV_ITEM.RE_ORDER_DAYS),
                            Parameter("@RE_ORDER_QTY",INV_ITEM.RE_ORDER_QTY),
                            Parameter("@IS_FOREIGN",INV_ITEM.IS_FOREIGN),
                            Parameter("@INCLUDE_IN_AUTO_PR",INV_ITEM.INCLUDE_IN_AUTO_PR),
                            Parameter("@GL_CODE",INV_ITEM.GL_CODE),
                            Parameter("@IS_FA",INV_ITEM.IS_FA),
                            Parameter("@IS_REUSABLE",INV_ITEM.IS_REUSABLE),
                            Parameter("@REUSE_PRICE_PERC",INV_ITEM.REUSE_PRICE_PERC),
                            Parameter("@VENDOR_ID",INV_ITEM.VENDOR_ID),
                            Parameter("@PURCHASE_PRICE",INV_ITEM.PURCHASE_PRICE),
                            Parameter("@SELLING_PRICE",INV_ITEM.SELLING_PRICE),
                            Parameter("@ALLOW_PARTIAL_DELIVERY",INV_ITEM.ALLOW_PARTIAL_DELIVERY),
                            Parameter("@ALLOW_PARTIAL_RECIEVE",INV_ITEM.ALLOW_PARTIAL_RECIEVE),
                            Parameter("@ORG_ID",INV_ITEM.ORG_ID),
            };
            return parameters;
        }
    }
}
