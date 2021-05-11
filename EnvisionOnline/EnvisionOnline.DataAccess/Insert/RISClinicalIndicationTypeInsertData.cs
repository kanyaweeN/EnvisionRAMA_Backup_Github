using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISClinicalIndicationTypeInsertData: DataAccessBase
    {

        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public RISClinicalIndicationTypeInsertData()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPE_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter paramPARENT_ID = Parameter();
            paramPARENT_ID.ParameterName = "@PARENT_ID";
            if (RIS_CLINICALINDICATIONTYPE.PARENT_ID == null)
                paramPARENT_ID.Value = DBNull.Value;
            else if (RIS_CLINICALINDICATIONTYPE.PARENT_ID == 0)
                paramPARENT_ID.Value = DBNull.Value;
            else
                paramPARENT_ID.Value = RIS_CLINICALINDICATIONTYPE.PARENT_ID;

            DbParameter[] parameters ={			
                           Parameter("@CI_UID",RIS_CLINICALINDICATIONTYPE.CI_UID),
                           Parameter("@CI_DESC",RIS_CLINICALINDICATIONTYPE.CI_DESC),
                           Parameter("@LEVEL",RIS_CLINICALINDICATIONTYPE.LEVEL),
                           paramPARENT_ID,
            Parameter("@IS_USER_DEFINED",RIS_CLINICALINDICATIONTYPE.IS_USER_DEFINED),
            Parameter("@ORG_ID",RIS_CLINICALINDICATIONTYPE.ORG_ID),
            Parameter("@CREATED_BY",RIS_CLINICALINDICATIONTYPE.CREATED_BY),
			            };
            return parameters;
        }
    }
}
