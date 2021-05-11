using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class RISNursesDtlDeleteData : DataAccessBase
    {
        private RISNursesDataDtl	_risnursesdatadtl;
        private RISNursesDtlDeleteDataParameters param;
        public RISNursesDtlDeleteData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATADTL_Delete.ToString();
		}
        public RISNursesDataDtl RISNursesDataDtl
		{
            get { return _risnursesdatadtl; }
            set { _risnursesdatadtl = value; }
		}
		public bool Delete()
		{
            param = new RISNursesDtlDeleteDataParameters(RISNursesDataDtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISNursesDtlDeleteDataParameters 
	{
		private RISNursesDataDtl _risnursesdatadtl;
		private SqlParameter[] _parameters;
        public RISNursesDtlDeleteDataParameters(RISNursesDataDtl risnursesdatadtl)
		{
            RISNursesDataDtl = risnursesdatadtl;
			Build();
		}
        public RISNursesDataDtl RISNursesDataDtl
		{
            get { return _risnursesdatadtl; }
            set { _risnursesdatadtl = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@NURSE_DATA_UK_ID",RISNursesDataDtl.NURSE_DATA_UK_ID)
                ,new SqlParameter("@DETAIL_DATA_ID" ,RISNursesDataDtl.DETAIL_DATA_ID)
			};
			_parameters = parameters;
		}
    }
}
