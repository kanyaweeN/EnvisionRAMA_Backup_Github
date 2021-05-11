using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISTechworksSelectData : DataAccessBase 
	{
		private RISTechworks	_ristechworks;
		private RISTechworksInsertDataParameters	_ristechworksinsertdataparameters;
		public  RISTechworksSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHWORKS_Select.ToString();
		}
		public  RISTechworks	RISTechworks
		{
			get{return _ristechworks;}
			set{_ristechworks=value;}
		}
		public DataSet GetData()
		{
			_ristechworksinsertdataparameters = new RISTechworksInsertDataParameters(RISTechworks);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_ristechworksinsertdataparameters.Parameters);
			return ds;
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
            };
			Parameters = parameters;
		}
	}
}

