//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 03:33:48
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class INVTransactionInsertData : DataAccessBase 
	{
        public INV_TRANSACTION INV_TRANSACTION { get; set; }
		public  INVTransactionInsertData()
		{
            INV_TRANSACTION = new INV_TRANSACTION();
			StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTION_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            INV_TRANSACTION.TXN_ID = (int)ParameterList[0].Value;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter _TXN_ID = Parameter("@TXN_ID", INV_TRANSACTION.TXN_ID);
            _TXN_ID.Direction = ParameterDirection.Output;

            DbParameter _REQUISITION_ID = Parameter();
            _REQUISITION_ID.ParameterName = "@REQUISITION_ID";
            if (INV_TRANSACTION.REQUISITION_ID == 0)
                _REQUISITION_ID.Value = DBNull.Value;
            else
                _REQUISITION_ID.Value = INV_TRANSACTION.REQUISITION_ID;

            DbParameter _PO_ID = Parameter();
            _PO_ID.ParameterName = "@PO_ID";
            if (INV_TRANSACTION.PO_ID == 0)
                _PO_ID.Value = DBNull.Value;
            else
                _PO_ID.Value = INV_TRANSACTION.PO_ID;

            DbParameter _FROM_UNIT = Parameter();
            _FROM_UNIT.ParameterName = "@FROM_UNIT";
            if (INV_TRANSACTION.FROM_UNIT == 0)
                _FROM_UNIT.Value = DBNull.Value;
            else
                _FROM_UNIT.Value = INV_TRANSACTION.FROM_UNIT;

            DbParameter _TO_UNIT = Parameter();
            _TO_UNIT.ParameterName = "@TO_UNIT";
            if (INV_TRANSACTION.TO_UNIT == 0)
                _TO_UNIT.Value = DBNull.Value;
            else
                _TO_UNIT.Value = INV_TRANSACTION.TO_UNIT;

            DbParameter[] parameters ={	
            _TXN_ID		
            ,Parameter("@TXN_TYPE",INV_TRANSACTION.TXN_TYPE)
            ,_REQUISITION_ID
            ,_PO_ID
            ,_FROM_UNIT
            ,_TO_UNIT
            ,Parameter("@COMMENTS",INV_TRANSACTION.COMMENTS)
            ,Parameter("@ORG_ID",INV_TRANSACTION.ORG_ID)
            ,Parameter("@CREATED_BY",INV_TRANSACTION.CREATED_BY)
            ,Parameter("@LAST_MODIFIED_BY",INV_TRANSACTION.LAST_MODIFIED_BY)
            ,Parameter("@Status",INV_TRANSACTION.STATUS.ToString())
			};
            return parameters;
        }
        private DbParameter[] buildParameterPOCancel(int PO_ID, int CreatedBy)
        {
            DbParameter[] parameters ={	Parameter("@PO_ID",PO_ID),
                                          Parameter("@CREATED_BY",CreatedBy)

                                    };
            return parameters;
        }
        public bool AddPOCancel(int PO_ID, int CreatedBy)
        {
            try
            {
                ParameterList = buildParameterPOCancel(PO_ID,CreatedBy);
                StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTION_CancelPOInsert;
                ExecuteNonQuery();
                return true;
            }
            catch { return false; }
       }
        private DbParameter[] buildParameterRQCancel(int REQUISITION_ID, int CreatedBy)
        {
            DbParameter[] parameters ={	Parameter("@REQUISITION_ID",REQUISITION_ID),
                                          Parameter("@CREATED_BY",CreatedBy)

                                    };
            return parameters;
        }
        public bool AddRQCancel(int REQUISITION_ID, int CreatedBy)
        {
            try
            {
                ParameterList = buildParameterRQCancel(REQUISITION_ID, CreatedBy);
                StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTION_CancelRQInsert;
                ExecuteNonQuery();
                return true;
            }
            catch { return false; }
        }
	}
}

