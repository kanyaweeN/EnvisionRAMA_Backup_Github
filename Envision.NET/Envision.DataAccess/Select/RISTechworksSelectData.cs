using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISTechworksSelectData : DataAccessBase 
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
		public  RISTechworksSelectData()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKS_Select;
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
                Parameter("@ACCESSION_ON",RIS_TECHWORK.ACCESSION_ON)
                ,Parameter("@TAKE",RIS_TECHWORK.TAKE)
			};
            return parameters;
        }
	}
}

