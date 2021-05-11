using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISTechworksUpdateData : DataAccessBase 
	{
		private RISTechworks	_ristechworks;
		private RISTechworksInsertDataParameters	_ristechworksinsertdataparameters;
		public  RISTechworksUpdateData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHWORKS_Update.ToString();
		}
		public  RISTechworks	RISTechworks
		{
			get{return _ristechworks;}
			set{_ristechworks=value;}
		}
		public void Update()
		{
			_ristechworksinsertdataparameters = new RISTechworksInsertDataParameters(RISTechworks);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_ristechworksinsertdataparameters.Parameters);
		}
	}
	public class RISTechworksInsertDataParameters 
	{
		private RISTechworks _ristechworks;
		private SqlParameter[] _parameters;
		public RISTechworksInsertDataParameters(RISTechworks ristechworks)
		{
			RISTechworks=ristechworks;
			Build();
		}
		public  RISTechworks	RISTechworks
		{
			get{return _ristechworks;}
			set{_ristechworks=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={
                new SqlParameter("@ACCESSION_ON",RISTechworks.ACCESSION_ON)
                ,new SqlParameter("@TAKE",RISTechworks.TAKE)
                ,new SqlParameter("@START_TIME",RISTechworks.START_TIME)
                ,new SqlParameter("@END_TIME",RISTechworks.END_TIME)
                ,new SqlParameter("@EXPOSURE_TECHNIQUE",RISTechworks.EXPOSURE_TECHNIQUE)
                ,new SqlParameter("@PROTOCOL",RISTechworks.PROTOCOL)
                ,new SqlParameter("@KV",RISTechworks.KV)
                ,new SqlParameter("@mA",RISTechworks.mA)
                ,new SqlParameter("@SEC",RISTechworks.SEC)
                ,new SqlParameter("@STATUS",RISTechworks.STATUS)
                ,new SqlParameter("@COMMENTS",RISTechworks.COMMENTS)
                ,new SqlParameter("@NO_OF_IMAGES",RISTechworks.NO_OF_IMAGES)
                ,new SqlParameter("@ORG_ID",RISTechworks.ORG_ID)
                ,new SqlParameter("@PERFORMANCED_BY",RISTechworks.PERFORMANCED_BY)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISTechworks.LAST_MODIFIED_BY)
            };
			Parameters = parameters;
		}
	}
}

