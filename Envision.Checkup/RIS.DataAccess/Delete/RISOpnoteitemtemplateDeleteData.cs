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
	public class RISOpnoteitemtemplateDeleteData : DataAccessBase 
	{
		private RISOpnoteitemtemplate	_risopnoteitemtemplate;
		private RISOpnoteitemtemplateInsertDataParameters	_risopnoteitemtemplateinsertdataparameters;
		public  RISOpnoteitemtemplateDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_OPNOTEITEMTEMPLATE_Delete.ToString();
		}
		public  RISOpnoteitemtemplate	RISOpnoteitemtemplate
		{
			get{return _risopnoteitemtemplate;}
			set{_risopnoteitemtemplate=value;}
		}
		public void Delete()
		{
			_risopnoteitemtemplateinsertdataparameters = new RISOpnoteitemtemplateInsertDataParameters(RISOpnoteitemtemplate);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risopnoteitemtemplateinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _risopnoteitemtemplateinsertdataparameters = new RISOpnoteitemtemplateInsertDataParameters(RISOpnoteitemtemplate);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _risopnoteitemtemplateinsertdataparameters.Parameters);
        }
	}
	public class RISOpnoteitemtemplateInsertDataParameters 
	{
		private RISOpnoteitemtemplate _risopnoteitemtemplate;
		private SqlParameter[] _parameters;
		public RISOpnoteitemtemplateInsertDataParameters(RISOpnoteitemtemplate risopnoteitemtemplate)
		{
			RISOpnoteitemtemplate=risopnoteitemtemplate;
			Build();
		}
		public  RISOpnoteitemtemplate	RISOpnoteitemtemplate
		{
			get{return _risopnoteitemtemplate;}
			set{_risopnoteitemtemplate=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@OP_ITEM_ID",RISOpnoteitemtemplate.OP_ITEM_ID)
,new SqlParameter("@EXAM_ID",RISOpnoteitemtemplate.EXAM_ID)
,new SqlParameter("@OPNOTE_TYPE",RISOpnoteitemtemplate.OPNOTE_TYPE)
,new SqlParameter("@LAST_MODIFIED_BY",RISOpnoteitemtemplate.LAST_MODIFIED_BY)
			};
			Parameters = parameters;
		}
	}
}

