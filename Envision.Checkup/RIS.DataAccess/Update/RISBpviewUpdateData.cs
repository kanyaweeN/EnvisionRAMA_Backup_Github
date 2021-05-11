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

namespace RIS.DataAccess.Update
{
	public class RISBpviewUpdateData : DataAccessBase 
	{
		private RISBpview	_risbpview;
		private RISBpviewInsertDataParameters	_risbpviewinsertdataparameters;
		public  RISBpviewUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_BPVIEW_Update.ToString();
		}
		public  RISBpview	RISBpview
		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public void Update()
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
//new SqlParameter("@BPVIEW_UID",RISBpview.BPVIEW_UID)
//,new SqlParameter("@BPVIEW_NAME",RISBpview.BPVIEW_NAME)
//,new SqlParameter("@BPVIEW_DESC",RISBpview.BPVIEW_DESC)
//,new SqlParameter("@NO_OF_EXAM",RISBpview.NO_OF_EXAM)
//,new SqlParameter("@IS_UPDATED",RISBpview.IS_UPDATED)
//,new SqlParameter("@IS_DELETED",RISBpview.IS_DELETED)
//,new SqlParameter("@ORG_ID",RISBpview.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISBpview.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISBpview.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISBpview.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISBpview.LAST_MODIFIED_ON)
			};
            Parameters = parameters;
		}
	}
}

