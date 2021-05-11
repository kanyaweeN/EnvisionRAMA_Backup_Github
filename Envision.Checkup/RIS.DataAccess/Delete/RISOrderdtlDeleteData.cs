//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    24/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISOrderdtlDeleteData : DataAccessBase 
	{
		private RISOrderdtl	_risorderdtl;
		private RISOrderdtlInsertDataParameters	_risorderdtlinsertdataparameters;
		public  RISOrderdtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERDTL_Delete.ToString();
		}
		public  RISOrderdtl	RISOrderdtl
		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public void Delete()
		{
			_risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risorderdtlinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _risorderdtlinsertdataparameters = new RISOrderdtlInsertDataParameters(RISOrderdtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _risorderdtlinsertdataparameters.Parameters);
        } 
	}
	public class RISOrderdtlInsertDataParameters 
	{
		private RISOrderdtl _risorderdtl;
		private SqlParameter[] _parameters;
		public RISOrderdtlInsertDataParameters(RISOrderdtl risorderdtl)
		{
			RISOrderdtl=risorderdtl;
			Build();
		}
		public  RISOrderdtl	RISOrderdtl
		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 
                new SqlParameter("@ORDER_ID",RISOrderdtl.ORDER_ID)
                ,new SqlParameter("@EXAM_ID",RISOrderdtl.EXAM_ID)
            };
			Parameters = parameters;
		}
	}
}

