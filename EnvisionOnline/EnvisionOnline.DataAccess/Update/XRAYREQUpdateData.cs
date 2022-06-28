using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class XRAYREQUpdateData : DataAccessBase
    {
        public XRAYREQ XRAYREQ { get; set; }

        public XRAYREQUpdateData()
        {
            XRAYREQ = new XRAYREQ();
            //StoredProcedureName = StoredProcedure.Prc_XRAYREQ_Update;
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_Update2;
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
        public void Delete()
        {
            StoredProcedureName = StoredProcedure.Prc_XREGIST_Status;
            ParameterList = buildParameterDelete();
            ExecuteNonQuery();
        }
        public void updateLockCase(int order_id, string is_busy, int busy_by)
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
        private DbParameter[] buildParameterDelete()
        {
            DbParameter[] parameters ={
                Parameter("@REG_ID",XRAYREQ.REG_ID)
                ,Parameter("@ORDER_ID",XRAYREQ.ORDER_ID)
                ,Parameter("@ACCESSION_NO",XRAYREQ.ACCESSION_NO)
            };
            return parameters;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter pIS_ALERT_CLINICAL_INSTRUCTION = Parameter();
            pIS_ALERT_CLINICAL_INSTRUCTION.ParameterName = "@IS_ALERT_CLINICAL_INSTRUCTION";
            if (XRAYREQ.IS_ALERT_CLINICAL_INSTRUCTION == null)
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = XRAYREQ.IS_ALERT_CLINICAL_INSTRUCTION == string.Empty ? (object)DBNull.Value : XRAYREQ.IS_ALERT_CLINICAL_INSTRUCTION;

            DbParameter pCLINICAL_INSTRUCTION_TAG = Parameter();
            pCLINICAL_INSTRUCTION_TAG.ParameterName = "@CLINICAL_INSTRUCTION_TAG";
            if (XRAYREQ.CLINICAL_INSTRUCTION_TAG == null)
                pCLINICAL_INSTRUCTION_TAG.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION_TAG.Value = XRAYREQ.CLINICAL_INSTRUCTION_TAG == string.Empty ? (object)DBNull.Value : XRAYREQ.CLINICAL_INSTRUCTION_TAG;

            DbParameter[] parameters ={
                Parameter("@ORDER_ID",XRAYREQ.ORDER_ID)
                ,Parameter("@INSURANCE_TYPE_ID",XRAYREQ.INSURANCE_TYPE_ID)
                ,Parameter("@EMP_UID",XRAYREQ.EMP_UID)
                ,Parameter("@DOCNAME",XRAYREQ.DOCNAME)
                ,Parameter("@PAT_STATUS",XRAYREQ.PAT_STATUS)
                ,Parameter("@CLINICAL_INSTRUCTION",XRAYREQ.CLINICAL_INSTRUCTION)
                ,Parameter("@REF_DOC_TITLE",XRAYREQ.REF_DOC_TITLE)
                ,Parameter("@REF_DOC_FNAME",XRAYREQ.REF_DOC_FNAME)
                ,Parameter("@REF_DOC_LNAME",XRAYREQ.REF_DOC_LNAME)
                ,Parameter("@REF_DOC_ID",XRAYREQ.REF_DOC_ID)
                ,Parameter("@LAST_MODIFIED_BY",XRAYREQ.LAST_MODIFIED_BY)
                ,Parameter("@ORG_ID",XRAYREQ.ORG_ID)
                ,Parameter("@REF_UNIT",XRAYREQ.REF_UNIT)
                ,pIS_ALERT_CLINICAL_INSTRUCTION
                ,pCLINICAL_INSTRUCTION_TAG
            };
            return parameters;
        }
    }
}
