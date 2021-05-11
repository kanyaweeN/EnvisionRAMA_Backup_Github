using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class XRAYREQDTLUpdateData : DataAccessBase
    {
        public XRAYREQ XRAYREQ { get; set; }

        public XRAYREQDTLUpdateData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQDTL_Update;
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
            DbParameter paramExam = Parameter();
            paramExam.ParameterName = "@EXAM_DT";
            if (XRAYREQ.EXAM_DT == null)
                paramExam.Value = DBNull.Value;
            else if (XRAYREQ.EXAM_DT == DateTime.MinValue)
                paramExam.Value = DBNull.Value;
            else
                paramExam.Value = XRAYREQ.EXAM_DT;

            DbParameter paramBpviewID = Parameter();
            paramBpviewID.ParameterName = "@BPVIEW_ID";
            if (XRAYREQ.BPVIEW_ID == null)
                paramBpviewID.Value = DBNull.Value;
            else if (XRAYREQ.BPVIEW_ID == 0)
                paramBpviewID.Value = DBNull.Value;
            else
                paramBpviewID.Value = XRAYREQ.BPVIEW_ID;

            DbParameter[] parameters ={
                Parameter("@ORDER_ID",XRAYREQ.ORDER_ID)
                ,Parameter("@EXAM_ID",XRAYREQ.EXAM_ID)
                ,Parameter("@PRIORITY",XRAYREQ.PRIORITY)
                ,Parameter("@QTY",XRAYREQ.QTY)
                ,Parameter("@RATE",XRAYREQ.RATE)
                ,Parameter("@BP_VIEW",XRAYREQ.BP_VIEW)
                ,paramBpviewID
                ,Parameter("@COMMENTS",XRAYREQ.COMMENTS)
                ,Parameter("@LAST_MODIFIED_BY",XRAYREQ.LAST_MODIFIED_BY)
                ,Parameter("@ORG_ID",XRAYREQ.ORG_ID)
                ,Parameter("@CLINIC_TYPE",XRAYREQ.CLINIC_TYPE)
                ,paramExam
                ,Parameter("@PAT_DEST_ID",XRAYREQ.PAT_DEST_ID)
                ,Parameter( "@IS_PORTABLE"               ,XRAYREQ.IS_PORTABLE)
                
            };
            return parameters;
        }
    }
}
