//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:26
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISLoadmediaUpdateData : DataAccessBase 
	{
		private RISLoadmedia	_risloadmedia;
		private RISLoadmediaUpdateDataParameters param;
		public  RISLoadmediaUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIA_Update.ToString();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public bool Update()
		{
			param= new RISLoadmediaUpdateDataParameters(RISLoadmedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISLoadmediaUpdateDataParameters 
	{
		private RISLoadmedia _risloadmedia;
		private SqlParameter[] _parameters;
		public RISLoadmediaUpdateDataParameters(RISLoadmedia risloadmedia)
		{
			RISLoadmedia=risloadmedia;
			Build();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter LoadDT = new SqlParameter();
            LoadDT.ParameterName = "@LOAD_DT";
            if (RISLoadmedia.LOAD_DT == DateTime.MinValue)
            {
                LoadDT.Value = DateTime.Now;
            }
            else
            {
                LoadDT.Value = RISLoadmedia.LOAD_DT;
            }

            SqlParameter LoadStart = new SqlParameter();
            LoadStart.ParameterName = "@LOAD_START_TIME";
            if (RISLoadmedia.LOAD_START_TIME == DateTime.MinValue)
            {
                LoadStart.Value = DBNull.Value;
            }
            else
            {
                LoadStart.Value = RISLoadmedia.LOAD_START_TIME;
            }

            SqlParameter REQBy = new SqlParameter();
            REQBy.ParameterName = "@REQ_BY";
            if (RISLoadmedia.REQ_BY == "0")
            {
                REQBy.Value = DBNull.Value;
            }
            else
            {
                REQBy.Value = RISLoadmedia.REQ_BY;
            }

            SqlParameter MediaType = new SqlParameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (RISLoadmedia.MEDIA_TYPE == "0" || RISLoadmedia.MEDIA_TYPE == null)
            {
                MediaType.Value = "0";
            }
            else
            {
                MediaType.Value = RISLoadmedia.MEDIA_TYPE;
            }
            SqlParameter Reason = new SqlParameter();
            Reason.ParameterName = "@REASON";
            if (RISLoadmedia.REASON == "0" || RISLoadmedia.REASON == null)
            {
                Reason.Value = "N";
            }
            else
            {
                Reason.Value = RISLoadmedia.REASON;
            }

            SqlParameter createOn = new SqlParameter();
            if (RISLoadmedia.CREATED_ON == DateTime.MinValue)
                createOn.Value = DBNull.Value;
            else
                createOn.Value = RISLoadmedia.CREATED_ON;

            SqlParameter modifyOn = new SqlParameter();
            if (RISLoadmedia.LAST_MODIFIED_ON == DateTime.MinValue)
                modifyOn.Value = DBNull.Value;
            else
                modifyOn.Value = RISLoadmedia.LAST_MODIFIED_ON;

			SqlParameter[] parameters ={
new SqlParameter("@LOAD_ID" ,RISLoadmedia.LOAD_ID)
,new SqlParameter("@HN",RISLoadmedia.HN)
,new SqlParameter("@VISIT_NO",RISLoadmedia.VISIT_NO)
,new SqlParameter("@ADMISSION_NO",RISLoadmedia.ADMISSION_NO)
,LoadDT
,LoadStart
,REQBy
,new SqlParameter("@REQ_UNIT",RISLoadmedia.REQ_UNIT)
,new SqlParameter("@REQ_DOC",RISLoadmedia.REQ_DOC)
,MediaType
,Reason
,new SqlParameter("@COMMENT",RISLoadmedia.COMMENT)
,new SqlParameter("@CREATED_BY",RISLoadmedia.CREATED_BY)
,createOn
,new SqlParameter("@LAST_MODIFIED_BY",RISLoadmedia.LAST_MODIFIED_BY)
,modifyOn
			};
			_parameters = parameters;
		}
	}
}

