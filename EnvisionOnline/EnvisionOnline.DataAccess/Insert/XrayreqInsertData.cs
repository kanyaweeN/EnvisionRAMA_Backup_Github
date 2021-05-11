using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class XrayreqInsertData : DataAccessBase
    {

        public XRAYREQ XRAYREQ { get; set; }

        public XrayreqInsertData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_Insert;
            //StoredProcedureName = StoredProcedure.Prc_XRAYREQ_Insert2;
        }

        public int Add()
        {
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            try
            {
                return System.Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private DbParameter[] buildParameter()
        {
            DbParameter paramOrderStart = Parameter();
            paramOrderStart.ParameterName = "@ORDER_START_TIME";
            if (XRAYREQ.ORDER_START_TIME == null)
                paramOrderStart.Value = DBNull.Value;
            else if (XRAYREQ.ORDER_START_TIME == DateTime.MinValue)
                paramOrderStart.Value = DBNull.Value;
            else
                paramOrderStart.Value = XRAYREQ.ORDER_START_TIME;

            DbParameter paramRequestDate = Parameter();
            paramRequestDate.ParameterName = "@REQUEST_DATE";
            if (XRAYREQ.REQUEST_DATE == null)
                paramRequestDate.Value = DBNull.Value;
            else if (XRAYREQ.REQUEST_DATE == DateTime.MinValue)
                paramRequestDate.Value = DBNull.Value;
            else
                paramRequestDate.Value = XRAYREQ.REQUEST_DATE;

            DbParameter paramOrderdt = Parameter();
            paramOrderdt.ParameterName = "@ORDER_DT";
            if (XRAYREQ.ORDER_DT == null)
                paramOrderdt.Value = DBNull.Value;
            else if (XRAYREQ.ORDER_DT == DateTime.MinValue)
                paramOrderdt.Value = DBNull.Value;
            else
                paramOrderdt.Value = XRAYREQ.ORDER_DT;

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

            DbParameter pIS_TELEMED = Parameter();
            pIS_TELEMED.ParameterName = "@IS_TELEMED";
            if (XRAYREQ.IS_TELEMED == null)
                pIS_TELEMED.Value = DBNull.Value;
            else
                pIS_TELEMED.Value = XRAYREQ.IS_TELEMED == string.Empty ? (object)DBNull.Value : XRAYREQ.IS_TELEMED;

            DbParameter[] parameters =
		    {
				Parameter( "@REQUESTNO"	                , XRAYREQ.REQUESTNO ) ,
                Parameter( "@FACILITYRMSNO"	            , XRAYREQ.FACILITYRMSNO ) ,
                Parameter( "@HN"	                    , XRAYREQ.HN ) ,
                Parameter( "@FULLNAME"	                , XRAYREQ.FULLNAME ) ,
                //paramOrderdt,
                Parameter( "@INSURANCE_TYPE_ID"	        , XRAYREQ.INSURANCE_TYPE_ID ) ,
                paramOrderStart ,
                paramRequestDate ,
                Parameter( "@REF_UNIT"	                , XRAYREQ.REF_UNIT ) ,
                Parameter( "@EMP_UID"	                , XRAYREQ.EMP_UID ) ,
                Parameter( "@DOCNAME"	                , XRAYREQ.DOCNAME ) ,
                Parameter( "@PAT_STATUS"	            , XRAYREQ.PAT_STATUS ) ,
                Parameter( "@REF_DOC_INSTRUCTION"	    , XRAYREQ.REF_DOC_INSTRUCTION ) ,
                Parameter( "@CLINICAL_INSTRUCTION"	    , XRAYREQ.CLINICAL_INSTRUCTION ) ,
                Parameter( "@STATUS"	                , XRAYREQ.STATUS ) ,
                Parameter( "@REF_DOC_TITLE"	            , XRAYREQ.REF_DOC_TITLE ) ,
                Parameter( "@REF_DOC_FNAME"	            , XRAYREQ.REF_DOC_FNAME ) ,
                Parameter( "@REF_DOC_LNAME"	            , XRAYREQ.REF_DOC_LNAME ) ,
                Parameter( "@REF_DOC_ID"	            , XRAYREQ.REF_DOC_ID ) ,
                Parameter( "@IS_CANCELED"	            , XRAYREQ.IS_CANCELED ) ,
                Parameter( "@ORG_ID"	                , XRAYREQ.ORG_ID ) ,
                Parameter( "@CREATED_BY"	            , XRAYREQ.CREATED_BY ) ,
                Parameter( "@REG_ID"	                , XRAYREQ.REG_ID ) ,
                Parameter( "@ENC_ID"	                , XRAYREQ.ENC_ID ) ,
                Parameter( "@ENC_TYPE"	                , XRAYREQ.ENC_TYPE ) ,
                Parameter( "@ENC_CLINIC"	            , XRAYREQ.ENC_CLINIC ) ,
                pIS_ALERT_CLINICAL_INSTRUCTION,
                pCLINICAL_INSTRUCTION_TAG,
                pIS_TELEMED
			};
            return parameters;
        }
    }
}
