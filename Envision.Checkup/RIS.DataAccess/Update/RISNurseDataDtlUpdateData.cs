using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;


namespace RIS.DataAccess.Update
{
    public class RISNurseDataDtlUpdateData : DataAccessBase
    {
        private RISNursesDataDtl	_risnursesdatadtl;
        private RISNurseDataDtlUpdateDataParameters param;
        public RISNurseDataDtlUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATADTL_Update.ToString();
		}
		public  RISNursesDataDtl	RISNursesDataDtl
		{
			get{return _risnursesdatadtl;}
			set{_risnursesdatadtl=value;}
		}
		public bool Update()
		{
            param = new RISNurseDataDtlUpdateDataParameters(RISNursesDataDtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISNurseDataDtlUpdateDataParameters 
	{
        private RISNursesDataDtl _risnursesdatadtl;
		private SqlParameter[] _parameters;
        public RISNurseDataDtlUpdateDataParameters(RISNursesDataDtl risnursesdatadtl)
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
                ,new SqlParameter("@DETAIL_DATA_ID",RISNursesDataDtl.DETAIL_DATA_ID)
                ,new SqlParameter("@DETAIL_TIME",RISNursesDataDtl.DETAIL_TIME)
                ,new SqlParameter("@HR_MIN",RISNursesDataDtl.HR_MIN)
                ,new SqlParameter("@RR_MIN",RISNursesDataDtl.RR_MIN)
                ,new SqlParameter("@BP_MMHG",RISNursesDataDtl.BP_MMHG)
                ,new SqlParameter("@O2_SAT",RISNursesDataDtl.O2_SAT)
                ,new SqlParameter("@CONCSIOUS",RISNursesDataDtl.CONCSIOUS)
                ,new SqlParameter("@PROGRESS_NOTE",RISNursesDataDtl.PROGRESS_NOTE)
                ,new SqlParameter("@ORG_ID",RISNursesDataDtl.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISNursesDataDtl.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
    }
}
