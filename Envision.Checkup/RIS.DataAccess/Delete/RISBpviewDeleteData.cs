//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    31/03/2552 02:52:51
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISBpviewDeleteData : DataAccessBase 
	{
		private RISBpview	_risbpview;
		private RISBpviewInsertDataParameters	_risbpviewinsertdataparameters;
		public  RISBpviewDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_BPVIEW_Delete.ToString();
		}
		public  RISBpview	RISBpview
		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public void Delete()
		{
			_risbpviewinsertdataparameters = new RISBpviewInsertDataParameters(RISBpview);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risbpviewinsertdataparameters.Parameters);
		}
	}
	public class RISBpviewInsertDataParameters 
	{
		private RISBpview _risbpview;
		private SqlParameter[] _parameters;
		public RISBpviewInsertDataParameters(RISBpview risbpview)
		{
			RISBpview=risbpview;
			Build();
		}
		public  RISBpview	RISBpview
		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@BPVIEW_ID",RISBpview.BPVIEW_ID)
			};
			Parameters = parameters;
		}
	}
}

