using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class XrayreqdtlInsertData : DataAccessBase
    {

        public XRAYREQ XRAYREQ { get; set; }

        public XrayreqdtlInsertData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQDTL_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
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

            DbParameter[] parameters =
		    {
      

				Parameter( "@ORDER_ID"	            , XRAYREQ.ORDER_ID ) ,
                Parameter( "@EXAM_ID"	            , XRAYREQ.EXAM_ID ) ,
                Parameter( "@EXAM_UID"	            , XRAYREQ.EXAM_UID ) ,
                Parameter( "@MODALITY_ID"	            , XRAYREQ.MODALITY_ID ) ,
                //Parameter( "@EXAM_DT"	            , DateTime.Now ) ,
                paramExam ,
                Parameter( "@PRIORITY"	            , XRAYREQ.PRIORITY ) ,
                Parameter( "@STATUS"	            , XRAYREQ.STATUS ) ,
                Parameter( "@ASSIGN_TO"	            , XRAYREQ.ASSIGN_TO ) ,
                Parameter( "@ASSIGN_TO_TITLE"	            , XRAYREQ.ASSIGN_TO_TITLE ) ,
                Parameter( "@ASSIGN_TO_FNAME"	            , XRAYREQ.ASSIGN_TO_FNAME ) ,
                Parameter( "@ASSIGN_TO_LNAME"	            , XRAYREQ.ASSIGN_TO_LNAME ) ,
                Parameter( "@ASSIGN_TO_UID"	            , XRAYREQ.ASSIGN_TO_UID ) ,
                Parameter( "@QTY"	            , XRAYREQ.QTY ) ,
                Parameter( "@RATE"	            , XRAYREQ.RATE ) ,
                Parameter( "@CLINIC_TYPE"	            , XRAYREQ.CLINIC_TYPE ) ,
                Parameter( "@BP_VIEW"	            , XRAYREQ.BP_VIEW ) ,
                paramBpviewID,
                //Parameter( "@BPVIEW_ID"	            , XRAYREQ.BPVIEW_ID ) ,
                //Parameter( "@ACCESSION_NO"	            , XRAYREQ.REF_DOC_ID ) ,
                Parameter( "@IS_DELETED"	            , XRAYREQ.IS_DELETED ) ,
                Parameter( "@COMMENTS"	            , XRAYREQ.COMMENTS ) ,
                Parameter( "@ORG_ID"	            , XRAYREQ.ORG_ID ) ,
                Parameter( "@CREATED_BY"	            , XRAYREQ.CREATED_BY ) ,
                Parameter( "@PAT_DEST_ID"	            , XRAYREQ.PAT_DEST_ID ) ,
                Parameter( "@IS_PORTABLE"               ,XRAYREQ.IS_PORTABLE)
			};
            return parameters;
        }
    }
}
