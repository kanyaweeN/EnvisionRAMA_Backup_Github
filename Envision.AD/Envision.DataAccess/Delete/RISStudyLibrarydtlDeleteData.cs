using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RISStudyLibrarydtlDeleteData : DataAccessBase 
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }

        public RISStudyLibrarydtlDeleteData()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYDTL_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@RADIOLOGIST_ID",RIS_STUDYLIBRARY.RADIOLOGIST_ID),
                                            Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO)
                                     };
            return parameters;
        }
	}
}

