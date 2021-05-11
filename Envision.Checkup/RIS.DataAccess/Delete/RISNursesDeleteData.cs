using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class RISNursesDeleteData : DataAccessBase
    {
        private RISNursesData	_risnursesdata;
        private RISNursesDeleteDataParameters param;
        public RISNursesDeleteData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATA_Delete.ToString();
		}
        public RISNursesData RISNursesData
		{
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public bool Delete()
		{
            param = new RISNursesDeleteDataParameters(RISNursesData);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISNursesDeleteDataParameters 
	{
		private RISNursesData _risnursesdata;
		private SqlParameter[] _parameters;
        public RISNursesDeleteDataParameters(RISNursesData risnursesdata)
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
new SqlParameter("@NURSE_DATA_UK_ID",RISNursesData.NURSE_DATA_UK_ID)
			};
			_parameters = parameters;
		}
    }
}
