using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISExamresultKeyimageSelectData:DataAccessBase
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public RISExamresultKeyimageSelectData()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTKEYIMAGES_Select;
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
                Parameter("@ACCESSION_NO",RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO)
			};
            return parameters;
        }
    }
}
