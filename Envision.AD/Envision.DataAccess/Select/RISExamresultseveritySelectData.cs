using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresultseveritySelectData : DataAccessBase 
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
		public  RISExamresultseveritySelectData()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSEVERITY_Select;
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
                   Parameter("@UNIT_ID",RIS_EXAMRESULTSEVERITY.UNIT_ID)
			};
            return parameters;
        }
        public DataSet GetSeverityLOG(string AccessionNo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSEVERITYLOG_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters ={			
                   Parameter("@ACCESSION_NO",AccessionNo)
			};
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
	}
}

