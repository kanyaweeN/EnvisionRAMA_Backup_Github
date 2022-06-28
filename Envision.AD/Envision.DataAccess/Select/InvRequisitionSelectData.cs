using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class INVRequisitionSelectData : DataAccessBase
    {
        public INV_REQUISITION INV_REQUISITION { get; set; }
        public INVRequisitionSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Select;
            INV_REQUISITION = new INV_REQUISITION();
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
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_SelectAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectForTranfer()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_SelectForTranfer;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetREQMaster(int REQUISITION_ID, int UNIT_ID)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameterREQMaster(REQUISITION_ID, UNIT_ID);
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Select_REQMaster;
            ds = ExecuteDataSet();
            return ds;
        }
     
        public DataSet GetREQDetail(int REQUISITION_ID, int UNIT_ID)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameterREQDetail(REQUISITION_ID, UNIT_ID);
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Select_REQDetail;
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterREQMaster(int REQUISITION_ID, int UNIT_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@REQUISITION_ID"   ,REQUISITION_ID),
                                          Parameter("@UNIT_ID"   ,UNIT_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterREQDetail(int REQUISITION_ID, int UNIT_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@REQUISITION_ID"   ,REQUISITION_ID),
                                          Parameter("@UNIT_ID"   ,UNIT_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@REQUISITION_ID"   ,INV_REQUISITION.REQUISITION_ID),
                                       };
            return parameters;
        }
    }
}

