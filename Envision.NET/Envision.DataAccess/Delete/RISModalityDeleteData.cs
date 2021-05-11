using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_MODALITYDeleteData : DataAccessBase 
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }

        public RIS_MODALITYDeleteData()
		{
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@MODALITY_ID",RIS_MODALITY.MODALITY_ID)
                                     };
            return parameters;
        }
	}
}

