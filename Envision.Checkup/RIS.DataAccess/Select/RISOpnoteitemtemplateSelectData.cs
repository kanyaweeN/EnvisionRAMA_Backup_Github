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

namespace RIS.DataAccess.Select
{
	public class RISOpnoteitemtemplateSelectData : DataAccessBase 
	{
		private RISOpnoteitemtemplate	_risopnoteitemtemplate;
		private RISOpnoteitemtemplateInsertDataParameters	_risopnoteitemtemplateinsertdataparameters;
		public  RISOpnoteitemtemplateSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_OPNOTEITEMTEMPLATE_Select.ToString();
		}
		public  RISOpnoteitemtemplate	RISOpnoteitemtemplate
		{
			get{return _risopnoteitemtemplate;}
			set{_risopnoteitemtemplate=value;}
		}
		public DataSet GetData()
		{
			_risopnoteitemtemplateinsertdataparameters = new RISOpnoteitemtemplateInsertDataParameters(RISOpnoteitemtemplate);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risopnoteitemtemplateinsertdataparameters.Parameters);
			return ds;
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
//new SqlParameter("@OP_ITEM_ID",RISOpnoteitemtemplate.OP_ITEM_ID)
new SqlParameter("@EXAM_ID",RISOpnoteitemtemplate.EXAM_ID)
//,new SqlParameter("@ITEM_VALUE",RISOpnoteitemtemplate.ITEM_VALUE)
//,new SqlParameter("@ITEM_UNIT",RISOpnoteitemtemplate.ITEM_UNIT)
,new SqlParameter("@OPNOTE_TYPE",RISOpnoteitemtemplate.OPNOTE_TYPE)
			
//,new SqlParameter("@IS_DELETED",RISOpnoteitemtemplate.IS_DELETED)
//,new SqlParameter("@IS_ACTIVE",RISOpnoteitemtemplate.IS_ACTIVE)
//,new SqlParameter("@CREATED_BY",RISOpnoteitemtemplate.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISOpnoteitemtemplate.CREATED_ON)
,new SqlParameter("@REG_ID",RISOpnoteitemtemplate.LAST_MODIFIED_BY) //LAST_MODIFIED_BY is @REG_ID in prc 
			
//,new SqlParameter("@LAST_MODIFIED_ON",RISOpnoteitemtemplate.LAST_MODIFIED_ON)
			};
            Parameters = parameters;
		}
	}
}

