using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISOrderexamflagInsertData: DataAccessBase 
	{
        public RIS_ORDEREXAMFLAG RIS_ORDEREXAMFLAG { get; set; }
        public RISOrderexamflagInsertData()
		{
            RIS_ORDEREXAMFLAG = new RIS_ORDEREXAMFLAG();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDEREXAMFLAG_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                            Parameter("@ORDER_ID",RIS_ORDEREXAMFLAG.ORDER_ID)
                            ,Parameter("@SCHEDULE_ID",RIS_ORDEREXAMFLAG.SCHEDULE_ID)
                            ,Parameter("@XRAYREQ_ID",RIS_ORDEREXAMFLAG.XRAYREQ_ID)
                            ,Parameter("@EXAM_ID",RIS_ORDEREXAMFLAG.EXAM_ID)
                            ,Parameter("@EXAMFLAG_ID",RIS_ORDEREXAMFLAG.EXAMFLAG_ID)
                            ,Parameter("@REASON",RIS_ORDEREXAMFLAG.REASON)
                            ,Parameter("@CREATED_BY",RIS_ORDEREXAMFLAG.CREATED_BY)
			            };
            return parameters;
        }
	}
}

