//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    24/04/2009 01:28:07
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
	public class RISExamresultlegacySelectData : DataAccessBase 
	{
		private RISExamresultlegacy _risexamresultlegacy;
		private RISExamresultlegacySelectDataParameters param;
		public  RISExamresultlegacySelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTLEGACY_Select.ToString();
		}
        public RISExamresultlegacy RISExamresultlegacy
		{
			get{return _risexamresultlegacy;}
			set{_risexamresultlegacy=value;}
		}
		public DataSet GetData()
		{
			param = new RISExamresultlegacySelectDataParameters(RISExamresultlegacy);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
        public DataTable GetArchive()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTLEGACY_Select.ToString();
            RISExamresultlegacySelectDataParameters param = new RISExamresultlegacySelectDataParameters(RISExamresultlegacy);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds.Tables[0];
        }
	}
	public class RISExamresultlegacySelectDataParameters 
	{
        private RISExamresultlegacy _risexamresultlegacy;
		private SqlParameter[] _parameters;
        public RISExamresultlegacySelectDataParameters(RISExamresultlegacy risexamresultlegacy)
		{
			RISExamresultlegacy=risexamresultlegacy;
			Build();
		}
        public RISExamresultlegacy RISExamresultlegacy
		{
			get{return _risexamresultlegacy;}
			set{_risexamresultlegacy=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={			
//new SqlParameter("@EXAMRESULTLEGACY_ID",RISExamresultlegacy.EXAMRESULTLEGACY_ID)
//,new SqlParameter("@ACCESSION_NO",RISExamresultlegacy.ACCESSION_NO)
//,new SqlParameter("@ORDER_UID",RISExamresultlegacy.ORDER_UID)
//,new SqlParameter("@EXAM_UID",RISExamresultlegacy.EXAM_UID)
//,new SqlParameter("@RESULT_TEXT_HTML",RISExamresultlegacy.RESULT_TEXT_HTML)
			
//,new SqlParameter("@RESULT_STATUS",RISExamresultlegacy.RESULT_STATUS)
//,new SqlParameter("@RELEASED_BY",RISExamresultlegacy.RELEASED_BY)
//,new SqlParameter("@RELEASED_ON",RISExamresultlegacy.RELEASED_ON)
//,new SqlParameter("@FINALIZED_BY",RISExamresultlegacy.FINALIZED_BY)
//,new SqlParameter("@FINALIZED_ON",RISExamresultlegacy.FINALIZED_ON)
			
//,new SqlParameter("@CREATED_BY",RISExamresultlegacy.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultlegacy.CREATED_ON)
                    new SqlParameter("@MODE",RISExamresultlegacy.MODE),
                    new SqlParameter("@HN",RISExamresultlegacy.HN),
                    //new SqlParameter("@EMP_ID",RISExamresultlegacy.EMP_ID),
                    new SqlParameter("@FROM_DATE",RISExamresultlegacy.FROM_DATE ),
                    new SqlParameter("@TO_DATE",RISExamresultlegacy.TO_DATE),
			};
			_parameters=parameters;
		}
	}
}

