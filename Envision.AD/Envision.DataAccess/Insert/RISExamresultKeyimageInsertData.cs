using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultKeyimageInsertData : DataAccessBase
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public RISExamresultKeyimageInsertData()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTKEYIMAGES_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();

		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
            Parameter("@ACCESSION_NO",RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO)
            ,Parameter("@SL_NO",RIS_EXAMRESULTKEYIMAGES.SL_NO)
            ,Parameter("@KEY_IMAGE",RIS_EXAMRESULTKEYIMAGES.KEY_IMAGE)
            ,Parameter("@ORG_ID",RIS_EXAMRESULTKEYIMAGES.ORG_ID)
            ,Parameter("@CREATED_BY",RIS_EXAMRESULTKEYIMAGES.CREATED_BY)
			            };
            return parameters;
        }
    }
}
