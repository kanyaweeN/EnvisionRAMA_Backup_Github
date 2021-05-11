using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISInsurancetypeInsertData : DataAccessBase
    {
        public RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }
        public RISInsurancetypeInsertData()
        {
            RIS_INSURANCETYPE = new RIS_INSURANCETYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_INSURANCETYPE_Insert;
        }
        public bool Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        public bool Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@INSURANCE_TYPE_UID",RIS_INSURANCETYPE.INSURANCE_TYPE_UID)
,Parameter("@INSURANCE_TYPE_DESC",RIS_INSURANCETYPE.INSURANCE_TYPE_DESC)
,Parameter("@ORG_ID",RIS_INSURANCETYPE.ORG_ID)
,Parameter("@CREATED_BY",RIS_INSURANCETYPE.CREATED_BY)
			            };
            return parameters;
        }
    }
}

