using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISQaworksInsertData : DataAccessBase 
	{
        public RIS_QAWORK RIS_QAWORK { get; set; }
        public RISQaworksInsertData()
		{
            RIS_QAWORK = new RIS_QAWORK();
            StoredProcedureName = StoredProcedure.Prc_RIS_QAWORKS_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_QAWORK.ACCESSION_NO)
                ,Parameter("@QA_RESULT",RIS_QAWORK.QA_RESULT)
                ,Parameter("@COMMENTS",RIS_QAWORK.COMMENTS)
                ,Parameter("@START_TIME",RIS_QAWORK.START_TIME)
                ,Parameter("@END_TIME",RIS_QAWORK.END_TIME)
                ,Parameter("@NO_OF_IMAGES_PRINT",RIS_QAWORK.NO_OF_IMAGES_PRINT)
                ,Parameter("@ORG_ID",RIS_QAWORK.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_QAWORK.CREATED_BY)
            };
            return parameters;
        }
	}
}

