//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    02/03/2552 02:02:06
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISOpnoteitemDeleteData : DataAccessBase 
	{
		private RISOpnoteitem	_risopnoteitem;
		private RISOpnoteitemInsertDataParameters	_risopnoteiteminsertdataparameters;
		public  RISOpnoteitemDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_OPNOTEITEM_Delete.ToString();
		}
		public  RISOpnoteitem	RISOpnoteitem
		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public void Delete()
		{
			_risopnoteiteminsertdataparameters = new RISOpnoteitemInsertDataParameters(RISOpnoteitem);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risopnoteiteminsertdataparameters.Parameters);
		}
	}
	public class RISOpnoteitemInsertDataParameters 
	{
		private RISOpnoteitem _risopnoteitem;
		private SqlParameter[] _parameters;
		public RISOpnoteitemInsertDataParameters(RISOpnoteitem risopnoteitem)
		{
			RISOpnoteitem=risopnoteitem;
			Build();
		}
		public  RISOpnoteitem	RISOpnoteitem
		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@OP_ITEM_ID",RISOpnoteitem.OP_ITEM_ID)
,new SqlParameter("@LAST_MODIFIED_BY",RISOpnoteitem.LAST_MODIFIED_BY)
			};
			Parameters = parameters;
		}
	}
}

