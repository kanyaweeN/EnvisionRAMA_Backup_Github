using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISExamresultradsSelectData : DataAccessBase
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS{get;set;}
        public RISExamresultradsSelectData()
        {
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTRADS_Select;
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
                Parameter("@ACCESSION_NO",RIS_EXAMRESULTRADS.ACCESSION_NO)
			};
            return parameters;
        }
    }
}
