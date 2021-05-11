using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISBpviewMappingInsertData : DataAccessBase 
	{
        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }
        public RISBpviewMappingInsertData()
		{
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEWMAPPING_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@EXAM_ID",RIS_BPVIEWMAPPING.EXAM_ID)
,Parameter("@BPVIEW_ID",RIS_BPVIEWMAPPING.BPVIEW_ID)
,Parameter("@NEED_DETAIL",RIS_BPVIEWMAPPING.NEED_DETAIL)
,Parameter("@SL_NO",RIS_BPVIEWMAPPING.SL_NO)
,Parameter("@CREATED_BY",RIS_BPVIEWMAPPING.CREATED_BY)
			            };
            return parameters;
        }
	}
}

