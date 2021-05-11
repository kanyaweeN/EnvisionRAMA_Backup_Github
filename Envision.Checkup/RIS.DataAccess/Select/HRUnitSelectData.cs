//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    23/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class HRUnitSelectData : DataAccessBase 
	{
		private HRUnit	_hrunit;
		private HRUnitInsertDataParameters	_hrunitinsertdataparameters;
		public  HRUnitSelectData()
		{
            _hrunit = new HRUnit();
            StoredProcedureName = StoredProcedure.Name.Prc_HR_UNIT_Select.ToString();
		}
		public  HRUnit	HRUnit
		{
			get{return _hrunit;}
			set{_hrunit=value;}
		}
		public DataSet GetData()
		{
			//_hrunitinsertdataparameters = new HRUnitInsertDataParameters(HRUnit);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString);//,_hrunitinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class HRUnitInsertDataParameters 
	{
		private HRUnit _hrunit;
		private SqlParameter[] _parameters;
		public HRUnitInsertDataParameters(HRUnit hrunit)
		{
			HRUnit=hrunit;
			Build();
		}
		public  HRUnit	HRUnit
		{
			get{return _hrunit;}
			set{_hrunit=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={new SqlParameter("@UNIT_ID",HRUnit.UNIT_ID),new SqlParameter("@UNIT_UID",HRUnit.UNIT_UID),new SqlParameter("@UNIT_ID_PARENT",HRUnit.UNIT_ID_PARENT),new SqlParameter("@UNIT_NAME",HRUnit.UNIT_NAME),new SqlParameter("@UNIT_NAME_ALIAS",HRUnit.UNIT_NAME_ALIAS)
			,new SqlParameter("@PHONE_NO",HRUnit.PHONE_NO),new SqlParameter("@DESCR",HRUnit.DESCR),new SqlParameter("@UNIT_ALIAS",HRUnit.UNIT_ALIAS),new SqlParameter("@UNIT_TYPE",HRUnit.UNIT_TYPE),new SqlParameter("@LOC",HRUnit.LOC)
			,new SqlParameter("@CREATED_BY",HRUnit.CREATED_BY),new SqlParameter("@CREATED_ON",HRUnit.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",HRUnit.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",HRUnit.LAST_MODIFIED_ON),new SqlParameter("@ORG_ID",HRUnit.ORG_ID)};
			Parameters = parameters;
		}
	}
}

