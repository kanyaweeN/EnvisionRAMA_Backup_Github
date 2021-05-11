using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class RISNursesDataDtlInsertData : DataAccessBase
    {
        private RISNursesDataDtl	_risnursesdatadtl;
		private RISNursesDataDtlInsertDataParameters	param;
        public RISNursesDataDtlInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATADTL_Insert.ToString();
		}
		public  RISNursesDataDtl	RISNursesDataDtl
		{
			get{return _risnursesdatadtl;}
			set{_risnursesdatadtl=value;}
		}
		public void Add()
		{
            param = new RISNursesDataDtlInsertDataParameters(RISNursesDataDtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
		}
        public void Add(SqlTransaction tran)
        {
            param = new RISNursesDataDtlInsertDataParameters(RISNursesDataDtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, param.Parameters);
        }
	}
	public class RISNursesDataDtlInsertDataParameters 
	{
		private RISNursesDataDtl _risnursesdatadtl;
		private SqlParameter[] _parameters;
        public RISNursesDataDtlInsertDataParameters(RISNursesDataDtl risnursesdatadtl)
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
            
            SqlParameter DetailTime = new SqlParameter();
            if (RISNursesDataDtl.DETAIL_TIME == DateTime.MinValue)
                DetailTime.Value = DBNull.Value;
            else
                DetailTime.Value = RISNursesDataDtl.DETAIL_TIME;

			SqlParameter[] parameters ={
			    new SqlParameter("@NURSE_DATA_UK_ID",RISNursesDataDtl.NURSE_DATA_UK_ID)
                ,DetailTime
                ,new SqlParameter("@HR_MIN",RISNursesDataDtl.HR_MIN)
                ,new SqlParameter("@RR_MIN",RISNursesDataDtl.RR_MIN)
                ,new SqlParameter("@BP_MMHG",RISNursesDataDtl.BP_MMHG)
                ,new SqlParameter("@O2_SAT",RISNursesDataDtl.O2_SAT)
                ,new SqlParameter("@CONCSIOUS",RISNursesDataDtl.CONCSIOUS)
                ,new SqlParameter("@PROGRESS_NOTE",RISNursesDataDtl.PROGRESS_NOTE)
                ,new SqlParameter("@ORG_ID",RISNursesDataDtl.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISNursesDataDtl.CREATED_BY)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISNursesDataDtl.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
    }
}
