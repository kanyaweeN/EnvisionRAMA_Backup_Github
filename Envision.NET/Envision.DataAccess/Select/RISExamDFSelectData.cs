using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamDFSelectData : DataAccessBase 
	{
        public RIS_EXAMDF RIS_EXAMDF { get; set; }

		public  RISExamDFSelectData()
		{
            RIS_EXAMDF = new RIS_EXAMDF();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMDF_Select;
		}

		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = new DbParameter[] {
                Parameter("@EXAM_ID",RIS_EXAMDF.EXAM_ID),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
            };
            ds = ExecuteDataSet();
            return ds;
		}
	}
}

