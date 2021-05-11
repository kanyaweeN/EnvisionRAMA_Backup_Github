using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class RISOrderUpdateData : DataAccessBase
    {
        public RIS_ORDER RIS_ORDER { get; set; }

        public RISOrderUpdateData()
        {
            RIS_ORDER = new RIS_ORDER();

            //StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateFromOnline;
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateFromOnline2;
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
            DbParameter pUnit = Parameter();
            pUnit.ParameterName = "@REF_UNIT";
            if (RIS_ORDER.REF_UNIT == null)
                pUnit.Value = DBNull.Value;
            else
                pUnit.Value = RIS_ORDER.REF_UNIT == 0 ? (object)DBNull.Value : RIS_ORDER.REF_UNIT;

            DbParameter pDoc = Parameter();
            pDoc.ParameterName = "@REF_DOC";
            if (RIS_ORDER.REF_DOC == null)
                pDoc.Value = DBNull.Value;
            else
                pDoc.Value = RIS_ORDER.REF_DOC == 0 ? (object)DBNull.Value : RIS_ORDER.REF_DOC;

            DbParameter pINSURANCE_TYPE_ID = Parameter();
            pINSURANCE_TYPE_ID.ParameterName = "@INSURANCE_TYPE_ID";
            if (RIS_ORDER.INSURANCE_TYPE_ID == null)
                pINSURANCE_TYPE_ID.Value = DBNull.Value;
            else
                pINSURANCE_TYPE_ID.Value = RIS_ORDER.INSURANCE_TYPE_ID == 0 ? (object)DBNull.Value : RIS_ORDER.INSURANCE_TYPE_ID;

            DbParameter pPAT_STATUS = Parameter();
            pPAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RIS_ORDER.PAT_STATUS == null)
                pPAT_STATUS.Value = DBNull.Value;
            else
                pPAT_STATUS.Value = RIS_ORDER.PAT_STATUS == string.Empty ? (object)DBNull.Value : RIS_ORDER.PAT_STATUS;

            DbParameter pREF_DOC_INSTRUCTION = Parameter();
            pREF_DOC_INSTRUCTION.ParameterName = "@REF_DOC_INSTRUCTION";
            if (RIS_ORDER.REF_DOC_INSTRUCTION == null)
                pREF_DOC_INSTRUCTION.Value = DBNull.Value;
            else
                pREF_DOC_INSTRUCTION.Value = RIS_ORDER.REF_DOC_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_ORDER.REF_DOC_INSTRUCTION;

            DbParameter pCLINICAL_INSTRUCTION = Parameter();
            pCLINICAL_INSTRUCTION.ParameterName = "@CLINICAL_INSTRUCTION";
            if (RIS_ORDER.CLINICAL_INSTRUCTION == null)
                pCLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION.Value = RIS_ORDER.CLINICAL_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_ORDER.CLINICAL_INSTRUCTION;

            DbParameter pIS_ALERT_CLINICAL_INSTRUCTION = Parameter();
            pIS_ALERT_CLINICAL_INSTRUCTION.ParameterName = "@IS_ALERT_CLINICAL_INSTRUCTION";
            if (RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION == null)
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION;

            DbParameter pCLINICAL_INSTRUCTION_TAG = Parameter();
            pCLINICAL_INSTRUCTION_TAG.ParameterName = "@CLINICAL_INSTRUCTION_TAG";
            if (RIS_ORDER.CLINICAL_INSTRUCTION_TAG == null)
                pCLINICAL_INSTRUCTION_TAG.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION_TAG.Value = RIS_ORDER.CLINICAL_INSTRUCTION_TAG == string.Empty ? (object)DBNull.Value : RIS_ORDER.CLINICAL_INSTRUCTION_TAG;

            DbParameter[] parameters ={
                      Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID)
                    ,pUnit
                    ,pDoc
                    ,pREF_DOC_INSTRUCTION
                    ,pCLINICAL_INSTRUCTION
                    , Parameter("@ORG_ID", 1)
                    , Parameter("@LAST_MODIFIED_BY", RIS_ORDER.LAST_MODIFIED_BY)
                    ,pINSURANCE_TYPE_ID
                    ,pPAT_STATUS
                    ,pIS_ALERT_CLINICAL_INSTRUCTION
                    ,pCLINICAL_INSTRUCTION_TAG
                                      };
            return parameters;
        }
    }
}
