using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_EXAMRESULTSEVERITYDeleteData : DataAccessBase 
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
        public RIS_EXAMRESULTSEVERITYDeleteData()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSEVERITY_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@SEVERITY_ID",RIS_EXAMRESULTSEVERITY.SEVERITY_ID)
                                     };
            return parameters;
        }
	}
}

