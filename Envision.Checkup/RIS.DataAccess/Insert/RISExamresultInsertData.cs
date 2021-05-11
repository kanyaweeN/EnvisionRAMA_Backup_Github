//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    09/04/2552 11:07:09
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
	public class RISExamresultInsertData : DataAccessBase 
	{
		private RISExamresult	_risexamresult;
		private RISExamresultInsertDataParameters	param;
		public  RISExamresultInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Reporting.ToString();
            //StoredProcedureName = "Prc_RIS_EXAMRESULT_Reporting_11";
            _risexamresult = new RISExamresult();
		}
		public  RISExamresult	RISExamresult
		{
			get{return _risexamresult;}
			set{_risexamresult=value;}
		}
		public bool Add()
		{
			param= new RISExamresultInsertDataParameters(RISExamresult);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            try
            {
                dbhelper.Run(param.Parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			return true;
		}
	}
	public class RISExamresultInsertDataParameters 
	{
		private RISExamresult _risexamresult;
		private SqlParameter[] _parameters;
		public RISExamresultInsertDataParameters(RISExamresult risexamresult)
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
                ,new SqlParameter("@ORDER_ID",RISExamresult.ORDER_ID)
                ,new SqlParameter("@EXAM_ID",RISExamresult.EXAM_ID)
                ,new SqlParameter("@RESULT_TEXT_HTML",RISExamresult.RESULT_TEXT_HTML)
                ,new SqlParameter("@RESULT_TEXT_PLAIN",RISExamresult.RESULT_TEXT_PLAIN)
                ,new SqlParameter("@RESULT_TEXT_RTF",RISExamresult.RESULT_TEXT_RTF)
                ,new SqlParameter("@RESULT_STATUS",RISExamresult.RESULT_STATUS)
                ,new SqlParameter("@HL7_TEXT",RISExamresult.HL7_TEXT)
                ,new SqlParameter("@HL7_SEND",RISExamresult.HL7_SEND)
                ,new SqlParameter("@ICD_ID",RISExamresult.ICD_ID)
                ,new SqlParameter("@RELEASED_BY",RISExamresult.RELEASED_BY)
                ,new SqlParameter("@FINALIZED_BY",RISExamresult.FINALIZED_BY)
                ,new SqlParameter("@ORG_ID",RISExamresult.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISExamresult.CREATED_BY)
                ,new SqlParameter("@SEVERITY_ID",RISExamresult.SEVERITY_ID)
			};
			_parameters = parameters;
		}
	}
}

