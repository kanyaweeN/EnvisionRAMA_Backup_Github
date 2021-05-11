using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISClinicalIndicationFavoriteInsertData : DataAccessBase
    {

        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationFavoriteInsertData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONFAVORITES_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                           Parameter("@CI_ID",RIS_CLINICALINDICATION.CI_ID),
                           Parameter("@EMP_ID",RIS_CLINICALINDICATION.EMP_ID),
                           Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID),
                           Parameter("@CREATED_BY",RIS_CLINICALINDICATION.CREATED_BY),
			            };
            return parameters;
        }
    }
}
