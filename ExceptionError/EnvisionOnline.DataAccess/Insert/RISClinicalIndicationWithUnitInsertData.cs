using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISClinicalIndicationWithUnitInsertData: DataAccessBase
    {

        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public RISClinicalIndicationWithUnitInsertData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONWITHUNIT_Insert;
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
                           Parameter("@UNIT_ID",RIS_CLINICALINDICATION.UNIT_ID),
                           Parameter("@ORG_ID",RIS_CLINICALINDICATION.ORG_ID),
                           Parameter("@CREATED_BY",RIS_CLINICALINDICATION.CREATED_BY),
			            };
            return parameters;
        }
    }
}
