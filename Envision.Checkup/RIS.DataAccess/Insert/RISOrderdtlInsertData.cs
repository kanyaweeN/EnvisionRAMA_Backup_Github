//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    24/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISOrderdtlInsertData : DataAccessBase 
	{
		private RISOrderdtl	_risorderdtl;
		private RISOrderdtlInsertDataParameters	_risorderdtlinsertdataparameters;
		public  RISOrderdtlInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_Insert.ToString();
		}
		public  RISOrderdtl	RISOrderdtl
		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public void Add()
		{
			_risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString,_risorderdtlinsertdataparameters.Parameters);
		}
        public void Add(SqlTransaction tran) {
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _risorderdtlinsertdataparameters.Parameters);
        }
	}
	public class RISOrderdtlInsertDataParameters 
	{
		private RISOrderdtl _risorderdtl;
		private SqlParameter[] _parameters;
		public RISOrderdtlInsertDataParameters(RISOrderdtl risorderdtl)
		{
			RISOrderdtl=risorderdtl;
			Build();
		}
		public  RISOrderdtl	RISOrderdtl
		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param1 = new SqlParameter("@ORDER_ID",RISOrderdtl.ORDER_ID);
            
            SqlParameter param2 = new SqlParameter("@EXAM_ID", RISOrderdtl.EXAM_ID);
            
            SqlParameter param3 = new SqlParameter("@ACCESSION_NO", RISOrderdtl.ACCESSION_NO);
            
            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Q_NO";
            if (RISOrderdtl.Q_NO == 0)
                param4.Value = DBNull.Value;
            else
                param4.Value = RISOrderdtl.Q_NO;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName="@MODALITY_ID";
            if(RISOrderdtl.MODALITY_ID==0)
                param5.Value = DBNull.Value;
            else
                param5.Value = RISOrderdtl.MODALITY_ID;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName="@EXAM_DT";
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
            if (RISOrderdtl.HL7_TEXT ==null)
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
            if (RISOrderdtl.RATE < 0 )
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
            if (RISOrderdtl.IMAGE_CAPTURED_BY==0)
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
            param20.ParameterName = "@CREATED_BY";
            if (RISOrderdtl.CREATED_BY == 0)
                param20.Value = DBNull.Value;
            else
                param20.Value = RISOrderdtl.CREATED_BY;

            SqlParameter param21 = new SqlParameter();
            param21.ParameterName = "@PRIORITY";
            if (RISOrderdtl.PRIORITY == string.Empty)
                param21.Value = DBNull.Value;
            else
                param21.Value = RISOrderdtl.PRIORITY;

            SqlParameter param22 = new SqlParameter();
            param22.ParameterName = "@EST_START_TIME";
            if (RISOrderdtl.EST_START_TIME == DateTime.MinValue)
                param22.Value = DBNull.Value;
            else
                param22.Value = RISOrderdtl.EST_START_TIME;

            SqlParameter param23 = new SqlParameter();
            param23.ParameterName = "@CLINIC_TYPE";
            if (RISOrderdtl.Clinic_type == 0)
                param23.Value = DBNull.Value;
            else
                param23.Value = RISOrderdtl.Clinic_type;

            SqlParameter param24 = new SqlParameter();
            param24.ParameterName = "@BPVIEW_ID";
            if (RISOrderdtl.BV_VIEW == 0)
                param24.Value = DBNull.Value;
            else
                param24.Value = RISOrderdtl.BV_VIEW;

            //SqlParameter param25 = new SqlParameter();
            //param25.ParameterName = "@HIS_SYNC";
            //if (RISOrderdtl.HIS_SYNC == string.Empty)
            //    param25.Value = DBNull.Value;
            //else
            //    param25.Value = RISOrderdtl.HIS_SYNC;

            SqlParameter[] parameters ={
                param1      ,param2    ,param3
                ,param4     ,param5    ,param6
                /*,param7*/     ,param8    ,param9
                ,param10    ,param11   ,param12
                ,param13    //,param14   
                ,param15
                ,param16    ,param17   ,param18
                ,param19    ,param20   ,param21
                ,param22    ,param23,param24
                //,param25
            
            };
			Parameters = parameters;
		}
	}
}

