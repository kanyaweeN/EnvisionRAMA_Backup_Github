using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_TECHCONSUMPTIONDeleteData : DataAccessBase 
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }
        
        public RIS_TECHCONSUMPTIONDeleteData()
		{
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHCONSUMPTION_Delete;
		}
	
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO"  ,RIS_TECHCONSUMPTION.ACCESSION_NO) ,
                                            Parameter("@TAKE"  ,RIS_TECHCONSUMPTION.TAKE) ,
                                       };
            return parameters;
        }
	}
	
}

