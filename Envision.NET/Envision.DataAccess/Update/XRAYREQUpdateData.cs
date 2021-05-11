using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class XRAYREQUpdateData : DataAccessBase
    {
        public XRAYREQ XRAYREQ { get; set; }

        public XRAYREQUpdateData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_XREGIST_Status;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@REG_ID",XRAYREQ.ORDER_ID)
                                      };
            return parameters;
        }

        public void updateCancel(int order_id)
        {
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_UpdateCancel;
            ParameterList = buildParameterUpdateCancel(order_id);
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateCancel(int order_id)
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID",order_id)
                                      };
            return parameters;
        }
        public void updateDeleteWithModality(int order_id, int modality_id)
        {
            StoredProcedureName = StoredProcedure.Prc_XRAYREQDTL_UpdateDelete;
            ParameterList = buildParameterUpdateDelete(order_id,modality_id);
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateDelete(int order_id, int modality_id)
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID",order_id),
                Parameter("@MODALITY_ID",modality_id)
                                      };
            return parameters;
        }

        public void updateMergeRequest(int order_id, string clinical_instruction, string ref_doc_instruction, string reason)
        {
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_UpdateMergeRequest;
            ParameterList = buildParameterUpdateDelete(order_id, clinical_instruction, ref_doc_instruction, reason);
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateDelete(int order_id, string clinical_instruction, string ref_doc_instruction, string reason)
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID",order_id),
                Parameter("@CLINICAL_INSTRUCTION",clinical_instruction),
                Parameter("@REF_DOC_INSTRUCTION",ref_doc_instruction),
                Parameter("@REASON",reason),
                                      };
            return parameters;
        }

        public void updateLockCase(int order_id,string is_busy,int busy_by)
        {
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_UpdateBusyCase;
            DbParameter[] parameters ={
                Parameter("@ORDER_ID",order_id),
                Parameter("@IS_BUSY",is_busy),
                Parameter("@BUSY_BY",busy_by),
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}

