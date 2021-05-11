//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class RISReleasemediaUpdateData : DataAccessBase 
	{
		private RISReleasemedia	_risreleasemedia;
		private RISReleasemediaUpdateDataParameters param;
		public  RISReleasemediaUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_RELEASEMEDIA_Update.ToString();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public bool Update()
		{
			param= new RISReleasemediaUpdateDataParameters(RISReleasemedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISReleasemediaUpdateDataParameters 
	{
		private RISReleasemedia _risreleasemedia;
		private SqlParameter[] _parameters;
		public RISReleasemediaUpdateDataParameters(RISReleasemedia risreleasemedia)
		{
			RISReleasemedia=risreleasemedia;
			Build();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter Release_Date = new SqlParameter();
            Release_Date.ParameterName = "@RELEASE_DATE";
            if (RISReleasemedia.RELEASE_DATE == DateTime.MinValue)
            {
                Release_Date.Value = DateTime.Now;
            }
            else
            {
                Release_Date.Value = RISReleasemedia.RELEASE_DATE;
            }

            SqlParameter Request_By = new SqlParameter();
            Request_By.ParameterName = "@REQUEST_BY";
            if (RISReleasemedia.REQUEST_BY == "0")
            {
                Request_By.Value = "N";
            }
            else
            {
                Request_By.Value = RISReleasemedia.REQUEST_BY;
            }
            //SqlParameter Request_By_ID = new SqlParameter();
            //Request_By_ID.ParameterName = "@REQUEST_BY_ID";
            //if (RISReleasemedia.REQUEST_BY_ID == "0")
            //{
            //    Request_By_ID.Value = "Nothing";
            //}
            //else
            //{
            //    Request_By_ID.Value = RISReleasemedia.REQUEST_BY_ID;
            //}
            SqlParameter MediaType = new SqlParameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (RISReleasemedia.MEDIA_TYPE == "0" || RISReleasemedia.MEDIA_TYPE == null)
            {
                MediaType.Value = "0";
            }
            else
            {
                MediaType.Value = RISReleasemedia.MEDIA_TYPE;
            }

            SqlParameter Reason = new SqlParameter();
            Reason.ParameterName = "@REASON";
            if (RISReleasemedia.REASON == "0" || RISReleasemedia.REASON == null)
            {
                Reason.Value = "N";
            }
            else
            {
                Reason.Value = RISReleasemedia.REASON;
            }

			SqlParameter[] parameters ={
new SqlParameter("@RELEASE_ID",RISReleasemedia.RELEASE_ID)
,new SqlParameter("@HN",RISReleasemedia.HN)
,Release_Date
,Request_By
,new SqlParameter("@REQUEST_BY_ID",RISReleasemedia.REQUEST_BY_ID)
,MediaType
,new SqlParameter("@RECEIVED_BY",RISReleasemedia.RECEIVED_BY)
,Reason
,new SqlParameter("@COMMENT",RISReleasemedia.COMMENT)
,new SqlParameter("@UNIT_ID",RISReleasemedia.UNIT_ID)
,new SqlParameter("@LAST_MODIFIED_BY",RISReleasemedia.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
	}
}

