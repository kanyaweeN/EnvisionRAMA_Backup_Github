using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISRadstudygroupSelectData : DataAccessBase 
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }
		public  RISRadstudygroupSelectData()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
			StoredProcedureName = StoredProcedure.Prc_RIS_RADSTUDYGROUP_Select;
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
                Parameter("@ACCESSION_NO",RIS_RADSTUDYGROUP.ACCESSION_NO)
                ,Parameter("@DateFrom",RIS_RADSTUDYGROUP.DateFrom)
                ,Parameter("@DateTo",RIS_RADSTUDYGROUP.DateTo)
			};
            return parameters;
        }
	}
}

