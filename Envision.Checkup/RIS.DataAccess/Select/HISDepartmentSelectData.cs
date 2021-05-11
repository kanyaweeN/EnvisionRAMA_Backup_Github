//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class HISDepartmentSelectData : DataAccessBase 
	{
		private HISDepartment	_hisdepartment;
		private HISDepartmentInsertDataParameters	_hisdepartmentinsertdataparameters;
		public  HISDepartmentSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_HIS_DEPARTMENT_Select.ToString();
		}
		public  HISDepartment	HISDepartment
		{
			get{return _hisdepartment;}
			set{_hisdepartment=value;}
		}
		public DataSet GetData()
		{
            //_hisdepartmentinsertdataparameters = new HISDepartmentInsertDataParameters(HISDepartment);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString,_hisdepartmentinsertdataparameters.Parameters);
            DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
	}
	public class HISDepartmentInsertDataParameters 
	{
		private HISDepartment _hisdepartment;
		private SqlParameter[] _parameters;
		public HISDepartmentInsertDataParameters(HISDepartment hisdepartment)
		{
			HISDepartment=hisdepartment;
			Build();
		}
		public  HISDepartment	HISDepartment
		{
			get{return _hisdepartment;}
			set{_hisdepartment=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={new SqlParameter("@DEP_ID",HISDepartment.DEP_ID),new SqlParameter("@DEP_NAME",HISDepartment.DEP_NAME),new SqlParameter("@DEP_TEL",HISDepartment.DEP_TEL)};
			Parameters = parameters;
		}
	}
}

