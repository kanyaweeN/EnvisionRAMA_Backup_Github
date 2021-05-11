using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;

using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessCreate;
namespace Envision.BusinessLogic
{
    public class InventoryRequest
    {
        private DataTable dt;
        private ProcessAddINVTransaction InsertTran;
        private INV_TRANSACTION	_invtransaction;
        public INV_TRANSACTION INVTransaction
		{
			get{return _invtransaction;}
			set{_invtransaction=value;}
		}
     
        public InventoryRequest()
        {
           // myArray = new List<INVTransactiondtl>();
            dt = new DataTable();
            dt.Columns.Add("TXNDTL_ID");
            dt.Columns.Add("TXN_ID");
            dt.Columns.Add("ITEM_ID");
            dt.Columns.Add("TXN_UNIT");
            dt.Columns.Add("BATCH");
            dt.Columns.Add("EXPIRY_DT");
            dt.Columns.Add("QTY");
            dt.Columns.Add("PRICE");
            dt.Columns.Add("COMMENTS");
            dt.Columns.Add("ORG_ID");
            dt.Columns.Add("ITEMSTOCK_ID");
        }
        public bool InsertTransaction()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    InsertTran = new ProcessAddINVTransaction();
                    InsertTran.INV_TRANSACTION = new INV_TRANSACTION();
                    InsertTran.INV_TRANSACTION = _invtransaction;
                    InsertTran.INV_TRANSACTION.Doc = "/" + ds.DataSetName + "/" + ds.Tables[0].TableName;
                    InsertTran.INV_TRANSACTION.xmlDoc = ds.GetXml();
                    InsertTran.Invoke();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        public void AddTransactionDtl(int ITEM_ID, int TXN_UNIT, string BATCH, DateTime EXPIRY_DT, double QTY, double PRICE, int ITEMSTOCK)
        {
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = 0;
            dr[2] = ITEM_ID;
            dr[3] = TXN_UNIT;
            dr[4] = BATCH;
            dr[5] = EXPIRY_DT.Year.ToString() + EXPIRY_DT.ToString("-M-dd");
            dr[6] = QTY;
            dr[7] = PRICE;
            dr[8] = _invtransaction.COMMENTS;
            dr[9] = _invtransaction.ORG_ID;
            dr[10] = ITEMSTOCK;
            dt.Rows.Add(dr);
        }
    }
}
