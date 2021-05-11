//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/02/2552 09:05:20
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISScheduleInsertData : DataAccessBase 
	{
		private RISSchedule	_risschedule;
		private RISScheduleInsertDataParameters	param;
		public  RISScheduleInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Insert.ToString();
		}
		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public bool Add()
		{
			param= new RISScheduleInsertDataParameters(RISSchedule);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RISSchedule.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count-1].Rows[0][0].ToString());
            return true;
		}
        public void AddBlock() {
            param = new RISScheduleInsertDataParameters(RISSchedule,true);
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_InsertBlock.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RISSchedule.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString());
        }
	}
	public class RISScheduleInsertDataParameters 
	{
		private RISSchedule _risschedule;
		private SqlParameter[] _parameters;
		public RISScheduleInsertDataParameters(RISSchedule risschedule)
		{
			RISSchedule=risschedule;
			Build();
		}
        public RISScheduleInsertDataParameters(RISSchedule risschedule,bool useblock)
        {
            RISSchedule = risschedule;
            if (true)
                BuildBlock();
            else
                Build();
        }
		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param = new SqlParameter();
            param.Value = 0;
            param.ParameterName = "@SCHEDULE_ID";

            SqlParameter paramID = new SqlParameter();
            paramID.Value = RISSchedule.GEN_DTL_ID;
            paramID.ParameterName = "@GEN_DTL_ID";
            if (RISSchedule.GEN_DTL_ID == 0)
                paramID.Value = DBNull.Value;


            SqlParameter Appoint_DT = new SqlParameter();
            Appoint_DT.ParameterName = "@APPOINT_DT";
            if (RISSchedule.APPOINT_DT == DateTime.MinValue)
            {
                Appoint_DT.Value = DBNull.Value;
            }
            else
            {
                Appoint_DT.Value = RISSchedule.APPOINT_DT;
            }
            SqlParameter End_Datetime = new SqlParameter();
            End_Datetime.ParameterName = "@END_DATETIME";
            if (RISSchedule.END_DATETIME == DateTime.MinValue)
            {
                End_Datetime.Value = DBNull.Value;
            }
            else
            {
                End_Datetime.Value = RISSchedule.END_DATETIME;
            }
            SqlParameter LMP_DT = new SqlParameter();
            LMP_DT.ParameterName = "@LMP_DT";
            if (RISSchedule.LMP_DT == DateTime.MinValue)
            {
                LMP_DT.Value = DBNull.Value;
            }
            else
            {
                LMP_DT.Value = RISSchedule.LMP_DT;
            }

			SqlParameter[] parameters ={	
		        param
                ,new SqlParameter("@REG_ID",RISSchedule.REG_ID)
                ,new SqlParameter("@HN",RISSchedule.HN)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@EXAM_ID",RISSchedule.EXAM_ID)

                ,Appoint_DT
                ,new SqlParameter("@SCHEDULE_DATA",RISSchedule.SCHEDULE_DATA)
                ,new SqlParameter("@BLOCK_REASON",RISSchedule.BLOCK_REASON)
                ,new SqlParameter("@SCHEDULE_DT",RISSchedule.SCHEDULE_DT)
                ,End_Datetime

                ,new SqlParameter("@REF_UNIT",RISSchedule.REF_UNIT)
                ,new SqlParameter("@REF_DOC",RISSchedule.REF_DOC)
                ,new SqlParameter("@REASON",RISSchedule.REASON)
                ,new SqlParameter("@SCHEDULE_STATUS",RISSchedule.SCHEDULE_STATUS)
                ,new SqlParameter("@ORG_ID",RISSchedule.ORG_ID)

                ,new SqlParameter("@CREATED_BY",RISSchedule.CREATED_BY)
                ,new SqlParameter("@CLINIC_TYPE",RISSchedule.CLINIC_TYPE)
                ,new SqlParameter("@RATE",RISSchedule.RATE)
                ,paramID
                ,new SqlParameter("@RAD_ID",RISSchedule.RAD_ID)
                ,new SqlParameter("@PAT_STATUS",RISSchedule.PATSTATUS_ID)
                ,LMP_DT
                ,new SqlParameter("@QTY",RISSchedule.QTY)
                ,new SqlParameter("@SESSION_ID",RISSchedule.SESSION_ID)
			};
			_parameters = parameters;
		}
        public void BuildBlock()
        {
            SqlParameter Appoint_DT = new SqlParameter();
            Appoint_DT.ParameterName = "@APPOINT_DT";
            if (RISSchedule.APPOINT_DT == DateTime.MinValue)
            {
                Appoint_DT.Value = DBNull.Value;
            }
            else
            {
                Appoint_DT.Value = RISSchedule.APPOINT_DT;
            }
            SqlParameter End_Datetime = new SqlParameter();
            End_Datetime.ParameterName = "@END_DATETIME";
            if (RISSchedule.END_DATETIME == DateTime.MinValue)
            {
                End_Datetime.Value = DBNull.Value;
            }
            else
            {
                End_Datetime.Value = RISSchedule.END_DATETIME;
            }

            SqlParameter[] parameters ={	
		        new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,Appoint_DT
                ,new SqlParameter("@SCHEDULE_DATA",RISSchedule.SCHEDULE_DATA)
                ,End_Datetime
                ,new SqlParameter("@REASON",RISSchedule.REASON)
                ,new SqlParameter("@SCHEDULE_STATUS",RISSchedule.SCHEDULE_STATUS)
                ,new SqlParameter("@ORG_ID",RISSchedule.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISSchedule.CREATED_BY)
              
			};
            _parameters = parameters;
        }
	}
}

