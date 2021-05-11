//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    21/10/2551 09:57:29
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class XRAYREQUpdateData : DataAccessBase 
	{
		private XRAYREQ	_xrayreq;
		private XRAYREQInsertDataParameters	_xrayreqinsertdataparameters;
		public  XRAYREQUpdateData()
		{
            _xrayreq = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Name.Prc_XRAYREQ_UpdateStatus.ToString();
		}
		public  XRAYREQ	XRAYREQ
		{
			get{return _xrayreq;}
			set{_xrayreq=value;}
		}
		public void Update()
		{
			_xrayreqinsertdataparameters = new XRAYREQInsertDataParameters(XRAYREQ);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_xrayreqinsertdataparameters.Parameters);
		}
        public void Update(SqlTransaction tran)
        {
            _xrayreqinsertdataparameters = new XRAYREQInsertDataParameters(XRAYREQ);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _xrayreqinsertdataparameters.Parameters);
        }
	}
	public class XRAYREQInsertDataParameters 
	{
		private XRAYREQ _xrayreq;
		private SqlParameter[] _parameters;
		public XRAYREQInsertDataParameters(XRAYREQ xrayreq)
		{
			XRAYREQ=xrayreq;
			Build();
		}
		public  XRAYREQ	XRAYREQ
		{
			get{return _xrayreq;}
			set{_xrayreq=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@ORDER_ID",XRAYREQ.ORDER_ID)
			};
            Parameters = parameters;
		}
	}
}

