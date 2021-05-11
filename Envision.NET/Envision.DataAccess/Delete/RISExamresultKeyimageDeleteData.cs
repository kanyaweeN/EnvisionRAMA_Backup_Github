using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class RISExamresultKeyimageDeleteData: DataAccessBase
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public RISExamresultKeyimageDeleteData()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTKEYIMAGES_Delete;
		}
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public bool Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();

            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@ACCESSION_NO",RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO),
                                            Parameter("@SL_NO",RIS_EXAMRESULTKEYIMAGES.SL_NO),
                                     };
            return parameters;
        }
    }
}
