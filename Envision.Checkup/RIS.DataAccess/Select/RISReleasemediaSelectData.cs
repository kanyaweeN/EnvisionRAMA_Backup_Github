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

namespace RIS.DataAccess.Select
{
	public class RISReleasemediaSelectData : DataAccessBase 
	{
		private RISReleasemedia	_risreleasemedia;
		private RISReleasemediaSelectDataParameters param;
		public  RISReleasemediaSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_RELEASEMEDIA_Select.ToString();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public DataSet GetData()
		{
			param = new RISReleasemediaSelectDataParameters(RISReleasemedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISReleasemediaSelectDataParameters 
	{
		private RISReleasemedia _risreleasemedia;
		private SqlParameter[] _parameters;
		public RISReleasemediaSelectDataParameters(RISReleasemedia risreleasemedia)
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
            SqlParameter datefrom = new SqlParameter();
            datefrom.ParameterName = "@FromDate";
            if (RISReleasemedia.FROMDATE == DateTime.MinValue)
            {
                datefrom.Value = DBNull.Value;
            }
            else
            {
                datefrom.Value = RISReleasemedia.FROMDATE;
            }
            SqlParameter todate = new SqlParameter();
            todate.ParameterName = "@ToDate";
            if (RISReleasemedia.TODATE == DateTime.MinValue)
            {
                todate.Value = DBNull.Value;
            }
            else
            {
                todate.Value = RISReleasemedia.TODATE;
            }
			SqlParameter[] parameters ={			
                new SqlParameter("@RELEASE_ID",RISReleasemedia.RELEASE_ID)
                ,new SqlParameter("@selectcase",RISReleasemedia.SELECTCASE)
                ,datefrom
                ,todate
                ,new SqlParameter("@HN",RISReleasemedia.HN)
			};
			_parameters=parameters;
		}
	}
}

