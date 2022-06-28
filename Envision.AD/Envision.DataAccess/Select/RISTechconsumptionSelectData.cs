using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISTechconsumptionSelectData : DataAccessBase 
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }
		public  RISTechconsumptionSelectData()
		{
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHCONSUMPTION_Select;
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
                Parameter("@ACCESSION_NO",RIS_TECHCONSUMPTION.ACCESSION_NO)
                ,Parameter("@TAKE",RIS_TECHCONSUMPTION.TAKE)
			};
            return parameters;
        }
        public DataSet GetData(string HN)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHCONSUMPTION_History;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_ByHN(HN);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ByHN(string HN)
        {
            DbParameter[] parameters ={			
                    Parameter("@HN", HN) 
			};
            return parameters;
        }
	}
}

