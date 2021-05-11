using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;


namespace RIS.DataAccess.Select
{
    public class RISNursesDataDtlSelectData : DataAccessBase
    {
        private RISNursesDataDtl	_risnursesdatadtl;
		private RISNursesDataDtlSelectDataParameters param;
        public RISNursesDataDtlSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATADTL_Select.ToString();
		}
		public  RISNursesDataDtl	RISNursesDataDtl
		{
			get{return _risnursesdatadtl;}
			set{_risnursesdatadtl=value;}
		}
		public DataSet GetData()
		{
			param = new RISNursesDataDtlSelectDataParameters(RISNursesDataDtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISNursesDataDtlSelectDataParameters 
	{
		private RISNursesDataDtl _risnursesdatadtl;
		private SqlParameter[] _parameters;
        public RISNursesDataDtlSelectDataParameters(RISNursesDataDtl risnursesdatadtl)
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
                new SqlParameter("@selectcase",_risnursesdatadtl.SELECTCASE)
                ,new SqlParameter("@NURSE_DATA_UK_ID", _risnursesdatadtl.NURSE_DATA_UK_ID)
			};
			_parameters=parameters;
		}
    }
}
