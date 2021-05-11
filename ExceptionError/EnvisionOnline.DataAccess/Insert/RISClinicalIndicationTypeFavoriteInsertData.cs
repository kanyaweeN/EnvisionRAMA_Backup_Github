using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISClinicalIndicationTypeFavoriteInsertData : DataAccessBase
    {

        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public RISClinicalIndicationTypeFavoriteInsertData()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPEFAVORITE_INSERT;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                           Parameter("@CI_TYPE_ID",RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID),
                           Parameter("@EMP_ID",RIS_CLINICALINDICATIONTYPE.EMP_ID),
                           Parameter("@ORG_ID",RIS_CLINICALINDICATIONTYPE.ORG_ID),
                           Parameter("@CREATED_BY",RIS_CLINICALINDICATIONTYPE.CREATED_BY),
			            };
            return parameters;
        }
    }
}
