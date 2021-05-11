//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class INVPoSelectData : DataAccessBase 
	{
		private INVPo	_invpo;
		private INVPoInsertDataParameters	_invpoinsertdataparameters;
		public  INVPoSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PO_Select.ToString();
		}
		public  INVPo	INVPo
		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public DataSet GetData()
		{
			_invpoinsertdataparameters = new INVPoInsertDataParameters(INVPo);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_invpoinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class INVPoInsertDataParameters 
	{
		private INVPo _invpo;
		private SqlParameter[] _parameters;
		public INVPoInsertDataParameters(INVPo invpo)
		{
			INVPo=invpo;
			Build();
		}
		public  INVPo	INVPo
		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@PO_ID",INVPo.PO_ID)
//,new SqlParameter("@PO_UID",INVPo.PO_UID)
//,new SqlParameter("@PR_ID",INVPo.PR_ID)
//,new SqlParameter("@GENERATED_ON",INVPo.GENERATED_ON)
//,new SqlParameter("@VENDOR_ID",INVPo.VENDOR_ID)
			
//,new SqlParameter("@TOC",INVPo.TOC)
//,new SqlParameter("@PO_STATUS",INVPo.PO_STATUS)
//,new SqlParameter("@ORG_ID",INVPo.ORG_ID)
//,new SqlParameter("@CREATED_BY",INVPo.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVPo.CREATED_ON)
			
//,new SqlParameter("@LAST_MODIFIED_BY",INVPo.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVPo.LAST_MODIFIED_ON)
			};
		}
	}
}

