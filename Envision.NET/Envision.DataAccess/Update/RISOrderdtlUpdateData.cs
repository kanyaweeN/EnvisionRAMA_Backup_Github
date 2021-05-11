using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISOrderdtlUpdateData : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }

        public RISOrderdtlUpdateData()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Update;
        }
        public RISOrderdtlUpdateData(RIS_ORDERDTL orderDTL) {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            RIS_ORDERDTL = orderDTL;
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateStatus;
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
        public void UpdateStatus()
        {
            ParameterList = buildParameterUpdateStatus();
            ExecuteNonQuery();
        }
        public void UpdateHL7Message(DbTransaction tran, DataTable dtt)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateHL7;

            foreach (DataRow dr in dtt.Rows)
            {
                ParameterList = buildParameterUpdateHL7Text(dr["ACCESSION_NO"].ToString(), dr["HL7_TXT"].ToString());
                Transaction = tran;
                ExecuteNonQuery(); 
            }
        }
        public void UpdateHL7Message(DataTable dtt)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateHL7;

            foreach (DataRow dr in dtt.Rows)
            {
                ParameterList = buildParameterUpdateHL7Text(dr["ACCESSION_NO"].ToString(), dr["HL7_TXT"].ToString());
                ExecuteNonQuery(); 
            }
        }
        public void UpdateFlag(DataTable dtt, string flag)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateFlag;

            foreach (DataRow dr in dtt.Rows)
            {
                ParameterList = buildParameterUpdateFlag(Convert.ToInt32(dr["ORDER_ID"].ToString()), flag);
                ExecuteNonQuery(); 
            }
        }
        public void UpdateSend()
        {
            //RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Send;
            ParameterList = buildParameterUpdateSendBilling();
            ExecuteNonQuery(); 
        }
        public void UpdateIsDeleted()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateIsDeleted;
            ParameterList = new DbParameter[]
            {
                Parameter("@ORDER_ID",RIS_ORDERDTL.ORDER_ID)
                ,Parameter("@ACCESSION_NO",RIS_ORDERDTL.ACCESSION_NO)
                ,Parameter("@IS_DELETED",RIS_ORDERDTL.IS_DELETED)
                ,Parameter("@LAST_MODIFIED_BY",RIS_ORDERDTL.LAST_MODIFIED_BY)
            };
            RIS_ORDERDTL.ORDER_ID = ExecuteNonQuery();
        }
        public void UpdatePriority()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdatePriority;
            ParameterList = new DbParameter[]
            {
                //Parameter("@ORDER_ID",RIS_ORDERDTL.ORDER_ID)
                Parameter("@ACCESSION_NO",RIS_ORDERDTL.ACCESSION_NO)
                ,Parameter("@PRIORITY",RIS_ORDERDTL.PRIORITY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_ORDERDTL.LAST_MODIFIED_BY)
            };
            RIS_ORDERDTL.ORDER_ID = ExecuteNonQuery();            
        }
        public void UpdateIsDF(string is_df, string accession_no, int emp_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateIS_DF;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",accession_no)
                ,Parameter("@IS_DF",is_df)
                ,Parameter("@DF_BY",emp_id)
            };
            ExecuteNonQuery();
        }
        
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@ORDER_ID", RIS_ORDERDTL.ORDER_ID);

            DbParameter param21 = Parameter();
            param21.ParameterName = "@0LD_EXAM_ID";
            if (RIS_ORDERDTL.OLD_EXAM_ID == null)
                param21.Value = DBNull.Value;
            else
                param21.Value = RIS_ORDERDTL.OLD_EXAM_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.OLD_EXAM_ID;

            DbParameter param2 = Parameter("@EXAM_ID", RIS_ORDERDTL.EXAM_ID);

            DbParameter param3 = Parameter("@ACCESSION_NO", RIS_ORDERDTL.ACCESSION_NO);

            DbParameter param4 = Parameter();
            param4.ParameterName = "@Q_NO";
            if (RIS_ORDERDTL.Q_NO == null)
                param4.Value = DBNull.Value;
            else
                param4.Value = RIS_ORDERDTL.Q_NO == 0 ? (object)DBNull.Value : RIS_ORDERDTL.Q_NO;

            DbParameter param5 = Parameter();
            param5.ParameterName = "@MODALITY_ID";
            if (RIS_ORDERDTL.MODALITY_ID == null)
                param5.Value = DBNull.Value;
            else
                param5.Value = RIS_ORDERDTL.MODALITY_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.MODALITY_ID;

            DbParameter param6 = Parameter();
            param6.ParameterName = "@EXAM_DT";
            if (RIS_ORDERDTL.EXAM_DT == null)
                param6.Value = DBNull.Value;
            else
                param6.Value = RIS_ORDERDTL.EXAM_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.EXAM_DT;

            DbParameter param8 = Parameter("@QTY",RIS_ORDERDTL.QTY);

            DbParameter param9 = Parameter();
            param9.ParameterName = "@ASSIGNED_TO";
            if (RIS_ORDERDTL.ASSIGNED_TO == null)
                param9.Value = DBNull.Value;
            else
                param9.Value = RIS_ORDERDTL.ASSIGNED_TO == 0 ? (object)DBNull.Value : RIS_ORDERDTL.ASSIGNED_TO;

            DbParameter param10 = Parameter();
            param10.ParameterName = "@HL7_TEXT";
            if (RIS_ORDERDTL.HL7_TEXT == null)
                param10.Value = DBNull.Value;
            else
                param10.Value = RIS_ORDERDTL.HL7_TEXT == string.Empty ? (object)DBNull.Value : RIS_ORDERDTL.HL7_TEXT;

            DbParameter param11 = Parameter();
            param11.ParameterName = "@HL7_SENT";
            if (RIS_ORDERDTL.HL7_SENT == null)
                param11.Value = DBNull.Value;
            else
                param11.Value = RIS_ORDERDTL.HL7_SENT.ToString() == string.Empty ? (object)DBNull.Value : RIS_ORDERDTL.HL7_SENT.ToString() ;

            DbParameter param12 = Parameter();
            param12.ParameterName = "@RATE";
            if (RIS_ORDERDTL.RATE == null)
                param12.Value = DBNull.Value;
            else
                param12.Value = RIS_ORDERDTL.RATE<=0 ? (object)DBNull.Value : RIS_ORDERDTL.RATE;

            DbParameter param13 = Parameter();
            param13.ParameterName = "@COMMENTS";
            if (RIS_ORDERDTL.COMMENTS == null)
                param13.Value = DBNull.Value;
            else
                param13.Value = RIS_ORDERDTL.COMMENTS == string.Empty ? (object)DBNull.Value : RIS_ORDERDTL.COMMENTS;

            DbParameter param15 = Parameter();
            param15.ParameterName = "@IMAGE_CAPTURED_BY";
            if (RIS_ORDERDTL.IMAGE_CAPTURED_BY == null)
                param15.Value = DBNull.Value;
            else
                param15.Value = RIS_ORDERDTL.IMAGE_CAPTURED_BY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.IMAGE_CAPTURED_BY;

            DbParameter param16 = Parameter();
            param16.ParameterName = "@IMAGE_CAPTURED_ON";
            if (RIS_ORDERDTL.IMAGE_CAPTURED_ON == null)
                param16.Value = DBNull.Value;
            else
                param16.Value = RIS_ORDERDTL.IMAGE_CAPTURED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.IMAGE_CAPTURED_ON;

            DbParameter param17 = Parameter();
            param17.ParameterName = "@QA_BY";
            if (RIS_ORDERDTL.QA_BY == null)
                param17.Value = DBNull.Value;
            else
                param17.Value = RIS_ORDERDTL.QA_BY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.QA_BY;

            DbParameter param18 = Parameter();
            param18.ParameterName = "@QA_ON";
            if (RIS_ORDERDTL.QA_ON == null)
                param18.Value = DBNull.Value;
            else
                param18.Value = RIS_ORDERDTL.QA_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.QA_ON;

            DbParameter param19 = Parameter();
            param19.ParameterName = "@ORG_ID";
            if (RIS_ORDERDTL.ORG_ID == null)
                param19.Value = DBNull.Value;
            else
                param19.Value = RIS_ORDERDTL.ORG_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.ORG_ID;

            DbParameter param20 = Parameter();
            param20.ParameterName = "@LAST_MODIFIED_BY";
            if (RIS_ORDERDTL.LAST_MODIFIED_BY == null)
                param20.Value = DBNull.Value;
            else
                param20.Value = RIS_ORDERDTL.LAST_MODIFIED_BY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.LAST_MODIFIED_BY;

            DbParameter param22 = Parameter();
            param22.ParameterName = "@PRIORITY";
            if (RIS_ORDERDTL.PRIORITY == null)
                param22.Value = DBNull.Value;
            else
                param22.Value = RIS_ORDERDTL.PRIORITY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.PRIORITY;

            DbParameter param23 = Parameter();
            param23.ParameterName = "@EST_START_TIME";
            if (RIS_ORDERDTL.EST_START_TIME == null)
                param23.Value = DBNull.Value;
            else
                param23.Value = RIS_ORDERDTL.EST_START_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDERDTL.EST_START_TIME;

            DbParameter param24 = Parameter("@IS_DELETED", RIS_ORDERDTL.IS_DELETED);
            DbParameter param25 = Parameter("@CLINIC_TYPE", RIS_ORDERDTL.CLINIC_TYPE);

            //DbParameter param26 = Parameter();
            //param26.ParameterName = "@BPVIEW_ID";
            ////if (RIS_ORDERDTL.BPVIEW_ID == null)
            //if (RIS_ORDERDTL.BV_VIEW == null)
            //    param26.Value = DBNull.Value;
            //else
            //    param26.Value = RIS_ORDERDTL.BV_VIEW == 0 ? (object)DBNull.Value : RIS_ORDERDTL.BV_VIEW;

            DbParameter param26 = Parameter();
            param26.ParameterName = "@BPVIEW_ID";
            if (RIS_ORDERDTL.BPVIEW_ID == null)
                param26.Value = DBNull.Value;
            else
                param26.Value = RIS_ORDERDTL.BPVIEW_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.BPVIEW_ID;


            DbParameter param28 = Parameter();
            param28.ParameterName = "@PREPARATION_ID";
            if (RIS_ORDERDTL.PREPARATION_ID == null)
                param28.Value = DBNull.Value;
            else
                param28.Value = RIS_ORDERDTL.PREPARATION_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.PREPARATION_ID;

            DbParameter[] parameters ={
                param1      ,param21    ,param2    ,param3  ,param4 
                 ,param5    ,param6     ,param8    ,param9  ,param10
                 ,param11   ,param12    ,param13   ,param15 ,param16
                 ,param17   ,param18    ,param19   ,param20 ,param22 
                ,param23    ,param24    ,param25, param26  // ,param27
                ,param28
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateStatus()
        {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_ORDERDTL.ACCESSION_NO)
                ,Parameter("@STATUS",RIS_ORDERDTL.STATUS)
                ,Parameter("@UserID",RIS_ORDERDTL.CREATED_BY)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateHL7Text(string ACCESSION_NO, string HL7_TEXT)
        {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",ACCESSION_NO)
                ,Parameter("@HL7_TEXT",HL7_TEXT)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateFlag(int ORDER_ID, string IS_DELETED)
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID",ORDER_ID)
                ,Parameter("@IS_DELETED",IS_DELETED)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateSendBilling()
        {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_ORDERDTL.ACCESSION_NO)
                ,Parameter("@HIS_SYNC",RIS_ORDERDTL.HIS_SYNC)
                ,Parameter("@HIS_ACK",RIS_ORDERDTL.HIS_ACK)
                                      };
            return parameters;
        }
    }
}