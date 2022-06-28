using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultDtlInsertData : DataAccessBase 
	{
        public RIS_EXAMRESULT_DTL RIS_EXAMRESULT_DTL { get; set; }
        public RISExamresultDtlInsertData()
		{
            RIS_EXAMRESULT_DTL = new RIS_EXAMRESULT_DTL();
		}
		public bool Add()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_DTL_Insert;
            ParameterList = new DbParameter[]
            {
                Parameter("@RPT_FINDING_DTL_ITEM_ID",RIS_EXAMRESULT_DTL.RPT_FINDING_DTL_ITEM_ID)
                ,Parameter("@ACCESSION_NO",RIS_EXAMRESULT_DTL.ACCESSION_NO)
                ,Parameter("@ORDER_ID",RIS_EXAMRESULT_DTL.ORDER_ID)
                ,Parameter("@EXAM_ID",RIS_EXAMRESULT_DTL.EXAM_ID)
                ,Parameter("@INPUT_TEXT",RIS_EXAMRESULT_DTL.INPUT_TEXT)
                ,Parameter("@IS_ACTIVE",RIS_EXAMRESULT_DTL.IS_ACTIVE)
                ,Parameter("@ORG_ID",RIS_EXAMRESULT_DTL.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_EXAMRESULT_DTL.CREATED_BY)
            };
            ExecuteNonQuery();
			return true;
		}
	}
}

