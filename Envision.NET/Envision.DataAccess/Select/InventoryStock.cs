using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class InventoryStock : DataAccessBase
    {
        private SqlParameter[] Parameters;
        private INV_TRANSACTION _invtransaction;
        private DataTable dt;
        public InventoryStock()
		{
			
		}
        public DataSet GetREQMaster(int REQUISITION_ID,int UNIT_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_REQMaster;
            DbParameter[] parameters = {			
                Parameter("@REQUISITION_ID",REQUISITION_ID)
                ,Parameter("@UNIT_ID",UNIT_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetREQDetail(int REQUISITION_ID, int UNIT_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_REQDetail;
            DbParameter[] parameters = {			
                Parameter("@REQUISITION_ID",REQUISITION_ID)
                ,Parameter("@UNIT_ID",UNIT_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPOMaster(int PO_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_POMaster;
            DbParameter[] parameters = {			
                Parameter("@PO_ID",PO_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();

            dt = new DataTable();
            dt = ds.Tables[0];
            //ITEMS_RECIEVE_SUCCESS
            return ds;
        }
        public DataSet GetPODetail(int PO_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_PODetail;
            DbParameter[] parameters = {			
                Parameter("@PO_ID",PO_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDouble(dt.Rows[i]["ITEMS_RECIEVE_SUCCESS"].ToString()) != 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["PO_ID"] = dt.Rows[i]["PO_ID"];
                    dr["PO_UID"] = dt.Rows[i]["PO_UID"];
                    dr["VENDOR_ID"] = dt.Rows[i]["VENDOR_ID"];
                    dr["TOC"] = dt.Rows[i]["TOC"];
                    dr["PO_STATUS"] = dt.Rows[i]["PO_STATUS"];
                    dr["ITEM_ID"] = dt.Rows[i]["ITEM_ID"];
                    dr["ITEM_NAME"] = dt.Rows[i]["ITEM_NAME"];
                    dr["ITEM_DESC"] = dt.Rows[i]["ITEM_DESC"];
                    dr["QTY"] = dt.Rows[i]["QTY"];
                    dr["ITEMS_RECIEVE"] = dt.Rows[i]["ITEMS_RECIEVE_REQ"];

                    dr["ITEM_RECIEVE_STATUS"] = "Loading";

                    ds.Tables[0].Rows.Add(dr);
                }
            }
            return ds;
        }
        public DataSet GetItemStockMaster(int UNIT_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_StockMaster;
            DbParameter[] parameters = {			
                Parameter("@UNIT_ID",UNIT_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetItemStockDetail(int UNIT_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_StockDetail;
            DbParameter[] parameters = {			
                Parameter("@UNIT_ID",UNIT_ID)
			};
            ParameterList = parameters;
            DataSet ds = ExecuteDataSet();
            return ds;
        }
    }
}
