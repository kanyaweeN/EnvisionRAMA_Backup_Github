using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class RISExamresultradsDeleteData : DataAccessBase
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS {get;set;}

        public RISExamresultradsDeleteData()
		{
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTRADS_Delete;
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
                                            Parameter("@ACCESSION_NO",RIS_EXAMRESULTRADS.ACCESSION_NO)
                                            ,Parameter("@RAD_ID",RIS_EXAMRESULTRADS.RAD_ID)
                                            ,Parameter("@MODE",RIS_EXAMRESULTRADS.MODE)
                                     };
            return parameters;
        }
    }
}
