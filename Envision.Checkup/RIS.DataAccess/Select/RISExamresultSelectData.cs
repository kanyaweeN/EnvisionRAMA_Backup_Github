//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    26/03/2552 02:07:35
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISExamresultSelectData : DataAccessBase 
	{
		private RISExamresult	_risexamresult;
        
		public  RISExamresultSelectData()
		{
			//StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Select.ToString();
            StoredProcedureName = string.Empty;
		}
		
        public  RISExamresult	RISExamresult
		{
			get{return _risexamresult;}
			set{_risexamresult=value;}
		}
        public DataTable GetNextData(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Next.ToString();
            RISExamresultSelectNext param = new RISExamresultSelectNext(ACCESSION_NO);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataTable GetPreviousData(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Previous.ToString();
            RISExamresultSelectPrevious param = new RISExamresultSelectPrevious(ACCESSION_NO);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataTable GetWorkList()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_WorkList.ToString();
            RISExamresultSelectWorkListParameters param = new RISExamresultSelectWorkListParameters(RISExamresult);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds.Tables[0];
		}
        public DataSet   GetCaseAmount()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_CaseAmt.ToString();
            RISExamresultSelectWorkListParameters param = new RISExamresultSelectWorkListParameters(RISExamresult,true);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds;
        }
        public DataSet   GetHistory() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_History.ToString();
            RISExamresultSelectHistoryParameters param = new RISExamresultSelectHistoryParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds;
        }
        public DataTable GetArchive()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_BrowseArchive_Select.ToString();
            RISExamresultSelectBrowseArchiveParameters param = new RISExamresultSelectBrowseArchiveParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataTable GetTransfer()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Transfer_Select.ToString();
            RISExamresultSelectTransferParameters param = new RISExamresultSelectTransferParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataTable GetMergeData() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_MergeSelect.ToString();
            RISExamresultMergeParameters param = new RISExamresultMergeParameters(RISExamresult, true);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataTable GetExamResult() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Select.ToString();
            RISExamresultSelectResultParameters param = new RISExamresultSelectResultParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
        public DataSet GetExamNote()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTNOTE_Select.ToString();
            RISExamresultNoteSelectResultParameters param = new RISExamresultNoteSelectResultParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds;
        }

        public void UpdateTransfer()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Transfer_Update.ToString();
            RISExamresultUpdateTransferParameters param = new RISExamresultUpdateTransferParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object obj = dbhelper.RunScalar(base.ConnectionString, param.Parameters);
        }
        public void Merge() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_MergeSplit.ToString();
            RISExamresultMergeParameters param = new RISExamresultMergeParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object obj = dbhelper.RunScalar(base.ConnectionString, param.Parameters);
        }
        
	}
    public class RISExamresultSelectWorkListParameters { 
        private RISExamresult _risexamresult;
		private SqlParameter[] _parameters;

        public RISExamresultSelectWorkListParameters(RISExamresult risexamresult)
		{
			RISExamresult=risexamresult;
			Build();
		}
        public RISExamresultSelectWorkListParameters(RISExamresult risexamresult,bool CaseAmt)
        {
            RISExamresult = risexamresult;
            if (CaseAmt)
                BuildCaseAmt();
            else
                Build();
        }

		public  RISExamresult	RISExamresult
		{
			get{return _risexamresult;}
			set{_risexamresult=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}

		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@MODE",RISExamresult.MODE)
                ,new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
                ,new SqlParameter("@HN",RISExamresult.HN)
                ,new SqlParameter("@FROM_DT",RISExamresult.DATETIME_FROM)
                ,new SqlParameter("@TO_DT",RISExamresult.DATETIME_END)
                ,new SqlParameter("@STATUS",RISExamresult.STATUS)
			};
			_parameters=parameters;
		}
        public void BuildCaseAmt() {
            SqlParameter[] parameters ={			
                new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultSelectHistoryParameters { 
        private RISExamresult _risexamresult;
		private SqlParameter[] _parameters;

        public RISExamresultSelectHistoryParameters(RISExamresult risexamresult)
		{
			RISExamresult=risexamresult;
			Build();
		}

		public  RISExamresult	RISExamresult
		{
			get{return _risexamresult;}
			set{_risexamresult=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}

		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@ACCESSION_NO",RISExamresult.ACCESSION_NO)
                ,new SqlParameter("@HN",RISExamresult.HN)
                ,new SqlParameter("@ORDER_ID",RISExamresult.ORDER_ID)
                ,new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
			};
			_parameters=parameters;
		}
    }
    public class RISExamresultSelectBrowseArchiveParameters
    {
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultSelectBrowseArchiveParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@MODE",RISExamresult.MODE)
                ,new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
                ,new SqlParameter("@FROM_DT",RISExamresult.DATETIME_FROM)
                ,new SqlParameter("@TO_DT",RISExamresult.DATETIME_END)
                ,new SqlParameter("@HN",RISExamresult.HN)
			};
            _parameters = parameters;
        }
    }

    public class RISExamresultSelectTransferParameters
    {
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultSelectTransferParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@MODE",RISExamresult.MODE)
                ,new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultUpdateTransferParameters
    {
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultUpdateTransferParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={
                new SqlParameter("@ORDER_ID",RISExamresult.ORDER_ID)
                ,new SqlParameter("@EXAM_ID",RISExamresult.EXAM_ID)
                ,new SqlParameter("@ASSIGNED_TO",RISExamresult.EMP_ID)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultMergeParameters { 
        private RISExamresult _risexamresult;
		private SqlParameter[] _parameters;

        public RISExamresultMergeParameters(RISExamresult risexamresult)
		{
			RISExamresult=risexamresult;
			Build();
		}
        public RISExamresultMergeParameters(RISExamresult risexamresult,bool select)
        {
            RISExamresult = risexamresult;
            if (select)
                BuildSelect();
            else
                Build();
        }
		public  RISExamresult	RISExamresult
		{
			get{return _risexamresult;}
			set{_risexamresult=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}

		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter ("@MERGE"          ,RISExamresult.MERGE)
                ,new SqlParameter("@MERGE_WITH"     ,RISExamresult.MERGE_WITH)
                ,new SqlParameter("@ACCESSION_NO"   ,RISExamresult.ACCESSION_NO)
			};
			_parameters=parameters;
		}
        public void BuildSelect()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@ACCESSION_NO"   ,RISExamresult.ACCESSION_NO),
                 new SqlParameter("@MERGE"   ,RISExamresult.MERGE),
                 new SqlParameter("@MERGE_WITH"   ,RISExamresult.MERGE_WITH)
			};
            _parameters = parameters;
        }

    }

    public class RISExamresultSelectResultParameters
    {
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultSelectResultParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@ACCESSION_NO",RISExamresult.ACCESSION_NO)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultNoteSelectResultParameters
    {
        
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultNoteSelectResultParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@ACCESSION_NO",RISExamresult.ACCESSION_NO)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultSelectNext
    {
        private SqlParameter[] _parameters;

        public RISExamresultSelectNext(string ACCESSION_NO)
        {
            Build(ACCESSION_NO);
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build(string ACCESSION_NO)
        {
            SqlParameter[] parameters ={			
                 new SqlParameter("@ACCESSION_NO"   ,ACCESSION_NO)
			};
            _parameters = parameters;
        }
    }
    public class RISExamresultSelectPrevious
    {
        private SqlParameter[] _parameters;

        public RISExamresultSelectPrevious(string ACCESSION_NO)
        {
            Build(ACCESSION_NO);
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build(string ACCESSION_NO)
        {
            SqlParameter[] parameters ={			
                 new SqlParameter("@ACCESSION_NO"   ,ACCESSION_NO)
			};
            _parameters = parameters;
        }
    }
}

