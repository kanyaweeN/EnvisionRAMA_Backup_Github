using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISOrderimagesSelectData : DataAccessBase 
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE{get;set;}
		private RISOrderimagesInsertDataParameters	_risorderimagesinsertdataparameters;
		public  RISOrderimagesSelectData()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERIMAGES_Select.ToString();
		}
		public DataSet GetData()
		{
			_risorderimagesinsertdataparameters = new RISOrderimagesInsertDataParameters();
            _risorderimagesinsertdataparameters.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risorderimagesinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class RISOrderimagesInsertDataParameters 
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }
		private SqlParameter[] _parameters;
		public RISOrderimagesInsertDataParameters()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
			Build();
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                //new SqlParameter("@ORDER_IMAGE_ID",RISOrderimages.ORDER_IMAGE_ID)
                //,new SqlParameter("@HN",RISOrderimages.HN)
                new SqlParameter("@ORDER_ID",RIS_ORDERIMAGE.ORDER_ID)
                //,new SqlParameter("@SL_NO",RISOrderimages.SL_NO)
                //,new SqlParameter("@IMAGE_NAME",RISOrderimages.IMAGE_NAME)
                //,new SqlParameter("@ORG_ID",RISOrderimages.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISOrderimages.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISOrderimages.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISOrderimages.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISOrderimages.LAST_MODIFIED_ON)
                ,new SqlParameter("@SCHEDULE_ID",RIS_ORDERIMAGE.SCHEDULE_ID)
            };
			Parameters = parameters;
		}
	}
}

