using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISQaworksInsertData : DataAccessBase 
	{
		private RISQaworks	_risqaworks;
		private RISQaworksInsertDataParameters	_risqaworksinsertdataparameters;
		public  RISQaworksInsertData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAWORKS_Insert.ToString();
		}
		public  RISQaworks	RISQaworks
		{
			get{return _risqaworks;}
			set{_risqaworks=value;}
		}
		public void Add()
		{
			_risqaworksinsertdataparameters = new RISQaworksInsertDataParameters(RISQaworks);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risqaworksinsertdataparameters.Parameters);
		}
	}
	public class RISQaworksInsertDataParameters 
	{
		private RISQaworks _risqaworks;
		private SqlParameter[] _parameters;
		public RISQaworksInsertDataParameters(RISQaworks risqaworks)
		{
			RISQaworks=risqaworks;
			Build();
		}
		public  RISQaworks	RISQaworks
		{
			get{return _risqaworks;}
			set{_risqaworks=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                new SqlParameter("@ACCESSION_NO",RISQaworks.ACCESSION_NO)
                //,new SqlParameter("@SL",RISQaworks.SL)
                ,new SqlParameter("@QA_RESULT",RISQaworks.QA_RESULT)
                ,new SqlParameter("@COMMENTS",RISQaworks.COMMENTS)
                ,new SqlParameter("@START_TIME",RISQaworks.START_TIME)
                ,new SqlParameter("@END_TIME",RISQaworks.END_TIME)
                ,new SqlParameter("@NO_OF_IMAGES_PRINT",RISQaworks.NO_OF_IMAGES_PRINT)
                ,new SqlParameter("@ORG_ID",RISQaworks.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISQaworks.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISQaworks.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISQaworks.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISQaworks.LAST_MODIFIED_ON)
            };
			Parameters = parameters;
		}
	}
}

