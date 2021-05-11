using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISLoadmediadtlSelectData : DataAccessBase 
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
		public  RISLoadmediadtlSelectData()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIADTL_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
			return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@LOAD_ID",RIS_LOADMEDIADTL.LOAD_ID)
                ,Parameter("@EXAM_ID",RIS_LOADMEDIADTL.EXAM_ID)
                ,Parameter("@selectcase",RIS_LOADMEDIADTL.SELECTCASE)
			};
            return parameters;
        }
	}
}

