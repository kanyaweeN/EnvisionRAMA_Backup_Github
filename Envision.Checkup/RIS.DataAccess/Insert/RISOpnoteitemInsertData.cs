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

namespace RIS.DataAccess.Insert
{
	public class RISOpnoteitemInsertData : DataAccessBase 
	{
		private RISOpnoteitem	_risopnoteitem;
		private RISOpnoteitemInsertDataParameters	_risopnoteiteminsertdataparameters;
		public  RISOpnoteitemInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_OPNOTEITEM_Insert.ToString();
		}
		public  RISOpnoteitem	RISOpnoteitem
		{
			get{return _risopnoteitem;}
			set{_risopnoteitem=value;}
		}
		public void Add()
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
new SqlParameter("@OP_ITEM_UID",RISOpnoteitem.OP_ITEM_UID)
,new SqlParameter("@OP_ITEM_NAME",RISOpnoteitem.OP_ITEM_NAME)
,new SqlParameter("@UNIT_ID",RISOpnoteitem.UNIT_ID)
//,new SqlParameter("@IS_DELETED",RISOpnoteitem.IS_DELETED)
,new SqlParameter("@IS_ACTIVE",RISOpnoteitem.IS_ACTIVE)
,new SqlParameter("@CREATED_BY",RISOpnoteitem.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISOpnoteitem.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",RISOpnoteitem.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISOpnoteitem.LAST_MODIFIED_ON)
			};
			Parameters = parameters;
		}
	}
}

