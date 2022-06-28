using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISExamresultKeyimageUpdateData : DataAccessBase
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public RISExamresultKeyimageUpdateData()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTKEYIMAGES_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@ACCESSION_NO",RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO)
,Parameter("@SL_NO",RIS_EXAMRESULTKEYIMAGES.SL_NO)
,Parameter("@LAST_MODIFIED_BY",RIS_EXAMRESULTKEYIMAGES.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
    }
}
