using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISReleasemediaSelectDataNew : DataAccessBase
    {
        private RISReleasemedia	_risreleasemedia;
        private RISReleasemediaSelectDataNewParameters param;
        public RISReleasemediaSelectDataNew()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RELEASEMEDIA_SelectNew.ToString();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public DataSet GetData()
		{
            param = new RISReleasemediaSelectDataNewParameters(RISReleasemedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISReleasemediaSelectDataNewParameters 
	{
		private RISReleasemedia _risreleasemedia;
		private SqlParameter[] _parameters;
        public RISReleasemediaSelectDataNewParameters(RISReleasemedia risreleasemedia)
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
			SqlParameter[] parameters ={			
                new SqlParameter("@selectcase",RISReleasemedia.SELECTCASE)
                ,new SqlParameter("@ReleaseID",RISReleasemedia.RELEASE_ID)
                ,new SqlParameter("@HN",RISReleasemedia.HN)
                ,new SqlParameter("@ACCESSION",RISReleasemedia.ACCESSION_NO)
			};
			_parameters=parameters;
		}
    }
}
