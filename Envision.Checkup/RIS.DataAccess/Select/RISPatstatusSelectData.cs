//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    29/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISPatstatusSelectData : DataAccessBase 
	{
		private RISPatstatus	_rispatstatus;
		private RISPatstatusInsertDataParameters	_rispatstatusinsertdataparameters;
		public  RISPatstatusSelectData()
		{
            _rispatstatus = new RISPatstatus();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATSTATUS_Select.ToString();
		}
		public  RISPatstatus	RISPatstatus
		{
			get{return _rispatstatus;}
			set{_rispatstatus=value;}
		}
		public DataSet GetData()
		{
            //_rispatstatusinsertdataparameters = new RISPatstatusInsertDataParameters(RISPatstatus);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //DataSet ds = dbhelper.Run(base.ConnectionString,_rispatstatusinsertdataparameters.Parameters);
            DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
	}
	public class RISPatstatusInsertDataParameters 
	{
		private RISPatstatus _rispatstatus;
		private SqlParameter[] _parameters;
		public RISPatstatusInsertDataParameters(RISPatstatus rispatstatus)
		{
			RISPatstatus=rispatstatus;
			Build();
		}
		public  RISPatstatus	RISPatstatus
		{
			get{return _rispatstatus;}
			set{_rispatstatus=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            //SqlParameter[] parameters ={new SqlParameter("@STATUS_ID",RISPatstatus.STATUS_ID),new SqlParameter("@STATUS_UID",RISPatstatus.STATUS_UID),new SqlParameter("@STATUS_TEXT",RISPatstatus.STATUS_TEXT),new SqlParameter("@IS_ACTIVE",RISPatstatus.IS_ACTIVE),new SqlParameter("@ORG_ID",RISPatstatus.ORG_ID)
            //,new SqlParameter("@CREATED_BY",RISPatstatus.CREATED_BY),new SqlParameter("@CREATED_ON",RISPatstatus.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISPatstatus.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISPatstatus.LAST_MODIFIED_ON)};
            //Parameters = parameters;
		}
	}
}

