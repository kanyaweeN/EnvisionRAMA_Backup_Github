using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISNursesDataSelectData : DataAccessBase
    {
        private RISNursesData	_risnursesdata;
		private RISNursesDataSelectDataParameters param;
		public  RISNursesDataSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATA_Select.ToString();
		}
		public  RISNursesData	RISNursesData
		{
			get{return _risnursesdata;}
			set{_risnursesdata=value;}
		}
		public DataSet GetData()
		{
			param = new RISNursesDataSelectDataParameters(RISNursesData);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISNursesDataSelectDataParameters 
	{
		private RISNursesData _risnursesdata;
		private SqlParameter[] _parameters;
        public RISNursesDataSelectDataParameters(RISNursesData risnursesdata)
		{
            RISNursesData = risnursesdata;
			Build();
		}
        public RISNursesData RISNursesData
		{
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
new SqlParameter("@selectcase",_risnursesdata.SELECTCASE)
                ,new SqlParameter("@accessionnoparameter",_risnursesdata.ACCESSIONPARAMETER)
                ,new SqlParameter("@NURSE_DATA_UK_ID", _risnursesdata.NURSE_DATA_UK_ID)
			};
			_parameters=parameters;
		}
    }
}
