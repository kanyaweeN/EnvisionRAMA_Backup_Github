using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISOrderimagesUpdateData : DataAccessBase 
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE{get;set;}
		private RISOrderimagesInsertDataParameters	_risorderimagesinsertdataparameters;
		public  RISOrderimagesUpdateData()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
		}
		public void Update()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERIMAGES_UpdateStatus.ToString();
            _risorderimagesinsertdataparameters = new RISOrderimagesInsertDataParameters();
            _risorderimagesinsertdataparameters.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risorderimagesinsertdataparameters.Parameters);
		}
        public void UpdateOrder()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERIMAGES_Update.ToString();
            _risorderimagesinsertdataparameters = new RISOrderimagesInsertDataParameters("ORDER");
            _risorderimagesinsertdataparameters.RIS_ORDERIMAGE = RIS_ORDERIMAGE; 
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _risorderimagesinsertdataparameters.Parameters);
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
        public RISOrderimagesInsertDataParameters(string UpOrd)
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            BuildUpdate();
        }
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={
                new SqlParameter("@ORDER_IMAGE_ID",RIS_ORDERIMAGE.ORDER_IMAGE_ID)
                ,new SqlParameter("@IS_DELETED",RIS_ORDERIMAGE.IS_DELETED)
                ,new SqlParameter("@LAST_MODIFIED_BY",RIS_ORDERIMAGE.LAST_MODIFIED_BY)
            };
			Parameters = parameters;
		}
        public void BuildUpdate()
        {
            SqlParameter[] parameters ={
                new SqlParameter("@ORDER_IMAGE_ID",RIS_ORDERIMAGE.ORDER_IMAGE_ID)
                ,new SqlParameter("@ORDER_ID",RIS_ORDERIMAGE.ORDER_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RIS_ORDERIMAGE.LAST_MODIFIED_BY)
            };
            Parameters = parameters;
        }
	}
}

