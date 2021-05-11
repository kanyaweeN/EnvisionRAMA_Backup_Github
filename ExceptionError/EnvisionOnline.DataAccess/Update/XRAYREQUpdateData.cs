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
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_Update;
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


            };
            return parameters;
        }
    }
}
