using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVPoSelectData : DataAccessBase 
	{
        public INV_PO INV_PO { get; set; }
		public  INVPoSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_PO_Select;
            INV_PO = new INV_PO();
		}
	
		public DataSet GetData()
		{
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet SelectAll()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PO_SelectAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectForRecieve()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PO_SelectForRecieve;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPOMaster(int PO_ID)
        {
            INV_PO.PO_ID = PO_ID;
            ParameterList = buildParameter();
            StoredProcedureName = StoredProcedure.Prc_INV_PO_Select_POMaster;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetPODetail(int PO_ID)
        {
            INV_PO.PO_ID = PO_ID;
            ParameterList = buildParameter();
            StoredProcedureName = StoredProcedure.Prc_INV_PO_Select_PODetail;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
           
            DataTable dt = new DataTable();
            dt = GetPOMaster(PO_ID).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDouble(dt.Rows[i]["ITEMS_RECIEVE_REQ"].ToString()) != 0)
                {
                    if (Convert.ToDouble(dt.Rows[i]["ITEMS_RECIEVE_SUCCESS"].ToString()) != 0)
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        DataRow[] drDetail = ds.Tables[0].Select("ITEM_ID =" + dt.Rows[i]["ITEM_ID"].ToString());

                        dr.ItemArray = drDetail[0].ItemArray;
                        dr["TXNDTL_ID"] = DBNull.Value;
                        dr["ITEM_ID"] = dt.Rows[i]["ITEM_ID"];
                        dr["ITEM_UID"] = dt.Rows[i]["ITEM_UID"];
                        dr["ITEM_NAME"] = dt.Rows[i]["ITEM_NAME"];
                        dr["EXPIRY_DT"] = DBNull.Value;
                        dr["BATCH"] = Convert.ToInt32(dt.Rows[i]["BATCH"].ToString()) + 1;
                        dr["PRICE"] = 0;
                        dr["RECIEVE_SUCCESS"] = dt.Rows[i]["ITEMS_RECIEVE_REQ"];

                        dr["ITEM_RECIEVE_STATUS"] = "Loading";

                        ds.Tables[0].Rows.Add(dr);
                    }
                }
                ds.AcceptChanges();
            }

            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@PO_ID"   ,INV_PO.PO_ID),
                                       };
            return parameters;
        }

	}
}

