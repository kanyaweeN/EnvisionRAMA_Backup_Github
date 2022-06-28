using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_EXAMRESULTTEMPLATEDeleteData : DataAccessBase 
	{
        public RIS_EXAMRESULTTEMPLATE RIS_EXAMRESULTTEMPLATE { get; set; }

        public RIS_EXAMRESULTTEMPLATEDeleteData()
		{
            RIS_EXAMRESULTTEMPLATE = new RIS_EXAMRESULTTEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATE_Delete;
		}
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@TEMPLATE_ID",RIS_EXAMRESULTTEMPLATE.TEMPLATE_ID)
                                     };
            return parameters;
        }
	}
}

