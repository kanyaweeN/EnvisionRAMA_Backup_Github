using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISOrderDtlInsertV2 : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }

        public RISOrderDtlInsertV2()
		{
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Insert_v2;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran) {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@ORDER_ID", RIS_ORDERDTL.ORDER_ID);

            DbParameter param2 = Parameter("@EXAM_ID", RIS_ORDERDTL.EXAM_ID);

            DbParameter param3 = Parameter("@ACCESSION_NO", RIS_ORDERDTL.ACCESSION_NO);

            DbParameter param4 = Parameter();
            param4.ParameterName = "@Q_NO";
            if (RIS_ORDERDTL.Q_NO == null)
                param4.Value = DBNull.Value;
            else
                param4.Value = RIS_ORDERDTL.Q_NO;

            DbParameter param5 = Parameter();
            param5.ParameterName = "@MODALITY_ID";
            if (RIS_ORDERDTL.MODALITY_ID == 0)
                param5.Value = DBNull.Value;
            else
                param5.Value = RIS_ORDERDTL.MODALITY_ID;

            DbParameter param6 = Parameter();
            param6.ParameterName = "@EXAM_DT";
            if (RIS_ORDERDTL.EXAM_DT == null)
                param6.Value = DBNull.Value;
            else
                param6.Value = RIS_ORDERDTL.EXAM_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.EXAM_DT;

            //DbParameter param7 = Parameter();
            //param7.ParameterName = "@SERVICE_TYPE";
            //if (RIS_ORDERDTL.SERVICE_TYPE == null)
            //    param7.Value = DBNull.Value;
            //else
            //    param7.Value = RIS_ORDERDTL.SERVICE_TYPE;

            DbParameter param8 = Parameter();
            param8.ParameterName = "@QTY";
            param8.Value = RIS_ORDERDTL.QTY;

            DbParameter param9 = Parameter();
            param9.ParameterName = "@ASSIGNED_TO";
            if (RIS_ORDERDTL.ASSIGNED_TO == null)
                param9.Value = DBNull.Value;
            else
                param9.Value = RIS_ORDERDTL.ASSIGNED_TO == 0 ? (object)DBNull.Value : RIS_ORDERDTL.ASSIGNED_TO;

            DbParameter param10 = Parameter();
            param10.ParameterName = "@HL7_TEXT";
            if (string.IsNullOrEmpty(RIS_ORDERDTL.HL7_TEXT))
                param10.Value = DBNull.Value;
            else
                param10.Value = RIS_ORDERDTL.HL7_TEXT;

            DbParameter param11 = Parameter();
            param11.ParameterName = "@HL7_SENT";
            if (RIS_ORDERDTL.HL7_SENT == null)
                param11.Value = DBNull.Value;
            else
                param11.Value = RIS_ORDERDTL.HL7_SENT;

            DbParameter param12 = Parameter();
            param12.ParameterName = "@RATE";
            if (RIS_ORDERDTL.RATE ==null)
                param12.Value = 0;
            else
                param12.Value = RIS_ORDERDTL.RATE < 0 ? 0 : RIS_ORDERDTL.RATE;

            DbParameter param13 = Parameter();
            param13.ParameterName = "@COMMENTS";
            if (string.IsNullOrEmpty(RIS_ORDERDTL.COMMENTS))// == null)
                param13.Value = DBNull.Value;
            else
                param13.Value = RIS_ORDERDTL.COMMENTS;

            //DbParameter param14 = Parameter();
            //param14.ParameterName = "@SPECIAL_CLINIC";
            //if (string.IsNullOrEmpty(RIS_ORDERDTL.SPECIAL_CLINIC))// == null)
            //    param14.Value = DBNull.Value;
            //else
            //    param14.Value = RIS_ORDERDTL.SPECIAL_CLINIC;

            DbParameter param15 = Parameter();
            param15.ParameterName = "@IMAGE_CAPTURED_BY";
            if (RIS_ORDERDTL.IMAGE_CAPTURED_BY ==null)
                param15.Value = DBNull.Value;
            else
                param15.Value = RIS_ORDERDTL.IMAGE_CAPTURED_BY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.IMAGE_CAPTURED_BY;

            DbParameter param16 = Parameter();
            param16.ParameterName = "@IMAGE_CAPTURED_ON";
            if (RIS_ORDERDTL.IMAGE_CAPTURED_ON == null)
                param16.Value = DBNull.Value;
            else
                param16.Value = RIS_ORDERDTL.IMAGE_CAPTURED_ON==DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.IMAGE_CAPTURED_ON;

            DbParameter param17 = Parameter();
            param17.ParameterName = "@QA_BY";
            if (RIS_ORDERDTL.QA_BY == null)
                param17.Value = DBNull.Value;
            else
                param17.Value = RIS_ORDERDTL.QA_BY==0 ? (object)DBNull.Value : RIS_ORDERDTL.QA_BY;

            DbParameter param18 = Parameter();
            param18.ParameterName = "@QA_ON";
            if (RIS_ORDERDTL.QA_ON == null)
                param18.Value = DBNull.Value;
            else
                param18.Value = RIS_ORDERDTL.QA_ON==DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.QA_ON;

            DbParameter param19 = Parameter();
            param19.ParameterName = "@ORG_ID";
            if (RIS_ORDERDTL.ORG_ID == null)
                param19.Value = DBNull.Value;
            else
                param19.Value = RIS_ORDERDTL.ORG_ID==0 ? (object)DBNull.Value : RIS_ORDERDTL.ORG_ID;

            DbParameter param20 = Parameter();
            param20.ParameterName = "@CREATED_BY";
            if (RIS_ORDERDTL.CREATED_BY == null)
                param20.Value = DBNull.Value;
            else
                param20.Value = RIS_ORDERDTL.CREATED_BY==0 ? (object)DBNull.Value : RIS_ORDERDTL.CREATED_BY;

            DbParameter param21 = Parameter();
            param21.ParameterName = "@PRIORITY";
            if (RIS_ORDERDTL.PRIORITY == null)
                param21.Value = DBNull.Value;
            else
                param21.Value = RIS_ORDERDTL.PRIORITY;

            DbParameter param22 = Parameter();
            param22.ParameterName = "@EST_START_TIME";
            if (RIS_ORDERDTL.EST_START_TIME == null)
                param22.Value = DBNull.Value;
            else
                param22.Value = RIS_ORDERDTL.EST_START_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.EST_START_TIME;

            DbParameter param23 = Parameter();
            param23.ParameterName = "@CLINIC_TYPE";
            if (RIS_ORDERDTL.CLINIC_TYPE == null)
                param23.Value = DBNull.Value;
            else
                param23.Value = RIS_ORDERDTL.CLINIC_TYPE == 0 ? (object)DBNull.Value : RIS_ORDERDTL.CLINIC_TYPE;

            DbParameter param24 = Parameter();
            param24.ParameterName = "@BPVIEW_ID";
            if (RIS_ORDERDTL.BPVIEW_ID == null)
                param24.Value = DBNull.Value;
            else
                param24.Value = RIS_ORDERDTL.BPVIEW_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.BPVIEW_ID;

            DbParameter param26 = Parameter();
            param26.ParameterName = "@PREPARATION_ID";
            if (RIS_ORDERDTL.PREPARATION_ID == null)
                param26.Value = DBNull.Value;
            else
                param26.Value = RIS_ORDERDTL.PREPARATION_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.PREPARATION_ID;

            DbParameter pCOMMENTS_ONLINE = Parameter();
            pCOMMENTS_ONLINE.ParameterName = "@COMMENTS_ONLINE";
            if (RIS_ORDERDTL.COMMENTS_ONLINE == null)
                pCOMMENTS_ONLINE.Value = DBNull.Value;
            else
                pCOMMENTS_ONLINE.Value = RIS_ORDERDTL.COMMENTS_ONLINE;

            DbParameter pHISSync = Parameter();
            pHISSync.ParameterName = "@HIS_SYNC";
            if (string.IsNullOrEmpty(RIS_ORDERDTL.HIS_SYNC.ToString()))// == string.Empty)
                pHISSync.Value = DBNull.Value;
            else
                pHISSync.Value = RIS_ORDERDTL.HIS_SYNC;

            DbParameter pHIS_ACK = Parameter();
            pHIS_ACK.ParameterName = "@HIS_ACK";
            if (string.IsNullOrEmpty(RIS_ORDERDTL.HIS_ACK))// == string.Empty)
                pHIS_ACK.Value = DBNull.Value;
            else
                pHIS_ACK.Value = RIS_ORDERDTL.HIS_ACK;

            DbParameter pPAT_DEST_ID = Parameter();
            pPAT_DEST_ID.ParameterName = "@PAT_DEST_ID";
            if (RIS_ORDERDTL.PAT_DEST_ID == 0)// == string.Empty)
                pPAT_DEST_ID.Value = DBNull.Value;
            else
                pPAT_DEST_ID.Value = RIS_ORDERDTL.PAT_DEST_ID;
   


//            ,@COMMENTS_ONLINE nvarchar(200)
//,@HIS_SYNC nvarchar(1)
//,@HIS_ACK nvarchar(300)







            DbParameter[] parameters ={
                param1      ,param2    ,param3
                ,param4     ,param5    ,param6
                /*,param7*/ ,param8    ,param9
                ,param10    ,param11   ,param12
                ,param13    //,param14   
                ,param15
                ,param16    ,param17   ,param18
                ,param19    ,param20   ,param21
                ,param22    ,param23   ,param24
                ,param26    ,pCOMMENTS_ONLINE
                ,pHISSync   ,pHIS_ACK, pPAT_DEST_ID
            
            };
            return parameters;
        }
    }
}
