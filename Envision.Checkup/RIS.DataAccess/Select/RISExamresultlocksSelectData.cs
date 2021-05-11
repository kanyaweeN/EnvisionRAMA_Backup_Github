//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/05/2552 03:39:04
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
	public class RISExamresultlocksSelectData : DataAccessBase 
	{
		private RISExamresultlocks	_risexamresultlocks;
		private RISExamresultlocksSelectDataParameters param;
		public  RISExamresultlocksSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTLOCKS_Select.ToString();
		}
		public  RISExamresultlocks	RISExamresultlocks
		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public DataSet GetData()
		{
			param = new RISExamresultlocksSelectDataParameters(RISExamresultlocks);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
        public DataSet GetData_DateRange()
        {
            param = new RISExamresultlocksSelectDataParameters(RISExamresultlocks);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
            return ds;
        }
	}
	public class RISExamresultlocksSelectDataParameters 
	{
		private RISExamresultlocks _risexamresultlocks;
		private SqlParameter[] _parameters;
		public RISExamresultlocksSelectDataParameters(RISExamresultlocks risexamresultlocks)
		{
			RISExamresultlocks=risexamresultlocks;
			Build();
		}
		public  RISExamresultlocks	RISExamresultlocks
		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            DateTime fd = RISExamresultlocks.FROM_DATE <= DateTime.MinValue ? DateTime.Now : RISExamresultlocks.FROM_DATE;
            DateTime td = RISExamresultlocks.TO_DATE <= DateTime.MinValue ? DateTime.Now : RISExamresultlocks.TO_DATE;

			SqlParameter[] parameters ={			
//new SqlParameter("@ACCESSION_NO",RISExamresultlocks.ACCESSION_NO)
//,new SqlParameter("@SL_NO",RISExamresultlocks.SL_NO)
//,new SqlParameter("@IS_LOCKED",RISExamresultlocks.IS_LOCKED)
//,new SqlParameter("@WORKING_RAD",RISExamresultlocks.WORKING_RAD)
//,new SqlParameter("@UNLOCKED_BY",RISExamresultlocks.UNLOCKED_BY)
			
//,new SqlParameter("@UNLOCKED_ON",RISExamresultlocks.UNLOCKED_ON)
//,new SqlParameter("@ORG_ID",RISExamresultlocks.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISExamresultlocks.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultlocks.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamresultlocks.LAST_MODIFIED_BY)
			
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresultlocks.LAST_MODIFIED_ON)  
                new SqlParameter("@MODE",RISExamresultlocks.MODE)
                ,new SqlParameter("@FROM_DATE",fd)
                ,new SqlParameter("@TO_DATE",td)
			};
			_parameters=parameters;
		}
	}
}

