using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class INVItemstockSelectData : DataAccessBase 
    {
        private INV_ITEMSTOCK INV_ITEMSTOCK { get; set; }
        public INVItemstockSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            return ds;
        }
        public DataSet GetItemStockMaster(int UNIT_ID)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameterStockMaster(UNIT_ID);
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_StockMaster;
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterStockMaster(int UNIT_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID",UNIT_ID),
                                       };
            return parameters;
        }
        public DataSet GetItemStockDetail(int UNIT_ID)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameterStockDetail(UNIT_ID);
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTOCK_Select_StockDetail;
            ds = ExecuteDataSet();
            return ds;
         }
        private DbParameter[] buildParameterStockDetail(int UNIT_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID",UNIT_ID),
                                       };
            return parameters;
        }
    }

}
