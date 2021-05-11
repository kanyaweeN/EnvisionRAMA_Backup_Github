using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISClinicalIndicationTypeFavoriteDeleteData : DataAccessBase
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public RISClinicalIndicationTypeFavoriteDeleteData()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATIONTYPEFAVORITE_DELETE;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@CI_TYPE_ID",RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID),
                                        Parameter("@EMP_ID",RIS_CLINICALINDICATIONTYPE.EMP_ID),
                                        Parameter("@ORG_ID",RIS_CLINICALINDICATIONTYPE.ORG_ID)
                                     };
            return parameters;
        }
    }
}
