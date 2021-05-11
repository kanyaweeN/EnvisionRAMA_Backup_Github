//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class RISOrderdtlUpdateData : DataAccessBase
    {
        private RISOrderdtl _risorderdtl;
        private RISOrderdtlInsertDataParameters _risorderdtlinsertdataparameters;
        public RISOrderdtlUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_Update.ToString();
        }
        public RISOrderdtlUpdateData(RISOrderdtl orderDTL) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_UpdateStatus.ToString();
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(orderDTL,true);
            RISOrderdtl = orderDTL;
        }
        public RISOrderdtl RISOrderdtl
        {
            get { return _risorderdtl; }
            set { _risorderdtl = value; }
        }
        public void Update()
        {
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _risorderdtlinsertdataparameters.Parameters);
        }
        public void Update(SqlTransaction tran)
        {

            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            try
            {
                object id = dbhelper.RunScalar(tran, _risorderdtlinsertdataparameters.Parameters);
            }
            catch (Exception ex) {
                string e = ex.Message;
            }
        }

        public void UpdateHL7Message(SqlTransaction tran,DataTable dtt)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_UpdateHL7.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            foreach (DataRow dr in dtt.Rows)
            {
                _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(dr["ACCESSION_NO"].ToString(), dr["HL7_TXT"].ToString());
                dbhelper.Run(tran, _risorderdtlinsertdataparameters.Parameters);
            }
        }
        public void UpdateHL7Message( DataTable dtt)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_UpdateHL7.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            foreach (DataRow dr in dtt.Rows)
            {
                _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(dr["ACCESSION_NO"].ToString(), dr["HL7_TXT"].ToString());
                dbhelper.RunScalar(base.ConnectionString,_risorderdtlinsertdataparameters.Parameters);
            }
        }
        public void UpdateFlag(DataTable dtt,string flag) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_UpdateFlag.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            foreach (DataRow dr in dtt.Rows)
            {
                _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters( Convert.ToInt32(dr["ORDER_ID"].ToString()),flag);
                dbhelper.RunScalar(base.ConnectionString, _risorderdtlinsertdataparameters.Parameters);
            }
        }
        public void UpdateStatus() {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _risorderdtlinsertdataparameters.Parameters);
        }
        public void UpdateSend() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_Send.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            RISOrderdtlUpdateSendBillParameter param = new RISOrderdtlUpdateSendBillParameter(RISOrderdtl);
            dbhelper.Run(param.Parameters);
        }
        public void UpdatePriority()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_UpdatePriority.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            RISOrderdtlUpdateDataParameters param = new RISOrderdtlUpdateDataParameters(RISOrderdtl);
            dbhelper.Run(param.Parameters);
        }
    }
    public class RISOrderdtlUpdateDataParameters
    {
        private RISOrderdtl _risorderdtl;
        private SqlParameter[] _parameters;
        public RISOrderdtl RISOrderdtl
        {
            get { return _risorderdtl; }
            set { _risorderdtl = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public RISOrderdtlUpdateDataParameters(RISOrderdtl risorderdtl)
        {
            RISOrderdtl = risorderdtl;
            Build();
        }
        public void Build()
        {
            SqlParameter[] parameters ={
                new SqlParameter("@ACCESSION_NO", RISOrderdtl.ACCESSION_NO)
                ,new SqlParameter("@PRIORITY",RISOrderdtl.PRIORITY)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISOrderdtl.LAST_MODIFIED_BY)
             };
            Parameters = parameters;
        }
        
    }
    public class RISOrderdtlInsertDataParameters
    {
        private RISOrderdtl _risorderdtl;
        private SqlParameter[] _parameters;

        public RISOrderdtlInsertDataParameters(RISOrderdtl risorderdtl)
        {
            RISOrderdtl = risorderdtl;
            Build();
        }
        public RISOrderdtlInsertDataParameters(RISOrderdtl risorderdtl,bool setStatus)
        {
            RISOrderdtl = risorderdtl;
            if (setStatus)
                BuildUpdateStatus();
            else
                Build();
        }
        public RISOrderdtlInsertDataParameters(string ACCESSION_NO, string HL7_TEXT)
        {
            _risorderdtl = new RISOrderdtl();
            BuildUpdateHL7Text(ACCESSION_NO, HL7_TEXT);
        }
        public RISOrderdtlInsertDataParameters(int order_ID,string flag) {
            _risorderdtl = new RISOrderdtl();
            BuildUpdateFlag(order_ID, flag);
        }

        public RISOrderdtl RISOrderdtl
        {
            get { return _risorderdtl; }
            set { _risorderdtl = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter param1 = new SqlParameter("@ORDER_ID", RISOrderdtl.ORDER_ID);

            SqlParameter param21 = new SqlParameter();
            param21.ParameterName = "@0LD_EXAM_ID";
            if (RISOrderdtl.OLD_EXAM_ID == 0)
                param21.Value = DBNull.Value;
            else
                param21.Value = RISOrderdtl.OLD_EXAM_ID;

            SqlParameter param2 = new SqlParameter("@EXAM_ID", RISOrderdtl.EXAM_ID);

            SqlParameter param3 = new SqlParameter("@ACCESSION_NO", RISOrderdtl.ACCESSION_NO);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Q_NO";
            if (RISOrderdtl.Q_NO == 0)
                param4.Value = DBNull.Value;
            else
                param4.Value = RISOrderdtl.Q_NO;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@MODALITY_ID";
            if (RISOrderdtl.MODALITY_ID == 0)
                param5.Value = DBNull.Value;
            else
                param5.Value = RISOrderdtl.MODALITY_ID;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@EXAM_DT";
            if (RISOrderdtl.EXAM_DT == DateTime.MinValue)
                param6.Value = DBNull.Value;
            else
                param6.Value = RISOrderdtl.EXAM_DT;

            //SqlParameter param7 = new SqlParameter();
            //param7.ParameterName = "@SERVICE_TYPE";
            //if (RISOrderdtl.SERVICE_TYPE == 0)
            //    param7.Value = DBNull.Value;
            //else
            //    param7.Value = RISOrderdtl.SERVICE_TYPE;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@QTY";
            //if (RISOrderdtl.QTY == 0)
            //    param8.Value = DBNull.Value;
            //else
            param8.Value = RISOrderdtl.QTY;

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "@ASSIGNED_TO";
            if (RISOrderdtl.ASSIGNED_TO == 0)
                param9.Value = DBNull.Value;
            else
                param9.Value = RISOrderdtl.ASSIGNED_TO;

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "@HL7_TEXT";
            if (RISOrderdtl.HL7_TEXT == null)
                param10.Value = DBNull.Value;
            else if (RISOrderdtl.HL7_TEXT.ToString() == string.Empty)
                param10.Value = DBNull.Value;
            else
                param10.Value = RISOrderdtl.HL7_TEXT;

            SqlParameter param11 = new SqlParameter();
            param11.ParameterName = "@HL7_SENT";
            if (RISOrderdtl.HL7_SENT == null)
                param11.Value = DBNull.Value;
            else if (RISOrderdtl.HL7_SENT.Trim() == string.Empty)
                param11.Value = DBNull.Value;
            else
                param11.Value = RISOrderdtl.HL7_SENT;

            SqlParameter param12 = new SqlParameter();
            param12.ParameterName = "@RATE";
            if (RISOrderdtl.RATE < 0)
                param12.Value = 0;
            else
                param12.Value = RISOrderdtl.RATE;

            SqlParameter param13 = new SqlParameter();
            param13.ParameterName = "@COMMENTS";
            if (RISOrderdtl.COMMENTS == null)
                param13.Value = DBNull.Value;
            else if (RISOrderdtl.COMMENTS.ToString().Trim() == string.Empty)
                param13.Value = DBNull.Value;
            else
                param13.Value = RISOrderdtl.COMMENTS;

            //SqlParameter param14 = new SqlParameter();
            //param14.ParameterName = "@SPECIAL_CLINIC";
            //if (RISOrderdtl.SPECIAL_CLINIC == null)
            //    param14.Value = DBNull.Value;
            //else if (RISOrderdtl.SPECIAL_CLINIC.ToString().Trim() == string.Empty)
            //    param14.Value = DBNull.Value;
            //else
            //    param14.Value = RISOrderdtl.SPECIAL_CLINIC;

            SqlParameter param15 = new SqlParameter();
            param15.ParameterName = "@IMAGE_CAPTURED_BY";
            if (RISOrderdtl.IMAGE_CAPTURED_BY == 0)
                param15.Value = DBNull.Value;
            else
                param15.Value = RISOrderdtl.IMAGE_CAPTURED_BY;

            SqlParameter param16 = new SqlParameter();
            param16.ParameterName = "@IMAGE_CAPTURED_ON";
            if (RISOrderdtl.IMAGE_CAPTURED_ON == DateTime.MinValue)
                param16.Value = DBNull.Value;
            else
                param16.Value = RISOrderdtl.IMAGE_CAPTURED_ON;

            SqlParameter param17 = new SqlParameter();
            param17.ParameterName = "@QA_BY";
            if (RISOrderdtl.QA_BY == 0)
                param17.Value = DBNull.Value;
            else
                param17.Value = RISOrderdtl.QA_BY;

            SqlParameter param18 = new SqlParameter();
            param18.ParameterName = "@QA_ON";
            if (RISOrderdtl.QA_ON == DateTime.MinValue)
                param18.Value = DBNull.Value;
            else
                param18.Value = RISOrderdtl.QA_ON;

            SqlParameter param19 = new SqlParameter();
            param19.ParameterName = "@ORG_ID";
            if (RISOrderdtl.ORG_ID == 0)
                param19.Value = DBNull.Value;
            else
                param19.Value = RISOrderdtl.ORG_ID;

            SqlParameter param20 = new SqlParameter();
            param20.ParameterName = "@LAST_MODIFIED_BY";
            if (RISOrderdtl.LAST_MODIFIED_BY == 0)
                param20.Value = DBNull.Value;
            else
                param20.Value = RISOrderdtl.LAST_MODIFIED_BY;

            SqlParameter param22 = new SqlParameter();
            param22.ParameterName = "@PRIORITY";
            if (RISOrderdtl.PRIORITY == string.Empty)
                param22.Value = DBNull.Value;
            else
                param22.Value = RISOrderdtl.PRIORITY;

            SqlParameter param23 = new SqlParameter();
            param23.ParameterName = "@EST_START_TIME";
            if (RISOrderdtl.EST_START_TIME == DateTime.MinValue)
                param23.Value = DBNull.Value;
            else
                param23.Value = RISOrderdtl.EST_START_TIME;

            SqlParameter param24 = new SqlParameter();
            param24.ParameterName = "@IS_DELETED";
            param24.Value = RISOrderdtl.IS_DELETED;

            SqlParameter param25 = new SqlParameter();
            param25.ParameterName = "@CLINIC_TYPE";
            if (RISOrderdtl.Clinic_type == 0)
                param25.Value = DBNull.Value;
            else
                param25.Value = RISOrderdtl.Clinic_type;

            SqlParameter param26 = new SqlParameter();
            param26.ParameterName = "@BPVIEW_ID";
            if (RISOrderdtl.BV_VIEW == 0)
                param26.Value = DBNull.Value;
            else
                param26.Value = RISOrderdtl.BV_VIEW;

            //SqlParameter param27 = new SqlParameter();
            //param27.ParameterName = "@HIS_SYNC";
            //if (RISOrderdtl.HIS_SYNC == null)
            //    param27.Value = DBNull.Value;
            //else if (RISOrderdtl.HIS_SYNC.ToString().Trim() == string.Empty)
            //    param27.Value = DBNull.Value;
            //else
            //    param27.Value = RISOrderdtl.HIS_SYNC;

            SqlParameter[] parameters ={
                param1      ,param21    ,param2    ,param3  ,param4 
                 ,param5    ,param6     ,param8    ,param9  ,param10
                 ,param11   ,param12    ,param13   ,param15 ,param16
                 ,param17   ,param18    ,param19   ,param20 ,param22 
                ,param23    ,param24    ,param25, param26  // ,param27
             };
            Parameters = parameters;
        }
        public void BuildUpdateFlag(int order_ID, string flag)
        {
            SqlParameter pOrderID = new SqlParameter("@ORDER_ID", order_ID);
            SqlParameter pIS_DELETED = new SqlParameter("@IS_DELETED", flag);
            Parameters = new SqlParameter[] { pOrderID,pIS_DELETED };
        }
        public void BuildUpdateHL7Text(string ACCESSION_NO, string HL7_TEXT)
        {
            SqlParameter pAccessionNo = new SqlParameter("@ACCESSION_NO", ACCESSION_NO);
            SqlParameter pHl7 = new SqlParameter("@HL7_TEXT", HL7_TEXT);
            Parameters = new SqlParameter[] { pAccessionNo, pHl7 };
        }
        public void BuildUpdateStatus() {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ACCESSION_NO",_risorderdtl.ACCESSION_NO)
                ,new SqlParameter("@STATUS",_risorderdtl.STATUS)
                ,new SqlParameter("@UserID",_risorderdtl.CREATED_BY)
            };
            Parameters = param;
        }
    }
    public class RISOrderdtlUpdateSendBillParameter
    {
        private RISOrderdtl _risorderdtl;
        private SqlParameter[] _parameters;

        public RISOrderdtl RISOrderdtl
        {
            get { return _risorderdtl; }
            set { _risorderdtl = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public RISOrderdtlUpdateSendBillParameter(RISOrderdtl risorderdtl)
        {
            _risorderdtl = risorderdtl;
            Build();
        }
        public void Build()
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ACCESSION_NO",_risorderdtl.ACCESSION_NO)
                ,new SqlParameter("@HIS_SYNC",_risorderdtl.HIS_SYNC)
                ,new SqlParameter("@HIS_ACK",_risorderdtl.HIS_ACK)
            };
            Parameters = param;

        }
    }
}