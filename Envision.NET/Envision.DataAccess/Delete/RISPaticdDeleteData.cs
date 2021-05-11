using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_PATICDDeleteData : DataAccessBase 
	{
        public RIS_PATICD RIS_PATICD { get; set; }

        public RIS_PATICDDeleteData()
		{
            RIS_PATICD = new RIS_PATICD();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATICD_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@PAT_ICD_ID",RIS_PATICD.PAT_ICD_ID) ,
                                       };
            return parameters;
        }
	}
}

