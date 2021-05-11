//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISModalityexamSelectData : DataAccessBase 
	{
		private RISModalityexam	_rismodalityexam;
		private RISModalityexamInsertDataParameters	_rismodalityexaminsertdataparameters;
        private int action;

		public RISModalityexamSelectData()
		{
            _rismodalityexam = new RISModalityexam();
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Select.ToString();
            action = 0;
		}
        public RISModalityexamSelectData(bool selectAll)
        {
            if (selectAll)
            {
                _rismodalityexam = new RISModalityexam();
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_SelectAll.ToString();
                action = 1;
            }
            else {
                _rismodalityexam = new RISModalityexam();
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Select.ToString();
                action = 0;

            }
        }
        public RISModalityexamSelectData(int modalityID) { 
            _rismodalityexam = new RISModalityexam();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_SelectByModalityID.ToString();
            _rismodalityexam.MODALITY_ID = modalityID;
            action = 2;
        }

		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public DataSet GetData()
		{
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds=null;
            if (action == 0)
            {
                _rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam);
                ds = dbhelper.Run(base.ConnectionString, _rismodalityexaminsertdataparameters.Parameters);
            }
            else if (action == 1)
            {
                _rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam);
                ds = dbhelper.Run(base.ConnectionString);
            }
            else
            {
                _rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam.MODALITY_ID);
                ds = dbhelper.Run(base.ConnectionString,_rismodalityexaminsertdataparameters.Parameters);
            }
			return ds;
		}

        public DataSet GetReport_ModalityExam(int UserID)
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Select_rptModality.ToString();
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            _rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam.MODALITY_ID, UserID);
            ds = dbhelper.Run(base.ConnectionString,_rismodalityexaminsertdataparameters.Parameters);
			return ds;
		}
        public DataSet GetReport_ModalityExam_Para()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Select_rptModality_Para.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            //_rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam.MODALITY_ID, UserID);
            ds = dbhelper.Run(base.ConnectionString);
            
            return ds;
        }
	}
	public class RISModalityexamInsertDataParameters 
	{
		private RISModalityexam _rismodalityexam;
		private SqlParameter[] _parameters;
        public RISModalityexamInsertDataParameters(int  modalityID) {
            _rismodalityexam = new RISModalityexam();
            _rismodalityexam.MODALITY_ID = modalityID;
            BuildModality();
        }
        public RISModalityexamInsertDataParameters(int ModalityID, int UserID) {
                _rismodalityexam = new RISModalityexam();
                _rismodalityexam.MODALITY_ID = ModalityID;
                BuildReport(UserID);
        }
		public RISModalityexamInsertDataParameters(RISModalityexam rismodalityexam)
		{
			RISModalityexam=rismodalityexam;
			Build();
		}

		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={
                new SqlParameter("@MODALITY_EXAM_ID",RISModalityexam.MODALITY_EXAM_ID),
                new SqlParameter("@MODALITY_ID",RISModalityexam.MODALITY_ID),
                new SqlParameter("@EXAM_ID",RISModalityexam.EXAM_ID),
                //new SqlParameter(@TECH_BYPASS,RISModalityexam.TECH_BYPASS),
                //new SqlParameter(@QA_BYPASS,RISModalityexam.QA_BYPASS),
                new SqlParameter("@IS_ACTIVE",RISModalityexam.IS_ACTIVE),
                //new SqlParameter(@IS_DEFAULT_MODALITY,RISModalityexam.IS_DEFAULT_MODALITY),
                //new SqlParameter(@IS_UPDATED,RISModalityexam.IS_UPDATED),
                //new SqlParameter(@IS_DELETED,RISModalityexam.IS_DELETED),
                new SqlParameter("@ORG_ID",RISModalityexam.ORG_ID)
                //new SqlParameter(@CREATED_BY,RISModalityexam.CREATED_BY),
                //new SqlParameter(@CREATED_ON,RISModalityexam.CREATED_ON),
                //new SqlParameter(@LAST_MODIFIED_BY,RISModalityexam.LAST_MODIFIED_BY),
                //new SqlParameter(@LAST_MODIFIED_ON,RISModalityexam.LAST_MODIFIED_ON)};
            };
			Parameters = parameters;
		}
        public void BuildModality() {
            SqlParameter[] parameters ={ 
                new SqlParameter("@MODALITY_ID",RISModalityexam.MODALITY_ID)
            };
            Parameters = parameters;
        }
        public void BuildReport(int UserID)
        {
            SqlParameter[] parameters ={ 
                new SqlParameter("@MODALITY_ID",RISModalityexam.MODALITY_ID),
                new SqlParameter("@USER_ID",UserID)
            };
            Parameters = parameters;
        }
	}
   
}

