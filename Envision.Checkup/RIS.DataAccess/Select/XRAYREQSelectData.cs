//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/10/2551 02:56:42
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class XRAYREQSelectData : DataAccessBase 
	{
		private XRAYREQ	_xrayreq;
		private XRAYREQInsertDataParameters	_xrayreqinsertdataparameters;
		public  XRAYREQSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_XRAYREQ_Select.ToString();
		}
		public  XRAYREQ	XRAYREQ
		{
			get{return _xrayreq;}
			set{_xrayreq=value;}
		}
		public DataSet GetData(int SpType)
		{
			_xrayreqinsertdataparameters = new XRAYREQInsertDataParameters(XRAYREQ,SpType);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_xrayreqinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class XRAYREQInsertDataParameters 
	{
		private XRAYREQ _xrayreq;
        private int spType = 0;
		private SqlParameter[] _parameters;
		public XRAYREQInsertDataParameters(XRAYREQ xrayreq,int SpType)
		{
            spType = SpType;
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
                new SqlParameter("@SpType",spType)
                ,new SqlParameter("@ORDER_ID",XRAYREQ.ORDER_ID)

                //new SqlParameter("@ORDER_ID",XRAYREQ.ORDER_ID)
                //,new SqlParameter("@REQUESTNO",XRAYREQ.REQUESTNO)
                //,new SqlParameter("@HN",XRAYREQ.HN)
                //,new SqlParameter("@ORDER_DT",XRAYREQ.ORDER_DT)
                //,new SqlParameter("@INSURANCE_TYPE_ID",XRAYREQ.INSURANCE_TYPE_ID)
                			
                //,new SqlParameter("@ORDER_START_TIME",XRAYREQ.ORDER_START_TIME)
                //,new SqlParameter("@REF_UNIT",XRAYREQ.REF_UNIT)
                //,new SqlParameter("@REF_DOC",XRAYREQ.REF_DOC)
                //,new SqlParameter("@PAT_STATUS",XRAYREQ.PAT_STATUS)
                //,new SqlParameter("@REF_DOC_INSTRUCTION",XRAYREQ.REF_DOC_INSTRUCTION)
                			
                //,new SqlParameter("@CLINICAL_INSTRUCTION",XRAYREQ.CLINICAL_INSTRUCTION)
                //,new SqlParameter("@STATUS",XRAYREQ.STATUS)
			};
            Parameters = parameters;
		}
	}
}

