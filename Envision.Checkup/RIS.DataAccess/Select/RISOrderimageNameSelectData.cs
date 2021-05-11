using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISOrderimageNameSelectData : DataAccessBase 
	{
        private int _risordernumber;
		private RISOrderimageNameDataParameters	_risorderimagenamedataparameters;
        public RISOrderimageNameSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDERIMAGES_SelectMinByOrderID.ToString();
		}
		public  int	RISOrderNumber
		{
			get{return _risordernumber;}
			set{_risordernumber=value;}
		}
		public DataSet GetData()
		{
            _risorderimagenamedataparameters = new RISOrderimageNameDataParameters(RISOrderNumber);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risorderimagenamedataparameters.Parameters);
			return ds;
		}
	}
	public class RISOrderimageNameDataParameters 
	{
		private int _risordernumber;
		private SqlParameter[] _parameters;
        public RISOrderimageNameDataParameters(int OrderNumber)
		{
            RISOrderNumber = OrderNumber;
			Build();
		}
        public int RISOrderNumber
		{
			get{return _risordernumber;}
            set { _risordernumber = value; }
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
                new SqlParameter("@ORDER_ID",RISOrderNumber)
                //,new SqlParameter("@SL_NO",RISOrderimages.SL_NO)
                //,new SqlParameter("@IMAGE_NAME",RISOrderimages.IMAGE_NAME)
                //,new SqlParameter("@ORG_ID",RISOrderimages.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISOrderimages.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISOrderimages.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISOrderimages.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISOrderimages.LAST_MODIFIED_ON)
            };
			Parameters = parameters;
		}
	}
}

